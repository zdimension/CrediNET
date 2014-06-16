using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrediNET
{
    public partial class FrmOptions : Form
    {
        ResXResourceWriter resourceWriter;

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        public FrmOptions()
        {
            InitializeComponent();
            
            Currencies.All.ForEach(x => cbxDftCrc.Items.Add(x.Name));
        }

        

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            cbxDftCrc.SelectedItem = ((CurrencyObj)(CrediNET.Properties.Settings.Default.DefaultCurrency)).Name;
            if (CrediNET.Properties.Settings.Default.Lang.Name == "fr-FR") cbxLng.SelectedIndex = 0;
            if (CrediNET.Properties.Settings.Default.Lang.Name == "en-US") cbxLng.SelectedIndex = 1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Get CultureInfo Name by its index
            // fr-FR = 0
            // en-US = 1

            string cultureName = "";

            switch (cbxLng.SelectedIndex)
            {
                case 0:
                    cultureName = "fr-FR";
                    MessageBox.Show("Relancez le programme pour appliquer les modifications.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 1:
                    cultureName = "en-US";
                    MessageBox.Show("Restart the program to apply changes", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }

            CrediNET.Properties.Settings.Default.DefaultCurrency = Currencies.All.First(x => x.Name == cbxDftCrc.SelectedItem.ToString()).ShortName;
            CrediNET.Properties.Settings.Default.Lang = (System.Globalization.CultureInfo)new CultureInfoConverter().ConvertFromString(cultureName);
        
            
        }

    }
}
