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
        public string BaseURL => "https://api-pix-h.gerencianet.com.br";

        public string ClientId => "Client_Id_51d92e9836716a4ab9b3ec1d9d34f6644ac28d69";

        public string ClientSecret => "Client_Secret_0ab77acbf2bde2cc40a1162f596846fa75ff710e";

        public X509Certificate2 Certificate => new X509Certificate2(@".\certificado.p12");
    }
}
