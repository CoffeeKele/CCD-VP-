using CCD_Framework.Controls;
using CCD_Framework.Helper;
using CCD_Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCD_Framework
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }
        iniHelper iniHelper = new iniHelper(Application.StartupPath + @"\Config.ini");
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rdbPhoto.Checked) iniHelper.IniWriteValue("SysSeting", "RunningMode", ((int)RunningMode.Photo).ToString());
            else if (rdbUpload.Checked) iniHelper.IniWriteValue("SysSeting", "RunningMode", ((int)RunningMode.Upload).ToString());

            if (runningMode != (RunningMode)Convert.ToInt32(iniHelper.IniReadValue("SysSeting", "RunningMode")))
            {
                reLoadRunMode?.Invoke();
            }


            if (rdbEN.Checked) iniHelper.IniWriteValue("SysSeting", "Language", ((int)Language.EN_US).ToString());
            else if (rdbZH.Checked) iniHelper.IniWriteValue("SysSeting", "Language", ((int)Language.ZH_CN).ToString());

            if (language != (Language)Convert.ToInt32(iniHelper.IniReadValue("SysSeting", "Language")))
            {
                reLoadLanguage?.Invoke();
            }


            //if (chkRecCellL.Checked)
            //    iniHelper.IniWriteValue("ProSeting", "RecCellLength", "1");
            //else
            //    iniHelper.IniWriteValue("ProSeting", "RecCellLength", "0");

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private RunningMode runningMode;
        private Language language;
        private void frmSetting_Load(object sender, EventArgs e)
        {
            runningMode = (RunningMode)Convert.ToInt32(iniHelper.IniReadValue("SysSeting", "RunningMode"));
            if (runningMode == RunningMode.Photo) rdbPhoto.Checked = true;
            else if (runningMode == RunningMode.Upload) rdbUpload.Checked = true;

            language = (Language)Convert.ToInt32(iniHelper.IniReadValue("SysSeting", "Language"));
            if (language == Language.EN_US) rdbEN.Checked = true;
            else if (language == Language.ZH_CN) rdbZH.Checked = true;

            //var recCellLength = Convert.ToInt32(iniHelper.IniReadValue("ProSeting", "RecCellLength"));
            //if (recCellLength == 0) chkRecCellL.Checked = false;
            //else if (recCellLength == 1) chkRecCellL.Checked = true;
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            if (LanguageHelper.CurrenLan == Language.EN_US)
            {
                this.btnSave.Width = 83 + 7;
                this.btnClose.Width = 83 + 7;
            }
            else if (LanguageHelper.CurrenLan == Language.ZH_CN)
            {
                this.btnSave.Width = 83;
                this.btnClose.Width = 83;
            }

            this.Text = LanguageHelper.GetString("fs_Text");
            this.groupBox1.Text = LanguageHelper.GetString("fs_Gb1");
            this.groupBox3.Text = LanguageHelper.GetString("fs_Gb2");
            this.rdbPhoto.Text = LanguageHelper.GetString("fs_Photograph");
            this.rdbUpload.Text = LanguageHelper.GetString("fs_Upload");
            this.rdbEN.Text = LanguageHelper.GetString("fs_EN");
            this.rdbZH.Text = LanguageHelper.GetString("fs_ZH");
            this.btnSave.Text = LanguageHelper.GetString("btn_Apply");
            this.btnClose.Text = LanguageHelper.GetString("btn_Close");
        }

        public delegate void reLoadRunModeHandler();
        public event reLoadRunModeHandler reLoadRunMode;

        public delegate void reLoadLanguageHandler();
        public event reLoadLanguageHandler reLoadLanguage;
        private void frmSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
