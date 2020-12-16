using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Valor
    {
        [JsonProperty("original")]
        public string Original { get; set; }
    }
}
