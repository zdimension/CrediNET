using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace CrediNET
{
    public partial class FrmReminder : Form
    {
        private Account CompteActuel;

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
            if (frm.ShowDialog() != DialogResult.OK) return;
            var op = new ReminderOperation
            {
                Type = frm.cbxType.SelectedItem.ToString(),
                Credit = frm.mupCredit.Value,
                Debit = frm.mupDebit.Value,
                Budget = frm.cbxBudget.SelectedText,
                DueDate = frm.mcDate.SelectionStart,
                Commentary = frm.txtComm.Text,
                NbOfRepetition = frm.nudNbOfRepetitions.Value,
                RepetitionType = (ReminderOperation.ERepititionType) frm.cbxRepetitionType.SelectedIndex,
                AutomaticallyAdded = frm.cbAddOperations.Checked
            };

            //Add new reminder operation
            CompteActuel.ReminderOperations.Add(op);

            LoadReminderOps();

            if (frm.cbAddOperations.Checked)
                //Add normal operations generated from the reminder operation
                op.addNormalOperations(CompteActuel);
            else
                ReminderOperation.deleteNormalOperations(CompteActuel, op.ID);
        }

        public void LoadReminderOps()
        {
            if (CompteActuel == null)
                return;

            lvReminderOps.BeginUpdate();

            lvReminderOps.Items.Clear();

            foreach (var op in CompteActuel.ReminderOperations)
            {
                var it = new ListViewItem {Text = op.ID, Name = op.ID};
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
            ReminderOperation.deleteNormalOperations(CompteActuel, lvReminderOps.SelectedItems[0].Text);
            LoadReminderOps();
        }

        private void btnModifyReminder_Click(object sender, EventArgs e)
        {
            var frm = new FrmReminderOperation(CompteActuel, false, true,
                CompteActuel.ReminderOperations.First(x => x.ID == lvReminderOps.SelectedItems[0].Text));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var op = new ReminderOperation(lvReminderOps.SelectedItems[0].Text)
                {
                    Type = frm.cbxType.SelectedItem.ToString(),
                    Credit = frm.mupCredit.Value,
                    Debit = frm.mupDebit.Value,
                    Budget = frm.cbxBudget.SelectedText,
                    DueDate = frm.mcDate.SelectionStart,
                    Commentary = frm.txtComm.Text,
                    NbOfRepetition = (int) frm.nudNbOfRepetitions.Value,
                    RepetitionType = (ReminderOperation.ERepititionType) frm.cbxRepetitionType.SelectedIndex,
                    AutomaticallyAdded = frm.cbAddOperations.Checked
                };

                var a =
                    CompteActuel.ReminderOperations.IndexOf(
                        CompteActuel.ReminderOperations.First(x => x.ID == lvReminderOps.SelectedItems[0].Text));
                CompteActuel.ReminderOperations.RemoveAll(x => x.ID == lvReminderOps.SelectedItems[0].Text);
                CompteActuel.ReminderOperations.Insert(a, op);

                //Delete old normal operations
                ReminderOperation.deleteNormalOperations(CompteActuel, op.ID);

                LoadReminderOps();

                if (frm.cbAddOperations.Checked)
                    //Add normal operations generated from the reminder operation
                    op.addNormalOperations(CompteActuel);
            }
        }

        private void FrmReminder_Load(object sender, EventArgs e)
        {
            //Initialize reminder operations and reminder calendar
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
            var today = mthCalReminder.SelectionStart;
            var numberOfDaysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

            var startOfMonth = new DateTime(today.Year, today.Month, 1);
            var endOfMonth = new DateTime(today.Year, today.Month, numberOfDaysInMonth);

            //Filter only reminder operations that fit the calendar
            var ops = ReminderOperation.filterOperation(CompteActuel.ForecastOperations, startOfMonth, endOfMonth);

            calReminder.SetViewRange(startOfMonth, endOfMonth);
            foreach (var item in ops)
            {
                var cal = new CalendarItem(calReminder, item.Date, item.Date, item.Budget);
                cal.ApplyColor(Color.FromName(CompteActuel.Budgets[item.Budget].ToKnownColor().ToString()));
                calReminder.Items.Add(cal);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
        }
    }
}