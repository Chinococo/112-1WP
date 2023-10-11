using System.Windows.Forms;

public class View
{
    private Model _model;
    private DataGridView _dataDisplayGrid;
    public View(Model model, DataGridView DataDisplayGrid)
    {
        this._model = model;
        this._dataDisplayGrid = DataDisplayGrid;
    }
    //新增一行新的DataGrid
    public void AddNewDataGridData()
    {
        _dataDisplayGrid.Rows.Add(_model.AddNewLineDataGrid());
    }
}