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
