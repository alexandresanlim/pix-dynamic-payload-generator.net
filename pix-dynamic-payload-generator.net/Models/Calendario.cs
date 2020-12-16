using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Calendario
    {
        [JsonProperty("expiracao")]
        public int Expiracao { get; set; }

        //[JsonProperty("criacao")]
        //public DateTime Criacao { get; set; }
    }
}
