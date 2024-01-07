using PowerPoint.PresentationModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HW2
{
    public partial class AddModelDialog : Form
    {
        private PresentationModel _presentationModel;
        private string _shape;

        public AddModelDialog(PresentationModel presentationModel, string shape)
        {
            this.Text = "Main Form";
            this.Size = new System.Drawing.Size(400, 300);
            this._presentationModel = presentationModel;
            this._shape = shape;
            InitializeComponent();
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            try
            {
                int x1 = Convert.ToInt32(_informationTextBoxX1.Text);
                int y1 = Convert.ToInt32(_informationTextBoxY1.Text);
                int x2 = Convert.ToInt32(_informationTextBoxX2.Text);
                int y2 = Convert.ToInt32(_informationTextBoxY2.Text);

                Point leftTop = new Point(x1, y1);
                Point rightBottom = new Point(x2, y2);

                _presentationModel.AddNewLine(_shape, leftTop, rightBottom);
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid integers for X1, Y1, X2, and Y2.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}