using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NCES_CP
{
    internal class Helper
    {
        public static string GetExtensionsInfo(dynamic extensions, X509Certificate2 certificate)
        {
            var extensionInfo = new List<string>();
            foreach (X509Extension extension in extensions)
            {
                if (extension == certificate.Extensions["2.5.29.17"] || extension == certificate.Extensions["2.5.29.14"] || extension == certificate.Extensions["2.5.29.35"])
                {
                    string friendlyName = extension.Oid.FriendlyName;
                    string value = extension.Format(true);

                    if (extension == certificate.Extensions["2.5.29.17"])
                    {
                        value = UpdateHexValues(value);
                    }

                    extensionInfo.Add($"{friendlyName}: {value}");
                }
            }

            return extensionInfo.Count > 0
                ? string.Join(", ", extensionInfo)
                : "None";
        }
        public static string UpdateHexValues(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"(?:(?:\s*([0-9A-Fa-f]{2,}))+\s*)*(?:\s*([0-9A-Fa-f]{2,})\s*)?");
            StringBuilder sb = new StringBuilder();

            int currentIndex = 0;
            foreach (Match match in matches)
            {
                if (match.Value.Length > 0)
                {
                    string[] hexValues = match.Value.Split(' ');
                    byte[] bytes = new byte[hexValues.Length];
                    for (int i = 0; i < hexValues.Length; i++)
                    {
                        bytes[i] = byte.Parse(hexValues[i], System.Globalization.NumberStyles.HexNumber);
                    }
                    string normalString = Encoding.UTF8.GetString(bytes).Substring(2) + " ";
                    sb.Append(input.Substring(currentIndex, match.Index - currentIndex));
                    sb.Append(normalString);
                    currentIndex = match.Index + match.Length;
                }
            }

            sb.Append(input.Substring(currentIndex));
            return sb.ToString();
        }
    }
}
