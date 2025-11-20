using Parcial2DDA.Models;

namespace Parcial2DDA.Services
{
    public interface IBalanzaService
    {
        public Task<ResponseDto> NuevoRegistro(RegistroDto registroRequest);
        public Task<ResponsePesoMaximo> MaximadiferenciaPeso();
        public Task<ResponseTiempoMaximo> MaximoTiempoLocal();
        public Task<ResponseReportesTotales> TotalMedicionesRealizadas();
    }
}