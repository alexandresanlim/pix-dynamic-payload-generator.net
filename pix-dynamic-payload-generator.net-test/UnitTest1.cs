using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net;

namespace pix_dynamic_payload_generator.net_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Generate()
        {
            var authorize = new Authorize(
                _baseUrl: "https://api-pix-h.gerencianet.com.br/oauth/token",
                _clientId: "Client_Id_51d92e9836716a4ab9b3ec1d9d34f6644ac28d69",
                _clientSecret: "Client_Secret_0ab77acbf2bde2cc40a1162f596846fa75ff710e",
                _certificate: @".\certificado.p12"
                );

            var t = authorize.GetToken();
        }
    }
}
