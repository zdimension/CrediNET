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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPasse = new System.Windows.Forms.TextBox();
            this.cbxCrypt = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbxBudgets = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemB = new System.Windows.Forms.Button();
            this.cbxDevise = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Afin de créer un compte valide, veuillez remplir les champs ci-dessous.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom :";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(101, 47);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(295, 23);
            this.txtNom.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mot de passe :";
            // 
            // txtPasse
            // 
            this.txtPasse.Location = new System.Drawing.Point(101, 76);
            this.txtPasse.Name = "txtPasse";
            this.txtPasse.Size = new System.Drawing.Size(295, 23);
            this.txtPasse.TabIndex = 4;
            this.txtPasse.UseSystemPasswordChar = true;
            this.txtPasse.Enter += new System.EventHandler(this.txtPasse_Enter);
            this.txtPasse.Leave += new System.EventHandler(this.txtPasse_Leave);
            // 
            // cbxCrypt
            // 
            this.cbxCrypt.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbxCrypt.AutoSize = true;
            this.cbxCrypt.Enabled = false;
            this.cbxCrypt.Location = new System.Drawing.Point(15, 264);
            this.cbxCrypt.Name = "cbxCrypt";
            this.cbxCrypt.Size = new System.Drawing.Size(121, 19);
            this.cbxCrypt.TabIndex = 5;
            this.cbxCrypt.Text = "Crypter le compte";
            this.cbxCrypt.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(321, 281);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbxBudgets
            // 
            this.lbxBudgets.FormattingEnabled = true;
            this.lbxBudgets.ItemHeight = 15;
            this.lbxBudgets.Items.AddRange(new object[] {
            "alimentaire",
            "divers",
            "habitat",
            "salaire",
            "santé",
            "voiture"});
            this.lbxBudgets.Location = new System.Drawing.Point(101, 163);
            this.lbxBudgets.Name = "lbxBudgets";
            this.lbxBudgets.Size = new System.Drawing.Size(295, 94);
            this.lbxBudgets.Sorted = true;
            this.lbxBudgets.TabIndex = 8;
            this.lbxBudgets.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(240, 281);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(130, 134);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(238, 23);
            this.txtItemName.TabIndex = 12;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Budgets :";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::CrediNET.Properties.Resources.add;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(100, 133);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemB
            // 
            this.btnRemB.Enabled = false;
            this.btnRemB.Image = global::CrediNET.Properties.Resources.delete;
            this.btnRemB.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnRemB.Location = new System.Drawing.Point(371, 133);
            this.btnRemB.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemB.Name = "btnRemB";
            this.btnRemB.Size = new System.Drawing.Size(25, 25);
            this.btnRemB.TabIndex = 10;
            this.btnRemB.UseVisualStyleBackColor = true;
            this.btnRemB.Click += new System.EventHandler(this.btnRemB_Click);
            // 
            // cbxDevise
            // 
            this.cbxDevise.FormattingEnabled = true;
            this.cbxDevise.Location = new System.Drawing.Point(101, 105);
            this.cbxDevise.Name = "cbxDevise";
            this.cbxDevise.Size = new System.Drawing.Size(295, 23);
            this.cbxDevise.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Devise :";
            // 
            // FrmCreerCompte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 314);
            this.ControlBox = false;
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
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmCreerCompte";
            this.Text = "Créer un compte";
            this.Load += new System.EventHandler(this.FrmCreerCompte_Load);
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
        public System.Windows.Forms.ListBox lbxBudgets;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnRemB;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cbxDevise;
        private System.Windows.Forms.Label label5;
    }
}