using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Models.Attributes;
using pix_dynamic_payload_generator.net.Requests.RequestModels.Base;

namespace pix_dynamic_payload_generator.net.Requests.RequestModels
{
    public class CobRequest : CobBaseRequest
    {
        public CobRequest(string _chave) : base(_chave)
        {
        }

        [JsonProperty("calendario")]
        public CalendarioBase Calendario { get; set; }

        [JsonProperty("devedor"), DevedorRequest]
        public Devedor Devedor { get; set; }

        ///// <summary>
        ///// valores monetários referentes à cobrança.
        ///// </summary>
        //[JsonProperty("valor")]
        //public Valor Valor { get; set; }
    }
}
