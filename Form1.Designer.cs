﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._displayDataGrid = new System.Windows.Forms.DataGridView();
            this._deleteCloumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeCloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._infoCloumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._insertButton = new System.Windows.Forms.Button();
            this._shapeCombobox = new System.Windows.Forms.ComboBox();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._groupBox2 = new System.Windows.Forms.GroupBox();
            this._buttonPage2 = new System.Windows.Forms.Button();
            this._buttonPage1 = new System.Windows.Forms.Button();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._toolStripCirecleButton = new System.Windows.Forms.ToolStripButton();
            this._toolStripLineButton = new System.Windows.Forms.ToolStripButton();
            this._toolStripRectangleButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this._displayDataGrid)).BeginInit();
            this._groupBox.SuspendLayout();
            this._groupBox2.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _displayDataGrid
            // 
            this._displayDataGrid.AllowUserToAddRows = false;
            this._displayDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._displayDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._deleteCloumn,
            this._shapeCloumn,
            this._infoCloumn});
            this._displayDataGrid.Location = new System.Drawing.Point(0, 102);
            this._displayDataGrid.Margin = new System.Windows.Forms.Padding(4);
            this._displayDataGrid.Name = "_displayDataGrid";
            this._displayDataGrid.ReadOnly = true;
            this._displayDataGrid.RowHeadersWidth = 62;
            this._displayDataGrid.RowTemplate.Height = 24;
            this._displayDataGrid.Size = new System.Drawing.Size(525, 594);
            this._displayDataGrid.TabIndex = 0;
            this._displayDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DisplayDataGridCellContentClick);
            // 
            // _deleteCloumn
            // 
            this._deleteCloumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._deleteCloumn.HeaderText = "刪除";
            this._deleteCloumn.MinimumWidth = 8;
            this._deleteCloumn.Name = "_deleteCloumn";
            this._deleteCloumn.ReadOnly = true;
            this._deleteCloumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._deleteCloumn.Width = 150;
            // 
            // _shapeCloumn
            // 
            this._shapeCloumn.HeaderText = "形狀";
            this._shapeCloumn.MinimumWidth = 8;
            this._shapeCloumn.Name = "_shapeCloumn";
            this._shapeCloumn.ReadOnly = true;
            this._shapeCloumn.Width = 150;
            // 
            // _infoCloumn
            // 
            this._infoCloumn.HeaderText = "資訊";
            this._infoCloumn.MinimumWidth = 8;
            this._infoCloumn.Name = "_infoCloumn";
            this._infoCloumn.ReadOnly = true;
            this._infoCloumn.Width = 150;
            // 
            // _insertButton
            // 
            this._insertButton.Location = new System.Drawing.Point(9, 32);
            this._insertButton.Margin = new System.Windows.Forms.Padding(4);
            this._insertButton.Name = "_insertButton";
            this._insertButton.Size = new System.Drawing.Size(114, 62);
            this._insertButton.TabIndex = 1;
            this._insertButton.Text = "新增";
            this._insertButton.UseVisualStyleBackColor = true;
            this._insertButton.Click += new System.EventHandler(this.InsertButtonClick);
            // 
            // _shapeCombobox
            // 
            this._shapeCombobox.FormattingEnabled = true;
            this._shapeCombobox.Items.AddRange(new object[] {
            "線",
            "矩形"});
            this._shapeCombobox.Location = new System.Drawing.Point(158, 48);
            this._shapeCombobox.Margin = new System.Windows.Forms.Padding(4);
            this._shapeCombobox.Name = "_shapeCombobox";
            this._shapeCombobox.Size = new System.Drawing.Size(132, 26);
            this._shapeCombobox.TabIndex = 2;
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._insertButton);
            this._groupBox.Controls.Add(this._displayDataGrid);
            this._groupBox.Controls.Add(this._shapeCombobox);
            this._groupBox.Location = new System.Drawing.Point(726, 88);
            this._groupBox.Margin = new System.Windows.Forms.Padding(4);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Padding = new System.Windows.Forms.Padding(4);
            this._groupBox.Size = new System.Drawing.Size(526, 780);
            this._groupBox.TabIndex = 3;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "資料顯示";
            // 
            // _groupBox2
            // 
            this._groupBox2.Controls.Add(this._buttonPage2);
            this._groupBox2.Controls.Add(this._buttonPage1);
            this._groupBox2.Location = new System.Drawing.Point(0, 61);
            this._groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this._groupBox2.Name = "_groupBox2";
            this._groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this._groupBox2.Size = new System.Drawing.Size(291, 729);
            this._groupBox2.TabIndex = 4;
            this._groupBox2.TabStop = false;
            this._groupBox2.Text = "投影片選擇";
            //this._groupBox2.Enter += new System.EventHandler(this._groupBox2_Enter);
            // 
            // _buttonPage2
            // 
            this._buttonPage2.Location = new System.Drawing.Point(15, 170);
            this._buttonPage2.Margin = new System.Windows.Forms.Padding(4);
            this._buttonPage2.Name = "_buttonPage2";
            this._buttonPage2.Size = new System.Drawing.Size(266, 110);
            this._buttonPage2.TabIndex = 0;
            this._buttonPage2.Text = "頁面2";
            this._buttonPage2.UseVisualStyleBackColor = true;
            // 
            // _buttonPage1
            // 
            this._buttonPage1.Location = new System.Drawing.Point(9, 32);
            this._buttonPage1.Margin = new System.Windows.Forms.Padding(4);
            this._buttonPage1.Name = "_buttonPage1";
            this._buttonPage1.Size = new System.Drawing.Size(266, 110);
            this._buttonPage1.TabIndex = 0;
            this._buttonPage1.Text = "頁面1";
            this._buttonPage1.UseVisualStyleBackColor = true;
            // 
            // _menuStrip
            // 
            this._menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1252, 31);
            this._menuStrip.TabIndex = 5;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _toolStripMenuItem
            // 
            this._toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._toolStripMenuItem.Name = "_toolStripMenuItem";
            this._toolStripMenuItem.Size = new System.Drawing.Size(62, 27);
            this._toolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripCirecleButton,
            this._toolStripLineButton,
            this._toolStripRectangleButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 31);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1252, 33);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _toolStripCirecleButton
            // 
            this._toolStripCirecleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripCirecleButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripCirecleButton.Image")));
            this._toolStripCirecleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripCirecleButton.Name = "_toolStripCirecleButton";
            this._toolStripCirecleButton.Size = new System.Drawing.Size(34, 28);
            this._toolStripCirecleButton.Text = "_toolStripCirecleButton";
            // 
            // _toolStripLineButton
            // 
            this._toolStripLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripLineButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripLineButton.Image")));
            this._toolStripLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripLineButton.Name = "_toolStripLineButton";
            this._toolStripLineButton.Size = new System.Drawing.Size(34, 28);
            this._toolStripLineButton.Text = "toolStripButton2";
            // 
            // _toolStripRectangleButton
            // 
            this._toolStripRectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._toolStripRectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripRectangleButton.Image")));
            this._toolStripRectangleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripRectangleButton.Name = "_toolStripRectangleButton";
            this._toolStripRectangleButton.Size = new System.Drawing.Size(34, 28);
            this._toolStripRectangleButton.Text = "toolStripButton3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 777);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this._groupBox2);
            this.Controls.Add(this._groupBox);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._displayDataGrid)).EndInit();
            this._groupBox.ResumeLayout(false);
            this._groupBox2.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _displayDataGrid;
        private System.Windows.Forms.Button _insertButton;
        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.GroupBox _groupBox2;
        private System.Windows.Forms.Button _buttonPage2;
        private System.Windows.Forms.Button _buttonPage1;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox _shapeCombobox;
        private System.Windows.Forms.DataGridViewButtonColumn _deleteCloumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _shapeCloumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn _infoCloumn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _toolStripCirecleButton;
        private System.Windows.Forms.ToolStripButton _toolStripLineButton;
        private System.Windows.Forms.ToolStripButton _toolStripRectangleButton;
    }
}

