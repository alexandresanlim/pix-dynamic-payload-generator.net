using System;
using System.Collections.Generic;
using System.Text;

namespace pix_dynamic_payload_generator.net.Extentions
{
    public static class DateTimeExtention
    {
        public static string ToDisplay(this DateTime dateTime)
        {
            if (dateTime == null)
                return "";

            return dateTime.ToString("dd MMM yy ddd HH:mm");
        }
    }
}
