using powerpoint.DrawingForm;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace powerpoint
{
    public partial class Form1 : Form
    {
        private Model _model;// 模型
        private View _view;// 視圖
        private Factory _factory;// 工廠
        private BindingList<Shape> _shapeList = new BindingList<Shape>();// 形狀列表
        private PresentationModel.PresentationModel _presentationModel;// 呈現模型
        private DoubleBufferedPanel doubleBufferedPanel = new DoubleBufferedPanel();
        //Panel _canvas = new DoubleBufferedPanel();
        public Form1()
        {
            InitializeComponent();
            _factory = new Factory();
            _model = new Model(_displayDataGrid, _shapeCombobox, _factory, _shapeList, _toolStripEllipseButton, _toolStripLineButton, _toolStripRectangleButton, _toolStripCursorsButton, _buttonPage1);
            _view = new View(_model, _displayDataGrid, _shapeList);
            _displayDataGrid.DataSource = _shapeList;
            this.KeyPreview = true;
            this.KeyDown += DeleteKeyDown;

            // 設定 Canvas（畫布）的相關屬性和事件處理程序
            // ...

            //_panel.Dock = DockStyle.Fill;
            doubleBufferedPanel.BackColor = System.Drawing.Color.LightYellow;
            doubleBufferedPanel.MouseDown += HandleCanvasPressed;
            doubleBufferedPanel.MouseUp += HandleCanvasReleased;
            doubleBufferedPanel.MouseMove += HandleCanvasMoved;
            doubleBufferedPanel.Paint += HandleCanvasPaint;
            doubleBufferedPanel.MouseEnter += DrawingAreaMouseEnter;
            doubleBufferedPanel.MouseLeave += DrawingAreaMouseLeave;
            doubleBufferedPanel.Size = new System.Drawing.Size(
               _groupBox.Location.X - (_groupBox2.Location.X + _groupBox2.Width),
               _groupBox.Location.Y + _displayDataGrid.Size.Height - _groupBox2.Location.Y
           );
            doubleBufferedPanel.Location = new System.Drawing.Point(
                _groupBox2.Location.X + _groupBox2.Width,
                _groupBox2.Location.Y
            );
            Controls.Add(doubleBufferedPanel);

            // 初始化呈現模型和模型
            _presentationModel = new PresentationModel.PresentationModel(_model, doubleBufferedPanel, _toolStripEllipseButton, _toolStripLineButton, _toolStripRectangleButton, _toolStripCursorsButton, _buttonPage1);
            _model._modelChanged += HandleModelChanged;
            UpdateButtonPage();
        }

        // 新增按鈕觸發事件
        private void InsertButtonClick(object sender, EventArgs e)
        {
            _model.AddNewLine();
            _view.UpdateView();
        }

        // DataGrid 按鈕觸發處理事件
        private void DisplayDataGridCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) // 替換 deleteColumnIndex 為“删除”按鈕所在的列索引
            {
                _model.DeleteLineByIndex(e.RowIndex);
                _view.UpdateView();
            }
        }

        // 清除按鈕觸碰事件
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
        }

        // Canvas 被點擊事件
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PressedPointer(e.X, e.Y);
        }

        // Canvas 被釋放事件
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleasedPointer(e.X, e.Y);
            _view.UpdateView();
            this.Cursor = Cursors.Default;
            _presentationModel.ClearToolStripButtonCheck();
        }

        // Canvas 被移動事件
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovedPointer(e.X, e.Y);
        }

        // Canvas 被繪圖事件
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        // Canvas 更新事件
        public void HandleModelChanged()
        {
            Invalidate(true);
            UpdateButtonPage();
        }

        // 按下 toolstrip 按鈕事件
        private void ToolStripEllipseButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UpdateToolStripButtonCheck(_toolStripEllipseButton);
            _model.UpdateToolStripButtonCheck(_toolStripEllipseButton);
            _model.ClearState();
            _model.ChangeState(true);
        }

        // 按下 toolstrip 按鈕事件
        private void ToolStripLineButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UpdateToolStripButtonCheck(_toolStripLineButton);
            _model.UpdateToolStripButtonCheck(_toolStripLineButton);
            _model.ClearState();
            _model.ChangeState(true);
        }

        // 按下 toolstrip 按鈕事件
        private void ToolStripRectangleButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UpdateToolStripButtonCheck(_toolStripRectangleButton);
            _model.UpdateToolStripButtonCheck(_toolStripRectangleButton);
            _model.ClearState();
            _model.ChangeState(true);
        }

        // 光標便十字事件
        private void DrawingAreaMouseEnter(object sender, EventArgs e)
        {
            // 鼠標進入繪圖區域時，設置鼠標光標為十字形
            if (_toolStripRectangleButton.Checked ||
                _toolStripEllipseButton.Checked ||
                _toolStripLineButton.Checked)
                this.Cursor = Cursors.Cross;
        }

        // 離開畫面事件
        private void DrawingAreaMouseLeave(object sender, EventArgs e)
        {
            // 鼠標離開繪圖區域時，恢復默認光標
            this.Cursor = Cursors.Default;
        }

        //ToolStrip游標選擇事件
        private void ToolStripCursorsButtonClick(object sender, EventArgs e)
        {
            _presentationModel.UpdateToolStripButtonCheck(_toolStripCursorsButton);
            _model.ClearState();
            _model.ChangeState(false);
        }

        //更新目前預覽圖狀態
        private void UpdateButtonPage()
        {
            Bitmap bitmap = new Bitmap(doubleBufferedPanel.Width, doubleBufferedPanel.Height);
            doubleBufferedPanel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, doubleBufferedPanel.Width, doubleBufferedPanel.Height));
            _buttonPage1.BackgroundImage = bitmap;
            _buttonPage1.BackgroundImageLayout = ImageLayout.Zoom;
        }

        //鍵盤偵測事件
        private void DeleteKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _model.DeleteBtnClick();
            }
        }
    }
}
