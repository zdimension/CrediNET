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
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pour filtrer les opérations, sélectionnez un critère ci-dessous :";
            // 
            // cbxFCmn
            // 
            this.cbxFCmn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFCmn.FormattingEnabled = true;
            this.cbxFCmn.Items.AddRange(new object[] {
            "Crédit",
            "Débit",
            "Date"});
            this.cbxFCmn.Location = new System.Drawing.Point(12, 39);
            this.cbxFCmn.Name = "cbxFCmn";
            this.cbxFCmn.Size = new System.Drawing.Size(121, 23);
            this.cbxFCmn.TabIndex = 1;
            this.cbxFCmn.SelectedIndexChanged += new System.EventHandler(this.cbxFCmn_SelectedIndexChanged);
            // 
            // cbxFType
            // 
            this.cbxFType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFType.FormattingEnabled = true;
            this.cbxFType.Items.AddRange(new object[] {
            "est inférieur à",
            "est égal à",
            "est supérieur à"});
            this.cbxFType.Location = new System.Drawing.Point(139, 39);
            this.cbxFType.Name = "cbxFType";
            this.cbxFType.Size = new System.Drawing.Size(121, 23);
            this.cbxFType.TabIndex = 2;
            // 
            // coolTabControl1
            // 
            this.coolTabControl1.Controls.Add(this.tbpC);
            this.coolTabControl1.Controls.Add(this.tbpD);
            this.coolTabControl1.Controls.Add(this.tbpDa);
            this.coolTabControl1.Location = new System.Drawing.Point(266, 39);
            this.coolTabControl1.Name = "coolTabControl1";
            this.coolTabControl1.SelectedIndex = 0;
            this.coolTabControl1.Size = new System.Drawing.Size(241, 51);
            this.coolTabControl1.TabIndex = 3;
            // 
            // tbpC
            // 
            this.tbpC.BackColor = System.Drawing.SystemColors.Control;
            this.tbpC.Controls.Add(this.mupC);
            this.tbpC.Location = new System.Drawing.Point(4, 24);
            this.tbpC.Name = "tbpC";
            this.tbpC.Padding = new System.Windows.Forms.Padding(3);
            this.tbpC.Size = new System.Drawing.Size(233, 23);
            this.tbpC.TabIndex = 0;
            this.tbpC.Text = "tabPage1";
            // 
            // mupC
            // 
            this.mupC.DecimalPlaces = 2;
            this.mupC.Devise = "€";
            this.mupC.Location = new System.Drawing.Point(0, 0);
            this.mupC.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupC.Name = "mupC";
            this.mupC.Size = new System.Drawing.Size(233, 23);
            this.mupC.TabIndex = 0;
            // 
            // tbpD
            // 
            this.tbpD.BackColor = System.Drawing.SystemColors.Control;
            this.tbpD.Controls.Add(this.mupDb);
            this.tbpD.Location = new System.Drawing.Point(4, 24);
            this.tbpD.Name = "tbpD";
            this.tbpD.Padding = new System.Windows.Forms.Padding(3);
            this.tbpD.Size = new System.Drawing.Size(233, 23);
            this.tbpD.TabIndex = 1;
            this.tbpD.Text = "tabPage2";
            // 
            // mupDb
            // 
            this.mupDb.DecimalPlaces = 2;
            this.mupDb.Devise = "€";
            this.mupDb.Location = new System.Drawing.Point(0, 0);
            this.mupDb.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupDb.Name = "mupDb";
            this.mupDb.Size = new System.Drawing.Size(233, 23);
            this.mupDb.TabIndex = 0;
            // 
            // tbpDa
            // 
            this.tbpDa.BackColor = System.Drawing.SystemColors.Control;
            this.tbpDa.Controls.Add(this.dtpM);
            this.tbpDa.Location = new System.Drawing.Point(4, 24);
            this.tbpDa.Name = "tbpDa";
            this.tbpDa.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDa.Size = new System.Drawing.Size(233, 23);
            this.tbpDa.TabIndex = 2;
            this.tbpDa.Text = "tabPage1";
            // 
            // dtpM
            // 
            this.dtpM.Location = new System.Drawing.Point(0, 0);
            this.dtpM.Name = "dtpM";
            this.dtpM.Size = new System.Drawing.Size(233, 23);
            this.dtpM.TabIndex = 0;
            // 
            // FrmOpFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            resources.ApplyResources(this, "$this");
            this.ClientSize = new System.Drawing.Size(519, 127);
            this.ControlBox = false;
            this.Controls.Add(this.coolTabControl1);
            this.Controls.Add(this.cbxFType);
            this.Controls.Add(this.cbxFCmn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmOpFilter";
            this.Text = "Filtrer";
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
    }
}