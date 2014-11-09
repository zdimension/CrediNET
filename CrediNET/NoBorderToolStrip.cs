using System.Windows.Forms;

namespace CrediNET
{
    public class NoBorderToolStrip : ToolStrip
    {
        public NoBorderToolStrip()
        {
            Renderer.RenderToolStripBorder += Renderer_RenderToolStripBorder;
        }

        private void Renderer_RenderToolStripBorder(object sender, ToolStripRenderEventArgs e)
        {
        }
    }
}