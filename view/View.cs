using HW2.PresentationModel;
using System.Collections.Generic;
using System.Windows.Forms;

public class View
{
    private Model _model;
    private PresentationModel _presentationModel;
    private DataGridView _dataDisplayGrid;
    private List<Shape> _shapeList;
    private const string DELETE = "刪除";
    private const string DELETECOLUMN = "_deleteCloumn";
    private const string SHAPECOLUMN = "_shapeCloumn";
    private const string INFOCOLUMN = "_infoCloumn";
    private ToolStripButton _toolStripEllipseButton;
    private ToolStripButton _toolStripLineButton;
    private ToolStripButton _toolStripRectangleButton;

    public View(Model prmaModel, PresentationModel presentationModel,DataGridView prmaDataGrid, List<Shape> shapelist, ToolStripButton buttonellipse, ToolStripButton buttonline, ToolStripButton buttonrectangle,)
    {
        this._model = prmaModel;
        this._presentationModel = presentationModel;
        this._dataDisplayGrid = prmaDataGrid;
        this._shapeList = shapelist;
        this._toolStripEllipseButton = buttonellipse;
        this._toolStripLineButton = buttonline;
        this._toolStripRectangleButton = buttonrectangle;
    }

    //更新畫面
    public void UpdateView()
    {
        _dataDisplayGrid.Rows.Clear();
        foreach (Shape shape in _shapeList)
        {
            int index = _dataDisplayGrid.Rows.Add();
            DataGridViewRow dataGridViewRow = _dataDisplayGrid.Rows[index];
            dataGridViewRow.Cells[DELETECOLUMN].Value = DELETE;
            dataGridViewRow.Cells[SHAPECOLUMN].Value = shape.GetShapeName();
            dataGridViewRow.Cells[INFOCOLUMN].Value = shape.GetInfo();
        }

        Dictionary<string, bool> State = _presentationModel.GetToolStripButtonState();
        _toolStripEllipseButton.Checked = State["Ellipse"];
        _toolStripLineButton.Checked = State["Line"];
        _toolStripRectangleButton.Checked = State["Rectangle"];
    }
}