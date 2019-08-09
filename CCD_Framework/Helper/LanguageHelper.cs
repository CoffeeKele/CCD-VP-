using CCD_Framework.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;

namespace CCD_Framework.Helper
{
    public static class LanguageHelper
    {
        public static Language CurrenLan { get; set; }
        public static string GetString(string id)
        {
            string strCurLanguage = "";

            try
            {
                if(CurrenLan==Language.EN_US)
                {
                    ResourceManager rm = new ResourceManager("CCD_Framework.Resources.EN_US", Assembly.GetExecutingAssembly());
                    CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                    strCurLanguage = rm.GetString(id, ci);
                }
                else if(CurrenLan == Language.ZH_CN)
                {
                    ResourceManager rm = new ResourceManager("CCD_Framework.Resources.ZH_CN", Assembly.GetExecutingAssembly());
                    CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                    strCurLanguage = rm.GetString(id, ci);
                }

            }
            catch
            {
                strCurLanguage = "No id:" + id + ", please add.";
            }

            return strCurLanguage;
        }
    }
}
