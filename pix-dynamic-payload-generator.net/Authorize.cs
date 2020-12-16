using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace pix_dynamic_payload_generator.net
{
    public class Authorize
    {
        public Authorize(string _baseUrl, string _clientId, string _clientSecret, string _certificate)
        {
            BaseUrl = _baseUrl;
            ClientId = _clientId;
            ClientSecret = _clientSecret;
            Certificate = _certificate;
        }

        /// <summary>
        /// Url da api pix do PSP
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// ClientId do oauth 2 do PSP
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// ClientSecret do oauth 2 do PSP
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Caminho absoluto do certificado
        /// </summary>
        public string Certificate { get; set; }

        public Responses.TokenResponse GetToken()
        {
            var byteArray = new UTF8Encoding().GetBytes(ClientId + ":" + ClientSecret);

            //O certificado tem que ser definido como "copy always"
            X509Certificate2 uidCert = new X509Certificate2(Certificate);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUrl);

            request.ClientCertificates.Add(uidCert);
            request.Method = "POST";
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(byteArray));
            request.Headers.Add("Content-Type", "application/json");
            request.ContentType = "application/json";

            using (var streamWriter = new System.IO.StreamWriter(request.GetRequestStream()))
            {
                var json = "{\r\n    \"grant_type\": \"client_credentials\"\r\n}";
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Responses.TokenResponse>(result);
            }
        }
    }
}
