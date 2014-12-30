using System;

namespace AzureTableBrowser.Extensions
{
    /// <summary>
    /// All extensions for string
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Alternative for string.IsNullOrWhiteSpace()
        /// </summary>
        public static bool IsEmptyOrWiteSpace(this string stringValue)
        {
            return string.IsNullOrWhiteSpace(stringValue);
        }
        
        /// <summary>
        /// Better alternative for string.Format()
        /// Usage: "Hellow {0}".ToFormat(userName.ToString());
        /// </summary>
        public static string ToFormat(this string stringFormat, params object[] args)
        {
            return String.Format(stringFormat, args);
        }

        
    }
}
