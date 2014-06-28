using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using System.Windows.Forms;

namespace CrediNET
{
    public partial class FrmCreateAccount : Form
    {
        [DllImport("uxtheme.dll")]
        public static extern int SetWindowTheme([In] IntPtr hwnd, [In, MarshalAs(UnmanagedType.LPWStr)] string pszSubAppName, [In, MarshalAs(UnmanagedType.LPWStr)] string pszSubIdList);

        bool edit = false;

        public FrmCreateAccount(Account editCompt = null)
        {
            InitializeComponent();
            Currencies.All.ForEach(x => cbxDevise.Items.Add(x.Name));
            if(editCompt != null)
            {
                edit = true;
                txtNom.Text = editCompt.Name;

                lbxBudgets.Items.Clear();

                editCompt.Budgets.ForEach(x => lbxBudgets.Items.Add(x));
                if (editCompt.Currency == null)
                    cbxDevise.SelectedItem = "";
                else
                    cbxDevise.SelectedItem = editCompt.Currency.Name;

                txtPasse_Leave(this, EventArgs.Empty);
            }
            else
            {
                edit = false;
            }
            SetWindowTheme(lbxBudgets.Handle, "Explorer", null);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbxBudgets.SelectedItems.Count == 0)
            {
                btnAdd.Enabled = true;

                if(!removing)
                    txtItemName.Text = "";
                btnRemB.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = false;
                btnRemB.Enabled = true;

                if(!removing)
                    txtItemName.Text = lbxBudgets.SelectedItem.ToString();
            }
        }

        private void FrmCreerCompte_Load(object sender, EventArgs e)
        {
            //Devises.All.ForEach(x => cbxDevise.Items.Add(x.Nom));
        }

        private void btnRemB_Click(object sender, EventArgs e)
        {
            if (lbxBudgets.SelectedItems.Count == 0)
                return;

            lbxBudgets.Items.Remove(lbxBudgets.SelectedItem);

            if (lbxBudgets.SelectedItems.Count == 1)
                btnRemB.Enabled = false;
        }

        private void txtPasse_Enter(object sender, EventArgs e)
        {
            if (txtPasse.Font.Italic && edit)
            {
                txtPasse.Text = "";
                txtPasse.Font = new Font(txtPasse.Font, FontStyle.Regular);
                txtPasse.UseSystemPasswordChar = true;
            }
        }

        private void txtPasse_Leave(object sender, EventArgs e)
        {
            if(txtPasse.Text == "" && edit)
            {
                switch (CrediNET.Properties.Settings.Default.Lang.Name)
                {
                    case "en-US":
                        txtPasse.Text = "Leave this field empty to keep current password";
                        break;
                    default:        //case "fr-FR":
                        txtPasse.Text = "Laissez ce champ vide pour ne pas modifier le code";
                        break;
                }

                txtPasse.Font = new Font(txtPasse.Font, FontStyle.Italic);
                txtPasse.UseSystemPasswordChar = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!lbxBudgets.Items.Contains(txtItemName.Text))
                lbxBudgets.Items.Add(txtItemName.Text);

            txtItemName.Text = "";
        }

        bool removing = false;


        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (lbxBudgets.SelectedItems.Count == 0) return;

            if (txtItemName.Text != lbxBudgets.SelectedItem.ToString())
            {

                int index = lbxBudgets.SelectedIndex;
                string s = txtItemName.Text;
                removing = true;

                lbxBudgets.Items.RemoveAt(index);
                lbxBudgets.Items.Insert(index, txtItemName.Text);

                removing = false;

                lbxBudgets.SetSelected(lbxBudgets.Items.IndexOf(s), true); 
            }
        }

        private void FrmCreateAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (cbxDevise.SelectedItem == null)
                {
                    e.Cancel = true;
                    errorProvider.SetError(cbxDevise, "!");
                }
            }
        }

        private void cbxDevise_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(cbxDevise, null);
        }

    }
}
