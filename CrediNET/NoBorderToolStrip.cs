using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrediNET
{
    public class NoBorderToolStrip : ToolStrip
    {
        public NoBorderToolStrip()
        {
            this.Renderer.RenderToolStripBorder += Renderer_RenderToolStripBorder;
        }

        void Renderer_RenderToolStripBorder(object sender, ToolStripRenderEventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
