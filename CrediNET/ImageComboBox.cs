using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CrediNET
{
    public class ImageComboBox : ComboBox
    {
        // Data for each color in the list
        public class ImageItem
        {
            public string Text { get; set; }

            public Image Image { get; set; }

            public ImageItem(string text, Image img)
            {
                Text = text;
                Image = img;
            }

            public static explicit operator ImageItem(KeyValuePair<string, Image> key)
            {
                return new ImageItem(key.Key, key.Value);
            }

            public static explicit operator KeyValuePair<string, Image>(ImageItem c)
            {
                return new KeyValuePair<string, Image>(c.Text, c.Image);
            }
        }

        public ImageComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += OnDrawItem;
        }


        // Draw list item
        protected void OnDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                // Get this color
                var ii = (ImageItem)Items[e.Index];

                // Fill background
                e.DrawBackground();

                // Draw color box
                var rect = new Rectangle
                {
                    X = e.Bounds.X + 4,
                    Y = e.Bounds.Y + 2,
                    Width = 16,
                    Height = 16
                };
                try
                {
                    e.Graphics.DrawImage(ii.Image, rect);
                }
                catch (Exception)
                {
                    e.Graphics.DrawRectangle(SystemPens.WindowText, rect);
                }
                
                //e.Graphics.DrawRectangle(SystemPens.WindowText, rect);

                // Write color name
                var brush = (e.State & DrawItemState.Selected) != DrawItemState.None
                    ? SystemBrushes.HighlightText
                    : SystemBrushes.WindowText;
                e.Graphics.DrawString(ii.Text, Font, brush,
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
        public new ImageItem SelectedItem
        {
            get { return (ImageItem)base.SelectedItem; }
            set { base.SelectedItem = value; }
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
                for (var i = 0; i < Items.Count; i++)
                {
                    if (((ImageItem)Items[i]).Text == value)
                    {
                        SelectedIndex = i;
                        break;
                    }
                }
            }
        }


    }
}