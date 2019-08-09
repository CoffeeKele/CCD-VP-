using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCD_Framework.Helper;
using CCD_Framework.Models;

namespace CCD_Framework.Controls
{
    public partial class ImageSave : UserControl
    {
        public delegate void SaveHandler();
        public event SaveHandler save;

        public delegate void CancelHandler();
        public event CancelHandler cancel;

        iniHelper iniHelper = new iniHelper(Application.StartupPath + @"\Config.ini");
        public bool IsSaveToLocal { get; set; }
        public string ImageSavePathEdit { get; set; }
        public bool UseCognex { get; set; }
        public bool AutoCreatDateFolder { get; set; }
        public bool AutoUseTimeForFileName { get; set; }
        public bool ImageFormatJPG { get; set; }
        public bool ImageFormatBMP { get; set; }
        public int WhichImageNeedSave { get; set; }
        public ImageSave()
        {
            InitializeComponent();


            txtImageSavePath.Text = iniHelper.IniReadValue("ImageSaveParameter", "ImageSavePathEdit");
            ckbSaveToLocal.Checked = Convert.ToBoolean(iniHelper.IniReadValue("ImageSaveParameter", "IsSaveToLocal"));
            ckbUseCognex.Checked = Convert.ToBoolean(iniHelper.IniReadValue("ImageSaveParameter", "UseCognex"));
            ckbCreatDateFolder.Checked = Convert.ToBoolean(iniHelper.IniReadValue("ImageSaveParameter", "CreatDateFolder"));
            ckbUseTimeForFileName.Checked = Convert.ToBoolean(iniHelper.IniReadValue("ImageSaveParameter", "UseTimeForFileName"));
            ckbJPG.Checked = Convert.ToBoolean(iniHelper.IniReadValue("ImageSaveParameter", "ImageFormatJPG"));
            ckbBMP.Checked = Convert.ToBoolean(iniHelper.IniReadValue("ImageSaveParameter", "ImageFormatBMP"));
            WhichImageNeedSave = Convert.ToInt32(iniHelper.IniReadValue("ImageSaveParameter", "WhichImageNeedSave"));
            switch (WhichImageNeedSave)
            {
                case 0:
                    {
                        this.rdbSaveAllImage.Checked = true;
                        break;
                    }
                case 1:
                    {
                        this.rdbSaveCorrectImage.Checked = true;
                        break;
                    }
                case 2:
                    {
                        this.rdbSaveErrorImage.Checked = true;
                        break;
                    }
            }

            this.ImageSavePathEdit = txtImageSavePath.Text;
            this.IsSaveToLocal = ckbSaveToLocal.Checked;
            this.UseCognex = ckbUseCognex.Checked;
            this.AutoCreatDateFolder = ckbCreatDateFolder.Checked;
            this.AutoUseTimeForFileName = ckbUseTimeForFileName.Checked;
            this.ImageFormatJPG = ckbJPG.Checked;
            this.ImageFormatBMP = ckbBMP.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            iniHelper.IniWriteValue("ImageSaveParameter", "IsSaveToLocal", ckbSaveToLocal.Checked.ToString());

            iniHelper.IniWriteValue("ImageSaveParameter", "ImageSavePathEdit", txtImageSavePath.Text);

            iniHelper.IniWriteValue("ImageSaveParameter", "CreatDateFolder", ckbCreatDateFolder.Checked.ToString());

            iniHelper.IniWriteValue("ImageSaveParameter", "UseTimeForFileName", ckbUseTimeForFileName.Checked.ToString());

            iniHelper.IniWriteValue("ImageSaveParameter", "UseCognex", ckbUseCognex.Checked.ToString());

            iniHelper.IniWriteValue("ImageSaveParameter", "ImageFormatJPG", ckbJPG.Checked.ToString());

            iniHelper.IniWriteValue("ImageSaveParameter", "ImageFormatBMP", ckbBMP.Checked.ToString());


            if (rdbSaveAllImage.Checked)
            {
                iniHelper.IniWriteValue("ImageSaveParameter", "WhichImageNeedSave", "0");
            }
            else if (rdbSaveCorrectImage.Checked)
            {
                iniHelper.IniWriteValue("ImageSaveParameter", "WhichImageNeedSave", "1");
            }
            else if (rdbSaveErrorImage.Checked)
            {
                iniHelper.IniWriteValue("ImageSaveParameter", "WhichImageNeedSave", "2");
            }
            save?.Invoke();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancel?.Invoke();
        }

        private void btnPathView_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = LanguageHelper.GetString("is_Msg1");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtImageSavePath.Text = dialog.SelectedPath;
            }
        }

        private void ImageSave_Load(object sender, EventArgs e)
        {
            if (LanguageHelper.CurrenLan == Language.EN_US)
            {
                this.ckbUseTimeForFileName.Left = 177 + 64;
                this.ckbUseCognex.Left = 370 + 40;
                this.rdbSaveErrorImage.Left = 98;
                this.rdbSaveCorrectImage.Width = 74;
                this.groupBox2.Width = 143 + 40;
                this.groupBox3.Left = 202 + 40;
                this.groupBox3.Width = 287 + 80;
                this.rdbSaveCorrectImage.Left = 186 + 30;
                btnOK.Width = 76 - 10;
                btnOK.Left = 484 + 15;
                btnCancel.Width = 76 + 12;
            }
            else if (LanguageHelper.CurrenLan == Language.ZH_CN)
            {
                this.ckbUseTimeForFileName.Left = 177;
                this.ckbUseCognex.Left = 370;
                this.rdbSaveErrorImage.Left = 98;
                this.rdbSaveCorrectImage.Width = 74;
                this.groupBox2.Width = 143;
                this.groupBox3.Left = 202;
                this.groupBox3.Width = 287;
                this.rdbSaveCorrectImage.Left = 186;
                btnOK.Width = 76;
                btnOK.Left = 484;
                btnCancel.Width = 76;
            }
            ckbSaveToLocal.Text = LanguageHelper.GetString("is_SPL");
            groupBox1.Text = LanguageHelper.GetString("is_IPP");
            btnPathView.Text = LanguageHelper.GetString("is_Browse");
            ckbCreatDateFolder.Text = LanguageHelper.GetString("is_AF");
            ckbUseTimeForFileName.Text = LanguageHelper.GetString("is_PT");
            ckbUseCognex.Text = LanguageHelper.GetString("is_ST");
            groupBox2.Text = LanguageHelper.GetString("is_IPF");
            groupBox3.Text = LanguageHelper.GetString("is_PS");
            rdbSaveAllImage.Text = LanguageHelper.GetString("is_AP");
            rdbSaveErrorImage.Text = LanguageHelper.GetString("is_WP");
            rdbSaveCorrectImage.Text = LanguageHelper.GetString("is_CP");
            btnOK.Text = LanguageHelper.GetString("btn_OK");
            btnCancel.Text = LanguageHelper.GetString("btn_Cancel");
        }
    }
}
