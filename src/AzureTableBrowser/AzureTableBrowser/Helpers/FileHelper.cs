using System.IO;

namespace AzureTableBrowser.Helpers
{
    /// <summary>
    /// Helper class for reading/writing files
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// Reads string from file and returns the result
        /// </summary>
        internal static string GetStringFromFile(string path)
        {
            var fileString = string.Empty;
            if (File.Exists(path))
            {
                fileString = File.ReadAllText(path);
            }
            return fileString;
        }
    }
}
