using pix_dynamic_payload_generator.net.ApiResource;
using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests
{
    public class CobOperation : Main
    {
        public CobOperation()
        {
            SetBaseUri("cob");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResponseCob> Create(Cob cob)
        {
            return await PostAsync<ResponseCob>(cob);
        }

        public async Task<ResponseCob> Create(string txId, Cob cob)
        {
            return await PutAsync<ResponseCob>(txId, cob);
        }
    }
}
