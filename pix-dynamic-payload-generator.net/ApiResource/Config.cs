using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.ApiResource
{
    public class Config
    {
        public static string BaseUrl { get; set; }

        public Config(string _baseUrl)
        {
            BaseUrl = _baseUrl;
        }
    }
}
