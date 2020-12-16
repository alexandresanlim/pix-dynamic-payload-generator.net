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

                request.Abort();

                return JsonConvert.DeserializeObject<Responses.TokenResponse>(result);
                //return result;
            }

            
        }

        ///// <summary>
        ///// Criar uma cobrança imediata
        ///// </summary>
        ///// <param name="txId"></param>
        ///// <param name="cob"></param>
        //public void CreateCob(string txId)
        //{
        //    try
        //    {
        //        var token = GetToken();

        //        //var byteArray = new UTF8Encoding().GetBytes(ClientId + ":" + ClientSecret);

        //        var byteArray = new UTF8Encoding().GetBytes(token.AccessToken);

        //        //X509Certificate2 uidCert = new X509Certificate2(Certificate);

        //        //ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
        //        //ServicePointManager.SecurityProtocol |= (SecurityProtocolType)3072;
        //        //System.Net.ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors) => { return true; });
        //        //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        //        //System.Net.ServicePointManager.Expect100Continue = false;

        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api-pix-h.gerencianet.com.br/v2/cob/" + txId);
        //        request.Method = "PUT";
        //        request.Headers.Add("Authorization", "Bearer " + token.AccessToken);
        //          //request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(byteArray));
        //        request.Headers.Add("Content-Type", "application/json");
        //        request.ContentType = "application/json";
        //        //request.KeepAlive = false;
        //        //request.ProtocolVersion = HttpVersion.Version10;
        //        //request.ServicePoint.ConnectionLimit = 1;

        //        //var handler = new HttpClientHandler();
        //        //handler.ServerCertificateCustomValidationCallback = delegate { return true; };

        //        //request.ha


        //        //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

        //        using (var streamWriter = new System.IO.StreamWriter(request.GetRequestStream()))
        //        {
        //            var json = "{\r\n  \"calendario\": {\r\n    \"expiracao\": 3600\r\n  },\r\n  \"devedor\": {\r\n    \"cpf\": \"12345678909\",\r\n    \"nome\": \"Francisco da Silva\"\r\n  },\r\n  \"valor\": {\r\n    \"original\": \"124.45\"\r\n  },\r\n  \"chave\": \"\",\r\n  \"solicitacaoPagador\": \"Cobrança dos serviços prestados.\"\r\n}";
        //            streamWriter.Write(json);
        //        }

        //        //System.Net.ServicePointManager.Expect100Continue = false;
        //        var httpResponse = (HttpWebResponse)request.GetResponse();

        //        using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
        //        {
        //            var result = streamReader.ReadToEnd();

        //            //return JsonConvert.DeserializeObject<Responses.TokenResponse>(result);
        //            //return result;
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw;
        //    }
        //}
    }
}
