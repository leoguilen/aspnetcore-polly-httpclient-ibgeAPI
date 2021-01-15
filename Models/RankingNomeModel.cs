using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IbgeService.Models
{
    public class RankingNomeModel
    {
        [JsonPropertyName("localidade")]
        public string Localidade { get; set; }

        [JsonPropertyName("sexo")]
        public string Sexo { get; set; }

        [JsonPropertyName("res")]
        public List<ResultadoRankingNomeModel> Dados { get; set; }
    }
}
