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
        public Form1()
        {
            InitializeComponent();
            _factory = new Factory();
            _model = new Model( _DisplayDataGrid, _ShapeCombobox, _factory);
            _view = new View(_model, _DisplayDataGrid);
        }
        //新增按鈕觸發事件
        private void InsertButtonClick(object sender, EventArgs e)
        {
            _view.AddNewDataGridData();
            
        }
        //DataGrid按鈕觸發處理事件
        private void DisplayDataGridCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) // 请替换 deleteColumnIndex 为“删除”按钮所在的列索引
            {
                _DisplayDataGrid.Rows.RemoveAt(e.RowIndex);
            }
        }
    }    
}
