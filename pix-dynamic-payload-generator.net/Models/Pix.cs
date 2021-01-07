using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Pix
    {
        [JsonProperty("endToEndId")]
        public string EndToEndId { get; set; }

        [JsonProperty("txid")]
        public string Txid { get; set; }

        [JsonProperty("valor")]
        public string Valor { get; set; }

        [JsonProperty("horario")]
        public DateTime Horario { get; set; }

        [JsonIgnore]
        public decimal ValorToDecimal => Convert.ToDecimal(Valor, new System.Globalization.CultureInfo("en-US"));

        [JsonIgnore]
        public string ValorDisplay => ValorToDecimal.ToString("C");
    }
}
