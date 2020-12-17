using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models
{
    public class InfoAdicional
    {
        /// <summary>
        /// maxLength: 50
        /// Nome do campo.
        /// </summary>
        [JsonProperty("nome")]
        public string Nome { get; set; }

        /// <summary>
        /// maxLength: 200
        /// Dados do campo.
        /// </summary>
        [JsonProperty("valor")]
        public string Valor { get; set; }
    }
}
