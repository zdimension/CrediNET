﻿using System;
using System.ComponentModel;
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

            Currencies.All.ForEach(x => cbxDftCrc.Items.Add(x.Name));
        }

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            cbxDftCrc.SelectedItem = ((CurrencyObj)(Settings.Default.DefaultCurrency)).Name;
            if (Settings.Default.Lang.Name == "fr-FR") cbxLng.SelectedIndex = 0;
            if (Settings.Default.Lang.Name == "en-US") cbxLng.SelectedIndex = 1;
            if (Settings.Default.Lang.Name == "de-DE") cbxLng.SelectedIndex = 2;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Get CultureInfo Name by its index
            // fr-FR = 0
            // en-US = 1

            /*string cultureName = "";

            switch (cbxLng.SelectedIndex)
            {
                case 0:
                    cultureName = "fr-FR";
                    //MessageBox.Show("Relancez le programme pour appliquer les modifications.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 1:
                    cultureName = "en-US";
                    //MessageBox.Show("Restart the program to apply changes", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }*/

            var cultureName = cbxLng.SelectedItem.ToString().Split('(')[1].Replace(")", "");

            Settings.Default.DefaultCurrency = Currencies.All.First(x => x.Name == cbxDftCrc.SelectedItem.ToString()).ShortName;
            Settings.Default.Lang = (CultureInfo)new CultureInfoConverter().ConvertFromString(cultureName);
            Settings.Default.Save();
        }
    }
}