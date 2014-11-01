using System;
using System.Drawing;

namespace CrediNET
{
    /*internal class CreateExcelDoc
    {
        public Workbook workbook = new Workbook();
        public Worksheet worksheet;

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateExcelDoc()
        {
            createDoc();
        }

        /// <summary>
        /// Creates the document
        /// </summary>
        public void createDoc(string sheettitle = "")
        {
            try
            {
                worksheet = new Worksheet(sheettitle);
                
                
            }
            catch (Exception e)
            {
                Console.Write("Error: " + e.Message);
            }
        }

        public void Finish()
        {
            workbook.Worksheets.Add(worksheet);

        }

        /// <summary>
        /// Create an header
        /// </summary>
        /// <param name="row">Header's row</param>
        /// <param name="col">Header's column</param>
        /// <param name="htext">Header's text</param>
        /// <param name="cell1">First cell</param>
        /// <param name="cell2">Last cell</param>
        /// <param name="mergeColumns">Merge the columns between <paramref name="cell1"/> and <paramref name="cell2"/></param>
        /// <param name="color">The background color</param>
        /// <param name="font">The font</param>
        /// <param name="size">The width</param>
        /// <param name="fcolor">Font color</param>
        public void createHeaders(int row, int col, string htext, string cell1, string cell2, int mergeColumns, Color color, bool font, int size, Color fcolor)
        {
            /*worksheet.Cells[row, col] = htext;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Merge(mergeColumns);
            workSheet_range.Interior.Color = color.ToArgb();

            workSheet_range.Borders.Color = Color.Black.ToArgb();
            workSheet_range.Font.Bold = font;
            workSheet_range.ColumnWidth = size;
            workSheet_range.Font.Color = fcolor.ToArgb();
            worksheet.Cells[row, col] = new Cell(htext);
            worksheet.Cells[row, col].Style.BackColor = color;
            worksheet.Cells[row, col].Style.RichTextFormat.
        }

        public void addData(int row, int col, string data, string cell1, string cell2, string format, int mergeColumns = 0)
        {
            worksheet.Cells[row, col] = data;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Merge(mergeColumns);
            workSheet_range.Borders.Color = Color.Black.ToArgb();
            workSheet_range.NumberFormat = format;
        }

        public void addData(int row, int col, decimal data, string cell1, string cell2, string format, int mergeColumns = 0)
        {
            worksheet.Cells[row, col] = data;
            workSheet_range = worksheet.get_Range(cell1, cell2);
            workSheet_range.Merge(mergeColumns);
            workSheet_range.Borders.Color = Color.Black.ToArgb();
            workSheet_range.NumberFormat = format;
        }
    }*/
}