using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net
{
    public class Start
    {
        //https://api-pix-h.gerencianet.com.br
        public static string BaseUrl { get; private set; }

        public string CertificatePath { get; private set; }

        public string ClientId { get; private set; }

        public string ClientSecret { get; private set; }

        public Start(string _baseUrl, string _clientId, string _clientSecret, string _certificatePath)
        {
            BaseUrl = _baseUrl;
            ClientId = _clientId;
            ClientSecret = _clientSecret;
            CertificatePath = _certificatePath;
        }
    }
}
