// 引用必要的命名空間
using PowerPoint;
using PowerPoint.Object;
using System;
using System.ComponentModel;

// Model 類，負責應用邏輯和數據管理
public class Model
{
    // 事件，當模型發生變化時通知其他部分
    public event ModelChangedEventHandler _modelChanged;

    // 委託定義用於事件處理
    public delegate void ModelChangedEventHandler();

    // 私有字段，存儲界面上的控件
    private Factory _factory = new Factory();

    private double _lastClickX;
    private double _lastClickY;
    private BindingList<Shape> _shapeList;
    private const string ENLINE = "Line";
    private const string ENRECTANGLE = "Rectangle";
    private const string ENELLIPS = "Ellipse";
    private const string DELETE = "刪除"; // 刪除按鈕的文字
    private const string LINE = "線";
    private const string RECTANGLE = "矩形";
    private const string ELLIPS = "橢圓";
    private double _firstPointX;
    private double _firstPointY;
    private bool _isPressed = false;
    private bool _isSelect = false;
    private int _selectIndex = -1;
    private Shape _hint; // 用於顯示提示形狀的變數
    private IState _state; // 表示當前狀態的接口
    private bool _toolStripEllipseButton = false;
    private bool _toolStripLineButton = false;
    private bool _toolStripRectangleButton = false;

    // 構造函數，初始化模型
    public Model(BindingList<Shape> shapelist)
    {
        this._shapeList = shapelist;
    }

    // 新增 DataGrid 資料
    public void AddNewLine(string _shapeCombobox)
    {
        // 根據選擇的形狀類型添加新形狀到列表
        if (_shapeCombobox == LINE)
        {
            _shapeList.Add(_factory.CreateShape(ENLINE));
        }
        else if (_shapeCombobox == RECTANGLE)
        {
            _shapeList.Add(_factory.CreateShape(ENRECTANGLE));
        }
        else if (_shapeCombobox == ELLIPS)
        {
            _shapeList.Add(_factory.CreateShape(ENELLIPS));
        }
        // 通知模型發生變化
        NotifyModelChanged();
    }

    // 刪除特定列的物件
    public void DeleteLineByIndex(int index)
    {
        // 移除指定索引的形狀
        if (index < _selectIndex)
            _selectIndex -= 1;
        else if (_selectIndex == index)
            _selectIndex = -1;
        _shapeList.RemoveAt(index);

        // 通知模型發生變化
        NotifyModelChanged();
    }

    // 滑鼠左鍵按下事件處理
    public void PressPointerDrawing(double x, double y)
    {
        if (_hint != null)
        {
            if (x > 0 && y > 0 && _hint != null)
            {
                _firstPointX = x;
                _firstPointY = y;
                _hint.SetPoint1(_firstPointX, _firstPointY);
                _isPressed = true;
            }
        }
    }

    // 滑鼠左鍵按下事件處理（用於選擇點）
    public void PressPointerPoint(double x, double y)
    {
        _lastClickX = x;
        _lastClickY = y;
        _selectIndex = -1;
        _isSelect = false;
        // 反向迭代形狀列表，找到包含鼠標點的形狀
        for (int i = _shapeList.Count - 1; i >= 0; i--)
        {
            Shape shape = _shapeList[i];

            // 檢查鼠標點是否在形狀的包圍框內
            if (IsPointWithinBoundingBox(x, y, shape))
            {
                _selectIndex = i;
                _isSelect = true;
                break; // 找到第一個匹配的形狀後退出循環
            }
        }
        // 通知模型發生變化
        NotifyModelChanged();
    }

    // 滑鼠按下事件處理（由 IState 接口實現）
    public void PressedPointer(double x, double y)
    {
        if (_state != null)
            _state.MouseDown(x, y);
    }

    // 滑鼠移動事件處理（用於繪製形狀）
    public void MovedPointerDrawing(double x, double y)
    {
        if (_isPressed)
        {
            if (_hint != null)
            {
                _hint.SetPoint2(x, y);
                // 通知模型發生變化
                NotifyModelChanged();
            }
        }
    }

    // 滑鼠移動事件處理（用於移動形狀）
    public void MovedPointerPoint(double x, double y)
    {
        if (_isSelect && _selectIndex >= 0)
        {
            _shapeList[_selectIndex].Move(x - _lastClickX, y - _lastClickY);
            _lastClickX = x;
            _lastClickY = y;
            // 通知模型發生變化
            NotifyModelChanged();
        }
    }

