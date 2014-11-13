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
        Dictionary<KeyValuePair<CurrencyObj, CurrencyObj>, decimal> cache = new Dictionary<KeyValuePair<CurrencyObj, CurrencyObj>, decimal>(); 

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
            mupFrom.Value = 1;
        }



        private void btnIntervertir_Click(object sender, EventArgs e)
        {
            var a = cbxDev2.SelectedItem;
            cbxDev2.SelectedItem = cbxDev2.Items.Cast<ImageComboBox.ImageItem>().First(x => x.Text == cbxDev1.SelectedItem.Text);
            cbxDev1.SelectedItem = cbxDev1.Items.Cast<ImageComboBox.ImageItem>().First(x => x.Text == a.Text);
            Do();
        }

        void Do()
        {
            if (cbxDev1.SelectedIndex == -1 || cbxDev2.SelectedIndex == -1) return;
            if (cbxDev1.SelectedItem == cbxDev2.SelectedItem)
            {
                mupTarget.Value = mupFrom.Value;
                return;
            }

            var fromcurrency = Currencies.All.First(x => x.Name == cbxDev1.SelectedItem.Text);
            var tocurrency = Currencies.All.First(x => x.Name == cbxDev2.SelectedItem.Text);

            if (!cache.Any(x => x.Key.Equals(new KeyValuePair<CurrencyObj, CurrencyObj>(fromcurrency, tocurrency))))
            {
                cache[new KeyValuePair<CurrencyObj, CurrencyObj>(fromcurrency, tocurrency)] =
                    (decimal)CurrencyExtensions.ExchangeRate(fromcurrency, tocurrency);
            }
            mupTarget.Value = (decimal)(mupFrom.Value * cache[new KeyValuePair<CurrencyObj, CurrencyObj>(fromcurrency, tocurrency)]);
        }

        private void cbxDev1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mupFrom.Devise = Currencies.All.First(x => x.Name == cbxDev1.SelectedItem.Text).Symbol;
            Do();
        }

        private void cbxDev2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mupTarget.Devise = Currencies.All.First(x => x.Name == cbxDev2.SelectedItem.Text).Symbol;
            Do();
        }

        private void mupFrom_ValueChanged(object sender, EventArgs e)
        {
            Do();
        }

        private void mupTarget_ValueChanged(object sender, EventArgs e)
        {
            Do();
        }
    }
}
