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
    }
}
