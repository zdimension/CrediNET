namespace CrediNET
{
    partial class FrmExchangeRate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExchangeRate));
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIntervertir = new System.Windows.Forms.Button();
            this.cbxDev2 = new CrediNET.ImageComboBox();
            this.cbxDev1 = new CrediNET.ImageComboBox();
            this.mupTarget = new CrediNET.MoneyUpDown();
            this.mupFrom = new CrediNET.MoneyUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.mupTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mupFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnIntervertir
            // 
            resources.ApplyResources(this.btnIntervertir, "btnIntervertir");
            this.btnIntervertir.Name = "btnIntervertir";
            this.btnIntervertir.UseVisualStyleBackColor = true;
            this.btnIntervertir.Click += new System.EventHandler(this.btnIntervertir_Click);
            // 
            // cbxDev2
            // 
            resources.ApplyResources(this.cbxDev2, "cbxDev2");
            this.cbxDev2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxDev2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDev2.FormattingEnabled = true;
            this.cbxDev2.Name = "cbxDev2";
            this.cbxDev2.SelectedItem = null;
            this.cbxDev2.SelectedIndexChanged += new System.EventHandler(this.cbxDev2_SelectedIndexChanged);
            // 
            // cbxDev1
            // 
            resources.ApplyResources(this.cbxDev1, "cbxDev1");
            this.cbxDev1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxDev1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDev1.FormattingEnabled = true;
            this.cbxDev1.Name = "cbxDev1";
            this.cbxDev1.SelectedItem = null;
            this.cbxDev1.SelectedIndexChanged += new System.EventHandler(this.cbxDev1_SelectedIndexChanged);
            // 
            // mupTarget
            // 
            resources.ApplyResources(this.mupTarget, "mupTarget");
            this.mupTarget.DecimalPlaces = 2;
            this.mupTarget.Devise = "$";
            this.mupTarget.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupTarget.Name = "mupTarget";
            this.mupTarget.ReadOnly = true;
            this.mupTarget.ValueChanged += new System.EventHandler(this.mupTarget_ValueChanged);
            // 
            // mupFrom
            // 
            resources.ApplyResources(this.mupFrom, "mupFrom");
            this.mupFrom.DecimalPlaces = 2;
            this.mupFrom.Devise = "€";
            this.mupFrom.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupFrom.Name = "mupFrom";
            this.mupFrom.ValueChanged += new System.EventHandler(this.mupFrom_ValueChanged);
            // 
            // FrmExchangeRate
            // 
            this.AcceptButton = this.btnClose;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnIntervertir);
            this.Controls.Add(this.cbxDev2);
            this.Controls.Add(this.cbxDev1);
            this.Controls.Add(this.mupTarget);
            this.Controls.Add(this.mupFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExchangeRate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.mupTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mupFrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private MoneyUpDown mupFrom;
        private ImageComboBox cbxDev1;
        private System.Windows.Forms.Button btnIntervertir;
        private MoneyUpDown mupTarget;
        private ImageComboBox cbxDev2;
    }
}