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

        public List<string> DtPhone = new List<string>();       // 手机号
        public List<string> DtGSNBPhone = new List<string>();   // 工商年报手机号
        public List<string> DtMorePhone = new List<string>();   // 更多手机号
        public List<string> DtZuoJi = new List<string>();       // 座机号

        // 解析好的电话  直接保存这个就好
        public Dictionary<string, string> PhoneData = new Dictionary<string, string>();

        public void parsePhoneData()
        {

            // 手机
            if(PublicConfig.ExportPhone)
            {
                if (PublicConfig.GetFirstPhone && DtPhone.Count > 0) // 只提取第一个手机号
                {
                    PhoneData[DtPhone[0]] = string.Empty;
                }
                else if(PublicConfig.GetSecondPhone && DtPhone.Count >= 2) // 只提取第2个手机号
                {
                    PhoneData[DtPhone[1]] = string.Empty;
                }
                else
                {
                    foreach (string phone in DtPhone)
                    {
                        PhoneData[phone] = string.Empty;
                    }
                } 
            }

            // 工商年报电话
            if(PublicConfig.ExportGSNB)
            {
                if (PublicConfig.GetFirstPhone && DtGSNBPhone.Count > 0) // 只提取第一个手机号
                {
                    PhoneData[DtGSNBPhone[0]] = string.Empty;
                }
                else if (PublicConfig.GetSecondPhone && DtGSNBPhone.Count >= 2) // 只提取第2个手机号
                {
                    PhoneData[DtGSNBPhone[1]] = string.Empty;
                }
                else
                {
                    foreach (string phone in DtGSNBPhone)
                    {
                        PhoneData[phone] = string.Empty;
                    }
                } 
            }

            // 更多电话
            if(PublicConfig.ExportMorePhone)
            {
                if (PublicConfig.GetFirstPhone && DtMorePhone.Count > 0) // 只提取第一个手机号
                {
                    PhoneData[DtMorePhone[0]] = string.Empty;
                }
                else if (PublicConfig.GetSecondPhone && DtMorePhone.Count >= 2) // 只提取第2个手机号
                {
                    PhoneData[DtMorePhone[1]] = string.Empty;
                }
                else
                {
                    foreach (string phone in DtMorePhone)
                    {
                        PhoneData[phone] = string.Empty;
                    }
                } 
            }

            // 座机
            if (PublicConfig.ExportZuoJi)
            {
                foreach (string phone in DtZuoJi)
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
                DtPhone.Add(sPhone);
            }
            if (PublicUtil.IsZuoJiNumber(sPhone))
            {
                DtZuoJi.Add(sPhone);
            }
        }

        private void addMorePhone(string sPhone)
        {
            if (PublicUtil.IsPhoneNumber(sPhone))
            {
                DtMorePhone.Add(sPhone);
            }
            if (PublicUtil.IsZuoJiNumber(sPhone))
            {
                DtZuoJi.Add(sPhone);
            }
        }

        private void addGSNBPhone(string sPhone)
        {
            if (PublicUtil.IsPhoneNumber(sPhone))
            {
                DtGSNBPhone.Add(sPhone);
            }
            if (PublicUtil.IsZuoJiNumber(sPhone))
            {
                DtZuoJi.Add(sPhone);
            }
        }

        public void ParsePhone()
        {
            // 联系电话
            // "江成如先生(经理):021-61555959;江先生:15316888558;江成如先生(经理):15316888558;"
            {
                //if(Name == "王亚宇")
                //{
                //    Console.WriteLine("debug");
                //}

                string[] dataList = Phone.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string data in dataList)
                {
                    string[] dataList2 = data.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach(string data2 in dataList2)
                    {
                        addPhone(data2);
                    }
                }
            }
            //addPhone(Phone);

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
            phoneNum += DtPhone.Count;
            phoneNum += DtMorePhone.Count;
            phoneNum += DtZuoJi.Count;
            return phoneNum;
        }


    }
}
