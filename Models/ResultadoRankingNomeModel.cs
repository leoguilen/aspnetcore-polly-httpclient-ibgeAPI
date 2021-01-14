using System.Text.Json.Serialization;

namespace IbgeService.Models
{
    public class ResultadoRankingNomeModel
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("frequencia")]
        public ulong Frequencia { get; set; }

        [JsonPropertyName("ranking")]
        public int Ranking { get; set; }
    }
}
