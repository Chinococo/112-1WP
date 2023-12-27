using PowerPoint.Object;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.PresentationModel
{
    public class PresentationModel
    {
        private Model _model;
        private Bitmap _bitmap;
        private const string IMAGE = "image.png";
        private IState _state; // 表示當前狀態的接口
        private BindingList<Shape> _shapeList;

        public PresentationModel(Model model, BindingList<Shape> shapeList)
        {
            this._model = model;
            this._shapeList = shapeList;
        }

        // Draw事件
        public void Draw(System.Drawing.Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
            Bitmap myBitmap = new Bitmap((int)graphics.VisibleClipBounds.Width, (int)graphics.VisibleClipBounds.Height);
            myBitmap.Save(IMAGE, System.Drawing.Imaging.ImageFormat.Png);
            _bitmap = myBitmap;
        }

        // 拿bitmap
        public Bitmap GetBitmap()
        {
            return _bitmap;
        }

        // 滑鼠移動事件處理（由 IState 接口實現）
        public void MovedPointer(double pressX, double pressY)
        {
            if (_state != null)
                _state.MouseMove(pressX, pressY);
        }

        // 滑鼠左鍵釋放事件處理（由 IState 接口實現）
        public void ReleasedPointer(double pressX, double pressY)
        {
            if (_state != null)
                _state.ReleasedPointer(pressX, pressY);
        }

        // 滑鼠按下事件處理（由 IState 接口實現）
        public void PressedPointer(double pressX, double pressY)
        {
            if (_state != null)
                _state.MouseDown(pressX, pressY);
        }

        // 切換繪製狀態
        public void ChangeState(bool drawingState)
        {
            if (drawingState)
                _state = new DrawingState(_model);
            else
                _state = new PointState(_model);
        }

        // 切換繪製狀態
        public void Undo()
        {
            int _executeIndex = _model.GetExecuteIndex();
            List<ICommand> _command = _model.GetCommand();
            if (_executeIndex < 0)
                return;
            else
            {
                _command[_executeIndex].UndoExecute();
                _executeIndex -= 1;
                _model.UpdateExecuteIndex(_executeIndex);
                _model.NotifyModelChanged();
            }
        }

        // 切換繪製狀態
        public void Redo()
        {
            int _executeIndex = _model.GetExecuteIndex();
            List<ICommand> _command = _model.GetCommand();
            if (_executeIndex >= _command.Count - 1)
                return;
            else
            {
                _command[_executeIndex + 1].Execute();
                _executeIndex += 1;
                _model.UpdateExecuteIndex(_executeIndex);
                _model.NotifyModelChanged();
            }
        }
    }
}