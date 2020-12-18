//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace pix_dynamic_payload_generator.net.Extentions
//{
//    public static class EnumExtention
//    {
//        public static T ToEnum<T>(this string value, T defaultValue)
//        {
//            if (string.IsNullOrEmpty(value))
//            {
//                return defaultValue;
//            }

//            T result;
//            return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
//        }
//    }
//}
