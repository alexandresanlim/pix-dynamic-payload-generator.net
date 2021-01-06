using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Responses.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Responses
{
    public class PixConsultaResponse
    {
        [JsonProperty("parametros")]
        public Parametros Parametros { get; set; }

        [JsonProperty("pix")]
        public List<Pix> Pix { get; set; }
    }
}
