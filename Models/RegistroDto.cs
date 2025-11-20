using System.Text.Json.Serialization;

namespace Parcial2DDA.Models
{
    public class RegistroDto
    {
        [JsonPropertyName("Huella")]
        public string huella { get; set;} = string.Empty;

        [JsonPropertyName("Peso")]
        public string peso { get; set;} = string.Empty;

        [JsonPropertyName("Tipo")]
        public string tipo { get; set;} = string.Empty;
    }
}