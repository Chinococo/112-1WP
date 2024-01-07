// 引用必要的命名空間
using Dialog;
using PowerPoint;
using System;
using System.ComponentModel;
using System.Drawing;

// Model 類，負責應用邏輯和數據管理
public class Model
{
    public delegate void ModelChangedEventHandler();
    public event ModelChangedEventHandler _modelChanged;
    private Size _deletePageSize;
    private Shape _previous;
    private Factory _factory = new Factory();
    private bool _addPage = false;
    private bool _deletePage = false;
    private bool _deletePageByIndex = false;
    private bool _insertPageByIndex = false;
    private bool _changeActivePageIndex = false;
    private int _activePageIndex = -1;
    private BindingList<Shape> _deletePageList;
    private int _deletePageIndex = -1;
    private ControlManager _controlManager;
    private int _selectIndex = -1;
    private BindingList<Shape> _shapeList;
    private string _shapeToolButtonState = "";
    private double _firstPointX;
    private double _firstPointY;
    private double _lastClickX;
    private double _lastClickY;
    private bool _isPressed = false;
    private bool _isSelect = false;
    private Shape _hint;
    private bool _zoom = false;
    private const string LINE = "線";
    private const string RECTANGLE = "矩形";
    private const string ELLIPSE = "橢圓";
    private const string NAME_LINE = "Line";
    private const string NAME_RECTANGLE = "Rectangle";
    private const string NAME_ELLIPSE = "Ellipse";

    //新增頁面
    public void AddNewPage()
    {
        _addPage = true;
    }

    //更新頁面索引
    public void ChangeActivePageIndex(int index)
    {
        _activePageIndex = index;
        _changeActivePageIndex = true;
    }

    //更新頁面索引
    public int UpdateActivePageIndex()
    {
        if (_changeActivePageIndex)
        {
            _changeActivePageIndex = false;
            return _activePageIndex;
        }
        return -1;
    }

    //新增頁面
    public bool GetAddPage()
    {
        bool result = _addPage;
        _addPage = false;
        return result;
    }


    //刪除頁面
    public void DeleteNewPage()
    {
        _deletePage = true;
    }

    //刪除頁面資訊
    public bool GetDeletePage()
    {
        bool result = _deletePage;
        _deletePage = false;
        return result;
    }

    //使用index刪除頁面
    public void DeletePageByIndex(int index)
    {
        _deletePageByIndex = true;
        _deletePageIndex = index;
    }

    //使用index插入頁面
    public void InsertPageByIndex(BindingList<Shape> list, int index, Size pageSize)
    {
        _insertPageByIndex = true;
        _deletePageList = list;
        _deletePageIndex = index;
        _deletePageSize = pageSize;
    }

    // 構造函數，初始化模型
    public Model(BindingList<Shape> shapeList, ControlManager controlManager)
    {
        this._shapeList = shapeList;
        this._controlManager = controlManager;
    }

    // 設定shapeList
    public void SetShapeList(BindingList<Shape> shapeList)
    {
        this._shapeList = shapeList;
    }

    //設定刪除頁面
    public UndoResult UndoDeletePage()
    {
        _insertPageByIndex = false;
        return new UndoResult
        {
            PageShape = _deletePageList,
            PageIndex = _deletePageIndex,
            PageSize = _deletePageSize
        };
    }

    //設定還原刪除頁面資訊
    public UndoResult RedoDeletePage()
    {
        _deletePageByIndex = false;
        return new UndoResult
        {
            PageIndex = _deletePageIndex,
        };
    }

    //設定是否再縮放
    public void SetZoom(bool zoom)
    {
        this._zoom = zoom;
    }

    // 新增 DataGrid 資料
    public void PopLine()
    {
        _shapeList.RemoveAt(_shapeList.Count - 1);
    }

    // 新增 DataGrid 資料
    public void AddNewLine(Shape shape)
    {
        _shapeList.Add(shape);
    }

    // 刪除特定列的物件
    public void DeleteLineByIndex(int index)
    {
        if (_shapeList.Count > index)
        {
            _controlManager.DeleteCommand(this, _shapeList[index], index);
            _shapeList.RemoveAt(index);
        }
        NotifyModelChanged();
    }

