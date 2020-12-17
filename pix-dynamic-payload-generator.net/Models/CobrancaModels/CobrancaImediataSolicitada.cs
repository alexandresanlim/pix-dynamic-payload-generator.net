using Newtonsoft.Json;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models.CobrancaModels
{
    /// <summary>
    /// Dados enviados para criação ou alteração da cobrança imediata via API Pix
    /// </summary>
    public class CobrancaImediataSolicitada : Cobranca
    {
        public CobrancaImediataSolicitada(string _chave) : base(_chave)
        {
        }

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
