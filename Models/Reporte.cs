using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2DDA.Models
{
    public class Reporte
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TotalMedicionesRealizadas { get; set; }
        public double MaximaDiferenciaPeso { get; set; }
        public string MaximaDiferenciaTiempoString { get; set; }
        public TimeSpan MaximaDiferenciaTiempoTimeSpan { get; set; }

        public Reporte(
            int totalMedicionesRealizadas,
            double maximaDiferenciaPeso,
            string maximaDiferenciaTiempoString,
            TimeSpan maximaDiferenciaTiempoTimeSpan)
        {
            TotalMedicionesRealizadas = totalMedicionesRealizadas;
            MaximaDiferenciaPeso = maximaDiferenciaPeso;
            MaximaDiferenciaTiempoString = maximaDiferenciaTiempoString;
            MaximaDiferenciaTiempoTimeSpan  = maximaDiferenciaTiempoTimeSpan;
        }
    }
}