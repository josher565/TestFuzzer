using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeAffinity.TestFuzzer
{
    public static class Extensions
    {

        public static string Truncate(this string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string DbEscape(this string value)
        {
            //http://docs.oracle.com/cd/B10500_01/text.920/a96518/cqspcl.htm
            StringBuilder sb = new StringBuilder();
            foreach (char c in value.ToCharArray())
                switch (c)
                {
                    case ',':
                        sb.Append(@"\,");
                        break;
                    case '&':
                        sb.Append(@"\&");
                        break;
                    case '?':
                        sb.Append(@"\?");
                        break;
                    case '{':
                        sb.Append(@"{{");
                        break;
                    case '}':
                        sb.Append(@"}}");
                        break;
                    case '\\':
                        sb.Append(@"\\");
                        break;
                    case '(':
                        sb.Append(@"\(");
                        break;
                    case ')':
                        sb.Append(@"\)");
                        break;
                    case '[':
                        sb.Append(@"\[");
                        break;
                    case ']':
                        sb.Append(@"\]");
                        break;
                    case '-':
                        sb.Append(@"\-");
                        break;
                    case ';':
                        sb.Append(@"\;");
                        break;
                    case '~':
                        sb.Append(@"\~");
                        break;
                    case '|':
                        sb.Append(@"\|");
                        break;
                    case '$':
                        sb.Append(@"\$");
                        break;
                    case '!':
                        sb.Append(@"\!");
                        break;
                    case '>':
                        sb.Append(@"\>");
                        break;
                    case '*':
                        sb.Append(@"\*");
                        break;
                    case '%':
                        sb.Append(@"\%");
                        break;
                    case '_':
                        sb.Append(@"\_");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }

            return sb.ToString();
        }
    }
}
