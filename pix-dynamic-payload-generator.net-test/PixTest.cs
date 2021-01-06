using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net.Requests.RequestServices;
using pix_dynamic_payload_generator.net_test.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net_test
{
    [TestClass]
    public class PixTest : UnitTestBase
    {
        #region Pix

        [TestMethod]
        public async Task PixGetByE2eid()
        {
            var request = new PixRequestService();
            var model = await request.GetByE2eid("E18236120202101061541s0003665A3X");

            Assert.IsFalse(string.IsNullOrEmpty(model?.Txid));
        }

        [TestMethod]
        public async Task PixGetByPeriod()
        {
            var request = new PixRequestService();
            var cb = await request.GetByPeriod(DateTime.Today);

            Assert.IsTrue(cb.Parametros.Paginacao != null);
        }

        #endregion
    }
}
