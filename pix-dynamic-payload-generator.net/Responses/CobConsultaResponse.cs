using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Responses
{
    public class CobConsultaResponse
    {

        [JsonProperty("parametros")]
        public Parametros Parametros { get; set; }

        [JsonProperty("cobs")]
        public List<Cob> Cobs { get; set; }
    }

    public class Parametros
    {
        [JsonProperty("inicio")]
        public DateTime Inicio { get; set; }

        [JsonProperty("fim")]
        public DateTime Fim { get; set; }

        [JsonProperty("paginacao")]
        public Paginacao Paginacao { get; set; }
    }

    public class Paginacao
    {
        [JsonProperty("paginaAtual")]
        public int PaginaAtual { get; set; }

        [JsonProperty("itensPorPagina")]
        public int ItensPorPagina { get; set; }

        [JsonProperty("quantidadeDePaginas")]
        public int QuantidadeDePaginas { get; set; }

        [JsonProperty("quantidadeTotalDeItens")]
        public int QuantidadeTotalDeItens { get; set; }
    }
}
