using pix_dynamic_payload_generator.net.Models.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace pix_dynamic_payload_generator.net
{
    public class StartConfig
    {
        /// <summary>
        /// Url da api pix do PSP, exemplo: https://api-pix-h.gerencianet.com.br
        /// </summary>
        public static string BaseUrl { get; private set; }

        /// <summary>
        /// ClientId do oauth 2 do PSP
        /// </summary>
        public static string ClientId { get; private set; }

        /// <summary>
        /// ClientSecret do oauth 2 do PSP
        /// </summary>
        public static string ClientSecret { get; private set; }

        public static X509Certificate2 Certificate { get; private set; }

        public static string AuthEndpoint { get; private set; }

        public static bool UseUrlFormEncodedForAuth { get; private set; }

        public static string AuthScopes { get; private set; }

        public static bool UseEndpointArea { get; private set; }

        public StartConfig(
            string _baseUrl,
            string _clientId,
            string _clientSecret,
            X509Certificate2 _certificate,
            string _authEnpoint = "/oauth/token",
            bool _useUrlFormEncodedForAuth = false,
            string _authScopes = "",
            bool _useEndpointArea = false)
        {
            BaseUrl = _baseUrl;
            ClientId = _clientId;
            ClientSecret = _clientSecret;
            Certificate = _certificate;
            AuthEndpoint = _authEnpoint;
            UseEndpointArea = _useEndpointArea;
            UseUrlFormEncodedForAuth = _useUrlFormEncodedForAuth;
            AuthScopes = _authScopes;
        }

        public StartConfig(IStartConfig _startConfig)
        {
            BaseUrl = _startConfig.BaseURL;
            ClientId = _startConfig.ClientId;
            ClientSecret = _startConfig.ClientSecret;
            Certificate = _startConfig.Certificate;
            AuthEndpoint = _startConfig.AuthEndpoint;
            UseEndpointArea = _startConfig.UseEndpointArea;
            UseUrlFormEncodedForAuth = _startConfig.UseUrlFormEncodedForAuth;
            AuthScopes = _startConfig.AuthScopes;
        }
    }
}
