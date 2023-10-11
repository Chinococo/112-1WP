
namespace HW2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._DisplayDataGrid = new System.Windows.Forms.DataGridView();
            this.刪除 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.形狀 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.資訊 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._InsertButton = new System.Windows.Forms.Button();
            this._ShapeCombobox = new System.Windows.Forms.ComboBox();
            this._GroupBox = new System.Windows.Forms.GroupBox();
            this._GroupBox2 = new System.Windows.Forms.GroupBox();
            this._ButtonPage2 = new System.Windows.Forms.Button();
            this._ButtonPage1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._DisplayDataGrid)).BeginInit();
            this._GroupBox.SuspendLayout();
            this._GroupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _DisplayDataGrid
            // 
            this._DisplayDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._DisplayDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.刪除,
            this.形狀,
            this.資訊});
            this._DisplayDataGrid.Location = new System.Drawing.Point(9, 102);
            this._DisplayDataGrid.Margin = new System.Windows.Forms.Padding(4);
            this._DisplayDataGrid.Name = "_DisplayDataGrid";
            this._DisplayDataGrid.RowHeadersWidth = 62;
            this._DisplayDataGrid.RowTemplate.Height = 24;
            this._DisplayDataGrid.Size = new System.Drawing.Size(525, 594);
            this._DisplayDataGrid.TabIndex = 0;
            this._DisplayDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DisplayDataGridCellContentClick);
            // 
            // 刪除
            // 
            this.刪除.HeaderText = "刪除";
            this.刪除.MinimumWidth = 8;
            this.刪除.Name = "刪除";
            this.刪除.Width = 150;
            // 
            // 形狀
            // 
            this.形狀.HeaderText = "形狀";
            this.形狀.MinimumWidth = 8;
            this.形狀.Name = "形狀";
            this.形狀.Width = 150;
            // 
            // 資訊
            // 
            this.資訊.HeaderText = "資訊";
            this.資訊.MinimumWidth = 8;
            this.資訊.Name = "資訊";
            this.資訊.Width = 150;
            // 
            // _InsertButton
            // 
            this._InsertButton.Location = new System.Drawing.Point(9, 32);
            this._InsertButton.Margin = new System.Windows.Forms.Padding(4);
            this._InsertButton.Name = "_InsertButton";
            this._InsertButton.Size = new System.Drawing.Size(114, 62);
            this._InsertButton.TabIndex = 1;
            this._InsertButton.Text = "新增";
            this._InsertButton.UseVisualStyleBackColor = true;
            this._InsertButton.Click += new System.EventHandler(this.InsertButtonClick);
            // 
            // _ShapeCombobox
            // 
            this._ShapeCombobox.FormattingEnabled = true;
            this._ShapeCombobox.Items.AddRange(new object[] {
            "線",
            "矩形"});
            this._ShapeCombobox.Location = new System.Drawing.Point(158, 48);
            this._ShapeCombobox.Margin = new System.Windows.Forms.Padding(4);
            this._ShapeCombobox.Name = "_ShapeCombobox";
            this._ShapeCombobox.Size = new System.Drawing.Size(132, 26);
            this._ShapeCombobox.TabIndex = 2;
            // 
            // _GroupBox
            // 
            this._GroupBox.Controls.Add(this._InsertButton);
            this._GroupBox.Controls.Add(this._DisplayDataGrid);
            this._GroupBox.Controls.Add(this._ShapeCombobox);
            this._GroupBox.Location = new System.Drawing.Point(726, 3);
            this._GroupBox.Margin = new System.Windows.Forms.Padding(4);
            this._GroupBox.Name = "_GroupBox";
            this._GroupBox.Padding = new System.Windows.Forms.Padding(4);
            this._GroupBox.Size = new System.Drawing.Size(526, 780);
            this._GroupBox.TabIndex = 3;
            this._GroupBox.TabStop = false;
            this._GroupBox.Text = "資料顯示";
            // 
            // _GroupBox2
            // 
            this._GroupBox2.Controls.Add(this._ButtonPage2);
            this._GroupBox2.Controls.Add(this._ButtonPage1);
            this._GroupBox2.Location = new System.Drawing.Point(0, 51);
            this._GroupBox2.Margin = new System.Windows.Forms.Padding(4);
            this._GroupBox2.Name = "_GroupBox2";
            this._GroupBox2.Padding = new System.Windows.Forms.Padding(4);
            this._GroupBox2.Size = new System.Drawing.Size(291, 729);
            this._GroupBox2.TabIndex = 4;
            this._GroupBox2.TabStop = false;
            this._GroupBox2.Text = "投影片選擇";
            // 
            // _ButtonPage2
            // 
            this._ButtonPage2.Location = new System.Drawing.Point(15, 170);
            this._ButtonPage2.Margin = new System.Windows.Forms.Padding(4);
            this._ButtonPage2.Name = "_ButtonPage2";
            this._ButtonPage2.Size = new System.Drawing.Size(266, 110);
            this._ButtonPage2.TabIndex = 0;
            this._ButtonPage2.Text = "頁面2";
            this._ButtonPage2.UseVisualStyleBackColor = true;
            // 
            // _ButtonPage1
            // 
            this._ButtonPage1.Location = new System.Drawing.Point(9, 32);
            this._ButtonPage1.Margin = new System.Windows.Forms.Padding(4);
            this._ButtonPage1.Name = "_ButtonPage1";
            this._ButtonPage1.Size = new System.Drawing.Size(266, 110);
            this._ButtonPage1.TabIndex = 0;
            this._ButtonPage1.Text = "頁面1";
            this._ButtonPage1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1252, 31);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _ToolStripMenuItem
            // 
            this._ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this._ToolStripMenuItem.Name = "_ToolStripMenuItem";
            this._ToolStripMenuItem.Size = new System.Drawing.Size(62, 27);
            this._ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 777);
            this.Controls.Add(this._GroupBox2);
            this.Controls.Add(this._GroupBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._DisplayDataGrid)).EndInit();
            this._GroupBox.ResumeLayout(false);
            this._GroupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _DisplayDataGrid;
        private System.Windows.Forms.Button _InsertButton;
        private System.Windows.Forms.GroupBox _GroupBox;
        private System.Windows.Forms.GroupBox _GroupBox2;
        private System.Windows.Forms.Button _ButtonPage2;
        private System.Windows.Forms.Button _ButtonPage1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewButtonColumn 刪除;
        private System.Windows.Forms.DataGridViewTextBoxColumn 形狀;
        private System.Windows.Forms.DataGridViewTextBoxColumn 資訊;
        private System.Windows.Forms.ComboBox _ShapeCombobox;
    }
}

