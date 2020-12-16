using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models
{
    public class InfoAdicional
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("valor")]
        public string Valor { get; set; }
    }
}
