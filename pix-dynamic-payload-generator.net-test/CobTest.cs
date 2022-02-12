using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_dynamic_payload_generator.net.Requests.RequestServices;
using pix_dynamic_payload_generator.net_test.Base;
using pix_payload_generator.net.Models.Attributes;
using pix_payload_generator.net.Models.CobrancaModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net_test
{
    [TestClass]
    public class CobTest : UnitTestBase
    {
        [TestMethod]
        public async Task CobCreate()
        {
            var cob = new CobRequest(_chave: "1b0e2743-0769-4f21-b0b7-9cfddb2a5a2b")
            {
                Calendario = new CalendarioRequest
                {
                    Expiracao = 3600
                },
                Devedor = new DevedorRequest
                {
                    Cpf = "12345678909",
                    Nome = "Francisco da Silva",
                },
                Valor = new ValorRequest
                {
                    Original = "1.00"
                },
                SolicitacaoPagador = "Serviço realizado.",
                InfoAdicionais = new List<InfoAdicional>
                {
                    new InfoAdicionalRequest
                    {
                        Nome = "Campo 1",
                        Valor = "Informação Adicional1 do PSP-Recebedor"
                    },
                    new InfoAdicionalRequest
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
            var cb = await cobRequest.GetByTxId("39088ca5f6a94069b541d1b7347a918a");

            Assert.IsFalse(string.IsNullOrEmpty(cb?.Txid));
        }

        [TestMethod]
        public async Task CobGetByPeriod()
        {
            var cobRequest = new CobRequestService();
            var cb = await cobRequest.GetByPeriod(DateTime.Today);

            Assert.IsTrue(cb.Parametros.Paginacao != null);
        }
    }
}
