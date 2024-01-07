using Dialog;
using PowerPoint.DrawingForm;
using PowerPoint.Drive;
using PowerPoint.PresentationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        private Model _model;// 模型
        private List<BindingList<Shape>> _shapeList = new List<BindingList<Shape>>();// 形狀列表
        private List<Size> _drawPanelSizeList = new List<Size>();// 形狀列表
        private PresentationModel.PresentationModel _presentationModel;// 呈現模型
        private int activePageIndex = 0;
        private DoubleBufferedPanel _drawPanel = new DoubleBufferedPanel();
        private const string SYMBOL_LINE = "線";
        private const string SYMBOL_RECTANGLE = "矩形";
        private const string SYMBOL_ELLIPSE = "橢圓";
        private bool _zoom = false;
        private const double TOUCH_SIZE = 10;
        private const float WIDTH_RATIO = 16.0f; // 目標的寬高比例
        private const float HEIGHT_RATIO = 9.0f; // 目標的寬高比例
        private const float RATIO = HEIGHT_RATIO / WIDTH_RATIO; // 目標的寬高比例
        private const int SPLITER_WIDTH = 10;
        private ControlManager _controlManger;
        private Button _activeButtonPage;
        private const int MIN_WIDTH = 16;
        private const int MIN_HEIGHT = 9;
        private const int SPLITER_BUFFER = 100;
        private const int TWICE = 2;
        string SAVE_DATA_NAME = "SaveData.csv";
        string LOAD_DATA_NAME = "LoadData.csv";
        public Form1()
        {
            InitializeComponent();
            AddNewButton();
            _controlManger = new ControlManager();
            _model = new Model(_shapeList[activePageIndex], _controlManger);
            _displayDataGrid.DataSource = _shapeList[activePageIndex];
            _activeButtonPage = _groupBox2.Controls.OfType<Button>().ToList()[0];
            _presentationModel = new PresentationModel.PresentationModel(_model, _shapeList[activePageIndex], _controlManger);
            SetInitial();
            UpdateButtonPage();
            UpdatePageInformation();
        }

        //初始化
        private void SetInitial()
        {
            this.KeyPreview = true;
            this.KeyDown += DeleteKeyDown;
            this.Resize += FormResize;
            _panelMiddle.BorderStyle = BorderStyle.FixedSingle;
            _drawPanel.BackColor = System.Drawing.Color.LightYellow;
            _drawPanel.MinimumSize = new Size(MIN_WIDTH, MIN_HEIGHT);
            _drawPanel.MouseDown += HandleCanvasPressed;
            _drawPanel.MouseUp += HandleCanvasReleased;
            _drawPanel.MouseMove += HandleCanvasMoved;
            _drawPanel.Paint += HandleCanvasPaint;
            _drawPanel.MouseEnter += DrawingAreaMouseEnter;
            _drawPanel.MouseLeave += DrawingAreaMouseLeave;
            _drawPanel.Anchor = AnchorStyles.None; // Center the control
            _drawPanelSizeList.Add(_drawPanel.Size);
            _panelLeft.SizeChanged += Panel1SizeChanged;
            _panelRight.SizeChanged += Panel1SizeChanged;
            FitPanel();
            _panelMiddle.Controls.Add(_drawPanel);
            _splitLeft.Width = SPLITER_WIDTH;
            _splitRight.Width = SPLITER_WIDTH;
            _model._modelChanged += HandleModelChanged;
        }

        // 新增按鈕觸發事件
        private void InsertButtonClick(object sender, EventArgs e)
        {
            if (_shapeComboBox.Text == "")
            {
                MessageBox.Show("未選擇形狀");
                return;
            }
            AddModelDialog test = new AddModelDialog(_presentationModel, _shapeComboBox.Text);
            test.Show();
        }

        // DataGrid 按鈕觸發處理事件
        private void DisplayDataGridCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) // 替換 deleteColumnIndex 為“删除”按鈕所在的列索引
            {
                _model.DeleteLineByIndex(e.RowIndex);
            }
        }

        // Canvas 被點擊事件
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _presentationModel.PressedPointer(e.X, e.Y);
        }

        // Canvas 被釋放事件

        public void HandleCanvasReleased(object sender, MouseEventArgs e)
        {
            _presentationModel.ReleasedPointer(e.X, e.Y);
            this.Cursor = Cursors.Default;
            ClearToolStripButtonCheck();
        }

        // Canvas 被移動事件
        public void HandleCanvasMoved(object sender, MouseEventArgs e)
        {
            _presentationModel.MovedPointer(e.X, e.Y);
            if (_model.GetSelectIndex() != -1 && _shapeList[activePageIndex].Count > _model.GetSelectIndex())
            {
                Shape selectedShape = _shapeList[activePageIndex][_model.GetSelectIndex()];
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
            _activeButtonPage.Image = _presentationModel.GetBitmap();
            _activeButtonPage.Refresh();
        }

        // Canvas 更新事件
        public void HandleModelChanged()
        {
            Task.Run(async () =>
            {
                    this.Invoke((MethodInvoker)delegate
                    {
                        //if(_controlManger.IsUndoButtonStatus()!= _toolStripUndoButton.Enabled)
                        //    _toolStripUndoButton.Enabled = _controlManger.IsUndoButtonStatus();
                        //if(_controlManger.IsRedoButtonStatus() != _toolStripRedoButton.Enabled)
                        //    _toolStripRedoButton.Enabled = _controlManger.IsRedoButtonStatus();
                    });
            });
            UpdateButtonPage();
            HandleUndoDeletePage();
            HandleRedoDeletePage();
            HandleUpdateActivePageIndex();
            Invalidate(true);
            UpdateButtonPage();
            HandleAddPage();
            HandleDeletePage();
        }

        // Canvas 更新事件
        private void HandleUndoDeletePage()
        {
            UndoResult undoDeletePage = _model.UndoDeletePage();
            if (undoDeletePage.PageIndex != -1)
            {
                _shapeList.Insert(undoDeletePage.PageIndex, undoDeletePage.PageShape);
                _drawPanelSizeList.Insert(undoDeletePage.PageIndex, undoDeletePage.PageSize);
                AddNewButton();
                activePageIndex = undoDeletePage.PageIndex;
                UpdatePageInformation();
                _model.NotifyModelChanged();
            }
        }

        // Canvas 更新事件
        private void HandleRedoDeletePage()
        {
            UndoResult redoDeletePage = _model.RedoDeletePage();
            if (redoDeletePage.PageIndex != -1)
            {
                _shapeList.RemoveAt(redoDeletePage.PageIndex);
                _drawPanelSizeList.RemoveAt(redoDeletePage.PageIndex);
                _groupBox2.Controls.Remove(_groupBox2.Controls.OfType<Button>().ToList()[0]);
                UpdatePageInformation();
                _model.NotifyModelChanged();
            }
        }

        // Canvas 更新事件
        private void HandleUpdateActivePageIndex()
        {
            int updateActivePageIndex = _model.UpdateActivePageIndex();
            if (updateActivePageIndex != -1)
            {
                Console.WriteLine("切換索引{0}", updateActivePageIndex);
                activePageIndex = updateActivePageIndex;
                UpdatePageInformation();
            }
        }

        // Canvas 更新事件
        private void HandleAddPage()
        {
            if (_model.GetAddPage())
            {
                AddNewButton();
            }
        }

        // Canvas 更新事件
        private void HandleDeletePage()
        {
            if (_model.GetDeletePage())
            {
                var existingButtons = _groupBox2.Controls.OfType<Button>().ToList();
                _groupBox2.Controls.Clear();
                _shapeList.RemoveAt(_shapeList.Count - 1);
                activePageIndex = _shapeList.Count - 1;
                _drawPanelSizeList.RemoveAt(_drawPanelSizeList.Count - 1);
                for (int i = 0; i < existingButtons.Count - 1; i++)
                {
                    _groupBox2.Controls.Add(existingButtons[i]);
                }
            }
        }

        // 按下 toolstrip 按鈕事件
        private void ToolStripEllipseButtonClick(object sender, EventArgs e)
        {
            UpdateToolStripButtonCheck(_toolStripEllipseButton);
            _model.UpdateToolStripButtonCheck(SYMBOL_ELLIPSE);
            _model.ClearState();
            _presentationModel.ChangeState(true);
        }

        // 按下 toolstrip 按鈕事件
        private void ToolStripLineButtonClick(object sender, EventArgs e)
        {
            UpdateToolStripButtonCheck(_toolStripLineButton);
            _model.UpdateToolStripButtonCheck(SYMBOL_LINE);
            _model.ClearState();
            _presentationModel.ChangeState(true);
        }

        // 按下 toolstrip 按鈕事件
        private void ToolStripRectangleButtonClick(object sender, EventArgs e)
        {
            UpdateToolStripButtonCheck(_toolStripRectangleButton);
            _model.UpdateToolStripButtonCheck(SYMBOL_RECTANGLE);
            _model.ClearState();
            _presentationModel.ChangeState(true);
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
            _presentationModel.ChangeState(false);
        }

        //更新目前預覽圖狀態
        private void UpdateButtonPage()
        {
            List<Button> sortedButtons = _groupBox2.Controls
                        .OfType<Button>()
                        .OrderBy(button => button.TabIndex)
                        .ToList();
            for (int i = 0; i < sortedButtons.Count && i < _drawPanelSizeList.Count && i < _shapeList.Count; i++)
            {
                Bitmap bitmap = new Bitmap(_drawPanelSizeList[i].Width, _drawPanelSizeList[i].Height);

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.LightYellow);
                    var windowsFormsGraphicsAdaptor = new WindowsFormsGraphicsAdaptor(graphics);

                    for (int k = 0; k < _shapeList[i].Count; k++)
                    {
                        _shapeList[i][k].Draw(windowsFormsGraphicsAdaptor);
                    }
                }

                Button temp = sortedButtons[i];

                temp.BackgroundImage = bitmap;
                temp.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        //鍵盤偵測事件
        private void DeleteKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (_model.GetSelectIndex() >= 0)
                {
                    _presentationModel.DeleteButtonClick();
                }
                else
                {
                    HandleDeleteKey();
                }
            }
        }

        //鍵盤偵測事件
        private void HandleDeleteKey()
        {
            _controlManger.DeleteCommand(_model, _shapeList[activePageIndex], activePageIndex, _drawPanelSizeList[activePageIndex]);
            _shapeList.RemoveAt(activePageIndex);

            List<Button> sortedButtons = SortButtonsByTabIndex();
            _groupBox2.Controls.Remove(sortedButtons[activePageIndex]);

            ButtonRefresh();

            HandleActivePageIndex(sortedButtons);

            UpdateButtonPage();
            UpdatePageInformation();
        }

        //鍵盤偵測事件
        private List<Button> SortButtonsByTabIndex()
        {
            return _groupBox2.Controls
                .OfType<Button>()
                .OrderBy(button => button.TabIndex)
                .ToList();
        }

        //鍵盤偵測事件
        private void HandleActivePageIndex(List<Button> sortedButtons)
        {
            if (activePageIndex >= _shapeList.Count)
                activePageIndex -= 1;

            sortedButtons = SortButtonsByTabIndex();

            if (activePageIndex < 0)
                activePageIndex = 0;

            if (activePageIndex == _shapeList.Count)
                activePageIndex = _shapeList.Count - 1;
        }


        //更新所以頁面
        private void UpdatePageInformation()
        {
            List<Button> sortedButtons = _groupBox2.Controls
                .OfType<Button>()
                .OrderBy(button => button.TabIndex)
                .ToList();
            if (activePageIndex < 0)
                activePageIndex = 0;
            if (activePageIndex == _shapeList.Count)
                activePageIndex = _shapeList.Count - 1;
            _activeButtonPage = sortedButtons[activePageIndex];
            _model.SetShapeList(_shapeList[activePageIndex]);
            _presentationModel.SetShapeList(_shapeList[activePageIndex]);
            _displayDataGrid.DataSource = _shapeList[activePageIndex];
            _model.NotifyModelChanged();
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

        //清除畫面強制比例
        private void FormResize(object sender, EventArgs e)
        {
            // 視窗大小改變時的處理程式碼
            EnforceAspectRatio();
        }

        //清除畫面強制比例
        private void EnforceAspectRatio()
        {
            float targetAspectRatio = WIDTH_RATIO / HEIGHT_RATIO;// 目標的寬高比例
            float currentAspectRatio = (float)this.Width / this.Height; // 當前的寬高比例

            if (currentAspectRatio != targetAspectRatio)
            {
                // 根據目標寬高比例調整視窗大小
                int newWidth = (int)(this.Height * targetAspectRatio);
                this.Width = newWidth;
            }
            _panelMiddle.Size = new Size(Width - _panelRight.Width - _panelLeft.Width - SPLITER_WIDTH, _panelRight.Height);
        }

        //Panel更新事件
        private void Panel1SizeChanged(object sender, EventArgs e)
        {
            if (Width - _panelRight.Width - _panelLeft.Width - SPLITER_WIDTH > 0)
                _panelMiddle.Size = new Size(Width - _panelRight.Width - _panelLeft.Width - SPLITER_WIDTH, _panelRight.Height);
            else
                _panelMiddle.Size = new Size(1, _panelRight.Height);
            FitPanel();
            UpdateButtonPage();
            _model.NotifyModelChanged();
        }

        //更新大小
        public void FitPanel()
        {
            _panelMiddle.Location = new Point(_panelLeft.Location.X + _panelLeft.Width, _panelLeft.Location.Y);
            _drawPanel.Size = _drawPanelSizeList[activePageIndex];
            int oldHeight = _drawPanel.Height;
            _drawPanel.Width = _panelMiddle.Width - SPLITER_BUFFER;
            int newHeight = (int)(_drawPanel.Width * RATIO);
            _drawPanel.Height = newHeight;
            _drawPanel.Height = newHeight;
            _drawPanel.Location = new Point(SPLITER_BUFFER / TWICE, (_panelMiddle.Height - newHeight) / TWICE);
            if (_drawPanel.Size.Height > _panelMiddle.Height - SPLITER_BUFFER)
            {
                _drawPanel.Height = _panelMiddle.Height - SPLITER_BUFFER;
                int newWidth = (int)(_drawPanel.Height * (WIDTH_RATIO / HEIGHT_RATIO));
                _drawPanel.Width = newWidth;
                _drawPanel.Location = new Point((_panelMiddle.Width - newWidth) / TWICE, SPLITER_BUFFER);
            }
            _drawPanelSizeList[activePageIndex] = _drawPanel.Size;
            ScaleShape((double)_drawPanel.Height / (double)oldHeight, activePageIndex);
        }

        //照著比例放大
        private void ScaleShape(double scale, int index)
        {
            foreach (var shape in _shapeList[index])
            {
                if ((shape.GetX1() * scale) > 0 && (shape.GetY1() * scale) > 0)
                    shape.SetPoint1(shape.GetX1() * scale, shape.GetY1() * scale);
                if ((shape.GetX2() * scale) > 0 && (shape.GetY2() * scale) > 0)
                    shape.SetPoint2(shape.GetX2() * scale, shape.GetY2() * scale);
            }
        }

        //Undo按鈕點擊事件
        private void UndoButtonClick(object sender, EventArgs e)
        {
            _controlManger.UndoExecute().UndoExecute();
            UpdatePageInformation();
            _model.NotifyModelChanged();
        }

        //Redo按鈕點擊事件
        private void RedoButtonClick(object sender, EventArgs e)
        {
            _controlManger.Execute().Execute();
            _model.NotifyModelChanged();
        }

        //新增頁面
        private void toolStripAddPageButton1Click(object sender, EventArgs e)
        {
            AddNewButton();
            _controlManger.PageCommand(_model);
            _controlManger.ChangeSelectIndexCommand(_model, activePageIndex, _shapeList.Count - 1);
            activePageIndex = _shapeList.Count - 1;
            UpdatePageInformation();
            _controlManger.ShowCommand();
        }

        //新增按鈕
        private void AddNewButton()
        {
            Button button = new Button();
            _shapeList.Add(new BindingList<Shape>());
            _drawPanelSizeList.Add(_drawPanel.Size);
            button.TabIndex = _groupBox2.Controls.Count;
            button.Height = 180;
            _drawPanelSizeList.Add(_drawPanel.Size);
            button.BackgroundImage = CreateLightYellowBitmap(_drawPanel.Width, _drawPanel.Height);
            button.BackgroundImageLayout = ImageLayout.Zoom;
            button.Click += PageButtonClick;
            button.Dock = DockStyle.Top;
            var existingButtons = _groupBox2.Controls.OfType<Button>().ToList();
            _groupBox2.Controls.Clear();
            _groupBox2.Controls.Add(button);
            for (int i = 0; i < existingButtons.Count; i++)
                _groupBox2.Controls.Add(existingButtons[i]);
            activePageIndex = _shapeList.Count - 1;
        }

        //更新按鈕狀態
        private void ButtonRefresh()
        {
            List<Button> sortedButtons = _groupBox2.Controls
                .OfType<Button>()
                .OrderBy(button => button.TabIndex)
                .ToList();
            sortedButtons.Reverse();
            _groupBox2.Controls.Clear();
            for (int i = 0; i < sortedButtons.Count; i++)
            {
                sortedButtons[i].TabIndex = sortedButtons.Count - i - 1;
                _groupBox2.Controls.Add(sortedButtons[i]);
            }
        }

        //更新按鈕事件
        private void PageButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                _activeButtonPage = clickedButton;
                if (activePageIndex != clickedButton.TabIndex)
                {
                    _controlManger.ChangeSelectIndexCommand(_model, activePageIndex, clickedButton.TabIndex);
                }
                activePageIndex = clickedButton.TabIndex;
                UpdatePageInformation();
                FitPanel();
                _model.NotifyModelChanged();
            }
        }

        //創建黃色背景
        private Bitmap CreateLightYellowBitmap(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(Brushes.LightYellow, 0, 0, width, height);
            }
            return bitmap;
        }
        //上傳檔案
        private async void toolStripButton2_Click(object sender, EventArgs e)
        {
            _toolStripUploadButton.Enabled = false;
            GoogleDriveService googleDrive = new GoogleDriveService("DrawTest", "clientSecret.json");
            try
            {
                _presentationModel.SaveByFileToCSV(_shapeList, _drawPanelSizeList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Task.Run(async () =>
            {
                try
                {
                    await googleDrive.UploadFile(SAVE_DATA_NAME, "text/csv").ConfigureAwait(false);
                    this.Invoke((MethodInvoker)delegate
                    {
                        Console.WriteLine("上船完成");
                        _toolStripUploadButton.Enabled = true;
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("上傳失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            Console.WriteLine("先去執行其他的");
        }

        //Load圖案
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LoadGoogleDriveData();
            LoadCsvData();
            UpdatePageAndButton();
            FitPanel();
            _model.NotifyModelChanged();
        }

        //Load圖案
        private void LoadGoogleDriveData()
        {
            GoogleDriveService _service = new GoogleDriveService("DrawTest", "clientSecret.json");
            List<Google.Apis.Drive.v2.Data.File> search = _service.ListRootFileAndFolder();
            if (search.Count == 0)
                return;
            _service.DownloadFile(search[0], "./");
        }

        //Load圖案
        private void LoadCsvData()
        {
            List<CsvData> csvDatas = _presentationModel.ReadCsvFile(LOAD_DATA_NAME);
            _shapeList.Clear();
            _drawPanelSizeList.Clear();
            _groupBox2.Controls.Clear();

            for (int i = 0; i < csvDatas.Count; i++)
            {
                while (_shapeList.Count <= csvDatas[i].PanelIndex)
                    AddNewButton();

                _drawPanelSizeList[csvDatas[i].PanelIndex] = new Size(csvDatas[i].DrawWidth, csvDatas[i].DrawHeight);
                _shapeList[csvDatas[i].PanelIndex].Add(new Factory().CreateShape(csvDatas[i].ShapeType, new Point(csvDatas[i].X1, csvDatas[i].Y1), new Point(csvDatas[i].X2, csvDatas[i].Y2)));
            }
        }

        //Load圖案
        private void UpdatePageAndButton()
        {
            activePageIndex = 0;
            UpdatePageInformation();
            UpdateButtonPage();
        }
    }
}