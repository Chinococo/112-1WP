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
        public MainModel model;
        public Form1()
        {
            InitializeComponent();
            model = new MainModel( DataDisplayGrid, shape_combobox);
        }

        private void Insert_button_Click(object sender, EventArgs e)
        {
            model.AddNewLineDataGrid();
            
        }
    }
    public class View
    {
        public Model model;
        View(Model model)
        {
            this.model = model;
        }
    }

}
