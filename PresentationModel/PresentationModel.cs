using System.Windows.Forms;

namespace HW2.PresentationModel
{
    internal class PresentationModel
    {
        private Model _model;
        private ToolStripButton _toolStripEllipseButton;
        private ToolStripButton _toolStripLineButton;
        private ToolStripButton _toolStripRectangleButton;

        public PresentationModel(Model model, Control canvas, ToolStripButton buttonellipse, ToolStripButton buttonline, ToolStripButton buttonrectangle)
        {
            this._model = model;
            this._toolStripEllipseButton = buttonellipse;
            this._toolStripLineButton = buttonline;
            this._toolStripRectangleButton = buttonrectangle;
        }

        // Draw事件
        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }

        //更新按鈕狀況

        public void UpdateToolStripButtonCheck(ToolStripButton temp)
        {
            _toolStripEllipseButton.Checked = false;
            _toolStripLineButton.Checked = false;
            _toolStripRectangleButton.Checked = false;
            temp.Checked = true;
        }
    }
}