using System.Text.Json.Serialization;

namespace Parcial2DDA.Models
{   
    public class ResponseTiempoMaximo
    {
        [JsonPropertyName("maximo_tiempo")]
        public string maximo_tiempo { get; set; } = string.Empty;
    }
}