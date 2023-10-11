using System.Windows.Forms;

public class View
{
    public Model _model;
    public DataGridView _DataDisplayGrid;
    public View(Model model, DataGridView DataDisplayGrid)
    {
        this._model = model;
        this._DataDisplayGrid = DataDisplayGrid;
    }
    //新增一行新的DataGrid
    public void AddNewDataGridData()
    {
        _DataDisplayGrid.Rows.Add(_model.AddNewLineDataGrid());
    }
}