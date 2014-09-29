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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.chbDate = new System.Windows.Forms.CheckBox();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chbCredit = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxBudget = new System.Windows.Forms.ComboBox();
            this.chbBudget = new System.Windows.Forms.CheckBox();
            this.chbType = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chbDebit = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.mudDebitTo = new CrediNET.MoneyUpDown();
            this.mudDebitFrom = new CrediNET.MoneyUpDown();
            this.mudCreditTo = new CrediNET.MoneyUpDown();
            this.mudCreditFrom = new CrediNET.MoneyUpDown();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mudDebitTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudDebitFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudCreditTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudCreditFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            //this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
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
            // dtpFrom
            // 
            resources.ApplyResources(this.dtpFrom, "dtpFrom");
            this.dtpFrom.Name = "dtpFrom";
            // 
            // dtpTo
            // 
            resources.ApplyResources(this.dtpTo, "dtpTo");
            this.dtpTo.Name = "dtpTo";
            // 
            // chbDate
            // 
            resources.ApplyResources(this.chbDate, "chbDate");
            this.chbDate.Name = "chbDate";
            this.chbDate.UseVisualStyleBackColor = true;
            this.chbDate.CheckedChanged += new System.EventHandler(this.chbDate_CheckedChanged);
            // 
            // chbAll
            // 
            resources.ApplyResources(this.chbAll, "chbAll");
            this.chbAll.Name = "chbAll";
            this.chbAll.UseVisualStyleBackColor = true;
            this.chbAll.CheckedChanged += new System.EventHandler(this.chbAll_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Name = "panel1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // chbCredit
            // 
            resources.ApplyResources(this.chbCredit, "chbCredit");
            this.chbCredit.Name = "chbCredit";
            this.chbCredit.UseVisualStyleBackColor = true;
            this.chbCredit.CheckedChanged += new System.EventHandler(this.chbCredit_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.chbBudget, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.chbType, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chbDebit, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chbAll, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chbCredit, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chbDate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel6
            // 
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.cbxBudget);
            this.panel6.Name = "panel6";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // cbxBudget
            // 
            this.cbxBudget.FormattingEnabled = true;
            resources.ApplyResources(this.cbxBudget, "cbxBudget");
            this.cbxBudget.Name = "cbxBudget";
            // 
            // chbBudget
            // 
            resources.ApplyResources(this.chbBudget, "chbBudget");
            this.chbBudget.Name = "chbBudget";
            this.chbBudget.UseVisualStyleBackColor = true;
            this.chbBudget.CheckedChanged += new System.EventHandler(this.chbBudget_CheckedChanged);
            // 
            // chbType
            // 
            resources.ApplyResources(this.chbType, "chbType");
            this.chbType.Name = "chbType";
            this.chbType.UseVisualStyleBackColor = true;
            this.chbType.CheckedChanged += new System.EventHandler(this.chbType_CheckedChanged);
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.mudDebitTo);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.mudDebitFrom);
            this.panel4.Name = "panel4";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // chbDebit
            // 
            resources.ApplyResources(this.chbDebit, "chbDebit");
            this.chbDebit.Name = "chbDebit";
            this.chbDebit.UseVisualStyleBackColor = true;
            this.chbDebit.CheckedChanged += new System.EventHandler(this.chbDebit_CheckedChanged);
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.mudCreditTo);
            this.panel3.Controls.Add(this.mudCreditFrom);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Name = "panel3";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.cbxType);
            this.panel5.Name = "panel5";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            resources.ApplyResources(this.cbxType, "cbxType");
            this.cbxType.Name = "cbxType";
            // 
            // mudDebitTo
            // 
            this.mudDebitTo.DecimalPlaces = 2;
            this.mudDebitTo.Devise = "€";
            resources.ApplyResources(this.mudDebitTo, "mudDebitTo");
            this.mudDebitTo.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mudDebitTo.Name = "mudDebitTo";
            // 
            // mudDebitFrom
            // 
            this.mudDebitFrom.DecimalPlaces = 2;
            this.mudDebitFrom.Devise = "€";
            resources.ApplyResources(this.mudDebitFrom, "mudDebitFrom");
            this.mudDebitFrom.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mudDebitFrom.Name = "mudDebitFrom";
            // 
            // mudCreditTo
            // 
            this.mudCreditTo.DecimalPlaces = 2;
            this.mudCreditTo.Devise = "€";
            resources.ApplyResources(this.mudCreditTo, "mudCreditTo");
            this.mudCreditTo.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mudCreditTo.Name = "mudCreditTo";
            // 
            // mudCreditFrom
            // 
            this.mudCreditFrom.DecimalPlaces = 2;
            this.mudCreditFrom.Devise = "€";
            resources.ApplyResources(this.mudCreditFrom, "mudCreditFrom");
            this.mudCreditFrom.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.mudCreditFrom.Name = "mudCreditFrom";
            // 
            // FrmOpFilter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Name = "FrmOpFilter";
            this.Load += new System.EventHandler(this.FrmOpFilter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mudDebitTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudDebitFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudCreditTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mudCreditFrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DateTimePicker dtpFrom;
        public System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.CheckBox chbAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        public MoneyUpDown mudCreditFrom;
        public MoneyUpDown mudCreditTo;
        public MoneyUpDown mudDebitTo;
        public MoneyUpDown mudDebitFrom;
        public System.Windows.Forms.ComboBox cbxType;
        public System.Windows.Forms.ComboBox cbxBudget;
        public System.Windows.Forms.CheckBox chbDate;
        public System.Windows.Forms.CheckBox chbCredit;
        public System.Windows.Forms.CheckBox chbDebit;
        public System.Windows.Forms.CheckBox chbType;
        public System.Windows.Forms.CheckBox chbBudget;
    }
}