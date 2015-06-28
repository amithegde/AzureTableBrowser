using AzureTableBrowser.Helpers;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;

namespace AzureTableBrowser.Extensions
{
    /// <summary>
    /// All extensions for Enumerables
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns enumerable as a hashset
        /// </summary>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }
        
        /// <summary>
        /// Returns true if an enumerable is empty
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.IsNull() || !enumerable.Any();
        }

        /// <summary>
        /// Converts an IEnumerable<dynamic> to DataTable
        /// </summary>
        public static DataTable ToDataTable(this IEnumerable<dynamic> list)
        {
            var result = new DataTable { TableName = "tableData" };

            //enumerate greedyly to avoid multiple enumerations
            var enumeratedData = list.ToList();

            if (enumeratedData.IsEmpty())
                return result;

            var dictionary = (IDictionary<string, object>)enumeratedData[0];
            if (dictionary != null)
            {
                var columnNames = dictionary.Keys.Distinct();
                result.Columns.AddRange(columnNames.Select(c => new DataColumn(c)).ToArray());
            }
            else
            {
                return result;
            }

            foreach (dynamic dataItem in enumeratedData)
            {
                var item = (IDictionary<string, object>)dataItem;

                var row = result.NewRow();
                foreach (var key in item.Keys)
                {
                    row[key] = item[key];
                }

                result.Rows.Add(row);
            }

            return result;
        }

        /// <summary>
        /// Goes through <see cref="DynamicTableEntity"/> pickes up each property and its value, converts it to an ExpandoObject
        /// </summary>
        public static List<dynamic> ToDynamicList(this IEnumerable<DynamicTableEntity> dynamicTableEntities)
        {
            var list = new List<dynamic>();

            var entityProperties = new HashSet<string>();
            //iterate over all rows to collect all properties
            foreach (var key in dynamicTableEntities.SelectMany(dynamicTableEntity => dynamicTableEntity.Properties.Keys))
            {
                entityProperties.Add(key);
            }

            foreach (var dynamicTableEntity in dynamicTableEntities)
            {
                var dynamicObject = new ExpandoObject() as IDictionary<string, Object>;
                dynamicObject.Add(Constants.PartitionKey, (dynamic)dynamicTableEntity.PartitionKey);
                dynamicObject.Add(Constants.RowKey, (dynamic)dynamicTableEntity.RowKey);
                dynamicObject.Add(Constants.ETag, (dynamic)dynamicTableEntity.ETag);
                dynamicObject.Add(Constants.Timestamp, (dynamic)dynamicTableEntity.Timestamp);

                foreach (var entityProperty in entityProperties)
                {
                    if (!dynamicTableEntity.Properties.ContainsKey(entityProperty))
                    {
                        dynamicObject.Add(entityProperty, (dynamic)string.Empty);
                        continue;
                    }

                    var item = dynamicTableEntity.Properties[entityProperty];
                    switch (item.PropertyType)
                    {
                        case EdmType.Binary:
                            dynamicObject.Add(entityProperty, (dynamic)item.BinaryValue);
                            break;
                        case EdmType.Boolean:
                            dynamicObject.Add(entityProperty, (dynamic)item.BooleanValue);
                            break;
                        case EdmType.DateTime:
                            dynamicObject.Add(entityProperty, (dynamic)item.DateTimeOffsetValue);
                            break;
                        case EdmType.Double:
                            dynamicObject.Add(entityProperty, (dynamic)item.DoubleValue);
                            break;
                        case EdmType.Guid:
                            dynamicObject.Add(entityProperty, (dynamic)item.GuidValue);
                            break;
                        case EdmType.Int32:
                            dynamicObject.Add(entityProperty, (dynamic)item.Int32Value);
                            break;
                        case EdmType.Int64:
                            dynamicObject.Add(entityProperty, (dynamic)item.Int64Value);
                            break;
                        case EdmType.String:
                            dynamicObject.Add(entityProperty, (dynamic)item.StringValue);
                            break;
                    }
                }
                list.Add(dynamicObject);
            }
			
            return list;
        }
    }
}