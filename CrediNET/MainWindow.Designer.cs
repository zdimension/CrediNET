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

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
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
            this.btnGraph = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCamembert = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCourbes = new System.Windows.Forms.ToolStripMenuItem();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1057, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblAccountName
            // 
            this.lblAccountName.ForeColor = System.Drawing.Color.LightGray;
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(140, 17);
            this.lblAccountName.Text = "<Pas de compte chargé>";
            // 
            // spacer
            // 
            this.spacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.spacer.ForeColor = System.Drawing.Color.LightGray;
            this.spacer.Name = "spacer";
            this.spacer.Size = new System.Drawing.Size(788, 17);
            this.spacer.Spring = true;
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblTotalCredit.Size = new System.Drawing.Size(57, 17);
            this.lblTotalCredit.Text = "0,00 €";
            // 
            // lblTotalDeb
            // 
            this.lblTotalDeb.ForeColor = System.Drawing.Color.Red;
            this.lblTotalDeb.Name = "lblTotalDeb";
            this.lblTotalDeb.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblTotalDeb.Size = new System.Drawing.Size(57, 17);
            this.lblTotalDeb.Text = "0,00 €";
            // 
            // ofpCompte
            // 
            this.ofpCompte.DefaultExt = "cna";
            this.ofpCompte.Filter = "Compte CrediNET (*.cna, *.cne)|*.cna;*.cne";
            // 
            // sfdCompte
            // 
            this.sfdCompte.Filter = "Compte CrediNET (*.cna, *.cne)|*.cna;*.cne";
            // 
            // sfdCSV
            // 
            this.sfdCSV.DefaultExt = "csv";
            this.sfdCSV.Filter = "Fichier CSV (*.csv)|*.csv";
            // 
            // sfdXLS
            // 
            this.sfdXLS.DefaultExt = "xls";
            this.sfdXLS.Filter = "Classeur Excel 97-2003 (*.xls)|*.xls";
            // 
            // sfdXLSX
            // 
            this.sfdXLSX.DefaultExt = "xlsx";
            this.sfdXLSX.Filter = "Classeur Excel (*.xlsx)|*.xlsx";
            // 
            // sfdODS
            // 
            this.sfdODS.DefaultExt = "ods";
            this.sfdODS.Filter = "Classeur OpenOffice/LibreOffice (*.ods)|*.ods";
            // 
            // lblSolde
            // 
            this.lblSolde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSolde.AutoSize = true;
            this.lblSolde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblSolde.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolde.Location = new System.Drawing.Point(788, 32);
            this.lblSolde.Name = "lblSolde";
            this.lblSolde.Size = new System.Drawing.Size(158, 32);
            this.lblSolde.TabIndex = 3;
            this.lblSolde.Text = "Solde : 0,00 €";
            this.lblSolde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSoldeAt
            // 
            this.lblSoldeAt.AutoSize = true;
            this.lblSoldeAt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblSoldeAt.Location = new System.Drawing.Point(792, 13);
            this.lblSoldeAt.Name = "lblSoldeAt";
            this.lblSoldeAt.Size = new System.Drawing.Size(128, 15);
            this.lblSoldeAt.TabIndex = 4;
            this.lblSoldeAt.Text = "Solde au   /  /     : 0,00 €";
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
            this.lvOps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOps.FullRowSelect = true;
            this.lvOps.Location = new System.Drawing.Point(0, 69);
            this.lvOps.Margin = new System.Windows.Forms.Padding(0);
            this.lvOps.Name = "lvOps";
            this.lvOps.Size = new System.Drawing.Size(1057, 417);
            this.lvOps.TabIndex = 2;
            this.lvOps.UseCompatibleStateImageBehavior = false;
            this.lvOps.View = System.Windows.Forms.View.Details;
            this.lvOps.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOps_ColumnClick);
            this.lvOps.SelectedIndexChanged += new System.EventHandler(this.lvOps_SelectedIndexChanged);
            // 
            // clmnID
            // 
            this.clmnID.Width = 0;
            // 
            // clmnDate
            // 
            this.clmnDate.Text = "Date";
            this.clmnDate.Width = 75;
            // 
            // clmnType
            // 
            this.clmnType.Text = "Type";
            // 
            // clmnBudget
            // 
            this.clmnBudget.Text = "Budget";
            this.clmnBudget.Width = 100;
            // 
            // clmnComm
            // 
            this.clmnComm.Text = "Commentaire";
            this.clmnComm.Width = 598;
            // 
            // clmnCred
            // 
            this.clmnCred.Text = "Crédit";
            this.clmnCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // clmnDeb
            // 
            this.clmnDeb.Text = "Débit";
            this.clmnDeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.btnGraph});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.MinimumSize = new System.Drawing.Size(0, 69);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(1057, 69);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.Paint += new System.Windows.Forms.PaintEventHandler(this.toolStrip_Paint);
            // 
            // btnNew
            // 
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Image = global::CrediNET.Properties.Resources.document_plus;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(39, 66);
            this.btnNew.Text = "Créer";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Image = global::CrediNET.Properties.Resources.document_import;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(44, 66);
            this.btnOpen.Text = "Ouvrir";
            this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 66);
            this.btnSave.Text = "Enregistrer";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Visible = false;
            this.btnSave.ButtonClick += new System.EventHandler(this.btnSave_Click);
            // 
            // enregistrerSousToolStripMenuItem
            // 
            this.enregistrerSousToolStripMenuItem.Image = global::CrediNET.Properties.Resources.save_as;
            this.enregistrerSousToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.enregistrerSousToolStripMenuItem.Name = "enregistrerSousToolStripMenuItem";
            this.enregistrerSousToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.enregistrerSousToolStripMenuItem.Text = "Enregistrer sous";
            this.enregistrerSousToolStripMenuItem.Click += new System.EventHandler(this.enregistrerSousToolStripMenuItem_Click);
            // 
            // cryptéToolStripMenuItem
            // 
            this.cryptéToolStripMenuItem.Enabled = false;
            this.cryptéToolStripMenuItem.Image = global::CrediNET.Properties.Resources.document_protect;
            this.cryptéToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cryptéToolStripMenuItem.Name = "cryptéToolStripMenuItem";
            this.cryptéToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.cryptéToolStripMenuItem.Text = "Crypté";
            this.cryptéToolStripMenuItem.CheckedChanged += new System.EventHandler(this.cryptéToolStripMenuItem_CheckedChanged);
            this.cryptéToolStripMenuItem.Click += new System.EventHandler(this.cryptéToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // exporterToolStripMenuItem
            // 
            this.exporterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierCSVToolStripMenuItem,
            this.fichierExcel972003ToolStripMenuItem,
            this.fichierExcelToolStripMenuItem,
            this.classeurOpenOfficeToolStripMenuItem});
            this.exporterToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exporterToolStripMenuItem.Name = "exporterToolStripMenuItem";
            this.exporterToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exporterToolStripMenuItem.Text = "Exporter";
            // 
            // fichierCSVToolStripMenuItem
            // 
            this.fichierCSVToolStripMenuItem.Image = global::CrediNET.Properties.Resources.csv;
            this.fichierCSVToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fichierCSVToolStripMenuItem.Name = "fichierCSVToolStripMenuItem";
            this.fichierCSVToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.fichierCSVToolStripMenuItem.Text = "Fichier CSV";
            this.fichierCSVToolStripMenuItem.Click += new System.EventHandler(this.fichierCSVToolStripMenuItem_Click);
            // 
            // fichierExcel972003ToolStripMenuItem
            // 
            this.fichierExcel972003ToolStripMenuItem.Image = global::CrediNET.Properties.Resources.xls;
            this.fichierExcel972003ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fichierExcel972003ToolStripMenuItem.Name = "fichierExcel972003ToolStripMenuItem";
            this.fichierExcel972003ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.fichierExcel972003ToolStripMenuItem.Text = "Fichier Excel 97-2003";
            this.fichierExcel972003ToolStripMenuItem.Click += new System.EventHandler(this.fichierExcelToolStripMenuItem_Click);
            // 
            // fichierExcelToolStripMenuItem
            // 
            this.fichierExcelToolStripMenuItem.Image = global::CrediNET.Properties.Resources.icon_xlsx;
            this.fichierExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fichierExcelToolStripMenuItem.Name = "fichierExcelToolStripMenuItem";
            this.fichierExcelToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.fichierExcelToolStripMenuItem.Text = "Fichier Excel";
            this.fichierExcelToolStripMenuItem.Click += new System.EventHandler(this.fichierExcelToolStripMenuItem_Click_1);
            // 
            // classeurOpenOfficeToolStripMenuItem
            // 
            this.classeurOpenOfficeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem});
            this.classeurOpenOfficeToolStripMenuItem.Enabled = false;
            this.classeurOpenOfficeToolStripMenuItem.Image = global::CrediNET.Properties.Resources.pngU1X58JfMGF;
            this.classeurOpenOfficeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.classeurOpenOfficeToolStripMenuItem.Name = "classeurOpenOfficeToolStripMenuItem";
            this.classeurOpenOfficeToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.classeurOpenOfficeToolStripMenuItem.Text = "Classeur OpenOffice";
            this.classeurOpenOfficeToolStripMenuItem.Click += new System.EventHandler(this.classeurOpenOfficeToolStripMenuItem_Click);
            // 
            // ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem
            // 
            this.ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem.Name = "ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem";
            this.ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem.Size = new System.Drawing.Size(307, 22);
            this.ceTypeDeFichierNnestPasEncoreSupportéToolStripMenuItem.Text = "Ce type de fichier n\'est pas encore supporté.";
            // 
            // btnEditAcc
            // 
            this.btnEditAcc.Image = global::CrediNET.Properties.Resources.document_prepare;
            this.btnEditAcc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditAcc.Name = "btnEditAcc";
            this.btnEditAcc.Size = new System.Drawing.Size(67, 66);
            this.btnEditAcc.Text = "Modifier\n le compte";
            this.btnEditAcc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditAcc.Visible = false;
            this.btnEditAcc.Click += new System.EventHandler(this.btnEditAcc_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 69);
            this.toolStripSeparator1.Visible = false;
            // 
            // btnAddOp
            // 
            this.btnAddOp.Image = global::CrediNET.Properties.Resources.page_add;
            this.btnAddOp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddOp.Name = "btnAddOp";
            this.btnAddOp.Size = new System.Drawing.Size(50, 66);
            this.btnAddOp.Text = "Ajouter";
            this.btnAddOp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddOp.ToolTipText = "Ajouter";
            this.btnAddOp.Visible = false;
            this.btnAddOp.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // btnEditOp
            // 
            this.btnEditOp.Enabled = false;
            this.btnEditOp.Image = global::CrediNET.Properties.Resources.page_edit;
            this.btnEditOp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditOp.Name = "btnEditOp";
            this.btnEditOp.Size = new System.Drawing.Size(41, 66);
            this.btnEditOp.Text = "Éditer";
            this.btnEditOp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditOp.Visible = false;
            this.btnEditOp.Click += new System.EventHandler(this.btnEditOp_Click);
            // 
            // btnDuplOp
            // 
            this.btnDuplOp.Enabled = false;
            this.btnDuplOp.Image = global::CrediNET.Properties.Resources.page_copy;
            this.btnDuplOp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDuplOp.Name = "btnDuplOp";
            this.btnDuplOp.Size = new System.Drawing.Size(63, 66);
            this.btnDuplOp.Text = "Dupliquer";
            this.btnDuplOp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDuplOp.Visible = false;
            this.btnDuplOp.Click += new System.EventHandler(this.btnDuplOp_Click);
            // 
            // btnDelOp
            // 
            this.btnDelOp.Enabled = false;
            this.btnDelOp.Image = global::CrediNET.Properties.Resources.page_delete;
            this.btnDelOp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelOp.Name = "btnDelOp";
            this.btnDelOp.Size = new System.Drawing.Size(66, 66);
            this.btnDelOp.Text = "Supprimer";
            this.btnDelOp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelOp.Visible = false;
            this.btnDelOp.Click += new System.EventHandler(this.btnDelOp_Click);
            // 
            // btnFilterOp
            // 
            this.btnFilterOp.Image = global::CrediNET.Properties.Resources.page_find;
            this.btnFilterOp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilterOp.Name = "btnFilterOp";
            this.btnFilterOp.Size = new System.Drawing.Size(41, 66);
            this.btnFilterOp.Text = "Filtrer";
            this.btnFilterOp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFilterOp.Visible = false;
            // 
            // btnOpt
            // 
            this.btnOpt.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnOpt.Image = global::CrediNET.Properties.Resources.application_form_edit;
            this.btnOpt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpt.Name = "btnOpt";
            this.btnOpt.Size = new System.Drawing.Size(58, 66);
            this.btnOpt.Text = "Réglages";
            this.btnOpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpt.Click += new System.EventHandler(this.btnOpt_Click_1);
            // 
            // btnGraph
            // 
            this.btnGraph.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCamembert,
            this.btnCourbes});
            this.btnGraph.Image = global::CrediNET.Properties.Resources.diagnostic_chart1;
            this.btnGraph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 66);
            this.btnGraph.Text = "Graphique";
            this.btnGraph.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGraph.Visible = false;
            // 
            // btnCamembert
            // 
            this.btnCamembert.Image = global::CrediNET.Properties.Resources.chart_pie;
            this.btnCamembert.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCamembert.Name = "btnCamembert";
            this.btnCamembert.Size = new System.Drawing.Size(137, 22);
            this.btnCamembert.Text = "Camembert";
            this.btnCamembert.Click += new System.EventHandler(this.btnCamembert_Click);
            // 
            // btnCourbes
            // 
            this.btnCourbes.Image = global::CrediNET.Properties.Resources.chart_line;
            this.btnCourbes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCourbes.Name = "btnCourbes";
            this.btnCourbes.Size = new System.Drawing.Size(137, 22);
            this.btnCourbes.Text = "Courbes";
            this.btnCourbes.Click += new System.EventHandler(this.btnCourbes_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(1057, 508);
            this.Controls.Add(this.lblSoldeAt);
            this.Controls.Add(this.lblSolde);
            this.Controls.Add(this.lvOps);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "MainWindow";
            this.Text = "CrediNET";
            this.Load += new System.EventHandler(this.MainWindow_Load);
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
    }
}

