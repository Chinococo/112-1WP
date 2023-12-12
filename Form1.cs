using PowerPoint.DrawingForm;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        private Model _model;// 模型
        private Factory _factory;// 工廠
        private BindingList<Shape> _shapeList = new BindingList<Shape>();// 形狀列表
        private PresentationModel.PresentationModel _presentationModel;// 呈現模型
        private DoubleBufferedPanel _doubleBufferedPanel = new DoubleBufferedPanel();
        private const string SYMBOL_LINE = "線";
        private const string SYMBOL_RECTANGLE = "矩形";
        private const string SYMBOL_ELLIPSE = "橢圓";

        //Panel _canvas = new DoubleBufferedPanel();
        public Form1()
        {
            InitializeComponent();
            _factory = new Factory();
            _model = new Model(_shapeList);
            _displayDataGrid.DataSource = _shapeList;
            this.KeyPreview = true;
            this.KeyDown += DeleteKeyDown;

            // 設定 Canvas（畫布）的相關屬性和事件處理程序
            // ...

            //_panel.Dock = DockStyle.Fill;
            _doubleBufferedPanel.BackColor = System.Drawing.Color.LightYellow;
            _doubleBufferedPanel.MouseDown += HandleCanvasPressed;
            _doubleBufferedPanel.MouseUp += HandleCanvasReleased;
            _doubleBufferedPanel.MouseMove += HandleCanvasMoved;
            _doubleBufferedPanel.Paint += HandleCanvasPaint;
            _doubleBufferedPanel.MouseEnter += DrawingAreaMouseEnter;
            _doubleBufferedPanel.MouseLeave += DrawingAreaMouseLeave;
            _doubleBufferedPanel.Size = new System.Drawing.Size(
                _groupBox.Location.X - (_groupBox2.Location.X + _groupBox2.Width),
                _groupBox.Location.Y + _groupBox.Size.Height - _groupBox2.Location.Y
            );
            _doubleBufferedPanel.Location = new System.Drawing.Point(
                _groupBox2.Location.X + _groupBox2.Width,
                _groupBox2.Location.Y
            );
            Controls.Add(_doubleBufferedPanel);

            // 初始化呈現模型和模型
            _presentationModel = new PresentationModel.PresentationModel(_model);
            _model._modelChanged += HandleModelChanged;
            UpdateButtonPage();
        }

        // 新增按鈕觸發事件
        private void InsertButtonClick(object sender, EventArgs e)
        {
            _model.AddNewLine(_shapeComboBox.Text);
        }

        // DataGrid 按鈕觸發處理事件
        private void DisplayDataGridCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) // 替換 deleteColumnIndex 為“删除”按鈕所在的列索引
            {
                _model.DeleteLineByIndex(e.RowIndex);
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
            this.Cursor = Cursors.Default;
            ClearToolStripButtonCheck();
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
            _buttonPage1.Image = _presentationModel.GetBitmap();
            _buttonPage1.Refresh();
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
            UpdateToolStripButtonCheck(_toolStripEllipseButton);
            _model.UpdateToolStripButtonCheck(SYMBOL_ELLIPSE);
            _model.ClearState();
            _model.ChangeState(true);
        }

        // 按下 toolstrip 按鈕事件
        private void ToolStripLineButtonClick(object sender, EventArgs e)
        {
            UpdateToolStripButtonCheck(_toolStripLineButton);
            _model.UpdateToolStripButtonCheck(SYMBOL_LINE);
            _model.ClearState();
            _model.ChangeState(true);
        }

        // 按下 toolstrip 按鈕事件
        private void ToolStripRectangleButtonClick(object sender, EventArgs e)
        {
            UpdateToolStripButtonCheck(_toolStripRectangleButton);
            _model.UpdateToolStripButtonCheck(SYMBOL_RECTANGLE);
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
            UpdateToolStripButtonCheck(_toolStripCursorsButton);
            _model.ClearState();
            _model.ChangeState(false);
        }

        //更新目前預覽圖狀態
        private void UpdateButtonPage()
        {
            Bitmap bitmap = new Bitmap(_doubleBufferedPanel.Width, _doubleBufferedPanel.Height);
            _doubleBufferedPanel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, _doubleBufferedPanel.Width, _doubleBufferedPanel.Height));
            _buttonPage1.BackgroundImage = bitmap;
            _buttonPage1.BackgroundImageLayout = ImageLayout.Zoom;
        }

        //鍵盤偵測事件
        private void DeleteKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _model.DeleteButtonClick();
            }
        }

        //更新toolstrip選取狀態
        public void UpdateToolStripButtonCheck(ToolStripButton temp)
        {
            ClearToolStripButtonCheck();
            temp.Checked = true;
        }

        //清除toolstrip選取狀態
        public void ClearToolStripButtonCheck()
        {
            _toolStripEllipseButton.Checked = false;
            _toolStripLineButton.Checked = false;
            _toolStripRectangleButton.Checked = false;
            _toolStripCursorsButton.Checked = false;
        }
    }
}