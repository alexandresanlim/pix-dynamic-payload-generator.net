using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net
{
    public class Api
    {
        public Api(string _baseUrl, string _clientId, string _clientSecret, string _certificate)
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

    }
}
