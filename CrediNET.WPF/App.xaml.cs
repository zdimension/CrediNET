using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
namespace CrediNET.WPF
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public sealed partial class App : Application
    {
        public static List<string> Types = new List<string>() { "CB", "CHQ", "PRL", "VIR", "SPC" };

        private void StartupHandler(object sender, System.Windows.StartupEventArgs e)
        {
            Currencies.Init();
        }
    }
}
