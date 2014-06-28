using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CrediNET
{
    public class Renderer
    {
        public RenderParams Colors;
        public Renderer()
        {
            this.Colors = new RenderParams();
        }
        public ToolStripRenderer GetRenderer()
        {
            return new TemplateRenderer(this.Colors);
        }
    }
    public class RenderParams
    {
        public Color foreColor;
        public int gripOffset;
        public int gripSquare;
        public int gripSize;
        public int gripMove;
        public int gripLines;
        public int checkInset;
        public int marginInset;
        public int separatorInset;
        public float cutToolItemMenu;
        public float cutContextMenu;
        public float cutMenuItemBack;
        public float contextCheckTickThickness;
        public object ColorTable;
        public Color insideTop1;
        public Color insideTop2;
        public Color insideBottom1;
        public Color imageMargin;
        public Color insideBottom2;
        public Color fillTop1;
        public Color fillTop2;
        public Color fillBottom1;
        public Color fillBottom2;
        public Color borderColor1;
        public Color borderColor2;
        public Color disabledInsideTop1;
        public Color disabledInsideTop2;
        public Color disabledInsideBottom1;
        public Color disabledInsideBottom2;
        public Color disabledFillTop1;
        public Color disabledFillTop2;
        public Color disabledFillBottom1;
        public Color disabledFillBottom2;
        public Color disabledBorderColor1;
        public Color disabledBorderColor2;
        public Color textDisabled;
        public Color textMenuStripItem;
        public Color textStatusStripItem;
        public Color textContextMenuItem;
        public Color textSelected;
        public Color arrowDisabled;
        public Color arrowLight;
        public Color arrowDark;
        public Color arrowSelected;
        public Color separatorMenuLight;
        public Color separatorMenuDark;
        public Color contextMenuBack;
        public Color contextCheckBorder;
        public Color contextCheckBorderSelected;
        public Color contextCheckTick;
        public Color contextCheckTickSelected;
        public Color statusStripBorderDark;
        public Color statusStripBorderLight;
        public Color gripDark;
        public Color gripLight;
        public RenderParams()
        {
            this.ColorTable = new TemplateColorTable();
        }
    }
    internal class TemplateColorTable : ProfessionalColorTable
    {
        internal static Color _contextMenuBack = Color.FromArgb(255, 255, 255);
        internal static Color _buttonPressedBegin = Color.FromArgb(255, 255, 255);
        internal static Color _buttonPressedEnd = Color.FromArgb(255, 255, 255);
        internal static Color _buttonPressedMiddle = Color.FromArgb(255, 255, 255);
        internal static Color _buttonSelectedBegin = Color.FromArgb(255, 255, 255);
        internal static Color _buttonSelectedEnd = Color.FromArgb(255, 255, 255);
        internal static Color _buttonSelectedMiddle = Color.FromArgb(255, 255, 255);
        internal static Color _menuItemSelectedBegin = Color.FromArgb(255, 255, 255);
        internal static Color _menuItemSelectedEnd = Color.FromArgb(255, 255, 255);
        internal static Color _checkBack = Color.Transparent;
        internal static Color _gripDark = Color.FromArgb(160, 160, 160);
        internal static Color _gripLight = Color.FromArgb(255, 255, 255);
        public static Color _imageMargin = Color.FromArgb(255, 255, 255);
        internal static Color _menuBorder = Color.FromArgb(160, 160, 160);
        internal static Color _overflowBegin = Color.FromArgb(255, 255, 255);
        internal static Color _overflowEnd = Color.FromArgb(255, 255, 255);
        internal static Color _overflowMiddle = Color.FromArgb(255, 255, 255);
        internal static Color _menuToolBack = Color.FromArgb(255, 255, 255);
        internal static Color _separatorDark = Color.FromArgb(160, 160, 160);
        internal static Color _separatorLight = Color.Transparent;
        internal static Color _statusStripLight = Color.FromArgb(255, 255, 255);
        internal static Color _statusStripDark = Color.FromArgb(255, 255, 255);
        internal static Color _toolStripBorder = Color.FromArgb(160, 160, 160);
        internal static Color _toolStripContentEnd = Color.FromArgb(255, 255, 255);
        internal static Color _toolStripBegin = Color.FromArgb(255, 255, 255);
        internal static Color _toolStripEnd = Color.FromArgb(255, 255, 255);
        internal static Color _toolStripMiddle = Color.FromArgb(255, 255, 255);
        internal static Color _buttonBorder = Color.FromArgb(229, 195, 101);
        public override Color ButtonPressedGradientBegin
        {
            get
            {
                return TemplateColorTable._buttonPressedBegin;
            }
        }
        public override Color ButtonPressedGradientEnd
        {
            get
            {
                return TemplateColorTable._buttonPressedEnd;
            }
        }
        public override Color ButtonPressedGradientMiddle
        {
            get
            {
                return TemplateColorTable._buttonPressedMiddle;
            }
        }
        public override Color ButtonSelectedGradientBegin
        {
            get
            {
                return TemplateColorTable._buttonSelectedBegin;
            }
        }
        public override Color ButtonSelectedGradientEnd
        {
            get
            {
                return TemplateColorTable._buttonSelectedEnd;
            }
        }
        public override Color ButtonSelectedGradientMiddle
        {
            get
            {
                return TemplateColorTable._buttonSelectedMiddle;
            }
        }
        public override Color ButtonSelectedHighlightBorder
        {
            get
            {
                return TemplateColorTable._buttonBorder;
            }
        }
        public override Color CheckBackground
        {
            get
            {
                return TemplateColorTable._checkBack;
            }
        }
        public override Color GripDark
        {
            get
            {
                return TemplateColorTable._gripDark;
            }
        }
        public override Color GripLight
        {
            get
            {
                return TemplateColorTable._gripLight;
            }
        }
        public override Color ImageMarginGradientBegin
        {
            get
            {
                return TemplateColorTable._imageMargin;
            }
        }
        public override Color MenuBorder
        {
            get
            {
                return TemplateColorTable._menuBorder;
            }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return TemplateColorTable._toolStripBegin;
            }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return TemplateColorTable._toolStripEnd;
            }
        }
        public override Color MenuItemPressedGradientMiddle
        {
            get
            {
                return TemplateColorTable._toolStripMiddle;
            }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return TemplateColorTable._menuItemSelectedBegin;
            }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return TemplateColorTable._menuItemSelectedEnd;
            }
        }
        public override Color MenuStripGradientBegin
        {
            get
            {
                return TemplateColorTable._menuToolBack;
            }
        }
        public override Color MenuStripGradientEnd
        {
            get
            {
                return TemplateColorTable._menuToolBack;
            }
        }
        public override Color OverflowButtonGradientBegin
        {
            get
            {
                return TemplateColorTable._overflowBegin;
            }
        }
        public override Color OverflowButtonGradientEnd
        {
            get
            {
                return TemplateColorTable._overflowEnd;
            }
        }
        public override Color OverflowButtonGradientMiddle
        {
            get
            {
                return TemplateColorTable._overflowMiddle;
            }
        }
        public override Color RaftingContainerGradientBegin
        {
            get
            {
                return TemplateColorTable._menuToolBack;
            }
        }
        public override Color RaftingContainerGradientEnd
        {
            get
            {
                return TemplateColorTable._menuToolBack;
            }
        }
        public override Color SeparatorDark
        {
            get
            {
                return TemplateColorTable._separatorDark;
            }
        }
        public override Color SeparatorLight
        {
            get
            {
                return TemplateColorTable._separatorLight;
            }
        }
        public override Color StatusStripGradientBegin
        {
            get
            {
                return TemplateColorTable._statusStripLight;
            }
        }
        public override Color StatusStripGradientEnd
        {
            get
            {
                return TemplateColorTable._statusStripDark;
            }
        }
        public override Color ToolStripBorder
        {
            get
            {
                return TemplateColorTable._toolStripBorder;
            }
        }
        public override Color ToolStripContentPanelGradientBegin
        {
            get
            {
                return TemplateColorTable._toolStripContentEnd;
            }
        }
        public override Color ToolStripContentPanelGradientEnd
        {
            get
            {
                return TemplateColorTable._menuToolBack;
            }
        }
        public override Color ToolStripDropDownBackground
        {
            get
            {
                return TemplateColorTable._contextMenuBack;
            }
        }
        public override Color ToolStripGradientBegin
        {
            get
            {
                return TemplateColorTable._toolStripBegin;
            }
        }
        public override Color ToolStripGradientEnd
        {
            get
            {
                return TemplateColorTable._toolStripEnd;
            }
        }
        public override Color ToolStripGradientMiddle
        {
            get
            {
                return TemplateColorTable._toolStripMiddle;
            }
        }
        public override Color ToolStripPanelGradientBegin
        {
            get
            {
                return TemplateColorTable._menuToolBack;
            }
        }
        public override Color ToolStripPanelGradientEnd
        {
            get
            {
                return TemplateColorTable._menuToolBack;
            }
        }
        [DebuggerNonUserCode]
        public TemplateColorTable()
        {
        }
    }
    internal class TemplateRenderer : ToolStripProfessionalRenderer
    {
        private class GradientItemColors
        {
            public Color cInsideTop1;
            public Color cInsideTop2;
            public Color cInsideBottom1;
            public Color cInsideBottom2;
            public Color cFillTop1;
            public Color cFillTop2;
            public Color cFillBottom1;
            public Color cFillBottom2;
            public Color cBorder1;
            public Color cBorder2;
            public GradientItemColors(Color insideTop1, Color insideTop2, Color insideBottom1, Color insideBottom2, Color fillTop1, Color fillTop2, Color fillBottom1, Color fillBottom2, Color border1, Color border2)
            {
                this.cInsideTop1 = insideTop1;
                this.cInsideTop2 = insideTop2;
                this.cInsideBottom1 = insideBottom1;
                this.cInsideBottom2 = insideBottom2;
                this.cFillTop1 = fillTop1;
                this.cFillTop2 = fillTop2;
                this.cFillBottom1 = fillBottom1;
                this.cFillBottom2 = fillBottom2;
                this.cBorder1 = border1;
                this.cBorder2 = border2;
            }
        }
        private Color forecolor;
        private bool m_IsGlassDesired;
        private static int _gripOffset;
        private static int _gripSquare;
        private static int _gripSize;
        private static int _gripMove;
        private static int _gripLines;
        private static int _checkInset;
        private static int _marginInset;
        private static int _separatorInset;
        private static float _cutToolItemMenu;
        private static float _cutContextMenu;
        private static float _cutMenuItemBack;
        private static float _contextCheckTickThickness;
        private static Blend _statusStripBlend;
        internal new static TemplateColorTable ColorTable;
        internal static Color insideTop1;
        internal static Color insideTop2;
        internal static Color insideBottom1;
        internal static Color insideBottom2;
        internal static Color fillTop1;
        internal static Color fillTop2;
        internal static Color fillBottom1;
        internal static Color fillBottom2;
        internal static Color borderColor1;
        internal static Color borderColor2;
        internal static Color disabledInsideTop1;
        internal static Color disabledInsideTop2;
        internal static Color disabledInsideBottom1;
        internal static Color disabledInsideBottom2;
        internal static Color disabledFillTop1;
        internal static Color disabledFillTop2;
        internal static Color disabledFillBottom1;
        internal static Color disabledFillBottom2;
        internal static Color disabledBorderColor1;
        internal static Color disabledBorderColor2;
        internal static Color _textDisabled;
        internal static Color _textMenuStripItem;
        internal static Color _textStatusStripItem;
        internal static Color _textContextMenuItem;
        internal static Color _textSelected;
        internal static Color _arrowDisabled;
        internal static Color _arrowLight;
        internal static Color _arrowDark;
        internal static Color _arrowSelected;
        internal static Color _separatorMenuLight;
        internal static Color _separatorMenuDark;
        internal static Color _contextMenuBack;
        internal static Color _contextCheckBorder;
        internal static Color _contextCheckBorderSelected;
        internal static Color _contextCheckTick;
        internal static Color _contextCheckTickSelected;
        internal static Color _statusStripBorderDark;
        internal static Color _statusStripBorderLight;
        internal static Color _gripDark;
        internal static Color _gripLight;
        private static TemplateRenderer.GradientItemColors _itemContextItemEnabledColors;
        private static TemplateRenderer.GradientItemColors _itemDisabledColors;
        private static TemplateRenderer.GradientItemColors _itemToolItemSelectedColors;
        private static TemplateRenderer.GradientItemColors _itemToolItemPressedColors;
        private static TemplateRenderer.GradientItemColors _itemToolItemCheckedColors;
        private static TemplateRenderer.GradientItemColors _itemToolItemCheckPressColors;
        public bool IsGlassDesired
        {
            get
            {
                return this.m_IsGlassDesired;
            }
            set
            {
                this.m_IsGlassDesired = value;
            }
        }
        public TemplateRenderer(RenderParams @params)
        {
            this.RoundedEdges = false;
            this.forecolor = @params.foreColor;
            TemplateRenderer._gripOffset = @params.gripOffset;
            TemplateRenderer._gripSquare = @params.gripSquare;
            TemplateRenderer._gripSize = @params.gripSize;
            TemplateRenderer._gripMove = @params.gripMove;
            TemplateRenderer._gripLines = @params.gripLines;
            TemplateRenderer._checkInset = @params.checkInset;
            TemplateRenderer._marginInset = @params.marginInset;
            TemplateRenderer._separatorInset = @params.separatorInset;
            TemplateRenderer._cutToolItemMenu = @params.cutToolItemMenu;
            TemplateRenderer._cutContextMenu = @params.cutContextMenu;
            TemplateRenderer._cutMenuItemBack = @params.cutMenuItemBack;
            TemplateRenderer._contextCheckTickThickness = @params.contextCheckTickThickness;
            TemplateRenderer.ColorTable = (TemplateColorTable)@params.ColorTable;
            TemplateColorTable._imageMargin = @params.imageMargin;
            TemplateRenderer.insideTop1 = @params.insideTop1;
            TemplateRenderer.insideTop2 = @params.insideTop2;
            TemplateRenderer.insideBottom1 = @params.insideBottom1;
            TemplateRenderer.insideBottom2 = @params.insideBottom2;
            TemplateRenderer.fillTop1 = @params.fillTop1;
            TemplateRenderer.fillTop2 = @params.fillTop2;
            TemplateRenderer.fillBottom1 = @params.fillBottom1;
            TemplateRenderer.fillBottom2 = @params.fillBottom2;
            TemplateRenderer.borderColor1 = @params.borderColor1;
            TemplateRenderer.borderColor2 = @params.borderColor2;
            TemplateRenderer.disabledInsideTop1 = @params.disabledInsideTop1;
            TemplateRenderer.disabledInsideTop2 = @params.disabledInsideTop2;
            TemplateRenderer.disabledInsideBottom1 = @params.disabledInsideBottom1;
            TemplateRenderer.disabledInsideBottom2 = @params.disabledInsideBottom2;
            TemplateRenderer.disabledFillTop1 = @params.disabledFillTop1;
            TemplateRenderer.disabledFillTop2 = @params.disabledFillTop2;
            TemplateRenderer.disabledFillBottom1 = @params.disabledFillBottom1;
            TemplateRenderer.disabledFillBottom2 = @params.disabledFillBottom2;
            TemplateRenderer.disabledBorderColor1 = @params.disabledBorderColor1;
            TemplateRenderer.disabledBorderColor2 = @params.disabledBorderColor2;
            TemplateRenderer._textDisabled = @params.textDisabled;
            TemplateRenderer._textMenuStripItem = @params.textMenuStripItem;
            TemplateRenderer._textStatusStripItem = @params.textStatusStripItem;
            TemplateRenderer._textContextMenuItem = @params.textContextMenuItem;
            TemplateRenderer._textSelected = @params.textSelected;
            TemplateRenderer._arrowDisabled = @params.arrowDisabled;
            TemplateRenderer._arrowLight = @params.arrowLight;
            TemplateRenderer._arrowDark = @params.arrowDark;
            TemplateRenderer._arrowSelected = @params.arrowSelected;
            TemplateRenderer._separatorMenuLight = @params.separatorMenuLight;
            TemplateRenderer._separatorMenuDark = @params.separatorMenuDark;
            TemplateRenderer._contextMenuBack = @params.contextMenuBack;
            TemplateRenderer._contextCheckBorder = @params.contextCheckBorder;
            TemplateRenderer._contextCheckBorderSelected = @params.contextCheckBorderSelected;
            TemplateRenderer._contextCheckTick = @params.contextCheckTick;
            TemplateRenderer._contextCheckTickSelected = @params.contextCheckTickSelected;
            TemplateRenderer._statusStripBorderDark = @params.statusStripBorderDark;
            TemplateRenderer._statusStripBorderLight = @params.statusStripBorderLight;
            TemplateRenderer._gripDark = @params.gripDark;
            TemplateRenderer._gripLight = @params.gripLight;
            TemplateRenderer._itemContextItemEnabledColors = new TemplateRenderer.GradientItemColors(@params.insideTop1, @params.insideTop2, @params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1, @params.fillBottom2, @params.borderColor1, @params.borderColor2);
            TemplateRenderer._itemDisabledColors = new TemplateRenderer.GradientItemColors(@params.disabledInsideTop1, @params.disabledInsideTop2, @params.disabledInsideBottom1, @params.disabledInsideBottom2, @params.disabledFillTop1, @params.disabledFillTop2, @params.disabledFillBottom1, @params.disabledFillBottom2, @params.disabledBorderColor1, @params.disabledBorderColor2);
            TemplateRenderer._itemToolItemSelectedColors = new TemplateRenderer.GradientItemColors(@params.insideTop1, @params.insideTop2, @params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1, @params.fillBottom2, @params.borderColor1, @params.borderColor2);
            TemplateRenderer._itemToolItemPressedColors = new TemplateRenderer.GradientItemColors(@params.insideTop1, @params.insideTop2, @params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1, @params.fillBottom2, @params.borderColor1, @params.borderColor2);
            TemplateRenderer._itemToolItemCheckedColors = new TemplateRenderer.GradientItemColors(@params.insideTop1, @params.insideTop2, @params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1, @params.fillBottom2, @params.borderColor1, @params.borderColor2);
            TemplateRenderer._itemToolItemCheckPressColors = new TemplateRenderer.GradientItemColors(@params.insideTop1, @params.insideTop2, @params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1, @params.fillBottom2, @params.borderColor1, @params.borderColor2);
            TemplateRenderer._statusStripBlend = new Blend();
            TemplateRenderer._statusStripBlend.Positions = new float[]
			{
				0f,
				0.25f,
				0.25f,
				0.57f,
				0.86f,
				1f
			};
            TemplateRenderer._statusStripBlend.Factors = new float[]
			{
				0.1f,
				0.6f,
				1f,
				0.4f,
				0f,
				0.95f
			};
        }
        public TemplateRenderer()
            : base(TemplateRenderer.ColorTable)
        {
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            bool flag = e.ArrowRectangle.Width > 0 && e.ArrowRectangle.Height > 0;
            bool flag2 = flag;
            if (flag2)
            {
                GraphicsPath graphicsPath = this.CreateArrowPath(e.Item, e.ArrowRectangle, e.Direction);
                try
                {
                    RectangleF bounds = graphicsPath.GetBounds();
                    bounds.Inflate(1f, 1f);
                    Color color = e.Item.Enabled ? TemplateRenderer._arrowLight : TemplateRenderer._arrowDisabled;
                    Color color2 = e.Item.Enabled ? TemplateRenderer._arrowDark : TemplateRenderer._arrowDisabled;
                    flag = e.Item.Selected;
                    flag2 = flag;
                    if (flag2)
                    {
                        color = TemplateRenderer._arrowSelected;
                        color2 = TemplateRenderer._arrowSelected;
                    }
                    float angle = 0f;
                    switch (e.Direction)
                    {
                        case ArrowDirection.Left:
                            angle = 180f;
                            break;
                        case ArrowDirection.Up:
                            angle = 270f;
                            break;
                        case ArrowDirection.Right:
                            angle = 0f;
                            break;
                        case ArrowDirection.Down:
                            angle = 90f;
                            break;
                    }
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, color, color2, angle);
                    try
                    {
                        e.Graphics.FillPath(linearGradientBrush, graphicsPath);
                    }
                    finally
                    {
                        flag = (linearGradientBrush != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            ((IDisposable)linearGradientBrush).Dispose();
                        }
                    }
                }
                finally
                {
                    flag = (graphicsPath != null);
                    flag2 = flag;
                    if (flag2)
                    {
                        ((IDisposable)graphicsPath).Dispose();
                    }
                }
            }
        }
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = this.forecolor;
            base.OnRenderItemText(e);
        }
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            ToolStripButton toolStripButton = (ToolStripButton)e.Item;
            bool flag = !toolStripButton.Selected && !toolStripButton.Pressed;
            bool flag2;
            bool flag3;
            if (flag)
            {
                flag2 = !toolStripButton.Checked;
                if (flag2)
                {
                    flag3 = false;
                    goto IL_3D;
                }
            }
            flag3 = true;
        IL_3D:
            bool flag4 = flag3;
            flag2 = flag4;
            if (flag2)
            {
                this.RenderToolButtonBackground(e.Graphics, toolStripButton, e.ToolStrip);
            }
        }
        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            bool flag = e.Item.Selected || e.Item.Pressed;
            bool flag2 = flag;
            if (flag2)
            {
                this.RenderToolDropButtonBackground(e.Graphics, e.Item, e.ToolStrip);
            }
        }
        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            Rectangle imageRectangle = e.ImageRectangle;
            imageRectangle.Inflate(1, 1);
            bool flag = imageRectangle.Top > TemplateRenderer._checkInset;
            bool flag2 = flag;
            checked
            {
                if (flag2)
                {
                    int num = imageRectangle.Top - TemplateRenderer._checkInset;
                    imageRectangle.Y -= num;
                    imageRectangle.Height += num;
                }
                flag = (imageRectangle.Height <= e.Item.Bounds.Height - TemplateRenderer._checkInset * 2);
                flag2 = flag;
                if (flag2)
                {
                    int num2 = e.Item.Bounds.Height - TemplateRenderer._checkInset * 2 - imageRectangle.Height;
                    imageRectangle.Height += num2;
                }
                UseAntiAlias useAntiAlias = new UseAntiAlias(e.Graphics);
                try
                {
                    GraphicsPath graphicsPath = this.CreateBorderPath(imageRectangle, TemplateRenderer._cutMenuItemBack);
                    try
                    {
                        SolidBrush solidBrush = new SolidBrush(TemplateRenderer.ColorTable.CheckBackground);
                        try
                        {
                            e.Graphics.FillPath(solidBrush, graphicsPath);
                        }
                        finally
                        {
                            flag = (solidBrush != null);
                            flag2 = flag;
                            if (flag2)
                            {
                                ((IDisposable)solidBrush).Dispose();
                            }
                        }
                        Pen pen = new Pen((Color)(e.Item.Selected ? TemplateRenderer._contextCheckBorderSelected : TemplateRenderer._contextCheckBorder));
                        try
                        {
                            e.Graphics.DrawPath(pen, graphicsPath);
                        }
                        finally
                        {
                            flag = (pen != null);
                            flag2 = flag;
                            if (flag2)
                            {
                                ((IDisposable)pen).Dispose();
                            }
                        }
                        flag = (e.Image != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            CheckState checkState = CheckState.Unchecked;
                            flag = (e.Item is ToolStripMenuItem);
                            flag2 = flag;
                            if (flag2)
                            {
                                ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.Item;
                                checkState = toolStripMenuItem.CheckState;
                            }
                            switch (checkState)
                            {
                                case CheckState.Checked:
                                    flag2 = true;
                                    if (flag2)
                                    {
                                        GraphicsPath graphicsPath2 = this.CreateTickPath(imageRectangle);
                                        try
                                        {
                                            Pen pen2 = new Pen((Color)(e.Item.Selected ? TemplateRenderer._contextCheckTickSelected : TemplateRenderer._contextCheckTick), TemplateRenderer._contextCheckTickThickness);
                                            try
                                            {
                                                e.Graphics.DrawPath(pen2, graphicsPath2);
                                            }
                                            finally
                                            {
                                                flag = (pen2 != null);
                                                flag2 = flag;
                                                if (flag2)
                                                {
                                                    ((IDisposable)pen2).Dispose();
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            flag = (graphicsPath2 != null);
                                            flag2 = flag;
                                            if (flag2)
                                            {
                                                ((IDisposable)graphicsPath2).Dispose();
                                            }
                                        }
                                    }
                                    break;
                                case CheckState.Indeterminate:
                                    flag2 = true;
                                    if (flag2)
                                    {
                                        GraphicsPath graphicsPath3 = this.CreateIndeterminatePath(imageRectangle);
                                        try
                                        {
                                            SolidBrush solidBrush2 = new SolidBrush((Color)(e.Item.Selected ? TemplateRenderer._contextCheckTickSelected : TemplateRenderer._contextCheckTick));
                                            try
                                            {
                                                e.Graphics.FillPath(solidBrush2, graphicsPath3);
                                            }
                                            finally
                                            {
                                                flag = (solidBrush2 != null);
                                                flag2 = flag;
                                                if (flag2)
                                                {
                                                    ((IDisposable)solidBrush2).Dispose();
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            flag = (graphicsPath3 != null);
                                            flag2 = flag;
                                            if (flag2)
                                            {
                                                ((IDisposable)graphicsPath3).Dispose();
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    finally
                    {
                        flag = (graphicsPath != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            ((IDisposable)graphicsPath).Dispose();
                        }
                    }
                }
                finally
                {
                    flag = (useAntiAlias != null);
                    flag2 = flag;
                    if (flag2)
                    {
                        ((IDisposable)useAntiAlias).Dispose();
                    }
                }
            }
        }
        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            bool flag = e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu;
            bool flag2 = flag;
            if (flag2)
            {
                bool flag3 = e.Image != null;
                flag2 = flag3;
                if (flag2)
                {
                    bool enabled = e.Item.Enabled;
                    flag2 = enabled;
                    if (flag2)
                    {
                        e.Graphics.DrawImage(e.Image, e.ImageRectangle);
                    }
                    else
                    {
                        ControlPaint.DrawImageDisabled(e.Graphics, e.Image, e.ImageRectangle.X, e.ImageRectangle.Y, Color.Transparent);
                    }
                }
            }
            else
            {
                base.OnRenderItemImage(e);
            }
        }
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            bool flag = !(e.ToolStrip is MenuStrip) && !(e.ToolStrip is ContextMenuStrip);
            bool flag2;
            bool flag3;
            if (flag)
            {
                flag2 = !(e.ToolStrip is ToolStripDropDownMenu);
                if (flag2)
                {
                    flag3 = false;
                    goto IL_45;
                }
            }
            flag3 = true;
        IL_45:
            bool flag4 = flag3;
            flag2 = flag4;
            if (flag2)
            {
                bool flag5 = e.Item.Pressed && e.ToolStrip is MenuStrip;
                flag2 = flag5;
                if (flag2)
                {
                    this.DrawContextMenuHeader(e.Graphics, e.Item);
                }
                else
                {
                    flag5 = e.Item.Selected;
                    flag2 = flag5;
                    if (flag2)
                    {
                        flag4 = e.Item.Enabled;
                        flag2 = flag4;
                        if (flag2)
                        {
                            bool flag6 = e.ToolStrip is MenuStrip;
                            flag2 = flag6;
                            if (flag2)
                            {
                                this.DrawGradientToolItem(e.Graphics, e.Item, TemplateRenderer._itemToolItemSelectedColors);
                            }
                            else
                            {
                                this.DrawGradientContextMenuItem(e.Graphics, e.Item, TemplateRenderer._itemContextItemEnabledColors);
                            }
                        }
                        else
                        {
                            Point pt = e.ToolStrip.PointToClient(Control.MousePosition);
                            bool flag7 = !e.Item.Bounds.Contains(pt);
                            flag2 = flag7;
                            if (flag2)
                            {
                                flag5 = (e.ToolStrip is MenuStrip);
                                flag2 = flag5;
                                if (flag2)
                                {
                                    this.DrawGradientToolItem(e.Graphics, e.Item, TemplateRenderer._itemDisabledColors);
                                }
                                else
                                {
                                    this.DrawGradientContextMenuItem(e.Graphics, e.Item, TemplateRenderer._itemDisabledColors);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }
        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            bool flag = e.Item.Selected || e.Item.Pressed;
            bool flag2 = flag;
            if (flag2)
            {
                ToolStripSplitButton toolStripSplitButton = (ToolStripSplitButton)e.Item;
                this.RenderToolSplitButtonBackground(e.Graphics, toolStripSplitButton, e.ToolStrip);
                Rectangle dropDownButtonBounds = toolStripSplitButton.DropDownButtonBounds;
                this.OnRenderArrow(new ToolStripArrowRenderEventArgs(e.Graphics, toolStripSplitButton, dropDownButtonBounds, SystemColors.ControlText, ArrowDirection.Down));
            }
            else
            {
                base.OnRenderSplitButtonBackground(e);
            }
        }
        protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(TemplateRenderer._gripDark);
            checked
            {
                try
                {
                    SolidBrush solidBrush2 = new SolidBrush(TemplateRenderer._gripLight);
                    try
                    {
                        bool flag = e.ToolStrip.RightToLeft == RightToLeft.Yes;
                        int num = e.AffectedBounds.Bottom - TemplateRenderer._gripSize * 2 + 1;
                        int num2 = TemplateRenderer._gripLines;
                        while (true)
                        {
                            int num3 = num2;
                            int num4 = 1;
                            bool flag2 = num3 < num4;
                            if (flag2)
                            {
                                break;
                            }
                            int num5 = flag ? (e.AffectedBounds.Left + 1) : (e.AffectedBounds.Right - TemplateRenderer._gripSize * 2 + 1);
                            int num6 = 0;
                            int num7 = num2 - 1;
                            int num8 = num6;
                            while (true)
                            {
                                int num9 = num8;
                                num4 = num7;
                                flag2 = (num9 > num4);
                                if (flag2)
                                {
                                    break;
                                }
                                this.DrawGripGlyph(e.Graphics, num5, num, solidBrush, solidBrush2);
                                num5 -= (flag ? (0 - TemplateRenderer._gripMove) : TemplateRenderer._gripMove);
                                num8++;
                            }
                            num -= TemplateRenderer._gripMove;
                            num2 += -1;
                        }
                    }
                    finally
                    {
                        bool flag3 = solidBrush2 != null;
                        bool flag2 = flag3;
                        if (flag2)
                        {
                            ((IDisposable)solidBrush2).Dispose();
                        }
                    }
                }
                finally
                {
                    bool flag4 = solidBrush != null;
                    bool flag2 = flag4;
                    if (flag2)
                    {
                        ((IDisposable)solidBrush).Dispose();
                    }
                }
            }
        }
        protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
        {
            base.OnRenderToolStripContentPanelBackground(e);
            bool flag = e.ToolStripContentPanel.Width > 0 && e.ToolStripContentPanel.Height > 0;
            bool flag2 = flag;
            if (flag2)
            {
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(e.ToolStripContentPanel.ClientRectangle, TemplateRenderer.ColorTable.ToolStripContentPanelGradientEnd, TemplateRenderer.ColorTable.ToolStripContentPanelGradientBegin, 90f);
                try
                {
                    e.Graphics.FillRectangle(linearGradientBrush, e.ToolStripContentPanel.ClientRectangle);
                }
                finally
                {
                    flag = (linearGradientBrush != null);
                    flag2 = flag;
                    if (flag2)
                    {
                        ((IDisposable)linearGradientBrush).Dispose();
                    }
                }
            }
        }
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 48)), e.AffectedBounds);
            //return;

            bool flag = e.ToolStrip is StatusStrip;
            if (!flag)
            {
                bool flag2 = e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu;
                flag = flag2;
                if (flag)
                {
                    GraphicsPath graphicsPath = this.CreateBorderPath(e.AffectedBounds, TemplateRenderer._cutContextMenu);
                    try
                    {
                        GraphicsPath graphicsPath2 = this.CreateClipBorderPath(e.AffectedBounds, TemplateRenderer._cutContextMenu);
                        try
                        {
                            UseClipping useClipping = new UseClipping(e.Graphics, graphicsPath2);
                            try
                            {
                                SolidBrush solidBrush = new SolidBrush(TemplateRenderer._contextMenuBack);
                                try
                                {
                                    e.Graphics.FillPath(solidBrush, graphicsPath);
                                }
                                finally
                                {
                                    flag2 = (solidBrush != null);
                                    flag = flag2;
                                    if (flag)
                                    {
                                        ((IDisposable)solidBrush).Dispose();
                                    }
                                }
                            }
                            finally
                            {
                                flag2 = (useClipping != null);
                                flag = flag2;
                                if (flag)
                                {
                                    ((IDisposable)useClipping).Dispose();
                                }
                            }
                        }
                        finally
                        {
                            flag2 = (graphicsPath2 != null);
                            flag = flag2;
                            if (flag)
                            {
                                ((IDisposable)graphicsPath2).Dispose();
                            }
                        }
                    }
                    finally
                    {
                        flag2 = (graphicsPath != null);
                        flag = flag2;
                        if (flag)
                        {
                            ((IDisposable)graphicsPath).Dispose();
                        }
                    }
                }
                else
                {
                    flag2 = (e.ToolStrip is StatusStrip);
                    flag = flag2;
                    if (flag)
                    {
                        RectangleF rect = new RectangleF(0f, 1.5f, (float)e.ToolStrip.Width, (float)checked(e.ToolStrip.Height - 2));
                        flag2 = (rect.Width > 0f && rect.Height > 0f);
                        flag = flag2;
                        if (flag)
                        {
                            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, TemplateRenderer.ColorTable.StatusStripGradientBegin, TemplateRenderer.ColorTable.StatusStripGradientEnd, 90f);
                            try
                            {
                                linearGradientBrush.Blend = TemplateRenderer._statusStripBlend;
                                e.Graphics.FillRectangle(linearGradientBrush, rect);
                            }
                            finally
                            {
                                flag2 = (linearGradientBrush != null);
                                flag = flag2;
                                if (flag)
                                {
                                    ((IDisposable)linearGradientBrush).Dispose();
                                }
                            }
                        }
                    }
                    else
                    {
                        base.OnRenderToolStripBackground(e);
                    }
                }
            }
        }
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            bool flag = e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu;
            bool flag2 = flag;
            checked
            {
                if (flag2)
                {
                    Rectangle affectedBounds = e.AffectedBounds;
                    bool flag3 = e.ToolStrip.RightToLeft == RightToLeft.Yes;
                    affectedBounds.Y += TemplateRenderer._marginInset;
                    affectedBounds.Height -= TemplateRenderer._marginInset * 2;
                    flag = !flag3;
                    flag2 = flag;
                    if (flag2)
                    {
                        affectedBounds.X += TemplateRenderer._marginInset;
                    }
                    else
                    {
                        affectedBounds.X = (int)Math.Round(Math.Round(unchecked((double)affectedBounds.X + (double)TemplateRenderer._marginInset / 2.0)));
                    }
                    SolidBrush solidBrush = new SolidBrush(TemplateRenderer.ColorTable.ImageMarginGradientBegin);
                    try
                    {
                        e.Graphics.FillRectangle(solidBrush, affectedBounds);
                    }
                    finally
                    {
                        flag = (solidBrush != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            ((IDisposable)solidBrush).Dispose();
                        }
                    }
                    Pen pen = new Pen(TemplateRenderer._separatorMenuLight);
                    try
                    {
                        Pen pen2 = new Pen(TemplateRenderer._separatorMenuDark);
                        try
                        {
                            flag = !flag3;
                            flag2 = flag;
                            if (flag2)
                            {
                                e.Graphics.DrawLine(pen, affectedBounds.Right, affectedBounds.Top, affectedBounds.Right, affectedBounds.Bottom);
                                e.Graphics.DrawLine(pen2, affectedBounds.Right - 1, affectedBounds.Top, affectedBounds.Right - 1, affectedBounds.Bottom);
                            }
                            else
                            {
                                e.Graphics.DrawLine(pen, affectedBounds.Left - 1, affectedBounds.Top, affectedBounds.Left - 1, affectedBounds.Bottom);
                                e.Graphics.DrawLine(pen2, affectedBounds.Left, affectedBounds.Top, affectedBounds.Left, affectedBounds.Bottom);
                            }
                        }
                        finally
                        {
                            flag = (pen2 != null);
                            flag2 = flag;
                            if (flag2)
                            {
                                ((IDisposable)pen2).Dispose();
                            }
                        }
                    }
                    finally
                    {
                        flag = (pen != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            ((IDisposable)pen).Dispose();
                        }
                    }
                }
                else
                {
                    base.OnRenderImageMargin(e);
                }
            }
        }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            return;

            /*bool flag = e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu;
            bool flag2 = flag;
            checked
            {
                if (flag2)
                {
                    bool flag3 = !e.ConnectedArea.IsEmpty;
                    flag2 = flag3;
                    if (flag2)
                    {
                        SolidBrush solidBrush = new SolidBrush(TemplateRenderer._contextMenuBack);
                        try
                        {
                            e.Graphics.FillRectangle(solidBrush, e.ConnectedArea);
                        }
                        finally
                        {
                            flag3 = (solidBrush != null);
                            flag2 = flag3;
                            if (flag2)
                            {
                                ((IDisposable)solidBrush).Dispose();
                            }
                        }
                    }
                    GraphicsPath graphicsPath = this.CreateBorderPath(e.AffectedBounds, e.ConnectedArea, TemplateRenderer._cutContextMenu);
                    try
                    {
                        GraphicsPath graphicsPath2 = this.CreateInsideBorderPath(e.AffectedBounds, e.ConnectedArea, TemplateRenderer._cutContextMenu);
                        try
                        {
                            GraphicsPath graphicsPath3 = this.CreateClipBorderPath(e.AffectedBounds, e.ConnectedArea, TemplateRenderer._cutContextMenu);
                            try
                            {
                                Pen pen = new Pen(TemplateRenderer.ColorTable.MenuBorder);
                                try
                                {
                                    Pen pen2 = new Pen(TemplateRenderer._separatorMenuLight);
                                    try
                                    {
                                        UseClipping useClipping = new UseClipping(e.Graphics, graphicsPath3);
                                        try
                                        {
                                            UseAntiAlias useAntiAlias = new UseAntiAlias(e.Graphics);
                                            try
                                            {
                                                e.Graphics.DrawPath(pen2, graphicsPath2);
                                                e.Graphics.DrawPath(pen, graphicsPath);
                                            }
                                            finally
                                            {
                                                flag3 = (useAntiAlias != null);
                                                flag2 = flag3;
                                                if (flag2)
                                                {
                                                    ((IDisposable)useAntiAlias).Dispose();
                                                }
                                            }
                                            e.Graphics.DrawLine(pen, e.AffectedBounds.Right, e.AffectedBounds.Bottom, e.AffectedBounds.Right - 1, e.AffectedBounds.Bottom - 1);
                                        }
                                        finally
                                        {
                                            flag3 = (useClipping != null);
                                            flag2 = flag3;
                                            if (flag2)
                                            {
                                                ((IDisposable)useClipping).Dispose();
                                            }
                                        }
                                    }
                                    finally
                                    {
                                        flag3 = (pen2 != null);
                                        flag2 = flag3;
                                        if (flag2)
                                        {
                                            ((IDisposable)pen2).Dispose();
                                        }
                                    }
                                }
                                finally
                                {
                                    flag3 = (pen != null);
                                    flag2 = flag3;
                                    if (flag2)
                                    {
                                        ((IDisposable)pen).Dispose();
                                    }
                                }
                            }
                            finally
                            {
                                flag3 = (graphicsPath3 != null);
                                flag2 = flag3;
                                if (flag2)
                                {
                                    ((IDisposable)graphicsPath3).Dispose();
                                }
                            }
                        }
                        finally
                        {
                            flag3 = (graphicsPath2 != null);
                            flag2 = flag3;
                            if (flag2)
                            {
                                ((IDisposable)graphicsPath2).Dispose();
                            }
                        }
                    }
                    finally
                    {
                        flag3 = (graphicsPath != null);
                        flag2 = flag3;
                        if (flag2)
                        {
                            ((IDisposable)graphicsPath).Dispose();
                        }
                    }
                }
                else
                {
                    bool flag4 = e.ToolStrip is StatusStrip;
                    flag2 = flag4;
                    if (flag2)
                    {
                        Pen pen3 = new Pen(TemplateRenderer._statusStripBorderDark);
                        try
                        {
                            Pen pen4 = new Pen(TemplateRenderer._statusStripBorderLight);
                            try
                            {
                                e.Graphics.DrawLine(pen3, 0, 0, e.ToolStrip.Width, 0);
                                e.Graphics.DrawLine(pen4, 0, 1, e.ToolStrip.Width, 1);
                            }
                            finally
                            {
                                flag4 = (pen4 != null);
                                flag2 = flag4;
                                if (flag2)
                                {
                                    ((IDisposable)pen4).Dispose();
                                }
                            }
                        }
                        finally
                        {
                            flag4 = (pen3 != null);
                            flag2 = flag4;
                            if (flag2)
                            {
                                ((IDisposable)pen3).Dispose();
                            }
                        }
                    }
                    else
                    {
                        base.OnRenderToolStripBorder(e);
                    }
                }
            }*/
        }
        private void RenderToolButtonBackground(Graphics g, ToolStripButton button, ToolStrip toolstrip)
        {
            bool enabled = button.Enabled;
            bool flag = enabled;
            if (flag)
            {
                bool @checked = button.Checked;
                flag = @checked;
                if (flag)
                {
                    bool flag2 = button.Pressed;
                    flag = flag2;
                    if (flag)
                    {
                        this.DrawGradientToolItem(g, button, TemplateRenderer._itemToolItemPressedColors);
                    }
                    else
                    {
                        flag2 = button.Selected;
                        flag = flag2;
                        if (flag)
                        {
                            this.DrawGradientToolItem(g, button, TemplateRenderer._itemToolItemCheckPressColors);
                        }
                        else
                        {
                            this.DrawGradientToolItem(g, button, TemplateRenderer._itemToolItemCheckedColors);
                        }
                    }
                }
                else
                {
                    bool flag3 = button.Pressed;
                    flag = flag3;
                    if (flag)
                    {
                        this.DrawGradientToolItem(g, button, TemplateRenderer._itemToolItemPressedColors);
                    }
                    else
                    {
                        flag3 = button.Selected;
                        flag = flag3;
                        if (flag)
                        {
                            this.DrawGradientToolItem(g, button, TemplateRenderer._itemToolItemSelectedColors);
                        }
                    }
                }
            }
            else
            {
                bool flag4 = button.Selected;
                flag = flag4;
                if (flag)
                {
                    Point pt = toolstrip.PointToClient(Control.MousePosition);
                    flag4 = !button.Bounds.Contains(pt);
                    flag = flag4;
                    if (flag)
                    {
                        this.DrawGradientToolItem(g, button, TemplateRenderer._itemDisabledColors);
                    }
                }
            }
        }
        private void RenderToolDropButtonBackground(Graphics g, ToolStripItem item, ToolStrip toolstrip)
        {
            bool flag = item.Selected || item.Pressed;
            bool flag2 = flag;
            if (flag2)
            {
                bool enabled = item.Enabled;
                flag2 = enabled;
                if (flag2)
                {
                    bool pressed = item.Pressed;
                    flag2 = pressed;
                    if (flag2)
                    {
                        this.DrawContextMenuHeader(g, item);
                    }
                    else
                    {
                        this.DrawGradientToolItem(g, item, TemplateRenderer._itemToolItemSelectedColors);
                    }
                }
                else
                {
                    Point pt = toolstrip.PointToClient(Control.MousePosition);
                    bool flag3 = !item.Bounds.Contains(pt);
                    flag2 = flag3;
                    if (flag2)
                    {
                        this.DrawGradientToolItem(g, item, TemplateRenderer._itemDisabledColors);
                    }
                }
            }
        }
        private void RenderToolSplitButtonBackground(Graphics g, ToolStripSplitButton splitButton, ToolStrip toolstrip)
        {
            bool flag = splitButton.Selected || splitButton.Pressed;
            bool flag2 = flag;
            if (flag2)
            {
                bool enabled = splitButton.Enabled;
                flag2 = enabled;
                if (flag2)
                {
                    bool flag3 = !splitButton.Pressed && splitButton.ButtonPressed;
                    flag2 = flag3;
                    if (flag2)
                    {
                        this.DrawGradientToolSplitItem(g, splitButton, TemplateRenderer._itemToolItemPressedColors, TemplateRenderer._itemToolItemSelectedColors, TemplateRenderer._itemContextItemEnabledColors);
                    }
                    else
                    {
                        flag3 = (splitButton.Pressed && !splitButton.ButtonPressed);
                        flag2 = flag3;
                        if (flag2)
                        {
                            this.DrawContextMenuHeader(g, splitButton);
                        }
                        else
                        {
                            this.DrawGradientToolSplitItem(g, splitButton, TemplateRenderer._itemToolItemSelectedColors, TemplateRenderer._itemToolItemSelectedColors, TemplateRenderer._itemContextItemEnabledColors);
                        }
                    }
                }
                else
                {
                    Point pt = toolstrip.PointToClient(Control.MousePosition);
                    bool flag4 = !splitButton.Bounds.Contains(pt);
                    flag2 = flag4;
                    if (flag2)
                    {
                        this.DrawGradientToolItem(g, splitButton, TemplateRenderer._itemDisabledColors);
                    }
                }
            }
        }
        public GraphicsPath DrawArc(Rectangle Rectangle, int Radius = 4)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(Rectangle.X, Rectangle.Y, Radius, Radius, 180f, 90f);
            checked
            {
                graphicsPath.AddArc(Rectangle.Width - Radius, Rectangle.Y, Radius, Radius, 270f, 90f);
                graphicsPath.AddArc(Rectangle.Width - Radius, Rectangle.Height - Radius, Radius, Radius, 0f, 90f);
                graphicsPath.AddArc(Rectangle.X, Rectangle.Height - Radius, Radius, Radius, 90f, 90f);
                graphicsPath.CloseFigure();
                return graphicsPath;
            }
        }
        private void DrawGradientToolItem(Graphics g, ToolStripItem item, TemplateRenderer.GradientItemColors colors)
        {
            Rectangle backRect = new Rectangle(Point.Empty, item.Bounds.Size);
            this.DrawGradientItem(g, backRect, colors);
        }
        private void DrawGradientToolSplitItem(Graphics g, ToolStripSplitButton splitButton, TemplateRenderer.GradientItemColors colorsButton, TemplateRenderer.GradientItemColors colorsDrop, TemplateRenderer.GradientItemColors colorsSplit)
        {
            Point empty = Point.Empty;
            Rectangle bounds = splitButton.Bounds;
            Rectangle rectangle = new Rectangle(empty, bounds.Size);
            Rectangle dropDownButtonBounds = splitButton.DropDownButtonBounds;
            bool flag = rectangle.Width > 0 && dropDownButtonBounds.Width > 0 && rectangle.Height > 0 && dropDownButtonBounds.Height > 0;
            bool flag2 = flag;
            checked
            {
                if (flag2)
                {
                    Rectangle backRect = rectangle;
                    flag = (dropDownButtonBounds.X > 0);
                    flag2 = flag;
                    int num;
                    if (flag2)
                    {
                        backRect.Width = dropDownButtonBounds.Left;
                        dropDownButtonBounds.X--;
                        dropDownButtonBounds.Width++;
                        num = dropDownButtonBounds.X;
                    }
                    else
                    {
                        backRect.Width -= dropDownButtonBounds.Width - 2;
                        backRect.X = dropDownButtonBounds.Right - 1;
                        dropDownButtonBounds.Width++;
                        num = dropDownButtonBounds.Right - 1;
                    }
                    GraphicsPath graphicsPath = this.CreateBorderPath(rectangle, TemplateRenderer._cutMenuItemBack);
                    try
                    {
                        this.DrawGradientBack(g, backRect, colorsButton);
                        this.DrawGradientBack(g, dropDownButtonBounds, colorsDrop);
                        bounds = new Rectangle(rectangle.X + num, rectangle.Top, 1, rectangle.Height + 1);
                        LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, colorsSplit.cBorder1, colorsSplit.cBorder2, 90f);
                        try
                        {
                            linearGradientBrush.SetSigmaBellShape(0.5f);
                            Pen pen = new Pen(linearGradientBrush);
                            try
                            {
                                g.DrawLine(pen, rectangle.X + num, rectangle.Top + 1, rectangle.X + num, rectangle.Bottom - 1);
                            }
                            finally
                            {
                                flag = (pen != null);
                                flag2 = flag;
                                if (flag2)
                                {
                                    ((IDisposable)pen).Dispose();
                                }
                            }
                        }
                        finally
                        {
                            flag = (linearGradientBrush != null);
                            flag2 = flag;
                            if (flag2)
                            {
                                ((IDisposable)linearGradientBrush).Dispose();
                            }
                        }
                        this.DrawGradientBorder(g, rectangle, colorsButton);
                    }
                    finally
                    {
                        flag = (graphicsPath != null);
                        flag2 = flag;
                        if (flag2)
                        {
                            ((IDisposable)graphicsPath).Dispose();
                        }
                    }
                }
            }
        }
        private void DrawContextMenuHeader(Graphics g, ToolStripItem item)
        {
            Rectangle rect = new Rectangle(Point.Empty, item.Bounds.Size);
            GraphicsPath graphicsPath = this.CreateBorderPath(rect, TemplateRenderer._cutToolItemMenu);
            try
            {
                GraphicsPath graphicsPath2 = this.CreateInsideBorderPath(rect, TemplateRenderer._cutToolItemMenu);
                try
                {
                    GraphicsPath graphicsPath3 = this.CreateClipBorderPath(rect, TemplateRenderer._cutToolItemMenu);
                    try
                    {
                        UseClipping useClipping = new UseClipping(g, graphicsPath3);
                        try
                        {
                            SolidBrush solidBrush = new SolidBrush(TemplateRenderer._separatorMenuLight);
                            try
                            {
                                g.FillPath(solidBrush, graphicsPath);
                            }
                            finally
                            {
                                bool flag = solidBrush != null;
                                bool flag2 = flag;
                                if (flag2)
                                {
                                    ((IDisposable)solidBrush).Dispose();
                                }
                            }
                            Pen pen = new Pen(TemplateRenderer.ColorTable.MenuBorder);
                            try
                            {
                                g.DrawPath(pen, graphicsPath);
                            }
                            finally
                            {
                                bool flag3 = pen != null;
                                bool flag2 = flag3;
                                if (flag2)
                                {
                                    ((IDisposable)pen).Dispose();
                                }
                            }
                        }
                        finally
                        {
                            bool flag4 = useClipping != null;
                            bool flag2 = flag4;
                            if (flag2)
                            {
                                ((IDisposable)useClipping).Dispose();
                            }
                        }
                    }
                    finally
                    {
                        bool flag5 = graphicsPath3 != null;
                        bool flag2 = flag5;
                        if (flag2)
                        {
                            ((IDisposable)graphicsPath3).Dispose();
                        }
                    }
                }
                finally
                {
                    bool flag6 = graphicsPath2 != null;
                    bool flag2 = flag6;
                    if (flag2)
                    {
                        ((IDisposable)graphicsPath2).Dispose();
                    }
                }
            }
            finally
            {
                bool flag7 = graphicsPath != null;
                bool flag2 = flag7;
                if (flag2)
                {
                    ((IDisposable)graphicsPath).Dispose();
                }
            }
        }
        private void DrawGradientContextMenuItem(Graphics g, ToolStripItem item, TemplateRenderer.GradientItemColors colors)
        {
            Rectangle backRect = new Rectangle(2, 0, checked(item.Bounds.Width - 3), item.Bounds.Height);
            this.DrawGradientItem(g, backRect, colors);
        }
        private void DrawGradientItem(Graphics g, Rectangle backRect, TemplateRenderer.GradientItemColors colors)
        {
            bool flag = backRect.Width > 0 && backRect.Height > 0;
            bool flag2 = flag;
            if (flag2)
            {
                this.DrawGradientBack(g, backRect, colors);
                this.DrawGradientBorder(g, backRect, colors);
            }
        }
        private void DrawGradientBack(Graphics g, Rectangle backRect, TemplateRenderer.GradientItemColors colors)
        {
            backRect.Inflate(-1, -1);
            checked
            {
                int num = (int)Math.Round(Math.Round((double)backRect.Height / 2.0));
                Rectangle rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
                Rectangle rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
                Rectangle rect = rectangle;
                Rectangle rect2 = rectangle2;
                rect.Inflate(1, 1);
                rect2.Inflate(1, 1);
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, colors.cInsideTop1, colors.cInsideTop2, 90f);
                try
                {
                    LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rect2, colors.cInsideBottom1, colors.cInsideBottom2, 90f);
                    try
                    {
                        g.FillRectangle(linearGradientBrush, rectangle);
                        g.FillRectangle(linearGradientBrush2, rectangle2);
                    }
                    finally
                    {
                        bool flag = linearGradientBrush2 != null;
                        bool flag2 = flag;
                        if (flag2)
                        {
                            ((IDisposable)linearGradientBrush2).Dispose();
                        }
                    }
                }
                finally
                {
                    bool flag3 = linearGradientBrush != null;
                    bool flag2 = flag3;
                    if (flag2)
                    {
                        ((IDisposable)linearGradientBrush).Dispose();
                    }
                }
                num = (int)Math.Round(Math.Round((double)backRect.Height / 2.0));
                rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
                rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
                rect = rectangle;
                rect2 = rectangle2;
                rect.Inflate(1, 1);
                rect2.Inflate(1, 1);
                LinearGradientBrush linearGradientBrush3 = new LinearGradientBrush(rect, colors.cFillTop1, colors.cFillTop2, 90f);
                try
                {
                    LinearGradientBrush linearGradientBrush4 = new LinearGradientBrush(rect2, colors.cFillBottom1, colors.cFillBottom2, 90f);
                    try
                    {
                        backRect.Inflate(-1, -1);
                        num = (int)Math.Round(Math.Round((double)backRect.Height / 2.0));
                        rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
                        rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
                        g.FillRectangle(linearGradientBrush3, rectangle);
                        g.FillRectangle(linearGradientBrush4, rectangle2);
                    }
                    finally
                    {
                        bool flag4 = linearGradientBrush4 != null;
                        bool flag2 = flag4;
                        if (flag2)
                        {
                            ((IDisposable)linearGradientBrush4).Dispose();
                        }
                    }
                }
                finally
                {
                    bool flag5 = linearGradientBrush3 != null;
                    bool flag2 = flag5;
                    if (flag2)
                    {
                        ((IDisposable)linearGradientBrush3).Dispose();
                    }
                }
            }
        }
        private void DrawGradientBorder(Graphics g, Rectangle backRect, TemplateRenderer.GradientItemColors colors)
        {
            UseAntiAlias useAntiAlias = new UseAntiAlias(g);
            try
            {
                Rectangle rect = backRect;
                rect.Inflate(1, 1);
                LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, colors.cBorder1, colors.cBorder2, 90f);
                try
                {
                    linearGradientBrush.SetSigmaBellShape(0.5f);
                    Pen pen = new Pen(linearGradientBrush);
                    try
                    {
                        GraphicsPath graphicsPath = this.CreateBorderPath(backRect, TemplateRenderer._cutMenuItemBack);
                        try
                        {
                            g.DrawPath(pen, graphicsPath);
                        }
                        finally
                        {
                            bool flag = graphicsPath != null;
                            bool flag2 = flag;
                            if (flag2)
                            {
                                ((IDisposable)graphicsPath).Dispose();
                            }
                        }
                    }
                    finally
                    {
                        bool flag3 = pen != null;
                        bool flag2 = flag3;
                        if (flag2)
                        {
                            ((IDisposable)pen).Dispose();
                        }
                    }
                }
                finally
                {
                    bool flag4 = linearGradientBrush != null;
                    bool flag2 = flag4;
                    if (flag2)
                    {
                        ((IDisposable)linearGradientBrush).Dispose();
                    }
                }
            }
            finally
            {
                bool flag5 = useAntiAlias != null;
                bool flag2 = flag5;
                if (flag2)
                {
                    ((IDisposable)useAntiAlias).Dispose();
                }
            }
        }
        private void DrawGripGlyph(Graphics g, int x, int y, Brush darkBrush, Brush lightBrush)
        {
            checked
            {
                g.FillRectangle(lightBrush, x + TemplateRenderer._gripOffset, y + TemplateRenderer._gripOffset, TemplateRenderer._gripSquare, TemplateRenderer._gripSquare);
                g.FillRectangle(darkBrush, x, y, TemplateRenderer._gripSquare, TemplateRenderer._gripSquare);
            }
        }
        private GraphicsPath CreateBorderPath(Rectangle rect, Rectangle exclude, float cut)
        {
            bool flag = exclude.IsEmpty;
            bool flag2 = flag;
            checked
            {
                GraphicsPath result;
                if (flag2)
                {
                    result = this.CreateBorderPath(rect, cut);
                }
                else
                {
                    rect.Width--;
                    rect.Height--;
                    List<PointF> list = new List<PointF>();
                    float x = (float)rect.X;
                    float num = (float)rect.Y;
                    float x2 = (float)rect.Right;
                    float y = (float)rect.Bottom;
                    GraphicsPath graphicsPath;
                    int num7;
                    unchecked
                    {
                        float num2 = (float)rect.X + cut;
                        float num3 = (float)rect.Right - cut;
                        float y2 = (float)rect.Y + cut;
                        float y3 = (float)rect.Bottom - cut;
                        float num4 = (cut == 0f) ? 1f : cut;
                        flag = (rect.Y >= exclude.Top && rect.Y <= exclude.Bottom);
                        flag2 = flag;
                        PointF item;
                        if (flag2)
                        {
                            float num5 = (float)checked(exclude.X - 1) - cut;
                            float num6 = (float)exclude.Right + cut;
                            flag = (num2 <= num5);
                            flag2 = flag;
                            if (flag2)
                            {
                                List<PointF> list2 = list;
                                item = new PointF(num2, num);
                                list2.Add(item);
                                List<PointF> list3 = list;
                                item = new PointF(num5, num);
                                list3.Add(item);
                                List<PointF> list4 = list;
                                item = new PointF(num5 + cut, num - num4);
                                list4.Add(item);
                            }
                            else
                            {
                                num5 = (float)checked(exclude.X - 1);
                                List<PointF> list5 = list;
                                item = new PointF(num5, num);
                                list5.Add(item);
                                List<PointF> list6 = list;
                                item = new PointF(num5, num - num4);
                                list6.Add(item);
                            }
                            flag = (num3 > num6);
                            flag2 = flag;
                            if (flag2)
                            {
                                List<PointF> list7 = list;
                                item = new PointF(num6 - cut, num - num4);
                                list7.Add(item);
                                List<PointF> list8 = list;
                                item = new PointF(num6, num);
                                list8.Add(item);
                                List<PointF> list9 = list;
                                item = new PointF(num3, num);
                                list9.Add(item);
                            }
                            else
                            {
                                num6 = (float)exclude.Right;
                                List<PointF> list10 = list;
                                item = new PointF(num6, num - num4);
                                list10.Add(item);
                                List<PointF> list11 = list;
                                item = new PointF(num6, num);
                                list11.Add(item);
                            }
                        }
                        else
                        {
                            List<PointF> list12 = list;
                            item = new PointF(num2, num);
                            list12.Add(item);
                            List<PointF> list13 = list;
                            item = new PointF(num3, num);
                            list13.Add(item);
                        }
                        List<PointF> list14 = list;
                        item = new PointF(x2, y2);
                        list14.Add(item);
                        List<PointF> list15 = list;
                        item = new PointF(x2, y3);
                        list15.Add(item);
                        List<PointF> list16 = list;
                        item = new PointF(num3, y);
                        list16.Add(item);
                        List<PointF> list17 = list;
                        item = new PointF(num2, y);
                        list17.Add(item);
                        List<PointF> list18 = list;
                        item = new PointF(x, y3);
                        list18.Add(item);
                        List<PointF> list19 = list;
                        item = new PointF(x, y2);
                        list19.Add(item);
                        graphicsPath = new GraphicsPath();
                        num7 = 1;
                    }
                    int num8 = list.Count - 1;
                    int num9 = num7;
                    while (true)
                    {
                        int num10 = num9;
                        int num11 = num8;
                        flag2 = (num10 > num11);
                        if (flag2)
                        {
                            break;
                        }
                        graphicsPath.AddLine(list[num9 - 1], list[num9]);
                        num9++;
                    }
                    graphicsPath.AddLine(list[list.Count - 1], list[0]);
                    result = graphicsPath;
                }
                return result;
            }
        }
        private GraphicsPath CreateBorderPath(Rectangle rect, float cut)
        {
            GraphicsPath graphicsPath;
            checked
            {
                rect.Width--;
                rect.Height--;
                graphicsPath = new GraphicsPath();
            }
            graphicsPath.AddLine((float)rect.Left + cut, (float)rect.Top, (float)rect.Right - cut, (float)rect.Top);
            graphicsPath.AddLine((float)rect.Right - cut, (float)rect.Top, (float)rect.Right, (float)rect.Top + cut);
            graphicsPath.AddLine((float)rect.Right, (float)rect.Top + cut, (float)rect.Right, (float)rect.Bottom - cut);
            graphicsPath.AddLine((float)rect.Right, (float)rect.Bottom - cut, (float)rect.Right - cut, (float)rect.Bottom);
            graphicsPath.AddLine((float)rect.Right - cut, (float)rect.Bottom, (float)rect.Left + cut, (float)rect.Bottom);
            graphicsPath.AddLine((float)rect.Left + cut, (float)rect.Bottom, (float)rect.Left, (float)rect.Bottom - cut);
            graphicsPath.AddLine((float)rect.Left, (float)rect.Bottom - cut, (float)rect.Left, (float)rect.Top + cut);
            graphicsPath.AddLine((float)rect.Left, (float)rect.Top + cut, (float)rect.Left + cut, (float)rect.Top);
            return graphicsPath;
        }
        private GraphicsPath CreateInsideBorderPath(Rectangle rect, float cut)
        {
            rect.Inflate(-1, -1);
            return this.CreateBorderPath(rect, cut);
        }
        private GraphicsPath CreateInsideBorderPath(Rectangle rect, Rectangle exclude, float cut)
        {
            rect.Inflate(-1, -1);
            return this.CreateBorderPath(rect, exclude, cut);
        }
        private GraphicsPath CreateClipBorderPath(Rectangle rect, float cut)
        {
            checked
            {
                rect.Width++;
                rect.Height++;
                return this.CreateBorderPath(rect, cut);
            }
        }
        private GraphicsPath CreateClipBorderPath(Rectangle rect, Rectangle exclude, float cut)
        {
            checked
            {
                rect.Width++;
                rect.Height++;
                return this.CreateBorderPath(rect, exclude, cut);
            }
        }
        private GraphicsPath CreateArrowPath(ToolStripItem item, Rectangle rect, ArrowDirection direction)
        {
            bool flag = direction == ArrowDirection.Left || direction == ArrowDirection.Right;
            bool flag2 = flag;
            checked
            {
                int num;
                int num2;
                if (flag2)
                {
                    num = (int)Math.Round(Math.Round(unchecked((double)rect.Right - (double)checked(rect.Width - 4) / 2.0)));
                    num2 = (int)Math.Round(Math.Round(unchecked((double)rect.Y + (double)rect.Height / 2.0)));
                }
                else
                {
                    num = (int)Math.Round(Math.Round(unchecked((double)rect.X + (double)rect.Width / 2.0)));
                    num2 = (int)Math.Round(Math.Round(unchecked((double)rect.Bottom - (double)checked(rect.Height - 3) / 2.0)));
                    flag = (item is ToolStripDropDownButton && item.RightToLeft == RightToLeft.Yes);
                    flag2 = flag;
                    if (flag2)
                    {
                        num++;
                    }
                }
                GraphicsPath graphicsPath = new GraphicsPath();
                switch (direction)
                {
                    case ArrowDirection.Left:
                        graphicsPath.AddLine(num - 4, num2, num, num2 - 4);
                        graphicsPath.AddLine(num, num2 - 4, num, num2 + 4);
                        graphicsPath.AddLine(num, num2 + 4, num - 4, num2);
                        break;
                    case ArrowDirection.Up:
                        unchecked
                        {
                            graphicsPath.AddLine((float)num + 3f, (float)num2, (float)num - 3f, (float)num2);
                            graphicsPath.AddLine((float)num - 3f, (float)num2, (float)num, (float)num2 - 4f);
                            graphicsPath.AddLine((float)num, (float)num2 - 4f, (float)num + 3f, (float)num2);
                            break;
                        }
                    case ArrowDirection.Right:
                        graphicsPath.AddLine(num, num2, num - 4, num2 - 4);
                        graphicsPath.AddLine(num - 4, num2 - 4, num - 4, num2 + 4);
                        graphicsPath.AddLine(num - 4, num2 + 4, num, num2);
                        break;
                    case ArrowDirection.Down:
                        unchecked
                        {
                            graphicsPath.AddLine((float)num + 3f, (float)num2 - 3f, (float)num - 2f, (float)num2 - 3f);
                            graphicsPath.AddLine((float)num - 2f, (float)num2 - 3f, (float)num, (float)num2);
                            graphicsPath.AddLine((float)num, (float)num2, (float)num + 3f, (float)num2 - 3f);
                            break;
                        }
                }
                return graphicsPath;
            }
        }
        private GraphicsPath CreateTickPath(Rectangle rect)
        {
            checked
            {
                int num = (int)Math.Round(Math.Round(unchecked((double)rect.X + (double)rect.Width / 2.0)));
                int num2 = (int)Math.Round(Math.Round(unchecked((double)rect.Y + (double)rect.Height / 2.0)));
                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddLine(num - 4, num2, num - 2, num2 + 4);
                graphicsPath.AddLine(num - 2, num2 + 4, num + 3, num2 - 5);
                return graphicsPath;
            }
        }
        private GraphicsPath CreateIndeterminatePath(Rectangle rect)
        {
            checked
            {
                int num = (int)Math.Round(Math.Round(unchecked((double)rect.X + (double)rect.Width / 2.0)));
                int num2 = (int)Math.Round(Math.Round(unchecked((double)rect.Y + (double)rect.Height / 2.0)));
                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddLine(num - 3, num2, num, num2 - 3);
                graphicsPath.AddLine(num, num2 - 3, num + 3, num2);
                graphicsPath.AddLine(num + 3, num2, num, num2 + 3);
                graphicsPath.AddLine(num, num2 + 3, num - 3, num2);
                return graphicsPath;
            }
        }
    }
    internal class UseAntiAlias : IDisposable
    {
        private Graphics _g;
        private SmoothingMode _old;
        public UseAntiAlias(Graphics g)
        {
            this._g = g;
            this._old = this._g.SmoothingMode;
            this._g.SmoothingMode = SmoothingMode.AntiAlias;
        }
        public void Dispose()
        {
            this._g.SmoothingMode = this._old;
        }
    }
    internal class UseClearTypeGridFit : IDisposable
    {
        private Graphics _g;
        private TextRenderingHint _old;
        public UseClearTypeGridFit(Graphics g)
        {
            this._g = g;
            this._old = this._g.TextRenderingHint;
            this._g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        }
        public void Dispose()
        {
            this._g.TextRenderingHint = this._old;
        }
    }
    internal class UseClipping : IDisposable
    {
        private Graphics _g;
        private Region _old;
        public UseClipping(Graphics g, GraphicsPath path)
        {
            this._g = g;
            this._old = g.Clip;
            Region region = this._old.Clone();
            region.Intersect(path);
            this._g.Clip = region;
        }
        public UseClipping(Graphics g, Region region)
        {
            this._g = g;
            this._old = g.Clip;
            Region region2 = this._old.Clone();
            region2.Intersect(region);
            this._g.Clip = region2;
        }
        public void Dispose()
        {
            this._g.Clip = this._old;
        }
    }
}
