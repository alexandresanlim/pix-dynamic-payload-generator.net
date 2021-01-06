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
                _baseUrl: "https://api-pix.gerencianet.com.br",
                _clientId: "Client_Id_505c65a6e2cd5e048d583b80f8da2356a7230275",
                _clientSecret: "Client_Secret_4bd8c21a1107a627c2db3a7dcf1c4180ce1a040a",
                _certificate: new System.Security.Cryptography.X509Certificates.X509Certificate2(@".\certificado.p12")
                );
        }
    }
}
