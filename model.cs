using System.Windows.Forms;

public class Model
{
    public DataGridView DataDisplayGrid;
    public ComboBox shape_combobox;
    public Factory factory;
    public Model(DataGridView DataDisplayGrid, ComboBox shape_combobox, Factory factory)
    {
        this.DataDisplayGrid = DataDisplayGrid;
        this.shape_combobox = shape_combobox;
        this.factory = factory;
    }
    public object[] AddNewLineDataGrid()
    {
        DataGridViewButtonCell button = new DataGridViewButtonCell();
        button.UseColumnTextForButtonValue = true;
        button.Value = "刪除";
        object shapeComboBoxValue = shape_combobox.SelectedItem;
        string data;

        if (shapeComboBoxValue != null && shapeComboBoxValue.ToString() == "線")
        {
            data = "(0,0,50,50)";
            factory.AddLine();
        }
        else
        {
            data = "(25,25,50,50)";
            factory.AddRectangle();
        }

        button.UseColumnTextForButtonValue = true; // 设置按钮显示文本

        return new object[] { button, shapeComboBoxValue, data };
    }
}
