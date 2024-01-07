
namespace Dialog
{
    partial class AddModelDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._informationX1 = new System.Windows.Forms.Label();
            this._informationTextBoxX1 = new System.Windows.Forms.TextBox();
            this._informationY1 = new System.Windows.Forms.Label();
            this._informationTextBoxY1 = new System.Windows.Forms.TextBox();
            this._informationX2 = new System.Windows.Forms.Label();
            this._informationTextBoxX2 = new System.Windows.Forms.TextBox();
            this._informationY2 = new System.Windows.Forms.Label();
            this._informationTextBoxY2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(84, 273);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(88, 47);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(279, 273);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(88, 47);
            this._cancelButton.TabIndex = 0;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // _informationX1
            // 
            this._informationX1.AutoSize = true;
            this._informationX1.Location = new System.Drawing.Point(64, 25);
            this._informationX1.Name = "_informationX1";
            this._informationX1.Size = new System.Drawing.Size(49, 12);
            this._informationX1.TabIndex = 1;
            this._informationX1.Text = "左上角X";
            // 
            // _informationTextBoxX1
            // 
            this._informationTextBoxX1.Location = new System.Drawing.Point(66, 41);
            this._informationTextBoxX1.Name = "_informationTextBoxX1";
            this._informationTextBoxX1.Size = new System.Drawing.Size(100, 22);
            this._informationTextBoxX1.TabIndex = 2;
            // 
            // _informationY1
            // 
            this._informationY1.AutoSize = true;
            this._informationY1.Location = new System.Drawing.Point(256, 25);
            this._informationY1.Name = "_informationY1";
            this._informationY1.Size = new System.Drawing.Size(49, 12);
            this._informationY1.TabIndex = 1;
            this._informationY1.Text = "左上角Y";
            // 
            // _informationTextBoxY1
            // 
            this._informationTextBoxY1.Location = new System.Drawing.Point(258, 41);
            this._informationTextBoxY1.Name = "_informationTextBoxY1";
            this._informationTextBoxY1.Size = new System.Drawing.Size(100, 22);
            this._informationTextBoxY1.TabIndex = 2;
            // 
            // _informationX2
            // 
            this._informationX2.AutoSize = true;
            this._informationX2.Location = new System.Drawing.Point(64, 123);
            this._informationX2.Name = "_informationX2";
            this._informationX2.Size = new System.Drawing.Size(49, 12);
            this._informationX2.TabIndex = 1;
            this._informationX2.Text = "右上角X";
            // 
            // _informationTextBoxX2
            // 
            this._informationTextBoxX2.Location = new System.Drawing.Point(66, 139);
            this._informationTextBoxX2.Name = "_informationTextBoxX2";
            this._informationTextBoxX2.Size = new System.Drawing.Size(100, 22);
            this._informationTextBoxX2.TabIndex = 2;
            // 
            // _informationY2
            // 
            this._informationY2.AutoSize = true;
            this._informationY2.Location = new System.Drawing.Point(256, 123);
            this._informationY2.Name = "_informationY2";
            this._informationY2.Size = new System.Drawing.Size(49, 12);
            this._informationY2.TabIndex = 1;
            this._informationY2.Text = "右上角Y";
            // 
            // _informationTextBoxY2
            // 
            this._informationTextBoxY2.Location = new System.Drawing.Point(258, 139);
            this._informationTextBoxY2.Name = "_informationTextBoxY2";
            this._informationTextBoxY2.Size = new System.Drawing.Size(100, 22);
            this._informationTextBoxY2.TabIndex = 2;
            // 
            // AddModelDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 332);
            this.Controls.Add(this._informationTextBoxY2);
            this.Controls.Add(this._informationTextBoxX2);
            this.Controls.Add(this._informationTextBoxY1);
            this.Controls.Add(this._informationTextBoxX1);
            this.Controls.Add(this._informationY2);
            this.Controls.Add(this._informationX2);
            this.Controls.Add(this._informationY1);
            this.Controls.Add(this._informationX1);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.Name = "AddModelDialog";
            this.Text = "AddModelDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Label _informationX1;
        private System.Windows.Forms.TextBox _informationTextBoxX1;
        private System.Windows.Forms.Label _informationY1;
        private System.Windows.Forms.TextBox _informationTextBoxY1;
        private System.Windows.Forms.Label _informationX2;
        private System.Windows.Forms.TextBox _informationTextBoxX2;
        private System.Windows.Forms.Label _informationY2;
        private System.Windows.Forms.TextBox _informationTextBoxY2;
    }
}