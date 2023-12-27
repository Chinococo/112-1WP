// 引用必要的命名空間
using PowerPoint;
using PowerPoint.Command;
using PowerPoint.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

// Model 類，負責應用邏輯和數據管理
public class Model
{
    // 事件，當模型發生變化時通知其他部分
    public event ModelChangedEventHandler _modelChanged;

    // 委託定義用於事件處理
    public delegate void ModelChangedEventHandler();

    // 私有字段，存儲界面上的控件
    private Factory _factory = new Factory();

    private List<ICommand> _command = new List<ICommand>();
    private int _executeIndex = -1;
    private double _lastClickX;
    private double _lastClickY;
    private BindingList<Shape> _shapeList;
    private const string NAME_LINE = "Line";
    private const string NAME_RECTANGLE = "Rectangle";
    private const string NAME_ELLIPSE = "Ellipse";
    private const string DELETE = "刪除"; // 刪除按鈕的文字
    private const string LINE = "線";
    private const string RECTANGLE = "矩形";
    private const string ELLIPSE = "橢圓";
    private string _shapeState = "";
    private string _shapeToolButtonState = "";
    private double _firstPointX;
    private double _firstPointY;
    private Shape _previous;
    private bool _isPressed = false;
    private bool _isSelect = false;
    private int _selectIndex = -1;
    private Shape _hint; // 用於顯示提示形狀的變數
    private IState _state; // 表示當前狀態的接口
    private bool _zoom = false;

    // 構造函數，初始化模型
    public Model(BindingList<Shape> shapeList)
    {
        this._shapeList = shapeList;
    }

    /// <summary>
    /// 更新zoom
    /// </summary>
    /// <param name="zoom"></param>
    public void SetZoom(bool zoom)
    {
        this._zoom = zoom;
    }

    // 拿zoom數值
    public bool IsZoom()
    {
        return _zoom;
    }

    // 新增 DataGrid 資料
    public void PopLine()
    {
        _shapeList.RemoveAt(_shapeList.Count - 1);
        // 通知模型發生變化
        NotifyModelChanged();
    }

    // 新增 DataGrid 資料
    public void AddNewLine(Shape shape)
    {
        _shapeList.Add(shape);
        // 通知模型發生變化
        NotifyModelChanged();
    }

    // 新增 DataGrid 資料
    public void AddNewLine(string state)
    {
        // 根據選擇的形狀類型添加新形狀到列表
        if (state == LINE)
        {
            _shapeList.Add(_factory.CreateShape(NAME_LINE));
        }
        else if (state == RECTANGLE)
        {
            _shapeList.Add(_factory.CreateShape(NAME_RECTANGLE));
        }
        else if (state == ELLIPSE)
        {
            _shapeList.Add(_factory.CreateShape(NAME_ELLIPSE));
        }
        _shapeState = state;
        UpdateExecuteId();
        _command.Add(new AddCommand(this, _shapeList[_shapeList.Count - 1].Clone()));
        _executeIndex += 1;
        // 通知模型發生變化
        NotifyModelChanged();
    }

    //去除部必要指令
    public void UpdateExecuteId()
    {
        while (_command.Count - 1 != _executeIndex)
        {
            _command.RemoveAt(_command.Count - 1);
        }
    }

    // 刪除特定列的物件
    public void DeleteLineByIndex(int index)
    {
        if (_shapeList.Count > index)
        {
            UpdateExecuteId();
            _command.Add(new DeleteCommand(this, _shapeList[index].Clone(), index));
            _executeIndex += 1;
            _shapeList.RemoveAt(index);
        }

        // 通知模型發生變化
        NotifyModelChanged();
    }

    // 滑鼠左鍵按下事件處理
    public void PressPointerDrawing(double pressX, double pressY)
    {
        if (_hint != null)
        {
            if (pressX > 0 && pressY > 0 && _hint != null)
            {
                _firstPointX = pressX;
                _firstPointY = pressY;
                _hint.SetPoint1(_firstPointX, _firstPointY);
                _isPressed = true;
            }
        }
    }

    // 滑鼠左鍵按下事件處理（用於選擇點）
    public void PressPoint(double pressX, double pressY)
    {
        if (_zoom)
        {
            _firstPointX = pressX;
            _firstPointY = pressY;
            _isPressed = true;
        }
        else
        {
            _lastClickX = pressX;
            _lastClickY = pressY;
            _selectIndex = -1;
            _isSelect = false;
            for (int i = _shapeList.Count - 1; i >= 0; i--)
            {
                Shape shape = _shapeList[i];
                if (IsPointWithinBoundingBox(pressX, pressY, shape))
                {
                    _selectIndex = i;
                    _isSelect = true;
                    _previous = _shapeList[_selectIndex].Clone();
                    break; // 找到第一個匹配的形狀後退出循環
                }
            }
        }

        NotifyModelChanged();
    }

    // 滑鼠按下事件處理（由 IState 接口實現）
    public void PressedPointer(double pressX, double pressY)
    {
        if (_state != null)
            _state.MouseDown(pressX, pressY);
    }

    // 滑鼠移動事件處理（用於繪製形狀）
    public void MovedPointerDrawing(double pressX, double pressY)
    {
        if (_isPressed)
        {
            if (_hint != null)
            {
                _hint.SetPoint2(pressX, pressY);
                // 通知模型發生變化
                NotifyModelChanged();
            }
        }
    }

