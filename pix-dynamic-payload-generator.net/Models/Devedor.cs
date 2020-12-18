using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Devedor
    {
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }
    }
}
