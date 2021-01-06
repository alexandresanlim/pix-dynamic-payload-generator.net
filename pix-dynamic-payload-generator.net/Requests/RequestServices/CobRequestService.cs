using pix_dynamic_payload_generator.net.ApiResource;
using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_dynamic_payload_generator.net.Requests.RequestServices.Base;
using pix_dynamic_payload_generator.net.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests.RequestServices
{
    /// <summary>
    /// Reúne endpoints destinados a lidar com gerenciamento de cobranças imediatas.
    /// </summary>
    public class CobRequestService : RequestBase
    {
        public CobRequestService()
        {
            SetRoute("cob");
        }

        /// <summary>
        /// Criar cobrança imediata
        /// </summary>
        /// <param name="cob"></param>
        /// <returns></returns>
        public async Task<Cob> Create(CobRequest cob)
        {
            return await PostAsync<Cob>(cob);
        }

        /// <summary>
        /// Criar cobrança imediata usando um identificador
        /// </summary>
        /// <param name="txId"></param>
        /// <param name="cob"></param>
        /// <returns></returns>
        public async Task<Cob> Create(string txId, CobRequest cob)
        {
            return await PutAsync<Cob>(txId, cob);
        }

        /// <summary>
        /// Consultar cobrança imediata usando o txId
        /// </summary>
        /// <param name="txId"></param>
        /// <returns></returns>
        public async Task<Cob> GetByTxId(string txId)
        {
            return await GetAsync<Cob>("/" + txId);
        }

        /// <summary>
        /// Consultar lista de cobranças
        /// </summary>
        /// <param name="startDate">A partir de</param>
        /// <param name="endDate">Até (se não informado, por padrão será adicionado 24 horas a partir do startdate)</param>
        /// <returns></returns>
        public async Task<CobConsultaResponse> GetByPeriod(DateTime startDate, DateTime? endDate = null)
        {
            endDate = endDate ?? startDate.AddHours(24);

            return await GetAsync<CobConsultaResponse>("?inicio=" + startDate.ToString("u") + "&fim=" + endDate.Value.ToString("u"));
        }
    }
}