    // 滑鼠移動事件處理（由 IState 接口實現）
    public void MovedPointer(double x, double y)
    {
        if (_state != null)
            _state.MouseMove(x, y);
    }

    // 滑鼠左鍵釋放事件處理（用於選擇點）
    public void ReleasedPointerPoint(double x, double y)
    {
        _isSelect = false;
        // 通知模型發生變化
        NotifyModelChanged();
    }

    // 滑鼠左鍵釋放事件處理（用於繪製形狀）
    public void ReleasedPointerDrawing(double x, double y)
    {
        _isSelect = false;
        if (_isPressed)
        {
            Shape hint;
            _isPressed = false;
            if (_toolStripEllipseButton)
            {
                hint = _factory.CreateShape(ENELLIPS, _firstPointX, _firstPointY, x, y);
                _hint.SetPoint1(_firstPointX, _firstPointY);
                _hint.SetPoint2(x, y);
                _shapeList.Add(hint);
            }
            else if (_toolStripLineButton)
            {
                hint = _factory.CreateShape(ENLINE, _firstPointX, _firstPointY, x, y);
                _hint.SetPoint1(_firstPointX, _firstPointY);
                _hint.SetPoint2(x, y);
                _shapeList.Add(hint);
            }
            else if (_toolStripRectangleButton)
            {
                hint = _factory.CreateShape(ENRECTANGLE, _firstPointX, _firstPointY, x, y);
                _shapeList.Add(hint);
            }
            // 通知模型發生變化
            NotifyModelChanged();
            _hint = null;
        }
    }

    // 滑鼠左鍵釋放事件處理（由 IState 接口實現）
    public void ReleasedPointer(double x, double y)
    {
        if (_state != null)
            _state.ReleasedPointer(x, y);
    }

    // 清除所有形狀並解除按壓
    public void Clear()
    {
        _isPressed = false;
        _shapeList.Clear();
        // 通知模型發生變化
        NotifyModelChanged();
    }

    // 通知畫面需要更新事件
    private void NotifyModelChanged()
    {
        if (_modelChanged != null)
            _modelChanged();
    }

    // 根據當前形狀類型繪製所有形狀
    public void Draw(IGraphics graphics)
    {
        graphics.ClearAll();
        int index = 0; // 从第一个形状开始
        foreach (Shape shape in _shapeList)
        {
            shape.Draw(graphics, index == _selectIndex);
            index++;
        }

        if (_isPressed)
            _hint.Draw(graphics);
    }

    // 更新工具欄按鈕選中狀態
    public void UpdateToolStripButtonCheck(string temp)
    {
        _toolStripEllipseButton = false;
        _toolStripLineButton = false;
        _toolStripRectangleButton = false;
        if (temp == ELLIPS)
        {
            _hint = _factory.CreateShape(ENELLIPS);
            _toolStripEllipseButton = true;
        }
        else if (temp == LINE)
        {
            _hint = _factory.CreateShape(ENLINE);
            _toolStripLineButton = true;
        }
        else if (temp == RECTANGLE)
        {
            _hint = _factory.CreateShape(ENRECTANGLE);
            _toolStripRectangleButton = true;
        }
    }

    // 檢查點是否在形狀的包圍框內
    private bool IsPointWithinBoundingBox(double x, double y, Shape shape)
    {
        double minX = Math.Min(shape.GetX1(), shape.GetX2());
        double minY = Math.Min(shape.GetY1(), shape.GetY2());
        double maxX = Math.Max(shape.GetX1(), shape.GetX2());
        double maxY = Math.Max(shape.GetY1(), shape.GetY2());

        return (x >= minX && x <= maxX && y >= minY && y <= maxY);
    }

    // 按鈕刪除 Click 事件處理
    public void DeleteBtnClick()
    {
        // 您的刪除邏輯在這裡執行
        // 例如，您可能想從 _shapeList 中刪除所選形狀

        // 假設 _selectedIndex 是您要刪除的形狀的索引
        if (_selectIndex >= 0 && _selectIndex < _shapeList.Count)
        {
            _shapeList.RemoveAt(_selectIndex);
        }
        // 通知模型發生變化
        NotifyModelChanged();
    }

    // 清除狀態（解除按壓等）
    public void ClearState()
    {
        this._selectIndex = -1;
        this._isPressed = false;
        this._isSelect = false;
    }

    // 切換繪製狀態
    public void ChangeState(bool drawingstate)
    {
        if (drawingstate)
            _state = new DrawingState(this);
        else
            _state = new PointState(this);
    }
}