using System.Windows.Forms;

public class View
{
    private Model _model;
    private DataGridView _dataDisplayGrid;
    public View(Model prmaModel, DataGridView prmaDataGrid)
    {
        this._model = prmaModel;
        this._dataDisplayGrid = prmaDataGrid;
    }
    //新增一行新的DataGrid
    public void AddNewDataGridData()
    {
        _dataDisplayGrid.Rows.Add(_model.AddNewLine());
    }
}