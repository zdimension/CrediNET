using System;

using System.Windows.Forms;

namespace CrediNET
{
    public partial class FrmCountSpcEuro : Form
    {
        public decimal Total { get; private set; }

        public FrmCountSpcEuro()
        {
            InitializeComponent();
        }

        private void RefreshTotal()
        {
            Total = 0.00M;
            Total += nud1ct.Value * 0.01M;
            Total += nud2ct.Value * 0.02M;
            Total += nud5ct.Value * 0.05M;
            Total += nud10ct.Value * 0.10M;
            Total += nud20ct.Value * 0.20M;
            Total += nud50ct.Value * 0.50M;
            Total += nud1eur.Value * 1;
            Total += nud2eur.Value * 2;
            Total += nud5eur.Value * 5;
            Total += nud10eur.Value * 10;
            Total += nud20eur.Value * 20;
            Total += nud50eur.Value * 50;
            Total += nud100eur.Value * 100;
            Total += nud200eur.Value * 200;
            Total += nud500eur.Value * 500;
            lblTotal.Text = "Total : " + Total.ToString("0.00") + " €";
        }

        private void nud1ct_ValueChanged(object sender, EventArgs e)
        {
            RefreshTotal();
        }

        private void btn1ct_Click(object sender, EventArgs e)
        {
            nud1ct.Value++;
        }

        private void btn2ct_Click(object sender, EventArgs e)
        {
            nud2ct.Value++;
        }

        private void btn5ct_Click(object sender, EventArgs e)
        {
            nud5ct.Value++;
        }

        private void btn10ct_Click(object sender, EventArgs e)
        {
            nud10ct.Value++;
        }

        private void btn20ct_Click(object sender, EventArgs e)
        {
            nud20ct.Value++;
        }

        private void btn50ct_Click(object sender, EventArgs e)
        {
            nud50ct.Value++;
        }

        private void btn1eur_Click(object sender, EventArgs e)
        {
            nud1eur.Value++;
        }

        private void btn2eur_Click(object sender, EventArgs e)
        {
            nud2eur.Value++;
        }

        private void btn5eur_Click(object sender, EventArgs e)
        {
            nud5eur.Value++;
        }

        private void btn10eur_Click(object sender, EventArgs e)
        {
            nud10eur.Value++;
        }

        private void btn20eur_Click(object sender, EventArgs e)
        {
            nud20eur.Value++;
        }

        private void btn50eur_Click(object sender, EventArgs e)
        {
            nud50eur.Value++;
        }

        private void btn100eur_Click(object sender, EventArgs e)
        {
            nud100eur.Value++;
        }

        private void btn200eur_Click(object sender, EventArgs e)
        {
            nud200eur.Value++;
        }

        private void btn500eur_Click(object sender, EventArgs e)
        {
            nud500eur.Value++;
        }
    }
}