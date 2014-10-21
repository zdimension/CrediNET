namespace CrediNET
{
    partial class MainWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        //System.ComponentModel.ComponentResourceManager resources;

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblAccountName = new System.Windows.Forms.ToolStripStatusLabel();
            this.spacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalCredit = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalDeb = new System.Windows.Forms.ToolStripStatusLabel();
            this.ofpCompte = new System.Windows.Forms.OpenFileDialog();
            this.sfdCompte = new System.Windows.Forms.SaveFileDialog();
            this.sfdCSV = new System.Windows.Forms.SaveFileDialog();
            this.sfdXLS = new System.Windows.Forms.SaveFileDialog();
            this.sfdXLSX = new System.Windows.Forms.SaveFileDialog();
            this.sfdODS = new System.Windows.Forms.SaveFileDialog();
            this.lblSolde = new System.Windows.Forms.Label();
            this.lblSoldeAt = new System.Windows.Forms.Label();
            this.lvOps = new CrediNET.DoubleBufferListView();
            this.clmnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnBudget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnComm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnCred = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnDeb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip = new CrediNET.NoBorderToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripSplitButton();
            this.enregistrerSousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cryptéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichierCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichierExcel972003ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichierExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classeurOpenOfficeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditAcc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddOp = new System.Windows.Forms.ToolStripButton();
            this.btnEditOp = new System.Windows.Forms.ToolStripButton();
            this.btnDuplOp = new System.Windows.Forms.ToolStripButton();
            this.btnDelOp = new System.Windows.Forms.ToolStripButton();
            this.btnFilterOp = new System.Windows.Forms.ToolStripButton();
            this.btnOpt = new System.Windows.Forms.ToolStripButton();
            this.btnReminder = new System.Windows.Forms.ToolStripButton();
            this.btnGraph = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCamembert = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCourbes = new System.Windows.Forms.ToolStripMenuItem();
            this.bwkSave = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAccountName,
            this.spacer,
            this.lblTotalCredit,
            this.lblTotalDeb});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            // 
            // lblAccountName
            // 
            this.lblAccountName.ForeColor = System.Drawing.Color.LightGray;
            this.lblAccountName.Name = "lblAccountName";
            resources.ApplyResources(this.lblAccountName, "lblAccountName");
            // 
            // spacer
            // 
            this.spacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.spacer.ForeColor = System.Drawing.Color.LightGray;
            this.spacer.Name = "spacer";
            resources.ApplyResources(this.spacer, "spacer");
            this.spacer.Spring = true;
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            resources.ApplyResources(this.lblTotalCredit, "lblTotalCredit");
            // 
            // lblTotalDeb
            // 
            this.lblTotalDeb.ForeColor = System.Drawing.Color.Red;
            this.lblTotalDeb.Name = "lblTotalDeb";
            this.lblTotalDeb.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            resources.ApplyResources(this.lblTotalDeb, "lblTotalDeb");
            // 
            // ofpCompte
            // 
            this.ofpCompte.DefaultExt = "cna";
            resources.ApplyResources(this.ofpCompte, "ofpCompte");
            // 
            // sfdCompte
            // 
            resources.ApplyResources(this.sfdCompte, "sfdCompte");
            // 
            // sfdCSV
            // 
            this.sfdCSV.DefaultExt = "csv";
            resources.ApplyResources(this.sfdCSV, "sfdCSV");
            // 
            // sfdXLS
            // 
            this.sfdXLS.DefaultExt = "xls";
            resources.ApplyResources(this.sfdXLS, "sfdXLS");
            // 
            // sfdXLSX
            // 
            this.sfdXLSX.DefaultExt = "xlsx";
            resources.ApplyResources(this.sfdXLSX, "sfdXLSX");
            // 
            // sfdODS
            // 
            this.sfdODS.DefaultExt = "ods";
            resources.ApplyResources(this.sfdODS, "sfdODS");
            // 
            // lblSolde
            // 
            resources.ApplyResources(this.lblSolde, "lblSolde");
            this.lblSolde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblSolde.Name = "lblSolde";
            // 
            // lblSoldeAt
            // 
            resources.ApplyResources(this.lblSoldeAt, "lblSoldeAt");
            this.lblSoldeAt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblSoldeAt.Name = "lblSoldeAt";
            // 
            // lvOps
            // 
            this.lvOps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvOps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnID,
            this.clmnDate,
            this.clmnType,
            this.clmnBudget,
            this.clmnComm,
            this.clmnCred,
            this.clmnDeb});
            resources.ApplyResources(this.lvOps, "lvOps");
            this.lvOps.FullRowSelect = true;
            this.lvOps.Name = "lvOps";
            this.lvOps.UseCompatibleStateImageBehavior = false;
            this.lvOps.View = System.Windows.Forms.View.Details;
            this.lvOps.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOps_ColumnClick);
            this.lvOps.SelectedIndexChanged += new System.EventHandler(this.lvOps_SelectedIndexChanged);
            this.lvOps.DoubleClick += new System.EventHandler(this.lvOps_DoubleClick);
            // 
            // clmnID
            // 
            resources.ApplyResources(this.clmnID, "clmnID");
            // 
            // clmnDate
            // 
            resources.ApplyResources(this.clmnDate, "clmnDate");
            // 
            // clmnType
            // 
            resources.ApplyResources(this.clmnType, "clmnType");
            // 
            // clmnBudget
            // 
            resources.ApplyResources(this.clmnBudget, "clmnBudget");
            // 
            // clmnComm
            // 
            resources.ApplyResources(this.clmnComm, "clmnComm");
            // 
            // clmnCred
            // 
            resources.ApplyResources(this.clmnCred, "clmnCred");
            // 
            // clmnDeb
            // 
            resources.ApplyResources(this.clmnDeb, "clmnDeb");
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnEditAcc,
            this.toolStripSeparator1,
            this.btnAddOp,
            this.btnEditOp,
            this.btnDuplOp,
            this.btnDelOp,
            this.btnFilterOp,
            this.btnOpt,
            this.btnReminder,
            this.btnGraph});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Paint += new System.Windows.Forms.PaintEventHandler(this.toolStrip_Paint);
            // 
            // btnNew
            // 
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Image = global::CrediNET.Properties.Resources.document_plus;
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Image = global::CrediNET.Properties.Resources.document_import;
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enregistrerSousToolStripMenuItem,
            this.cryptéToolStripMenuItem,
            this.toolStripSeparator2,
            this.exporterToolStripMenuItem});
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::CrediNET.Properties.Resources.save;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.ButtonClick += new System.EventHandler(this.btnSave_Click);
            // 
            // enregistrerSousToolStripMenuItem
            // 
            this.enregistrerSousToolStripMenuItem.Image = global::CrediNET.Properties.Resources.save_as;
            resources.ApplyResources(this.enregistrerSousToolStripMenuItem, "enregistrerSousToolStripMenuItem");
            this.enregistrerSousToolStripMenuItem.Name = "enregistrerSousToolStripMenuItem";
            this.enregistrerSousToolStripMenuItem.Click += new System.EventHandler(this.enregistrerSousToolStripMenuItem_Click);
            // 
            // cryptéToolStripMenuItem
            // 
            resources.ApplyResources(this.cryptéToolStripMenuItem, "cryptéToolStripMenuItem");
            this.cryptéToolStripMenuItem.Image = global::CrediNET.Properties.Resources.document_protect;
            this.cryptéToolStripMenuItem.Name = "cryptéToolStripMenuItem";
            this.cryptéToolStripMenuItem.CheckedChanged += new System.EventHandler(this.cryptéToolStripMenuItem_CheckedChanged);
            this.cryptéToolStripMenuItem.Click += new System.EventHandler(this.cryptéToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // exporterToolStripMenuItem
            // 
            this.exporterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierCSVToolStripMenuItem,
            this.fichierExcel972003ToolStripMenuItem,
            this.fichierExcelToolStripMenuItem,
            this.classeurOpenOfficeToolStripMenuItem});
            resources.ApplyResources(this.exporterToolStripMenuItem, "exporterToolStripMenuItem");
            this.exporterToolStripMenuItem.Name = "exporterToolStripMenuItem";
            // 
            // fichierCSVToolStripMenuItem
            // 
            this.fichierCSVToolStripMenuItem.Image = global::CrediNET.Properties.Resources.csv;
            resources.ApplyResources(this.fichierCSVToolStripMenuItem, "fichierCSVToolStripMenuItem");
            this.fichierCSVToolStripMenuItem.Name = "fichierCSVToolStripMenuItem";
            this.fichierCSVToolStripMenuItem.Click += new System.EventHandler(this.fichierCSVToolStripMenuItem_Click);
            // 
            // fichierExcel972003ToolStripMenuItem
            // 
            this.fichierExcel972003ToolStripMenuItem.Image = global::CrediNET.Properties.Resources.xls;
            resources.ApplyResources(this.fichierExcel972003ToolStripMenuItem, "fichierExcel972003ToolStripMenuItem");
            this.fichierExcel972003ToolStripMenuItem.Name = "fichierExcel972003ToolStripMenuItem";
            this.fichierExcel972003ToolStripMenuItem.Click += new System.EventHandler(this.fichierExcelToolStripMenuItem_Click);
            // 
            // fichierExcelToolStripMenuItem
            // 
            this.fichierExcelToolStripMenuItem.Image = global::CrediNET.Properties.Resources.icon_xlsx;
            resources.ApplyResources(this.fichierExcelToolStripMenuItem, "fichierExcelToolStripMenuItem");
            this.fichierExcelToolStripMenuItem.Name = "fichierExcelToolStripMenuItem";
            this.fichierExcelToolStripMenuItem.Click += new System.EventHandler(this.fichierExcelToolStripMenuItem_Click_1);
            // 
            // classeurOpenOfficeToolStripMenuItem
            // 
            this.classeurOpenOfficeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem});
            resources.ApplyResources(this.classeurOpenOfficeToolStripMenuItem, "classeurOpenOfficeToolStripMenuItem");
            this.classeurOpenOfficeToolStripMenuItem.Image = global::CrediNET.Properties.Resources.pngU1X58JfMGF;
            this.classeurOpenOfficeToolStripMenuItem.Name = "classeurOpenOfficeToolStripMenuItem";
            this.classeurOpenOfficeToolStripMenuItem.Click += new System.EventHandler(this.classeurOpenOfficeToolStripMenuItem_Click);
            // 
            // ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem
            // 
            this.ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem.Name = "ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem";
            resources.ApplyResources(this.ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem, "ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem");
            // 
            // btnEditAcc
            // 
            this.btnEditAcc.Image = global::CrediNET.Properties.Resources.document_prepare;
            resources.ApplyResources(this.btnEditAcc, "btnEditAcc");
            this.btnEditAcc.Name = "btnEditAcc";
            this.btnEditAcc.Click += new System.EventHandler(this.btnEditAcc_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnAddOp
            // 
            this.btnAddOp.Image = global::CrediNET.Properties.Resources.page_add;
            resources.ApplyResources(this.btnAddOp, "btnAddOp");
            this.btnAddOp.Name = "btnAddOp";
            this.btnAddOp.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // btnEditOp
            // 
            resources.ApplyResources(this.btnEditOp, "btnEditOp");
            this.btnEditOp.Image = global::CrediNET.Properties.Resources.page_edit;
            this.btnEditOp.Name = "btnEditOp";
            this.btnEditOp.Click += new System.EventHandler(this.btnEditOp_Click);
            // 
            // btnDuplOp
            // 
            resources.ApplyResources(this.btnDuplOp, "btnDuplOp");
            this.btnDuplOp.Image = global::CrediNET.Properties.Resources.page_copy;
            this.btnDuplOp.Name = "btnDuplOp";
            this.btnDuplOp.Click += new System.EventHandler(this.btnDuplOp_Click);
            // 
            // btnDelOp
            // 
            resources.ApplyResources(this.btnDelOp, "btnDelOp");
            this.btnDelOp.Image = global::CrediNET.Properties.Resources.page_delete;
            this.btnDelOp.Name = "btnDelOp";
            this.btnDelOp.Click += new System.EventHandler(this.btnDelOp_Click);
            // 
            // btnFilterOp
            // 
            this.btnFilterOp.Image = global::CrediNET.Properties.Resources.page_find;
            resources.ApplyResources(this.btnFilterOp, "btnFilterOp");
            this.btnFilterOp.Name = "btnFilterOp";
            this.btnFilterOp.Click += new System.EventHandler(this.btnFilterOp_Click);
            // 
            // btnOpt
            // 
            this.btnOpt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOpt.Image = global::CrediNET.Properties.Resources.application_form_edit;
            resources.ApplyResources(this.btnOpt, "btnOpt");
            this.btnOpt.Name = "btnOpt";
            this.btnOpt.Click += new System.EventHandler(this.btnOpt_Click_1);
            // 
            // btnReminder
            // 
            this.btnReminder.Image = global::CrediNET.Properties.Resources.page_refresh;
            resources.ApplyResources(this.btnReminder, "btnReminder");
            this.btnReminder.Name = "btnReminder";
            this.btnReminder.Click += new System.EventHandler(this.btnReminder_Click);
            // 
            // btnGraph
            // 
            this.btnGraph.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCamembert,
            this.btnCourbes});
            this.btnGraph.Image = global::CrediNET.Properties.Resources.diagnostic_chart1;
            resources.ApplyResources(this.btnGraph, "btnGraph");
            this.btnGraph.Name = "btnGraph";
            // 
            // btnCamembert
            // 
            this.btnCamembert.Image = global::CrediNET.Properties.Resources.chart_pie;
            resources.ApplyResources(this.btnCamembert, "btnCamembert");
            this.btnCamembert.Name = "btnCamembert";
            this.btnCamembert.Click += new System.EventHandler(this.btnCamembert_Click);
            // 
            // btnCourbes
            // 
            this.btnCourbes.Image = global::CrediNET.Properties.Resources.chart_line;
            resources.ApplyResources(this.btnCourbes, "btnCourbes");
            this.btnCourbes.Name = "btnCourbes";
            this.btnCourbes.Click += new System.EventHandler(this.btnCourbes_Click);
            // 
            // bwkSave
            // 
            this.bwkSave.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwkSave_DoWork);
            this.bwkSave.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwkSave_RunWorkerCompleted);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.Controls.Add(this.lblSoldeAt);
            this.Controls.Add(this.lblSolde);
            this.Controls.Add(this.lvOps);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.SizeChanged += new System.EventHandler(this.MainWindow_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblAccountName;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalCredit;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalDeb;
        private System.Windows.Forms.ToolStripStatusLabel spacer;
        private System.Windows.Forms.OpenFileDialog ofpCompte;
        private System.Windows.Forms.SaveFileDialog sfdCompte;
        private System.Windows.Forms.SaveFileDialog sfdCSV;
        private System.Windows.Forms.SaveFileDialog sfdXLS;
        private System.Windows.Forms.SaveFileDialog sfdXLSX;
        private System.Windows.Forms.SaveFileDialog sfdODS;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripSplitButton btnSave;
        private System.Windows.Forms.ToolStripMenuItem enregistrerSousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cryptéToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichierCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichierExcel972003ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichierExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classeurOpenOfficeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnEditAcc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAddOp;
        private System.Windows.Forms.ToolStripButton btnEditOp;
        private System.Windows.Forms.ToolStripButton btnDuplOp;
        private System.Windows.Forms.ToolStripButton btnDelOp;
        private System.Windows.Forms.ToolStripButton btnFilterOp;
        private System.Windows.Forms.ToolStripButton btnOpt;
        private NoBorderToolStrip toolStrip;
        private System.Windows.Forms.ColumnHeader clmnID;
        private System.Windows.Forms.ColumnHeader clmnDate;
        private System.Windows.Forms.ColumnHeader clmnType;
        private System.Windows.Forms.ColumnHeader clmnBudget;
        private System.Windows.Forms.ColumnHeader clmnComm;
        private System.Windows.Forms.ColumnHeader clmnCred;
        private System.Windows.Forms.ColumnHeader clmnDeb;
        private DoubleBufferListView lvOps;
        private System.Windows.Forms.Label lblSolde;
        private System.Windows.Forms.ToolStripDropDownButton btnGraph;
        private System.Windows.Forms.ToolStripMenuItem btnCamembert;
        private System.Windows.Forms.ToolStripMenuItem btnCourbes;
        private System.Windows.Forms.Label lblSoldeAt;
        private System.Windows.Forms.ToolStripButton btnReminder;
        private System.ComponentModel.BackgroundWorker bwkSave;
    }
}

