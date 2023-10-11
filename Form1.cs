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
        public Model model;
        public View view;
        public Factory factory;
        public Form1()
        {
            InitializeComponent();
            factory = new Factory();
            model = new Model( DataDisplayGrid, shape_combobox,factory);
            view = new View(model,DataDisplayGrid);
        }

        private void Insert_button_Click(object sender, EventArgs e)
        {
            view.AddNewDataGridData();
            
        }

        private void DataDisplayGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) // 请替换 deleteColumnIndex 为“删除”按钮所在的列索引
            {
                DataDisplayGrid.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
    public class View
    {
        public Model model;
        public DataGridView DataDisplayGrid;
        public View(Model model, DataGridView DataDisplayGrid )
        {
            this.model = model;
            this.DataDisplayGrid = DataDisplayGrid;
        }
        public void AddNewDataGridData()
        {
            DataDisplayGrid.Rows.Add(model.AddNewLineDataGrid());
        }
    }

}
