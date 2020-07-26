using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneFilter
{
    public partial class FormMian : Form
    {
        private string mExcelPath = string.Empty;

        public FormMian()
        {
            InitializeComponent();
            LogHelper.txbLog = this.txbLog;
        }

        private void FormMian_Load(object sender, EventArgs e)
        {
            mExcelPath = @"E:\work\300\qichamao.xlsx";
            PublicConfig.XlsTemplatePath = Environment.CurrentDirectory + @"\导出模板.xls";
            PublicConfig.XlsTemplatePath2 = Environment.CurrentDirectory + @"\导出模板2.xls";
            LogHelper.showLog("拖动文件到程序窗口，然后导出即可!");

            DateTime dt = DateTime.Now;
            TimeSpan tSpan = new TimeSpan(dt.Ticks);
            PublicConfig.AppNow = tSpan.TotalSeconds;
        }

        private void btnExportXls_Click(object sender, EventArgs e)
        {
            if(System.IO.File.Exists(mExcelPath) == false)
            {
                LogHelper.showLog("文件不存在：" + mExcelPath);
                return;
            }

            btnExportXls.Enabled = false;
            LogHelper.showLog(mExcelPath);
            LogHelper.showLog("正在导出xls文件，请稍后...");

            Thread t = new Thread(delegate(){
                ExcelHelper.ParseExcel(mExcelPath);
                LogHelper.showLog("导出xls文件完毕！");
                this.BeginInvoke((ThreadStart)delegate()
                {
                    btnExportXls.Enabled = true;
                });

            });
            t.Start();
        }

        private void btnExportVcf_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(mExcelPath) == false)
            {
                LogHelper.showLog("文件不存在：" + mExcelPath);
                return;
            }

            btnExportVcf.Enabled = false;
            LogHelper.showLog(mExcelPath);
            LogHelper.showLog("正在导出vcf文件，请稍后...");

            Thread t = new Thread(delegate()
            {

                ExcelHelper.ParseVcf(mExcelPath);
                LogHelper.showLog("导出vcf文件完毕！");
                this.BeginInvoke((ThreadStart)delegate()
                {
                    btnExportVcf.Enabled = true;
                });

            });
            t.Start();
        }

        private void menuItemConfig_Click(object sender, EventArgs e)
        {
            FormSet f = new FormSet();
            f.ShowDialog();
        }

        private void FormMian_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (path.EndsWith(".xlsx"))
            {
                //path = System.IO.Path.GetDirectoryName(path);
                LogHelper.showLog(path);
                mExcelPath = path;
            }
        }

        private void FormMian_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

       
    }
}
