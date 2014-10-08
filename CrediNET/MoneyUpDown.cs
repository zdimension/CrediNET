using System;
using System.Windows.Forms;

namespace CrediNET
{
    public class MoneyUpDown : NumericUpDown
    {
        private void InitializeComponent()
        {
            this.TextChanged += new System.EventHandler(this.textChanged);
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
            this.Text = this.Value.ToString() + " " + Devise;
        }
    }
}