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
        public async Task<Cob> Create(CobrancaRequest cob)
        {
            return await PostAsync<Cob>(cob);
        }

        /// <summary>
        /// Criar cobrança imediata usando um identificador
        /// </summary>
        /// <param name="txId"></param>
        /// <param name="cob"></param>
        /// <returns></returns>
        public async Task<Cob> Create(string txId, CobrancaRequest cob)
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
            return await GetAsync<Cob>(txId);
        }
    }
}
