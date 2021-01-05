using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.ApiResource
{

    public interface IHttpClientWrapper : IDisposable
    {
        /// <summary>
        /// Enviar uma requisição
        /// </summary>
        /// <param name="request">Dados da mensagem da requisição</param>
        /// <returns>resposta da requisição</returns>
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }

    public class StandardHttpClient : IHttpClientWrapper
    {
        private readonly HttpClient client;

        public StandardHttpClient()
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(StartConfig.Certificate);

            var token = Requests.RequestServices.TokenService.Create(); //StartConfig.GetToken();

            client = new HttpClient(handler);
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Enviar uma requisição
        /// </summary>
        /// <param name="requestMessage">Dados da mensagem da requisição</param>
        /// <returns>resposta da requisição</returns>
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage)
        {
            var response = await client.SendAsync(requestMessage).ConfigureAwait(false);
            return response;
        }

        public void Dispose()
        {
            client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
