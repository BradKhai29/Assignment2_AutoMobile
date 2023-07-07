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
            value = value.Trim().ToLower();
            var tokens = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                if(i == 0)
                {
                    stringBuilder.Append(token.Substring(0, 1).ToUpper());
                    stringBuilder.Append(token.Substring(1)).Append(' ');
                }
                else stringBuilder.Append(token.ToLower()).Append(' ');
            }

            return stringBuilder.ToString().TrimEnd();
        }

        public static string ToCapitalCase(this string value)
        {
            var stringBuilder = new StringBuilder();
            value = value.Trim().ToLower();
            var tokens = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                stringBuilder.Append(token.Substring(0, 1).ToUpper());
                if (i != tokens.Length - 1) stringBuilder.Append(token.Substring(1)).Append(' ');
                else stringBuilder.Append(token.Substring(1));
            }

            return stringBuilder.ToString();
        }
    }
}
