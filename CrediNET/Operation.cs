using System;

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
        public DateTime Date { get; set; }

        /// <summary>
        /// Commentary
        /// </summary>
        public string Commentary { get; set; }

        /// <summary>
        /// Credit
        /// </summary>
        public decimal Credit { get; set; }

        /// <summary>
        /// Debit
        /// </summary>
        public decimal Debit { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public string Budget { get; set; }

        /// <summary>
        /// The reminder operation from which this operation is generated
        /// </summary>
        public string RmdOptID { get; set; }

        /// <summary>
        /// Simple constructor
        /// </summary>
        public Operation()
        {
            _id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The GUID</param>
        public Operation(string id)
        {
            _id = id;
        }

        public Operation(DateTime date, string commentary, decimal credit, decimal debit, string type, string budget)
        {
            _id = Guid.NewGuid().ToString();
            Date = date;
            Commentary = commentary;
            Credit = credit;
            Debit = debit;
            Type = type;
            Budget = budget;
        }

        public Operation(DateTime date, string commentary, decimal credit, decimal debit, string type, string budget,
            string rmdOptID)
        {
            _id = Guid.NewGuid().ToString();
            Date = date;
            Commentary = commentary;
            Credit = credit;
            Debit = debit;
            Type = type;
            Budget = budget;
            RmdOptID = rmdOptID;
        }
    }
}