using System;
using System.Windows.Forms;

namespace CrediNET
{
    public class MoneyUpDown : NumericUpDown
    {
        private void InitializeComponent()
        {
            TextChanged += new EventHandler(textChanged);
        }

        private void textChanged(object sender, EventArgs e)
        {
            try
            {
                Value = decimal.Parse(Text.Replace(Devise, "").Trim());
            }
            catch
            {
                base.UpdateEditText();
            }
        }

        public MoneyUpDown()
        {
            InitializeComponent();
            Maximum = 999999999999;
            DecimalPlaces = 2;
        }

        private string _dev = "€";

        public string Devise
        {
            get { return _dev; }
            set { _dev = value; UpdateEditText(); }
        }

        protected override void UpdateEditText()
        {
            Text = Value.ToString() + " " + Devise;
        }
    }
}