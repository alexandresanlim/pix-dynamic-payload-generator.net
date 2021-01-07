using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Pix
    {
        [JsonProperty("endToEndId")]
        public string EndToEndId { get; set; }

        [JsonProperty("txid")]
        public string Txid { get; set; }

        [JsonProperty("valor")]
        public string Valor { get; set; }

        [JsonProperty("horario")]
        public DateTime Horario { get; set; }

        [JsonProperty("infoPagador")]
        public string InfoPagador { get; set; }

        [JsonProperty("devolucoes")]
        public List<Devolucao> Devolucoes { get; set; }

        [JsonIgnore]
        public decimal DevolucoesTotal => HasDevolucao ? Devolucoes.Sum(x => x.ValorToDecimal) : 0;

        [JsonIgnore]
        public string DevolucoesTotalDisplay => DevolucoesTotal.ToString("C");

        [JsonIgnore]
        public decimal ValorToDecimal => Valor.ToDecimalUSCulture();

        [JsonIgnore]
        public decimal ValorFinal => ValorToDecimal - DevolucoesTotal;

        [JsonIgnore]
        public string ValorFinalDisplay => ValorFinal.ToString("C");

        [JsonIgnore]
        public string ValorDisplay => ValorToDecimal.ToString("C");

        [JsonIgnore]
        public string HorarioDisplay => Horario.ToDisplay();

        [JsonIgnore]
        public bool HasDevolucao => Devolucoes != null && Devolucoes.Count > 0;
    }
}
