using System;
using System.Windows.Forms;

namespace CrediNET
{
    public class MoneyUpDown : NumericUpDown
    {
        private void InitializeComponent()
        {
            //TextChanged += textChanged;
            KeyUp += MoneyUpDown_KeyUp;
            LostFocus += MoneyUpDown_LostFocus;
        }

        void MoneyUpDown_LostFocus(object sender, EventArgs e)
        {
            loadmny();
        }

        void MoneyUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loadmny();
            }
        }

        void loadmny()
        {
            try
            {
                Value = Math.Round(decimal.Parse(Text.Replace(Devise, "").Trim()), DecimalPlaces);
            }
            catch
            {
                base.UpdateEditText();
            }
        }

        /*private void textChanged(object sender, EventArgs e)
        {
            try
            {
                Value = Math.Round(decimal.Parse(Text.Replace(Devise, "").Trim()), DecimalPlaces);
            }
            catch
            {
                base.UpdateEditText();
            }
        }*/

        public MoneyUpDown()
        {
            InitializeComponent();
            Maximum = 999999999999;
            //DecimalPlaces = Convert.ToInt32(Properties.Settings.Default.DecimalPlaces);
            
        }

        public new int DecimalPlaces
        {
            get { return Convert.ToInt32(Properties.Settings.Default.DecimalPlaces); }
        }

        private string _dev = "€";

        public string Devise
        {
            get { return _dev; }
            set
            {
                _dev = value;
                UpdateEditText();
            }
        }

        protected override void UpdateEditText()
        {
            Text = Math.Round(Value, DecimalPlaces) + @" " + Devise;
        }
    }
}