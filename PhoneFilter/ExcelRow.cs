using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFilter
{
    public class ExcelRow
    {
        public string CompanyName = string.Empty;
        public string Name = string.Empty;
        public string Phone = string.Empty;
        public string GSNB = string.Empty;  // 工商年报电话
        public string MorePhone = string.Empty;

        public Dictionary<string, string> DtPhone = new Dictionary<string,string>(); // 手机号
        public Dictionary<string, string> DtGSNBPhone = new Dictionary<string, string>(); // 工商年报手机号
        public Dictionary<string, string> DtMorePhone = new Dictionary<string, string>(); // 更多手机号
        public Dictionary<string, string> DtZuoJi = new Dictionary<string,string>(); // 座机号

        // 解析好的电话  直接保存这个就好
        public Dictionary<string, string> PhoneData = new Dictionary<string, string>();

        public void parsePhoneData()
        {
            // 手机
            if(PublicConfig.ExportPhone)
            {
                foreach(string phone in DtPhone.Keys)
                {
                    PhoneData[phone] = string.Empty;
                }
            }

            // 工商年报电话
            if(PublicConfig.ExportGSNB)
            {
                foreach (string phone in DtGSNBPhone.Keys)
                {
                    PhoneData[phone] = string.Empty;
                }
            }

            // 更多电话
            if(PublicConfig.ExportMorePhone)
            {
                foreach (string phone in DtMorePhone.Keys)
                {
                    PhoneData[phone] = string.Empty;
                }
            }

            // 座机
            if (PublicConfig.ExportZuoJi)
            {
                foreach (string phone in DtZuoJi.Keys)
                {
                    PhoneData[phone] = string.Empty;
                }
            }
        }

        private void addPhone(string sPhone)
        {
            if (PublicUtil.IsPhoneNumber(sPhone))
            {
                if (sPhone.Length > 11) sPhone = sPhone.Substring(0, 11);
                DtPhone[sPhone] = string.Empty;
            }
            if (PublicUtil.IsZuoJiNumber(sPhone))
            {
                DtZuoJi[sPhone] = string.Empty;
            }
        }

        private void addMorePhone(string sPhone)
        {
            if (PublicUtil.IsPhoneNumber(sPhone))
            {
                DtMorePhone[sPhone] = string.Empty;
            }
            if (PublicUtil.IsZuoJiNumber(sPhone))
            {
                DtZuoJi[sPhone] = string.Empty;
            }
        }

        private void addGSNBPhone(string sPhone)
        {
            if (PublicUtil.IsPhoneNumber(sPhone))
            {
                DtGSNBPhone[sPhone] = string.Empty;
            }
            if (PublicUtil.IsZuoJiNumber(sPhone))
            {
                DtZuoJi[sPhone] = string.Empty;
            }
        }

        public void ParsePhone()
        {

            // 联系电话
            addPhone(Phone);

            // 工商年报电话
            // 0313-6219828; 13833319661; 
            // 18233215555; 
            // 66521860; 0371-55633767; 13949020571; 037166521860; 13838818883; 
            {
                string[] dataList = GSNB.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string data in dataList)
                {
                    addGSNBPhone(data.Trim());
                }
            }

            // 更多联系电话
            // 柯利梅:13831301238; 
            // 0371-63629832:15938731672; 
            // 郭建平:031186015119; 黄燕霞:13171588307; 
            {
                string[] dataList = MorePhone.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string data in dataList)
                {
                    string[] dataList2 = data.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach(string data2 in dataList2)
                    {
                        addMorePhone(data2.Trim());
                    }
                }
            }

        }

        public int getPhoneNum()
        {
            int phoneNum = 0;
            phoneNum += DtPhone.Keys.Count;
            phoneNum += DtMorePhone.Keys.Count;
            phoneNum += DtZuoJi.Keys.Count;
            return phoneNum;
        }


    }
}
