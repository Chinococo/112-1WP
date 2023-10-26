using HW2.DrawingForm;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form1 : Form
    {
        private Model _model;
        private View _view;
        private Factory _factory;
        private List<Shape> _shapeList = new List<Shape>();
        private PresentationModel.PresentationModel _presentationModel;
        private Panel _canvas = new DoubleBufferedPanel();

        public Form1()
        {
            InitializeComponent();
            _factory = new Factory();
            _model = new Model(_displayDataGrid, _shapeCombobox, _factory, _shapeList, _toolStripEllipseButton, _toolStripLineButton, _toolStripRectangleButton);
            
            // prepare canvas
            //
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            _canvas.MouseEnter += DrawingAreaMouseEnter;
            _canvas.MouseLeave += DrawingAreaMouseLeave;
            _canvas.

            Controls.Add(_canvas);
            //
            // prepare presentation model and model
            //
            _presentationModel = new PresentationModel.PresentationModel(_model, _canvas);
            _model._modelChanged += HandleModelChanged;
            _view = new View(_model, _presentationModel, _displayDataGrid, _shapeList, _toolStripEllipseButton, _toolStripLineButton, _toolStripRectangleButton);
        }

        //新增按鈕觸發事件
        private void InsertButtonClick(object sender, EventArgs e)
        {
            _model.AddNewLine();
            //_presentationModel.Draw(graphics);
            _view.UpdateView();
        }

        //DataGrid按鈕觸發處理事件
        private void DisplayDataGridCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) // 请替换 deleteColumnIndex 为“删除”按钮所在的列索引
            {
                _model.DeleteLineByIndex(e.RowIndex);
                _view.UpdateView();
            }
        }

        //清除按鈕觸碰事件

        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
        }

        //Canvas被點擊事件

        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PressedPointer(e.X, e.Y);
        }

        //Canvas被釋放事件

        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleasedPointer(e.X, e.Y);
            _view.UpdateView();
        }

        //Canvas被移動事件

        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovedPointer(e.X, e.Y);
        }

        //Canvas被繪圖事件

        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        //Canvase更新事件

        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        //按下toolstrip按鈕事件

        private void ToolStripEllipseButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UpdateToolStripButtonCheck("Ellipse");
            _model.UpdateToolStripButtonCheck(_toolStripEllipseButton);
            _view.UpdateView();
        }

        //按下toolstrip按鈕事件

        private void ToolStripLineButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UpdateToolStripButtonCheck("Line");
            _model.UpdateToolStripButtonCheck(_toolStripLineButton);
            _view.UpdateView();
        }

        //按下toolstrip按鈕事件

        private void ToolStripRectangleButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UpdateToolStripButtonCheck("Rectangle");
            _model.UpdateToolStripButtonCheck(_toolStripRectangleButton);
            _view.UpdateView();
        }

        //光標便十字事件
        private void DrawingAreaMouseEnter(object sender, EventArgs e)
        {
            // 鼠标进入绘图区域时，设置鼠标光标为十字形
            this.Cursor = Cursors.Cross;
        }

        //離開畫面事件
        private void DrawingAreaMouseLeave(object sender, EventArgs e)
        {
            // 鼠标离开绘图区域时，恢复默认光标
            this.Cursor = Cursors.Default;
        }
    }
}