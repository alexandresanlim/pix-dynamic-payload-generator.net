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

        [JsonProperty("pixCopiaECola")]
        public string PixCopiaECola { get; set; }

        [JsonProperty("revisao")]
        public int Revisao { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("pix")]
        public List<Pix> Pix { get; set; }

        [JsonIgnore]
        public decimal PixValorTotal => HasPix ? Pix.Sum(x => x.ValorToDecimal) : 0;

        [JsonIgnore]
        public string PixValorTotalDisplay => PixValorTotal.ToString("C");

        [JsonIgnore]
        public decimal PixValorTotalDevolucao => HasPix ? Pix.Sum(x => x.DevolucoesTotal) : 0;

        [JsonIgnore]
        public string PixValorTotalDevolucaoDisplay => PixValorTotalDevolucao.ToString("C");

        [JsonIgnore]
        public decimal PixValorFinal => PixValorTotal - PixValorTotalDevolucao;

        [JsonIgnore]
        public string PixValorFinalDisplay => PixValorFinal.ToString("C");

        [JsonIgnore]
        public string StatusDisplay => StatusOnEnum.ToDisplay();

        [JsonIgnore]
        public string StatusPagamentoDisplay => StatusPagamento.ToDisplay();

        [JsonIgnore]
        public bool HasPix => Pix != null && Pix.Count > 0;

        [JsonIgnore]
        public int PixCount => HasPix ? Pix.Count : 0;

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

                return PixValorFinal == Valor.ToDecimal ? PaymenStatus.PAGO_TOTALMENTE : PaymenStatus.PAGO_PARCIALMENTE;
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
            return new DynamicPayload(cob.Txid, merchant, cob.Location, uniquePayment, cob.Valor.Original);
        }

        public static string ToDisplay(this PaymenStatus paymenStatus)
        {
            switch (paymenStatus)
            {
                case PaymenStatus.NAO_PAGO:
                    return "Não Pago";
                case PaymenStatus.PAGO_PARCIALMENTE:
                    return "Pago Parcialmente";
                case PaymenStatus.PAGO_TOTALMENTE:
                    return "Pago Totalmente";
                case PaymenStatus.NOT_FOUND:
                default:
                    return "Não encontrado";
            }
        }

        public static string ToDisplay(this CobStatus cobStatus)
        {
            switch (cobStatus)
            {
                case CobStatus.ATIVA:
                    return "Ativa";
                case CobStatus.CONCLUIDA:
                    return "Concluída";
                case CobStatus.REMOVIDA_PELO_USUARIO_RECEBEDOR:
                    return "Removida pelo usuário recebedor";
                case CobStatus.REMOVIDA_PELO_PSP:
                    return "Removida pelo PSP";
                case CobStatus.NOT_FOUND:
                default:
                    return "Não Encontrado";
            }
        }
    }
}
