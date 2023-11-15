using HW2.DrawingForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW2
{
    public partial class Form1 : Form
    {
        private Model _model;
        private View _view;
        private Factory _factory;
        private BindingList<Shape> _shapeList = new BindingList<Shape>();
        PresentationModel.PresentationModel _presentationModel;
        //Panel _canvas = new DoubleBufferedPanel();
        public Form1()
        {
            InitializeComponent();
            _factory = new Factory();
            _model = new Model( _displayDataGrid, _shapeCombobox, _factory, _shapeList,_toolStripEllipseButton,_toolStripLineButton,_toolStripRectangleButton,_toolStripCursorsButton,_buttonPage1);
            _view = new View(_model, _displayDataGrid, _shapeList);
            _displayDataGrid.DataSource = _shapeList;
            this.KeyPreview = true;
            this.KeyDown += Delete_KeyDown;
            // prepare canvas
            //
            /*
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            _canvas.MouseEnter += DrawingAreaMouseEnter;
            _canvas.MouseLeave += DrawingAreaMouseLeave;
            _canvas.Location = new System.Drawing.Point(168, 52);
            _canvas.Size = new System.Drawing.Size(548, 397);
            */
            //_panel.Dock = DockStyle.Fill;
            _panel.BackColor = System.Drawing.Color.LightYellow;
            _panel.MouseDown += HandleCanvasPressed;
            _panel.MouseUp += HandleCanvasReleased;
            _panel.MouseMove += HandleCanvasMoved;
            _panel.Paint += HandleCanvasPaint;
            _panel.MouseEnter += DrawingAreaMouseEnter;
            _panel.MouseLeave += DrawingAreaMouseLeave;
            Controls.Add(_panel);
            //
            // prepare presentation model and model
            //
            _presentationModel = new PresentationModel.PresentationModel(_model, _panel, _toolStripEllipseButton, _toolStripLineButton, _toolStripRectangleButton,_toolStripCursorsButton, _buttonPage1);
            _model._modelChanged += HandleModelChanged;
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
            if (e.ColumnIndex == 1) // 请替换 deleteColumnIndex 为“删除”按钮所在的列索引
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
            this.Cursor = Cursors.Default;
            _presentationModel.ClearToolStripButtonCheck();
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
            UpdateButtonPage();
        }

        //按下toolstrip按鈕事件

        private void ToolStripEllipseButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UpdateToolStripButtonCheck(_toolStripEllipseButton);
            _model.UpdateToolStripButtonCheck(_toolStripEllipseButton);
            _model.ClearState();
        }

        //按下toolstrip按鈕事件

        private void ToolStripLineButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UpdateToolStripButtonCheck(_toolStripLineButton);
            _model.UpdateToolStripButtonCheck(_toolStripLineButton);
            _model.ClearState();
        }

        //按下toolstrip按鈕事件

        private void ToolStripRectangleButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UpdateToolStripButtonCheck(_toolStripRectangleButton);
            _model.UpdateToolStripButtonCheck(_toolStripRectangleButton);
            _model.ClearState();
        }

        //光標便十字事件
        private void DrawingAreaMouseEnter(object sender, EventArgs e)
        {
            // 鼠标进入绘图区域时，设置鼠标光标为十字形
            if(_toolStripRectangleButton.Checked||
                _toolStripEllipseButton.Checked||
                _toolStripLineButton.Checked)
                this.Cursor = Cursors.Cross;
        }

        //離開畫面事件
        private void DrawingAreaMouseLeave(object sender, EventArgs e)
        {
            // 鼠标离开绘图区域时，恢复默认光标
            this.Cursor = Cursors.Default;
        }

        private void _toolStripCursorsButton_Click(object sender, EventArgs e)
        {
            _presentationModel.UpdateToolStripButtonCheck(_toolStripCursorsButton);
            _model.ClearState();
            //_model.UpdateToolStripButtonCheck(_toolStripRectangleButton);
        }
        private void UpdateButtonPage()
        {
            Bitmap bitmap = new Bitmap(_panel.Width, _panel.Height);
            _panel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, _panel.Width, _panel.Height));
            _buttonPage1.BackgroundImage = bitmap;
            _buttonPage1.BackgroundImageLayout = ImageLayout.Zoom;
        }
        private void Delete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _model.btnDelete_Click();
            }
        }
    }
    
}
