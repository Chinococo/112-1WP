using HW2;
using System.Collections.Generic;
using System.Windows.Forms;

public class Model
{
    public event ModelChangedEventHandler _modelChanged;
    public delegate void ModelChangedEventHandler();
    ToolStripButton _toolStripEllipseButton;
    ToolStripButton _toolStripLineButton;
    ToolStripButton _toolStripRectangleButton;
    private DataGridView _dataDisplayGrid;
    private ComboBox _shapeCombobox;
    private Factory _factory;
    private List<Shape> _shapeList;
    private const string ENLINE = "Line";
    private const string ENRECTANGLE = "Rectangle"; 
    private const string ENELLIPS = "Ellipse";
    private const string DELETE = "刪除";
    private const string LINE = "線";
    private const string RECTANGLE = "矩形";
    double _firstPointX;
    double _firstPointY;
    bool _isPressed = false;
    Shape _hint;
    public Model(DataGridView datagrid, ComboBox combobox, Factory mainfactory, List<Shape> shapelist, ToolStripButton buttonellipse, ToolStripButton buttonline, ToolStripButton buttonrectangle)
    {
        this._dataDisplayGrid = datagrid;
        this._shapeCombobox = combobox;
        this._factory = mainfactory;
        this._shapeList = shapelist;
        this._toolStripEllipseButton = buttonellipse;
        this._toolStripLineButton = buttonline;
        this._toolStripRectangleButton = buttonrectangle;
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

    public void PressedPointer(double x, double y)
    {

        if (x > 0 && y > 0 && _hint != null)
        {
            _firstPointX = x;
            _firstPointY = y;
            _hint.SetPoint1(_firstPointX, _firstPointY);
            _isPressed = true;
        }
    }

    public void MovedPointer(double x, double y)
    {
        if (_isPressed)
        {
            _hint.SetPoint2(x, y);
            NotifyModelChanged();
        }
    }

    public void ReleasedPointer(double x, double y)
    {
        if (_isPressed)
        {
            Shape hint;
            _isPressed = false;
            if (_toolStripEllipseButton.Checked)
            {
                hint = _factory.CreateShape(ENELLIPS, _firstPointX, _firstPointY, x, y);
                _hint.SetPoint1(_firstPointX, _firstPointY);
                _hint.SetPoint2(x, y);
            }
            else if (_toolStripLineButton.Checked)
            {
                hint = _factory.CreateShape(ENLINE, _firstPointX, _firstPointY, x, y);
                _hint.SetPoint1(_firstPointX, _firstPointY);
                _hint.SetPoint2(x, y);

            }
            else
            {
                hint = _factory.CreateShape(ENRECTANGLE, _firstPointX, _firstPointY, x, y);
            }
            _shapeList.Add(hint);
            NotifyModelChanged();
        }
    }
    //情除所有在畫面上的物件 並解除按壓
    public void Clear()
    {
        _isPressed = false;
        _shapeList.Clear();
        NotifyModelChanged();
    }
    //廣播畫面需要更新事件
    void NotifyModelChanged()
    {
        if (_modelChanged != null)
            _modelChanged();
    }
    //獎畫面全部清除在一一畫上去目前最新的圖案
    public void Draw(IGraphics graphics)
    {
        graphics.ClearAll();
        foreach (Shape shape in _shapeList)
            shape.Draw(graphics);
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
}
