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
        private bool _zoom = false;
        private int _size_update = 0;
        private const double TOUCH_SIZE = 10;
        //Panel _canvas = new DoubleBufferedPanel();
        public Form1()
        {
            InitializeComponent();
            _factory = new Factory();
            _model = new Model(_shapeList);
            _displayDataGrid.DataSource = _shapeList;
            this.KeyPreview = true;
            this.KeyDown += DeleteKeyDown;
            this.Load += FormLoad;
            this.Resize += FormResize;
            // 設定 Canvas（畫布）的相關屬性和事件處理程序
            // ...

            //panel3.Dock = DockStyle.Fill;
            panel3.BorderStyle = BorderStyle.FixedSingle; // Set the border style
            _doubleBufferedPanel.BackColor = System.Drawing.Color.LightYellow;
            _doubleBufferedPanel.MouseDown += HandleCanvasPressed;
            _doubleBufferedPanel.MouseUp += HandleCanvasReleased;
            _doubleBufferedPanel.MouseMove += HandleCanvasMoved;
            _doubleBufferedPanel.Paint += HandleCanvasPaint;
            _doubleBufferedPanel.MouseEnter += DrawingAreaMouseEnter;
            _doubleBufferedPanel.MouseLeave += DrawingAreaMouseLeave;
            _doubleBufferedPanel.Anchor = AnchorStyles.None; // Center the control
            //_doubleBufferedPanel.Dock = DockStyle.Left;
            panel1.SizeChanged += Panel1_SizeChanged;
            panel2.SizeChanged += Panel2_SizeChanged;
            panel3.SizeChanged += Panel3_SizeChanged;
            panel3.Controls.Add(_doubleBufferedPanel);
            Console.WriteLine($"Init Panel 3 Size Changed: Width = {panel3.Width}, Height = {panel3.Height}");
            splitter1.Width = 10;
            splitter2.Width = 10;

            //_doubleBufferedPanel.Location = new System.Drawing.Point(
            //    _groupBox2.Location.X + _groupBox2.Width,
            //    _groupBox2.Location.Y
            //);
            //Controls.Add(_doubleBufferedPanel);

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
        
        public void HandleCanvasReleased(object sender , MouseEventArgs e)
        {
            _model.ReleasedPointer(e.X, e.Y);
            this.Cursor = Cursors.Default;
            ClearToolStripButtonCheck();
        }

        // Canvas 被移動事件
        public void HandleCanvasMoved(object sender , MouseEventArgs e)
        {
            _model.MovedPointer(e.X, e.Y);
            if (_model.GetSelectIndex() != -1 && _shapeList.Count > _model.GetSelectIndex())
            {
                Shape selectedShape = _shapeList[_model.GetSelectIndex()];
                bool isMouseInGrip = e.X >= selectedShape.GetX2() - TOUCH_SIZE && e.Y >= selectedShape.GetY2() - TOUCH_SIZE;
                if (isMouseInGrip)
                {
                    this.Cursor = Cursors.SizeNWSE;
                    _zoom = true;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    _zoom = false;
                }
                _model.SetZoom(_zoom);
            }
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
        private void FormLoad(object sender, EventArgs e)
        {

        }

        private void FormResize(object sender, EventArgs e)
        {
            // 視窗大小改變時的處理程式碼
            EnforceAspectRatio();
        }

        private void EnforceAspectRatio()
        {
            float targetAspectRatio = 16.0f / 9.0f; // 目標的寬高比例
            float currentAspectRatio = (float)this.Width / this.Height; // 當前的寬高比例

            if (currentAspectRatio != targetAspectRatio)
            {
                // 根據目標寬高比例調整視窗大小
                int newWidth = (int)(this.Height * targetAspectRatio);
                this.Width = newWidth;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            // Perform actions or update something when the panel size changes
            // For example, you can display the new size in the console
            Console.WriteLine($"Panel 1 Size Changed: Width = {panel1.Width}, Height = {panel1.Height}");
            _size_update += 1;
            int t = Width - panel2.Width - panel1.Width;
            panel3.Size = new Size(Width - panel2.Width - panel1.Width-10, panel2.Height);
        }
        private void Panel2_SizeChanged(object sender, EventArgs e)
        {
            // Perform actions or update something when the panel size changes
            // For example, you can display the new size in the console
            Console.WriteLine($"Panel 2 Size Changed: Width = {panel2.Width}, Height = {panel2.Height}");
            _size_update += 1;
            int t = Width - panel2.Width - panel1.Width;
             Console.WriteLine($"Panel 3 Size Changed: Width = {panel3.Width}, Height = {panel3.Height}");
            panel3.Size = new Size(Width - panel2.Width - panel1.Width - 10, panel2.Height);
        }
        private void Panel3_SizeChanged(object sender, EventArgs e)
        {
            // Perform actions or update something when the panel size changes
            // For example, you can display the new size in the console
            panel3.Location = new Point(panel1.Location.X+ panel1.Width, panel1.Location.Y);
            _doubleBufferedPanel.Width = panel3.Width-100;
           
            float targetAspectRatio = 9.0f / 16.0f; // 目標的寬高比例
            int newHeight = (int)(_doubleBufferedPanel.Width * targetAspectRatio);
            _doubleBufferedPanel.Height = newHeight;
            _doubleBufferedPanel.Location = new Point(50,(panel3.Height- newHeight)/2);
            panel3.Controls.Add(_doubleBufferedPanel);
            Console.WriteLine($"_doubleBufferedPanel Location Changed: x = {_doubleBufferedPanel.Location.X}, y = {_doubleBufferedPanel.Location.Y}");
            Console.WriteLine($"_doubleBufferedPanel Size Changed: Width = {_doubleBufferedPanel.Width}, Height = {_doubleBufferedPanel.Height}");
            Console.WriteLine($"Panel 3 Size Changed: Width = {panel3.Width}, Height = {panel3.Height}");
        }

        private void _buttonPage1_Click(object sender, EventArgs e)
        {

        }
    }
}