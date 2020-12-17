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
                _baseUrl: "https://api-pix-h.gerencianet.com.br",
                _clientId: "Client_Id_51d92e9836716a4ab9b3ec1d9d34f6644ac28d69",
                _clientSecret: "Client_Secret_0ab77acbf2bde2cc40a1162f596846fa75ff710e",
                _certificatePath: @".\certificado.p12"
                );
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
                    Original = "37.00"
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
            var cob = await cobRequest.GetByTxId("ea1b4dc6e8ee4508840cfa80873b4460");

            var l = cob.Location;
            var value = Convert.ToDecimal(cob.Valor.Original, new CultureInfo("en-US"));

            var payload = new DynamicPayload(
                cob.Txid,
                new Merchant("Alexandre Lima", "Presidente Prudente"),
                cob.Location,
                true, value);

            var stringToQrCode = payload.GenerateStringToQrCode();
        }

        [TestMethod]
        public void GetStaticQrCode()
        {
            var payload = new StaticPayload(
                "bee05743-4291-4f3c-9259-595df1307ba1",
                "Um-Id-Qualquer",
                new Merchant("Alexandre Lima", "Presidente Prudente"));

            var stringToQrCode = payload.GenerateStringToQrCode();
        }


    }
}
