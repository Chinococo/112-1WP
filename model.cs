using System.Windows.Forms;

public class MainModel
{
    public DataGridView DataDisplayGrid;
    public ComboBox shape_combobox;
    public MainModel(DataGridView DataDisplayGrid, ComboBox shape_combobox)
    {
        this.DataDisplayGrid = DataDisplayGrid;
        this.shape_combobox = shape_combobox;

    }
    public object[] AddNewLineDataGrid()
    {
        DataGridViewButtonCell button = new DataGridViewButtonCell();
        button.Value = "刪除";

        object shapeComboBoxValue = shape_combobox.SelectedItem;
        string data;

        if (shapeComboBoxValue != null && shapeComboBoxValue.ToString() == "線")
        {
            data = "(0,0,50,50)";
        }
        else
        {
            data = "(25,25,50,50)";
        }

        button.UseColumnTextForButtonValue = true; // 设置按钮显示文本

        return new object[] { button, shapeComboBoxValue, data };
    }
}
