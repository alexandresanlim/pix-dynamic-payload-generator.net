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
    [TestClass]
    public class WebhookTest : UnitTestBase
    {
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
    }
}
