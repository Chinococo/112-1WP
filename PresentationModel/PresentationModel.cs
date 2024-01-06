using PowerPoint.Object;
using System.ComponentModel;
using System.Drawing;

namespace PowerPoint.PresentationModel
{
    public class PresentationModel
    {
        private Model _model;
        private Bitmap _bitmap;
        private Factory _factory = new Factory();
        private const string IMAGE = "image.png";
        private IState _state; // 表示當前狀態的接口
        private BindingList<Shape> _shapeList;
        private ControlManger _controlManger;
        private const string LINE = "線";
        private const string RECTANGLE = "矩形";
        private const string ELLIPSE = "橢圓";
        private const string NAME_LINE = "Line";
        private const string NAME_RECTANGLE = "Rectangle";
        private const string NAME_ELLIPSE = "Ellipse";
        private string _shapeState = "";

        public PresentationModel(Model model, BindingList<Shape> shapeList, ControlManger controlManger)
        {
            this._model = model;
            this._shapeList = shapeList;
            this._controlManger = controlManger;
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

        // 按鈕刪除 Click 事件處理
        public void DeleteButtonClick()
        {
            int selectIndex = _model.GetSelectIndex();
            if (selectIndex >= 0 && selectIndex < _shapeList.Count)
            {
                _controlManger.DeleteCommand(_model, _shapeList[selectIndex].Clone(), selectIndex);
                _shapeList.RemoveAt(selectIndex);
            }
            // 通知模型發生變化
            _model.NotifyModelChanged();
        }

        // 新增 DataGrid 資料
        public void AddNewLine(string state)
        {
            if (state == LINE)
                _shapeList.Add(_factory.CreateShape(NAME_LINE));
            else if (state == RECTANGLE)
                _shapeList.Add(_factory.CreateShape(NAME_RECTANGLE));
            else if (state == ELLIPSE)
                _shapeList.Add(_factory.CreateShape(NAME_ELLIPSE));
            _shapeState = state;
            _controlManger.AddCommand(_model, _shapeList[_shapeList.Count - 1].Clone());
            _model.NotifyModelChanged();
        }

        public void SetShapeList(BindingList<Shape> shapeList)
        {
            this._shapeList = shapeList;
        }
    }
}