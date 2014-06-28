using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CrediNET
{

    [Serializable]
    public class Operation
    {
        private string _id = "";

        /// <summary>
        /// GUID of operation
        /// </summary>
        public string ID
        {
            get { return _id; }
        }

        /// <summary>
        /// Date of operation
        /// </summary>
        public DateTime Date
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
        public Operation()
        {
            _id = System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The GUID</param>
        public Operation(string id)
        {
            this._id = id;
        }
    }
}
