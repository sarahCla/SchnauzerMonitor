namespace SchnauzerMonitor
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DataGridInfo = new System.Windows.Forms.DataGridView();
            this.rightMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.del = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Start = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.IpPort = new System.Windows.Forms.ToolStripMenuItem();
            this.查看日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowFrom = new System.Windows.Forms.ToolStripMenuItem();
            this.HideFrom = new System.Windows.Forms.ToolStripMenuItem();
            this.BackFrom = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridInfo)).BeginInit();
            this.rightMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridInfo
            // 
            this.DataGridInfo.AllowUserToAddRows = false;
            this.DataGridInfo.AllowUserToDeleteRows = false;
            this.DataGridInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridInfo.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.DataGridInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridInfo.Location = new System.Drawing.Point(15, 28);
            this.DataGridInfo.Name = "DataGridInfo";
            this.DataGridInfo.ReadOnly = true;
            this.DataGridInfo.RowTemplate.Height = 23;
            this.DataGridInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridInfo.Size = new System.Drawing.Size(1009, 491);
            this.DataGridInfo.TabIndex = 0;
            // 
            // rightMenuStrip
            // 
            this.rightMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.del});
            this.rightMenuStrip.Name = "rightMenuStrip";
            this.rightMenuStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // del
            // 
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(100, 22);
            this.del.Text = "删除";
            this.del.Click += new System.EventHandler(this.Del_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始菜单ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.查看日志ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1036, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始菜单ToolStripMenuItem
            // 
            this.开始菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Start,
            this.Exit});
            this.开始菜单ToolStripMenuItem.Name = "开始菜单ToolStripMenuItem";
            this.开始菜单ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.开始菜单ToolStripMenuItem.Text = "开始菜单";
            // 
            // Start
            // 
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(152, 22);
            this.Start.Text = "启动";
            this.Start.Click += new System.EventHandler(this.DoStart);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(152, 22);
            this.Exit.Text = "退出";
            this.Exit.Click += new System.EventHandler(this.DoExit);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IpPort});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem1.Text = "系统配置";
            // 
            // IpPort
            // 
            this.IpPort.Name = "IpPort";
            this.IpPort.Size = new System.Drawing.Size(135, 22);
            this.IpPort.Text = "IP端口设置";
            this.IpPort.Click += new System.EventHandler(this.protSet);
            // 
            // 查看日志ToolStripMenuItem
            // 
            this.查看日志ToolStripMenuItem.Name = "查看日志ToolStripMenuItem";
            this.查看日志ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.查看日志ToolStripMenuItem.Text = "查看日志";
            this.查看日志ToolStripMenuItem.Click += new System.EventHandler(this.DoReadErrLog);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowFrom,
            this.HideFrom,
            this.BackFrom});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // ShowFrom
            // 
            this.ShowFrom.Name = "ShowFrom";
            this.ShowFrom.Size = new System.Drawing.Size(152, 22);
            this.ShowFrom.Text = "显示";
            this.ShowFrom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ShowFrom_MouseUp);
            // 
            // HideFrom
            // 
            this.HideFrom.Name = "HideFrom";
            this.HideFrom.Size = new System.Drawing.Size(152, 22);
            this.HideFrom.Text = "隐藏";
            this.HideFrom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HideFrom_MouseUp);
            // 
            // BackFrom
            // 
            this.BackFrom.Name = "BackFrom";
            this.BackFrom.Size = new System.Drawing.Size(152, 22);
            this.BackFrom.Text = "退出";
            this.BackFrom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackFrom_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1036, 531);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.DataGridInfo);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SchnauzerMonitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.DoResize);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridInfo)).EndInit();
            this.rightMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridInfo;
        private System.Windows.Forms.ContextMenuStrip rightMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem del;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem IpPort;
        private System.Windows.Forms.ToolStripMenuItem 开始菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Start;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem 查看日志ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowFrom;
        private System.Windows.Forms.ToolStripMenuItem BackFrom;
        private System.Windows.Forms.ToolStripMenuItem HideFrom;



    }
}

