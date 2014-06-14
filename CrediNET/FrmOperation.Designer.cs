namespace CrediNET
{
    partial class FrmOperation
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
            this.mcDate = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mupCredit = new CrediNET.MoneyUpDown();
            this.mupDebit = new CrediNET.MoneyUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxBudget = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComm = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCmptSpc = new System.Windows.Forms.Button();
            this.btnVirCaC = new System.Windows.Forms.Button();
            this.ofpCompte = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mupCredit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mupDebit)).BeginInit();
            this.SuspendLayout();
            // 
            // mcDate
            // 
            this.mcDate.Location = new System.Drawing.Point(216, 5);
            this.mcDate.Margin = new System.Windows.Forms.Padding(0);
            this.mcDate.MaxSelectionCount = 1;
            this.mcDate.Name = "mcDate";
            this.mcDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type :";
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(62, 6);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(150, 23);
            this.cbxType.TabIndex = 2;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Crédit :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Débit :";
            // 
            // mupCredit
            // 
            this.mupCredit.DecimalPlaces = 2;
            this.mupCredit.Devise = "€";
            this.mupCredit.Location = new System.Drawing.Point(62, 35);
            this.mupCredit.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupCredit.Name = "mupCredit";
            this.mupCredit.Size = new System.Drawing.Size(150, 23);
            this.mupCredit.TabIndex = 7;
            // 
            // mupDebit
            // 
            this.mupDebit.DecimalPlaces = 2;
            this.mupDebit.Devise = "€";
            this.mupDebit.Location = new System.Drawing.Point(62, 64);
            this.mupDebit.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupDebit.Name = "mupDebit";
            this.mupDebit.Size = new System.Drawing.Size(150, 23);
            this.mupDebit.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Budget :";
            // 
            // cbxBudget
            // 
            this.cbxBudget.FormattingEnabled = true;
            this.cbxBudget.Location = new System.Drawing.Point(62, 93);
            this.cbxBudget.Name = "cbxBudget";
            this.cbxBudget.Size = new System.Drawing.Size(150, 23);
            this.cbxBudget.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Commentaire :";
            // 
            // txtComm
            // 
            this.txtComm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtComm.Location = new System.Drawing.Point(97, 178);
            this.txtComm.Name = "txtComm";
            this.txtComm.Size = new System.Drawing.Size(346, 23);
            this.txtComm.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(368, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(287, 212);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCmptSpc
            // 
            this.btnCmptSpc.Location = new System.Drawing.Point(8, 122);
            this.btnCmptSpc.Name = "btnCmptSpc";
            this.btnCmptSpc.Size = new System.Drawing.Size(204, 23);
            this.btnCmptSpc.TabIndex = 15;
            this.btnCmptSpc.Text = "Compter espèces";
            this.btnCmptSpc.UseVisualStyleBackColor = true;
            this.btnCmptSpc.Click += new System.EventHandler(this.btnCmptSpc_Click);
            // 
            // btnVirCaC
            // 
            this.btnVirCaC.Location = new System.Drawing.Point(8, 150);
            this.btnVirCaC.Name = "btnVirCaC";
            this.btnVirCaC.Size = new System.Drawing.Size(204, 23);
            this.btnVirCaC.TabIndex = 16;
            this.btnVirCaC.Text = "Virement compte-à-compte";
            this.btnVirCaC.UseVisualStyleBackColor = true;
            this.btnVirCaC.Visible = false;
            // 
            // ofpCompte
            // 
            this.ofpCompte.DefaultExt = "cna";
            this.ofpCompte.Filter = "Compte CrediNET (*.cna, *.cne)|*.cna;*.cne";
            // 
            // FrmOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 245);
            this.ControlBox = false;
            this.Controls.Add(this.btnVirCaC);
            this.Controls.Add(this.btnCmptSpc);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtComm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxBudget);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mupDebit);
            this.Controls.Add(this.mupCredit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mcDate);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmOperation";
            this.Text = "Nouvelle opération";
            ((System.ComponentModel.ISupportInitialize)(this.mupCredit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mupDebit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.MonthCalendar mcDate;

        public System.Windows.Forms.ComboBox cbxType;
        public MoneyUpDown mupCredit;
        public MoneyUpDown mupDebit;
        public System.Windows.Forms.ComboBox cbxBudget;
        public System.Windows.Forms.TextBox txtComm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCmptSpc;
        private System.Windows.Forms.Button btnVirCaC;
        private System.Windows.Forms.OpenFileDialog ofpCompte;

    }
}