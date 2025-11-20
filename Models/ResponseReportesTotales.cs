using System.Text.Json.Serialization;

namespace Parcial2DDA.Models
{   
    public class ResponseReportesTotales
    {
        [JsonPropertyName("total_mediciones_realizadas")]
        public string Total_mediciones_realizadas { get; set; } = string.Empty;
    }
}