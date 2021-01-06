using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net.Requests.RequestModels;
using pix_dynamic_payload_generator.net.Requests.RequestServices;
using pix_dynamic_payload_generator.net_test.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net_test
{
    public class CobVTest : UnitTestBase
    {
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
    }
}
