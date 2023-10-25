using System.Collections.Generic;
using System.Windows.Forms;

public class Model
{
    private DataGridView _dataDisplayGrid;
    private ComboBox _shapeCombobox;
    private Factory _factory;
    private List<Shape> _shapeList;
    private const string LINE_INFO = "(0,0,50,50)";
    private const string RECTANGLE_INFO = "(25,25,50,50)";
    private const string DELETE = "刪除";
    private const string LINE = "線";
    public Model(DataGridView datagrid, ComboBox combobox, Factory mainfactory, List<Shape> shapelist)
    {
        this._dataDisplayGrid = datagrid;
        this._shapeCombobox = combobox;
        this._factory = mainfactory;
        this._shapeList = shapelist;
    }
    //新增DataGrid資料
    public void AddNewLine()
    {
        if (_shapeCombobox != null && _shapeCombobox.Text == LINE)
        {
            _shapeList.Add(new Line());
        }
        else
        {
            _shapeList.Add(new Rectangle());
        }
    }
    public void DeleteLineByIndex(int index)
    {
        _shapeList.RemoveAt(index);
    }
}