    // 滑鼠左鍵按下事件處理
    public void PressPointerDrawing(double pressX, double pressY)
    {
        if (_hint != null)
            if (pressX > 0 && pressY > 0 && _hint != null)
            {
                _firstPointX = pressX;
                _firstPointY = pressY;
                _hint.SetPoint1(_firstPointX, _firstPointY);
                _isPressed = true;
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
            FindSelectIndex(pressX, pressY);
        }
        NotifyModelChanged();
    }

    //找到選取物件index
    public void FindSelectIndex(double pressX, double pressY)
    {
        _selectIndex = -1;
        _isSelect = false;
        for (int i = _shapeList.Count - 1; i >= 0; i--)
            if (IsPointWithinBoundingBox(pressX, pressY, _shapeList[i]))
            {
                _selectIndex = i;
                _isSelect = true;
                _previous = _shapeList[_selectIndex].Clone();
                break;
            }
        
    }

    // 滑鼠移動事件處理（用於繪製形狀）
    public void MovedPointerDrawing(double pressX, double pressY)
    {
        if (_isPressed)
            if (_hint != null)
                _hint.SetPoint2(pressX, pressY);
        NotifyModelChanged();
    }

    // 滑鼠移動事件處理（用於移動形狀）
    public void MovedPointerPoint(double pressX, double pressY)
    {
        if (_zoom && _isPressed)
        {
            _shapeList[_selectIndex].SetPoint2(_shapeList[_selectIndex].GetX2() + pressX - _firstPointX, _shapeList[_selectIndex].GetY2() + pressY - _firstPointY);
            _firstPointX = pressX;
            _firstPointY = pressY;
        }
        else if (_isSelect && _selectIndex >= 0)
        {
            _shapeList[_selectIndex].Move(pressX - _lastClickX, pressY - _lastClickY);
            _lastClickX = pressX;
            _lastClickY = pressY;
        }
        NotifyModelChanged();
    }

    // 滑鼠左鍵釋放事件處理（用於選擇點）
    public void ReleasedPointerPoint(double pressX, double pressY)
    {
        if (_selectIndex >= 0)
            if (_zoom && _isPressed)
                _controlManager.ResizeCommand(this, _previous, _shapeList[_selectIndex].Clone(), _selectIndex);
            else if (_isSelect && _selectIndex >= 0)       
                _controlManager.MoveCommand(this, _previous, _shapeList[_selectIndex].Clone(), _selectIndex);
        _isSelect = false;
        _isPressed = false;
        NotifyModelChanged();
    }

    // 滑鼠左鍵釋放事件處理（用於繪製形狀）
    public void ReleasedPointerDrawing(double pressX, double pressY)
    {
        _isSelect = false;
        _isPressed = false;
        if (_hint != null)
            _hint = _factory.CreateShape(_shapeToolButtonState, new Point((int)_firstPointX, (int)_firstPointY), new Point((int)pressX, (int)pressY));
        if (_hint != null)
        {
            _shapeList.Add(_hint);
            _controlManager.DrawCommand(this, _hint.Clone());
        }
        NotifyModelChanged();
        _hint = null;
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
        for (int index = 0; index < _shapeList.Count; index++)
            _shapeList[index].Draw(graphics, index == _selectIndex);
        if (_isPressed && _hint != null)
            _hint.Draw(graphics);
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

    // 回傳selectindex
    public int GetSelectIndex()
    {
        return _selectIndex;
    }

    //新增物件by索引
    public void InsertByIndex(int index, Shape temp)
    {
        this._shapeList.Insert(index, temp);
    }

    //新增物件by索引
    public void ChangeByIndex(int index, Shape temp)
    {
        this._shapeList[index] = temp;
    }

    // 清除狀態（解除按壓等）
    public void ClearState()
    {
        this._selectIndex = -1;
        this._isPressed = false;
        this._isSelect = false;
    }

    // 更新工具欄按鈕選中狀態
    public void UpdateToolStripButtonCheck(string temp)
    {
        _hint = _factory.CreateShape(temp);
        if (temp == ELLIPSE)
           _shapeToolButtonState = NAME_ELLIPSE;
        else if (temp == LINE)
            _shapeToolButtonState = NAME_LINE;
        else if (temp == RECTANGLE)
            _shapeToolButtonState = NAME_RECTANGLE;
    }
}