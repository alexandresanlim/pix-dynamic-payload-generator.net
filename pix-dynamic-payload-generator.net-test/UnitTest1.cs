using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net;
using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests;
using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_dynamic_payload_generator.net.Requests.RequestServices;
using pix_payload_generator.net;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net_test
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            new StartConfig(
                _baseUrl: "https://api-pix-h.seupsp.com.br",
                _clientId: "client-id-fornecido-pelo-psp",
                _clientSecret: "client-secret-fornecido-pelo-psp",
               _certificate: new System.Security.Cryptography.X509Certificates.X509Certificate2(@".\certificado.p12")
                );
        }

        #region OAuth

        [TestMethod]
        public void OAuthGetCertificate()
        {
            var certificate = StartConfig.Certificate;
        }

        [TestMethod]
        public void OAuthGenerateToken()
        {
            var token = StartConfig.GetToken();
            Assert.IsFalse(string.IsNullOrEmpty(token?.AccessToken));
        }

        #endregion

        #region WebHook

        [TestMethod]
        public async Task WebhookCreate()
        {
            var request = new WebHookRequestService();
            var webHookRequest = new WebHookRequest
            {
                 WebhookUrl = "https://pix.example.com/api/webhook/"
            };
            var success = await request.Create("key", webHookRequest);
        }

        [TestMethod]
        public async Task WebhookGetByKey()
        {
            var request = new WebHookRequestService();
            var wh = await request.GetByKey("key");
        }

        #endregion

        #region Cob

        [TestMethod]
        public async Task CobCreate()
        {
            var cob = new CobRequest(_chave: "1b0e2743-0769-4f21-b0b7-9cfddb2a5a2b")
            {
                Calendario = new Calendario
                {
                    Expiracao = 3600
                },
                Devedor = new Devedor
                {
                    Cpf = "12345678909",
                    Nome = "Francisco da Silva",
                },
                Valor = new Valor
                {
                    Original = "1.00"
                },
                SolicitacaoPagador = "Serviço realizado.",
                InfoAdicionais = new System.Collections.Generic.List<InfoAdicional>
                {
                    new InfoAdicional
                    {
                        Nome = "Campo 1",
                        Valor = "Informação Adicional1 do PSP-Recebedor"
                    },
                    new InfoAdicional
                    {
                        Nome = "Campo 2",
                        Valor = "Informação Adicional2 do PSP-Recebedor"
                    }
                }
            };

            var cobRequest = new CobRequestService();

            var cb = await cobRequest.Create(System.Guid.NewGuid().ToString("N"), cob);

            Assert.IsFalse(string.IsNullOrEmpty(cb?.Txid));
        }

        [TestMethod]
        public async Task CobGetByTxId()
        {
            var cobRequest = new CobRequestService();
            var cb = await cobRequest.GetByTxId("2883c7672f794369a293bfb3d2ec6c69");

            Assert.IsFalse(string.IsNullOrEmpty(cb?.Txid));
        }

        #endregion

        #region CobV

        [TestMethod]
        public async Task CobVCreate()
        {
            var cob = new CobVRequest
            {
                Chave = "1b0e2743-0769-4f21-b0b7-9cfddb2a5a2b",
                Calendario = new CalendarioCobV
                {
                    DataDeVencimento = "2020-12-31",
                    ValidadeAposVencimento = 30
                },
                Loc = new LocCobV
                {
                    Id = 789
                },
                Devedor = new DevedorCobV
                {
                    Logradouro = "Alameda Souza, Numero 80, Bairro Braz",
                    Cidade = "Recife",
                    Uf = "PE",
                    Cep = "70011750",
                    Cpf = "12345678909",
                    Nome = "Francisco da Silva"
                },
                ValorCobV = new ValorCobV
                {
                    Original = "123.45",
                    Multa = new Multa
                    {
                        Modalidade = "2",
                        ValorPerc = "15.00"
                    },
                    Juros = new Juros
                    {
                        Modalidade = "2",
                        ValorPerc = "2.00"
                    },
                    Desconto = new Desconto
                    {
                        Modalidade = "1",
                        DescontoDataFixa = new System.Collections.Generic.List<DescontoDataFixa>
                        {
                            new DescontoDataFixa{ Data = "2020-11-30",ValorPerc = "30.00"}
                        }
                    }
                },
                SolicitacaoPagador = "Cobrança dos serviços prestados."
            };

            var cobRequest = new CobVRequestService();

            var cb = await cobRequest.Create(System.Guid.NewGuid().ToString("N"), cob);

            Assert.IsFalse(string.IsNullOrEmpty(cb?.Txid));
        }

        #endregion

        #region Pix

        [TestMethod]
        public async Task CobGetByE2eid()
        {
            var request = new PixRequestService();
            var cb = await request.GetByE2eid("e2eid");
        }

        #endregion

        #region QrCodes

        [TestMethod]
        public async Task QrCodeGetDynamic()
        {
            var cobRequest = new CobRequestService();

            var cob = await cobRequest.GetByTxId("496b0fd872ba49a0ad5b55572debdabf");

            var payload = cob.ToPayload(new Merchant("Alexandre Lima", "Presidente Prudente"));

            var stringToQrCode = payload.GenerateStringToQrCode();

            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }

        [TestMethod]
        public void QrCodeGetStatic()
        {
            var cobranca = new Cobranca(_chave: "bee05743-4291-4f3c-9259-595df1307ba1");

            var payload = cobranca.ToPayload("O-TxtId-Aqui", new Merchant("Alexandre Sanlim", "Presidente Prudente"));

            var stringToQrCode = payload.GenerateStringToQrCode();

            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }

        #endregion
    }
}
