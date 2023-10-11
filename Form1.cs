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
        public Form1()
        {
            InitializeComponent();
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
    public class Model
    {
        public Model model;
        Model(Model model)
        {
            this.model = model;
        }
    }
}
