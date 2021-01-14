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
        public ICollection<ResultadoRankingNomeModel> Dados { get; set; }
    }
}
