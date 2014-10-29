using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Elysium;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;

namespace CrediNET
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Elysium.Controls.Window
    {
        public Account CompteActuel = null;
        public Account FilteredAccount = null;
        public decimal SoldeActuel = 0;
        public string CompteActuelChemin = null;

        private string dfd
        {
            get
            {
                return Currencies.All.First(x => x.ShortName == CrediNET.Properties.Settings.Default.DefaultCurrency).Symbol;
            }
        }

        public MainWindow()
        {
            //Application.Current.Apply(Theme.Light);
            //AppearanceManager.Current.ThemeSource = AppearanceManager.LightThemeSource;
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var cg = Properties.Settings.Default.AccentColor;
            this.Resources["accentColor"] = new SolidColorBrush(cg);
            this.Resources["borderColor"] = new SolidColorBrush(new Color() { A = 255, R = 255, G = 255, B = 255 });
            Application.Current.Apply(Properties.Settings.Default.Theme == "Light" ? Theme.Light : Theme.Dark, new SolidColorBrush(cg), new SolidColorBrush(new Color() { A = 255, R = 255, G = 255, B = 255 }));
            ClearStuff();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // 1093 -> 279
            //this.FindChild<StackPanel>("pnlTool2").Width = this.Width - 879;
            this.pnlTool2.Width = this.Width - 800;
            
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            var ac = new FrmCreateAccount();
            if(ac.ShowDialog() == true)
            {
                if (CompteActuel != null)
                    ClearStuff();

                CompteActuel = new Account();
                CompteActuel.Name = ac.txtName.Text;
                CompteActuel.DefPass(ac.txtPassword.Password);
                CompteActuel.Budgets.Clear();
                ac.lbxBudgets.Items.OfType<ListViewItem>().All(x => { CompteActuel.Budgets.Add(x.Content.ToString(), (x.Background as SolidColorBrush).Color); return true; });

                CompteActuel.ChangeCurrency(Currencies.All.First(x => x.Name == (string)(ac.cbxCurrency.SelectedItem)));

                LoadAccountStuff();
            }
        }

        public void LoadAccountStuff()
        {

        }

        public void ClearStuff()
        {
            if (CompteActuel != null)
            {
                CompteActuel = null;
                CompteActuelChemin = "";
                SoldeActuel = 0;
            }

            btnEditAccount.Visibility = Visibility.Hidden;
            separator.Visibility = Visibility.Hidden;

            btnAddOp.Visibility = Visibility.Hidden;
            btnEditOp.Visibility = Visibility.Hidden;
            btnDuplicateOp.Visibility = Visibility.Hidden;
            btnDeleteOp.Visibility = Visibility.Hidden;
            btnFilterOp.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Hidden;
            btnReminderOp.Visibility = Visibility.Hidden;

            btnGraph.Visibility = Visibility.Hidden;

            dgOps.Items.Clear();

            switch (CrediNET.Properties.Settings.Default.Lang.Name)
            {
                case "de-DE":
                    lblAccountName.Content = "<Kein Konto geladen>";
                    lblSolde.Content = "Kontostand : 0,00 " + dfd;
                    lblSoldeAt.Content = "Kontostand am   /  /     : 0,00 " + dfd;
                    lblTotalCredit.Content = "0,00 " + dfd;
                    lblTotalDebit.Content = "0,00 " + dfd;
                    break;

                case "fr-FR":
                    lblAccountName.Content = "<Pas de compte chargé>";
                    lblSolde.Content = "Solde : 0,00 " + dfd;
                    lblSoldeAt.Content = "Solde au   /  /     : 0,00 " + dfd;
                    lblTotalCredit.Content = "0,00 " + dfd;
                    lblTotalDebit.Content = "0,00 " + dfd;
                    break;

                default: //case "en-US":
                    lblAccountName.Content = "<No account loaded>";
                    lblSolde.Content = "Balance : " + dfd + "0.00 ";
                    lblSoldeAt.Content = "Balance of   /  /     : " + dfd + "0.00";
                    lblTotalCredit.Content = dfd + "0.00";
                    lblTotalDebit.Content = dfd + "0.00";
                    break;
            }

            this.Title = "CrediNET";
        }
    }
}
