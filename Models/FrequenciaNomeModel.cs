using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IbgeService.Models
{
    public class FrequenciaNomeModel
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("sexo")]
        public string Sexo { get; set; }

        [JsonPropertyName("localidade")]
        public string Localidade { get; set; }

        [JsonPropertyName("res")]
        public List<ResultadoFrequenciaNomeModel> Dados { get; set; }
    }
}
