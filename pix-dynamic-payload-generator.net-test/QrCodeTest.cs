using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net.Requests.RequestServices;
using pix_dynamic_payload_generator.net_test.Base;
using pix_payload_generator.net.Models.CobrancaModels;
using pix_payload_generator.net.Models.PayloadModels;
using pix_dynamic_payload_generator.net.Models;
using pix_payload_generator.net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net_test
{
    [TestClass]
    public class QrCodeTest : UnitTestBase
    {
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
