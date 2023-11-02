using HW2.PresentationModel;
using System.Collections.Generic;
using System.Windows.Forms;

public class View
{
    private Model _model;
    private PresentationModel _presentationModel;
   // private DataGridView _dataDisplayGrid;
    private List<Shape> _shapeList;
    private const string DELETE = "刪除";
    private const string DELETECOLUMN = "_deleteCloumn";
    private const string SHAPECOLUMN = "_shapeCloumn";
    private const string INFOCOLUMN = "_infoCloumn";
    //private ToolStripButton _toolStripEllipseButton;
    //private ToolStripButton _toolStripLineButton;
    //private ToolStripButton _toolStripRectangleButton;

    public View(Model prmaModel)
    {
        this._model = prmaModel;
    }

    //更新DataGrid
    public DataGridView UpdateDataGrid()
    {
        DataGridView newDataGridView = new DataGridView();

        // 在这里对新的 DataGridView 进行任何初始化或设置操作
        // 例如，设置列、行、样式等

        foreach (Shape shape in _shapeList)
        {
            // 在新的 DataGridView 中添加行并设置数据
            int rowIndex = newDataGridView.Rows.Add();
            newDataGridView.Rows[rowIndex].Cells[DELETECOLUMN].Value = DELETE;
            newDataGridView.Rows[rowIndex].Cells[SHAPECOLUMN].Value = shape.GetShapeName();
            newDataGridView.Rows[rowIndex].Cells[INFOCOLUMN].Value = shape.GetInfo();
        }
        return newDataGridView;
        //Dictionary<string, bool> State = _presentationModel.GetToolStripButtonState();
        //_toolStripEllipseButton.Checked = State["Ellipse"];
        //_toolStripLineButton.Checked = State["Line"];
        //_toolStripRectangleButton.Checked = State["Rectangle"];
    }
}