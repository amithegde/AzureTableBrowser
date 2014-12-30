namespace AzureTableBrowser.Extensions
{
    /// <summary>
    /// All extensions for System.Object class
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns true if an object is null
        /// </summary>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
    }
}
