namespace PhoneFilter
{
    partial class FormMian
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMian));
            this.txbLog = new System.Windows.Forms.TextBox();
            this.btnExportXls = new System.Windows.Forms.Button();
            this.btnExportVcf = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.chbTopMost = new System.Windows.Forms.CheckBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbLog
            // 
            this.txbLog.Location = new System.Drawing.Point(12, 151);
            this.txbLog.Multiline = true;
            this.txbLog.Name = "txbLog";
            this.txbLog.ReadOnly = true;
            this.txbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbLog.Size = new System.Drawing.Size(878, 280);
            this.txbLog.TabIndex = 0;
            // 
            // btnExportXls
            // 
            this.btnExportXls.Location = new System.Drawing.Point(496, 45);
            this.btnExportXls.Name = "btnExportXls";
            this.btnExportXls.Size = new System.Drawing.Size(136, 35);
            this.btnExportXls.TabIndex = 1;
            this.btnExportXls.Text = "导出xls文件";
            this.btnExportXls.UseVisualStyleBackColor = true;
            this.btnExportXls.Click += new System.EventHandler(this.btnExportXls_Click);
            // 
            // btnExportVcf
            // 
            this.btnExportVcf.Location = new System.Drawing.Point(496, 97);
            this.btnExportVcf.Name = "btnExportVcf";
            this.btnExportVcf.Size = new System.Drawing.Size(136, 35);
            this.btnExportVcf.TabIndex = 1;
            this.btnExportVcf.Text = "导出cvf文件";
            this.btnExportVcf.UseVisualStyleBackColor = true;
            this.btnExportVcf.Click += new System.EventHandler(this.btnExportVcf_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemConfig});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip";
            // 
            // menuItemConfig
            // 
            this.menuItemConfig.Name = "menuItemConfig";
            this.menuItemConfig.Size = new System.Drawing.Size(81, 24);
            this.menuItemConfig.Text = "参数配置";
            this.menuItemConfig.Click += new System.EventHandler(this.menuItemConfig_Click);
            // 
            // chbTopMost
            // 
            this.chbTopMost.AutoSize = true;
            this.chbTopMost.Location = new System.Drawing.Point(150, 45);
            this.chbTopMost.Name = "chbTopMost";
            this.chbTopMost.Size = new System.Drawing.Size(59, 19);
            this.chbTopMost.TabIndex = 3;
            this.chbTopMost.Text = "置顶";
            this.chbTopMost.UseVisualStyleBackColor = true;
            this.chbTopMost.CheckedChanged += new System.EventHandler(this.chbTopMost_CheckedChanged);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(150, 83);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(107, 35);
            this.btnClearLog.TabIndex = 4;
            this.btnClearLog.Text = "清空日志";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // FormMian
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 443);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.chbTopMost);
            this.Controls.Add(this.btnExportVcf);
            this.Controls.Add(this.btnExportXls);
            this.Controls.Add(this.txbLog);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手机号导出";
            this.Load += new System.EventHandler(this.FormMian_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMian_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMian_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbLog;
        private System.Windows.Forms.Button btnExportXls;
        private System.Windows.Forms.Button btnExportVcf;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemConfig;
        private System.Windows.Forms.CheckBox chbTopMost;
        private System.Windows.Forms.Button btnClearLog;
    }
}

