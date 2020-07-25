using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneFilter
{
    public class LogHelper
    {
        public static System.Windows.Forms.TextBox txbLog = null;
        public static bool mIsEnabelLog = true;
        public static string mLogFileName = "App.log";
        public static int mLogFileSize = 1024 * 1024 * 1;   // 1MB

        /// <summary>
        /// 是否开启详细日志
        /// </summary>
        public static bool mIsDetailLog = false;

        private delegate void DGShowLog(string strLog);
        private delegate void DGClearLog();

        public static void saveLogFile(string txt)
        {
            try
            {
                backupLogFile();
                string t = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string log = string.Format("[{0}] {1}\r\n", t, txt);

                FileStream fs = new FileStream(mLogFileName, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(log);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch(Exception ex)
            {
                showLog(ex);
            }
        }

        public static void saveLogUingFFCQian2(string txt)
        {
            try
            {
                string t = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string log = string.Format("[{0}] {1}\r\n", t, txt);

                FileStream fs = new FileStream("BetApp_UingQian2.log", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(log);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                showLog(ex);
            }
        }

        /// <summary>
        /// 备份日志文件
        /// </summary>
        private static void backupLogFile()
        {
            try
            {
                if(System.IO.File.Exists(mLogFileName) == false)
                {
                    return;
                }
                FileInfo fileInfo = new FileInfo(mLogFileName);
                if(fileInfo.Length < mLogFileSize)
                {
                    return;
                }

                string t = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileName = string.Format("{0}.{1}", mLogFileName, t);
                System.IO.File.Move(mLogFileName, fileName);
            }
            catch (Exception ex)
            {
                showLog(ex);
            }
        }

        public static void showLog(object obj)
        {
            showLog(obj.ToString());
        }

        public static void showLog(string strLog)
        {
            if (mIsEnabelLog == false) return;
            if (txbLog == null) return;
            if (txbLog.InvokeRequired)
            {
                DGShowLog d = new DGShowLog(showLog);
                txbLog.Invoke(d, new object[] { strLog });
            }
            else
            {
                if (txbLog.Text.Length >= 10000)
                {
                    clearLog();
                }

                DateTime dtNow = DateTime.Now;
                string text = string.Empty;
                text = string.Format("{0} {1} \r\n", dtNow.ToString("yyyy-MM-dd HH:mm:ss"), strLog);
                txbLog.AppendText(text);
            }

        }

        public static void clearLog()
        {
            if (txbLog.InvokeRequired)
            {
                DGClearLog d = new DGClearLog(clearLog);
                txbLog.Invoke(d);
            }
            else
            {
                txbLog.Text = string.Empty;
            }
        }

        public static void debugLog(object obj)
        {
            if(obj != null)
            {
                System.Diagnostics.Debug.WriteLine(obj.ToString());
            }
        }

        public static void debugLog(string txt)
        {
            System.Diagnostics.Debug.WriteLine(txt);
        }

    }
}
