using pix_dynamic_payload_generator.net;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net_test.Base
{
    public class UnitTestBase
    {
        public UnitTestBase()
        {
            new StartConfig(
                _baseUrl: "https://api-pix.seupsp.com.br",
                _clientId: "Client_Id_",
                _clientSecret: "Client_Secret_",
                _certificate: new System.Security.Cryptography.X509Certificates.X509Certificate2(@".\certificado.p12")
                );
        }
    }
}
