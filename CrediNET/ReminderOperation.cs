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

        public bool AutomaticallyAdded
        {
            get;
            set;
        }
        /// <summary>
        /// Simple constructor
        /// </summary>
        public ReminderOperation()
        {
            _id = Guid.NewGuid().ToString();
            ForcastOperations = new List<Operation>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The GUID</param>
        public ReminderOperation(string id)
        {
            _id = id;
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

        /// <summary>
        /// Generate daily forcast operations
        /// </summary>
        /// <returns>A list of daily forcast operations</returns>
        private List<Operation> populateDailyOperations()
        {
            var lstOps = new List<Operation>();

            for (var i = 0; i < NbOfRepetition; i++)
            {
                //Consider only due dates in the future
                if (DateTime.Compare(DueDate.AddDays(i), DateTime.Now) >= 0)
                    lstOps.Add(new Operation(DueDate.AddDays(i), Commentary, Credit, Debit, Type, Budget, ID));
            }
            return lstOps;
        }

        /// <summary>
        /// Generate weekly forcast operations
        /// </summary>
        /// <returns>A list of weekly forcast operations</returns>
        private List<Operation> populateWeeklyOperations()
        {
            var beginningDay = DueDate;
            var lstOps = new List<Operation>();

            for (var i = 0; i < NbOfRepetition; i++)
            {
                //Consider only due dates in the future
                if (DateTime.Compare(DueDate.AddDays(i * 7), DateTime.Now) >= 0)
                    lstOps.Add(new Operation(DueDate.AddDays(i * 7), Commentary, Credit, Debit, Type, Budget, ID));
            }
            return lstOps;
        }

        /// <summary>
        /// Generate monthly forcast operations
        /// </summary>
        /// <returns>A list of monthly forcast operations</returns>
        private List<Operation> populateMonthlyOperations()
        {
            var beginningDay = DueDate;
            var lstOps = new List<Operation>();

            for (var i = 0; i < NbOfRepetition; i++)
            {
                //Consider only due dates in the future
                if (DateTime.Compare(DueDate.AddMonths(i), DateTime.Now) >= 0)
                    lstOps.Add(new Operation(DueDate.AddMonths(i), Commentary, Credit, Debit, Type, Budget, ID));
            }
            return lstOps;
        }

        /// <summary>
        /// Generate yearly forcast operations
        /// </summary>
        /// <returns>A list of yearly forcast operations</returns>
        private List<Operation> populateYearlyOperations()
        {
            var beginningDay = DueDate;
            var lstOps = new List<Operation>();

            for (var i = 0; i < NbOfRepetition; i++)
            {
                //Consider only due dates in the future
                if (DateTime.Compare(DueDate.AddYears(i), DateTime.Now) >= 0)
                    lstOps.Add(new Operation(DueDate.AddYears(i), Commentary, Credit, Debit, Type, Budget, ID));
            }
            return lstOps;
        }

        /// <summary>
        /// Depending on repetition type, generate forcast operations
        /// </summary>
        public void populateForcastOperations()
        {
            switch (RepetitionType)
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

        /// <summary>
        /// Filter the list of operations according to starting day and ending day
        /// </summary>
        /// <param name="lstOps">List of operations for filtering</param>
        /// <param name="start">Start day</param>
        /// <param name="end">End day</param>
        /// <returns>List of filtered operations</returns>
        public static List<Operation> filterOperation(List<Operation> lstOps, DateTime start, DateTime end)
        {
            return lstOps.FindAll(x => {return DateTime.Compare(x.Date, start) >= 0 && DateTime.Compare(x.Date, end) <= 0; });
        }

        public void addNormalOperations(Account acc)
        {
            acc.Operations.AddRange(ForcastOperations);
        }

        public static void deleteNormalOperations(Account acc, string rmdOptID)
        {
            acc.Operations.RemoveAll(x => x.RmdOptID == rmdOptID && DateTime.Compare(x.Date, DateTime.Now) > 0);
        }
    }
}