using AzureTableBrowser.Extensions;
using AzureTableBrowser.Helpers;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;

namespace AzureTableBrowser.DAL
{
    /// <summary>
    /// Wrapper class on top of Azure Storage Library to simplify communication with Storage
    /// </summary>
    public class AzureDataProvider
    {

        #region Private Fields

        private readonly StorageCredentials storageCredentials;

        private readonly string tableEndpoint;

        #endregion

        #region Public Properties
        public bool IsUserHttps { get; set; }

        public CloudTableClient TableClient
        {
            get
            {
                return IsUseDeveloperAccount
                    ? CloudStorageAccount.DevelopmentStorageAccount.CreateCloudTableClient()
                    : new CloudTableClient(new Uri(tableEndpoint), storageCredentials);
            }
        }

        #endregion

        private bool IsUseDeveloperAccount { get; set; }

        #region Private Methods

        private string GetScheme()
        {
            return IsUserHttps ? Constants.HttpsScheme : Constants.HttpScheme;
        }

        #endregion

        #region Constructors

        public AzureDataProvider(bool isDeveloperAccount)
        {
            if (isDeveloperAccount)
            {
                IsUseDeveloperAccount = true;
            }
        }
        
        public AzureDataProvider(string account, string key, bool isUseHttps)
        {

            storageCredentials = new StorageCredentials(account, key);
            IsUserHttps = isUseHttps;

            tableEndpoint = "{0}{1}.{2}/".ToFormat(GetScheme(), account, Constants.DefaultTableCoreUrl);
        }

        public AzureDataProvider(string connectionString)
        {
            try
            {
                var cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
                storageCredentials = cloudStorageAccount.Credentials;
                tableEndpoint = cloudStorageAccount.TableEndpoint.ToString();
            }
            catch (Exception ex)
            {
                //TODO: log  exception
                throw;
            }
        }

        #endregion

        #region Table Methods

        /// <summary>
        /// Gets list of CloudTable on the account
        /// </summary>
        /// <param name="tablePrefix">table prefix to filter tables</param>
        /// <returns>List of tables</returns>
        public IList<CloudTable> GetTables(string tablePrefix = "")
        {
            List<CloudTable> tables = null;
            TableContinuationToken continuationToken = null;
            try
            {
                do
                {
                    var azureTables = TableClient.ListTablesSegmented(continuationToken);
                    continuationToken = azureTables.ContinuationToken;

                    if (tables.IsNull())
                    {
                        tables = new List<CloudTable>();
                    }

                    tables.AddRange(azureTables.Results);

                } while (!continuationToken.IsNull());
            }
            catch (Exception ex)
            {
                //TODO: Log exception
                throw;
            }

            return tables;
        }

        /// <summary>
        /// Returns table entities
        /// </summary>
        public List<dynamic> GetEntities(string tableName, int takeCount, string filters)
        {

            var table = TableClient.GetTableReference(tableName);

            var tableQuery = !filters.IsEmpty()
                                 ? new TableQuery<DynamicTableEntity>().Where(filters).Take(takeCount)
                                 : new TableQuery<DynamicTableEntity>().Take(takeCount);

            var tableResult = table.ExecuteQuery(tableQuery);

            List<dynamic> dynamicCollection = tableResult.ToDynamicList();

            return dynamicCollection;
        }

        #endregion
    }
}
