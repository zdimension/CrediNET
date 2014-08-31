using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CrediNET
{
    public class MoneyUpDown : NumericUpDown
    {
        public MoneyUpDown()
        {
            this.Maximum = 999999999999;
            this.DecimalPlaces = 2;
        }

        private string _dev = "€";
        public string Devise
        {
            get { return _dev; }
            set { _dev = value; UpdateEditText(); }
        }

        protected override void UpdateEditText()
        {
            try
            {
                Value = decimal.Parse(Text.Replace(Devise, "").Trim());
            }
            catch
            {
                base.UpdateEditText();
            }
            this.Text = this.Value.ToString() + " " + Devise;
        }
    }
}
