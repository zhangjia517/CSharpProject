namespace Test_InteractiveWebPlayer
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.项目菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.场景管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择场景ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.改变天气ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地形管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.部署坦克ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.我方坦克ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.敌方坦克ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建树木ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.palmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.任务管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.坦克移动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停移动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.继续移动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToggleCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.第三人称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加入RtiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加入RtiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.发送ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于德馨同创ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(-12, 0);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(1109, 708);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 706);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1093, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.项目菜单ToolStripMenuItem,
            this.场景管理ToolStripMenuItem,
            this.地形管理ToolStripMenuItem,
            this.任务管理ToolStripMenuItem,
            this.testToolStripMenuItem,
            this.加入RtiToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1093, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 项目菜单ToolStripMenuItem
            // 
            this.项目菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.项目菜单ToolStripMenuItem.Name = "项目菜单ToolStripMenuItem";
            this.项目菜单ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.项目菜单ToolStripMenuItem.Text = "项目管理";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 场景管理ToolStripMenuItem
            // 
            this.场景管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择场景ToolStripMenuItem,
            this.改变天气ToolStripMenuItem});
            this.场景管理ToolStripMenuItem.Name = "场景管理ToolStripMenuItem";
            this.场景管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.场景管理ToolStripMenuItem.Text = "场景管理";
            // 
            // 选择场景ToolStripMenuItem
            // 
            this.选择场景ToolStripMenuItem.Name = "选择场景ToolStripMenuItem";
            this.选择场景ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.选择场景ToolStripMenuItem.Text = "选择场景";
            this.选择场景ToolStripMenuItem.Click += new System.EventHandler(this.选择场景ToolStripMenuItem_Click);
            // 
            // 改变天气ToolStripMenuItem
            // 
            this.改变天气ToolStripMenuItem.Name = "改变天气ToolStripMenuItem";
            this.改变天气ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.改变天气ToolStripMenuItem.Text = "改变天气";
            this.改变天气ToolStripMenuItem.Click += new System.EventHandler(this.改变天气ToolStripMenuItem_Click);
            // 
            // 地形管理ToolStripMenuItem
            // 
            this.地形管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.部署坦克ToolStripMenuItem,
            this.创建树木ToolStripMenuItem});
            this.地形管理ToolStripMenuItem.Name = "地形管理ToolStripMenuItem";
            this.地形管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.地形管理ToolStripMenuItem.Text = "地形管理";
            // 
            // 部署坦克ToolStripMenuItem
            // 
            this.部署坦克ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.我方坦克ToolStripMenuItem,
            this.敌方坦克ToolStripMenuItem});
            this.部署坦克ToolStripMenuItem.Name = "部署坦克ToolStripMenuItem";
            this.部署坦克ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.部署坦克ToolStripMenuItem.Text = "部署坦克";
            // 
            // 我方坦克ToolStripMenuItem
            // 
            this.我方坦克ToolStripMenuItem.Name = "我方坦克ToolStripMenuItem";
            this.我方坦克ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.我方坦克ToolStripMenuItem.Text = "我方坦克";
            this.我方坦克ToolStripMenuItem.Click += new System.EventHandler(this.我方坦克ToolStripMenuItem_Click);
            // 
            // 敌方坦克ToolStripMenuItem
            // 
            this.敌方坦克ToolStripMenuItem.Name = "敌方坦克ToolStripMenuItem";
            this.敌方坦克ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.敌方坦克ToolStripMenuItem.Text = "敌方坦克";
            this.敌方坦克ToolStripMenuItem.Click += new System.EventHandler(this.敌方坦克ToolStripMenuItem_Click);
            // 
            // 创建树木ToolStripMenuItem
            // 
            this.创建树木ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.palmToolStripMenuItem});
            this.创建树木ToolStripMenuItem.Name = "创建树木ToolStripMenuItem";
            this.创建树木ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.创建树木ToolStripMenuItem.Text = "创建树木";
            // 
            // palmToolStripMenuItem
            // 
            this.palmToolStripMenuItem.Name = "palmToolStripMenuItem";
            this.palmToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.palmToolStripMenuItem.Text = "Palm";
            this.palmToolStripMenuItem.Click += new System.EventHandler(this.palmToolStripMenuItem_Click);
            // 
            // 任务管理ToolStripMenuItem
            // 
            this.任务管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建任务ToolStripMenuItem,
            this.坦克移动ToolStripMenuItem,
            this.暂停移动ToolStripMenuItem,
            this.继续移动ToolStripMenuItem});
            this.任务管理ToolStripMenuItem.Name = "任务管理ToolStripMenuItem";
            this.任务管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.任务管理ToolStripMenuItem.Text = "任务管理";
            // 
            // 创建任务ToolStripMenuItem
            // 
            this.创建任务ToolStripMenuItem.Name = "创建任务ToolStripMenuItem";
            this.创建任务ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.创建任务ToolStripMenuItem.Text = "创建任务";
            this.创建任务ToolStripMenuItem.Click += new System.EventHandler(this.创建任务ToolStripMenuItem_Click);
            // 
            // 坦克移动ToolStripMenuItem
            // 
            this.坦克移动ToolStripMenuItem.Name = "坦克移动ToolStripMenuItem";
            this.坦克移动ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.坦克移动ToolStripMenuItem.Text = "坦克移动";
            this.坦克移动ToolStripMenuItem.Click += new System.EventHandler(this.坦克移动ToolStripMenuItem_Click);
            // 
            // 暂停移动ToolStripMenuItem
            // 
            this.暂停移动ToolStripMenuItem.Name = "暂停移动ToolStripMenuItem";
            this.暂停移动ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.暂停移动ToolStripMenuItem.Text = "暂停移动";
            this.暂停移动ToolStripMenuItem.Click += new System.EventHandler(this.暂停移动ToolStripMenuItem_Click);
            // 
            // 继续移动ToolStripMenuItem
            // 
            this.继续移动ToolStripMenuItem.Name = "继续移动ToolStripMenuItem";
            this.继续移动ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.继续移动ToolStripMenuItem.Text = "继续移动";
            this.继续移动ToolStripMenuItem.Click += new System.EventHandler(this.继续移动ToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToggleCameraToolStripMenuItem,
            this.第三人称ToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.testToolStripMenuItem.Text = "视角管理";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // testToggleCameraToolStripMenuItem
            // 
            this.testToggleCameraToolStripMenuItem.Name = "testToggleCameraToolStripMenuItem";
            this.testToggleCameraToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.testToggleCameraToolStripMenuItem.Text = "第一人称";
            this.testToggleCameraToolStripMenuItem.Click += new System.EventHandler(this.testToggleCameraToolStripMenuItem_Click);
            // 
            // 第三人称ToolStripMenuItem
            // 
            this.第三人称ToolStripMenuItem.Name = "第三人称ToolStripMenuItem";
            this.第三人称ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.第三人称ToolStripMenuItem.Text = "第三人称";
            this.第三人称ToolStripMenuItem.Click += new System.EventHandler(this.第三人称ToolStripMenuItem_Click);
            // 
            // 加入RtiToolStripMenuItem
            // 
            this.加入RtiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加入RtiToolStripMenuItem1,
            this.发送ToolStripMenuItem});
            this.加入RtiToolStripMenuItem.Name = "加入RtiToolStripMenuItem";
            this.加入RtiToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.加入RtiToolStripMenuItem.Text = "RTI";
            // 
            // 加入RtiToolStripMenuItem1
            // 
            this.加入RtiToolStripMenuItem1.Name = "加入RtiToolStripMenuItem1";
            this.加入RtiToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.加入RtiToolStripMenuItem1.Text = "加入Rti";
            this.加入RtiToolStripMenuItem1.Click += new System.EventHandler(this.加入RtiToolStripMenuItem1_Click);
            // 
            // 发送ToolStripMenuItem
            // 
            this.发送ToolStripMenuItem.Name = "发送ToolStripMenuItem";
            this.发送ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.发送ToolStripMenuItem.Text = "发送";
            this.发送ToolStripMenuItem.Click += new System.EventHandler(this.发送ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于德馨同创ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.关于ToolStripMenuItem.Text = " 帮助菜单";
            // 
            // 关于德馨同创ToolStripMenuItem
            // 
            this.关于德馨同创ToolStripMenuItem.Name = "关于德馨同创ToolStripMenuItem";
            this.关于德馨同创ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.关于德馨同创ToolStripMenuItem.Text = "关于德馨同创";
            this.关于德馨同创ToolStripMenuItem.Click += new System.EventHandler(this.关于德馨同创ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1093, 728);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.webBrowser1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "虚拟样机Ver1.0.2.3.0.1 — 德馨同创";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 场景管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择场景ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 改变天气ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 任务管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地形管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 部署坦克ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 我方坦克ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 敌方坦克ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建树木ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem palmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于德馨同创ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 项目菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加入RtiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加入RtiToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 发送ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 坦克移动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂停移动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 继续移动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToggleCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 第三人称ToolStripMenuItem;
    }
}

