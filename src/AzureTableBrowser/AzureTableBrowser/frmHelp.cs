using System;
using System.Windows.Forms;

namespace AzureTableBrowser
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        public string HelpText { get; set; }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            txtHelp.Text = HelpText;
            btnOk.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
