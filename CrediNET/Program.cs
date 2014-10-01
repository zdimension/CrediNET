﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

using System.Windows.Forms;
using CrediNET.Properties;

namespace CrediNET
{
    internal static class Program
    {
        //public static string EncryptionKey = "bW90ZGVwYXNzZWNyZWRpbmV0X3Npdm91c2xpc2V6Y2VtZXNzYWdlY2VzdHF1ZXZvdXNldGVzdW5oYWNrZXI=";

        public static List<string> Types = new List<string>() { "CB", "CHQ", "PRL", "VIR", "SPC" };

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Currencies.Init();
            Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);

            Thread.CurrentThread.CurrentCulture = Settings.Default.Lang;
            Thread.CurrentThread.CurrentUICulture = Settings.Default.Lang;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(args.Count() == 0 ? new MainWindow() : (args[0] == "" ? new MainWindow() : new MainWindow(args[0])));
        }

        private static void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Settings.Default.Save();
            Thread.CurrentThread.CurrentCulture = Settings.Default.Lang;
            Thread.CurrentThread.CurrentUICulture = Settings.Default.Lang;
            Currencies.Init();
        }
    }
}