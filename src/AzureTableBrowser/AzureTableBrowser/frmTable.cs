using AzureTableBrowser.DAL;
using AzureTableBrowser.Extensions;
using AzureTableBrowser.Helpers;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureTableBrowser
{
    public partial class frmTable : Form
    {
        public frmTable()
        {
            InitializeComponent();

            QueryData = new List<dynamic>();

            IsDeveloperAccount = true;
        }

        #region Constants

        private string serverQueryEventHandlerKey = "ServerQuery";
        private string linqQueryEventHandlerKey = "LinqQuery";

        #endregion

        #region Properties

        private bool IsDeveloperAccount { get; set; }

        private AzureDataProvider DataProvider { get; set; }

        private List<dynamic> QueryData { get; set; }

        private Dictionary<string, KeyEventHandler> KeyEventHandlers { get; set; }

        #endregion

        #region Private Mehtods

        private void LoadAccount(bool isDeveloperAccount)
        {
            SetApplicationStatus(isReady: false);

            var tables = GetTables(isDeveloperAccount);
            if (!tables.IsEmpty())
            {
                cmbTables.SafeInvoke(d => d.DataSource = tables.Select(table => table.Name).ToList());
            }

            SetApplicationStatus(isReady: true);
        }

        private void LoadAccount(string account, string key, bool isUseHttps)
        {
            SetApplicationStatus(isReady: false);

            var tables = GetTables(account, key, isUseHttps);
            if (!tables.IsEmpty())
            {
                cmbTables.SafeInvoke(d => d.DataSource = tables.Select(table => table.Name).ToList());
            }

            SetApplicationStatus(isReady: true);
        }
        private void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void ResetRowsCount()
        {
            txtCount.Text = "200";
        }

        private void SetDataProvider(string account, string key, bool isUsehttps)
        {
            try
            {
                DataProvider = new AzureDataProvider(account, key, isUseHttps: true);
            }
            catch (Exception ex)
            {
                //TODO: log this exception
                MessageBox.Show(ex.Message);
            }
        }

        private void SetDataProvider(bool isDeveloperAccount)
        {
            try
            {
                DataProvider = new AzureDataProvider(isDeveloperAccount);
            }
            catch (Exception ex)
            {
                //TODO: log this exception
                MessageBox.Show(ex.Message);
            }
        }

        private IList<CloudTable> GetTables(string account, string key, bool isUseHttps)
        {
            SetDataProvider(account, key, isUseHttps);

            IList<CloudTable> tables = null;
            if (!DataProvider.IsNull())
            {
                //load all tables on the account
                tables = DataProvider.GetTables();
            }

            return tables;
        }

        private IList<CloudTable> GetTables(bool isDeveloperAccount)
        {
            SetDataProvider(isDeveloperAccount);

            IList<CloudTable> tables = null;
            if (!DataProvider.IsNull())
            {
                //load all tables on the account
                tables = DataProvider.GetTables();
            }

            return tables;
        }

        private void SetDataGridSize()
        {
            dataGrid.SafeInvoke(d => d.Width = this.Width - 22);
            dataGrid.SafeInvoke(d => d.Height = this.Height - 245);

        }

        private void SetApplicationStatus(bool isReady)
        {
            if (isReady)
            {
                toolStripStatus.Text = "[Ready]";
            }
            else
            {
                toolStripStatus.Text = "[Working]";
            }

            //negate isReady
            pictureProgress.SafeInvoke(d => d.Visible = !isReady);
        }

        private void PerformServerQuery(string tableName, int takeCount, string serverQuery)
        {
            SetApplicationStatus(isReady: false);

            var stopWatch = Stopwatch.StartNew();

            QueryData = DataProvider.GetEntities(tableName, takeCount: takeCount, filters: serverQuery);
            BindDynamicData(QueryData);

            stopWatch.Stop();

            DisplayTimeTaken(stopWatch.ElapsedMilliseconds);
            SetApplicationStatus(isReady: true);
        }

        private void PerformLinqQuery(string linqQueryString)
        {
            if (QueryData.Count <= 0) return;

            if (linqQueryString.IsEmpty())
            {
                linqQueryString = "data";
            }

            List<dynamic> data = TextToLinq.Filter(QueryData, linqQueryString);

            BindLinqQueryResult(data);
        }

        private void DisplayTimeTaken(long milliSeconds)
        {
            toolStripStatusTime.Text = "[Time Taken: {0}]".ToFormat(TimeSpan.FromMilliseconds(milliSeconds));
        }

        private void DisplayRowsCount(long count)
        {
            toolStripStatusCount.Text = "[Count: {0}]".ToFormat(count);

        }

        private void SetDeveloperAccount(bool isDeveloperAccount)
        {
            txtAccount.Enabled = !IsDeveloperAccount;
            txtKey.Enabled = !IsDeveloperAccount;
        }

        private void BindLinqQueryResult(List<dynamic> data)
        {
            if (data.IsEmpty())
            {
                ClearGrid();
            }
            else if (data[0].GetType().Name == "ExpandoObject")
            {
                BindDynamicData(data);
            }
            else
            {
                dataGrid.SafeInvoke(d => d.DataSource = data);
            }
        }

        private void BindDynamicData(List<dynamic> data)
        {
            if (data.Count > 0)
            {
                DataTable dataTable = data.ToDataTable();
                dataGrid.SafeInvoke(d => d.DataSource = dataTable);
                DisplayRowsCount(data.Count);

                data = null;
            }
            else
            {
                ClearGrid();
            }
        }

        private void ClearGrid()
        {
            var data = new List<dynamic>();
            dataGrid.SafeInvoke(d => d.DataSource = data);

            DisplayRowsCount(data.Count);
        }

        /// <summary>
        /// Writes data from the grid as a CSV file
        /// </summary>
        private void SaveGridToCsv()
        {
            try
            {
                if (dataGrid.Rows.Count <= 0) return;

                using (var strWri = new StreamWriter(saveFileDialog.FileName))
                {
                    //Write Row Header
                    var strRowVal = new StringBuilder();
                    foreach (DataGridViewColumn col in dataGrid.Columns)
                    {
                        strRowVal.Append(col.Name);
                        strRowVal.Append(",");
                    }
                    strWri.WriteLine(strRowVal.ToString().TrimEnd(','));

                    //Write the rows
                    for (var i = 0; i < dataGrid.Rows.Count; i++)
                    {
                        strRowVal = new StringBuilder();
                        for (var j = 0; j < dataGrid.Rows[i].Cells.Count; j++)
                        {
                            strRowVal.Append(dataGrid.Rows[i].Cells[j].Value);
                            strRowVal.Append(",");
                        }
                        strWri.WriteLine(strRowVal.ToString().TrimEnd(','));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetFormTitle()
        {
            this.SafeInvoke(d => d.Text = "Azure Table Browser: [Table: {0}]".ToFormat(cmbTables.Text));
        }
        #endregion

        private void btnLoadAccount_Click(object sender, EventArgs e)
        {
            ResetRowsCount();
            ClearGrid();

            if (IsDeveloperAccount)
            {
                Task.Run(() => LoadAccount(IsDeveloperAccount));
            }
            else
            {
                //validate input
                if (txtAccount.Text.IsEmptyOrWiteSpace())
                {
                    DisplayMessage("Please enter account name");
                    return;
                }

                if (txtKey.Text.IsEmptyOrWiteSpace())
                {
                    DisplayMessage("Please enter key");
                    return;
                }

                // validation passed
                Task.Run(() => LoadAccount(txtAccount.Text, txtKey.Text, isUseHttps: true));
            }
        }

        private void frmTable_Resize(object sender, EventArgs e)
        {
            Task.Run(() => SetDataGridSize());
        }

        /// <summary>
        /// Queries data from Storage Table and displays result
        /// </summary>
        private void btnServerQuery_Click(object sender, EventArgs e)
        {
            //validate input
            if (cmbTables.SelectedValue.IsNull() || cmbTables.SelectedValue.ToString().IsEmptyOrWiteSpace())
            {
                DisplayMessage("No table selected. Pleaes load tables first and choose the one needed.");
                return;
            }

            int takeCount = 0;
            if (!Int32.TryParse(txtCount.Text, out takeCount))
            {
                DisplayMessage("Please enter valid take count.");
                return;
            }


            string tableName = cmbTables.SelectedValue.ToString();
            string serverQuery = txtServerQuery.Text;

            ClearGrid();

            Task.Run(() => PerformServerQuery(tableName, takeCount, serverQuery));
        }

        /// <summary>
        /// Export to CSV click Event.
        /// Sets a default file name and opens save dialog box
        /// </summary>
        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGrid.Rows.Count > 0)
            {
                saveFileDialog.FileName = "\"{0}-{1}.csv\"".ToFormat(cmbTables.SafeInvoke(d => d.SelectedValue.ToString()), DateTimeOffset.UtcNow.UtcTicks);
                saveFileDialog.ShowDialog();
                
            }
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            Task.Run(() => SaveGridToCsv());
        }

        private void txtCount_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{HOME}+{END}");
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetRowsCount();

            Task.Run(() => SetFormTitle());
        }

        private void linkLabelOdataHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://msdn.microsoft.com/en-us/library/windowsazure/ff683669.aspx");
        }

        private void linkLabelLinqHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TODO: Read this from a file
            var help = new frmHelp
            {
                HelpText = @"It runs only on the in-memory collection pulled from Storage Table. Enter a valid LINQ query. It has to be valid C# compilable code. The data in the grid is referred as 'data'.
Both Expression syntax and Lambda expression queries work and produce same output. Both can be used together as well.

Sample #1:

data.Where(d => d.OrderAmount > 100.0)

Sample #2

from r in data
group r by new{r.ProductName, r.City} into g
select new{
  g.Key.ProductName, 
  g.Key.City,
  AvgSalesAmount = g.Average(r => (souble)r.OrderAmount),
}

-OR-

data.GroupBy(r => new{r.ProductName, r.City})
.Select(d => new{
	d.Key.ProductName,
	d.Key.City,
	AvgSalesAmount = d.Average(r => (double)r.OrderAmount),
})

Sample #3

data.GroupBy(x => new { x.EmailTo })
.Select(x => new { x.Key.EmailTo, Count = x.Count()})

Additional Notes:
- While doing a GroupBy, use new{}. Applies for both expression query and lambda query
- While doing a Select, use new{}. Applies for both expression query and lambda query
- While doing an Average on double data type, please do a double cast as shown on the examples above"
            };

            help.ShowDialog();
        }

        private void btnLinqQuery_Click(object sender, EventArgs e)
        {
            var linqQuerystring = txtLinqQuery.Text;
            Task.Run(() => PerformLinqQuery(linqQuerystring));
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            chkIsDeveloperAccount.Checked = IsDeveloperAccount;

            SetDeveloperAccount(IsDeveloperAccount);
        }

        private void chkIsDeveloperAccount_CheckedChanged(object sender, EventArgs e)
        {
            IsDeveloperAccount = chkIsDeveloperAccount.Checked;

            SetDeveloperAccount(IsDeveloperAccount);
        }

        private void dataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenu.Show(dataGrid, new Point(e.X, e.Y));
        }

        private void linkLabelSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/amithegde/AzureTableBrowser");
        }

        private void linkLabelMoreHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/amithegde/AzureTableBrowser/blob/master/help.md");
        }
    }
}