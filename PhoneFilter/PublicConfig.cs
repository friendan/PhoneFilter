using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFilter
{
    public class PublicConfig
    {
        // 企业名称，法人姓名，电话，工商年报电话，更多号码 座机
        public static bool ExportCompanyName = false;
        public static bool ExportName = true;
        public static bool ExportPhone = true;
        public static bool ExportGSNB = false;
        public static bool ExportMorePhone = true;
        public static bool ExportZuoJi = false;

        public static string XlsTemplatePath = string.Empty;
        public static string XlsTemplatePath2 = string.Empty;
        public static bool FilterSamePhone = false; // 是否过滤相同手机号码
        public static double AppNow = 0;
        public static double AppLimit = 63808128000;
        public static int FileRowNum = 300;

        // 过滤公司名称字符串
        public static string FilterCompanyName = "银行|超市|连锁|快递|快运|商贸|速运|速递|药房|药店|旅行社|旅游|中国|联通|电信|移动|保险|农资|营业厅|劳务";
        public static Dictionary<string, string> DtFilterCompanyName = new Dictionary<string, string>();
        public static void InitFilterCompanyName()
        {
            DtFilterCompanyName.Clear();
            string[] dataList = FilterCompanyName.Split(new string[]{"|"}, StringSplitOptions.RemoveEmptyEntries);
            foreach(string data in dataList)
            {
                if (data.Trim().Length <= 0) return;
                DtFilterCompanyName[data.Trim()] = string.Empty;
            }
        }
        public static bool IsFilterCompanyName(string name)
        {
            foreach(string item in DtFilterCompanyName.Keys)
            {
                if (name.Contains(item)) return true;
            }
            return false;
        }

    }
}
