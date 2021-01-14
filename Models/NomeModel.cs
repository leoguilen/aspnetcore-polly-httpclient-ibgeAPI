using System.Text.Json.Serialization;

namespace IbgeService.Models
{
    public class NomeModel
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("regiao")]
        public int Regiao { get; set; }

        [JsonPropertyName("freq")]
        public int Frequencia { get; set; }

        [JsonPropertyName("rank")]
        public int Ranking { get; set; }

        [JsonPropertyName("sexo")]
        public string Sexo { get; set; }
    }
}
