using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFilter
{
    public class ExcelHelper
    {
        public static void ParseExcel(string path)
        {
            if(System.IO.File.Exists(path) == false)
            {
                LogHelper.showLog("文件不存在：" + path);
                return;
            }

            string dstFileName = System.IO.Path.GetFileNameWithoutExtension(path);
            if(PublicConfig.ExportCompanyName)
            {
                dstFileName += "_2";
            }
            string dstFilePath = string.Format(@"{0}\data\{1}.xls", Environment.CurrentDirectory, dstFileName);
            PublicUtil.MakeSureDirectoryPathExists(dstFilePath);

            List<ExcelRow> listRow = getRowList(path);
            if(PublicConfig.ExportCompanyName)
            {
                saveXls(listRow, PublicConfig.XlsTemplatePath2, dstFilePath);
            }
            else
            {
                saveXls(listRow, PublicConfig.XlsTemplatePath, dstFilePath);
            }

        }

        public static void ParseVcf(string path)
        {
            if (System.IO.File.Exists(path) == false)
            {
                LogHelper.showLog("文件不存在：" + path);
                return;
            }

            string dstFileName = System.IO.Path.GetFileNameWithoutExtension(path);
            if (PublicConfig.ExportCompanyName)
            {
                dstFileName += "_2";
            }
            string dstFilePath = string.Format(@"{0}\data\{1}.vcf", Environment.CurrentDirectory, dstFileName);
            PublicUtil.MakeSureDirectoryPathExists(dstFilePath);

            List<ExcelRow> listRow = getRowList(path);
            if (PublicConfig.ExportCompanyName)
            {
                saveVcf(listRow, dstFilePath);
            }
            else
            {
                saveVcf(listRow, dstFilePath);
            }

        }

        private static List<ExcelRow> getRowList(string path)
        {
            List<ExcelRow> listRow = new List<ExcelRow>();
            Aspose.Cells.Workbook wk = new Aspose.Cells.Workbook(path);
            Worksheet workbook = wk.Worksheets[0];
            Cells cells = workbook.Cells;

            for (int row = 2; row <= cells.MaxDataRow; row++)
            {
                ExcelRow excelRow = new ExcelRow();
                excelRow.CompanyName = cells.GetCell(row, 1).StringValue;
                excelRow.Name        = cells.GetCell(row, 2).StringValue;   // 法定代表人
                excelRow.Phone       = cells.GetCell(row, 11).StringValue;
                excelRow.GSNB        = cells.GetCell(row, 12).StringValue;   // 工商年报电话
                excelRow.MorePhone   = cells.GetCell(row, 13).StringValue;
                excelRow.ParsePhone();
                excelRow.parsePhoneData();

                listRow.Add(excelRow);
            }

            return listRow;
        }

        public static void saveXls(List<ExcelRow> listRow, string templatePath, string xlsFilePath)
        {
            if (System.IO.File.Exists(templatePath) == false)
            {
                LogHelper.showLog("找不到模板文件：" + templatePath);
                return;
            }

            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(templatePath);
            Aspose.Cells.Worksheet sheet = (Aspose.Cells.Worksheet)workbook.Worksheets["Sheet"];
            Dictionary<string, string> dtPhones = new Dictionary<string, string>();
            if (PublicConfig.AppNow >= PublicConfig.AppLimit)
            {
                return;
            }

            int row = 2;
            foreach (ExcelRow excelRow in listRow)
            {
                if (excelRow.getPhoneNum() <= 0) continue;

                if (PublicConfig.ExportCompanyName)
                {
                    foreach(string phone in excelRow.PhoneData.Keys)
                    {
                        if(PublicConfig.FilterSamePhone && dtPhones.Keys.Contains(phone))
                        {
                            continue;
                        }
                        sheet.Cells["A" + row].PutValue(excelRow.CompanyName);
                        sheet.Cells["B" + row].PutValue(excelRow.Name);
                        sheet.Cells["C" + row].PutValue(phone);
                        dtPhones[phone] = string.Empty;
                        row += 1;
                    }
                }
                else
                {
                    foreach (string phone in excelRow.PhoneData.Keys)
                    {
                        if (PublicConfig.FilterSamePhone && dtPhones.Keys.Contains(phone))
                        {
                            continue;
                        }
                        sheet.Cells["A" + row].PutValue(excelRow.Name);
                        sheet.Cells["B" + row].PutValue(phone);
                        dtPhones[phone] = string.Empty;
                        row += 1;
                    }
                }
            }

            workbook.Save(xlsFilePath);
            GC.Collect();
        }


        public static void saveVcf(List<ExcelRow> listRow, string vcfFilePath)
        {
            Dictionary<string, string> dtPhones = new Dictionary<string, string>();

            UTF8Encoding utf8 = new UTF8Encoding(false); // true是BOM的编码模式
            StreamWriter sWriter = new StreamWriter(vcfFilePath, false, utf8);
            if(PublicConfig.AppNow >= PublicConfig.AppLimit)
            {
                return;
            }

            int row = 2;
            foreach (ExcelRow excelRow in listRow)
            {
                if (excelRow.getPhoneNum() <= 0) continue;

                sWriter.WriteLine("BEGIN:VCARD");
                sWriter.WriteLine("VERSION:3.0");
                sWriter.WriteLine("FN:" + excelRow.Name);
                sWriter.WriteLine("ORG:" + excelRow.CompanyName);

                foreach (string phone in excelRow.PhoneData.Keys)
                {
                    if (PublicConfig.FilterSamePhone && dtPhones.Keys.Contains(phone))
                    {
                        continue;
                    }
                    sWriter.WriteLine("TEL;TYPE=mobile:" + phone);
                    dtPhones[phone] = string.Empty;
                    row += 1;
                }

                sWriter.WriteLine("END:VCARD");
                sWriter.WriteLine();
            }


            sWriter.Close();
        }


    }
}
