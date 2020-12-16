using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.ApiResource;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests.Base
{
    public class RequestBase : IRequestBase
    {
        private readonly IHttpClientWrapper client;

        private readonly JsonSerializerSettings JsonSettings;

        /// <summary>
        /// 
        /// </summary>
        private string BaseURI { get; set; }

        public void SetBaseUri(string value)
        {
            BaseURI = Start.BaseUrl + "/v2/" + value;
        }

        public string GetBaseURI()
        {
            return BaseURI;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customClient"></param>
        /// <param name="customJsonSerializerSettings"></param>
        public RequestBase(IHttpClientWrapper customClient, JsonSerializerSettings customJsonSerializerSettings = null)
        {
            client = customClient;
            JsonSettings = customJsonSerializerSettings ?? new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        }

        /// <summary>
        /// 
        /// </summary>
        public RequestBase() : this(new StandardHttpClient(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            client.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(object data)
        {
            //var completeUrl = GetCompleteUrl();
            var response = await SendRequestAsync(HttpMethod.Get, GetBaseURI(), data).ConfigureAwait(false);
            return await ProcessResponse<T>(response).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public async Task<T> PostAsync<T>(object data, Dictionary<string, string> headers = null)
        {
            try
            {
                var b = GetBaseURI();

                var response = await SendRequestAsync(HttpMethod.Post, b, data, null, headers).ConfigureAwait(false);

                return await ProcessResponse<T>(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public async Task<T> PutAsync<T>(string txId, object data, Dictionary<string, string> headers = null)
        {
            try
            {
                var b = GetBaseURI() + "/" + txId;

                var response = await SendRequestAsync(HttpMethod.Put, b, data, null, headers).ConfigureAwait(false);

                return await ProcessResponse<T>(response).ConfigureAwait(false);
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        private async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<T>(data, JsonSettings)).ConfigureAwait(false);
            }

            throw new ArgumentException(data);
        }

        private async Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string url, object data = null, string customToken = null, Dictionary<string, string> headers = null)
        {
            using (var requestMessage = new HttpRequestMessage(method, url))
            {
                await SetContent(data, requestMessage);

                if (headers != null)
                {
                    foreach (var i in headers)
                    {
                        requestMessage.Headers.Add(i.Key, i.Value);
                    }
                }

                return await client.SendAsync(requestMessage).ConfigureAwait(false);
            }
        }

        private async Task SetContent(object data, HttpRequestMessage requestMessage)
        {
            if (data != null)
            {
                var content = await Task.FromResult(JsonConvert.SerializeObject(data, JsonSettings)).ConfigureAwait(false);
                requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");

            }
        }
    }
}
