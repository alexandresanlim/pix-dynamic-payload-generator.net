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
                _baseUrl: "https://api-pix.gerencianet.com.br",
                _clientId: "Client_Id_505c65a6e2cd5e048d583b80f8da2356a7230275",
                _clientSecret: "Client_Secret_4bd8c21a1107a627c2db3a7dcf1c4180ce1a040a",
               // _certificatePath: @"caminho-absoluto-fornecido-pelo-psp-ex:-.\certificado.p12-lembre-se-de-marcar-como-copy-always"
               _certificatePath: @".\certificado.p12"
                );
        }

        [TestMethod]
        public void GenerateCertificate()
        {
            var a = AppDomain.CurrentDomain.BaseDirectory;
            var certificate = StartConfig.Certificate;
        }

        [TestMethod]
        public void GenerateToken()
        {
            var authorize = StartConfig.GetToken();
        }

        [TestMethod]
        public async Task GenerateCob()
        {
            var cob = new CobrancaRequest(_chave: "1b0e2743-0769-4f21-b0b7-9cfddb2a5a2b")
            {
                Calendario = new Calendario
                {
                    Expiracao = 3600
                },
                Devedor = new Devedor
                {
                    Cnpj = "12345678000195",
                    Nome = "Empresa de Serviços SA",
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
        }

        [TestMethod]
        public async Task GetCobByTxId()
        {
            var cobRequest = new CobRequestService();
            var cb = await cobRequest.GetByTxId("2883c7672f794369a293bfb3d2ec6c69");
        }

        [TestMethod]
        public async Task GetDynamicQrCode()
        {
            var cobRequest = new CobRequestService();

            var cob = await cobRequest.GetByTxId("496b0fd872ba49a0ad5b55572debdabf");

            var payload = cob.ToPayload(new Merchant("Alexandre Lima", "Presidente Prudente"));

            var stringToQrCode = payload.GenerateStringToQrCode();

            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }

        [TestMethod]
        public void GetStaticQrCode()
        {
            var cobranca = new Cobranca(_chave: "bee05743-4291-4f3c-9259-595df1307ba1");

            var payload = cobranca.ToPayload("O-TxtId-Aqui", new Merchant("Alexandre Sanlim", "Presidente Prudente"));

            var stringToQrCode = payload.GenerateStringToQrCode();

            Assert.IsFalse(string.IsNullOrEmpty(stringToQrCode));
        }


    }
}
