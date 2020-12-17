using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models.Cobranca
{
    /// <summary>
    /// Dados enviados para criação ou alteração da cobrança imediata via API Pix
    /// </summary>
    public class CobrancaImediataSolicitada : CobrancaBase
    {
        [JsonProperty("calendario")]
        public Calendario Calendario { get; set; }

        [JsonProperty("devedor")]
        public Devedor Devedor { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("loc")]
        public Loc Loc { get; set; }
    }
}
