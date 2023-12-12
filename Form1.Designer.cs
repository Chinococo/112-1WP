
namespace PowerPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._displayDataGrid = new System.Windows.Forms.DataGridView();
            this._deleteColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._infoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._insertButton = new System.Windows.Forms.Button();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._groupBox2 = new System.Windows.Forms.GroupBox();
            this._buttonPage1 = new System.Windows.Forms.Button();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._toolStripEllipseButton = new System.Windows.Forms.ToolStripButton();
            this._toolStripLineButton = new System.Windows.Forms.ToolStripButton();
            this._toolStripRectangleButton = new System.Windows.Forms.ToolStripButton();
            this._toolStripCursorsButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._displayDataGrid)).BeginInit();
            this._groupBox.SuspendLayout();
            this._groupBox2.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this._toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _displayDataGrid
            // 
            this._displayDataGrid.AllowUserToAddRows = false;
            this._displayDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._displayDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._displayDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteColumn,
            this._shapeColumn,
            this._infoColumn});
            this._displayDataGrid.Location = new System.Drawing.Point(6, 68);
            this._displayDataGrid.Name = "_displayDataGrid";
            this._displayDataGrid.ReadOnly = true;
            this._displayDataGrid.RowHeadersVisible = false;
            this._displayDataGrid.RowHeadersWidth = 62;
            this._displayDataGrid.RowTemplate.Height = 24;
            this._displayDataGrid.Size = new System.Drawing.Size(344, 379);
            this._displayDataGrid.TabIndex = 0;
            this._displayDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DisplayDataGridCellContentClick);
            // 
            // _deleteCloumn
            // 
            this._deleteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._deleteColumn.DataPropertyName = "delete";
            this._deleteColumn.HeaderText = "刪除";
            this._deleteColumn.MinimumWidth = 8;
            this._deleteColumn.Name = "_deleteCloumn";
            this._deleteColumn.ReadOnly = true;
            this._deleteColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // _shapeCloumn
            // 
            this._shapeColumn.DataPropertyName = "shape";
            this._shapeColumn.HeaderText = "形狀";
            this._shapeColumn.MinimumWidth = 8;
            this._shapeColumn.Name = "_shapeCloumn";
            this._shapeColumn.ReadOnly = true;
            this._shapeColumn.Width = 40;
            // 
            // _infoCloumn
            // 
            this._infoColumn.DataPropertyName = "information";
            this._infoColumn.HeaderText = "資訊";
            this._infoColumn.MinimumWidth = 8;
            this._infoColumn.Name = "_infoCloumn";
            this._infoColumn.ReadOnly = true;
            this._infoColumn.Width = 150;
            // 
            // _insertButton
            // 
            this._insertButton.Location = new System.Drawing.Point(6, 21);
            this._insertButton.Name = "_insertButton";
            this._insertButton.Size = new System.Drawing.Size(76, 41);
            this._insertButton.TabIndex = 1;
            this._insertButton.Text = "新增";
            this._insertButton.UseVisualStyleBackColor = true;
            this._insertButton.Click += new System.EventHandler(this.InsertButtonClick);
            // 
            // _shapeCombobox
            // 
            this._shapeComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "橢圓",
            "線",
            "矩形"});
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Items.AddRange(new object[] {
            "線",
            "矩形",
            "橢圓"});
            this._shapeComboBox.Location = new System.Drawing.Point(105, 32);
            this._shapeComboBox.Name = "_shapeCombobox";
            this._shapeComboBox.Size = new System.Drawing.Size(89, 20);
            this._shapeComboBox.TabIndex = 2;
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._insertButton);
            this._groupBox.Controls.Add(this._displayDataGrid);
            this._groupBox.Controls.Add(this._shapeComboBox);
            this._groupBox.Location = new System.Drawing.Point(484, 59);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(351, 447);
            this._groupBox.TabIndex = 3;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "資料顯示";
            // 
            // _groupBox2
            // 
            this._groupBox2.Controls.Add(this._buttonPage1);
            this._groupBox2.Location = new System.Drawing.Point(0, 62);
            this._groupBox2.Name = "_groupBox2";
            this._groupBox2.Size = new System.Drawing.Size(116, 461);
            this._groupBox2.TabIndex = 4;
            this._groupBox2.TabStop = false;
            this._groupBox2.Text = "投影片選擇";
            // 
            // _buttonPage1
            // 
            this._buttonPage1.Location = new System.Drawing.Point(6, 21);
            this._buttonPage1.Name = "_buttonPage1";
            this._buttonPage1.Size = new System.Drawing.Size(99, 73);
            this._buttonPage1.TabIndex = 0;
            this._buttonPage1.UseVisualStyleBackColor = true;
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this._menuStrip.Size = new System.Drawing.Size(835, 24);
            this._menuStrip.TabIndex = 5;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _toolStripMenuItem
            // 
            this._toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._toolStripMenuItem.Name = "_toolStripMenuItem";
            this._toolStripMenuItem.Size = new System.Drawing.Size(43, 22);
            this._toolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _toolStrip1
            // 
            this._toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripEllipseButton,
            this._toolStripLineButton,
            this._toolStripRectangleButton,
            this._toolStripCursorsButton});
            this._toolStrip1.Location = new System.Drawing.Point(0, 24);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(835, 31);
            this._toolStrip1.TabIndex = 6;
            this._toolStrip1.Text = "toolStrip1";
            // 
            // _toolStripEllipseButton
            // 
            this._toolStripEllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripEllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripEllipseButton.Image")));
            this._toolStripEllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripEllipseButton.Name = "_toolStripEllipseButton";
            this._toolStripEllipseButton.Size = new System.Drawing.Size(28, 28);
            this._toolStripEllipseButton.Text = "_toolStripCirecleButton";
            this._toolStripEllipseButton.Click += new System.EventHandler(this.ToolStripEllipseButtonClick);
            // 
            // _toolStripLineButton
            // 
            this._toolStripLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripLineButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripLineButton.Image")));
            this._toolStripLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripLineButton.Name = "_toolStripLineButton";
            this._toolStripLineButton.Size = new System.Drawing.Size(28, 28);
            this._toolStripLineButton.Text = "toolStripButton2";
            this._toolStripLineButton.Click += new System.EventHandler(this.ToolStripLineButtonClick);
            // 
            // _toolStripRectangleButton
            // 
            this._toolStripRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripRectangleButton.Image")));
            this._toolStripRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripRectangleButton.Name = "_toolStripRectangleButton";
            this._toolStripRectangleButton.Size = new System.Drawing.Size(28, 28);
            this._toolStripRectangleButton.Text = "toolStripButton3";
            this._toolStripRectangleButton.Click += new System.EventHandler(this.ToolStripRectangleButtonClick);
            // 
            // _toolStripCursorsButton
            // 
            this._toolStripCursorsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripCursorsButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripCursorsButton.Image")));
            this._toolStripCursorsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripCursorsButton.Name = "_toolStripCursorsButton";
            this._toolStripCursorsButton.Size = new System.Drawing.Size(28, 28);
            this._toolStripCursorsButton.Text = "toolStripButton1";
            this._toolStripCursorsButton.Click += new System.EventHandler(this.ToolStripCursorsButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 518);
            this.Controls.Add(this._toolStrip1);
            this.Controls.Add(this._groupBox2);
            this.Controls.Add(this._groupBox);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._displayDataGrid)).EndInit();
            this._groupBox.ResumeLayout(false);
            this._groupBox2.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._toolStrip1.ResumeLayout(false);
            this._toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _displayDataGrid;
        private System.Windows.Forms.Button _insertButton;
        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.GroupBox _groupBox2;
        private System.Windows.Forms.Button _buttonPage1;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox _shapeComboBox;
        private System.Windows.Forms.ToolStrip _toolStrip1;
        private System.Windows.Forms.ToolStripButton _toolStripEllipseButton;
        private System.Windows.Forms.ToolStripButton _toolStripLineButton;
        private System.Windows.Forms.ToolStripButton _toolStripRectangleButton;
        private System.Windows.Forms.ToolStripButton _toolStripCursorsButton;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _infoColumn;
    }
}

