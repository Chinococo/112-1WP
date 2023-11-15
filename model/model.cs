using HW2;
using HW2.Object;
using System;
using System.ComponentModel;
using System.Windows.Forms;

public class Model
{
    public event ModelChangedEventHandler _modelChanged;

    public delegate void ModelChangedEventHandler();

    private ToolStripButton _toolStripEllipseButton;
    private ToolStripButton _toolStripLineButton;
    private ToolStripButton _toolStripRectangleButton;
    private ToolStripButton _toolStripCursorsButton;
    private Button _buttonPage1;
    private DataGridView _dataDisplayGrid;
    private ComboBox _shapeCombobox;
    private Factory _factory;
    private double _lastClickX;
    private double _lastClickY;
    private BindingList<Shape> _shapeList;
    private const string ENLINE = "Line";
    private const string ENRECTANGLE = "Rectangle";
    private const string ENELLIPS = "Ellipse";
    private const string DELETE = "刪除";
    private const string LINE = "線";
    private const string RECTANGLE = "矩形";
    private int _pageIndex = 0;
    private double _firstPointX;
    private double _firstPointY;
    private bool _isPressed = false;
    private bool _isSelect = false;
    private int _selectIndex = -1;
    private Shape _hint;
    private IState state;

    public Model(DataGridView datagrid, ComboBox combobox, Factory mainfactory, BindingList<Shape> shapelist, ToolStripButton buttonellipse, ToolStripButton buttonline, ToolStripButton buttonrectangle, ToolStripButton buttoncursors, Button buttonPage1)
    {
        this._dataDisplayGrid = datagrid;
        this._shapeCombobox = combobox;
        this._factory = mainfactory;
        this._shapeList = shapelist;
        this._toolStripEllipseButton = buttonellipse;
        this._toolStripLineButton = buttonline;
        this._toolStripRectangleButton = buttonrectangle;
        this._toolStripCursorsButton = buttoncursors;
        this._buttonPage1 = buttonPage1;
    }

    //新增DataGrid資料
    public void AddNewLine()
    {
        if (_shapeCombobox != null && _shapeCombobox.Text == LINE)
        {
            _shapeList.Add(_factory.CreateShape(ENLINE));
        }
        else if (_shapeCombobox != null && _shapeCombobox.Text == RECTANGLE)
        {
            _shapeList.Add(_factory.CreateShape(ENRECTANGLE));
        }
        else
        {
            _shapeList.Add(_factory.CreateShape(ENELLIPS));
        }
        NotifyModelChanged();
    }

    //刪除特定列的物件
    public void DeleteLineByIndex(int index)
    {
        _shapeList.RemoveAt(index);
        NotifyModelChanged();
    }

    //滑鼠左鍵事件
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

    public void PressPointerPoint(double x, double y)
    {
        _lastClickX = x;
        _lastClickY = y;
        _selectIndex = -1;
        _isSelect = false;
        // Iterate through the shapes in reverse order
        for (int i = _shapeList.Count - 1; i >= 0; i--)
        {
            Shape shape = _shapeList[i];

            // Check if the clicked coordinates fall within the bounding box of the shape
            if (IsPointWithinBoundingBox(x, y, shape))
            {
                _selectIndex = i;
                _isSelect = true;
                break; // Exit the loop after deleting the first matching shape
            }
        }
        NotifyModelChanged();
    }

    public void PressedPointer(double x, double y)
    {
        if (state != null)
            state.MouseDown(x, y);
    }

    //滑鼠移動事件
    public void MovedPointerDrawing(double x, double y)
    {
        if (_isPressed)
        {
            if (_hint != null)
            {
                _hint.SetPoint2(x, y);
                NotifyModelChanged();
            }
        }
    }

    public void MovedPointerPoint(double x, double y)
    {
        if (_isSelect && _selectIndex >= 0)
        {
            _shapeList[_selectIndex].Move(x - _lastClickX, y - _lastClickY);
            _lastClickX = x;
            _lastClickY = y;
            NotifyModelChanged();
        }
    }

