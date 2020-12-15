using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public string GetToken()
        {
            var byteArray = new UTF8Encoding().GetBytes("Client_Id_51d92e9836716a4ab9b3ec1d9d34f6644ac28d69:Client_Secret_0ab77acbf2bde2cc40a1162f596846fa75ff710e");

            //O certificado tem que ser definido como "copy always"
            X509Certificate2 uidCert = new X509Certificate2(@".\certificado.p12");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api-pix-h.gerencianet.com.br/oauth/token");

            request.ClientCertificates.Add(uidCert);
            request.Method = "POST";
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(byteArray));
            request.Headers.Add("Content-Type", "application/json");
            request.ContentType = "application/json";
            //request. = "{\r\n    \"grant_type\": \"client_credentials\"\r\n}";


            using (var streamWriter = new System.IO.StreamWriter(request.GetRequestStream()))
            {
                //string json = "{\"user\":\"test\"," +
                //              "\"password\":\"bla\"}";

                var json = "{\r\n    \"grant_type\": \"client_credentials\"\r\n}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }
    }
}
