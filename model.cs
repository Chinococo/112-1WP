using System.Windows.Forms;

public class Model
{
    private DataGridView _dataDisplayGrid;
    private ComboBox _shapeCombobox;
    private Factory _factory;
    private const string LINE_INFO = "(0,0,50,50)";
    private const string RECTANGLE_INFO = "(25,25,50,50)";
    private const string DELETE = "刪除";
    public Model(DataGridView datagrid, ComboBox combobox, Factory mainfactory)
    {
        this._dataDisplayGrid = datagrid;
        this._shapeCombobox = combobox;
        this._factory = mainfactory;
    }
    //新增DataGrid資料
    public object[] AddNewLineDataGrid()
    {
        DataGridViewButtonCell button = new DataGridViewButtonCell();
        button.UseColumnTextForButtonValue = true;
        button.Value = DELETE;
        object shapeComboBoxValue = _shapeCombobox.SelectedItem;
        string data;

        if (shapeComboBoxValue != null && shapeComboBoxValue.ToString() == "線")
        {
            data = LINE_INFO;
            _factory.AddLine();
        }
        else
        {
            data = RECTANGLE_INFO;
            _factory.AddRectangle();
        }

        button.UseColumnTextForButtonValue = true; // 设置按钮显示文本

        return new object[] { button, shapeComboBoxValue, data };
    }
}
