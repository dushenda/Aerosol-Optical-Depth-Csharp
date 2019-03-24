namespace FileSystemDemo
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.tvwFileSystem = new System.Windows.Forms.TreeView();
            this.Splitter = new System.Windows.Forms.Splitter();
            this.lvwFileSystem = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnClose,
            this.btnOpen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoToolTip = false;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 22);
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.AutoToolTip = false;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(88, 22);
            this.btnOpen.Text = "打开文件夹";
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.AutoToolTip = false;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 22);
            this.btnClose.Text = "关闭文件夹";
            // 
            // tvwFileSystem
            // 
            this.tvwFileSystem.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwFileSystem.HideSelection = false;
            this.tvwFileSystem.Location = new System.Drawing.Point(0, 25);
            this.tvwFileSystem.Name = "tvwFileSystem";
            this.tvwFileSystem.Size = new System.Drawing.Size(272, 425);
            this.tvwFileSystem.TabIndex = 1;
            // 
            // Splitter
            // 
            this.Splitter.Location = new System.Drawing.Point(272, 25);
            this.Splitter.Name = "Splitter";
            this.Splitter.Size = new System.Drawing.Size(10, 425);
            this.Splitter.TabIndex = 2;
            this.Splitter.TabStop = false;
            // 
            // lvwFileSystem
            // 
            this.lvwFileSystem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.size,
            this.date});
            this.lvwFileSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwFileSystem.FullRowSelect = true;
            this.lvwFileSystem.GridLines = true;
            this.lvwFileSystem.HideSelection = false;
            this.lvwFileSystem.Location = new System.Drawing.Point(282, 25);
            this.lvwFileSystem.Name = "lvwFileSystem";
            this.lvwFileSystem.Size = new System.Drawing.Size(518, 425);
            this.lvwFileSystem.TabIndex = 3;
            this.lvwFileSystem.UseCompatibleStateImageBehavior = false;
            this.lvwFileSystem.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "名称";
            this.name.Width = 99;
            // 
            // size
            // 
            this.size.Text = "大小";
            this.size.Width = 103;
            // 
            // date
            // 
            this.date.Text = "修改日期";
            this.date.Width = 98;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvwFileSystem);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.tvwFileSystem);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "文件系统管理器";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.TreeView tvwFileSystem;
        private System.Windows.Forms.Splitter Splitter;
        private System.Windows.Forms.ListView lvwFileSystem;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ColumnHeader date;
    }
}

