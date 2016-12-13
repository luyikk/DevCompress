namespace DevCompressWin
{
    partial class WinMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinMain));
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.导入文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.导出文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部导出到文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关联文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.导入文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入文件ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.编译ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出文件ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.全部导出到文件夹ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(1, 28);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(927, 569);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem1,
            this.关联文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(929, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.新建ToolStripMenuItem1,
            this.导入文件ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.新建ToolStripMenuItem.Text = "建立";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.打开ToolStripMenuItem.Text = "新建";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // 新建ToolStripMenuItem1
            // 
            this.新建ToolStripMenuItem1.Name = "新建ToolStripMenuItem1";
            this.新建ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.新建ToolStripMenuItem1.Text = "导入文件夹";
            this.新建ToolStripMenuItem1.Click += new System.EventHandler(this.新建ToolStripMenuItem1_Click);
            // 
            // 导入文件ToolStripMenuItem
            // 
            this.导入文件ToolStripMenuItem.Name = "导入文件ToolStripMenuItem";
            this.导入文件ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.导入文件ToolStripMenuItem.Text = "导入文件";
            this.导入文件ToolStripMenuItem.Click += new System.EventHandler(this.导入文件ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.保存ToolStripMenuItem.Text = "编译";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem1
            // 
            this.打开ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem2,
            this.导出文件ToolStripMenuItem,
            this.全部导出到文件夹ToolStripMenuItem});
            this.打开ToolStripMenuItem1.Name = "打开ToolStripMenuItem1";
            this.打开ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.打开ToolStripMenuItem1.Text = "读取";
            // 
            // 打开ToolStripMenuItem2
            // 
            this.打开ToolStripMenuItem2.Name = "打开ToolStripMenuItem2";
            this.打开ToolStripMenuItem2.Size = new System.Drawing.Size(172, 22);
            this.打开ToolStripMenuItem2.Text = "打开";
            this.打开ToolStripMenuItem2.Click += new System.EventHandler(this.打开ToolStripMenuItem2_Click);
            // 
            // 导出文件ToolStripMenuItem
            // 
            this.导出文件ToolStripMenuItem.Name = "导出文件ToolStripMenuItem";
            this.导出文件ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.导出文件ToolStripMenuItem.Text = "导出文件";
            this.导出文件ToolStripMenuItem.Click += new System.EventHandler(this.导出文件ToolStripMenuItem_Click);
            // 
            // 全部导出到文件夹ToolStripMenuItem
            // 
            this.全部导出到文件夹ToolStripMenuItem.Name = "全部导出到文件夹ToolStripMenuItem";
            this.全部导出到文件夹ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.全部导出到文件夹ToolStripMenuItem.Text = "全部导出到文件夹";
            this.全部导出到文件夹ToolStripMenuItem.Click += new System.EventHandler(this.全部导出到文件夹ToolStripMenuItem_Click);
            // 
            // 关联文件ToolStripMenuItem
            // 
            this.关联文件ToolStripMenuItem.Name = "关联文件ToolStripMenuItem";
            this.关联文件ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.关联文件ToolStripMenuItem.Text = "关联文件";
            this.关联文件ToolStripMenuItem.Click += new System.EventHandler(this.关联文件ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.*|*.*";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(1, 603);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(465, 13);
            this.progressBar1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 604);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 3;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.DefaultExt = "det";
            this.openFileDialog2.Filter = "*.dev|*.dev|*.*|*.*";
           
            // 
            // 删除ToolStripMenuItem1
            // 
            this.删除ToolStripMenuItem1.Name = "删除ToolStripMenuItem1";
            this.删除ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.删除ToolStripMenuItem1.Text = "删除";
            this.删除ToolStripMenuItem1.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 导入文件夹ToolStripMenuItem
            // 
            this.导入文件夹ToolStripMenuItem.Name = "导入文件夹ToolStripMenuItem";
            this.导入文件夹ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.导入文件夹ToolStripMenuItem.Text = "导入文件夹";
            this.导入文件夹ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem1_Click);
            // 
            // 导入文件ToolStripMenuItem1
            // 
            this.导入文件ToolStripMenuItem1.Name = "导入文件ToolStripMenuItem1";
            this.导入文件ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.导入文件ToolStripMenuItem1.Text = "导入文件";
            this.导入文件ToolStripMenuItem1.Click += new System.EventHandler(this.导入文件ToolStripMenuItem_Click);
            // 
            // 编译ToolStripMenuItem
            // 
            this.编译ToolStripMenuItem.Name = "编译ToolStripMenuItem";
            this.编译ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.编译ToolStripMenuItem.Text = "编译";
            this.编译ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 导出文件ToolStripMenuItem1
            // 
            this.导出文件ToolStripMenuItem1.Name = "导出文件ToolStripMenuItem1";
            this.导出文件ToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.导出文件ToolStripMenuItem1.Text = "导出文件";
            this.导出文件ToolStripMenuItem1.Click += new System.EventHandler(this.导出文件ToolStripMenuItem_Click);
            // 
            // 全部导出到文件夹ToolStripMenuItem1
            // 
            this.全部导出到文件夹ToolStripMenuItem1.Name = "全部导出到文件夹ToolStripMenuItem1";
            this.全部导出到文件夹ToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
            this.全部导出到文件夹ToolStripMenuItem1.Text = "全部导出到文件夹";
            this.全部导出到文件夹ToolStripMenuItem1.Click += new System.EventHandler(this.全部导出到文件夹ToolStripMenuItem_Click);
            // 
            // WinMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 623);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WinMain";
            this.Text = "DevCompressWin";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 导入文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 导出文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部导出到文件夹ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem 关联文件ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导入文件夹ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入文件ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 编译ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出文件ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 全部导出到文件夹ToolStripMenuItem1;
    }
}

