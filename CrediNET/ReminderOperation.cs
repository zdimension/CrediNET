using System;
using System.Collections.Generic;

namespace CrediNET
{
    [Serializable]
    public class ReminderOperation
    {
        private string _id = "";

        /// <summary>
        /// GUID of reminder
        /// </summary>
        public string ID
        {
            get { return _id; }
        }

        /// <summary>
        /// Due date of reminder
        /// </summary>
        public DateTime DueDate
        {
            get;
            set;
        }

        /// <summary>
        /// Commentary
        /// </summary>
        public string Commentary
        {
            get;
            set;
        }

        /// <summary>
        /// Credit
        /// </summary>
        public decimal Credit
        {
            get;
            set;
        }

        /// <summary>
        /// Debit
        /// </summary>
        public decimal Debit
        {
            get;
            set;
        }

        /// <summary>
        /// Type
        /// </summary>
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// Category
        /// </summary>
        public string Budget
        {
            get;
            set;
        }

        /// <summary>
        /// Number of repetition
        /// </summary>
        public decimal NbOfRepetition
        {
            get;
            set;
        }

        public enum ERepititionType
        {
            Day = 0, Week = 1, Month = 2, Year = 3,
            Monday = 4,
            Tuesday = 5,
            Wednesday = 6,
            Thursday = 7,
            Friday = 8,
            Saturday = 9,
            Sunday = 10
        }

        /// <summary>
        /// Repetition type
        /// </summary>
        public ERepititionType RepetitionType
        {
            get;
            set;
        }

        /// <summary>
        /// Simple constructor
        /// </summary>
        public ReminderOperation()
        {
            _id = System.Guid.NewGuid().ToString();
            ForcastOperations = new List<Operation>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The GUID</param>
        public ReminderOperation(string id)
        {
            this._id = id;
            ForcastOperations = new List<Operation>();
        }

        /// <summary>
        /// Forcast Operations
        /// </summary>
        public List<Operation> ForcastOperations
        {
            get;
            set;
        }

        private List<Operation> populateDailyOperations()
        {
            List<Operation> lstOps = new List<Operation>();

            for (int i = 0; i < this.NbOfRepetition; i++)
            {
                lstOps.Add(new Operation(this.DueDate.AddDays(i), this.Commentary, this.Credit, this.Debit, this.Type, this.Budget, false));
            }
            return lstOps;
        }

        private List<Operation> populateWeeklyOperations()
        {
            DateTime beginningDay = this.DueDate;
            List<Operation> lstOps = new List<Operation>();

            for (int i = 0; i < this.NbOfRepetition; i++)
            {
                lstOps.Add(new Operation(this.DueDate.AddDays(i * 7), this.Commentary, this.Credit, this.Debit, this.Type, this.Budget, false));
            }
            return lstOps;
        }

        private List<Operation> populateMonthlyOperations()
        {
            DateTime beginningDay = this.DueDate;
            List<Operation> lstOps = new List<Operation>();

            for (int i = 0; i < this.NbOfRepetition; i++)
            {
                lstOps.Add(new Operation(this.DueDate.AddMonths(i), this.Commentary, this.Credit, this.Debit, this.Type, this.Budget, false));
            }
            return lstOps;
        }

        private List<Operation> populateYearlyOperations()
        {
            DateTime beginningDay = this.DueDate;
            List<Operation> lstOps = new List<Operation>();

            for (int i = 0; i < this.NbOfRepetition; i++)
            {
                lstOps.Add(new Operation(this.DueDate.AddYears(i), this.Commentary, this.Credit, this.Debit, this.Type, this.Budget, false));
            }
            return lstOps;
        }

        public void populateForcastOperations()
        {
            switch (this.RepetitionType)
            {
                case ERepititionType.Day:
                    ForcastOperations = populateDailyOperations();
                    break;
                case ERepititionType.Week:
                    ForcastOperations = populateWeeklyOperations();
                    break;
                case ERepititionType.Month:
                    ForcastOperations = populateMonthlyOperations();
                    break;
                case ERepititionType.Year:
                    ForcastOperations = populateYearlyOperations();
                    break;
                default:
                    break;
            }
        }

        public static List<Operation> filterOperation(List<Operation> lstOps, DateTime start, DateTime end)
        {
            return lstOps.FindAll(x => {return DateTime.Compare(x.Date, start) >= 0 && DateTime.Compare(x.Date, end) <= 0; });
        }
    }
}