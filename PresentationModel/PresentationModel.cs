using System.Collections.Generic;
using System.Windows.Forms;

namespace HW2.PresentationModel
{
    public  class PresentationModel
    {
        private Model _model;
        private bool _toolStripEllipseButtonState = false;
        private bool _toolStripLineButtonState = false;
        private bool _toolStripRectangleButtonState = false;

        public PresentationModel(Model model, Control canvas)
        {
            this._model = model;
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

        public void ClearToolStripButtonCheck()
        {
            _toolStripEllipseButtonState = false;
            _toolStripLineButtonState = false;
            _toolStripRectangleButtonState = false;
        }

        public void UpdateToolStripButtonCheck(string name)
        {
            ClearToolStripButtonCheck();
            if (name == "Line")
                _toolStripLineButtonState = true;
            else if (name == "Ellipse")
                _toolStripEllipseButtonState = true;
            else
                _toolStripRectangleButtonState = true;
        }

        public Dictionary<string, bool> GetToolStripButtonState()
        {
            Dictionary<string, bool> buttonStateDict = new Dictionary<string, bool>
            {
                { "Line", _toolStripLineButtonState },
                { "Ellipse", _toolStripEllipseButtonState },
                { "Rectangle", _toolStripRectangleButtonState }
            };

            return buttonStateDict;
        }
    }
}