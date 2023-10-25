﻿using HW2.DrawingForm;
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
        private List<Shape> _shapeList=new List<Shape>();
        PresentationModel.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        public Form1()
        {
            InitializeComponent();
            _factory = new Factory();
            _model = new Model( _displayDataGrid, _shapeCombobox, _factory, _shapeList,_toolStripEllipseButton,_toolStripLineButton,_toolStripRectangleButton);
            _view = new View(_model, _displayDataGrid, _shapeList);
            // prepare canvas
            //
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            _canvas.MouseEnter += drawingArea_MouseEnter;
            _canvas.MouseLeave += drawingArea_MouseLeave;

            Controls.Add(_canvas);
            //
            // prepare presentation model and model
            //
            _presentationModel = new PresentationModel.PresentationModel(_model,_canvas);
            _model._modelChanged += HandleModelChanged;
        }
        //新增按鈕觸發事件
        private void InsertButtonClick(object sender, EventArgs e)
        {
            _model.AddNewLine();
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
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Clear();
        }
        public void HandleCanvasPressed(object sender,System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerPressed(e.X, e.Y);
        }
        public void HandleCanvasReleased(object sender,
System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerReleased(e.X, e.Y);
        }
        public void HandleCanvasMoved(object sender,
       System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerMoved(e.X, e.Y);
        }
        public void HandleCanvasPaint(object sender,
       System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        private void _toolStripCirecleButton_Click(object sender, EventArgs e)
        {
            _model.UpdateToolStripButtonCheck(_toolStripEllipseButton);
        }

        private void _toolStripLineButton_Click(object sender, EventArgs e)
        {
            _model.UpdateToolStripButtonCheck(_toolStripLineButton);
        }

        private void _toolStripRectangleButton_Click(object sender, EventArgs e)
        {
            _model.UpdateToolStripButtonCheck(_toolStripRectangleButton);
        }
        private void drawingArea_MouseEnter(object sender, EventArgs e)
        {
            // 鼠标进入绘图区域时，设置鼠标光标为十字形
            this.Cursor = Cursors.Cross;
        }

        private void drawingArea_MouseLeave(object sender, EventArgs e)
        {
            // 鼠标离开绘图区域时，恢复默认光标
            this.Cursor = Cursors.Default;
        }

       
    }    
}
