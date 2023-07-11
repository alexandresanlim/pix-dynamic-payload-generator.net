using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.RequestModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Requests.RequestModels
{
    public class CobVRequest
    {
        [JsonProperty("chave")]
        public string Chave { get; set; }

        [JsonProperty("solicitacaoPagador")]
        public string SolicitacaoPagador { get; set; }

        [JsonProperty("calendario")]
        public CalendarioCobV Calendario { get; set; }

        [JsonProperty("loc")]
        public LocCobV Loc { get; set; }

        [JsonProperty("devedor")]
        public DevedorCobV Devedor { get; set; }

        [JsonProperty("valor")]
        public ValorCobV ValorCobV { get; set; }
    }

    public class ValorCobV
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("multa")]
        public Multa Multa { get; set; }

        [JsonProperty("juros")]
        public Juros Juros { get; set; }

        [JsonProperty("desconto")]
        public Desconto Desconto { get; set; }
    }

    public class Multa
    {
        [JsonProperty("modalidade")]
        public string Modalidade { get; set; }

        [JsonProperty("valorPerc")]
        public string ValorPerc { get; set; }
    }

    public class Juros
    {
        [JsonProperty("modalidade")]
        public string Modalidade { get; set; }

        [JsonProperty("valorPerc")]
        public string ValorPerc { get; set; }
    }

    public class Desconto
    {
        [JsonProperty("modalidade")]
        public string Modalidade { get; set; }

        [JsonProperty("descontoDataFixa")]
        public List<DescontoDataFixa> DescontoDataFixa { get; set; }
    }

    public class DescontoDataFixa
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("valorPerc")]
        public string ValorPerc { get; set; }
    }

    public class DevedorCobV: Devedor
    {
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }
    }

    public class CalendarioCobV
    {
        [JsonProperty("dataDeVencimento")]
        public string DataDeVencimento { get; set; }

        [JsonProperty("validadeAposVencimento")]
        public int ValidadeAposVencimento { get; set; }
    }

    public class LocCobV
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }

}
