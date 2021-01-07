using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Extentions
{
    public static class StringExtention
    {
        public static decimal ToDecimalUSCulture(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return decimal.Zero;

            return Convert.ToDecimal(value, new System.Globalization.CultureInfo("en-US"));
        }
    }
}
