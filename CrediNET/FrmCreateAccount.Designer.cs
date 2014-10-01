namespace CrediNET
{
    partial class FrmCreateAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateAccount));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPasse = new System.Windows.Forms.TextBox();
            this.cbxCrypt = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbxBudgets = new CrediNET.DoubleBufferListView();
            this.clmnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDevise = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemB = new System.Windows.Forms.Button();
            this.cbxClr = new CrediNET.ColorComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtNom
            // 
            resources.ApplyResources(this.txtNom, "txtNom");
            this.txtNom.Name = "txtNom";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtPasse
            // 
            resources.ApplyResources(this.txtPasse, "txtPasse");
            this.txtPasse.Name = "txtPasse";
            this.txtPasse.UseSystemPasswordChar = true;
            this.txtPasse.Enter += new System.EventHandler(this.txtPasse_Enter);
            this.txtPasse.Leave += new System.EventHandler(this.txtPasse_Leave);
            // 
            // cbxCrypt
            // 
            resources.ApplyResources(this.cbxCrypt, "cbxCrypt");
            this.cbxCrypt.Name = "cbxCrypt";
            this.cbxCrypt.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbxBudgets
            // 
            this.lbxBudgets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnName});
            this.lbxBudgets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lbxBudgets.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lbxBudgets.Items"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lbxBudgets.Items1"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lbxBudgets.Items2"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lbxBudgets.Items3"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lbxBudgets.Items4"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("lbxBudgets.Items5")))});
            resources.ApplyResources(this.lbxBudgets, "lbxBudgets");
            this.lbxBudgets.MultiSelect = false;
            this.lbxBudgets.Name = "lbxBudgets";
            this.lbxBudgets.UseCompatibleStateImageBehavior = false;
            this.lbxBudgets.View = System.Windows.Forms.View.Details;
            this.lbxBudgets.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // clmnName
            // 
            resources.ApplyResources(this.clmnName, "clmnName");
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtItemName
            // 
            resources.ApplyResources(this.txtItemName, "txtItemName");
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cbxDevise
            // 
            this.cbxDevise.FormattingEnabled = true;
            resources.ApplyResources(this.cbxDevise, "cbxDevise");
            this.cbxDevise.Name = "cbxDevise";
            this.cbxDevise.SelectedIndexChanged += new System.EventHandler(this.cbxDevise_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::CrediNET.Properties.Resources.add;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemB
            // 
            resources.ApplyResources(this.btnRemB, "btnRemB");
            this.btnRemB.Image = global::CrediNET.Properties.Resources.delete;
            this.btnRemB.Name = "btnRemB";
            this.btnRemB.UseVisualStyleBackColor = true;
            this.btnRemB.Click += new System.EventHandler(this.btnRemB_Click);
            // 
            // cbxClr
            // 
            this.cbxClr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxClr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClr.FormattingEnabled = true;
            resources.ApplyResources(this.cbxClr, "cbxClr");
            this.cbxClr.Name = "cbxClr";
            this.cbxClr.SelectedItem = null;
            this.cbxClr.SelectedValue = System.Drawing.Color.White;
            this.cbxClr.SelectedIndexChanged += new System.EventHandler(this.cbxClr_SelectedIndexChanged);
            // 
            // FrmCreateAccount
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.cbxClr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxDevise);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtItemName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemB);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbxBudgets);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbxCrypt);
            this.Controls.Add(this.txtPasse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCreateAccount";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCreateAccount_FormClosing);
            this.Load += new System.EventHandler(this.FrmCreerCompte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPasse;
        public System.Windows.Forms.CheckBox cbxCrypt;
        private System.Windows.Forms.Button btnCancel;
        public DoubleBufferListView lbxBudgets;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnRemB;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbxDevise;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private ColorComboBox cbxClr;
        private System.Windows.Forms.ColumnHeader clmnName;
    }
}