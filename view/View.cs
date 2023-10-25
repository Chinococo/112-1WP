using System.Collections.Generic;
using System.Windows.Forms;

public class View
{
    private Model _model;
    private DataGridView _dataDisplayGrid;
    private List<Shape> _shapeList;
    public View(Model prmaModel, DataGridView prmaDataGrid, List<Shape> shapelist)
    {
        this._model = prmaModel;
        this._dataDisplayGrid = prmaDataGrid;
        this._shapeList = shapelist;
    }

    //更新畫面
    public void UpdateView()
    {
        _dataDisplayGrid.Rows.Clear();
        foreach (Shape shape in _shapeList)
        {
            int index = _dataDisplayGrid.Rows.Add();
            DataGridViewRow dataGridViewRow = _dataDisplayGrid.Rows[index];
            dataGridViewRow.Cells["_deleteCloumn"].Value = "刪除";
            dataGridViewRow.Cells["_shapeCloumn"].Value = shape.GetShapeName();
            dataGridViewRow.Cells["_infoCloumn"].Value = shape.GetInfo();
        }
    }
}