    // 滑鼠移動事件處理（用於移動形狀）
    public void MovedPointerPoint(double pressX, double pressY)
    {
        if (_zoom && _isPressed)
        {
            Shape temp = _shapeList[_selectIndex];
            double deltaX = pressX - _firstPointX;
            double deltaY = pressY - _firstPointY;
            temp.SetPoint2(temp.GetX2() + deltaX, temp.GetY2() + deltaY);
            _firstPointX = pressX;
            _firstPointY = pressY;
        }
        else if (_isSelect && _selectIndex >= 0)
        {
            _shapeList[_selectIndex].Move(pressX - _lastClickX, pressY - _lastClickY);
            _lastClickX = pressX;
            _lastClickY = pressY;
            // 通知模型發生變化
        }
        NotifyModelChanged();
    }

    // 滑鼠移動事件處理（由 IState 接口實現）
    public void MovedPointer(double pressX, double pressY)
    {
        if (_state != null)
            _state.MouseMove(pressX, pressY);
    }

    // 滑鼠左鍵釋放事件處理（用於選擇點）
    public void ReleasedPointerPoint(double pressX, double pressY)
    {
        UpdateExecuteId();
        _command.Add(new MoveCommand(this, _previous, _shapeList[_selectIndex].Clone(), _selectIndex));
        _executeIndex += 1;
        _isSelect = false;
        _isPressed = false;
        // 通知模型發生變化
        NotifyModelChanged();
    }

    // 滑鼠左鍵釋放事件處理（用於繪製形狀）
    public void ReleasedPointerDrawing(double pressX, double pressY)
    {
        _isSelect = false;
        _isPressed = false;
        if (_hint != null)
        {
            _hint = _factory.CreateShape(_shapeToolButtonState, new Point((int)_firstPointX, (int)_firstPointY), new Point((int)pressX, (int)pressY));
        }
        UpdateExecuteId();
        _command.Add(new DrawCommand(this, _hint.Clone()));
        _executeIndex += 1;
        if (_hint != null)
            _shapeList.Add(_hint);
        NotifyModelChanged();
        _hint = null;
    }

    // 滑鼠左鍵釋放事件處理（由 IState 接口實現）
    public void ReleasedPointer(double pressX, double pressY)
    {
        if (_state != null)
            _state.ReleasedPointer(pressX, pressY);
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
    public void NotifyModelChanged()
    {
        if (_modelChanged != null)
            _modelChanged();
    }

    // 根據當前形狀類型繪製所有形狀
    public void Draw(CustomGraphics graphics)
    {
        graphics.ClearAll();
        int index = 0; // 从第一个形状开始
        foreach (Shape shape in _shapeList)
        {
            shape.Draw(graphics, index == _selectIndex);
            index++;
        }

        if (_isPressed && _hint != null)
            _hint.Draw(graphics);
    }

    // 更新工具欄按鈕選中狀態
    public void UpdateToolStripButtonCheck(string temp)
    {
        if (temp == ELLIPSE)
        {
            _hint = _factory.CreateShape(NAME_ELLIPSE);
            _shapeToolButtonState = NAME_ELLIPSE;
        }
        else if (temp == LINE)
        {
            _hint = _factory.CreateShape(NAME_LINE);
            _shapeToolButtonState = NAME_LINE;
        }
        else if (temp == RECTANGLE)
        {
            _hint = _factory.CreateShape(NAME_RECTANGLE);
            _shapeToolButtonState = NAME_RECTANGLE;
        }
    }

    // 檢查點是否在形狀的包圍框內
    private bool IsPointWithinBoundingBox(double pressX, double pressY, Shape shape)
    {
        double minX = Math.Min(shape.GetX1(), shape.GetX2());
        double minY = Math.Min(shape.GetY1(), shape.GetY2());
        double maxX = Math.Max(shape.GetX1(), shape.GetX2());
        double maxY = Math.Max(shape.GetY1(), shape.GetY2());

        return (pressX >= minX && pressX <= maxX && pressY >= minY && pressY <= maxY);
    }

    // 按鈕刪除 Click 事件處理
    public void DeleteButtonClick()
    {
        if (_selectIndex >= 0 && _selectIndex < _shapeList.Count)
        {
            UpdateExecuteId();
            _command.Add(new DeleteCommand(this, _shapeList[_selectIndex].Clone(), _selectIndex));
            _executeIndex += 1;
            _shapeList.RemoveAt(_selectIndex);
        }
        // 通知模型發生變化
        NotifyModelChanged();
    }

    // 回傳selectindex
    public int GetSelectIndex()
    {
        return _selectIndex;
    }

    // 清除狀態（解除按壓等）
    public void ClearState()
    {
        this._selectIndex = -1;
        this._isPressed = false;
        this._isSelect = false;
    }

    // 切換繪製狀態
    public void ChangeState(bool drawingState)
    {
        if (drawingState)
            _state = new DrawingState(this);
        else
            _state = new PointState(this);
    }

    // 切換繪製狀態
    public void Undo()
    {
        if (_executeIndex < 0)
            return;
        else
        {
            _command[_executeIndex].UndoExecute();
            _executeIndex -= 1;
            NotifyModelChanged();
        }
    }

    // 切換繪製狀態
    public void Redo()
    {
        if (_executeIndex >= _command.Count - 1)
            return;
        else
        {
            _command[_executeIndex + 1].Execute();
            _executeIndex += 1;
            NotifyModelChanged();
        }
    }

    //新增物件by索引
    public void InsertByIndex(int index, Shape temp)
    {
        this._shapeList.Insert(index, temp);
    }

    //新增物件by索引
    public void MoveByIndex(int index, Shape temp)
    {
        this._shapeList[index] = temp;
    }
}