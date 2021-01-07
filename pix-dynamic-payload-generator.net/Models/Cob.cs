using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pix_dynamic_payload_generator.net.Models
{
    public class Cob : CobrancaImediataSolicitada
    {
        public Cob(string _chave) : base(_chave)
        {
        }

        [JsonProperty("txid")]
        public string Txid { get; set; }

        [JsonProperty("revisao")]
        public int Revisao { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("pix")]
        public List<Pix> Pix { get; set; }

        [JsonIgnore]
        public CobStatus StatusOnEnum
        {
            get
            {
                CobStatus result;
                return Enum.TryParse<CobStatus>(Status, true, out result) ? result : CobStatus.NOT_FOUND;
            }
        }

        [JsonIgnore]
        public PaymenStatus StatusPagamento
        {
            get
            {
                if (StatusOnEnum == CobStatus.NOT_FOUND)
                    return PaymenStatus.NOT_FOUND;

                if (StatusOnEnum == CobStatus.ATIVA)
                    return PaymenStatus.NAO_PAGO;

                return Pix.Sum(x => x.ValorToDecimal) == Valor.ToDecimal ? PaymenStatus.PAGO_TOTALMENTE : PaymenStatus.PAGO_PARCIALMENTE;
            }
        }
    }

    public enum CobStatus
    {
        NOT_FOUND = -1,
        ATIVA,
        CONCLUIDA,
        REMOVIDA_PELO_USUARIO_RECEBEDOR,
        REMOVIDA_PELO_PSP
    }

    public enum PaymenStatus
    {
        NOT_FOUND = -1,
        NAO_PAGO,
        PAGO_PARCIALMENTE,
        PAGO_TOTALMENTE
    }

    public static class CobExtention
    {
        public static Payload ToPayload(this Cob cob, Merchant merchant, bool uniquePayment = false)
        {
            return new DynamicPayload(cob.Txid, merchant, cob.Location, uniquePayment, cob.Valor.ToDecimal);
        }
    }
}
