using System.Text.Json.Serialization;

namespace IbgeService.Models
{
    public class QueryParameters
    {
        public string Sexo { get; set; }
        public string Localidade { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Decada { get; set; }
    }
}
