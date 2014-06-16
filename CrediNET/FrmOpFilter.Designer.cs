namespace CrediNET
{
    partial class FrmOpFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpFilter));
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFCmn = new System.Windows.Forms.ComboBox();
            this.cbxFType = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.coolTabControl1 = new CrediNET.CoolTabControl();
            this.tbpC = new System.Windows.Forms.TabPage();
            this.mupC = new CrediNET.MoneyUpDown();
            this.tbpD = new System.Windows.Forms.TabPage();
            this.mupDb = new CrediNET.MoneyUpDown();
            this.tbpDa = new System.Windows.Forms.TabPage();
            this.dtpM = new System.Windows.Forms.DateTimePicker();
            this.coolTabControl1.SuspendLayout();
            this.tbpC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mupC)).BeginInit();
            this.tbpD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mupDb)).BeginInit();
            this.tbpDa.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbxFCmn
            // 
            resources.ApplyResources(this.cbxFCmn, "cbxFCmn");
            this.cbxFCmn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFCmn.FormattingEnabled = true;
            this.cbxFCmn.Items.AddRange(new object[] {
            resources.GetString("cbxFCmn.Items"),
            resources.GetString("cbxFCmn.Items1"),
            resources.GetString("cbxFCmn.Items2")});
            this.cbxFCmn.Name = "cbxFCmn";
            this.cbxFCmn.SelectedIndexChanged += new System.EventHandler(this.cbxFCmn_SelectedIndexChanged);
            // 
            // cbxFType
            // 
            resources.ApplyResources(this.cbxFType, "cbxFType");
            this.cbxFType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFType.FormattingEnabled = true;
            this.cbxFType.Items.AddRange(new object[] {
            resources.GetString("cbxFType.Items"),
            resources.GetString("cbxFType.Items1"),
            resources.GetString("cbxFType.Items2")});
            this.cbxFType.Name = "cbxFType";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // coolTabControl1
            // 
            resources.ApplyResources(this.coolTabControl1, "coolTabControl1");
            this.coolTabControl1.Controls.Add(this.tbpC);
            this.coolTabControl1.Controls.Add(this.tbpD);
            this.coolTabControl1.Controls.Add(this.tbpDa);
            this.coolTabControl1.Name = "coolTabControl1";
            this.coolTabControl1.SelectedIndex = 0;
            // 
            // tbpC
            // 
            resources.ApplyResources(this.tbpC, "tbpC");
            this.tbpC.BackColor = System.Drawing.SystemColors.Control;
            this.tbpC.Controls.Add(this.mupC);
            this.tbpC.Name = "tbpC";
            // 
            // mupC
            // 
            resources.ApplyResources(this.mupC, "mupC");
            this.mupC.DecimalPlaces = 2;
            this.mupC.Devise = "€";
            this.mupC.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupC.Name = "mupC";
            // 
            // tbpD
            // 
            resources.ApplyResources(this.tbpD, "tbpD");
            this.tbpD.BackColor = System.Drawing.SystemColors.Control;
            this.tbpD.Controls.Add(this.mupDb);
            this.tbpD.Name = "tbpD";
            // 
            // mupDb
            // 
            resources.ApplyResources(this.mupDb, "mupDb");
            this.mupDb.DecimalPlaces = 2;
            this.mupDb.Devise = "€";
            this.mupDb.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupDb.Name = "mupDb";
            // 
            // tbpDa
            // 
            resources.ApplyResources(this.tbpDa, "tbpDa");
            this.tbpDa.BackColor = System.Drawing.SystemColors.Control;
            this.tbpDa.Controls.Add(this.dtpM);
            this.tbpDa.Name = "tbpDa";
            // 
            // dtpM
            // 
            resources.ApplyResources(this.dtpM, "dtpM");
            this.dtpM.Name = "dtpM";
            // 
            // FrmOpFilter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.coolTabControl1);
            this.Controls.Add(this.cbxFType);
            this.Controls.Add(this.cbxFCmn);
            this.Controls.Add(this.label1);
            this.Name = "FrmOpFilter";
            this.Load += new System.EventHandler(this.FrmOpFilter_Load);
            this.coolTabControl1.ResumeLayout(false);
            this.tbpC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mupC)).EndInit();
            this.tbpD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mupDb)).EndInit();
            this.tbpDa.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFCmn;
        private System.Windows.Forms.ComboBox cbxFType;
        private CoolTabControl coolTabControl1;
        private System.Windows.Forms.TabPage tbpC;
        private MoneyUpDown mupC;
        private System.Windows.Forms.TabPage tbpD;
        private MoneyUpDown mupDb;
        private System.Windows.Forms.TabPage tbpDa;
        private System.Windows.Forms.DateTimePicker dtpM;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}