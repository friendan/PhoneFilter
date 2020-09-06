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
        private static int mXlsFileIndex = 0;
        private static int mVcfFileIndex = 0;

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

            string dstFilePath = string.Format(@"{0}\{1}\xls\{2}.xls", 
                PublicConfig.SaveDir, 
                dstFileName,
                dstFileName);
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

        public static void ParseMail(string path)
        {
            if (System.IO.File.Exists(path) == false)
            {
                LogHelper.showLog("文件不存在：" + path);
                return;
            }

            string dstFileName = System.IO.Path.GetFileNameWithoutExtension(path);


            string mailPath = string.Format(@"{0}\{1}\非QQ邮箱_{2}.txt",
                PublicConfig.SaveDir,
                dstFileName,
                dstFileName);

            string qqMailPath = string.Format(@"{0}\{1}\QQ邮箱_{2}.txt",
               PublicConfig.SaveDir,
               dstFileName,
               dstFileName);

            PublicUtil.MakeSureDirectoryPathExists(mailPath);

            List<ExcelRow> listRow = getRowList(path);
            SaveMail(listRow, mailPath, qqMailPath);
        }

        public static void SaveMail(List<ExcelRow> listRow, string mailPath, string qqMailPath)
        {
            try
            {
                if (listRow.Count <= 0) return;
                //if (File.Exists(mailPath)) File.Delete(mailPath);
                StreamWriter sw = new StreamWriter(mailPath, false, System.Text.Encoding.UTF8);
                StreamWriter swQQMail = new StreamWriter(qqMailPath, false, System.Text.Encoding.UTF8);
                string line = string.Empty;
                foreach (ExcelRow row in listRow)
                {
                    foreach(string mail in  row.ListMail)
                    {
                        line = string.Format("{0} {1}", row.Name, mail);
                        if (IsQQMail(mail))
                        {
                            swQQMail.WriteLine(line);
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                       
                    }
                }
                sw.Close();
                swQQMail.Close();

            }
            catch(Exception ex)
            {
                LogHelper.showLog(ex);
            }
        }

        public static bool IsQQMail(string mail)
        {
            bool retVal = false;
            if (mail.IndexOf("@qq") > 0) retVal = true;
            if (mail.IndexOf("@QQ") > 0) retVal = true;

            return retVal;
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
            string dstFilePath = string.Format(@"{0}\{1}\vcf\{2}.vcf",
                PublicConfig.SaveDir, 
                dstFileName,
                dstFileName);

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

        public static bool IsTemplateFile(string path)
        {
            Aspose.Cells.Workbook wk = new Aspose.Cells.Workbook(path);
            Worksheet workbook = wk.Worksheets[0];
            Cells cells = workbook.Cells;
            if (cells.MaxColumn == 2) // 只有3列 0 1 2
            {
                PublicConfig.ExportPhone = true; // 使用模板时 必须导出电话
                return true;
            }
            return false;
        }

        private static List<ExcelRow> getRowList(string path)
        {
            bool isTemplate = IsTemplateFile(path);

            List<ExcelRow> listRow = new List<ExcelRow>();
            Aspose.Cells.Workbook wk = new Aspose.Cells.Workbook(path);
            Worksheet workbook = wk.Worksheets[0];
            Cells cells = workbook.Cells;
            string data = string.Empty;

            int row = 2;
            if(isTemplate)
            {
                row = 0;
            }

            for (; row <= cells.MaxDataRow; row++)
            {
                ExcelRow excelRow = new ExcelRow();

                if(isTemplate)
                {
                    excelRow.CompanyName = cells.GetCell(row, 0).StringValue; // 公司名称
                }
                else
                {
                    excelRow.CompanyName = cells.GetCell(row, 1).StringValue; // 公司名称
                }

                if(PublicConfig.IsFilterCompanyName(excelRow.CompanyName))
                {
                    continue;
                }

                // 企查猫 有邮箱
                if (cells.MaxColumn == 16)
                {
                    string mail = cells.GetCell(row, 14).StringValue.Trim();
                    if(mail.IndexOf("@") > 0)
                    {
                        excelRow.ListMail.Add(mail);
                    }
                }

                // 模板只有3列
                if(isTemplate)
                {
                    excelRow.Name = cells.GetCell(row, 1).StringValue;   // 法定代表人
                    data = cells.GetCell(row, 2).StringValue;
                    data = data.Replace("；", ";");
                    data = data.Replace(", ", ";");
                    excelRow.Phone = data.Trim();
                }
                else
                {
                    excelRow.Name = cells.GetCell(row, 2).StringValue;   // 法定代表人
                    excelRow.Phone = cells.GetCell(row, 11).StringValue;
                    excelRow.GSNB = cells.GetCell(row, 12).StringValue;   // 工商年报电话
                    excelRow.MorePhone = cells.GetCell(row, 13).StringValue;
                }

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
            string fPath = string.Format(@"{0}\{1}\xls\{2}_{3}.xls",
                PublicConfig.SaveDir, 
                fName, 
                fName,
                mXlsFileIndex);
            return fPath;
        }

        public static string getNewVcfFilePath(string vcfFilePath)
        {
            mVcfFileIndex += 1;
            string fName = Path.GetFileNameWithoutExtension(vcfFilePath);
            string fPath = string.Format(@"{0}\{1}\vcf\{2}_{3}.vcf",
                PublicConfig.SaveDir, 
                fName, 
                fName,
                mVcfFileIndex);
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
