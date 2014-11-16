using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CrediNET.Properties;

namespace CrediNET
{
    public partial class FrmOptions : Form
    {
        public FrmOptions()
        {
            InitializeComponent();

            foreach (var ccr in Currencies.All)
            {
                var bt = (Bitmap)CrediNET.CurrencyFlags.ResourceManager.GetObject(ccr.ShortName) ??
                         CurrencyFlags.UNKNOWN;
                cbxDftCrc.Items.Add(new ImageComboBox.ImageItem(ccr.Name, bt));
            }

            
        }

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            cbxDftCrc.SelectedItem = cbxDftCrc.Items.Cast<ImageComboBox.ImageItem>().First(x => x.Text == Currencies.All.First(y => y.ShortName == Settings.Default.DefaultCurrency).Name);
            if (Settings.Default.Lang.Name == "fr-FR") cbxLng.SelectedIndex = 0;
            if (Settings.Default.Lang.Name == "en-US") cbxLng.SelectedIndex = 1;
            if (Settings.Default.Lang.Name == "de-DE") cbxLng.SelectedIndex = 2;
            if (Settings.Default.Lang.Name == "vi-VN") cbxLng.SelectedIndex = 3;

            nupDecimals_ValueChanged(this, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var cultureName = cbxLng.SelectedItem.ToString().Split('(')[1].Replace(")", "");

            Settings.Default.DefaultCurrency =
                Currencies.All.First(x => x.Name == cbxDftCrc.SelectedItem.Text).ShortName;
            Settings.Default.Lang = (CultureInfo) new CultureInfoConverter().ConvertFromString(cultureName);
            Settings.Default.Save();
        }

        private void cbxSplash_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }

        void checkMods()
        {
            try
            {
                var cultureName = cbxLng.SelectedItem.ToString().Split('(')[1].Replace(")", "");
                if (
                    Settings.Default.Lang != (CultureInfo)new CultureInfoConverter().ConvertFromString(cultureName) ||
                    cbxDftCrc.SelectedItem.Text !=
                    Currencies.All.First(y => y.ShortName == Settings.Default.DefaultCurrency).Name ||
                    cbxUseDashes.Checked != Settings.Default.UseDashes ||
                    nupDecimals.Value != Settings.Default.DecimalPlaces)
                {
                    pbxIcI.Visible = true;
                    lblRestart.Visible = true;
                }
                else
                {
                    pbxIcI.Visible = false;
                    lblRestart.Visible = false;
                }
            }
            catch
            {

            }
        }

        private void nupDecimals_ValueChanged(object sender, EventArgs e)
        {
            lblSample.Text = Math.Round(123.456789123, Convert.ToInt32(nupDecimals.Value)).ToString() + @" " +
                             Currencies.All.First(x => x.Name == cbxDftCrc.SelectedItem.Text).Symbol;
            checkMods();
        }

        private void cbxLng_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkMods();
        }

        private void cbxDftCrc_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkMods();
        }

        private void cbxUseDashes_CheckedChanged(object sender, EventArgs e)
        {
            checkMods();
        }
    }
}