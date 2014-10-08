﻿namespace CrediNET
{
    partial class FrmReminderOperation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReminderOperation));
            this.mcDate = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComm = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCmptSpc = new System.Windows.Forms.Button();
            this.btnVirCaC = new System.Windows.Forms.Button();
            this.ofpCompte = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.nudNbOfRepetitions = new System.Windows.Forms.NumericUpDown();
            this.cbxRepetitionType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mupCredit = new CrediNET.MoneyUpDown();
            this.mupDebit = new CrediNET.MoneyUpDown();
            this.cbxBudget = new CrediNET.ColorComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudNbOfRepetitions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mupCredit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mupDebit)).BeginInit();
            this.SuspendLayout();
            // 
            // mcDate
            // 
            resources.ApplyResources(this.mcDate, "mcDate");
            this.mcDate.MaxSelectionCount = 1;
            this.mcDate.Name = "mcDate";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbxType
            // 
            resources.ApplyResources(this.cbxType, "cbxType");
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Name = "cbxType";
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtComm
            // 
            resources.ApplyResources(this.txtComm, "txtComm");
            this.txtComm.Name = "txtComm";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCmptSpc
            // 
            resources.ApplyResources(this.btnCmptSpc, "btnCmptSpc");
            this.btnCmptSpc.Name = "btnCmptSpc";
            this.btnCmptSpc.UseVisualStyleBackColor = true;
            this.btnCmptSpc.Click += new System.EventHandler(this.btnCmptSpc_Click);
            // 
            // btnVirCaC
            // 
            resources.ApplyResources(this.btnVirCaC, "btnVirCaC");
            this.btnVirCaC.Name = "btnVirCaC";
            this.btnVirCaC.UseVisualStyleBackColor = true;
            // 
            // ofpCompte
            // 
            this.ofpCompte.DefaultExt = "cna";
            resources.ApplyResources(this.ofpCompte, "ofpCompte");
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // nudNbOfRepetitions
            // 
            resources.ApplyResources(this.nudNbOfRepetitions, "nudNbOfRepetitions");
            this.nudNbOfRepetitions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNbOfRepetitions.Name = "nudNbOfRepetitions";
            this.nudNbOfRepetitions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbxRepetitionType
            // 
            resources.ApplyResources(this.cbxRepetitionType, "cbxRepetitionType");
            this.cbxRepetitionType.FormattingEnabled = true;
            this.cbxRepetitionType.Items.AddRange(new object[] {
            resources.GetString("cbxRepetitionType.Items"),
            resources.GetString("cbxRepetitionType.Items1"),
            resources.GetString("cbxRepetitionType.Items2"),
            resources.GetString("cbxRepetitionType.Items3"),
            resources.GetString("cbxRepetitionType.Items4"),
            resources.GetString("cbxRepetitionType.Items5"),
            resources.GetString("cbxRepetitionType.Items6"),
            resources.GetString("cbxRepetitionType.Items7"),
            resources.GetString("cbxRepetitionType.Items8"),
            resources.GetString("cbxRepetitionType.Items9"),
            resources.GetString("cbxRepetitionType.Items10")});
            this.cbxRepetitionType.Name = "cbxRepetitionType";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // mupCredit
            // 
            resources.ApplyResources(this.mupCredit, "mupCredit");
            this.mupCredit.DecimalPlaces = 2;
            this.mupCredit.Devise = "€";
            this.mupCredit.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupCredit.Name = "mupCredit";
            // 
            // mupDebit
            // 
            resources.ApplyResources(this.mupDebit, "mupDebit");
            this.mupDebit.DecimalPlaces = 2;
            this.mupDebit.Devise = "€";
            this.mupDebit.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mupDebit.Name = "mupDebit";
            // 
            // cbxBudget
            // 
            resources.ApplyResources(this.cbxBudget, "cbxBudget");
            this.cbxBudget.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxBudget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBudget.FormattingEnabled = true;
            this.cbxBudget.Name = "cbxBudget";
            this.cbxBudget.SelectedItem = null;
            this.cbxBudget.SelectedValue = System.Drawing.Color.White;
            // 
            // FrmReminderOperation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.cbxRepetitionType);
            this.Controls.Add(this.nudNbOfRepetitions);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
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
            this.Name = "FrmReminderOperation";
            ((System.ComponentModel.ISupportInitialize)(this.nudNbOfRepetitions)).EndInit();
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
        public ColorComboBox cbxBudget;
        public System.Windows.Forms.TextBox txtComm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCmptSpc;
        private System.Windows.Forms.Button btnVirCaC;
        private System.Windows.Forms.OpenFileDialog ofpCompte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown nudNbOfRepetitions;
        public System.Windows.Forms.ComboBox cbxRepetitionType;

    }
}