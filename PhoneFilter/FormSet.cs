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
            chbExportCompanyName.Checked = PublicConfig.ExportCompanyName;
            chbExportName.Checked = PublicConfig.ExportName;
            chbExportPhone.Checked = PublicConfig.ExportPhone;
            chbExportGSNB.Checked = PublicConfig.ExportGSNB;
            chbExportMorePhone.Checked = PublicConfig.ExportMorePhone;
            chbExportZuoJi.Checked = PublicConfig.ExportZuoJi;
        }

        private void chbFilterSamePhone_CheckedChanged(object sender, EventArgs e)
        {
            PublicConfig.FilterSamePhone = chbFilterSamePhone.Checked;
        }
    }
}
