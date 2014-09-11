﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CrediNET
{
    public partial class FrmOpFilter : Form
    {
        private Account compte;
        public FrmOpFilter(Account CompteActuel)
        {
            this.compte = CompteActuel;
            InitializeComponent();
        }
        private void FrmOpFilter_Load(object sender, EventArgs e)
        {
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
            mudCreditFrom.Enabled = false;
            mudCreditTo.Enabled = false;
            mudDebitFrom.Enabled = false;
            mudDebitTo.Enabled = false;
            cbxType.Enabled = false;
            cbxBudget.Enabled = false;

            //Load operation budgets to cbxType
            compte.Budgets.ForEach(x => cbxBudget.Items.Add(x));
            cbxBudget.SelectedIndex = 0;

            //Load operation types to cbxType
            Program.Types.ForEach(y => cbxType.Items.Add(y));
            cbxType.SelectedIndex = 0;
        }

        private void chbDate_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == false)
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
            }
            else
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
            }
        }

        private void chbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == false)
            {
                dtpFrom.Enabled = false;
                dtpTo.Enabled = false;
                mudCreditFrom.Enabled = false;
                mudCreditTo.Enabled = false;
                mudDebitFrom.Enabled = false;
                mudDebitTo.Enabled = false;
                cbxType.Enabled = false;
                cbxBudget.Enabled = false;
                chbDate.Checked = false;
                chbCredit.Checked = false;
                chbDebit.Checked = false;
                chbType.Checked = false;
                chbBudget.Checked = false;
            }
            else
            {
                dtpFrom.Enabled = true;
                dtpTo.Enabled = true;
                mudCreditFrom.Enabled = true;
                mudCreditTo.Enabled = true;
                mudDebitFrom.Enabled = true;
                mudDebitTo.Enabled = true;
                cbxType.Enabled = true;
                cbxBudget.Enabled = true;
                chbDate.Checked = true;
                chbCredit.Checked = true;
                chbDebit.Checked = true;
                chbType.Checked = true;
                chbBudget.Checked = true;
            }
        }

        private void chbCredit_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == false)
            {
                mudCreditFrom.Enabled = false;
                mudCreditTo.Enabled = false;
            }
            else
            {
                mudCreditFrom.Enabled = true;
                mudCreditTo.Enabled = true;
            }
        }

        private void chbDebit_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == false)
            {
                mudDebitFrom.Enabled = false;
                mudDebitTo.Enabled = false;
            }
            else
            {
                mudDebitFrom.Enabled = true;
                mudDebitTo.Enabled = true;
            }
        }

        private void chbType_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == false)
            {
                cbxType.Enabled = false;
            }
            else
            {
                cbxType.Enabled = true;
            }
        }

        private void chbBudget_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == false)
            {
                cbxBudget.Enabled = false;
            }
            else
            {
                cbxBudget.Enabled = true;
            }
        }
    }
}
