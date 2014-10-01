using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrediNET
{
    public partial class ColorComboBox : ComboBox
    {
        // Data for each color in the list
        public class ColorInfo
        {
            public string Text { get; set; }
            public Color Color { get; set; }

            public ColorInfo(string text, Color color)
            {
                Text = text;
                Color = color;
            }

            public static explicit operator ColorInfo(KeyValuePair<string, Color> key)
            {
                return new ColorInfo(key.Key, key.Value);
            }

            public static explicit operator KeyValuePair<string, Color>(ColorInfo c)
            {
                return new KeyValuePair<string, Color>(c.Text, c.Color);
            }
        }

        public ColorComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += OnDrawItem;
        }

        // Populate control with standard colors
        public void AddStandardColors()
        {
            Items.Clear();

            

            System.Enum.GetNames(typeof(KnownColor)).OrderBy(y => y).All(x =>
            {
                try { Items.Add(new ColorInfo(x, (Color)(typeof(Color).GetProperty(x).GetValue(null, null)))); }
                catch { Items.Add(new ColorInfo(x, (Color)(typeof(SystemColors).GetProperty(x).GetValue(null, null)))); }
                return true;
            });
        }

        // Draw list item
        protected void OnDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                // Get this color
                ColorInfo color = (ColorInfo)Items[e.Index];

                // Fill background
                e.DrawBackground();

                // Draw color box
                Rectangle rect = new Rectangle();
                rect.X = e.Bounds.X + 2;
                rect.Y = e.Bounds.Y + 2;
                rect.Width = 18;
                rect.Height = e.Bounds.Height - 5;
                e.Graphics.FillRectangle(new SolidBrush(color.Color), rect);
                e.Graphics.DrawRectangle(SystemPens.WindowText, rect);

                // Write color name
                Brush brush;
                if ((e.State & DrawItemState.Selected) != DrawItemState.None)
                    brush = SystemBrushes.HighlightText;
                else
                    brush = SystemBrushes.WindowText;
                e.Graphics.DrawString(color.Text, Font, brush,
                    e.Bounds.X + rect.X + rect.Width + 2,
                    e.Bounds.Y + ((e.Bounds.Height - Font.Height) / 2));

                // Draw the focus rectangle if appropriate
                if ((e.State & DrawItemState.NoFocusRect) == DrawItemState.None)
                    e.DrawFocusRectangle();
            }
        }

        /// <summary>
        /// Gets or sets the currently selected item.
        /// </summary>
        public new ColorInfo SelectedItem
        {
            get
            {
                return (ColorInfo)base.SelectedItem;
            }
            set
            {
                base.SelectedItem = value;
            }
        }

        /// <summary>
        /// Gets the text of the selected item, or sets the selection to
        /// the item with the specified text.
        /// </summary>
        public new string SelectedText
        {
            get
            {
                if (SelectedIndex >= 0)
                    return SelectedItem.Text;
                return String.Empty;
            }
            set
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (((ColorInfo)Items[i]).Text == value)
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the value of the selected item, or sets the selection to
        /// the item with the specified value.
        /// </summary>
        public new Color SelectedValue
        {
            get
            {
                if (SelectedIndex >= 0)
                    return SelectedItem.Color;
                return Color.White;
            }
            set
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (((ColorInfo)Items[i]).Color == value)
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}
