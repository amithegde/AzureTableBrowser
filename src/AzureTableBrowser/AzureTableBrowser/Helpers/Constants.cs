namespace AzureTableBrowser.Helpers
{
    /// <summary>
    /// Constants used across the application
    /// </summary>
    public class Constants
    {
        public const string PartitionKey = "PartitionKey";
        public const string RowKey = "RowKey";
        public const string Timestamp = "Timestamp";
        public const string ETag = "ETag";
        public const char IdSeparator = '|';

        public const string DefaultTableCoreUrl = "table.core.windows.net";

        public const int DefaultTablePageSize = 200;
        public const int MaxTablePageSize = 1000; // table segmented query supports only 1000 entities at a time

        public const string HttpsScheme = "https://";
        public const string HttpScheme = "http://";

        public const string SettingsFile = "settings.json";
    }
}
