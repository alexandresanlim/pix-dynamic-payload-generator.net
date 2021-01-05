using Newtonsoft.Json;
using pix_dynamic_payload_generator.net.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        /// Caminho absoluto do certificado marcado como copy-always
        /// </summary>
        //public static string CertificatePath { get; private set; }

        /// <summary>
        /// ClientId do oauth 2 do PSP
        /// </summary>
        public static string ClientId { get; private set; }

        /// <summary>
        /// ClientSecret do oauth 2 do PSP
        /// </summary>
        public static string ClientSecret { get; private set; }

        public static X509Certificate2 Certificate { get; private set; }

        public StartConfig(string _baseUrl, string _clientId, string _clientSecret, X509Certificate2 _certificate)
        {
            BaseUrl = _baseUrl;
            ClientId = _clientId;
            ClientSecret = _clientSecret;
            Certificate = _certificate;
        }
    }
}
