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
            var authorize = new Authorize(
                _baseUrl: "https://api-pix-h.gerencianet.com.br/oauth/token",
                _clientId: "Client_Id_51d92e9836716a4ab9b3ec1d9d34f6644ac28d69",
                _clientSecret: "Client_Secret_0ab77acbf2bde2cc40a1162f596846fa75ff710e",
                _certificate: @".\certificado.p12"
                );

            var token = authorize.GetToken();

            var headers = new Dictionary<string, string>
            {
                //{"Cache-Control", "no-cache" },
                //{"Content-type", "application/json" },
                {"Authorization", token.TypeAndAccess}
            };

            return await PostAsync<ResponseCob>(cob, headers);
        }

        public async Task<ResponseCob> Create(string txId, Cob cob)
        {
            var authorize = new Authorize(
                _baseUrl: "https://api-pix-h.gerencianet.com.br/oauth/token",
                _clientId: "Client_Id_51d92e9836716a4ab9b3ec1d9d34f6644ac28d69",
                _clientSecret: "Client_Secret_0ab77acbf2bde2cc40a1162f596846fa75ff710e",
                _certificate: @".\certificado.p12"
                );

            var token = authorize.GetToken();



            var headers = new Dictionary<string, string>
            {
                //{"Cache-Control", "no-cache" },
                //{"Content-type", "application/json" },
                {"Authorization", token.TypeAndAccess}
            };

            return await PutAsync<ResponseCob>(txId, cob, headers);
        }
    }
}
