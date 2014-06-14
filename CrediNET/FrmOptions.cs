using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
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
            cbxLng.SelectedItem = CrediNET.Properties.Settings.Default.Lang.Name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CrediNET.Properties.Settings.Default.DefaultCurrency = Currencies.All.First(x => x.Name == cbxDftCrc.SelectedItem.ToString()).ShortName;
        }

    }
}
