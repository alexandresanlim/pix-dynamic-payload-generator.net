using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net;

namespace pix_dynamic_payload_generator.net_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Generate()
        {
            var a = Authorize.ge();
        }
    }
}
