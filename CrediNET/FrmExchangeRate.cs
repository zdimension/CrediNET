using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrediNET
{
    public partial class FrmExchangeRate : Form
    {
        public FrmExchangeRate()
        {
            InitializeComponent();
            foreach (var ccr in Currencies.All)
            {
                var bt = (Bitmap)CrediNET.CurrencyFlags.ResourceManager.GetObject(ccr.ShortName) ??
                         CurrencyFlags.UNKNOWN;
                cbxDev1.Items.Add(new ImageComboBox.ImageItem(ccr.Name, bt));
                cbxDev2.Items.Add(new ImageComboBox.ImageItem(ccr.Name, bt));
            }
            cbxDev1.SelectedItem = cbxDev1.Items.Cast<ImageComboBox.ImageItem>().First(x => x.Text.Contains("EUR"));
            cbxDev2.SelectedItem = cbxDev2.Items.Cast<ImageComboBox.ImageItem>().First(x => x.Text.Contains("USD"));
        }

        private void btnIntervertir_Click(object sender, EventArgs e)
        {
            var a = cbxDev2.SelectedItem;
            cbxDev2.SelectedItem = cbxDev1.SelectedItem;
            cbxDev1.SelectedItem = a;
        }
    }
}
