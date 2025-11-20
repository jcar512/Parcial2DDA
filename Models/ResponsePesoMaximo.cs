using System.Text.Json.Serialization;

namespace Parcial2DDA.Models
{   
    public class ResponsePesoMaximo
    {
        [JsonPropertyName("maxima_diferencia_peso")]
        public string Maxima_diferencia_peso { get; set; } = string.Empty;
    }
}