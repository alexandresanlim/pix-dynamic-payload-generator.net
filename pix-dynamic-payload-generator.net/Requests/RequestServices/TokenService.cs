using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_dynamic_payload_generator.net.Requests.RequestServices.Base;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net.Requests.RequestServices
{
    public static class TokenService
    {
        private static Token LastToken { get; set; }

        public static Token Create()
        {
            if (!string.IsNullOrEmpty(LastToken?.AccessToken))
                return LastToken;

            var byteArray = new UTF8Encoding().GetBytes(StartConfig.ClientId + ":" + StartConfig.ClientSecret);

            var handler = new HttpClientHandler();

            handler.ClientCertificates.Add(StartConfig.Certificate);

            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, StartConfig.BaseUrl + StartConfig.AuthEndpoint))
            {
                if (StartConfig.UseUrlFormEncodedForAuth)
                {
                    var content = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("client_id", StartConfig.ClientId),
                        new KeyValuePair<string, string>("client_secret", StartConfig.ClientSecret),
                        new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    };
                    if (!string.IsNullOrEmpty(StartConfig.AuthScopes))
                    {
                        content.Add(new KeyValuePair<string, string>("scope", StartConfig.AuthScopes));
                    }
                    
                    requestMessage.Content = new FormUrlEncodedContent(content);
                }
                else
                {
                    const string content = "{\r\n    \"grant_type\": \"client_credentials\"\r\n}";
                    requestMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
                }

                var s = client.SendAsync(requestMessage).Result;

                var data = s.Content.ReadAsStringAsync().Result;

                if (s.IsSuccessStatusCode)
                    LastToken = JsonConvert.DeserializeObject<Token>(data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                else
                    throw new ArgumentException(data);

                return LastToken;
            }
        }
    }
}
