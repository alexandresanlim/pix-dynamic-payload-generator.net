using Newtonsoft.Json;
using pix_payload_generator.net.Models.Attributes;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Devedor
    {
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("nome"), MaxLenght(1)]
        public string Nome { get; set; }

        [JsonIgnore]
        public bool IsCNPJ => !string.IsNullOrEmpty(Cnpj);

        [JsonIgnore]
        public bool IsCPF => !string.IsNullOrEmpty(Cpf);

        [JsonIgnore]
        public string DocumentInfo => IsCNPJ ? Cnpj : Cpf;
    }
}
