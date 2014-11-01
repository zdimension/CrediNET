using System;
using System.Linq;
using System.Windows.Forms;

namespace CrediNET
{
    public partial class FrmOperation : Form
    {


        public FrmOperation(Account compte, bool vir = false, bool edit = false, Operation op = null)
        {
            InitializeComponent();

            compte.Budgets.All(x => { cbxBudget.Items.Add(new ColorComboBox.ColorInfo(x.Key, x.Value)); return true; });
            cbxBudget.SelectedIndex = 0;
            Program.Types.ForEach(y => cbxType.Items.Add(y));
            cbxType.SelectedIndex = 0;

            if(vir)
            {
                cbxType.SelectedItem = "VIR";
                cbxType.Enabled = false;
            }

            if (edit)
                Text = "Éditer l'opération";

            if (op == null) return;
            cbxType.SelectedItem = op.Type;
            mupCredit.Value = op.Credit;
            mupDebit.Value = op.Debit;
            cbxBudget.SelectedItem = cbxBudget.Items.OfType<ColorComboBox.ColorInfo>().First(x => x.Text == op.Budget);
            mcDate.SelectionStart = op.Date;
            mcDate.SelectionEnd = op.Date;
            txtComm.Text = op.Commentary;
        }

        private void btnCmptSpc_Click(object sender, EventArgs e)
        {
            var fr = new FrmCountSpcEuro();
            if(fr.ShowDialog() == DialogResult.OK)
            {
                mupCredit.Value = fr.Total;
            }
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnVirCaC.Visible = cbxType.SelectedItem.ToString() == "VIR";
        }
    }
}
