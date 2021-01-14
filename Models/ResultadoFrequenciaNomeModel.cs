using System.Text.Json.Serialization;

namespace IbgeService.Models
{
    public class ResultadoFrequenciaNomeModel
    {
        [JsonPropertyName("periodo")]
        public string Periodo { get; set; }

        [JsonPropertyName("frequencia")]
        public int Frequencia { get; set; }
    }
}
