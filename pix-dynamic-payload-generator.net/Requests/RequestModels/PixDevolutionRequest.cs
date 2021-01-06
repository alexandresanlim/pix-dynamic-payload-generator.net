using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Requests.RequestModels
{
    public class PixDevolutionRequest
    {
        [JsonProperty("valor")]
        public string Valor { get; set; }
    }
}
