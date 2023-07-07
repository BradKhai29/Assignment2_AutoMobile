using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyStoreWinApp.Utility
{
    public static class MyStringExtension
    {
        public static string ToNormalCase(this string value)
        {
            if (value == null) return "";
            var stringBuilder = new StringBuilder();
            value = Regex.Replace(value, "\\s+", " ").ToLower();
            stringBuilder.Append(value.Substring(0, 1).ToUpper());
            stringBuilder.Append(value.Substring(1));

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ToCapitalCase(this string value)
        {
            var stringBuilder = new StringBuilder();
            value = Regex.Replace(value, "\\s+", " ").ToLower();
            var tokens = value.Split(" ");
            foreach( var token in tokens )
            {
                stringBuilder.Append(token.Substring(0, 1).ToUpper());
                stringBuilder.Append(token.Substring(1)).Append(" ");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
