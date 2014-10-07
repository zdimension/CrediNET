using System;

namespace CrediNET
{
    [Serializable]
    public class Reminder
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
        /// Monthly
        /// </summary>
        public bool Monthly
        {
            get;
            set;
        }

        /// <summary>
        /// Simple constructor
        /// </summary>
        public Reminder()
        {
            _id = System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The GUID</param>
        public Reminder(string id)
        {
            this._id = id;
        }
    }
}