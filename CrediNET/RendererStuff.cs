using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CrediNET
{
	public class Renderer
	{
		public RenderParams Colors;

		public Renderer()
		{
			Colors = new RenderParams();
		}

		public ToolStripRenderer GetRenderer()
		{
			return new TemplateRenderer(Colors);
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
			ColorTable = new TemplateColorTable();
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
			get { return _buttonPressedBegin; }
		}

		public override Color ButtonPressedGradientEnd
		{
			get { return _buttonPressedEnd; }
		}

		public override Color ButtonPressedGradientMiddle
		{
			get { return _buttonPressedMiddle; }
		}

		public override Color ButtonSelectedGradientBegin
		{
			get { return _buttonSelectedBegin; }
		}

		public override Color ButtonSelectedGradientEnd
		{
			get { return _buttonSelectedEnd; }
		}

		public override Color ButtonSelectedGradientMiddle
		{
			get { return _buttonSelectedMiddle; }
		}

		public override Color ButtonSelectedHighlightBorder
		{
			get { return _buttonBorder; }
		}

		public override Color CheckBackground
		{
			get { return _checkBack; }
		}

		public override Color GripDark
		{
			get { return _gripDark; }
		}

		public override Color GripLight
		{
			get { return _gripLight; }
		}

		public override Color ImageMarginGradientBegin
		{
			get { return _imageMargin; }
		}

		public override Color MenuBorder
		{
			get { return _menuBorder; }
		}

		public override Color MenuItemPressedGradientBegin
		{
			get { return _toolStripBegin; }
		}

		public override Color MenuItemPressedGradientEnd
		{
			get { return _toolStripEnd; }
		}

		public override Color MenuItemPressedGradientMiddle
		{
			get { return _toolStripMiddle; }
		}

		public override Color MenuItemSelectedGradientBegin
		{
			get { return _menuItemSelectedBegin; }
		}

		public override Color MenuItemSelectedGradientEnd
		{
			get { return _menuItemSelectedEnd; }
		}

		public override Color MenuStripGradientBegin
		{
			get { return _menuToolBack; }
		}

		public override Color MenuStripGradientEnd
		{
			get { return _menuToolBack; }
		}

		public override Color OverflowButtonGradientBegin
		{
			get { return _overflowBegin; }
		}

		public override Color OverflowButtonGradientEnd
		{
			get { return _overflowEnd; }
		}

		public override Color OverflowButtonGradientMiddle
		{
			get { return _overflowMiddle; }
		}

		public override Color RaftingContainerGradientBegin
		{
			get { return _menuToolBack; }
		}

		public override Color RaftingContainerGradientEnd
		{
			get { return _menuToolBack; }
		}

		public override Color SeparatorDark
		{
			get { return _separatorDark; }
		}

		public override Color SeparatorLight
		{
			get { return _separatorLight; }
		}

		public override Color StatusStripGradientBegin
		{
			get { return _statusStripLight; }
		}

		public override Color StatusStripGradientEnd
		{
			get { return _statusStripDark; }
		}

		public override Color ToolStripBorder
		{
			get { return _toolStripBorder; }
		}

		public override Color ToolStripContentPanelGradientBegin
		{
			get { return _toolStripContentEnd; }
		}

		public override Color ToolStripContentPanelGradientEnd
		{
			get { return _menuToolBack; }
		}

		public override Color ToolStripDropDownBackground
		{
			get { return _contextMenuBack; }
		}

		public override Color ToolStripGradientBegin
		{
			get { return _toolStripBegin; }
		}

		public override Color ToolStripGradientEnd
		{
			get { return _toolStripEnd; }
		}

		public override Color ToolStripGradientMiddle
		{
			get { return _toolStripMiddle; }
		}

		public override Color ToolStripPanelGradientBegin
		{
			get { return _menuToolBack; }
		}

		public override Color ToolStripPanelGradientEnd
		{
			get { return _menuToolBack; }
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

			public GradientItemColors(Color insideTop1, Color insideTop2, Color insideBottom1, Color insideBottom2,
				Color fillTop1, Color fillTop2, Color fillBottom1, Color fillBottom2, Color border1, Color border2)
			{
				cInsideTop1 = insideTop1;
				cInsideTop2 = insideTop2;
				cInsideBottom1 = insideBottom1;
				cInsideBottom2 = insideBottom2;
				cFillTop1 = fillTop1;
				cFillTop2 = fillTop2;
				cFillBottom1 = fillBottom1;
				cFillBottom2 = fillBottom2;
				cBorder1 = border1;
				cBorder2 = border2;
			}
		}

		private Color forecolor;
	    private static int _gripOffset;
		private static int _gripSquare;
		private static int _gripSize;
		private static int _gripMove;
		private static int _gripLines;
		private static int _checkInset;
		private static int _marginInset;
	    private static float _cutToolItemMenu;
		private static float _cutContextMenu;
		private static float _cutMenuItemBack;
		private static float _contextCheckTickThickness;
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
		private static GradientItemColors _itemContextItemEnabledColors;
		private static GradientItemColors _itemDisabledColors;
		private static GradientItemColors _itemToolItemSelectedColors;
		private static GradientItemColors _itemToolItemPressedColors;
		private static GradientItemColors _itemToolItemCheckedColors;
		private static GradientItemColors _itemToolItemCheckPressColors;

	    public bool IsGlassDesired { get; set; }

	    public TemplateRenderer(RenderParams @params)
		{
			RoundedEdges = false;
			forecolor = @params.foreColor;
			_gripOffset = @params.gripOffset;
			_gripSquare = @params.gripSquare;
			_gripSize = @params.gripSize;
			_gripMove = @params.gripMove;
			_gripLines = @params.gripLines;
			_checkInset = @params.checkInset;
			_marginInset = @params.marginInset;
		    _cutToolItemMenu = @params.cutToolItemMenu;
			_cutContextMenu = @params.cutContextMenu;
			_cutMenuItemBack = @params.cutMenuItemBack;
			_contextCheckTickThickness = @params.contextCheckTickThickness;
			ColorTable = (TemplateColorTable) @params.ColorTable;
			TemplateColorTable._imageMargin = @params.imageMargin;
			insideTop1 = @params.insideTop1;
			insideTop2 = @params.insideTop2;
			insideBottom1 = @params.insideBottom1;
			insideBottom2 = @params.insideBottom2;
			fillTop1 = @params.fillTop1;
			fillTop2 = @params.fillTop2;
			fillBottom1 = @params.fillBottom1;
			fillBottom2 = @params.fillBottom2;
			borderColor1 = @params.borderColor1;
			borderColor2 = @params.borderColor2;
			disabledInsideTop1 = @params.disabledInsideTop1;
			disabledInsideTop2 = @params.disabledInsideTop2;
			disabledInsideBottom1 = @params.disabledInsideBottom1;
			disabledInsideBottom2 = @params.disabledInsideBottom2;
			disabledFillTop1 = @params.disabledFillTop1;
			disabledFillTop2 = @params.disabledFillTop2;
			disabledFillBottom1 = @params.disabledFillBottom1;
			disabledFillBottom2 = @params.disabledFillBottom2;
			disabledBorderColor1 = @params.disabledBorderColor1;
			disabledBorderColor2 = @params.disabledBorderColor2;
			_textDisabled = @params.textDisabled;
			_textMenuStripItem = @params.textMenuStripItem;
			_textStatusStripItem = @params.textStatusStripItem;
			_textContextMenuItem = @params.textContextMenuItem;
			_textSelected = @params.textSelected;
			_arrowDisabled = @params.arrowDisabled;
			_arrowLight = @params.arrowLight;
			_arrowDark = @params.arrowDark;
			_arrowSelected = @params.arrowSelected;
			_separatorMenuLight = @params.separatorMenuLight;
			_separatorMenuDark = @params.separatorMenuDark;
			_contextMenuBack = @params.contextMenuBack;
			_contextCheckBorder = @params.contextCheckBorder;
			_contextCheckBorderSelected = @params.contextCheckBorderSelected;
			_contextCheckTick = @params.contextCheckTick;
			_contextCheckTickSelected = @params.contextCheckTickSelected;
			_statusStripBorderDark = @params.statusStripBorderDark;
			_statusStripBorderLight = @params.statusStripBorderLight;
			_gripDark = @params.gripDark;
			_gripLight = @params.gripLight;
			_itemContextItemEnabledColors = new GradientItemColors(@params.insideTop1, @params.insideTop2,
				@params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1,
				@params.fillBottom2, @params.borderColor1, @params.borderColor2);
			_itemDisabledColors = new GradientItemColors(@params.disabledInsideTop1, @params.disabledInsideTop2,
				@params.disabledInsideBottom1, @params.disabledInsideBottom2, @params.disabledFillTop1,
				@params.disabledFillTop2, @params.disabledFillBottom1, @params.disabledFillBottom2,
				@params.disabledBorderColor1, @params.disabledBorderColor2);
			_itemToolItemSelectedColors = new GradientItemColors(@params.insideTop1, @params.insideTop2,
				@params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1,
				@params.fillBottom2, @params.borderColor1, @params.borderColor2);
			_itemToolItemPressedColors = new GradientItemColors(@params.insideTop1, @params.insideTop2,
				@params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1,
				@params.fillBottom2, @params.borderColor1, @params.borderColor2);
			_itemToolItemCheckedColors = new GradientItemColors(@params.insideTop1, @params.insideTop2,
				@params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1,
				@params.fillBottom2, @params.borderColor1, @params.borderColor2);
			_itemToolItemCheckPressColors = new GradientItemColors(@params.insideTop1, @params.insideTop2,
				@params.insideBottom1, @params.insideBottom2, @params.fillTop1, @params.fillTop2, @params.fillBottom1,
				@params.fillBottom2, @params.borderColor1, @params.borderColor2);
			
		}

		public TemplateRenderer()
			: base(ColorTable)
		{
		}

		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
		{
			var flag = e.ArrowRectangle.Width > 0 && e.ArrowRectangle.Height > 0;
			var flag2 = flag;
			if (flag2)
			{
				var graphicsPath = CreateArrowPath(e.Item, e.ArrowRectangle, e.Direction);
				try
				{
					var bounds = graphicsPath.GetBounds();
					bounds.Inflate(1f, 1f);
					var color = e.Item.Enabled ? _arrowLight : _arrowDisabled;
					var color2 = e.Item.Enabled ? _arrowDark : _arrowDisabled;
					flag = e.Item.Selected;
					flag2 = flag;
					if (flag2)
					{
						color = _arrowSelected;
						color2 = _arrowSelected;
					}
					var angle = 0f;
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
					var linearGradientBrush = new LinearGradientBrush(bounds, color, color2, angle);
					try
					{
						e.Graphics.FillPath(linearGradientBrush, graphicsPath);
					}
					finally
					{
						flag = true;
						flag2 = true;
					    ((IDisposable) linearGradientBrush).Dispose();
					}
				}
				finally
				{
					flag = (graphicsPath != null);
					flag2 = flag;
					if (flag2)
					{
						graphicsPath.Dispose();
					}
				}
			}
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			e.TextColor = forecolor;
			base.OnRenderItemText(e);
		}

		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			var toolStripButton = (ToolStripButton) e.Item;
			var flag = !toolStripButton.Selected && !toolStripButton.Pressed;
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
			var flag4 = flag3;
			flag2 = flag4;
			if (flag2)
			{
				RenderToolButtonBackground(e.Graphics, toolStripButton, e.ToolStrip);
			}
		}

		protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
		{
			var flag = e.Item.Selected || e.Item.Pressed;
			var flag2 = flag;
			if (flag2)
			{
				RenderToolDropButtonBackground(e.Graphics, e.Item, e.ToolStrip);
			}
		}

		protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
		{
			var imageRectangle = e.ImageRectangle;
			imageRectangle.Inflate(1, 1);
			var flag = imageRectangle.Top > _checkInset;
			var flag2 = flag;
			checked
			{
				if (flag2)
				{
					var num = imageRectangle.Top - _checkInset;
					imageRectangle.Y -= num;
					imageRectangle.Height += num;
				}
				flag = (imageRectangle.Height <= e.Item.Bounds.Height - _checkInset * 2);
				flag2 = flag;
				if (flag2)
				{
					var num2 = e.Item.Bounds.Height - _checkInset * 2 - imageRectangle.Height;
					imageRectangle.Height += num2;
				}
				var useAntiAlias = new UseAntiAlias(e.Graphics);
				try
				{
					var graphicsPath = CreateBorderPath(imageRectangle, _cutMenuItemBack);
					try
					{
						var solidBrush = new SolidBrush(ColorTable.CheckBackground);
						try
						{
							e.Graphics.FillPath(solidBrush, graphicsPath);
						}
						finally
						{
							flag = true;
							flag2 = true;
						    ((IDisposable) solidBrush).Dispose();
						}
						var pen = new Pen(e.Item.Selected ? _contextCheckBorderSelected : _contextCheckBorder);
						try
						{
							e.Graphics.DrawPath(pen, graphicsPath);
						}
						finally
						{
							flag = true;
							flag2 = true;
						    pen.Dispose();
						}
						flag = (e.Image != null);
						flag2 = flag;
						if (flag2)
						{
							var checkState = CheckState.Unchecked;
							flag = (e.Item is ToolStripMenuItem);
							flag2 = flag;
							if (flag2)
							{
								var toolStripMenuItem = (ToolStripMenuItem) e.Item;
								checkState = toolStripMenuItem.CheckState;
							}
							switch (checkState)
							{
								case CheckState.Checked:
									flag2 = true;
							    {
							        var graphicsPath2 = CreateTickPath(imageRectangle);
							        try
							        {
							            var pen2 =
							                new Pen(
							                    e.Item.Selected ? _contextCheckTickSelected : _contextCheckTick,
							                    _contextCheckTickThickness);
							            try
							            {
							                e.Graphics.DrawPath(pen2, graphicsPath2);
							            }
							            finally
							            {
							                flag = true;
							                flag2 = true;
							                pen2.Dispose();
							            }
							        }
							        finally
							        {
							            flag = graphicsPath2 != null;
							            flag2 = flag;
							            if (flag2)
							            {
							                graphicsPath2.Dispose();
							            }
							        }
							    }
							        break;

								case CheckState.Indeterminate:
									flag2 = true;
									if (flag2)
									{
										var graphicsPath3 = CreateIndeterminatePath(imageRectangle);
										try
										{
											var solidBrush2 =
												new SolidBrush(
													e.Item.Selected ? _contextCheckTickSelected : _contextCheckTick);
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
													((IDisposable) solidBrush2).Dispose();
												}
											}
										}
										finally
										{
											flag = (graphicsPath3 != null);
											flag2 = flag;
											if (flag2)
											{
												graphicsPath3.Dispose();
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
							graphicsPath.Dispose();
						}
					}
				}
				finally
				{
					flag = (useAntiAlias != null);
					flag2 = flag;
					if (flag2)
					{
						((IDisposable) useAntiAlias).Dispose();
					}
				}
			}
		}

		protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
		{
			var flag = e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu;
			var flag2 = flag;
			if (flag2)
			{
				var flag3 = e.Image != null;
				flag2 = flag3;
				if (flag2)
				{
					var enabled = e.Item.Enabled;
					flag2 = enabled;
					if (flag2)
					{
						e.Graphics.DrawImage(e.Image, e.ImageRectangle);
					}
					else
					{
						ControlPaint.DrawImageDisabled(e.Graphics, e.Image, e.ImageRectangle.X, e.ImageRectangle.Y,
							Color.Transparent);
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
			var flag = !(e.ToolStrip is MenuStrip) && !(e.ToolStrip is ContextMenuStrip);
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
			var flag4 = flag3;
			flag2 = flag4;
			if (flag2)
			{
				var flag5 = e.Item.Pressed && e.ToolStrip is MenuStrip;
				flag2 = flag5;
				if (flag2)
				{
					DrawContextMenuHeader(e.Graphics, e.Item);
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
							var flag6 = e.ToolStrip is MenuStrip;
							flag2 = flag6;
							if (flag2)
							{
								DrawGradientToolItem(e.Graphics, e.Item, _itemToolItemSelectedColors);
							}
							else
							{
								DrawGradientContextMenuItem(e.Graphics, e.Item, _itemContextItemEnabledColors);
							}
						}
						else
						{
							var pt = e.ToolStrip.PointToClient(Control.MousePosition);
							var flag7 = !e.Item.Bounds.Contains(pt);
							flag2 = flag7;
							if (flag2)
							{
								flag5 = (e.ToolStrip is MenuStrip);
								flag2 = flag5;
								if (flag2)
								{
									DrawGradientToolItem(e.Graphics, e.Item, _itemDisabledColors);
								}
								else
								{
									DrawGradientContextMenuItem(e.Graphics, e.Item, _itemDisabledColors);
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
			var flag = e.Item.Selected || e.Item.Pressed;
			var flag2 = flag;
			if (flag2)
			{
				var toolStripSplitButton = (ToolStripSplitButton) e.Item;
				RenderToolSplitButtonBackground(e.Graphics, toolStripSplitButton, e.ToolStrip);
				var dropDownButtonBounds = toolStripSplitButton.DropDownButtonBounds;
				OnRenderArrow(new ToolStripArrowRenderEventArgs(e.Graphics, toolStripSplitButton, dropDownButtonBounds,
					SystemColors.ControlText, ArrowDirection.Down));
			}
			else
			{
				base.OnRenderSplitButtonBackground(e);
			}
		}

		protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
		{
			var solidBrush = new SolidBrush(_gripDark);
			checked
			{
				try
				{
					var solidBrush2 = new SolidBrush(_gripLight);
					try
					{
						var flag = e.ToolStrip.RightToLeft == RightToLeft.Yes;
						var num = e.AffectedBounds.Bottom - _gripSize * 2 + 1;
						var num2 = _gripLines;
						while (true)
						{
							var num3 = num2;
							var num4 = 1;
							var flag2 = num3 < num4;
							if (flag2)
							{
								break;
							}
							var num5 = flag ? (e.AffectedBounds.Left + 1) : (e.AffectedBounds.Right - _gripSize * 2 + 1);
							var num6 = 0;
							var num7 = num2 - 1;
							var num8 = num6;
							while (true)
							{
								var num9 = num8;
								num4 = num7;
								flag2 = (num9 > num4);
								if (flag2)
								{
									break;
								}
								DrawGripGlyph(e.Graphics, num5, num, solidBrush, solidBrush2);
								num5 -= (flag ? (0 - _gripMove) : _gripMove);
								num8++;
							}
							num -= _gripMove;
							num2 += -1;
						}
					}
					finally
					{
						var flag3 = solidBrush2 != null;
						var flag2 = flag3;
						if (flag2)
						{
							((IDisposable) solidBrush2).Dispose();
						}
					}
				}
				finally
				{
					var flag4 = solidBrush != null;
					var flag2 = flag4;
					if (flag2)
					{
						((IDisposable) solidBrush).Dispose();
					}
				}
			}
		}

		protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
		{
			base.OnRenderToolStripContentPanelBackground(e);
			var flag = e.ToolStripContentPanel.Width > 0 && e.ToolStripContentPanel.Height > 0;
			var flag2 = flag;
			if (flag2)
			{
				var linearGradientBrush = new LinearGradientBrush(e.ToolStripContentPanel.ClientRectangle,
					ColorTable.ToolStripContentPanelGradientEnd, ColorTable.ToolStripContentPanelGradientBegin, 90f);
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
						((IDisposable) linearGradientBrush).Dispose();
					}
				}
			}
		}

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			//e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(45, 45, 48)), e.AffectedBounds);
			//return;

			var flag = e.ToolStrip is StatusStrip;
			if (!flag)
			{
				var flag2 = e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu;
				flag = flag2;
				if (flag)
				{
					var graphicsPath = CreateBorderPath(e.AffectedBounds, _cutContextMenu);
					try
					{
						var graphicsPath2 = CreateClipBorderPath(e.AffectedBounds, _cutContextMenu);
						try
						{
							var useClipping = new UseClipping(e.Graphics, graphicsPath2);
							try
							{
								var solidBrush = new SolidBrush(_contextMenuBack);
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
										((IDisposable) solidBrush).Dispose();
									}
								}
							}
							finally
							{
								flag2 = (useClipping != null);
								flag = flag2;
								if (flag)
								{
									((IDisposable) useClipping).Dispose();
								}
							}
						}
						finally
						{
							flag2 = (graphicsPath2 != null);
							flag = flag2;
							if (flag)
							{
								graphicsPath2.Dispose();
							}
						}
					}
					finally
					{
						flag2 = (graphicsPath != null);
						flag = flag2;
						if (flag)
						{
							graphicsPath.Dispose();
						}
					}
				}
				else
				{
				    flag2 = (e.ToolStrip is StatusStrip);
				    flag = flag2;
				    base.OnRenderToolStripBackground(e);
				}
			}
		}

		protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
		{
			var flag = e.ToolStrip is ContextMenuStrip || e.ToolStrip is ToolStripDropDownMenu;
			var flag2 = flag;
			checked
			{
				if (flag2)
				{
					var affectedBounds = e.AffectedBounds;
					var flag3 = e.ToolStrip.RightToLeft == RightToLeft.Yes;
					affectedBounds.Y += _marginInset;
					affectedBounds.Height -= _marginInset * 2;
					flag = !flag3;
					flag2 = flag;
					if (flag2)
					{
						affectedBounds.X += _marginInset;
					}
					else
					{
						affectedBounds.X =
							(int)
								Math.Round(Math.Round(unchecked(affectedBounds.X + _marginInset / 2.0)));
					}
					var solidBrush = new SolidBrush(ColorTable.ImageMarginGradientBegin);
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
							((IDisposable) solidBrush).Dispose();
						}
					}
					var pen = new Pen(_separatorMenuLight);
					try
					{
						var pen2 = new Pen(_separatorMenuDark);
						try
						{
							flag = !flag3;
							flag2 = flag;
							if (flag2)
							{
								e.Graphics.DrawLine(pen, affectedBounds.Right, affectedBounds.Top, affectedBounds.Right,
									affectedBounds.Bottom);
								e.Graphics.DrawLine(pen2, affectedBounds.Right - 1, affectedBounds.Top,
									affectedBounds.Right - 1, affectedBounds.Bottom);
							}
							else
							{
								e.Graphics.DrawLine(pen, affectedBounds.Left - 1, affectedBounds.Top,
									affectedBounds.Left - 1, affectedBounds.Bottom);
								e.Graphics.DrawLine(pen2, affectedBounds.Left, affectedBounds.Top, affectedBounds.Left,
									affectedBounds.Bottom);
							}
						}
						finally
						{
							flag = (pen2 != null);
							flag2 = flag;
							if (flag2)
							{
								pen2.Dispose();
							}
						}
					}
					finally
					{
						flag = (pen != null);
						flag2 = flag;
						if (flag2)
						{
							pen.Dispose();
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
		    
		}

		private void RenderToolButtonBackground(Graphics g, ToolStripButton button, ToolStrip toolstrip)
		{
			var enabled = button.Enabled;
			var flag = enabled;
			if (flag)
			{
				var @checked = button.Checked;
				flag = @checked;
				if (flag)
				{
					var flag2 = button.Pressed;
					flag = flag2;
					if (flag)
					{
						DrawGradientToolItem(g, button, _itemToolItemPressedColors);
					}
					else
					{
						flag2 = button.Selected;
						flag = flag2;
					    DrawGradientToolItem(g, button, flag ? _itemToolItemCheckPressColors : _itemToolItemCheckedColors);
					}
				}
				else
				{
					var flag3 = button.Pressed;
					flag = flag3;
					if (flag)
					{
						DrawGradientToolItem(g, button, _itemToolItemPressedColors);
					}
					else
					{
						flag3 = button.Selected;
						flag = flag3;
						if (flag)
						{
							DrawGradientToolItem(g, button, _itemToolItemSelectedColors);
						}
					}
				}
			}
			else
			{
				var flag4 = button.Selected;
				flag = flag4;
				if (flag)
				{
					var pt = toolstrip.PointToClient(Control.MousePosition);
					flag4 = !button.Bounds.Contains(pt);
					flag = flag4;
					if (flag)
					{
						DrawGradientToolItem(g, button, _itemDisabledColors);
					}
				}
			}
		}

		private void RenderToolDropButtonBackground(Graphics g, ToolStripItem item, ToolStrip toolstrip)
		{
			var flag = item.Selected || item.Pressed;
			var flag2 = flag;
			if (flag2)
			{
				var enabled = item.Enabled;
				flag2 = enabled;
				if (flag2)
				{
					var pressed = item.Pressed;
					flag2 = pressed;
					if (flag2)
					{
						DrawContextMenuHeader(g, item);
					}
					else
					{
						DrawGradientToolItem(g, item, _itemToolItemSelectedColors);
					}
				}
				else
				{
					var pt = toolstrip.PointToClient(Control.MousePosition);
					var flag3 = !item.Bounds.Contains(pt);
					flag2 = flag3;
					if (flag2)
					{
						DrawGradientToolItem(g, item, _itemDisabledColors);
					}
				}
			}
		}

		private void RenderToolSplitButtonBackground(Graphics g, ToolStripSplitButton splitButton, ToolStrip toolstrip)
		{
			var flag = splitButton.Selected || splitButton.Pressed;
			var flag2 = flag;
			if (flag2)
			{
				var enabled = splitButton.Enabled;
				flag2 = enabled;
				if (flag2)
				{
					var flag3 = !splitButton.Pressed && splitButton.ButtonPressed;
					flag2 = flag3;
					if (flag2)
					{
						DrawGradientToolSplitItem(g, splitButton, _itemToolItemPressedColors,
							_itemToolItemSelectedColors, _itemContextItemEnabledColors);
					}
					else
					{
						flag3 = (splitButton.Pressed && !splitButton.ButtonPressed);
						flag2 = flag3;
						if (flag2)
						{
							DrawContextMenuHeader(g, splitButton);
						}
						else
						{
							DrawGradientToolSplitItem(g, splitButton, _itemToolItemSelectedColors,
								_itemToolItemSelectedColors, _itemContextItemEnabledColors);
						}
					}
				}
				else
				{
					var pt = toolstrip.PointToClient(Control.MousePosition);
					var flag4 = !splitButton.Bounds.Contains(pt);
					flag2 = flag4;
					if (flag2)
					{
						DrawGradientToolItem(g, splitButton, _itemDisabledColors);
					}
				}
			}
		}

		public GraphicsPath DrawArc(Rectangle Rectangle, int Radius = 4)
		{
			var graphicsPath = new GraphicsPath();
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

		private void DrawGradientToolItem(Graphics g, ToolStripItem item, GradientItemColors colors)
		{
			var backRect = new Rectangle(Point.Empty, item.Bounds.Size);
			DrawGradientItem(g, backRect, colors);
		}

		private void DrawGradientToolSplitItem(Graphics g, ToolStripSplitButton splitButton,
			GradientItemColors colorsButton, GradientItemColors colorsDrop, GradientItemColors colorsSplit)
		{
			var empty = Point.Empty;
			var bounds = splitButton.Bounds;
			var rectangle = new Rectangle(empty, bounds.Size);
			var dropDownButtonBounds = splitButton.DropDownButtonBounds;
			var flag = rectangle.Width > 0 && dropDownButtonBounds.Width > 0 && rectangle.Height > 0 &&
					   dropDownButtonBounds.Height > 0;
			var flag2 = flag;
			checked
			{
				if (flag2)
				{
					var backRect = rectangle;
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
					var graphicsPath = CreateBorderPath(rectangle, _cutMenuItemBack);
					try
					{
						DrawGradientBack(g, backRect, colorsButton);
						DrawGradientBack(g, dropDownButtonBounds, colorsDrop);
						bounds = new Rectangle(rectangle.X + num, rectangle.Top, 1, rectangle.Height + 1);
						var linearGradientBrush = new LinearGradientBrush(bounds, colorsSplit.cBorder1,
							colorsSplit.cBorder2, 90f);
						try
						{
							linearGradientBrush.SetSigmaBellShape(0.5f);
							var pen = new Pen(linearGradientBrush);
							try
							{
								g.DrawLine(pen, rectangle.X + num, rectangle.Top + 1, rectangle.X + num,
									rectangle.Bottom - 1);
							}
							finally
							{
								flag = (pen != null);
								flag2 = flag;
								if (flag2)
								{
									pen.Dispose();
								}
							}
						}
						finally
						{
							flag = (linearGradientBrush != null);
							flag2 = flag;
							if (flag2)
							{
								((IDisposable) linearGradientBrush).Dispose();
							}
						}
						DrawGradientBorder(g, rectangle, colorsButton);
					}
					finally
					{
						flag = (graphicsPath != null);
						flag2 = flag;
						if (flag2)
						{
							graphicsPath.Dispose();
						}
					}
				}
			}
		}

		private void DrawContextMenuHeader(Graphics g, ToolStripItem item)
		{
			var rect = new Rectangle(Point.Empty, item.Bounds.Size);
			var graphicsPath = CreateBorderPath(rect, _cutToolItemMenu);
			try
			{
				var graphicsPath2 = CreateInsideBorderPath(rect, _cutToolItemMenu);
				try
				{
					var graphicsPath3 = CreateClipBorderPath(rect, _cutToolItemMenu);
					try
					{
						var useClipping = new UseClipping(g, graphicsPath3);
						try
						{
							var solidBrush = new SolidBrush(_separatorMenuLight);
							try
							{
								g.FillPath(solidBrush, graphicsPath);
							}
							finally
							{
								var flag = solidBrush != null;
								var flag2 = flag;
								if (flag2)
								{
									((IDisposable) solidBrush).Dispose();
								}
							}
							var pen = new Pen(ColorTable.MenuBorder);
							try
							{
								g.DrawPath(pen, graphicsPath);
							}
							finally
							{
								var flag3 = pen != null;
								var flag2 = flag3;
								if (flag2)
								{
									pen.Dispose();
								}
							}
						}
						finally
						{
							var flag4 = useClipping != null;
							var flag2 = flag4;
							if (flag2)
							{
								((IDisposable) useClipping).Dispose();
							}
						}
					}
					finally
					{
						var flag5 = graphicsPath3 != null;
						var flag2 = flag5;
						if (flag2)
						{
							graphicsPath3.Dispose();
						}
					}
				}
				finally
				{
					var flag6 = graphicsPath2 != null;
					var flag2 = flag6;
					if (flag2)
					{
						graphicsPath2.Dispose();
					}
				}
			}
			finally
			{
				var flag7 = graphicsPath != null;
				var flag2 = flag7;
				if (flag2)
				{
					graphicsPath.Dispose();
				}
			}
		}

		private void DrawGradientContextMenuItem(Graphics g, ToolStripItem item, GradientItemColors colors)
		{
			var backRect = new Rectangle(2, 0, checked(item.Bounds.Width - 3), item.Bounds.Height);
			DrawGradientItem(g, backRect, colors);
		}

		private void DrawGradientItem(Graphics g, Rectangle backRect, GradientItemColors colors)
		{
			var flag = backRect.Width > 0 && backRect.Height > 0;
			var flag2 = flag;
			if (flag2)
			{
				DrawGradientBack(g, backRect, colors);
				DrawGradientBorder(g, backRect, colors);
			}
		}

		private void DrawGradientBack(Graphics g, Rectangle backRect, GradientItemColors colors)
		{
			backRect.Inflate(-1, -1);
			checked
			{
				var num = (int) Math.Round(Math.Round(backRect.Height / 2.0));
				var rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
				var rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
				var rect = rectangle;
				var rect2 = rectangle2;
				rect.Inflate(1, 1);
				rect2.Inflate(1, 1);
				var linearGradientBrush = new LinearGradientBrush(rect, colors.cInsideTop1, colors.cInsideTop2, 90f);
				try
				{
					var linearGradientBrush2 = new LinearGradientBrush(rect2, colors.cInsideBottom1,
						colors.cInsideBottom2, 90f);
					try
					{
						g.FillRectangle(linearGradientBrush, rectangle);
						g.FillRectangle(linearGradientBrush2, rectangle2);
					}
					finally
					{
						var flag = linearGradientBrush2 != null;
						var flag2 = flag;
						if (flag2)
						{
							((IDisposable) linearGradientBrush2).Dispose();
						}
					}
				}
				finally
				{
					var flag3 = linearGradientBrush != null;
					var flag2 = flag3;
					if (flag2)
					{
						((IDisposable) linearGradientBrush).Dispose();
					}
				}
				num = (int) Math.Round(Math.Round(backRect.Height / 2.0));
				rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
				rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
				rect = rectangle;
				rect2 = rectangle2;
				rect.Inflate(1, 1);
				rect2.Inflate(1, 1);
				var linearGradientBrush3 = new LinearGradientBrush(rect, colors.cFillTop1, colors.cFillTop2, 90f);
				try
				{
					var linearGradientBrush4 = new LinearGradientBrush(rect2, colors.cFillBottom1, colors.cFillBottom2,
						90f);
					try
					{
						backRect.Inflate(-1, -1);
						num = (int) Math.Round(Math.Round(backRect.Height / 2.0));
						rectangle = new Rectangle(backRect.X, backRect.Y, backRect.Width, num);
						rectangle2 = new Rectangle(backRect.X, backRect.Y + num, backRect.Width, backRect.Height - num);
						g.FillRectangle(linearGradientBrush3, rectangle);
						g.FillRectangle(linearGradientBrush4, rectangle2);
					}
					finally
					{
						var flag4 = linearGradientBrush4 != null;
						var flag2 = flag4;
						if (flag2)
						{
							((IDisposable) linearGradientBrush4).Dispose();
						}
					}
				}
				finally
				{
					var flag5 = linearGradientBrush3 != null;
					var flag2 = flag5;
					if (flag2)
					{
						((IDisposable) linearGradientBrush3).Dispose();
					}
				}
			}
		}

		private void DrawGradientBorder(Graphics g, Rectangle backRect, GradientItemColors colors)
		{
			var useAntiAlias = new UseAntiAlias(g);
			try
			{
				var rect = backRect;
				rect.Inflate(1, 1);
				var linearGradientBrush = new LinearGradientBrush(rect, colors.cBorder1, colors.cBorder2, 90f);
				try
				{
					linearGradientBrush.SetSigmaBellShape(0.5f);
					var pen = new Pen(linearGradientBrush);
					try
					{
						var graphicsPath = CreateBorderPath(backRect, _cutMenuItemBack);
						try
						{
							g.DrawPath(pen, graphicsPath);
						}
						finally
						{
							var flag = graphicsPath != null;
							var flag2 = flag;
							if (flag2)
							{
								graphicsPath.Dispose();
							}
						}
					}
					finally
					{
						var flag3 = pen != null;
						var flag2 = flag3;
						if (flag2)
						{
							pen.Dispose();
						}
					}
				}
				finally
				{
					var flag4 = linearGradientBrush != null;
					var flag2 = flag4;
					if (flag2)
					{
						((IDisposable) linearGradientBrush).Dispose();
					}
				}
			}
			finally
			{
				var flag5 = useAntiAlias != null;
				var flag2 = flag5;
				if (flag2)
				{
					((IDisposable) useAntiAlias).Dispose();
				}
			}
		}

		private void DrawGripGlyph(Graphics g, int x, int y, Brush darkBrush, Brush lightBrush)
		{
			checked
			{
				g.FillRectangle(lightBrush, x + _gripOffset, y + _gripOffset, _gripSquare, _gripSquare);
				g.FillRectangle(darkBrush, x, y, _gripSquare, _gripSquare);
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
			graphicsPath.AddLine(rect.Left + cut, rect.Top, rect.Right - cut, rect.Top);
			graphicsPath.AddLine(rect.Right - cut, rect.Top, rect.Right, rect.Top + cut);
			graphicsPath.AddLine(rect.Right, rect.Top + cut, rect.Right,
				rect.Bottom - cut);
			graphicsPath.AddLine(rect.Right, rect.Bottom - cut, rect.Right - cut,
				rect.Bottom);
			graphicsPath.AddLine(rect.Right - cut, rect.Bottom, rect.Left + cut,
				rect.Bottom);
			graphicsPath.AddLine(rect.Left + cut, rect.Bottom, rect.Left,
				rect.Bottom - cut);
			graphicsPath.AddLine(rect.Left, rect.Bottom - cut, rect.Left, rect.Top + cut);
			graphicsPath.AddLine(rect.Left, rect.Top + cut, rect.Left + cut, rect.Top);
			return graphicsPath;
		}

		private GraphicsPath CreateInsideBorderPath(Rectangle rect, float cut)
		{
			rect.Inflate(-1, -1);
			return CreateBorderPath(rect, cut);
		}

	    private GraphicsPath CreateClipBorderPath(Rectangle rect, float cut)
		{
			checked
			{
				rect.Width++;
				rect.Height++;
				return CreateBorderPath(rect, cut);
			}
		}

	    private GraphicsPath CreateArrowPath(ToolStripItem item, Rectangle rect, ArrowDirection direction)
		{
			var flag = direction == ArrowDirection.Left || direction == ArrowDirection.Right;
			var flag2 = flag;
			checked
			{
				int num;
				int num2;
				if (flag2)
				{
					num =
						(int)
							Math.Round(
								Math.Round(unchecked(rect.Right - checked(rect.Width - 4) / 2.0)));
					num2 = (int) Math.Round(Math.Round(unchecked(rect.Y + rect.Height / 2.0)));
				}
				else
				{
					num = (int) Math.Round(Math.Round(unchecked(rect.X + rect.Width / 2.0)));
					num2 =
						(int)
							Math.Round(
								Math.Round(unchecked(rect.Bottom - checked(rect.Height - 3) / 2.0)));
					flag = (item is ToolStripDropDownButton && item.RightToLeft == RightToLeft.Yes);
					flag2 = flag;
					if (flag2)
					{
						num++;
					}
				}
				var graphicsPath = new GraphicsPath();
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
							graphicsPath.AddLine(num + 3f, num2, num - 3f, num2);
							graphicsPath.AddLine(num - 3f, num2, num, num2 - 4f);
							graphicsPath.AddLine(num, num2 - 4f, num + 3f, num2);
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
							graphicsPath.AddLine(num + 3f, num2 - 3f, num - 2f,
								num2 - 3f);
							graphicsPath.AddLine(num - 2f, num2 - 3f, num, num2);
							graphicsPath.AddLine(num, num2, num + 3f, num2 - 3f);
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
				var num = (int) Math.Round(Math.Round(unchecked(rect.X + rect.Width / 2.0)));
				var num2 = (int) Math.Round(Math.Round(unchecked(rect.Y + rect.Height / 2.0)));
				var graphicsPath = new GraphicsPath();
				graphicsPath.AddLine(num - 4, num2, num - 2, num2 + 4);
				graphicsPath.AddLine(num - 2, num2 + 4, num + 3, num2 - 5);
				return graphicsPath;
			}
		}

		private GraphicsPath CreateIndeterminatePath(Rectangle rect)
		{
			checked
			{
				var num = (int) Math.Round(Math.Round(unchecked(rect.X + rect.Width / 2.0)));
				var num2 = (int) Math.Round(Math.Round(unchecked(rect.Y + rect.Height / 2.0)));
				var graphicsPath = new GraphicsPath();
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
			_g = g;
			_old = _g.SmoothingMode;
			_g.SmoothingMode = SmoothingMode.AntiAlias;
		}

		public void Dispose()
		{
			_g.SmoothingMode = _old;
		}
	}

	internal class UseClearTypeGridFit : IDisposable
	{
		private Graphics _g;
		private TextRenderingHint _old;

		public UseClearTypeGridFit(Graphics g)
		{
			_g = g;
			_old = _g.TextRenderingHint;
			_g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		}

		public void Dispose()
		{
			_g.TextRenderingHint = _old;
		}
	}

	internal class UseClipping : IDisposable
	{
		private Graphics _g;
		private Region _old;

		public UseClipping(Graphics g, GraphicsPath path)
		{
			_g = g;
			_old = g.Clip;
			var region = _old.Clone();
			region.Intersect(path);
			_g.Clip = region;
		}

		public UseClipping(Graphics g, Region region)
		{
			_g = g;
			_old = g.Clip;
			var region2 = _old.Clone();
			region2.Intersect(region);
			_g.Clip = region2;
		}

		public void Dispose()
		{
			_g.Clip = _old;
		}
	}
}