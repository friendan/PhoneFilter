using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneFilter
{
    public class PublicUtil
    {
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>创建是否成功</returns>
        [DllImport("Dbghelp", SetLastError = true)]
        public static extern bool MakeSureDirectoryPathExists(string path);


        /// <summary>
        /// 是否是手机号
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string phone)
        {
            if (phone.Length <= 5) return false;
            if (string.IsNullOrEmpty(phone)) return false;
            if (phone.Trim().Length < 11) return false;
            if (phone.Trim().StartsWith("1") == false) return false;

            return IsNumber(phone.Trim());
        }

        /// <summary>
        /// 是否是座机号
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsZuoJiNumber(string phone)
        {
            if (phone.Length <= 5) return false;
            if (phone.Substring(4, 1) != "-") return false;
            string p = phone.Replace("-", "").Trim();
            return IsNumber(p);
        }


        /// <summary>
        /// 判断字符串是否是数字
        /// </summary>
        public static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            return rx.IsMatch(s);
        }


    }
}
