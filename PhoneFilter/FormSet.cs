using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneFilter
{
    public partial class FormSet : Form
    {
        public FormSet()
        {
            InitializeComponent();
        }

        private void chbExportCompanyName_CheckedChanged(object sender, EventArgs e)
        {
            PublicConfig.ExportCompanyName = chbExportCompanyName.Checked;
        }

        private void chbExportName_CheckedChanged(object sender, EventArgs e)
        {
            PublicConfig.ExportName = chbExportName.Checked;
        }

        private void chbExportPhone_CheckedChanged(object sender, EventArgs e)
        {
            PublicConfig.ExportPhone = chbExportPhone.Checked;
        }

        private void chbExportGSNB_CheckedChanged(object sender, EventArgs e)
        {
            PublicConfig.ExportGSNB = chbExportGSNB.Checked;
        }

        private void chbExportMorePhone_CheckedChanged(object sender, EventArgs e)
        {
            PublicConfig.ExportMorePhone = chbExportMorePhone.Checked;
        }

        private void chbExportZuoJi_CheckedChanged(object sender, EventArgs e)
        {
            PublicConfig.ExportZuoJi = chbExportZuoJi.Checked;
        }

        private void FormSet_Load(object sender, EventArgs e)
        {
            txbFilterCompanyName.Text = PublicConfig.FilterCompanyName;
            chbExportCompanyName.Checked = PublicConfig.ExportCompanyName;
            chbExportName.Checked = PublicConfig.ExportName;
            chbExportPhone.Checked = PublicConfig.ExportPhone;
            chbExportGSNB.Checked = PublicConfig.ExportGSNB;
            chbExportMorePhone.Checked = PublicConfig.ExportMorePhone;
            chbExportZuoJi.Checked = PublicConfig.ExportZuoJi;
            chbFilterSamePhone.Checked = PublicConfig.FilterSamePhone;
            txbFileRowNum.Text = PublicConfig.FileRowNum.ToString();
            txbSaveDir.Text = PublicConfig.SaveDir;

            chbGetFirstPhone.Checked = PublicConfig.GetFirstPhone;
            chbGetSecondPhone.Checked = PublicConfig.GetSecondPhone;
        }

        private void chbFilterSamePhone_CheckedChanged(object sender, EventArgs e)
        {
            PublicConfig.FilterSamePhone = chbFilterSamePhone.Checked;
        }

        private void FormSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            PublicConfig.FileRowNum = Convert.ToInt32(txbFileRowNum.Text);
            PublicConfig.FilterCompanyName = txbFilterCompanyName.Text;
            PublicConfig.SaveDir = txbSaveDir.Text;
            PublicConfig.InitFilterCompanyName();
            PublicConfig.SaveConfig();
        }

        private void chbGetFirstPhone_CheckedChanged(object sender, EventArgs e)
        {
            PublicConfig.GetFirstPhone = chbGetFirstPhone.Checked;
            if(PublicConfig.GetFirstPhone)
            {
                chbGetSecondPhone.Checked = false;
            }
        }

        private void chbGetSecondPhone_CheckedChanged(object sender, EventArgs e)
        {
            PublicConfig.GetSecondPhone = chbGetSecondPhone.Checked;
            if(PublicConfig.GetSecondPhone)
            {
                chbGetFirstPhone.Checked = false;
            }
        }
    }
}
