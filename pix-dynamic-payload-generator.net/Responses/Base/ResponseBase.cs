using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Responses.Base
{
    public class ResponseBase
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("violacoes")]
        public List<Violacao> Violacoes { get; set; }
    }

    public class Violacao
    {
        [JsonProperty("razao")]
        public string Razao { get; set; }

        [JsonProperty("propriedade")]
        public string Propriedade { get; set; }
    }
}
