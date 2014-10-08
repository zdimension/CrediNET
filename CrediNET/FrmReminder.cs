using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace CrediNET
{
    public partial class FrmReminder : Form
    {
        Account CompteActuel;

        public FrmReminder()
        {
            InitializeComponent();
        }

        public FrmReminder(Account CompteActuel)
        {
            InitializeComponent();
            this.CompteActuel = CompteActuel;
        }

        private void btnAddReminder_Click(object sender, EventArgs e)
        {
            var frm = new FrmReminderOperation(CompteActuel);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ReminderOperation op = new ReminderOperation();
                op.Type = frm.cbxType.SelectedItem.ToString();
                op.Credit = frm.mupCredit.Value;
                op.Debit = frm.mupDebit.Value;
                op.Budget = frm.cbxBudget.SelectedText;
                op.DueDate = frm.mcDate.SelectionStart;
                op.Commentary = frm.txtComm.Text;
                op.NbOfRepetition = frm.nudNbOfRepetitions.Value;
                op.RepetitionType = (ReminderOperation.ERepititionType)frm.cbxRepetitionType.SelectedIndex;
                
                CompteActuel.ReminderOperations.Add(op);
                LoadReminderOps();
            }
        }

        public void LoadReminderOps()
        {
            if (CompteActuel == null)
                return;

            lvReminderOps.BeginUpdate();

            lvReminderOps.Items.Clear();

            foreach (ReminderOperation op in CompteActuel.ReminderOperations)
            {
                ListViewItem it = new ListViewItem();
                it.Text = op.ID;
                it.Name = op.ID;
                it.SubItems.Add(op.Budget);
                it.SubItems.Add(op.DueDate.ToString("dd/MM/yyyy"));

                lvReminderOps.Items.Add(it);
            }

            lvReminderOps.EndUpdate();
            CompteActuel.populateForcastOperations();
            loadCalendar();
        }

        private void btnDeleteReminder_Click(object sender, EventArgs e)
        {
            CompteActuel.ReminderOperations.RemoveAll(x => x.ID == lvReminderOps.SelectedItems[0].Text);
            LoadReminderOps();
        }

        private void btnModifyReminder_Click(object sender, EventArgs e)
        {
            var frm = new FrmReminderOperation(CompteActuel, false, true, CompteActuel.ReminderOperations.First(x => x.ID == lvReminderOps.SelectedItems[0].Text));
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ReminderOperation op = new ReminderOperation();
                op.Type = frm.cbxType.SelectedItem.ToString();
                op.Credit = frm.mupCredit.Value;
                op.Debit = frm.mupDebit.Value;
                op.Budget = frm.cbxBudget.SelectedText;
                op.DueDate = frm.mcDate.SelectionStart;
                op.Commentary = frm.txtComm.Text;
                op.NbOfRepetition = (int)frm.nudNbOfRepetitions.Value;
                op.RepetitionType = (ReminderOperation.ERepititionType)frm.cbxRepetitionType.SelectedIndex;

                int a = CompteActuel.ReminderOperations.IndexOf(CompteActuel.ReminderOperations.First(x => x.ID == lvReminderOps.SelectedItems[0].Text));
                CompteActuel.ReminderOperations.RemoveAll(x => x.ID == lvReminderOps.SelectedItems[0].Text);
                CompteActuel.ReminderOperations.Insert(a, op);
                LoadReminderOps();
            }
        }

        private void FrmReminder_Load(object sender, EventArgs e)
        {
            LoadReminderOps();
            loadCalendar();
        }

        private void mthCalReminder_DateChanged(object sender, DateRangeEventArgs e)
        {
            loadCalendar();
        }
        
        private void loadCalendar()
        {
            CompteActuel.populateForcastOperations();
            calReminder.Items.Clear();
            DateTime today = mthCalReminder.SelectionStart;
            int numberOfDaysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = new DateTime(today.Year, today.Month, numberOfDaysInMonth);

            List<Operation> ops = ReminderOperation.filterOperation(CompteActuel.ForecastOperations, startOfMonth, endOfMonth);

            calReminder.SetViewRange(startOfMonth, endOfMonth);
            foreach (var item in ops)
            {
                CalendarItem cal = new CalendarItem(calReminder, item.Date, item.Date, item.Budget);
                cal.ApplyColor(Color.FromName(CompteActuel.Budgets[item.Budget].ToKnownColor().ToString()));
                calReminder.Items.Add(cal);    
            }
            
        }
    }
}
