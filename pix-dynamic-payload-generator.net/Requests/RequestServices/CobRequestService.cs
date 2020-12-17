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
    public class CobRequestService : RequestBase
    {
        public CobRequestService()
        {
            SetRoute("cob");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Cob> Create(CobRequest cob)
        {
            return await PostAsync<Cob>(cob);
        }

        public async Task<Cob> Create(string txId, CobRequest cob)
        {
            return await PutAsync<Cob>(txId, cob);
        }

        public async Task<Cob> GetByTxId(string txId)
        {
            return await GetAsync<Cob>(txId);
        }
    }
}
