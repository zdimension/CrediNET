using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms.Calendar
{
    /// <summary>
    /// CalendarRenderer that renders low-intensity calendar for slow computers
    /// </summary>
    public class CalendarSystemRenderer
        : CalendarRenderer
    {
        #region Fields

        private CalendarColorTable _colorTable;
        private float _selectedItemBorder;

        #endregion

        #region Ctor

        public CalendarSystemRenderer(Calendar calendar)
            : base(calendar)
        {
            ColorTable = new CalendarColorTable();
            SelectedItemBorder = 1;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="CalendarColorTable"/> for this renderer
        /// </summary>
        public CalendarColorTable ColorTable
        {
            get { return _colorTable; }
            set { _colorTable = value; }
        }

        /// <summary>
        /// Gets or sets the size of the border of selected items
        /// </summary>
        public float SelectedItemBorder
        {
            get { return _selectedItemBorder; }
            set { _selectedItemBorder = value; }
        }

        #endregion

        #region Overrides

        public override void OnDrawBackground(CalendarRendererEventArgs e)
        {
            e.Graphics.Clear(ColorTable.Background);
        }

        public override void OnDrawDay(CalendarRendererDayEventArgs e)
        {
            var r = e.Day.Bounds;

            if (e.Day.Selected)
            {
                using (Brush b = new SolidBrush(ColorTable.DayBackgroundSelected))
                {
                    e.Graphics.FillRectangle(b, r);
                }
            }
            else if (e.Day.Date.Month % 2 == 0)
            {
                using (Brush b = new SolidBrush(ColorTable.DayBackgroundEven))
                {
                    e.Graphics.FillRectangle(b, r);
                }
            }
            else
            {
                using (Brush b = new SolidBrush(ColorTable.DayBackgroundOdd))
                {
                    e.Graphics.FillRectangle(b, r);
                }
            }

            base.OnDrawDay(e);
        }

        public override void OnDrawDayBorder(CalendarRendererDayEventArgs e)
        {
            base.OnDrawDayBorder(e);

            var r = e.Day.Bounds;
            var today = e.Day.Date.Date.Equals(DateTime.Today.Date);

            using (var p = new Pen(today ? ColorTable.TodayBorder : ColorTable.DayBorder, today ? 2 : 1))
            {
                if (e.Calendar.DaysMode == CalendarDaysMode.Short)
                {
                    e.Graphics.DrawLine(p, r.Right, r.Top, r.Right, r.Bottom);
                    e.Graphics.DrawLine(p, r.Left, r.Bottom, r.Right, r.Bottom);

                    if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday || today)
                    {
                        e.Graphics.DrawLine(p, r.Left, r.Top, r.Left, r.Bottom);
                    }
                }
                else
                {
                    e.Graphics.DrawRectangle(p, r);
                }
            }
        }

        public override void OnDrawDayTop(CalendarRendererDayEventArgs e)
        {
            var s = e.Day.DayTop.Selected;

            using (Brush b = new SolidBrush(s ? ColorTable.DayTopSelectedBackground : ColorTable.DayTopBackground))
            {
                e.Graphics.FillRectangle(b, e.Day.DayTop.Bounds);
            }

            using (var p = new Pen(s ? ColorTable.DayTopSelectedBorder : ColorTable.DayTopBorder))
            {
                e.Graphics.DrawRectangle(p, e.Day.DayTop.Bounds);
            }

            base.OnDrawDayTop(e);
        }

        public override void OnDrawDayHeaderBackground(CalendarRendererDayEventArgs e)
        {
            var today = e.Day.Date.Date.Equals(DateTime.Today.Date);

            using (Brush b = new SolidBrush(today ? ColorTable.TodayTopBackground : ColorTable.DayHeaderBackground))
            {
                e.Graphics.FillRectangle(b, e.Day.HeaderBounds);
            }

            base.OnDrawDayHeaderBackground(e);
        }

        public override void OnDrawWeekHeader(CalendarRendererBoxEventArgs e)
        {
            using (Brush b = new SolidBrush(ColorTable.WeekHeaderBackground))
            {
                e.Graphics.FillRectangle(b, e.Bounds);
            }

            using (var p = new Pen(ColorTable.WeekHeaderBorder))
            {
                e.Graphics.DrawRectangle(p, e.Bounds);
            }

            e.TextColor = ColorTable.WeekHeaderText;

            base.OnDrawWeekHeader(e);
        }

        public override void OnDrawDayTimeUnit(CalendarRendererTimeUnitEventArgs e)
        {
            base.OnDrawDayTimeUnit(e);

            using (var b = new SolidBrush(ColorTable.TimeUnitBackground))
            {
                if (e.Unit.Selected)
                {
                    b.Color = ColorTable.TimeUnitSelectedBackground;
                }
                else if (e.Unit.Highlighted)
                {
                    b.Color = ColorTable.TimeUnitHighlightedBackground;
                }

                e.Graphics.FillRectangle(b, e.Unit.Bounds);
            }

            using (var p = new Pen(e.Unit.Minutes == 0 ? ColorTable.TimeUnitBorderDark : ColorTable.TimeUnitBorderLight)
                )
            {
                e.Graphics.DrawLine(p, e.Unit.Bounds.Location, new Point(e.Unit.Bounds.Right, e.Unit.Bounds.Top));
            }

            //TextRenderer.DrawText(e.Graphics, e.Unit.PassingItems.Count.ToString(), e.Calendar.Font, e.Unit.Bounds, Color.Black);
        }

        public override void OnDrawTimeScale(CalendarRendererEventArgs e)
        {
            var margin = 5;
            var largeX1 = TimeScaleBounds.Left + margin;
            var largeX2 = TimeScaleBounds.Right - margin;
            var shortX1 = TimeScaleBounds.Left + TimeScaleBounds.Width / 2;
            var shortX2 = largeX2;
            var top = 0;
            var p = new Pen(ColorTable.TimeScaleLine);

            for (var i = 0; i < e.Calendar.Days[0].TimeUnits.Length; i++)
            {
                var unit = e.Calendar.Days[0].TimeUnits[i];

                if (!unit.Visible) continue;

                top = unit.Bounds.Top;

                if (unit.Minutes == 0)
                {
                    e.Graphics.DrawLine(p, largeX1, top, largeX2, top);
                }
                else
                {
                    e.Graphics.DrawLine(p, shortX1, top, shortX2, top);
                }
            }

            if (e.Calendar.DaysMode == CalendarDaysMode.Expanded
                && e.Calendar.Days != null
                && e.Calendar.Days.Length > 0
                && e.Calendar.Days[0].TimeUnits != null
                && e.Calendar.Days[0].TimeUnits.Length > 0
                )
            {
                top = e.Calendar.Days[0].BodyBounds.Top;

                //Timescale top line is full
                e.Graphics.DrawLine(p, TimeScaleBounds.Left, top, TimeScaleBounds.Right, top);
            }

            p.Dispose();

            base.OnDrawTimeScale(e);
        }

        public override void OnDrawTimeScaleHour(CalendarRendererBoxEventArgs e)
        {
            e.TextColor = ColorTable.TimeScaleHours;
            base.OnDrawTimeScaleHour(e);
        }

        public override void OnDrawTimeScaleMinutes(CalendarRendererBoxEventArgs e)
        {
            e.TextColor = ColorTable.TimeScaleMinutes;
            base.OnDrawTimeScaleMinutes(e);
        }

        public override void OnDrawItemBackground(CalendarRendererItemBoundsEventArgs e)
        {
            base.OnDrawItemBackground(e);

            var alpha = 255;

            if (e.Item.IsDragging)
            {
                alpha = 120;
            }
            else if (e.Calendar.DaysMode == CalendarDaysMode.Short)
            {
                alpha = 200;
            }

            var color1 = Color.White;
            var color2 = e.Item.Selected ? ColorTable.ItemSelectedBackground : ColorTable.ItemBackground;

            if (!e.Item.BackgroundColorLighter.IsEmpty)
            {
                color1 = e.Item.BackgroundColorLighter;
            }

            if (!e.Item.BackgroundColor.IsEmpty)
            {
                color2 = e.Item.BackgroundColor;
            }

            ItemFill(e, e.Bounds, Color.FromArgb(alpha, color1), Color.FromArgb(alpha, color2));
        }

        public override void OnDrawItemShadow(CalendarRendererItemBoundsEventArgs e)
        {
            base.OnDrawItemShadow(e);

            if (e.Item.IsOnDayTop || e.Calendar.DaysMode == CalendarDaysMode.Short || e.Item.IsDragging)
            {
                return;
            }

            var r = e.Bounds;
            r.Offset(ItemShadowPadding, ItemShadowPadding);

            using (var b = new SolidBrush(ColorTable.ItemShadow))
            {
                ItemFill(e, r, ColorTable.ItemShadow, ColorTable.ItemShadow);
            }
        }

        public override void OnDrawItemBorder(CalendarRendererItemBoundsEventArgs e)
        {
            base.OnDrawItemBorder(e);

            var a = e.Item.BorderColor.IsEmpty ? ColorTable.ItemBorder : e.Item.BorderColor;
            var b = e.Item.Selected && !e.Item.IsDragging ? ColorTable.ItemSelectedBorder : a;
            var c = Color.FromArgb(e.Item.IsDragging ? 120 : 255, b);

            ItemBorder(e, e.Bounds, c, e.Item.Selected && !e.Item.IsDragging ? SelectedItemBorder : 1f);
        }

        public override void OnDrawItemStartTime(CalendarRendererBoxEventArgs e)
        {
            if (e.TextColor.IsEmpty)
            {
                e.TextColor = ColorTable.ItemSecondaryText;
            }

            base.OnDrawItemStartTime(e);
        }

        public override void OnDrawItemEndTime(CalendarRendererBoxEventArgs e)
        {
            if (e.TextColor.IsEmpty)
            {
                e.TextColor = ColorTable.ItemSecondaryText;
            }

            base.OnDrawItemEndTime(e);
        }

        public override void OnDrawItemText(CalendarRendererBoxEventArgs e)
        {
            var item = e.Tag as CalendarItem;

            if (item != null)
            {
                if (item.IsDragging)
                {
                    e.TextColor = Color.FromArgb(120, e.TextColor);
                }
            }

            base.OnDrawItemText(e);
        }

        public override void OnDrawWeekHeaders(CalendarRendererEventArgs e)
        {
            base.OnDrawWeekHeaders(e);
        }

        public override void OnDrawDayNameHeader(CalendarRendererBoxEventArgs e)
        {
            e.TextColor = ColorTable.WeekDayName;

            base.OnDrawDayNameHeader(e);

            using (var p = new Pen(ColorTable.WeekDayName))
            {
                e.Graphics.DrawLine(p, e.Bounds.Right, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom);
            }
        }

        public override void OnDrawDayOverflowEnd(CalendarRendererDayEventArgs e)
        {
            using (var path = new GraphicsPath())
            {
                var top = e.Day.OverflowEndBounds.Top + e.Day.OverflowEndBounds.Height / 2;
                path.AddPolygon(new[]
                {
                    new Point(e.Day.OverflowEndBounds.Left, top),
                    new Point(e.Day.OverflowEndBounds.Right, top),
                    new Point(e.Day.OverflowEndBounds.Left + e.Day.OverflowEndBounds.Width / 2,
                        e.Day.OverflowEndBounds.Bottom),
                });

                using (
                    Brush b =
                        new SolidBrush(e.Day.OverflowEndSelected
                            ? ColorTable.DayOverflowSelectedBackground
                            : ColorTable.DayOverflowBackground))
                {
                    e.Graphics.FillPath(b, path);
                }

                using (var p = new Pen(ColorTable.DayOverflowBorder))
                {
                    e.Graphics.DrawPath(p, path);
                }
            }
        }

        #endregion
    }
}