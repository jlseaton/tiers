using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiers.Core
{
    static class Extensions
    {
        /// <summary>
        /// Returns all of the messages from an exception's inner exceptions
        /// </summary>
        /// <param name="ex">The exception to be parsed</param>
        /// <returns>Returns all of the inner exception messages without as much extra stuff</returns>
        public static string GetInnerMessages(this Exception ex)
        {
            string message = string.Empty;
            Exception innerException = ex;

            do
            {
                message = message + 
                    (string.IsNullOrEmpty(innerException.Message) ? 
                    string.Empty : innerException.Message);
                innerException = innerException.InnerException;
            }
            while (innerException != null);

            return message;
        }

        /// <summary>
        /// Strips away non alphanumeric characters, excluding spaces, @, ., _, and /
        /// </summary>
        /// <param name="text">The string to be stripped</param>
        /// <returns>The stripped string</returns>
        public static string RemoveSpecialCharacters(this string text)
        {
            if (!Constants.StripSpecialCharacters)
            {
                return text;
            }

            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') ||
                    (c >= 'a' && c <= 'z') || c == '.' || c == '_'
                    || c == '@' || c == '/' || c == ' ')
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    };
}
