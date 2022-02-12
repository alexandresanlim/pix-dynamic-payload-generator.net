﻿using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Extentions;
using System;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Calendario : CalendarioBase
    {
        [JsonProperty("criacao")]
        public DateTime Criacao { get; set; }

        [JsonIgnore]
        public string CriacaoDisplay => Criacao.ToDisplay();
    }

    public class CalendarioBase
    {
        /// <summary>
        /// title: Tempo de vida da cobrança, especificado em segundos.
        /// example: 360
        /// default: 8640
        /// Tempo de vida da cobrança, especificado em segundos a partir da data de criação(Calendario.criacao)
        /// </summary>
        [JsonProperty("expiracao")]
        public int Expiracao { get; set; }
    }
}
