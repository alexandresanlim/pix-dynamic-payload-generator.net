using pix_dynamic_payload_generator.net.ApiResource;
using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.Base;
using pix_dynamic_payload_generator.net.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests
{
    public class CobRequest : RequestBase
    {
        public CobRequest()
        {
            SetRoute("cob");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CobResponse> Create(Cob cob)
        {
            return await PostAsync<CobResponse>(cob);
        }

        public async Task<CobResponse> Create(string txId, Cob cob)
        {
            return await PutAsync<CobResponse>(txId, cob);
        }

        public async Task<CobResponse> GetByTxId(string txId)
        {
            return await GetAsync<CobResponse>(txId);
        }
    }
}
