using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace pix_dynamic_payload_generator.net
{
    public class StartConfig
    {
        /// <summary>
        /// Url da api pix do PSP, exemplo: https://api-pix-h.gerencianet.com.br
        /// </summary>
        public static string BaseUrl { get; private set; }

        /// <summary>
        /// Caminho absoluto do certificado
        /// </summary>
        public static string CertificatePath { get; private set; }

        /// <summary>
        /// ClientId do oauth 2 do PSP
        /// </summary>
        public static string ClientId { get; private set; }

        /// <summary>
        /// ClientSecret do oauth 2 do PSP
        /// </summary>
        public static string ClientSecret { get; private set; }

        public static X509Certificate2 Certificate => new X509Certificate2(CertificatePath);

        private static Responses.TokenResponse LastToken { get; set; }

        public StartConfig(string _baseUrl, string _clientId, string _clientSecret, string _certificatePath)
        {
            BaseUrl = _baseUrl;
            ClientId = _clientId;
            ClientSecret = _clientSecret;
            CertificatePath = _certificatePath;
        }

        //public static void Start(string _baseUrl, string _clientId, string _clientSecret, string _certificatePath)
        //{
        //    BaseUrl = _baseUrl;
        //    ClientId = _clientId;
        //    ClientSecret = _clientSecret;
        //    CertificatePath = _certificatePath;
        //}

        public static Responses.TokenResponse GetToken()
        {
            if (LastToken != null)
                return LastToken;

            var byteArray = new UTF8Encoding().GetBytes(ClientId + ":" + ClientSecret);

            //O certificado tem que ser definido como "copy always"
            X509Certificate2 uidCert = new X509Certificate2(Certificate);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUrl + "/oauth/token");

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
                LastToken = JsonConvert.DeserializeObject<Responses.TokenResponse>(result);
            }

            return LastToken;
        }
    }
}
