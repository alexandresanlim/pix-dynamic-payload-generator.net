using pix_dynamic_payload_generator.net;
using pix_dynamic_payload_generator.net.Models.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace pix_dynamic_payload_generator.net_test.Base
{
    public class UnitTestBase
    {
        public UnitTestBase()
        {
            var config = new StartConfigValues();

            new StartConfig(
                _baseUrl: config.BaseURL,
                _clientId: config.ClientId,
                _clientSecret: config.ClientSecret,
                _certificate: config.Certificate
                );
        }
    }

    public class StartConfigValues : IStartConfig
    {
        /// <summary>
        /// Emxemplo: Gerencianet PRD: https://api-pix.gerencianet.com.br HML:https://api-pix-h.gerencianet.com.br  
        /// </summary>
        public string BaseURL => "https://api-pix-h.psp.com.br";

        /// <summary>
        /// ClientId fornecido pelo PSP
        /// </summary>
        public string ClientId => "{CLIENT ID AQUI}";

        /// <summary>
        /// ClientSecret fornecido pelo PSP
        /// </summary>
        public string ClientSecret => "{CLIENT SECRET AQUI}";

        /// <summary>
        /// Caminho para o certificado fornecido pelo PSP
        /// </summary>
        public X509Certificate2 Certificate => new X509Certificate2(@".\certificado.p12");

        public string AuthEndpoint => "/oauth/token";

        public bool UseUrlFormEncodedForAuth => false;

        public string AuthScopes => "";

        public bool UseEndpointArea => false;
    }
}
