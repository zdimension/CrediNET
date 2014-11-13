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
            this.moneyUpDown1 = new CrediNET.MoneyUpDown();
            this.cbxDev1 = new CrediNET.ImageComboBox();
            this.btnIntervertir = new System.Windows.Forms.Button();
            this.moneyUpDown2 = new CrediNET.MoneyUpDown();
            this.imageComboBox1 = new CrediNET.ImageComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.moneyUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(391, 245);
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
            // moneyUpDown1
            // 
            this.moneyUpDown1.DecimalPlaces = 2;
            this.moneyUpDown1.Devise = "€";
            this.moneyUpDown1.Location = new System.Drawing.Point(12, 42);
            this.moneyUpDown1.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.moneyUpDown1.Name = "moneyUpDown1";
            this.moneyUpDown1.Size = new System.Drawing.Size(120, 23);
            this.moneyUpDown1.TabIndex = 2;
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
            // 
            // moneyUpDown2
            // 
            this.moneyUpDown2.DecimalPlaces = 2;
            this.moneyUpDown2.Devise = "€";
            this.moneyUpDown2.Location = new System.Drawing.Point(346, 42);
            this.moneyUpDown2.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.moneyUpDown2.Name = "moneyUpDown2";
            this.moneyUpDown2.Size = new System.Drawing.Size(120, 23);
            this.moneyUpDown2.TabIndex = 2;
            // 
            // imageComboBox1
            // 
            this.imageComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.imageComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageComboBox1.FormattingEnabled = true;
            this.imageComboBox1.Location = new System.Drawing.Point(346, 71);
            this.imageComboBox1.Name = "imageComboBox1";
            this.imageComboBox1.SelectedItem = null;
            this.imageComboBox1.Size = new System.Drawing.Size(120, 24);
            this.imageComboBox1.TabIndex = 3;
            // 
            // FrmExchangeRate
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 280);
            this.Controls.Add(this.btnIntervertir);
            this.Controls.Add(this.imageComboBox1);
            this.Controls.Add(this.cbxDev1);
            this.Controls.Add(this.moneyUpDown2);
            this.Controls.Add(this.moneyUpDown1);
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
            ((System.ComponentModel.ISupportInitialize)(this.moneyUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private MoneyUpDown moneyUpDown1;
        private ImageComboBox cbxDev1;
        private System.Windows.Forms.Button btnIntervertir;
        private MoneyUpDown moneyUpDown2;
        private ImageComboBox imageComboBox1;
    }
}