
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CCD_Framework.Helper
{
    public class iniHelper
    {
        public string path;

        #region "声明变量"

        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="section">节点名称[如[TypeName]]</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="def">值</param>
        /// <param name="retval">stringbulider对象</param>
        /// <param name="size">字节大小</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        [DllImport("kernel32")]
        private static extern uint GetPrivateProfileString(

           string lpAppName, // points to section name

           string lpKeyName, // points to key name

           string lpDefault, // points to default string

           byte[] lpReturnedString, // points to destination buffer

           uint nSize, // size of destination buffer

           string lpFileName  // points to initialization filename

       );

        #endregion

        //声明读写INI文件的API函数  
        public iniHelper(string INIPath)
        {
            path = INIPath;
        }

        //类的构造函数，传递INI文件名  
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        //写INI文件  
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }

        public List<string> ReadSections()
        {
            List<string> result = new List<string>();

            byte[] buf = new byte[65536];

            uint len = GetPrivateProfileString(null, null, null, buf, (uint)buf.Length, path);

            int j = 0;

            for (int i = 0; i < len; i++)

                if (buf[i] == 0)

                {

                    result.Add(Encoding.Default.GetString(buf, j, i - j));

                    j = i + 1;

                }

            return result;

        }


    }
}