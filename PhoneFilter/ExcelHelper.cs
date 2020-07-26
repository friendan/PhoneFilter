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
        private static int mXlsFileIndex = 1;
        private static int mVcfFileIndex = 1;

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

        public static string getNewXlsFilePath(string xlsFilePath)
        {
            mXlsFileIndex += 1;
            string fName = Path.GetFileNameWithoutExtension(xlsFilePath);
            string fPath = string.Format(@"{0}\data\{1}_{2}.xls", Environment.CurrentDirectory, fName, mXlsFileIndex);
            return fPath;
        }

        public static string getNewVcfFilePath(string vcfFilePath)
        {
            mVcfFileIndex += 1;
            string fName = Path.GetFileNameWithoutExtension(vcfFilePath);
            string fPath = string.Format(@"{0}\data\{1}_{2}.vcf", Environment.CurrentDirectory, fName, mVcfFileIndex);
            return fPath;
        }

        public static void saveXls(List<ExcelRow> listRow, string templatePath, string xlsFilePath)
        {
            if (System.IO.File.Exists(templatePath) == false)
            {
                LogHelper.showLog("找不到模板文件：" + templatePath);
                return;
            }

            string xlsFilePathBK = xlsFilePath;
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(templatePath);
            Aspose.Cells.Worksheet sheet = (Aspose.Cells.Worksheet)workbook.Worksheets["Sheet"];
            Dictionary<string, string> dtPhones = new Dictionary<string, string>();
            if (PublicConfig.AppNow >= PublicConfig.AppLimit)
            {
                return;
            }

            int writeNum = 0;
            int row = 2;
            bool isSave = false;

            foreach (ExcelRow excelRow in listRow)
            {
                if (excelRow.getPhoneNum() <= 0) continue;
                isSave = false;

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
                        writeNum += 1;

                        // 换文件写
                        if(PublicConfig.FileRowNum > 0 && writeNum >= PublicConfig.FileRowNum)
                        {
                            writeNum = 0;
                            workbook.Save(xlsFilePath);
                            xlsFilePath = getNewXlsFilePath(xlsFilePathBK);
                            workbook = new Aspose.Cells.Workbook(templatePath);
                            sheet = (Aspose.Cells.Worksheet)workbook.Worksheets["Sheet"];
                            isSave = true;
                            row = 2;
                        }

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
                        writeNum += 1;

                        // 换文件写
                        if (PublicConfig.FileRowNum > 0 && writeNum >= PublicConfig.FileRowNum)
                        {
                            writeNum = 0;
                            workbook.Save(xlsFilePath);
                            xlsFilePath = getNewXlsFilePath(xlsFilePathBK);
                            workbook = new Aspose.Cells.Workbook(templatePath);
                            sheet = (Aspose.Cells.Worksheet)workbook.Worksheets["Sheet"];
                            isSave = true;
                            row = 2;
                        }


                    }
                }
            }

            if(isSave == false)
            {
                workbook.Save(xlsFilePath);
            }

            GC.Collect();
        }


        public static void saveVcf(List<ExcelRow> listRow, string vcfFilePath)
        {
            string vcfFilePathBK = vcfFilePath;

            Dictionary<string, string> dtPhones = new Dictionary<string, string>();

            UTF8Encoding utf8 = new UTF8Encoding(false); // true是BOM的编码模式
            StreamWriter sWriter = new StreamWriter(vcfFilePath, false, utf8);
            if(PublicConfig.AppNow >= PublicConfig.AppLimit)
            {
                return;
            }

            int row = 2;
            int writeNum = 0;
            bool isSave = false;

            foreach (ExcelRow excelRow in listRow)
            {
                if (excelRow.getPhoneNum() <= 0) continue;
                isSave = false;

                foreach (string phone in excelRow.PhoneData.Keys)
                {
                    if (PublicConfig.FilterSamePhone && dtPhones.Keys.Contains(phone))
                    {
                        continue;
                    }

                    sWriter.WriteLine("BEGIN:VCARD");
                    sWriter.WriteLine("VERSION:3.0");
                    sWriter.WriteLine("FN:" + excelRow.Name);
                    sWriter.WriteLine("ORG:" + excelRow.CompanyName);
                    sWriter.WriteLine("TEL;TYPE=mobile:" + phone);
                    sWriter.WriteLine("END:VCARD");
                    sWriter.WriteLine();

                    dtPhones[phone] = string.Empty;
                    row += 1;
                    writeNum += 1;

                    // 换文件写
                    if (PublicConfig.FileRowNum > 0 && writeNum >= PublicConfig.FileRowNum)
                    {
                        writeNum = 0;
                        sWriter.Close();
                        vcfFilePath = getNewVcfFilePath(vcfFilePathBK);
                        sWriter = new StreamWriter(vcfFilePath, false, utf8);
                        isSave = true;
                    }

                }
            }

            if (isSave == false)
            {
                sWriter.Close();
            }
            
        }


    }
}
