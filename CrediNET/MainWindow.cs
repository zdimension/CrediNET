using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

using System.Windows.Forms;
using System.Resources;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Ookii.Dialogs;
using System.Globalization;
using System.Threading;

namespace CrediNET
{
    public partial class MainWindow : Form
    {
      

        private const int WIN_1252_CP = 1252;

        public Account CompteActuel = null;
        public Account filteredAccount = null;
        public decimal SoldeActuel = 0;
        public string CompteActuelChemin = null;

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        public MainWindow()
        {
            InitializeComponent();
            InitRenderers();
            SetWindowTheme(lvOps.Handle, "Explorer", null);

            ClearStuff();

            lvOps.DrawItem += lvOps_DrawItem;
            lvOps.ListViewItemSorter = lvwColumnSorter;
        }

        public MainWindow(string file)
        {
            InitializeComponent();
            InitRenderers();
            SetWindowTheme(lvOps.Handle, "Explorer", null);

            ClearStuff();

            lvOps.DrawItem += lvOps_DrawItem;
            lvOps.ListViewItemSorter = lvwColumnSorter;
            CompteActuelChemin = file;
        }

        void lvOps_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Item.ForeColor = SystemColors.HighlightText;
                e.Item.BackColor = SystemColors.Highlight;
            }
            else
            {
                e.Item.ForeColor = lvOps.ForeColor;
                e.Item.BackColor = lvOps.BackColor;
            }
        }

        public void InitRenderers()
        {
            Renderer rend = new Renderer();
            rend.Colors.gripOffset = 1;
            rend.Colors.gripSquare = 2;
            rend.Colors.gripSize = 3;
            rend.Colors.gripMove = 4;
            rend.Colors.gripLines = 3;
            rend.Colors.checkInset = 1;
            rend.Colors.marginInset = 2;
            rend.Colors.separatorInset = 31;
            rend.Colors.cutToolItemMenu = 1f;
            rend.Colors.cutContextMenu = 0f;
            rend.Colors.cutMenuItemBack = 1.3f;
            rend.Colors.contextCheckTickThickness = 1.6f;
            rend.Colors.imageMargin = Color.Transparent;
            rend.Colors.insideTop1 = Color.FromArgb(80, 80, 80);
            rend.Colors.insideTop2 = Color.FromArgb(80, 80, 80);
            rend.Colors.insideBottom1 = Color.FromArgb(80, 80, 80);
            rend.Colors.insideBottom2 = Color.FromArgb(80, 80, 80);
            rend.Colors.fillTop1 = Color.FromArgb(75, 75, 75);
            rend.Colors.fillTop2 = Color.FromArgb(75, 75, 75);
            rend.Colors.fillBottom1 = Color.FromArgb(75, 75, 75);
            rend.Colors.fillBottom2 = Color.FromArgb(75, 75, 75);
            rend.Colors.borderColor1 = Color.FromArgb(20, 20, 20);
            rend.Colors.borderColor2 = Color.FromArgb(20, 20, 20);
            rend.Colors.disabledInsideTop1 = Color.FromArgb(160, 160, 160);
            rend.Colors.disabledInsideTop2 = Color.FromArgb(160, 160, 160);
            rend.Colors.disabledInsideBottom1 = Color.FromArgb(160, 160, 160);
            rend.Colors.disabledInsideBottom2 = Color.FromArgb(160, 160, 160);
            rend.Colors.disabledFillTop1 = Color.FromArgb(160, 160, 160);
            rend.Colors.disabledFillTop2 = Color.FromArgb(160, 160, 160);
            rend.Colors.disabledFillBottom1 = Color.FromArgb(160, 160, 160);
            rend.Colors.disabledFillBottom2 = Color.FromArgb(160, 160, 160);
            rend.Colors.disabledBorderColor1 = Color.FromArgb(130, 130, 130);
            rend.Colors.disabledBorderColor2 = Color.FromArgb(130, 130, 130);
            rend.Colors.textDisabled = Color.FromArgb(160, 160, 160);
            rend.Colors.textMenuStripItem = System.Drawing.Color.LightGray;
            rend.Colors.textStatusStripItem = System.Drawing.Color.LightGray;
            rend.Colors.textContextMenuItem = System.Drawing.Color.LightGray;
            rend.Colors.textSelected = System.Drawing.Color.LightGray;
            rend.Colors.arrowDisabled = Color.WhiteSmoke;
            rend.Colors.arrowLight = Color.WhiteSmoke;
            rend.Colors.arrowDark = Color.WhiteSmoke;
            rend.Colors.arrowSelected = Color.WhiteSmoke;
            rend.Colors.separatorMenuLight = Color.FromArgb(50, 50, 50);
            rend.Colors.separatorMenuDark = Color.FromArgb(50, 50, 50);
            rend.Colors.contextMenuBack = Color.FromArgb(50, 50, 50);
            rend.Colors.contextCheckBorder = Color.Transparent;
            rend.Colors.contextCheckBorderSelected = Color.Transparent;
            rend.Colors.contextCheckTick = Color.WhiteSmoke;
            rend.Colors.contextCheckTickSelected = Color.WhiteSmoke;
            rend.Colors.statusStripBorderDark = Color.FromArgb(50, 50, 50);
            rend.Colors.statusStripBorderLight = Color.FromArgb(50, 50, 50);
            rend.Colors.gripDark = Color.FromArgb(0, 0, 0);
            rend.Colors.gripLight = Color.FromArgb(0, 0, 0);
            rend.Colors.foreColor = System.Drawing.Color.LightGray;
            

            toolStrip.Renderer = rend.GetRenderer();
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var ae = new FrmOperation(CompteActuel);
            if(ae.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Operation op = new Operation();
                op.Type = ae.cbxType.SelectedItem.ToString();
                op.Credit = ae.mupCredit.Value;
                op.Debit = ae.mupDebit.Value;
                op.Budget = ae.cbxBudget.SelectedItem.ToString();
                op.Date = ae.mcDate.SelectionStart;                
                op.Commentary = ae.txtComm.Text;

                CompteActuel.Operations.Add(op);
                LoadOps();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (CompteActuel != null)
                ClearStuff();

            var ae = new FrmCreateAccount();
            if (ae.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CompteActuel = new Account();
                CompteActuel.Name = ae.txtNom.Text;
                CompteActuel.DefPass(ae.txtPasse.Text);
                CompteActuel.Budgets = ae.lbxBudgets.Items.Cast<string>().ToList();

                CompteActuel.ChangeCurrency(Currencies.All.First(x => x.Name == (string)(ae.cbxDevise.SelectedItem)));

                //CompteActuel.Crypte = ae.cbxCrypt.Checked;

                LoadAccountStuff();
            }
        }

        public void ChargerSoldeAu()
        {
            if(lvOps.SelectedItems.Count == 0)
            {
                switch (CrediNET.Properties.Settings.Default.Lang.Name)
                {
                    case "en-US":
                        lblSoldeAt.Text = "Balance of ";
                        break;
                    case "de-DE":
                        lblSoldeAt.Text = "Balance bei ";
                        break;
                    default:        //case "fr-FR":
                        lblSoldeAt.Text = "Solde au ";
                        break;
                }

                lblSoldeAt.Text += DateTime.Now.ToString("dd/MM/yyyy") + " : " + SoldeActuel.ToString("0.00") + " " + CompteActuel.Currency.Symbol;
            }
            else
            {
                DateTime d = CompteActuel.Operations.First(x2 => x2.ID == lvOps.SelectedItems[0].Text).Date;
                decimal totalc = 0;
                CompteActuel.Operations.FindAll(x => CompteActuel.Operations.IndexOf(x) <= CompteActuel.Operations.IndexOf(CompteActuel.Operations.First(x2 => x2.ID == lvOps.SelectedItems[0].Text))).ForEach(x1 => totalc += x1.Credit);
                decimal totald = 0;
                CompteActuel.Operations.FindAll(x => CompteActuel.Operations.IndexOf(x) <= CompteActuel.Operations.IndexOf(CompteActuel.Operations.First(x2 => x2.ID == lvOps.SelectedItems[0].Text))).ForEach(x1 => totald += x1.Debit);

                switch (CrediNET.Properties.Settings.Default.Lang.Name)
                {
                    case "en-US":
                        lblSoldeAt.Text = "Balance of ";
                        break;
                    case "de-DE":
                        lblSoldeAt.Text = "Kontostand am ";
                        break;
                    default:        //case "fr-FR":
                        lblSoldeAt.Text = "Solde au ";
                        break;
                }

                lblSoldeAt.Text += d.ToString("dd/MM/yyyy") + " : " + (totalc - totald).ToString("0.00") + " " + CompteActuel.Currency.Symbol;
            }
        }

        string dfd 
        { 
            get
            { 
                return  Currencies.All.First(x => x.ShortName == CrediNET.Properties.Settings.Default.DefaultCurrency).Symbol;
            }
        }

        public void ClearStuff()
        {
            if (CompteActuel != null)
            {
                CompteActuel = null;
                CompteActuelChemin = "";
                SoldeActuel = 0;
            }

            btnEditAcc.Visible = false;
            toolStripSeparator1.Visible = false;

            btnAddOp.Visible = false;
            btnEditOp.Visible = false;
            btnDuplOp.Visible = false;
            btnDelOp.Visible = false;
            btnFilterOp.Visible = false;
            btnSave.Visible = false;

            btnGraph.Visible = false;

            lvOps.Items.Clear();

            this.Controls.Clear();
            InitializeComponent();
            InitRenderers();

            switch (CrediNET.Properties.Settings.Default.Lang.Name)
            {
                case "de-DE":
                    lblAccountName.Text = "<Kein Konto geladen>";
                    lblSolde.Text = "Kontostand : 0,00 " + dfd;
                    lblSoldeAt.Text = "Kontostand am   /  /     : 0,00 " + dfd;
                    lblTotalCredit.Text = "0,00 " + dfd;
                    lblTotalDeb.Text = "0,00 " + dfd;
                    break;
                case "fr-FR":
                    lblAccountName.Text = "<Pas de compte chargé>";
                    lblSolde.Text = "Solde : 0,00 " + dfd;
                    lblSoldeAt.Text = "Solde au   /  /     : 0,00 " + dfd;
                    lblTotalCredit.Text = "0,00 " + dfd;
                    lblTotalDeb.Text = "0,00 " + dfd;
                    break;
                default: //case "en-US":
                    lblAccountName.Text = "<No account loaded>";
                    lblSolde.Text = "Balance : " + dfd + "0.00 ";
                    lblSoldeAt.Text = "Balance of   /  /     : " + dfd + "0.00";
                    lblTotalCredit.Text = dfd + "0.00";
                    lblTotalDeb.Text = dfd + "0.00";
                    break;
            }
            
            //resources.ApplyResources(this, "$this");      //Not needed, controls' language updated with InitializeComponent()
        }

        public void LoadOps()
        {
            if (CompteActuel == null)
                return;

            lvOps.BeginUpdate();

            lvOps.Items.Clear();

            foreach (Operation op in CompteActuel.Operations)
            {
                

                ListViewItem it = new ListViewItem();
                it.Text = op.ID;
                it.Name = op.ID;
                it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                it.SubItems.Add(op.Type);
                it.SubItems.Add(op.Budget);
                it.SubItems.Add(op.Commentary);
                it.SubItems.Add(op.Credit + " " + CompteActuel.Currency.Symbol);
                it.SubItems.Add(op.Debit + " " + CompteActuel.Currency.Symbol);

                //if(!lvOps.Items.Contains(it))
                lvOps.Items.Add(it);
                
            }

            if (CompteActuel.Operations.Count == 0)
                btnCamembert.Enabled = false;
            else
                btnCamembert.Enabled = true;

            lvOps.EndUpdate();

            decimal totalc = 0;
            CompteActuel.Operations.ForEach(x1 => totalc += x1.Credit);
            lblTotalCredit.Text = totalc.ToString("0.00") + " " + CompteActuel.Currency.Symbol;

            decimal totald = 0;
            CompteActuel.Operations.ForEach(x1 => totald += x1.Debit);
            lblTotalDeb.Text = totald.ToString("0.00") + " " + CompteActuel.Currency.Symbol;

            switch (CrediNET.Properties.Settings.Default.Lang.Name)
            {
                case "en-US":
                    lblSolde.Text = "Balance : ";
                    break;
                case "de-DE":
                    lblSoldeAt.Text = "Kontostand : ";
                    break;
                default:        //case "fr-FR":
                    lblSolde.Text = "Solde : ";
                    break;
            }

            lblSolde.Text += (totalc - totald).ToString("0.00") + " " + CompteActuel.Currency.Symbol;

            SoldeActuel = totalc - totald;
        }

        public void LoadAccountStuff()
        {
            if (CompteActuel == null)
                return;

            btnEditAcc.Visible = true;
            toolStripSeparator1.Visible = true;

            btnAddOp.Visible = true;
            btnEditOp.Visible = true;
            btnDuplOp.Visible = true;
            btnDelOp.Visible = true;
            btnFilterOp.Visible = true;
            btnSave.Visible = true;

            btnGraph.Visible = true;

            LoadOps();

            ChargerSoldeAu();

            lblAccountName.Text = CompteActuelChemin;

            

            CheckCrypt();
            //cryptéToolStripMenuItem.Checked = CompteActuel.Crypte;
        }

        public void CheckCrypt()
        {
            /*if(CompteActuel.Crypte)
            {
                sfdCompte.Filter = "Compte crypté CrediNET (*.cne)|*.cne";               
            }
            else
            {*/

            switch (CrediNET.Properties.Settings.Default.Lang.Name)
            {
                case "en-US":
                    sfdCompte.Filter = "CrediNET Account (*.cna)|*.cna";
                    break;
                case "de-DE":
                    sfdCompte.Filter = "CrediNET Konto (*.cna)|*.cna";
                    break;
                default:        //case "fr-FR":
                    sfdCompte.Filter = "Compte CrediNET (*.cna)|*.cna";
                    break;
            }

            //}
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
            ClearStuff();

            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (CompteActuel != null)
                ClearStuff();

            if(ofpCompte.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Cursor = Cursors.AppStarting;
                CompteActuel = Account.FromFile(ofpCompte.FileName);
                CompteActuelChemin = ofpCompte.FileName;
                LoadAccountStuff();
                this.Cursor = Cursors.Default;
            }
        }

        public void LoadFile(string s)
        {
            if (CompteActuel != null)
                ClearStuff();

                this.Cursor = Cursors.AppStarting;
                CompteActuel = Account.FromFile(s);
                CompteActuelChemin = s;
                LoadAccountStuff();
                this.Cursor = Cursors.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CompteActuelChemin == null)
                enregistrerSousToolStripMenuItem_Click(sender, e);

            CompteActuel.Save();
        }

        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompteActuel.Encrypted)
            {
                switch (CrediNET.Properties.Settings.Default.Lang.Name)
                {
                    case "en-US":
                        sfdCompte.Filter = "CrediNET crypted Account (*.cne)|*.cne";
                        break;
                    case "de-DE":
                        sfdCompte.Filter = "CrediNET versclüsseltes Konto (*.cne)|*.cne";
                        break;
                    default:        //case "fr-FR":
                        sfdCompte.Filter = "Compte CrediNET crypté (*.cne)|*.cne";
                        break;
                }
            }
            else
            {
                switch (CrediNET.Properties.Settings.Default.Lang.Name)
                {
                    case "en-US":
                        sfdCompte.Filter = "CrediNET Account (*.cna)|*.cna";
                        break;
                    case "de-DE":
                        sfdCompte.Filter = "CrediNET Konto (*.cna)|*.cna";
                        break;
                    default:        //case "fr-FR":
                        sfdCompte.Filter = "Compte CrediNET (*.cna)|*.cna";
                        break;
                }
            }
            if(sfdCompte.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CompteActuel.SaveAs(sfdCompte.FileName);
            }
        }

        private void cryptéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*CompteActuel.Crypte = !CompteActuel.Crypte;
            cryptéToolStripMenuItem.Checked = CompteActuel.Crypte;
            CheckCrypt();*/
        }

        private void cryptéToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            //CheckCrypt();
        }

        private void lvOps_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("youpi");
            btnEditOp.Enabled = lvOps.SelectedItems.Count != 0;
            btnDuplOp.Enabled = lvOps.SelectedItems.Count != 0;
            btnDelOp.Enabled = lvOps.SelectedItems.Count != 0;

            ChargerSoldeAu();
        }

        private void btnOpt_Click(object sender, EventArgs e)
        {
        }

        private void btnDelOp_Click(object sender, EventArgs e)
        {
            CompteActuel.Operations.RemoveAll(x => x.ID == lvOps.SelectedItems[0].Text);
            LoadOps();
        }

        private void btnEditOp_Click(object sender, EventArgs e)
        {
            var ae = new FrmOperation(CompteActuel, false, true, CompteActuel.Operations.First(x => x.ID == lvOps.SelectedItems[0].Text));
            if (ae.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Operation op = new Operation();
                op.Type = ae.cbxType.SelectedItem.ToString();
                op.Credit = ae.mupCredit.Value;
                op.Debit = ae.mupDebit.Value;
                op.Budget = ae.cbxBudget.SelectedItem.ToString();
                op.Date = ae.mcDate.SelectionStart;
                op.Commentary = ae.txtComm.Text;

                int a = CompteActuel.Operations.IndexOf(CompteActuel.Operations.First(x => x.ID == lvOps.SelectedItems[0].Text));
                CompteActuel.Operations.RemoveAll(x => x.ID == lvOps.SelectedItems[0].Text);
                CompteActuel.Operations.Insert(a, op);
                LoadOps();
            }
        }

        private void btnDuplOp_Click(object sender, EventArgs e)
        {
            var ae = new FrmOperation(CompteActuel, false, true, CompteActuel.Operations.First(x => x.ID == lvOps.SelectedItems[0].Text));
            if (ae.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Operation op = new Operation();
                op.Type = ae.cbxType.SelectedItem.ToString();
                op.Credit = ae.mupCredit.Value;
                op.Debit = ae.mupDebit.Value;
                op.Budget = ae.cbxBudget.SelectedItem.ToString();
                op.Date = ae.mcDate.SelectionStart;
                op.Commentary = ae.txtComm.Text;

                CompteActuel.Operations.Add(op);
                LoadOps();
            }
        }

        private void fichierCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sfdCSV.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(sfdCSV.FileName))
                    File.Delete(sfdCSV.FileName);

                using (StreamWriter wr = new StreamWriter(sfdCSV.FileName, false, Encoding.GetEncoding(WIN_1252_CP)))
                {
                    switch (CrediNET.Properties.Settings.Default.Lang.Name)
                    {
                        case "en-US":
                            wr.WriteLine("Date;Type;Budget;Comment;Credit;Debit");
                            break;
                        case "de-DE":
                            wr.WriteLine("Date;Type;Budget;Kommentar;Kredit;Debit");
                            break;
                        default:        //case "fr-FR":
                            wr.WriteLine("Date;Type;Budget;Commentaire;Crédit;Débit");
                            break;
                    }


                    foreach(Operation op in CompteActuel.Operations)
                    {
                        string s = "";
                        s += op.Date.ToString("dd/MM/yyyy");
                        s += ";";
                        s += op.Type;
                        s += ";";
                        s += op.Budget;
                        s += ";";
                        s += op.Commentary;
                        s += ";";
                        s += op.Credit + " " + CompteActuel.Currency.Symbol;
                        s += ";";
                        s += op.Debit + " " + CompteActuel.Currency.Symbol;
                        wr.WriteLine(s);
                    }
                    wr.Close();
                }

                Process.Start(sfdCSV.FileName);
            }
        }

        private void toolStrip_Paint(object sender, PaintEventArgs e)
        {
            var clr = Color.FromArgb(45, 45, 48);
            int a = toolStrip.Width;
            e.Graphics.DrawLine(new Pen(clr), a, 0, a, toolStrip.Height);
        }

        public ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void lvOps_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvOps.BeginUpdate();
            //ListView myListView = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                    lvOps.Sorting = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                    lvOps.Sorting = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
                lvOps.Sorting = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            lvOps.Sort();
            lvOps.ListViewItemSorter = new ListViewColumnSorter(e.Column, lvOps.Sorting);
            lvOps.EndUpdate();
        }

        private void fichierExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdXLS.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(sfdXLS.FileName))
                    File.Delete(sfdXLS.FileName);

                /*Excel.Application app = new Excel.Application();
                app.Visible = true;
                Excel.Workbook workbook = app.Workbooks.Add(1);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                Excel.Range workSheet_range = null;*/

                CreateExcelDoc d = new CreateExcelDoc();

                //Same for English and French lang
                d.createHeaders(1, 1, "Date", "A1", "A1", 0, Color.Gainsboro, true, 10, Color.Black);
                d.createHeaders(1, 2, "Type", "B1", "B1", 0, Color.Gainsboro, true, 10, Color.Black);
                d.createHeaders(1, 3, "Budget", "C1", "D1", 1, Color.Gainsboro, true, 10, Color.Black);

                switch (CrediNET.Properties.Settings.Default.Lang.Name)
                {
                    case "en-US":
                        d.createHeaders(1, 5, "Comment", "E1", "G1", 0, Color.Gainsboro, true, 10, Color.Black);
                        d.createHeaders(1, 8, "Credit", "H1", "H1", 0, Color.Gainsboro, true, 10, Color.Black);
                        d.createHeaders(1, 9, "Debit", "I1", "I1", 0, Color.Gainsboro, true, 10, Color.Black);
                        break;

                    case "de-DE":
                        d.createHeaders(1, 5, "Kommentar", "E1", "G1", 0, Color.Gainsboro, true, 10, Color.Black);
                        d.createHeaders(1, 8, "Kredit", "H1", "H1", 0, Color.Gainsboro, true, 10, Color.Black);
                        d.createHeaders(1, 9, "Debit", "I1", "I1", 0, Color.Gainsboro, true, 10, Color.Black);
                        break;

                    default:        //case "fr-FR":
                        d.createHeaders(1, 5, "Commentaire", "E1", "G1", 0, Color.Gainsboro, true, 10, Color.Black);
                        d.createHeaders(1, 8, "Crédit", "H1", "H1", 0, Color.Gainsboro, true, 10, Color.Black);
                        d.createHeaders(1, 9, "Débit", "I1", "I1", 0, Color.Gainsboro, true, 10, Color.Black);
                        break;
                }
                
                foreach(Operation op in CompteActuel.Operations)
                {
                    int id = CompteActuel.Operations.IndexOf(op) + 2;
                    d.addData(id, 1, op.Date.ToString("dd/MM/yyyy"), "A" + id, "A" + id, "dd/mm/yyyy");

                    d.addData(id, 2, op.Type, "B" + id, "B" + id, "");
                    d.addData(id, 3, op.Budget, "C" + id, "D" + id, "", 1);
                    d.addData(id, 5, op.Commentary, "E" + id, "G" + id, "", 2);


                    d.addData(id, 8, op.Credit, "H" + id, "H" + id, "# ###,00 " + CompteActuel.Currency.Symbol);
                    d.addData(id, 9, op.Debit, "I" + id, "I" + id, "# ###,00 " + CompteActuel.Currency.Symbol);
                }

                d.worksheet.Columns[1].AutoFit();
                d.worksheet.Columns[2].AutoFit();

                //d.app.SaveWorkspace(sfdXLS.FileName);

                

                

                //Process.Start(sfdXLS.FileName);
            }
        }

        private void fichierExcelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (sfdXLSX.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(sfdXLSX.FileName))
                    File.Delete(sfdXLSX.FileName);

                using (ExcelPackage pkg = new ExcelPackage())
                {

                    OfficeOpenXml.ExcelWorksheet w = pkg.Workbook.Worksheets.Add(CompteActuel.Name);


                    // en-tête
                    w.Cells[1, 1].Value = "Date";
                    w.Cells[1, 2].Value = "Type";
                    w.Cells[1, 3].Value = "Budget";

                    switch (CrediNET.Properties.Settings.Default.Lang.Name)
                    {
                        case "en-US":
                            w.Cells[1, 4, 1, 6].Value = "Comment";
                            w.Cells[1, 4, 1, 6].Merge = true;
                            w.Cells[1, 7].Value = "Credit";
                            w.Cells[1, 8].Value = "Debit";
                            break;

                        case "de-DE":
                            w.Cells[1, 4, 1, 6].Value = "Kommentar";
                            w.Cells[1, 4, 1, 6].Merge = true;
                            w.Cells[1, 7].Value = "Kredit";
                            w.Cells[1, 8].Value = "Debit";
                            break;

                        default:        //case "fr-FR":
                            w.Cells[1, 4, 1, 6].Value = "Commentaire";
                            w.Cells[1, 4, 1, 6].Merge = true;
                            w.Cells[1, 7].Value = "Crédit";
                            w.Cells[1, 8].Value = "Débit";
                            break;
                    }
                                       

                    w.Cells[1, 1, 1, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    w.Cells[1, 1, 1, 8].Style.Fill.BackgroundColor.SetColor(Color.Gainsboro);
                    w.Cells[1, 1, 1, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    foreach (Operation op in CompteActuel.Operations)
                    {
                        int id = CompteActuel.Operations.IndexOf(op) + 2;
                        w.Cells[id, 1].Value = op.Date.ToString("dd/MM/yyyy");
                        w.Cells[id, 2].Value = op.Type;
                        w.Cells[id, 3].Value = op.Budget;
                        w.Cells[id, 4].Value = op.Commentary;

                        w.Cells[id, 4, id, 6].Merge = true;

                        w.Cells[id, 7, id, 8].Style.Numberformat.Format = "#,##0.00 " + CompteActuel.Currency.Symbol;

                        w.Cells[id, 7].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        w.Cells[id, 7].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                        w.Cells[id, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        w.Cells[id, 8].Style.Fill.BackgroundColor.SetColor(Color.Tomato);

                        w.Cells[id, 7].Value = op.Credit;
                        w.Cells[id, 8].Value = op.Debit;

                    }

                    w.Cells.AutoFitColumns(1);
                    w.Cells.AutoFitColumns(2);
                    w.Cells.AutoFitColumns(3);
                    w.Cells.AutoFitColumns(7);
                    w.Cells.AutoFitColumns(8);

                    pkg.SaveAs(new FileInfo(sfdXLSX.FileName));

                    Process.Start(sfdXLSX.FileName);
                }

                

            }
        }

        private void classeurOpenOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (sfdODS.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(sfdODS.FileName))
                    File.Delete(sfdODS.FileName);
            }*/
        }

        private void btnOpt_Click_1(object sender, EventArgs e)
        {
            new FrmOptions().ShowDialog();
            if (CompteActuel == null) ClearStuff();
            //DevExt.ExchangeRate(Devises.Euro, Devises.US_Dollar);
        }

        private void btnCamembert_Click(object sender, EventArgs e)
        {
            new FrmGraph(1, filteredAccount == null ? CompteActuel : filteredAccount).ShowDialog(this);
        }

        private void btnCourbes_Click(object sender, EventArgs e)
        {
            new FrmGraph(2, filteredAccount == null ? CompteActuel : filteredAccount).ShowDialog(this);
        }

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            var ae = new FrmCreateAccount(CompteActuel);
            if (ae.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CompteActuel.Name = ae.txtNom.Text;
                if(ae.txtPasse.Font.Style != FontStyle.Italic) CompteActuel.DefPass(ae.txtPasse.Text);
                CompteActuel.Budgets = ae.lbxBudgets.Items.Cast<string>().ToList();

                CompteActuel.ChangeCurrency(Currencies.All.First(x => x.Name == ae.cbxDevise.SelectedItem.ToString()));

                CompteActuel.Encrypted = ae.cbxCrypt.Checked;

                LoadAccountStuff();
            }
        }

        bool onlytime = true;

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (onlytime)
            {
                if (CompteActuelChemin != "")
                    LoadFile(CompteActuelChemin);
            }
            onlytime = false;
        }

        private void btnFilterOp_Click(object sender, EventArgs e)
        {
            FrmOpFilter of = new FrmOpFilter(CompteActuel);

            DateTime? dtFrom = null;
            DateTime? dtTo = null;
            decimal? creditFrom = null;
            decimal? creditTo = null;
            decimal? debitFrom = null;
            decimal? debitTo = null;
            string type = null;
            string budget = null;


            if (btnFilterOp.Checked)
            {
                LoadOps(dtFrom, dtTo, creditFrom, creditTo, debitFrom, debitTo, type, budget);
                filteredAccount = null;
                btnFilterOp.Checked = false;
            }
            else
            {
                if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (of.chbDate.Checked)
                    {
                        dtFrom = of.dtpFrom.Value;
                        dtTo = of.dtpTo.Value;
                    }
                    if (of.chbCredit.Checked)
                    {
                        creditFrom = of.mudCreditFrom.Value;
                        creditTo = of.mudCreditTo.Value;
                    }
                    if (of.chbDebit.Checked)
                    {
                        debitFrom = of.mudDebitFrom.Value;
                        debitTo = of.mudDebitTo.Value;
                    }
                    if (of.chbType.Checked)
                    {
                        type = of.cbxType.SelectedItem.ToString();
                    }
                    if (of.chbBudget.Checked)
                    {
                        budget = of.cbxBudget.SelectedItem.ToString();
                    }
                    
                    LoadOps(dtFrom, dtTo, creditFrom, creditTo, debitFrom, debitTo, type, budget);
                    btnFilterOp.Checked = true;
                }
            }


        }

        public void LoadOps(DateTime? dtFrom, DateTime? dtTo, decimal? creditFrom, decimal? creditTo, decimal? debitFrom, decimal? debitTo, string type, string budget)
        {
            if (CompteActuel == null)
                return;

            lvOps.BeginUpdate();

            lvOps.Items.Clear();

            IQueryable<Operation> queryOps =
                from op in CompteActuel.Operations.AsQueryable<Operation>()
                select op;

            if (dtFrom != null && dtTo != null)
                queryOps = queryOps.Where(op => DateTime.Compare(op.Date, dtFrom ?? DateTime.Now) >= 0 && DateTime.Compare(op.Date, dtTo ?? DateTime.Now) <= 0);
    
            if (creditFrom.HasValue && creditTo.HasValue)
                queryOps = queryOps.Where(op => op.Credit >= creditFrom && op.Credit <= creditTo);

            if (debitFrom.HasValue && debitTo.HasValue)
                queryOps = queryOps.Where(op => op.Debit >= debitFrom && op.Debit <= debitTo);

            if (type != null)
                queryOps = queryOps.Where(op => op.Type.Equals(type));

            if (budget != null)
                queryOps = queryOps.Where(op => op.Budget.Equals(budget));

            //filteredAccount is used as input for graph representations
            filteredAccount = new Account();
            filteredAccount.Name = CompteActuel.Name;
            filteredAccount.Currency = CompteActuel.Currency;

            foreach (Operation op in queryOps)
            {
                ListViewItem it = new ListViewItem();
                it.Text = op.ID;
                it.Name = op.ID;
                it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                it.SubItems.Add(op.Type);
                it.SubItems.Add(op.Budget);
                it.SubItems.Add(op.Commentary);
                it.SubItems.Add(op.Credit + " " + CompteActuel.Currency.Symbol);
                it.SubItems.Add(op.Debit + " " + CompteActuel.Currency.Symbol);

                //if(!lvOps.Items.Contains(it))
                lvOps.Items.Add(it);

                filteredAccount.Operations.Add(op);
            }

            if (CompteActuel.Operations.Count == 0)
                btnCamembert.Enabled = false;
            else
                btnCamembert.Enabled = true;

            lvOps.EndUpdate();

            decimal totalc = 0;
            queryOps.ToList().ForEach(x1 => totalc += x1.Credit);
            lblTotalCredit.Text = totalc.ToString("0.00") + " " + CompteActuel.Currency.Symbol;

            decimal totald = 0;
            queryOps.ToList().ForEach(x1 => totald += x1.Debit);
            lblTotalDeb.Text = totald.ToString("0.00") + " " + CompteActuel.Currency.Symbol;

            switch (CrediNET.Properties.Settings.Default.Lang.Name)
            {
                case "en-US":
                    lblSolde.Text = "Balance : ";
                    break;
                case "de-DE":
                    lblSoldeAt.Text = "Kontostand : ";
                    break;
                default:        //case "fr-FR":
                    lblSolde.Text = "Solde : ";
                    break;
            }

            lblSolde.Text += (totalc - totald).ToString("0.00") + " " + CompteActuel.Currency.Symbol;

            SoldeActuel = totalc - totald;
        }
    }
}
