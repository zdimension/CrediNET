using System;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CrediNET
{
    public class ListViewColumnSorter : IComparer
    {
        public enum SortModifiers
        {
            SortByImage,
            SortByCheckbox,
            SortByText,
            SortByDate,
            SortByDecimal
        }

        /// <summary>
        /// Column to sort
        /// </summary>
        public int ColumnToSort;

        /// <summary>
        /// Order of sort
        /// </summary>
        public SortOrder OrderOfSort;

        /// <summary>
        /// Case insensitive comparers
        /// </summary>
        private NumberCaseInsensitiveComparer ObjectCompare;

        private ImageTextComparer FirstObjectCompare;
        private CheckboxTextComparer FirstObjectCompare2;

        private SortModifiers mySortModifier = SortModifiers.SortByText;

        public SortModifiers _SortModifier
        {
            set { mySortModifier = value; }
            get { return mySortModifier; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new NumberCaseInsensitiveComparer();
            FirstObjectCompare = new ImageTextComparer();
            FirstObjectCompare2 = new CheckboxTextComparer();
        }

        public ListViewColumnSorter(int newCol, SortOrder newOrder)
        {
            ColumnToSort = newCol;
            OrderOfSort = newOrder;

            switch (ColumnToSort)
            {
                case 1:
                    mySortModifier = SortModifiers.SortByDate;
                    break;

                case 5:
                case 6:
                    mySortModifier = SortModifiers.SortByDecimal;
                    break;

                default:
                    mySortModifier = SortModifiers.SortByText;
                    break;
            }

            ObjectCompare = new NumberCaseInsensitiveComparer();
            FirstObjectCompare = new ImageTextComparer();
            FirstObjectCompare2 = new CheckboxTextComparer();
        }

        /// <summary>
        /// This method comes right from IEnumerable. It compares two items.
        /// </summary>
        /// <param name="x">First item</param>
        /// <param name="y">Second item</param>
#pragma warning disable 1570
        /// <returns>Result of the comparison. 0 if equal, 1 if x > y, -1 if x < y</returns>
#pragma warning restore 1570
        public int Compare(object x, object y)
        {
            var compareResult = 0;

            var listviewX = (ListViewItem) x;
            var listviewY = (ListViewItem) y;

            var listViewMain = listviewX.ListView;

            if (listViewMain.Sorting != SortOrder.Ascending &&
                listViewMain.Sorting != SortOrder.Descending)
            {
                return compareResult;
            }

            if (mySortModifier.Equals(SortModifiers.SortByText))
            {
                if (listviewX.SubItems.Count <= ColumnToSort &&
                    listviewY.SubItems.Count <= ColumnToSort)
                {
                    compareResult = ObjectCompare.Compare(null, null);
                }
                else if (listviewX.SubItems.Count <= ColumnToSort &&
                         listviewY.SubItems.Count > ColumnToSort)
                {
                    compareResult = ObjectCompare.Compare(null, listviewY.SubItems[ColumnToSort].Text.Trim());
                }
                else if (listviewX.SubItems.Count > ColumnToSort && listviewY.SubItems.Count <= ColumnToSort)
                {
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text.Trim(), null);
                }
                else
                {
                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text.Trim(),
                        listviewY.SubItems[ColumnToSort].Text.Trim());
                }
            }
            else if (mySortModifier.Equals(SortModifiers.SortByDate))
            {
                // Parse the two objects passed as a parameter as a DateTime.
                var firstDate =
                    DateTime.ParseExact(((ListViewItem) x).SubItems[ColumnToSort].Text, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                var secondDate =
                    DateTime.ParseExact(((ListViewItem) y).SubItems[ColumnToSort].Text, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture);
                // Compare the two dates.
                var returnVal = DateTime.Compare(firstDate, secondDate);

                if (OrderOfSort == SortOrder.Descending)
                    returnVal *= -1;
                return returnVal;
            }
            else if (mySortModifier.Equals(SortModifiers.SortByDecimal))
            {
                // Parse the two objects passed as a parameter as a decimal.
                Console.WriteLine(((ListViewItem) x).SubItems[ColumnToSort].Text);
                var firstNum =
                    decimal.Parse(Regex.Match(((ListViewItem) x).SubItems[ColumnToSort].Text, @"^-?\d+(?:\.\d+)?").Value);
                var secondNum =
                    decimal.Parse(Regex.Match(((ListViewItem) y).SubItems[ColumnToSort].Text, @"^-?\d+(?:\.\d+)?").Value);
                // Compare the two dates.
                var returnVal = firstNum > secondNum ? 1 : -1;

                if (OrderOfSort == SortOrder.Descending)
                    returnVal *= -1;
                return returnVal;
            }
            else
            {
                switch (mySortModifier)
                {
                    case SortModifiers.SortByCheckbox:
                        compareResult = FirstObjectCompare2.Compare(x, y);
                        break;

                    case SortModifiers.SortByImage:
                        compareResult = FirstObjectCompare.Compare(x, y);
                        break;

                    default:
                        compareResult = FirstObjectCompare.Compare(x, y);
                        break;
                }
            }

            if (OrderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Get or set the column to sort (default: 0)
        /// </summary>
        public int SortColumn
        {
            set { ColumnToSort = value; }
            get { return ColumnToSort; }
        }

        /// <summary>
        /// Get or set the sort order (default: ascending)
        /// </summary>
        public SortOrder Order
        {
            set { OrderOfSort = value; }
            get { return OrderOfSort; }
        }
    }

    public class ImageTextComparer : IComparer
    {
        private NumberCaseInsensitiveComparer ObjectCompare;

        public ImageTextComparer()
        {
            ObjectCompare = new NumberCaseInsensitiveComparer();
        }

        /// <summary>
        /// This method comes right from IEnumerable. It compares two items.
        /// </summary>
        /// <param name="x">First item</param>
        /// <param name="y">Second item</param>
#pragma warning disable 1570
        /// <returns>Result of the comparison. 0 if equal, 1 if x > y, -1 if x < y</returns>
#pragma warning restore 1570
        public int Compare(object x, object y)
        {
            var listviewX = (ListViewItem) x;
            var image1 = listviewX.ImageIndex;
            var listviewY = (ListViewItem) y;
            var image2 = listviewY.ImageIndex;

            if (image1 < image2)
            {
                return -1;
            }
            else if (image1 == image2)
            {
                return ObjectCompare.Compare(listviewX.Text.Trim(), listviewY.Text.Trim());
            }
            else
            {
                return 1;
            }
        }
    }

    public class CheckboxTextComparer : IComparer
    {
        private NumberCaseInsensitiveComparer ObjectCompare;

        public CheckboxTextComparer()
        {
            ObjectCompare = new NumberCaseInsensitiveComparer();
        }

        /// <summary>
        /// This method comes right from IEnumerable. It compares two items.
        /// </summary>
        /// <param name="x">First item</param>
        /// <param name="y">Second item</param>
#pragma warning disable 1570
        /// <returns>Result of the comparison. 0 if equal, 1 if x > y, -1 if x < y</returns>
#pragma warning restore 1570
        public int Compare(object x, object y)
        {
            var listviewX = (ListViewItem) x;
            var listviewY = (ListViewItem) y;

            if (listviewX.Checked && !listviewY.Checked)
            {
                return -1;
            }
            else if (listviewX.Checked.Equals(listviewY.Checked))
            {
                if (listviewX.ImageIndex < listviewY.ImageIndex)
                {
                    return -1;
                }
                else if (listviewX.ImageIndex == listviewY.ImageIndex)
                {
                    return ObjectCompare.Compare(listviewX.Text.Trim(), listviewY.Text.Trim());
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }
    }

    public class NumberCaseInsensitiveComparer : CaseInsensitiveComparer
    {
        /// <summary>
        /// This method comes right from IEnumerable. It compares two items.
        /// </summary>
        /// <param name="x">First item</param>
        /// <param name="y">Second item</param>
#pragma warning disable 1570
        /// <returns>Result of the comparison. 0 if equal, 1 if x > y, -1 if x < y</returns>
#pragma warning restore 1570
        public new int Compare(object x, object y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            if ((x is String) && IsWholeNumber((string) x) && (y is String) && IsWholeNumber((string) y))
            {
                try
                {
                    return base.Compare(Convert.ToUInt64(((string) x).Trim()), Convert.ToUInt64(((string) y).Trim()));
                }
                catch
                {
                    return -1;
                }
            }
            else
            {
                return base.Compare(x, y);
            }
        }

        /// <summary>
        /// Check if the given number is a whole number.
        /// </summary>
        /// <param name="strNumber">Number</param>
        /// <returns>Number is whole</returns>
        private bool IsWholeNumber(string strNumber)
        {
            var wholePattern = new Regex(@"^\d+$");
            return wholePattern.IsMatch(strNumber);
        }
    }
}