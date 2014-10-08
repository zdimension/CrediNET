namespace CrediNET
{
    partial class FrmReminder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReminder));
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.mthCalReminder = new System.Windows.Forms.MonthCalendar();
            this.lvReminderOps = new System.Windows.Forms.ListView();
            this.clmnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnBudget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnDueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.calReminder = new System.Windows.Forms.Calendar.Calendar();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnModifyReminder = new System.Windows.Forms.Button();
            this.btnDeleteReminder = new System.Windows.Forms.Button();
            this.btnAddReminder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mthCalReminder
            // 
            resources.ApplyResources(this.mthCalReminder, "mthCalReminder");
            this.mthCalReminder.Name = "mthCalReminder";
            this.mthCalReminder.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mthCalReminder_DateChanged);
            // 
            // lvReminderOps
            // 
            resources.ApplyResources(this.lvReminderOps, "lvReminderOps");
            this.lvReminderOps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnId,
            this.clmnBudget,
            this.clmnDueDate});
            this.lvReminderOps.FullRowSelect = true;
            this.lvReminderOps.GridLines = true;
            this.lvReminderOps.Name = "lvReminderOps";
            this.lvReminderOps.UseCompatibleStateImageBehavior = false;
            this.lvReminderOps.View = System.Windows.Forms.View.Details;
            // 
            // clmnId
            // 
            resources.ApplyResources(this.clmnId, "clmnId");
            // 
            // clmnBudget
            // 
            resources.ApplyResources(this.clmnBudget, "clmnBudget");
            // 
            // clmnDueDate
            // 
            resources.ApplyResources(this.clmnDueDate, "clmnDueDate");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // calReminder
            // 
            resources.ApplyResources(this.calReminder, "calReminder");
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calReminder.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calReminder.Name = "calReminder";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnModifyReminder
            // 
            resources.ApplyResources(this.btnModifyReminder, "btnModifyReminder");
            this.btnModifyReminder.Image = global::CrediNET.Properties.Resources.page_edit;
            this.btnModifyReminder.Name = "btnModifyReminder";
            this.btnModifyReminder.UseVisualStyleBackColor = true;
            this.btnModifyReminder.Click += new System.EventHandler(this.btnModifyReminder_Click);
            // 
            // btnDeleteReminder
            // 
            resources.ApplyResources(this.btnDeleteReminder, "btnDeleteReminder");
            this.btnDeleteReminder.Image = global::CrediNET.Properties.Resources.page_delete;
            this.btnDeleteReminder.Name = "btnDeleteReminder";
            this.btnDeleteReminder.UseVisualStyleBackColor = true;
            this.btnDeleteReminder.Click += new System.EventHandler(this.btnDeleteReminder_Click);
            // 
            // btnAddReminder
            // 
            resources.ApplyResources(this.btnAddReminder, "btnAddReminder");
            this.btnAddReminder.Image = global::CrediNET.Properties.Resources.page_add;
            this.btnAddReminder.Name = "btnAddReminder";
            this.btnAddReminder.UseVisualStyleBackColor = true;
            this.btnAddReminder.Click += new System.EventHandler(this.btnAddReminder_Click);
            // 
            // FrmReminder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnModifyReminder);
            this.Controls.Add(this.btnDeleteReminder);
            this.Controls.Add(this.btnAddReminder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvReminderOps);
            this.Controls.Add(this.calReminder);
            this.Controls.Add(this.mthCalReminder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReminder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmReminder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mthCalReminder;
        private System.Windows.Forms.Calendar.Calendar calReminder;
        private System.Windows.Forms.ListView lvReminderOps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddReminder;
        private System.Windows.Forms.Button btnDeleteReminder;
        private System.Windows.Forms.Button btnModifyReminder;
        private System.Windows.Forms.ColumnHeader clmnId;
        private System.Windows.Forms.ColumnHeader clmnBudget;
        private System.Windows.Forms.ColumnHeader clmnDueDate;
        private System.Windows.Forms.Button btnOK;
    }
}