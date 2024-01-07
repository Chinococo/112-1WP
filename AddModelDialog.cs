using PowerPoint.PresentationModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dialog
{
    public partial class AddModelDialog : Form
    {
        private PresentationModel _presentationModel;
        private string _shape;
        private const string FORM_NAME = "Main Form";
        private const int WIDTH = 400;
        private const int HEIGHT = 300;
        private const string ERROR_TITLE = "Invalid input. Please enter valid integers for X1, Y1, X2, and Y2.";
        private const string ERROR_MESSAGE = "Error";
        public AddModelDialog(PresentationModel presentationModel, string shape)
        {
            this.Text = FORM_NAME;
            this.Size = new System.Drawing.Size(WIDTH, HEIGHT);
            this._presentationModel = presentationModel;
            this._shape = shape;
            InitializeComponent();
        }

        //確認按鈕按下
        private void AddButtonClick(object sender, EventArgs e)
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
                MessageBox.Show(ERROR_TITLE,ERROR_MESSAGE , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //取消按鈕按下
        private void CancelButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}