using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Extentions;
using pix_dynamic_payload_generator.net.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Devolucao
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("rtrId")]
        public string RtrId { get; set; }

        [JsonProperty("valor")]
        public string Valor { get; set; }

        [JsonProperty("horario")]
        public Horario Horario { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonIgnore]
        public decimal ValorToDecimal => Valor.ToDecimalUSCulture();

        [JsonIgnore]
        public string ValorDisplay => ValorToDecimal.ToString("C");
    }
}
