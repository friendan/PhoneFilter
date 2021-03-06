﻿namespace PhoneFilter
{
    partial class FormSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSet));
            this.chbExportCompanyName = new System.Windows.Forms.CheckBox();
            this.chbExportName = new System.Windows.Forms.CheckBox();
            this.chbExportPhone = new System.Windows.Forms.CheckBox();
            this.chbExportGSNB = new System.Windows.Forms.CheckBox();
            this.chbExportMorePhone = new System.Windows.Forms.CheckBox();
            this.chbExportZuoJi = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbFilterSamePhone = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbFileRowNum = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txbFilterCompanyName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txbSaveDir = new System.Windows.Forms.TextBox();
            this.chbGetFirstPhone = new System.Windows.Forms.CheckBox();
            this.chbGetSecondPhone = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbExportCompanyName
            // 
            this.chbExportCompanyName.AutoSize = true;
            this.chbExportCompanyName.Location = new System.Drawing.Point(27, 31);
            this.chbExportCompanyName.Name = "chbExportCompanyName";
            this.chbExportCompanyName.Size = new System.Drawing.Size(89, 19);
            this.chbExportCompanyName.TabIndex = 0;
            this.chbExportCompanyName.Text = "企业名称";
            this.chbExportCompanyName.UseVisualStyleBackColor = true;
            this.chbExportCompanyName.CheckedChanged += new System.EventHandler(this.chbExportCompanyName_CheckedChanged);
            // 
            // chbExportName
            // 
            this.chbExportName.AutoSize = true;
            this.chbExportName.Location = new System.Drawing.Point(27, 67);
            this.chbExportName.Name = "chbExportName";
            this.chbExportName.Size = new System.Drawing.Size(89, 19);
            this.chbExportName.TabIndex = 0;
            this.chbExportName.Text = "法人姓名";
            this.chbExportName.UseVisualStyleBackColor = true;
            this.chbExportName.CheckedChanged += new System.EventHandler(this.chbExportName_CheckedChanged);
            // 
            // chbExportPhone
            // 
            this.chbExportPhone.AutoSize = true;
            this.chbExportPhone.Location = new System.Drawing.Point(27, 101);
            this.chbExportPhone.Name = "chbExportPhone";
            this.chbExportPhone.Size = new System.Drawing.Size(59, 19);
            this.chbExportPhone.TabIndex = 0;
            this.chbExportPhone.Text = "电话";
            this.chbExportPhone.UseVisualStyleBackColor = true;
            this.chbExportPhone.CheckedChanged += new System.EventHandler(this.chbExportPhone_CheckedChanged);
            // 
            // chbExportGSNB
            // 
            this.chbExportGSNB.AutoSize = true;
            this.chbExportGSNB.Location = new System.Drawing.Point(27, 139);
            this.chbExportGSNB.Name = "chbExportGSNB";
            this.chbExportGSNB.Size = new System.Drawing.Size(119, 19);
            this.chbExportGSNB.TabIndex = 0;
            this.chbExportGSNB.Text = "工商年报电话";
            this.chbExportGSNB.UseVisualStyleBackColor = true;
            this.chbExportGSNB.CheckedChanged += new System.EventHandler(this.chbExportGSNB_CheckedChanged);
            // 
            // chbExportMorePhone
            // 
            this.chbExportMorePhone.AutoSize = true;
            this.chbExportMorePhone.Location = new System.Drawing.Point(27, 173);
            this.chbExportMorePhone.Name = "chbExportMorePhone";
            this.chbExportMorePhone.Size = new System.Drawing.Size(89, 19);
            this.chbExportMorePhone.TabIndex = 0;
            this.chbExportMorePhone.Text = "更多号码";
            this.chbExportMorePhone.UseVisualStyleBackColor = true;
            this.chbExportMorePhone.CheckedChanged += new System.EventHandler(this.chbExportMorePhone_CheckedChanged);
            // 
            // chbExportZuoJi
            // 
            this.chbExportZuoJi.AutoSize = true;
            this.chbExportZuoJi.Location = new System.Drawing.Point(27, 209);
            this.chbExportZuoJi.Name = "chbExportZuoJi";
            this.chbExportZuoJi.Size = new System.Drawing.Size(59, 19);
            this.chbExportZuoJi.TabIndex = 0;
            this.chbExportZuoJi.Text = "座机";
            this.chbExportZuoJi.UseVisualStyleBackColor = true;
            this.chbExportZuoJi.CheckedChanged += new System.EventHandler(this.chbExportZuoJi_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbExportPhone);
            this.groupBox1.Controls.Add(this.chbExportZuoJi);
            this.groupBox1.Controls.Add(this.chbExportCompanyName);
            this.groupBox1.Controls.Add(this.chbExportMorePhone);
            this.groupBox1.Controls.Add(this.chbExportName);
            this.groupBox1.Controls.Add(this.chbExportGSNB);
            this.groupBox1.Location = new System.Drawing.Point(37, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 243);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // chbFilterSamePhone
            // 
            this.chbFilterSamePhone.AutoSize = true;
            this.chbFilterSamePhone.Location = new System.Drawing.Point(26, 33);
            this.chbFilterSamePhone.Name = "chbFilterSamePhone";
            this.chbFilterSamePhone.Size = new System.Drawing.Size(149, 19);
            this.chbFilterSamePhone.TabIndex = 2;
            this.chbFilterSamePhone.Text = "过滤相同手机号码";
            this.chbFilterSamePhone.UseVisualStyleBackColor = true;
            this.chbFilterSamePhone.CheckedChanged += new System.EventHandler(this.chbFilterSamePhone_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "文件分割：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chbGetSecondPhone);
            this.groupBox2.Controls.Add(this.chbGetFirstPhone);
            this.groupBox2.Controls.Add(this.txbFileRowNum);
            this.groupBox2.Controls.Add(this.chbFilterSamePhone);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(278, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 238);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // txbFileRowNum
            // 
            this.txbFileRowNum.Location = new System.Drawing.Point(111, 77);
            this.txbFileRowNum.Name = "txbFileRowNum";
            this.txbFileRowNum.Size = new System.Drawing.Size(125, 25);
            this.txbFileRowNum.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txbFilterCompanyName);
            this.groupBox3.Location = new System.Drawing.Point(37, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(683, 153);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "名称过滤：";
            // 
            // txbFilterCompanyName
            // 
            this.txbFilterCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbFilterCompanyName.Location = new System.Drawing.Point(3, 21);
            this.txbFilterCompanyName.Multiline = true;
            this.txbFilterCompanyName.Name = "txbFilterCompanyName";
            this.txbFilterCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbFilterCompanyName.Size = new System.Drawing.Size(677, 129);
            this.txbFilterCompanyName.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txbSaveDir);
            this.groupBox4.Location = new System.Drawing.Point(37, 434);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(683, 90);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "保存目录：";
            // 
            // txbSaveDir
            // 
            this.txbSaveDir.Location = new System.Drawing.Point(11, 32);
            this.txbSaveDir.Name = "txbSaveDir";
            this.txbSaveDir.Size = new System.Drawing.Size(663, 25);
            this.txbSaveDir.TabIndex = 0;
            // 
            // chbGetFirstPhone
            // 
            this.chbGetFirstPhone.AutoSize = true;
            this.chbGetFirstPhone.Location = new System.Drawing.Point(26, 134);
            this.chbGetFirstPhone.Name = "chbGetFirstPhone";
            this.chbGetFirstPhone.Size = new System.Drawing.Size(179, 19);
            this.chbGetFirstPhone.TabIndex = 5;
            this.chbGetFirstPhone.Text = "只提取第一个手机号码";
            this.chbGetFirstPhone.UseVisualStyleBackColor = true;
            this.chbGetFirstPhone.CheckedChanged += new System.EventHandler(this.chbGetFirstPhone_CheckedChanged);
            // 
            // chbGetSecondPhone
            // 
            this.chbGetSecondPhone.AutoSize = true;
            this.chbGetSecondPhone.Location = new System.Drawing.Point(26, 168);
            this.chbGetSecondPhone.Name = "chbGetSecondPhone";
            this.chbGetSecondPhone.Size = new System.Drawing.Size(179, 19);
            this.chbGetSecondPhone.TabIndex = 5;
            this.chbGetSecondPhone.Text = "只提取第二个手机号码";
            this.chbGetSecondPhone.UseVisualStyleBackColor = true;
            this.chbGetSecondPhone.CheckedChanged += new System.EventHandler(this.chbGetSecondPhone_CheckedChanged);
            // 
            // FormSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 543);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSet_FormClosing);
            this.Load += new System.EventHandler(this.FormSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chbExportCompanyName;
        private System.Windows.Forms.CheckBox chbExportName;
        private System.Windows.Forms.CheckBox chbExportPhone;
        private System.Windows.Forms.CheckBox chbExportGSNB;
        private System.Windows.Forms.CheckBox chbExportMorePhone;
        private System.Windows.Forms.CheckBox chbExportZuoJi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbFilterSamePhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbFileRowNum;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txbFilterCompanyName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txbSaveDir;
        private System.Windows.Forms.CheckBox chbGetSecondPhone;
        private System.Windows.Forms.CheckBox chbGetFirstPhone;
    }
}