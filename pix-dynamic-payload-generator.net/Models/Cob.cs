using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Models.Cobranca;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Cob : CobrancaImediataSolicitada
    {
        [JsonProperty("txid")]
        public string Txid { get; set; }

        [JsonProperty("revisao")]
        public int Revisao { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
