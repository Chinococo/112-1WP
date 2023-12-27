﻿using PowerPoint.DrawingForm;
using System;
using System.Collections.Generic;
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
        private List<ICommand> _command = new List<ICommand>();

        //Panel _canvas = new DoubleBufferedPanel();
        public Form1()
        {
            InitializeComponent();
            _factory = new Factory();
            _model = new Model(_shapeList, _command);
            _displayDataGrid.DataSource = _shapeList;
            this.KeyPreview = true;
            this.KeyDown += DeleteKeyDown;
            this.Resize += FormResize;
            // 設定 Canvas（畫布）的相關屬性和事件處理程序
            // ...

            //panel3.Dock = DockStyle.Fill;
            _panelMiddle.BorderStyle = BorderStyle.FixedSingle; // Set the border style
            _drawPanel.BackColor = System.Drawing.Color.LightYellow;
            _drawPanel.MouseDown += HandleCanvasPressed;
            _drawPanel.MouseUp += HandleCanvasReleased;
            _drawPanel.MouseMove += HandleCanvasMoved;
            _drawPanel.Paint += HandleCanvasPaint;
            _drawPanel.MouseEnter += DrawingAreaMouseEnter;
            _drawPanel.MouseLeave += DrawingAreaMouseLeave;
            _drawPanel.Anchor = AnchorStyles.None; // Center the control
            //_doubleBufferedPanel.Dock = DockStyle.Left;
            _panelLeft.SizeChanged += Panel1SizeChanged;
            _panelRight.SizeChanged += Panel2SizeChanged;
            _panelMiddle.SizeChanged += Panel3SizeChanged;
            _panelMiddle.Controls.Add(_drawPanel);
            _splitLeft.Width = SPLITER_WIDTH;
            _splitRight.Width = SPLITER_WIDTH;

            //_doubleBufferedPanel.Location = new System.Drawing.Point(
            //    _groupBox2.Location.X + _groupBox2.Width,
            //    _groupBox2.Location.Y
            //);
            //Controls.Add(_doubleBufferedPanel);

            // 初始化呈現模型和模型
            _presentationModel = new PresentationModel.PresentationModel(_model, _shapeList, _command);
            _model._modelChanged += HandleModelChanged;
            UpdateButtonPage();
        }

        // 新增按鈕觸發事件
        private void InsertButtonClick(object sender, EventArgs e)
        {
            _presentationModel.AddNewLine(_shapeComboBox.Text);
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
            if (_drawPanel.Width > 0 && _drawPanel.Height > 0)
            {
                Bitmap bitmap = new Bitmap(_drawPanel.Width, _drawPanel.Height);
                _drawPanel.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, _drawPanel.Width, _drawPanel.Height));
                _buttonPage1.BackgroundImage = bitmap;
                _buttonPage1.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        //鍵盤偵測事件
        private void DeleteKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _presentationModel.DeleteButtonClick();
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
        }

        //Panel更新事件
        private void Panel2SizeChanged(object sender, EventArgs e)
        {
            if (Width - _panelRight.Width - _panelLeft.Width - SPLITER_WIDTH > 0)
                _panelMiddle.Size = new Size(Width - _panelRight.Width - _panelLeft.Width - SPLITER_WIDTH, _panelRight.Height);
            else
                _panelMiddle.Size = new Size(1, _panelRight.Height);
        }

        //Panel更新事件
        private void Panel3SizeChanged(object sender, EventArgs e)
        {
            _panelMiddle.Location = new Point(_panelLeft.Location.X + _panelLeft.Width, _panelLeft.Location.Y);
            int oldHeight = _drawPanel.Height;
            _drawPanel.Width = _panelMiddle.Width - 100;
            int newHeight = (int)(_drawPanel.Width * RATIO);
            _drawPanel.Height = newHeight;
            _drawPanel.Location = new Point(50, (_panelMiddle.Height - newHeight) / 2);
            if (_drawPanel.Size.Height > _panelMiddle.Height - 100)
            {
                _drawPanel.Height = _panelMiddle.Height - 100;
                int newWidth = (int)(_drawPanel.Height * (WIDTH_RATIO / HEIGHT_RATIO));
                _drawPanel.Width = newWidth;
                _drawPanel.Location = new Point((_panelMiddle.Width - newWidth) / 2, 50);
                
            }
            ScaleShape((double)_drawPanel.Height / (double)oldHeight);
            UpdateButtonPage();
            _model.NotifyModelChanged();
        }

        //照著比例放大
        private void ScaleShape(double scale)
        {
            foreach (var shape in _shapeList)
            {
                shape.SetPoint1(shape.GetX1() * scale, shape.GetY1() * scale);
                shape.SetPoint2(shape.GetX2() * scale, shape.GetY2() * scale);
            }
        }

        //Page按鈕點擊事件
        private void ButtonPageClick(object sender, EventArgs e)
        {
        }

        //Undo按鈕點擊事件
        private void UndoButtonClick(object sender, EventArgs e)
        {
            _presentationModel.Undo();
        }

        //Redo按鈕點擊事件
        private void RedoButtonClick(object sender, EventArgs e)
        {
            _presentationModel.Redo();
        }
    }
}