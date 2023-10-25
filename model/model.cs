using HW2;
using System.Collections.Generic;
using System.Windows.Forms;

public class Model
{
    ToolStripButton _toolStripCirecleButton, _toolStripLineButton, _toolStripRectangleButton;
    private DataGridView _dataDisplayGrid;
    private ComboBox _shapeCombobox;
    private Factory _factory;
    private List<Shape> _shapeList;
    private const string LINE_INFO = "(0,0,50,50)";
    private const string RECTANGLE_INFO = "(25,25,50,50)";
    private const string DELETE = "刪除";
    private const string LINE = "線";
    private const string RECTANGLE = "矩形";
    public event ModelChangedEventHandler _modelChanged;
    public delegate void ModelChangedEventHandler();
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
        this._toolStripCirecleButton = buttonellipse;
        this._toolStripLineButton = buttonline;
        this._toolStripRectangleButton = buttonrectangle;
    }
    //新增DataGrid資料
    public void AddNewLine()
    {
        if (_shapeCombobox != null && _shapeCombobox.Text == LINE)
        {
            _shapeList.Add(_factory.CreateShape("Line"));
        }
        else if(_shapeCombobox != null && _shapeCombobox.Text == RECTANGLE)
        {
            _shapeList.Add(_factory.CreateShape("Rectangle"));
        }
        else
        {
            _shapeList.Add(_factory.CreateShape("Ellipse"));
        }
        NotifyModelChanged();
    }
    public void DeleteLineByIndex(int index)
    {
        _shapeList.RemoveAt(index);
        NotifyModelChanged();
    }
    public void PointerPressed(double x, double y)
    {

        if (x > 0 && y > 0&&_hint!=null)
        {
            _firstPointX = x;
            _firstPointY = y;
            _hint.x1 = _firstPointX;
            _hint.y1 = _firstPointY;
            _isPressed = true;
        }
    }
    public void PointerMoved(double x, double y)
    {
        if (_isPressed)
        {
            _hint.x2 = x;
            _hint.y2 = y;
            NotifyModelChanged();
        }
    }
    public void PointerReleased(double x, double y)
    {
        if (_isPressed)
        {
            Shape hint;
            _isPressed = false;
            if (_toolStripCirecleButton.Checked)
            {
                hint = _factory.CreateShape("Ellipse", _firstPointX, _firstPointY, x, y);
                hint.x1 = _firstPointX;
                hint.y1 = _firstPointY;
                hint.x2 = x;
                hint.y2 = y;
            }
            else if(_toolStripLineButton.Checked)
            {
                hint = _factory.CreateShape("Line", _firstPointX, _firstPointY, x, y);
                hint.x1 = _firstPointX;
                hint.y1 = _firstPointY;
                hint.x2 = x;
                hint.y2 = y;

            }
            else
            {
                hint = _factory.CreateShape("Rectangle", _firstPointX, _firstPointY, x, y);
            }
            _shapeList.Add(hint);
            NotifyModelChanged();
        }
    }
    public void Clear()
    {
        _isPressed = false;
        _shapeList.Clear();
        NotifyModelChanged();
    }
    void NotifyModelChanged()
    {
        if (_modelChanged != null)
            _modelChanged();
    }
    public void Draw(IGraphics graphics)
    {
        graphics.ClearAll();
        foreach (Shape shape in _shapeList)
            shape.Draw(graphics);
        if (_isPressed)
            _hint.Draw(graphics);
    }
    public void UpdateToolStripButtonCheck(ToolStripButton temp)
    {
        if (temp.Name == "_toolStripEllipseButton")
            _hint = _factory.CreateShape("Ellipse");
        else if (temp.Name == "_toolStripLineButton")
            _hint = _factory.CreateShape("Line");
        else
            _hint = _factory.CreateShape("Rectangle");
    }
}
