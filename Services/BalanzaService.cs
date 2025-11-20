using System.Security.AccessControl;
using Azure;
using Microsoft.EntityFrameworkCore;
using Parcial2DDA.Data;
using Parcial2DDA.Models;

namespace Parcial2DDA.Services
{
    public class BalanzaService : IBalanzaService
    {
        private readonly AppDbContext _context;

        public BalanzaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto> NuevoRegistro(RegistroDto registroRequest)
        {
            if(registroRequest == null)
            {
                throw new ArgumentNullException(nameof(registroRequest));
            }

            if(registroRequest.tipo == "entrada")
            {
                Registro nuevoRegistroEntrada = new Registro(
                    registroRequest.huella,
                    Double.Parse(registroRequest.peso),
                    registroRequest.tipo,
                    DateTime.Now
                );

                await _context.AddAsync(nuevoRegistroEntrada);
                await _context.SaveChangesAsync();

                return new ResponseDto{diferenciaPeso = "Todavia no hay una salida", diferenciaTiempo = "0"};
            }else if(registroRequest.tipo == "salida")
            {
                Registro? registro = await _context
                .Registros
                .FirstOrDefaultAsync(r => r.Huella == registroRequest.huella);

                if(registro == null) throw new ArgumentException("No se encontro un registro con esa huella");

                Registro nuevoRegistroSalida = new Registro(
                    registroRequest.huella,
                    Double.Parse(registroRequest.peso),
                    registroRequest.tipo,
                    DateTime.Now
                );                

                long ts1 = new DateTimeOffset(registro.IngresoRegistro).ToUnixTimeSeconds();                
                long ts2 = new DateTimeOffset(nuevoRegistroSalida.IngresoRegistro).ToUnixTimeSeconds();

                long diferenciaTiempo = ts2 - ts1;             

                TimeSpan timeSpan = nuevoRegistroSalida.IngresoRegistro.Subtract(registro.IngresoRegistro);

                string tiempoString = $"{timeSpan.Hours} horas, {timeSpan.Minutes} minutos, {timeSpan.Seconds} segundos";

                double diferenciaPeso = nuevoRegistroSalida.Peso - registro.Peso;

                Reporte? reporte = await _context.Reportes.FirstOrDefaultAsync(r => r.Id == 1);

                if (reporte == null)
                {
                    Reporte inicializarReporte = new Reporte
                    (
                        1,
                        diferenciaPeso,
                        tiempoString,
                        timeSpan
                    );

                    await _context.AddAsync(inicializarReporte);
                    await _context.SaveChangesAsync();
                }else{
                    reporte.TotalMedicionesRealizadas ++;
                    if(reporte.MaximaDiferenciaTiempoTimeSpan < timeSpan) reporte.MaximaDiferenciaTiempoTimeSpan = timeSpan;
                    if(reporte.MaximaDiferenciaPeso < diferenciaPeso) reporte.MaximaDiferenciaPeso = diferenciaPeso;

                    await _context.SaveChangesAsync();
                }

                _context.Remove(registro);
                await _context.SaveChangesAsync();

               
                return new ResponseDto
                {
                    diferenciaPeso = diferenciaPeso.ToString(),
                    diferenciaTiempo = diferenciaTiempo.ToString()
                };
            }

            throw new ArgumentException($"Tipo ingresado invalido: {registroRequest.tipo}. Debe ser 'entrada' o 'salida'.");           
        }

        public async Task<ResponsePesoMaximo> MaximadiferenciaPeso()
        {
            Reporte? reporte = await _context.Reportes.FirstOrDefaultAsync(r => r.Id == 1);
            if (reporte == null) return new ResponsePesoMaximo{Maxima_diferencia_peso = "Todavia no hay un reporte"};

            return new ResponsePesoMaximo{Maxima_diferencia_peso = reporte.MaximaDiferenciaPeso.ToString()};
        }

        public async Task<ResponseTiempoMaximo> MaximoTiempoLocal()
        {
            Reporte? reporte = await _context.Reportes.FirstOrDefaultAsync(r => r.Id == 1);
            if (reporte == null) return new ResponseTiempoMaximo {maximo_tiempo = "Todavia no hay un reporte"};

            return new ResponseTiempoMaximo{maximo_tiempo = reporte.MaximaDiferenciaTiempoString};
        }
        public async Task<ResponseReportesTotales> TotalMedicionesRealizadas()
        {
            Reporte? reporte = await _context.Reportes.FirstOrDefaultAsync(r => r.Id == 1);
            if (reporte == null) return new ResponseReportesTotales{Total_mediciones_realizadas = "Todavia no hay un reporte"};

            return new ResponseReportesTotales{Total_mediciones_realizadas = reporte.TotalMedicionesRealizadas.ToString()};
        }
    }
}