namespace CrediNET
{
    partial class FrmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptions));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbxDftCrc = new ImageComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxLng = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.cbxUseDashes = new System.Windows.Forms.CheckBox();
            this.cbxSplash = new System.Windows.Forms.CheckBox();
            this.vsbMain = new System.Windows.Forms.VScrollBar();
            this.panel1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbxDftCrc
            // 
            this.cbxDftCrc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDftCrc.FormattingEnabled = true;
            resources.ApplyResources(this.cbxDftCrc, "cbxDftCrc");
            this.cbxDftCrc.Name = "cbxDftCrc";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cbxLng
            // 
            this.cbxLng.FormattingEnabled = true;
            this.cbxLng.Items.AddRange(new object[] {
            resources.GetString("cbxLng.Items"),
            resources.GetString("cbxLng.Items1"),
            resources.GetString("cbxLng.Items2"),
            resources.GetString("cbxLng.Items3")});
            resources.ApplyResources(this.cbxLng, "cbxLng");
            this.cbxLng.Name = "cbxLng";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.cbxUseDashes);
            this.pnlMain.Controls.Add(this.cbxSplash);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.cbxDftCrc);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.cbxLng);
            resources.ApplyResources(this.pnlMain, "pnlMain");
            this.pnlMain.Name = "pnlMain";
            // 
            // cbxUseDashes
            // 
            resources.ApplyResources(this.cbxUseDashes, "cbxUseDashes");
            this.cbxUseDashes.Checked = global::CrediNET.Properties.Settings.Default.UseDashes;
            this.cbxUseDashes.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CrediNET.Properties.Settings.Default, "UseDashes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxUseDashes.Name = "cbxUseDashes";
            this.cbxUseDashes.UseVisualStyleBackColor = true;
            // 
            // cbxSplash
            // 
            resources.ApplyResources(this.cbxSplash, "cbxSplash");
            this.cbxSplash.Checked = global::CrediNET.Properties.Settings.Default.ShowSplash;
            this.cbxSplash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxSplash.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CrediNET.Properties.Settings.Default, "ShowSplash", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbxSplash.Name = "cbxSplash";
            this.cbxSplash.UseVisualStyleBackColor = true;
            this.cbxSplash.CheckedChanged += new System.EventHandler(this.cbxSplash_CheckedChanged);
            // 
            // vsbMain
            // 
            resources.ApplyResources(this.vsbMain, "vsbMain");
            this.vsbMain.Name = "vsbMain";
            // 
            // FrmOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.vsbMain);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmOptions";
            this.Load += new System.EventHandler(this.FrmOptions_Load);
            this.panel1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private ImageComboBox cbxDftCrc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxLng;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.VScrollBar vsbMain;
        private System.Windows.Forms.CheckBox cbxSplash;
        private System.Windows.Forms.CheckBox cbxUseDashes;

    }
}