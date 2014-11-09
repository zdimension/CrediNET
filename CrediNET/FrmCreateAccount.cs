using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CrediNET.Languages;
using CrediNET.Properties;

namespace CrediNET
{
    public partial class FrmCreateAccount : Form
    {
        [DllImport("uxtheme.dll")]
        public static extern int SetWindowTheme([In] IntPtr hwnd,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszSubAppName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszSubIdList);

        private bool edit;

        public FrmCreateAccount(Account editCompt = null)
        {
            InitializeComponent();
            Currencies.All.ForEach(x => cbxDevise.Items.Add(x.Name));
            cbxClr.AddStandardColors();
            if (editCompt != null)
            {
                edit = true;
                txtNom.Text = editCompt.Name;

                lbxBudgets.Items.Clear();

                editCompt.Budgets.All(x =>
                {
                    lbxBudgets.Items.Add(new ListViewItem {Text = x.Key, BackColor = x.Value});
                    return true;
                });
                cbxDevise.SelectedItem = editCompt.Currency == null ? "" : editCompt.Currency.Name;

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
            if (lbxBudgets.SelectedItems.Count == 0)
            {
                btnAdd.Enabled = true;

                if (!removing)
                {
                    txtItemName.Text = "";
                    cbxClr.SelectedValue = Color.White;
                }

                btnRemB.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = false;
                btnRemB.Enabled = true;

                if (!removing)
                {
                    txtItemName.Text = lbxBudgets.SelectedItems[0].Text;
                    //cbxClr.SelectedValue = lbxBudgets.SelectedItems[0].BackColor;
                    cbxClr.SelectedItem =
                        cbxClr.Items.OfType<ColorComboBox.ColorInfo>()
                            .First(x => x.Color.ToArgb() == lbxBudgets.SelectedItems[0].BackColor.ToArgb());
                }
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

            lbxBudgets.Items.Remove(lbxBudgets.SelectedItems[0]);

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
            if (txtPasse.Text == "" && edit)
            {
                switch (Settings.Default.Lang.Name)
                {
                    case "en-US":
                        txtPasse.Text = en_US.Account_Creation_LeaveEmpty;
                        break;

                    case "de-DE":
                        txtPasse.Text = de_DE.Account_Creation_LeaveEmpty;
                        break;

                    case "vi-VN":
                        txtPasse.Text = vi_VN.Account_Creation_LeaveEmpty;
                        break;

                    default: //case "fr-FR":
                        txtPasse.Text = fr_FR.Account_Creation_LeaveEmpty;
                        break;
                }

                txtPasse.Font = new Font(txtPasse.Font, FontStyle.Italic);
                txtPasse.UseSystemPasswordChar = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbxBudgets.Items.OfType<ListViewItem>().All(x => x.Text != txtItemName.Text))
                lbxBudgets.Items.Add(new ListViewItem {Text = txtItemName.Text, BackColor = cbxClr.SelectedValue});

            txtItemName.Text = "";
        }

        private bool removing = false;

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (lbxBudgets.SelectedItems.Count == 0) return;

            if (txtItemName.Text != lbxBudgets.SelectedItems[0].Text)
            {
                lbxBudgets.SelectedItems[0].Text = txtItemName.Text;
            }
        }

        private void FrmCreateAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
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

        private void cbxClr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxBudgets.SelectedItems.Count == 0) return;

            if (cbxClr.SelectedValue != lbxBudgets.SelectedItems[0].BackColor)
            {
                lbxBudgets.SelectedItems[0].BackColor = cbxClr.SelectedValue;
            }
        }
    }
}