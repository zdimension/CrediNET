using System;
using System.Windows.Forms;

namespace CrediNET
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();

            lblVersion.Text = lblVersion.Text.Replace("$ver", Application.ProductVersion.Substring(0, 3));
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}