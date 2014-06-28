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
    public partial class FrmOpFilter : Form
    {
        public FrmOpFilter()
        {
            InitializeComponent();
        }

        public OpFilter ResultFilter
        {
            get
            {
                return new OpFilter() { Type = (OpFilterType)cbxFCmn.SelectedIndex, Order = (OpFilterOrder)cbxFType.SelectedIndex, Value = cbxFCmn.SelectedIndex == 0 ? mupC.Value : (object)(cbxFCmn.SelectedIndex == 1 ? (object)mupDb.Value : (object)dtpM.Value) };
            }
        }

        private void FrmOpFilter_Load(object sender, EventArgs e)
        {
            cbxFCmn.SelectedIndex = 0;
            cbxFType.SelectedIndex = 0;
        }

        private void cbxFCmn_SelectedIndexChanged(object sender, EventArgs e)
        {
            coolTabControl1.SelectTab(cbxFCmn.SelectedIndex);
        }
    }

    public struct OpFilter
    {
        public OpFilterType Type { get; set; }

        public OpFilterOrder Order { get; set; }

        public object Value { get; set; }
    }

    public enum OpFilterType
    {
        Credit = 1,
        Debit = 2,
        Date = 4
    }

    public enum OpFilterOrder
    {
        Inf = 1,
        Equal = 2,
        Sup = 3
    }
}
