using System.Windows.Forms;

public class MainModel { 
public DataGridView DataDisplayGrid;
    public ComboBox shape_combobox;
    public MainModel( DataGridView DataDisplayGrid, ComboBox shape_combobox)
    {
        this.DataDisplayGrid = DataDisplayGrid;
        this.shape_combobox = shape_combobox;

    }
    public void AddNewLineDataGrid()
    {

        DataGridViewButtonCell button = new DataGridViewButtonCell();
        button.Value = "刪除";
        // 添加一行，包括一个按钮、两个文本框的值和指定的额外值
        DataDisplayGrid.Rows.Add(button,shape_combobox.SelectedValue, "(0,0,0,0)");
    }
}