    public void MovedPointer(double x, double y)
    {
        if (state != null)
            state.MouseMove(x, y);
    }

    public void ReleasedPointerPoint(double x, double y)
    {
        _isSelect = false;
        NotifyModelChanged();
    }

    public void ReleasedPointerDrawing(double x, double y)
    {
        _isSelect = false;
        if (_isPressed)
        {
            Shape hint;
            _isPressed = false;
            if (_toolStripEllipseButton.Checked)
            {
                hint = _factory.CreateShape(ENELLIPS, _firstPointX, _firstPointY, x, y);
                _hint.SetPoint1(_firstPointX, _firstPointY);
                _hint.SetPoint2(x, y);
                _shapeList.Add(hint);
            }
            else if (_toolStripLineButton.Checked)
            {
                hint = _factory.CreateShape(ENLINE, _firstPointX, _firstPointY, x, y);
                _hint.SetPoint1(_firstPointX, _firstPointY);
                _hint.SetPoint2(x, y);
                _shapeList.Add(hint);
            }
            else if (_toolStripRectangleButton.Checked)
            {
                hint = _factory.CreateShape(ENRECTANGLE, _firstPointX, _firstPointY, x, y);
                _shapeList.Add(hint);
            }
            NotifyModelChanged();
            _hint = null;
        }
    }

    //是否鼠標事件

    public void ReleasedPointer(double x, double y)
    {
        if (state != null)
            state.ReleasedPointer(x, y);
    }

    //情除所有在畫面上的物件 並解除按壓
    public void Clear()
    {
        _isPressed = false;
        _shapeList.Clear();
        NotifyModelChanged();
    }

    //廣播畫面需要更新事件

    private void NotifyModelChanged()
    {
        if (_modelChanged != null)
            _modelChanged();
    }

    //獎畫面全部清除在一一畫上去目前最新的圖案

    public void Draw(IGraphics graphics)
    {
        graphics.ClearAll();
        int index = 0; // start with the first shape
        foreach (Shape shape in _shapeList)
        {
            shape.Draw(graphics, index == _selectIndex);
            index++;
        }

        if (_isPressed)
            _hint.Draw(graphics);
    }

    //依照類別創建物件

    public void UpdateToolStripButtonCheck(ToolStripButton temp)
    {
        if (temp.Name == _toolStripEllipseButton.Name)
            _hint = _factory.CreateShape(ENELLIPS);
        else if (temp.Name == _toolStripLineButton.Name)
            _hint = _factory.CreateShape(ENLINE);
        else
            _hint = _factory.CreateShape(ENRECTANGLE);
    }

    private bool IsPointWithinBoundingBox(double x, double y, Shape shape)
    {
        // Check if the clicked coordinates fall within the bounding box of the shape
        double minX = Math.Min(shape.GetX1(), shape.GetX2());
        double minY = Math.Min(shape.GetY1(), shape.GetY2());
        double maxX = Math.Max(shape.GetX1(), shape.GetX2());
        double maxY = Math.Max(shape.GetY1(), shape.GetY2());

        return (x >= minX && x <= maxX && y >= minY && y <= maxY);
    }

    public void btnDelete_Click()
    {
        // Your delete logic goes here
        // For example, you might want to delete the selected shape from your _shapeList

        // Assuming _selectedIndex is the index of the shape you want to delete
        if (_selectIndex >= 0 && _selectIndex < _shapeList.Count)
        {
            _shapeList.RemoveAt(_selectIndex);
        }
        NotifyModelChanged();
    }

    public void ClearState()
    {
        this._selectIndex = -1;
        this._isPressed = false;
        this._isSelect = false;
    }

    public void ChangeState(bool Drawing)
    {
        if (Drawing)
            state = new DrawingState(this);
        else
            state = new PointState(this);
    }
}