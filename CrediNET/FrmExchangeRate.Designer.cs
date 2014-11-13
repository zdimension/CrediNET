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
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mupFrom = new CrediNET.MoneyUpDown();
            this.cbxDev1 = new CrediNET.ImageComboBox();
            this.btnIntervertir = new System.Windows.Forms.Button();
            this.mupTarget = new CrediNET.MoneyUpDown();
            this.cbxDev2 = new CrediNET.ImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mupFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mupTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(392, 100);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Fermer";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(446, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Saisissez une valeur, puis sélectionnez la monnaie de départ et la monnaie d\'arri" +
    "vée.";
            // 
            // mupFrom
            // 
            this.mupFrom.DecimalPlaces = 2;
            this.mupFrom.Devise = "€";
            this.mupFrom.Location = new System.Drawing.Point(12, 42);
            this.mupFrom.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupFrom.Name = "mupFrom";
            this.mupFrom.Size = new System.Drawing.Size(120, 23);
            this.mupFrom.TabIndex = 2;
            // 
            // cbxDev1
            // 
            this.cbxDev1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxDev1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDev1.FormattingEnabled = true;
            this.cbxDev1.Location = new System.Drawing.Point(12, 71);
            this.cbxDev1.Name = "cbxDev1";
            this.cbxDev1.SelectedItem = null;
            this.cbxDev1.Size = new System.Drawing.Size(120, 24);
            this.cbxDev1.TabIndex = 3;
            // 
            // btnIntervertir
            // 
            this.btnIntervertir.Location = new System.Drawing.Point(138, 41);
            this.btnIntervertir.Name = "btnIntervertir";
            this.btnIntervertir.Size = new System.Drawing.Size(202, 25);
            this.btnIntervertir.TabIndex = 4;
            this.btnIntervertir.Text = "<->";
            this.btnIntervertir.UseVisualStyleBackColor = true;
            this.btnIntervertir.Click += new System.EventHandler(this.btnIntervertir_Click);
            // 
            // mupTarget
            // 
            this.mupTarget.DecimalPlaces = 2;
            this.mupTarget.Devise = "$";
            this.mupTarget.Location = new System.Drawing.Point(346, 42);
            this.mupTarget.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupTarget.Name = "mupTarget";
            this.mupTarget.ReadOnly = true;
            this.mupTarget.Size = new System.Drawing.Size(120, 23);
            this.mupTarget.TabIndex = 2;
            // 
            // cbxDev2
            // 
            this.cbxDev2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxDev2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDev2.FormattingEnabled = true;
            this.cbxDev2.Location = new System.Drawing.Point(346, 71);
            this.cbxDev2.Name = "cbxDev2";
            this.cbxDev2.SelectedItem = null;
            this.cbxDev2.Size = new System.Drawing.Size(120, 24);
            this.cbxDev2.TabIndex = 3;
            // 
            // FrmExchangeRate
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 134);
            this.Controls.Add(this.btnIntervertir);
            this.Controls.Add(this.cbxDev2);
            this.Controls.Add(this.cbxDev1);
            this.Controls.Add(this.mupTarget);
            this.Controls.Add(this.mupFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExchangeRate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convertisseur de monnaies";
            ((System.ComponentModel.ISupportInitialize)(this.mupFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mupTarget)).EndInit();
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