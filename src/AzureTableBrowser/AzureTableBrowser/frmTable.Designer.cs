namespace AzureTableBrowser
{
    partial class frmTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTable));
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnLoadAccount = new System.Windows.Forms.Button();
            this.cmbTables = new System.Windows.Forms.ComboBox();
            this.lblTables = new System.Windows.Forms.Label();
            this.txtServerQuery = new System.Windows.Forms.RichTextBox();
            this.lblOdata = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLinqQuery = new System.Windows.Forms.RichTextBox();
            this.btnServerQuery = new System.Windows.Forms.Button();
            this.btnLinqQuery = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.linkLabelOdataHelp = new System.Windows.Forms.LinkLabel();
            this.linkLabelLinqHelp = new System.Windows.Forms.LinkLabel();
            this.chkIsDeveloperAccount = new System.Windows.Forms.CheckBox();
            this.pictureProgress = new System.Windows.Forms.PictureBox();
            this.linkLabelSource = new System.Windows.Forms.LinkLabel();
            this.linkLabelMoreHelp = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(68, 33);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(373, 20);
            this.txtAccount.TabIndex = 1;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(12, 37);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(50, 13);
            this.lblAccount.TabIndex = 0;
            this.lblAccount.Text = "&Account:";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(34, 63);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(28, 13);
            this.lblKey.TabIndex = 2;
            this.lblKey.Text = "&Key:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(68, 59);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(373, 20);
            this.txtKey.TabIndex = 3;
            // 
            // btnLoadAccount
            // 
            this.btnLoadAccount.Location = new System.Drawing.Point(448, 33);
            this.btnLoadAccount.Name = "btnLoadAccount";
            this.btnLoadAccount.Size = new System.Drawing.Size(75, 46);
            this.btnLoadAccount.TabIndex = 4;
            this.btnLoadAccount.Text = "&Load";
            this.btnLoadAccount.UseVisualStyleBackColor = true;
            this.btnLoadAccount.Click += new System.EventHandler(this.btnLoadAccount_Click);
            // 
            // cmbTables
            // 
            this.cmbTables.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTables.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTables.FormattingEnabled = true;
            this.cmbTables.Location = new System.Drawing.Point(583, 46);
            this.cmbTables.Name = "cmbTables";
            this.cmbTables.Size = new System.Drawing.Size(410, 21);
            this.cmbTables.TabIndex = 6;
            this.cmbTables.SelectedIndexChanged += new System.EventHandler(this.cmbTables_SelectedIndexChanged);
            // 
            // lblTables
            // 
            this.lblTables.AutoSize = true;
            this.lblTables.Location = new System.Drawing.Point(535, 50);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(42, 13);
            this.lblTables.TabIndex = 5;
            this.lblTables.Text = "&Tables:";
            // 
            // txtServerQuery
            // 
            this.txtServerQuery.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServerQuery.Location = new System.Drawing.Point(68, 101);
            this.txtServerQuery.Name = "txtServerQuery";
            this.txtServerQuery.Size = new System.Drawing.Size(455, 104);
            this.txtServerQuery.TabIndex = 10;
            this.txtServerQuery.Text = "";
            // 
            // lblOdata
            // 
            this.lblOdata.AutoSize = true;
            this.lblOdata.Location = new System.Drawing.Point(65, 85);
            this.lblOdata.Name = "lblOdata";
            this.lblOdata.Size = new System.Drawing.Size(78, 13);
            this.lblOdata.TabIndex = 9;
            this.lblOdata.Text = "&ODATA Query:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "&LINQ Query:";
            // 
            // txtLinqQuery
            // 
            this.txtLinqQuery.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLinqQuery.Location = new System.Drawing.Point(538, 101);
            this.txtLinqQuery.Name = "txtLinqQuery";
            this.txtLinqQuery.Size = new System.Drawing.Size(455, 104);
            this.txtLinqQuery.TabIndex = 12;
            this.txtLinqQuery.Text = "";
            // 
            // btnServerQuery
            // 
            this.btnServerQuery.Location = new System.Drawing.Point(999, 99);
            this.btnServerQuery.Name = "btnServerQuery";
            this.btnServerQuery.Size = new System.Drawing.Size(102, 38);
            this.btnServerQuery.TabIndex = 13;
            this.btnServerQuery.Text = "Server &Query";
            this.btnServerQuery.UseVisualStyleBackColor = true;
            this.btnServerQuery.Click += new System.EventHandler(this.btnServerQuery_Click);
            // 
            // btnLinqQuery
            // 
            this.btnLinqQuery.Location = new System.Drawing.Point(999, 143);
            this.btnLinqQuery.Name = "btnLinqQuery";
            this.btnLinqQuery.Size = new System.Drawing.Size(102, 38);
            this.btnLinqQuery.TabIndex = 14;
            this.btnLinqQuery.Text = "&LINQ Query";
            this.btnLinqQuery.UseVisualStyleBackColor = true;
            this.btnLinqQuery.Click += new System.EventHandler(this.btnLinqQuery_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(3, 211);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1098, 360);
            this.dataGrid.TabIndex = 16;
            this.dataGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGrid_MouseClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus,
            this.toolStripStatusTime,
            this.toolStripStatusCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 574);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1106, 22);
            this.statusStrip.TabIndex = 14;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatus.Text = "[Ready]";
            // 
            // toolStripStatusTime
            // 
            this.toolStripStatusTime.Name = "toolStripStatusTime";
            this.toolStripStatusTime.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusTime.Text = "[Time Taken: ]";
            // 
            // toolStripStatusCount
            // 
            this.toolStripStatusCount.Name = "toolStripStatusCount";
            this.toolStripStatusCount.Size = new System.Drawing.Size(54, 17);
            this.toolStripStatusCount.Text = "[Count: ]";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(999, 50);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(38, 13);
            this.lblCount.TabIndex = 7;
            this.lblCount.Text = "&Count:";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(1043, 46);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(58, 20);
            this.txtCount.TabIndex = 8;
            this.txtCount.Text = "200";
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCount.Enter += new System.EventHandler(this.txtCount_Enter);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToCSVToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(149, 26);
            // 
            // exportToCSVToolStripMenuItem
            // 
            this.exportToCSVToolStripMenuItem.Name = "exportToCSVToolStripMenuItem";
            this.exportToCSVToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exportToCSVToolStripMenuItem.Text = "Export To CSV";
            this.exportToCSVToolStripMenuItem.Click += new System.EventHandler(this.exportToCSVToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "Untitled.csv";
            this.saveFileDialog.Filter = "\"CSV Files (*.csv)|*.csv\"";
            this.saveFileDialog.Title = "Export Csv";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // linkLabelOdataHelp
            // 
            this.linkLabelOdataHelp.AutoSize = true;
            this.linkLabelOdataHelp.Location = new System.Drawing.Point(144, 85);
            this.linkLabelOdataHelp.Name = "linkLabelOdataHelp";
            this.linkLabelOdataHelp.Size = new System.Drawing.Size(13, 13);
            this.linkLabelOdataHelp.TabIndex = 18;
            this.linkLabelOdataHelp.TabStop = true;
            this.linkLabelOdataHelp.Text = "?";
            this.linkLabelOdataHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOdataHelp_LinkClicked);
            // 
            // linkLabelLinqHelp
            // 
            this.linkLabelLinqHelp.AutoSize = true;
            this.linkLabelLinqHelp.Location = new System.Drawing.Point(601, 85);
            this.linkLabelLinqHelp.Name = "linkLabelLinqHelp";
            this.linkLabelLinqHelp.Size = new System.Drawing.Size(13, 13);
            this.linkLabelLinqHelp.TabIndex = 19;
            this.linkLabelLinqHelp.TabStop = true;
            this.linkLabelLinqHelp.Text = "?";
            this.linkLabelLinqHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLinqHelp_LinkClicked);
            // 
            // chkIsDeveloperAccount
            // 
            this.chkIsDeveloperAccount.AutoSize = true;
            this.chkIsDeveloperAccount.Location = new System.Drawing.Point(68, 10);
            this.chkIsDeveloperAccount.Name = "chkIsDeveloperAccount";
            this.chkIsDeveloperAccount.Size = new System.Drawing.Size(118, 17);
            this.chkIsDeveloperAccount.TabIndex = 20;
            this.chkIsDeveloperAccount.TabStop = false;
            this.chkIsDeveloperAccount.Text = "Developer Account";
            this.chkIsDeveloperAccount.UseVisualStyleBackColor = true;
            this.chkIsDeveloperAccount.CheckedChanged += new System.EventHandler(this.chkIsDeveloperAccount_CheckedChanged);
            // 
            // pictureProgress
            // 
            this.pictureProgress.Image = global::AzureTableBrowser.Properties.Resources.progress;
            this.pictureProgress.Location = new System.Drawing.Point(999, 187);
            this.pictureProgress.Name = "pictureProgress";
            this.pictureProgress.Size = new System.Drawing.Size(102, 10);
            this.pictureProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureProgress.TabIndex = 21;
            this.pictureProgress.TabStop = false;
            this.pictureProgress.Visible = false;
            // 
            // linkLabelSource
            // 
            this.linkLabelSource.AutoSize = true;
            this.linkLabelSource.Location = new System.Drawing.Point(1060, 6);
            this.linkLabelSource.Name = "linkLabelSource";
            this.linkLabelSource.Size = new System.Drawing.Size(41, 13);
            this.linkLabelSource.TabIndex = 22;
            this.linkLabelSource.Text = "Source";
            this.linkLabelSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSource_LinkClicked);
            // 
            // linkLabelMoreHelp
            // 
            this.linkLabelMoreHelp.AutoSize = true;
            this.linkLabelMoreHelp.Location = new System.Drawing.Point(1045, 22);
            this.linkLabelMoreHelp.Name = "linkLabelMoreHelp";
            this.linkLabelMoreHelp.Size = new System.Drawing.Size(56, 13);
            this.linkLabelMoreHelp.TabIndex = 23;
            this.linkLabelMoreHelp.TabStop = true;
            this.linkLabelMoreHelp.Text = "&More Help";
            this.linkLabelMoreHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMoreHelp_LinkClicked);
            // 
            // frmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 596);
            this.Controls.Add(this.linkLabelMoreHelp);
            this.Controls.Add(this.linkLabelSource);
            this.Controls.Add(this.pictureProgress);
            this.Controls.Add(this.chkIsDeveloperAccount);
            this.Controls.Add(this.linkLabelLinqHelp);
            this.Controls.Add(this.linkLabelOdataHelp);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.btnLinqQuery);
            this.Controls.Add(this.btnServerQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLinqQuery);
            this.Controls.Add(this.lblOdata);
            this.Controls.Add(this.txtServerQuery);
            this.Controls.Add(this.lblTables);
            this.Controls.Add(this.cmbTables);
            this.Controls.Add(this.btnLoadAccount);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.txtAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTable";
            this.Text = "Azure Table Browser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTable_Load);
            this.Resize += new System.EventHandler(this.frmTable_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnLoadAccount;
        private System.Windows.Forms.ComboBox cmbTables;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.RichTextBox txtServerQuery;
        private System.Windows.Forms.Label lblOdata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtLinqQuery;
        private System.Windows.Forms.Button btnServerQuery;
        private System.Windows.Forms.Button btnLinqQuery;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCount;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem exportToCSVToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.LinkLabel linkLabelOdataHelp;
        private System.Windows.Forms.LinkLabel linkLabelLinqHelp;
        private System.Windows.Forms.CheckBox chkIsDeveloperAccount;
        private System.Windows.Forms.PictureBox pictureProgress;
        private System.Windows.Forms.LinkLabel linkLabelSource;
        private System.Windows.Forms.LinkLabel linkLabelMoreHelp;
    }
}

