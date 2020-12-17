using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Calendario
    {
        /// <summary>
        /// title: Tempo de vida da cobrança, especificado em segundos.
        /// example: 360
        /// default: 8640
        /// Tempo de vida da cobrança, especificado em segundos a partir da data de criação(Calendario.criacao)
        /// </summary>
        [JsonProperty("expiracao")]
        public int Expiracao { get; set; }

        //[JsonProperty("criacao")]
        //public DateTime Criacao { get; set; }
    }
}
