using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AODL.Document.Content.Tables;
using AODL.Document.SpreadsheetDocuments;
using CrediNET.Languages;
using CrediNET.Properties;
using OfficeOpenXml;
using OfficeOpenXml.Style;

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
            if (Settings.Default.ShowSplash)
            {
                if (new Splash().ShowDialog() == DialogResult.OK)
                {
                }
            }
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

        private void lvOps_DrawItem(object sender, DrawListViewItemEventArgs e)
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
            var rend = new Renderer
            {
                Colors =
                {
                    gripOffset = 1,
                    gripSquare = 2,
                    gripSize = 3,
                    gripMove = 4,
                    gripLines = 3,
                    checkInset = 1,
                    marginInset = 2,
                    separatorInset = 31,
                    cutToolItemMenu = 1f,
                    cutContextMenu = 0f,
                    cutMenuItemBack = 1.3f,
                    contextCheckTickThickness = 1.6f,
                    imageMargin = Color.Transparent,
                    insideTop1 = Color.FromArgb(80, 80, 80),
                    insideTop2 = Color.FromArgb(80, 80, 80),
                    insideBottom1 = Color.FromArgb(80, 80, 80),
                    insideBottom2 = Color.FromArgb(80, 80, 80),
                    fillTop1 = Color.FromArgb(75, 75, 75),
                    fillTop2 = Color.FromArgb(75, 75, 75),
                    fillBottom1 = Color.FromArgb(75, 75, 75),
                    fillBottom2 = Color.FromArgb(75, 75, 75),
                    borderColor1 = Color.FromArgb(20, 20, 20),
                    borderColor2 = Color.FromArgb(20, 20, 20),
                    disabledInsideTop1 = Color.FromArgb(160, 160, 160),
                    disabledInsideTop2 = Color.FromArgb(160, 160, 160),
                    disabledInsideBottom1 = Color.FromArgb(160, 160, 160),
                    disabledInsideBottom2 = Color.FromArgb(160, 160, 160),
                    disabledFillTop1 = Color.FromArgb(160, 160, 160),
                    disabledFillTop2 = Color.FromArgb(160, 160, 160),
                    disabledFillBottom1 = Color.FromArgb(160, 160, 160),
                    disabledFillBottom2 = Color.FromArgb(160, 160, 160),
                    disabledBorderColor1 = Color.FromArgb(130, 130, 130),
                    disabledBorderColor2 = Color.FromArgb(130, 130, 130),
                    textDisabled = Color.FromArgb(160, 160, 160),
                    textMenuStripItem = Color.LightGray,
                    textStatusStripItem = Color.LightGray,
                    textContextMenuItem = Color.LightGray,
                    textSelected = Color.LightGray,
                    arrowDisabled = Color.WhiteSmoke,
                    arrowLight = Color.WhiteSmoke,
                    arrowDark = Color.WhiteSmoke,
                    arrowSelected = Color.WhiteSmoke,
                    separatorMenuLight = Color.FromArgb(50, 50, 50),
                    separatorMenuDark = Color.FromArgb(50, 50, 50),
                    contextMenuBack = Color.FromArgb(50, 50, 50),
                    contextCheckBorder = Color.Transparent,
                    contextCheckBorderSelected = Color.Transparent,
                    contextCheckTick = Color.WhiteSmoke,
                    contextCheckTickSelected = Color.WhiteSmoke,
                    statusStripBorderDark = Color.FromArgb(50, 50, 50),
                    statusStripBorderLight = Color.FromArgb(50, 50, 50),
                    gripDark = Color.FromArgb(0, 0, 0),
                    gripLight = Color.FromArgb(0, 0, 0),
                    foreColor = Color.LightGray
                }
            };

            toolStrip.Renderer = rend.GetRenderer();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var ae = new FrmOperation(CompteActuel);
            if (ae.ShowDialog() == DialogResult.OK)
            {
                var op = new Operation
                {
                    Type = ae.cbxType.SelectedItem.ToString(),
                    Credit = ae.mupCredit.Value,
                    Debit = ae.mupDebit.Value,
                    Budget = ae.cbxBudget.SelectedText,
                    Date = ae.mcDate.SelectionStart,
                    Commentary = ae.txtComm.Text
                };

                CompteActuel.Operations.Add(op);
                LoadOps();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (CompteActuel != null)
                ClearStuff();

            var ae = new FrmCreateAccount();
            if (ae.ShowDialog() != DialogResult.OK) return;
            CompteActuel = new Account {Name = ae.txtNom.Text};
            CompteActuel.DefPass(ae.txtPasse.Text);
            CompteActuel.Budgets.Clear();
            ae.lbxBudgets.Items.OfType<ListViewItem>().All(x =>
            {
                CompteActuel.Budgets.Add(x.Text, x.BackColor);
                return true;
            });

            CompteActuel.ChangeCurrency(Currencies.All.First(x => x.Name == (string) (ae.cbxDevise.SelectedItem)));

            //CompteActuel.Crypte = ae.cbxCrypt.Checked;

            LoadAccountStuff();
        }

        public void ChargerSoldeAu()
        {
            if (lvOps.SelectedItems.Count == 0)
            {
                switch (Settings.Default.Lang.Name)
                {
                    case "en-US":
                        lblSoldeAt.Text = en_US.Account_BalanceOf;
                        break;

                    case "de-DE":
                        lblSoldeAt.Text = de_DE.Account_BalanceOf;
                        break;

                    case "vi-VN":
                        lblSoldeAt.Text = vi_VN.Account_BalanceOf;
                        break;

                    default: //case "fr-FR":
                        lblSoldeAt.Text = fr_FR.Account_BalanceOf;
                        break;
                }

                lblSoldeAt.Text += DateTime.Now.ToString("dd/MM/yyyy") + @" : " + SoldeActuel.ToString("0.00") + @" " +
                                   CompteActuel.Currency.Symbol;
            }
            else
            {
                var d = CompteActuel.Operations.First(x2 => x2.ID == lvOps.SelectedItems[0].Text).Date;
                decimal totalc = 0;
                CompteActuel.Operations.FindAll(
                    x =>
                        CompteActuel.Operations.IndexOf(x) <=
                        CompteActuel.Operations.IndexOf(
                            CompteActuel.Operations.First(x2 => x2.ID == lvOps.SelectedItems[0].Text)))
                    .ForEach(x1 => totalc += x1.Credit);
                decimal totald = 0;
                CompteActuel.Operations.FindAll(
                    x =>
                        CompteActuel.Operations.IndexOf(x) <=
                        CompteActuel.Operations.IndexOf(
                            CompteActuel.Operations.First(x2 => x2.ID == lvOps.SelectedItems[0].Text)))
                    .ForEach(x1 => totald += x1.Debit);

                switch (Settings.Default.Lang.Name)
                {
                    case "en-US":
                        lblSoldeAt.Text = en_US.Account_BalanceOf;
                        break;

                    case "de-DE":
                        lblSoldeAt.Text = de_DE.Account_BalanceOf;
                        break;

                    case "vi-VN":
                        lblSoldeAt.Text = vi_VN.Account_BalanceOf;
                        break;

                    default: //case "fr-FR":
                        lblSoldeAt.Text = fr_FR.Account_BalanceOf;
                        break;
                }

                lblSoldeAt.Text += d.ToString("dd/MM/yyyy") + @" : " + (totalc - totald).ToString("0.00") + @" " +
                                   CompteActuel.Currency.Symbol;
            }
        }

        private string dfd
        {
            get { return Currencies.All.First(x => x.ShortName == Settings.Default.DefaultCurrency).Symbol; }
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
            btnReminder.Visible = false;

            btnGraph.Visible = false;

            lvOps.Items.Clear();

            Controls.Clear();
            InitializeComponent();
            InitRenderers();

            switch (Settings.Default.Lang.Name)
            {
                case "de-DE":
                    lblAccountName.Text = de_DE.Account_NoneLoaded;
                    lblSolde.Text = de_DE.Account_BalanceZero + dfd;
                    lblSoldeAt.Text = de_DE.Account_BalanceDateZero + dfd;
                    lblTotalCredit.Text = Resources.Account_TotalZero + dfd;
                    lblTotalDeb.Text = Resources.Account_TotalZero + dfd;
                    break;

                case "fr-FR":
                    lblAccountName.Text = fr_FR.Account_NoneLoaded;
                    lblSolde.Text = fr_FR.Account_BalanceZero + dfd;
                    lblSoldeAt.Text = fr_FR.Account_BalanceDateZero + dfd;
                    lblTotalCredit.Text = Resources.Account_TotalZero + dfd;
                    lblTotalDeb.Text = Resources.Account_TotalZero + dfd;
                    break;

                case "vi-VN":
                    lblAccountName.Text = vi_VN.Account_NoneLoaded;
                    lblSolde.Text = vi_VN.Account_BalanceZero + dfd;
                    lblSoldeAt.Text = vi_VN.Account_BalanceDateZero + dfd;
                    lblTotalCredit.Text = Resources.Account_TotalZero + dfd;
                    lblTotalDeb.Text = Resources.Account_TotalZero + dfd;
                    break;

                default: //case "en-US":
                    lblAccountName.Text = en_US.Account_NoneLoaded;
                    lblSolde.Text = en_US.Account_BalanceZero.Replace("&", dfd);
                    lblSoldeAt.Text = en_US.Account_BalanceDateZero.Replace("&", dfd);
                    lblTotalCredit.Text = dfd + en_US.Account_TotalZero;
                    lblTotalDeb.Text = dfd + en_US.Account_TotalZero;
                    break;
            }

            Text = @"CrediNET";

            //resources.ApplyResources(this, "$this");      //Not needed, controls' language updated with InitializeComponent()
        }

        public void LoadOps()
        {
            if (CompteActuel == null)
                return;

            lvOps.BeginUpdate();

            lvOps.Items.Clear();

            foreach (var op in CompteActuel.Operations)
            {
                var it = new ListViewItem {Text = op.ID, Name = op.ID};
                it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                it.SubItems.Add(op.Type);
                it.SubItems.Add(op.Budget);
                it.SubItems.Add(op.Commentary);
                it.SubItems.Add(op.Credit.ZeroAsDash() + " " + CompteActuel.Currency.Symbol);
                it.SubItems.Add(op.Debit.ZeroAsDash() + " " + CompteActuel.Currency.Symbol);
                it.BackColor = CompteActuel.Budgets[op.Budget];

                //if(!lvOps.Items.Contains(it))
                lvOps.Items.Add(it);
            }

            btnCamembert.Enabled = CompteActuel.Operations.Count != 0;

            lvOps.EndUpdate();

            decimal totalc = 0;
            CompteActuel.Operations.ForEach(x1 => totalc += x1.Credit);
            lblTotalCredit.Text = totalc.ToString("0.00") + @" " + CompteActuel.Currency.Symbol;

            decimal totald = 0;
            CompteActuel.Operations.ForEach(x1 => totald += x1.Debit);
            lblTotalDeb.Text = totald.ToString("0.00") + @" " + CompteActuel.Currency.Symbol;

            switch (Settings.Default.Lang.Name)
            {
                case "en-US":
                    lblSolde.Text = en_US.Account_Balance;
                    break;

                case "de-DE":
                    lblSolde.Text = de_DE.Account_Balance;
                    break;

                case "vi-VN":
                    lblSolde.Text = vi_VN.Account_Balance;
                    break;

                default: //case "fr-FR":
                    lblSolde.Text = fr_FR.Account_Balance;
                    break;
            }

            lblSolde.Text += (totalc - totald).ToString("0.00") + @" " + CompteActuel.Currency.Symbol;

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
            btnReminder.Visible = true;

            btnGraph.Visible = true;

            LoadOps();

            ChargerSoldeAu();

            lblAccountName.Text = CompteActuelChemin;
            Text = @"CrediNET - " + CompteActuel.Name;
            lblCrDate.Text = CompteActuel.CreationDate.ToString("dd/MM/yyyy");

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

            switch (Settings.Default.Lang.Name)
            {
                case "en-US":
                    sfdCompte.Filter = en_US.Account_FileFilter;
                    break;

                case "de-DE":
                    sfdCompte.Filter = de_DE.Account_FileFilter;
                    break;

                case "vi-VN":
                    sfdCompte.Filter = vi_VN.Account_FileFilter;
                    break;

                default: //case "fr-FR":
                    sfdCompte.Filter = fr_FR.Account_FileFilter;
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

            if (ofpCompte.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.AppStarting;
                CompteActuel = Account.FromFile(ofpCompte.FileName);
                CompteActuelChemin = ofpCompte.FileName;
                LoadAccountStuff();
                Cursor = Cursors.Default;
            }
        }

        public void LoadFile(string s)
        {
            if (CompteActuel != null)
                ClearStuff();

            Cursor = Cursors.AppStarting;
            CompteActuel = Account.FromFile(s);
            CompteActuelChemin = s;
            LoadAccountStuff();
            Cursor = Cursors.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CompteActuelChemin == null)
                enregistrerSousToolStripMenuItem_Click(sender, e);

            Cursor = Cursors.WaitCursor;
            bwkSave.RunWorkerAsync();
        }

        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CompteActuel.Encrypted)
            {
                switch (Settings.Default.Lang.Name)
                {
                    case "en-US":
                        sfdCompte.Filter = en_US.Account_FileFilterCrypted;
                        break;

                    case "de-DE":
                        sfdCompte.Filter = de_DE.Account_FileFilterCrypted;
                        break;

                    case "vi-VN":
                        sfdCompte.Filter = vi_VN.Account_FileFilterCrypted;
                        break;

                    default: //case "fr-FR":
                        sfdCompte.Filter = fr_FR.Account_FileFilterCrypted;
                        break;
                }
            }
            else
            {
                switch (Settings.Default.Lang.Name)
                {
                    case "en-US":
                        sfdCompte.Filter = en_US.Account_FileFilterSave;
                        break;

                    case "de-DE":
                        sfdCompte.Filter = de_DE.Account_FileFilterSave;
                        break;

                    case "vi-VN":
                        sfdCompte.Filter = vi_VN.Account_FileFilterSave;
                        break;

                    default: //case "fr-FR":
                        sfdCompte.Filter = fr_FR.Account_FileFilterSave;
                        break;
                }
            }
            if (sfdCompte.ShowDialog() == DialogResult.OK)
            {
                tmpf = sfdCompte.FileName;
                Cursor = Cursors.WaitCursor;
                bwkSave.RunWorkerAsync();
            }
        }


        private string tmpf = "";

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

        private void btnDelOp_Click(object sender, EventArgs e)
        {
            CompteActuel.Operations.RemoveAll(x => x.ID == lvOps.SelectedItems[0].Text);
            LoadOps();
        }

        private void btnEditOp_Click(object sender, EventArgs e)
        {
            var ae = new FrmOperation(CompteActuel, false, true,
                CompteActuel.Operations.First(x => x.ID == lvOps.SelectedItems[0].Text));
            if (ae.ShowDialog() == DialogResult.OK)
            {
                var op = new Operation
                {
                    Type = ae.cbxType.SelectedItem.ToString(),
                    Credit = ae.mupCredit.Value,
                    Debit = ae.mupDebit.Value,
                    Budget = ae.cbxBudget.SelectedText,
                    Date = ae.mcDate.SelectionStart,
                    Commentary = ae.txtComm.Text
                };

                var a =
                    CompteActuel.Operations.IndexOf(
                        CompteActuel.Operations.First(x => x.ID == lvOps.SelectedItems[0].Text));
                CompteActuel.Operations.RemoveAll(x => x.ID == lvOps.SelectedItems[0].Text);
                CompteActuel.Operations.Insert(a, op);
                LoadOps();
            }
        }

        private void btnDuplOp_Click(object sender, EventArgs e)
        {
            var ae = new FrmOperation(CompteActuel, false, true,
                CompteActuel.Operations.First(x => x.ID == lvOps.SelectedItems[0].Text));
            if (ae.ShowDialog() == DialogResult.OK)
            {
                var op = new Operation
                {
                    Type = ae.cbxType.SelectedItem.ToString(),
                    Credit = ae.mupCredit.Value,
                    Debit = ae.mupDebit.Value,
                    Budget = ae.cbxBudget.SelectedText,
                    Date = ae.mcDate.SelectionStart,
                    Commentary = ae.txtComm.Text
                };

                CompteActuel.Operations.Add(op);
                LoadOps();
            }
        }

        private void fichierCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdCSV.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfdCSV.FileName))
                    File.Delete(sfdCSV.FileName);

                using (var wr = new StreamWriter(sfdCSV.FileName, false, Encoding.GetEncoding(WIN_1252_CP)))
                {
                    switch (Settings.Default.Lang.Name)
                    {
                        case "en-US":
                            wr.WriteLine("Date;Type;Budget;Comment;Credit;Debit");
                            break;

                        case "de-DE":
                            wr.WriteLine("Date;Type;Budget;Kommentar;Kredit;Debit");
                            break;

                        case "vi-VN":
                            wr.WriteLine("Ngày;Mục;Loại;Ghi chú;Dư;Nợ");
                            break;

                        default: //case "fr-FR":
                            wr.WriteLine("Date;Type;Budget;Commentaire;Crédit;Débit");
                            break;
                    }

                    foreach (var op in CompteActuel.Operations)
                    {
                        var s = "";
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
            var a = toolStrip.Width;
            e.Graphics.DrawLine(new Pen(clr), a, 0, a, toolStrip.Height);
        }

        public ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
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
            if (sfdXLS.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfdXLS.FileName))
                    File.Delete(sfdXLS.FileName);

                /*var workbook = new Workbook();
                var sheet = workbook.Worksheets[0];
                sheet.Range["A1"].Text = "Date";
                sheet.Range["A1"].Style.Font.IsBold = true;
                sheet.Range["A1"].Style.Color = Color.Gainsboro;
                sheet.Range["A1"].Style.Font.Size = 10;
                sheet.Range["B1"].Text = "Type";
                sheet.Range["B1"].Style.Font.IsBold = true;
                sheet.Range["B1"].Style.Color = Color.Gainsboro;
                sheet.Range["B1"].Style.Font.Size = 10;
                sheet.Range["C1"].Text = "Budget";
                sheet.Range["C1"].Style.Font.IsBold = true;
                sheet.Range["C1"].Style.Color = Color.Gainsboro;
                sheet.Range["C1"].Style.Font.Size = 10;
                switch (Settings.Default.Lang.Name)
                {
                    case "en-US":
                        sheet.Range["D1"].Text = "Comment";
                        sheet.Range["D1"].Style.Font.IsBold = true;
                        sheet.Range["D1"].Style.Color = Color.Gainsboro;
                        sheet.Range["D1"].Style.Font.Size = 10;
                        sheet.Range["E1"].Text = "Credit";
                        sheet.Range["E1"].Style.Font.IsBold = true;
                        sheet.Range["E1"].Style.Color = Color.Gainsboro;
                        sheet.Range["E1"].Style.Font.Size = 10;
                        sheet.Range["F1"].Text = "Debit";
                        sheet.Range["F1"].Style.Font.IsBold = true;
                        sheet.Range["F1"].Style.Color = Color.Gainsboro;
                        sheet.Range["F1"].Style.Font.Size = 10;
                        break;

                    case "de-DE":
                        sheet.Range["D1"].Text = "Kommentar";
                        sheet.Range["D1"].Style.Font.IsBold = true;
                        sheet.Range["D1"].Style.Color = Color.Gainsboro;
                        sheet.Range["D1"].Style.Font.Size = 10;
                        sheet.Range["E1"].Text = "Kredit";
                        sheet.Range["E1"].Style.Font.IsBold = true;
                        sheet.Range["E1"].Style.Color = Color.Gainsboro;
                        sheet.Range["E1"].Style.Font.Size = 10;
                        sheet.Range["F1"].Text = "Debit";
                        sheet.Range["F1"].Style.Font.IsBold = true;
                        sheet.Range["F1"].Style.Color = Color.Gainsboro;
                        sheet.Range["F1"].Style.Font.Size = 10;
                        break;

                    default:
                        sheet.Range["D1"].Text = "Commentaire";
                        sheet.Range["D1"].Style.Font.IsBold = true;
                        sheet.Range["D1"].Style.Color = Color.Gainsboro;
                        sheet.Range["D1"].Style.Font.Size = 10;
                        sheet.Range["E1"].Text = "Crédit";
                        sheet.Range["E1"].Style.Font.IsBold = true;
                        sheet.Range["E1"].Style.Color = Color.Gainsboro;
                        sheet.Range["E1"].Style.Font.Size = 10;
                        sheet.Range["F1"].Text = "Débit";
                        sheet.Range["F1"].Style.Font.IsBold = true;
                        sheet.Range["F1"].Style.Color = Color.Gainsboro;
                        sheet.Range["F1"].Style.Font.Size = 10;
                        break;
                }

                foreach (var op in CompteActuel.Operations)
                {
                    var id = CompteActuel.Operations.IndexOf(op) + 2;

                    sheet.Range[id, 1].Text = op.Date.ToString("dd/MM/yyyy");
                    sheet.Range[id, 1].DataValidation.AllowType = CellDataType.Date;
                    sheet.Range[id, 2].Text = op.Type;
                    sheet.Range[id, 3].Text = op.Budget;
                    sheet.Range[id, 4].Text = op.Commentary;
                    sheet.Range[id, 5].Text = op.Credit.ZeroAsDash() + " " + CompteActuel.Currency.Symbol;
                    sheet.Range[id, 5].Style.Font.Color = Color.White;
                    sheet.Range[id, 5].Style.Color = Color.Green;
                    sheet.Range[id, 6].Text = op.Debit.ZeroAsDash() + " " + CompteActuel.Currency.Symbol;
                    sheet.Range[id, 6].Style.Font.Color = Color.White;
                    sheet.Range[id, 6].Style.Color = Color.Red;
                }

                sheet.AutoFitColumn(1);
                sheet.AutoFitColumn(2);
                sheet.AutoFitColumn(3);
                sheet.AutoFitColumn(4);
                sheet.AutoFitColumn(5);
                sheet.AutoFitColumn(6);
                workbook.SaveToFile(sfdXLS.FileName, ExcelVersion.Version97to2003);
                Process.Start(sfdXLS.FileName);*/
            }
        }

        private void fichierExcelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (sfdXLSX.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfdXLSX.FileName))
                    File.Delete(sfdXLSX.FileName);

                using (var pkg = new ExcelPackage())
                {
                    var w = pkg.Workbook.Worksheets.Add(CompteActuel.Name);

                    //headers
                    switch (Settings.Default.Lang.Name)
                    {
                        case "en-US":
                            w.Cells["A1"].Value = "Date";
                            w.Cells["B1"].Value = "Type";
                            w.Cells["C1"].Value = "Budget";
                            w.Cells["D1"].Value = "Comment";
                            w.Cells["E1"].Value = "Credit";
                            w.Cells["F1"].Value = "Debit";
                            break;

                        case "de-DE":
                            w.Cells["A1"].Value = "Datum";
                            w.Cells["B1"].Value = "Typ";
                            w.Cells["C1"].Value = "Budget";
                            w.Cells["D1"].Value = "Kommentar";
                            w.Cells["E1"].Value = "Verdienst";
                            w.Cells["F1"].Value = "Soll";
                            break;
                        default: //case "fr-FR":
                            w.Cells["A1"].Value = "Date";
                            w.Cells["B1"].Value = "Type";
                            w.Cells["C1"].Value = "Budget";
                            w.Cells["D1"].Value = "Commentaire";
                            w.Cells["E1"].Value = "Crédit";
                            w.Cells["F1"].Value = "Débit";
                            break;
                    }
                    w.Cells["A1:F1"].Style.Font.Bold = true;
                    w.Cells["A1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    w.Cells["A1:F1"].Style.Fill.BackgroundColor.SetColor(Color.Gainsboro);
                    w.Cells["A1:F1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    foreach (var op in CompteActuel.Operations)
                    {
                        var id = CompteActuel.Operations.IndexOf(op) + 2;
                        w.Cells[id, 1].Value = op.Date.ToString("dd/MM/yyyy");
                        w.Cells[id, 2].Value = op.Type;
                        w.Cells[id, 3].Value = op.Budget;
                        w.Cells[id, 4].Value = op.Commentary;
                        w.Cells[id, 5, id, 6].Style.Numberformat.Format = @"#,##0.00\ [$€-1]";
                        w.Cells[id, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        w.Cells[id, 5].Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                        w.Cells[id, 5].Value = op.Credit;
                        w.Cells[id, 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        w.Cells[id, 6].Style.Fill.BackgroundColor.SetColor(Color.Red);
                        w.Cells[id, 6].Value = op.Debit;

                        //budget background
                        w.Cells[id, 1, id, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        w.Cells[id, 1, id, 4].Style.Fill.BackgroundColor.SetColor(CompteActuel.Budgets[op.Budget]);
                    }


                    //balance
                    w.Cells[CompteActuel.Operations.Count + 4, 4].Value = lblSolde.Text;

                    w.Cells.AutoFitColumns(1);
                    w.Cells.AutoFitColumns(2);
                    w.Cells.AutoFitColumns(3);
                    w.Cells.AutoFitColumns(4);
                    w.Cells.AutoFitColumns(5);
                    w.Cells.AutoFitColumns(6);
                    if (w.Column(4).Width <= 50) w.Column(4).Width = 50;

                    pkg.SaveAs(new FileInfo(sfdXLSX.FileName));
                }

                Process.Start(sfdXLSX.FileName);
            }
        }

        private void classeurOpenOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdODS.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfdODS.FileName))
                    File.Delete(sfdODS.FileName);

                var doc = new SpreadsheetDocument();
                doc.New();
                var tbl = new Table(doc, CompteActuel.Name, "account");

                //headers
                tbl.AddCell(1, 1, "Date", Color.Gainsboro, true, Color.Black);
                tbl.AddCell(1, 2, "Type", Color.Gainsboro, true, Color.Black);
                tbl.AddCell(1, 3, "Budget", Color.Gainsboro, true, Color.Black);
                switch (Settings.Default.Lang.Name)
                {
                    case "en-US":
                        tbl.AddCell(1, 4, "Commentary", Color.Gainsboro, true, Color.Black);
                        tbl.AddCell(1, 5, "Credit", Color.Gainsboro, true, Color.Black);
                        tbl.AddCell(1, 6, "Debit", Color.Gainsboro, true, Color.Black);
                        break;
                    case "de-DE":
                        tbl.AddCell(1, 4, "Kommentar", Color.Gainsboro, true, Color.Black);
                        tbl.AddCell(1, 5, "Kredit", Color.Gainsboro, true, Color.Black);
                        tbl.AddCell(1, 6, "Debit", Color.Gainsboro, true, Color.Black);
                        break;
                    default:
                        tbl.AddCell(1, 4, "Commentaire", Color.Gainsboro, true, Color.Black);
                        tbl.AddCell(1, 5, "Crédit", Color.Gainsboro, true, Color.Black);
                        tbl.AddCell(1, 6, "Débit", Color.Gainsboro, true, Color.Black);
                        break;
                }
                foreach (var op in CompteActuel.Operations)
                {
                    var id = CompteActuel.Operations.IndexOf(op) + 2;

                    tbl.AddCell(id, 1, op.Date.ToString("dd/MM/yyyy"), Color.White, false, Color.Black);
                    tbl.AddCell(id, 2, op.Type, Color.White, false, Color.Black);
                    tbl.AddCell(id, 3, op.Budget, Color.White, false, Color.Black);
                    tbl.AddCell(id, 4, op.Commentary, Color.White, false, Color.Black);
                    tbl.AddCell(id, 5, op.Credit + " " + CompteActuel.Currency.Symbol, Color.White, false, Color.Black);
                    tbl.AddCell(id, 6, op.Debit + " " + CompteActuel.Currency.Symbol, Color.White, false, Color.Black);
                }

                doc.TableCollection.Add(tbl);
                doc.SaveTo(sfdODS.FileName);
                Process.Start(sfdODS.FileName);
            }
        }

        private void btnOpt_Click_1(object sender, EventArgs e)
        {
            new FrmOptions().ShowDialog();
            if (CompteActuel == null) ClearStuff();
            //DevExt.ExchangeRate(Devises.Euro, Devises.US_Dollar);
        }

        private void btnCamembert_Click(object sender, EventArgs e)
        {
            new FrmGraph(1, filteredAccount ?? CompteActuel).ShowDialog(this);
        }

        private void btnCourbes_Click(object sender, EventArgs e)
        {
            new FrmGraph(2, filteredAccount ?? CompteActuel).ShowDialog(this);
        }

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            var ae = new FrmCreateAccount(CompteActuel);
            if (ae.ShowDialog() == DialogResult.OK)
            {
                CompteActuel.Name = ae.txtNom.Text;
                if (ae.txtPasse.Font.Style != FontStyle.Italic) CompteActuel.DefPass(ae.txtPasse.Text);
                CompteActuel.Budgets.Clear();
                ae.lbxBudgets.Items.OfType<ListViewItem>().All(x =>
                {
                    CompteActuel.Budgets.Add(x.Text, x.BackColor);
                    return true;
                });

                CompteActuel.ChangeCurrency(Currencies.All.First(x => x.Name == ae.cbxDevise.SelectedItem.ToString()),
                    CompteActuel.Currency != Currencies.All.First(x => x.Name == ae.cbxDevise.SelectedItem.ToString()));

                CompteActuel.Encrypted = ae.cbxCrypt.Checked;

                LoadAccountStuff();
            }
        }

        private bool onlytime = true;

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
            var of = new FrmOpFilter(CompteActuel);

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
                LoadOps(null, null, null, null, null, null, null, null);
                filteredAccount = null;
                btnFilterOp.Checked = false;
            }
            else
            {
                if (of.ShowDialog() != DialogResult.OK) return;
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
                    budget = of.cbxBudget.SelectedItem.Text;
                }

                LoadOps(dtFrom, dtTo, creditFrom, creditTo, debitFrom, debitTo, type, budget);
                btnFilterOp.Checked = true;
            }
        }

        public void LoadOps(DateTime? dtFrom, DateTime? dtTo, decimal? creditFrom, decimal? creditTo, decimal? debitFrom,
            decimal? debitTo, string type, string budget)
        {
            if (CompteActuel == null)
                return;

            lvOps.BeginUpdate();

            lvOps.Items.Clear();

            var queryOps =
                from op in CompteActuel.Operations.AsQueryable()
                select op;

            if (dtFrom != null && dtTo != null)
                queryOps =
                    queryOps.Where(
                        op =>
                            DateTime.Compare(op.Date, (DateTime) dtFrom) >= 0 &&
                            DateTime.Compare(op.Date, (DateTime) dtTo) <= 0);

            if (creditFrom.HasValue && creditTo.HasValue)
                queryOps = queryOps.Where(op => op.Credit >= creditFrom && op.Credit <= creditTo);

            if (debitFrom.HasValue && debitTo.HasValue)
                queryOps = queryOps.Where(op => op.Debit >= debitFrom && op.Debit <= debitTo);

            if (type != null)
                queryOps = queryOps.Where(op => op.Type.Equals(type));

            if (budget != null)
                queryOps = queryOps.Where(op => op.Budget.Equals(budget));

            //filteredAccount is used as input for graph representations
            filteredAccount = new Account {Name = CompteActuel.Name, Currency = CompteActuel.Currency};

            foreach (var op in queryOps)
            {
                var it = new ListViewItem {Text = op.ID, Name = op.ID};
                it.SubItems.Add(op.Date.ToString("dd/MM/yyyy"));
                it.SubItems.Add(op.Type);
                it.SubItems.Add(op.Budget);
                it.SubItems.Add(op.Commentary);
                it.SubItems.Add(op.Credit.ZeroAsDash() + " " + CompteActuel.Currency.Symbol);
                it.SubItems.Add(op.Debit.ZeroAsDash() + " " + CompteActuel.Currency.Symbol);
                it.BackColor = CompteActuel.Budgets[op.Budget];

                //if(!lvOps.Items.Contains(it))
                lvOps.Items.Add(it);

                filteredAccount.Operations.Add(op);
            }

            btnCamembert.Enabled = CompteActuel.Operations.Count != 0;

            lvOps.EndUpdate();

            decimal totalc = 0;
            queryOps.ToList().ForEach(x1 => totalc += x1.Credit);
            lblTotalCredit.Text = totalc.ToString("0.00") + @" " + CompteActuel.Currency.Symbol;

            decimal totald = 0;
            queryOps.ToList().ForEach(x1 => totald += x1.Debit);
            lblTotalDeb.Text = totald.ToString("0.00") + @" " + CompteActuel.Currency.Symbol;

            switch (Settings.Default.Lang.Name)
            {
                case "en-US":
                    lblSolde.Text = en_US.Account_Balance;
                    break;

                case "de-DE":
                    lblSoldeAt.Text = de_DE.Account_Balance;
                    break;

                case "vi-VN":
                    lblSoldeAt.Text = vi_VN.Account_Balance;
                    break;

                default: //case "fr-FR":
                    lblSolde.Text = fr_FR.Account_Balance;
                    break;
            }

            lblSolde.Text += (totalc - totald).ToString("0.00") + @" " + CompteActuel.Currency.Symbol;

            SoldeActuel = totalc - totald;
        }

        private void btnReminder_Click(object sender, EventArgs e)
        {
            var frm = new FrmReminder(CompteActuel);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadOps();
            }
        }

        private void lvOps_DoubleClick(object sender, EventArgs e)
        {
            if (lvOps.SelectedItems.Count == 0 && CompteActuel != null)
            {
                btnEditAcc_Click(sender, e);
            }
            else if (lvOps.SelectedItems.Count != 0)
            {
                btnEditOp_Click(sender, e);
            }
        }

        private void MainWindow_SizeChanged(object sender, EventArgs e)
        {
            // 685
            clmnComm.Width = ClientSize.Width - 372;
        }

        private void bwkSave_DoWork(object sender, DoWorkEventArgs e)
        {
            if (tmpf == "")
                CompteActuel.Save();
            else
                CompteActuel.SaveAs(tmpf);
        }

        private void bwkSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            tmpf = "";
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfdPDF.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfdPDF.FileName))
                    File.Delete(sfdPDF.FileName);

                /*var workbook = new Workbook();
                var sheet = workbook.Worksheets[0];
                sheet.Range["A1"].Text = "Date";
                sheet.Range["A1"].Style.Font.IsBold = true;
                sheet.Range["A1"].Style.Color = Color.Gainsboro;
                sheet.Range["A1"].Style.Font.Size = 10;
                sheet.Range["B1"].Text = "Type";
                sheet.Range["B1"].Style.Font.IsBold = true;
                sheet.Range["B1"].Style.Color = Color.Gainsboro;
                sheet.Range["B1"].Style.Font.Size = 10;
                sheet.Range["C1"].Text = "Budget";
                sheet.Range["C1"].Style.Font.IsBold = true;
                sheet.Range["C1"].Style.Color = Color.Gainsboro;
                sheet.Range["C1"].Style.Font.Size = 10;
                switch (Settings.Default.Lang.Name)
                {
                    case "en-US":
                        sheet.Range["D1"].Text = "Comment";
                        sheet.Range["D1"].Style.Font.IsBold = true;
                        sheet.Range["D1"].Style.Color = Color.Gainsboro;
                        sheet.Range["D1"].Style.Font.Size = 10;
                        sheet.Range["E1"].Text = "Credit";
                        sheet.Range["E1"].Style.Font.IsBold = true;
                        sheet.Range["E1"].Style.Color = Color.Gainsboro;
                        sheet.Range["E1"].Style.Font.Size = 10;
                        sheet.Range["F1"].Text = "Debit";
                        sheet.Range["F1"].Style.Font.IsBold = true;
                        sheet.Range["F1"].Style.Color = Color.Gainsboro;
                        sheet.Range["F1"].Style.Font.Size = 10;
                        break;

                    case "de-DE":
                        sheet.Range["D1"].Text = "Kommentar";
                        sheet.Range["D1"].Style.Font.IsBold = true;
                        sheet.Range["D1"].Style.Color = Color.Gainsboro;
                        sheet.Range["D1"].Style.Font.Size = 10;
                        sheet.Range["E1"].Text = "Kredit";
                        sheet.Range["E1"].Style.Font.IsBold = true;
                        sheet.Range["E1"].Style.Color = Color.Gainsboro;
                        sheet.Range["E1"].Style.Font.Size = 10;
                        sheet.Range["F1"].Text = "Debit";
                        sheet.Range["F1"].Style.Font.IsBold = true;
                        sheet.Range["F1"].Style.Color = Color.Gainsboro;
                        sheet.Range["F1"].Style.Font.Size = 10;
                        break;

                    default:
                        sheet.Range["D1"].Text = "Commentaire";
                        sheet.Range["D1"].Style.Font.IsBold = true;
                        sheet.Range["D1"].Style.Color = Color.Gainsboro;
                        sheet.Range["D1"].Style.Font.Size = 10;
                        sheet.Range["E1"].Text = "Crédit";
                        sheet.Range["E1"].Style.Font.IsBold = true;
                        sheet.Range["E1"].Style.Color = Color.Gainsboro;
                        sheet.Range["E1"].Style.Font.Size = 10;
                        sheet.Range["F1"].Text = "Débit";
                        sheet.Range["F1"].Style.Font.IsBold = true;
                        sheet.Range["F1"].Style.Color = Color.Gainsboro;
                        sheet.Range["F1"].Style.Font.Size = 10;
                        break;
                }

                foreach (var op in CompteActuel.Operations)
                {
                    var id = CompteActuel.Operations.IndexOf(op) + 2;

                    sheet.Range[id, 1].Text = op.Date.ToString("dd/MM/yyyy");
                    sheet.Range[id, 1].DataValidation.AllowType = CellDataType.Date;
                    sheet.Range[id, 2].Text = op.Type;
                    sheet.Range[id, 3].Text = op.Budget;
                    sheet.Range[id, 4].Text = op.Commentary;
                    sheet.Range[id, 5].Text = op.Credit.ZeroAsDash() + " " + CompteActuel.Currency.Symbol;
                    sheet.Range[id, 5].Style.Font.Color = Color.White;
                    sheet.Range[id, 5].Style.Color = Color.Green;
                    sheet.Range[id, 6].Text = op.Debit.ZeroAsDash() + " " + CompteActuel.Currency.Symbol;

                    sheet.Range[id, 6].Style.Font.Color = Color.White;
                    sheet.Range[id, 6].Style.Color = Color.Red;
                }


                sheet.Columns[0].ColumnWidth = 10.5;
                sheet.Columns[1].ColumnWidth = 5.5;
                sheet.Columns[2].ColumnWidth = 15;
                sheet.Columns[3].ColumnWidth = 27.5;
                sheet.Columns[4].ColumnWidth = 15;
                sheet.Columns[5].ColumnWidth = 15;

                //borders
                sheet.Range["A1:F1"].Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
                sheet.Range[2, 1, CompteActuel.Operations.Count + 1, 6].Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;

                workbook.SaveToFile(sfdPDF.FileName, FileFormat.PDF);
                Process.Start(sfdPDF.FileName);*/
            }
        }
    }
}