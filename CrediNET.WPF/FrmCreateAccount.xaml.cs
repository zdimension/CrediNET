using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using JetBrains.Annotations;

namespace CrediNET
{
    /// <summary>
    /// Logique d'interaction pour FrmCreateAccount.xaml
    /// </summary>
    public sealed partial class FrmCreateAccount : Elysium.Controls.Window
    {
        public FrmCreateAccount(Account editCompt = null)
        {
            InitializeComponent();
            Currencies.All.ForEach(x => cbxCurrency.Items.Add(x.Name));
            lbxBudgets.ItemsSource = Budgets;
            
        }

        public Color SelectedColor
        { 
            get
            {
                var convertFromString = ColorConverter.ConvertFromString(cbxColor.SelectedValue.ToString());
                if (convertFromString != null)
                    return cbxColor.SelectedValue == null ? Colors.White : (Color)convertFromString;
                return Colors.White;
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var cg = Properties.Settings.Default.AccentColor;
            this.Resources["accentColor"] = new SolidColorBrush(cg);
            this.Resources["borderColor"] = new SolidColorBrush(new Color() { A = 255, R = 255, G = 255, B = 255 });
            Application.Current.Apply(Properties.Settings.Default.Theme == "Light" ? Theme.Light : Theme.Dark, new SolidColorBrush(cg), new SolidColorBrush(new Color() { A = 255, R = 255, G = 255, B = 255 }));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private ObservableCollection<ListViewItem> Budgets = new ObservableCollection<ListViewItem>
        {
            new ListViewItem() {Content="alimentary"},
            new ListViewItem() {Content="car"},
            new ListViewItem() {Content="health"},
            new ListViewItem() {Content="housing"},
            new ListViewItem() {Content="salary"},
            new ListViewItem() {Content="various"}
        };

        void checkfd()
        {
            btnOK.IsEnabled = !(string.IsNullOrWhiteSpace(txtName.Text)) && !(string.IsNullOrWhiteSpace(txtPassword.Password)) && lbxBudgets.Items.Count > 0;
            btnBudgetAdd.IsEnabled = !(string.IsNullOrWhiteSpace(txtBudgetName.Text)) && !(SelectedColor == null);
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            checkfd();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            checkfd();
        }

        private void btnBudgetAdd_Click(object sender, RoutedEventArgs e)
        {
            if (lbxBudgets.Items.OfType<ListViewItem>().All(x => x.Content.ToString() != txtBudgetName.Text))
                lbxBudgets.Items.Add(new ListViewItem { Content = txtBudgetName.Text, Background = new SolidColorBrush(SelectedColor) });

            txtBudgetName.Text = "";
        }

        private void txtBudgetName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lbxBudgets.SelectedItems.Count == 0) return;

            var listViewItem = lbxBudgets.SelectedItems[0] as ListViewItem;
            if (listViewItem != null && txtBudgetName.Text != listViewItem.Content.ToString())
            {
                int index = lbxBudgets.SelectedIndex;

                ((ListViewItem)lbxBudgets.SelectedItems[0]).Content = txtBudgetName.Text;
            }
        }

        private void btnBudgetRemove_Click(object sender, RoutedEventArgs e)
        {
            Budgets.Insert(1, new ListViewItem() { Content = "fm,noi" });
        }

        private void cbxColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxBudgets.SelectedIndex == -1) return;

            var solidColorBrush = ((ListViewItem)lbxBudgets.Items[lbxBudgets.SelectedIndex]).Background as SolidColorBrush;
            if(solidColorBrush != null && SelectedColor != solidColorBrush.Color)
            {
                //((ListViewItem)lbxBudgets.Items[lbxBudgets.SelectedIndex]).Background = new SolidColorBrush(SelectedColor);
            }
        }

        private void lbxBudgets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkfd();

            if(lbxBudgets.SelectedIndex != -1)
            {
                var listViewItem = lbxBudgets.Items[lbxBudgets.SelectedIndex] as ListViewItem;
                if (listViewItem != null)
                    txtBudgetName.Text = listViewItem.Content.ToString();
                var viewItem = lbxBudgets.Items[lbxBudgets.SelectedIndex] as ListViewItem;
                if (viewItem != null)
                    cbxColor.SelectedValue = (viewItem.Background as SolidColorBrush).Color;
            }
            else
            {
                txtBudgetName.Text = "";
                cbxColor.SelectedIndex = -1;
            }
        }

    }
}
