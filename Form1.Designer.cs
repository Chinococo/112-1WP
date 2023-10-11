
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
            this.DataDisplayGrid = new System.Windows.Forms.DataGridView();
            this.insert_button = new System.Windows.Forms.Button();
            this.shape_combobox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_page2 = new System.Windows.Forms.Button();
            this.button_page1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataDisplayGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataDisplayGrid
            // 
            this.DataDisplayGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataDisplayGrid.Location = new System.Drawing.Point(8, 68);
            this.DataDisplayGrid.Name = "DataDisplayGrid";
            this.DataDisplayGrid.RowTemplate.Height = 24;
            this.DataDisplayGrid.Size = new System.Drawing.Size(186, 396);
            this.DataDisplayGrid.TabIndex = 0;
            // 
            // insert_button
            // 
            this.insert_button.Location = new System.Drawing.Point(6, 21);
            this.insert_button.Name = "insert_button";
            this.insert_button.Size = new System.Drawing.Size(76, 41);
            this.insert_button.TabIndex = 1;
            this.insert_button.Text = "新增";
            this.insert_button.UseVisualStyleBackColor = true;
            // 
            // shape_combobox
            // 
            this.shape_combobox.FormattingEnabled = true;
            this.shape_combobox.Location = new System.Drawing.Point(105, 32);
            this.shape_combobox.Name = "shape_combobox";
            this.shape_combobox.Size = new System.Drawing.Size(89, 20);
            this.shape_combobox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.insert_button);
            this.groupBox1.Controls.Add(this.DataDisplayGrid);
            this.groupBox1.Controls.Add(this.shape_combobox);
            this.groupBox1.Location = new System.Drawing.Point(612, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 520);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料顯示";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_page2);
            this.groupBox2.Controls.Add(this.button_page1);
            this.groupBox2.Location = new System.Drawing.Point(0, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 486);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "投影片選擇";
            // 
            // button_page2
            // 
            this.button_page2.Location = new System.Drawing.Point(10, 113);
            this.button_page2.Name = "button_page2";
            this.button_page2.Size = new System.Drawing.Size(177, 73);
            this.button_page2.TabIndex = 0;
            this.button_page2.Text = "頁面2";
            this.button_page2.UseVisualStyleBackColor = true;
            // 
            // button_page1
            // 
            this.button_page1.Location = new System.Drawing.Point(6, 21);
            this.button_page1.Name = "button_page1";
            this.button_page1.Size = new System.Drawing.Size(177, 73);
            this.button_page1.TabIndex = 0;
            this.button_page1.Text = "頁面1";
            this.button_page1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(835, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 518);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DataDisplayGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataDisplayGrid;
        private System.Windows.Forms.Button insert_button;
        private System.Windows.Forms.ComboBox shape_combobox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_page2;
        private System.Windows.Forms.Button button_page1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
    }
}

