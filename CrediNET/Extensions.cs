using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using System.Xml.Linq;
using AODL.Document.Content.Tables;
using AODL.Document.Content.Text;
using AODL.Document.Styles;

namespace CrediNET
{
    public static class Extensions
    {
        public static string Sanitize(this string str)
        {
            return str.Replace("'", "''");
        }

        public static void AddOrUpdate(this Dictionary<string, decimal> dic, string key, decimal value)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }

        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }

        public static string ToHex(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static void AddCell(this Table tbl, int row, int col, string text, Color back, bool bold, Color fore)
        {
            Cell c = tbl.CreateCell();
            c.CellStyle = new CellStyle(tbl.Document);
            c.CellStyle.CellProperties.BackgroundColor = back.ToHex();
            Paragraph p = ParagraphBuilder.CreateSpreadsheetParagraph(tbl.Document);
            FormatedText t = new FormatedText(tbl.Document, "t" + row + col, text);
            t.TextStyle.TextProperties.Bold = bold.ToString();
            t.TextStyle.TextProperties.FontColor = fore.ToHex();
            p.TextContent.Add(t);
            c.Content.Add(p);
            tbl.InsertCellAt(row, col, c);
        }


        public static void AddCell(this Table tbl, int row, int col, string text, Color back)
        {
            Cell c = tbl.CreateCell();
            c.CellStyle = new CellStyle(tbl.Document);
            c.CellStyle.CellProperties.BackgroundColor = back.ToHex();
            Paragraph p = ParagraphBuilder.CreateSpreadsheetParagraph(tbl.Document);
            FormatedText t = new FormatedText(tbl.Document, "t" + row + col, text);
            p.TextContent.Add(t);
            c.Content.Add(p);
            tbl.InsertCellAt(row, col, c);
        }

        public static string ZeroAsDash(this decimal d)
        {
            return (d == 0 && Properties.Settings.Default.UseDashes) ? "-" : d.ToString("0.00");
        }
    }
}
