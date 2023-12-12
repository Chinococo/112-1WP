using System.ComponentModel;
using System.Windows.Forms;

public class View
{
    private Model _model;
    private const string DELETE = "刪除";
    private const string DELETECOLUMN = "_deleteCloumn";
    private const string SHAPECOLUMN = "_shapeCloumn";
    private const string INFOCOLUMN = "_infoCloumn";

    public View(Model prmaModel)
    {
        this._model = prmaModel;
    }

    //更新畫面
    public void UpdateView()
    {
        /*
        _dataDisplayGrid.Rows.Clear();
        foreach (Shape shape in _shapeList)
        {
            int index = _dataDisplayGrid.Rows.Add();
            DataGridViewRow dataGridViewRow = _dataDisplayGrid.Rows[index];
            dataGridViewRow.Cells[DELETECOLUMN].Value = DELETE;
            dataGridViewRow.Cells[SHAPECOLUMN].Value = shape.GetShapeName();
            dataGridViewRow.Cells[INFOCOLUMN].Value = shape.GetInfo();
        }
        */
    }
}