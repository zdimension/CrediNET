using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CrediNET
{
    public partial class FrmReminderOperation : Form
    {
        public FrmReminderOperation(Account compte, bool vir = false, bool edit = false, ReminderOperation op = null)
        {
            InitializeComponent();

            compte.Budgets.All(x => { cbxBudget.Items.Add(new ColorComboBox.ColorInfo(x.Key, x.Value)); return true; });
            cbxBudget.SelectedIndex = 0;
            Program.Types.ForEach(y => cbxType.Items.Add(y));
            cbxType.SelectedIndex = 0;
            cbxRepetitionType.SelectedIndex = 0;

            if(vir)
            {
                cbxType.SelectedItem = "VIR";
                cbxType.Enabled = false;
            }

            if (edit)
                this.Text = "Éditer l'opération";

            if(op != null)
            {
                cbxType.SelectedItem = op.Type;
                mupCredit.Value = op.Credit;
                mupDebit.Value = op.Debit;
                cbxBudget.SelectedItem = cbxBudget.Items.OfType<ColorComboBox.ColorInfo>().First(x => x.Text == op.Budget);
                mcDate.SelectionStart = op.DueDate;
                mcDate.SelectionEnd = op.DueDate;
                txtComm.Text = op.Commentary;
                nudNbOfRepetitions.Value = op.NbOfRepetition;
                cbxRepetitionType.SelectedIndex = (int)op.RepetitionType;
                cbAddOperations.Checked = op.AutomaticallyAdded;
            }
        }

        private void btnCmptSpc_Click(object sender, EventArgs e)
        {
            var fr = new FrmCountSpcEuro();
            if(fr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mupCredit.Value = fr.Total;
            }
        }

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnVirCaC.Visible = cbxType.SelectedItem.ToString() == "VIR";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
                
        }
    }
}
