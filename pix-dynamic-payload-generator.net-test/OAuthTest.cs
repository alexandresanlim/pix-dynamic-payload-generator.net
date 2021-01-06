using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net;
using pix_dynamic_payload_generator.net.Requests.RequestServices;
using pix_dynamic_payload_generator.net_test.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net_test
{
    [TestClass]
    public class OAuthTest : UnitTestBase
    {
        #region OAuth

        [TestMethod]
        public void OAuthGetCertificate()
        {
            var certificate = StartConfig.Certificate;
        }

        [TestMethod]
        public void OAuthGenerateToken()
        {
            var token = TokenService.Create();
            Assert.IsFalse(string.IsNullOrEmpty(token?.AccessToken));
        }

        #endregion
    }
}
