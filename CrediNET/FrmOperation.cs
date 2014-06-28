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
    public partial class FrmOperation : Form
    {


        public FrmOperation(Account compte, bool vir = false, bool edit = false, Operation op = null)
        {
            InitializeComponent();

            compte.Budgets.ForEach(x => cbxBudget.Items.Add(x));
            cbxBudget.SelectedIndex = 0;
            Program.Types.ForEach(y => cbxType.Items.Add(y));
            cbxType.SelectedIndex = 0;

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
                cbxBudget.SelectedItem = op.Budget;
                mcDate.SelectionStart = op.Date;
                mcDate.SelectionEnd = op.Date;
                txtComm.Text = op.Commentary;
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
    }
}
