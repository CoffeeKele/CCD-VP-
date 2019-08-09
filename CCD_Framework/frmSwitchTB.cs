using CCD_Framework.Helper;
using CCD_Framework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CCD_Framework
{
    public partial class frmSwitchTB : Form
    {
        public frmSwitchTB()
        {
            InitializeComponent();
        }
        public delegate void reLoadTBInspectionHandler();
        public event reLoadTBInspectionHandler reLoadTBInspection;
        iniHelper iniHelper = new iniHelper(Application.StartupPath + @"\Config.ini");
        private string CurrentPCode = string.Empty;
        private void frmSwitchTB_Load(object sender, EventArgs e)
        {
            var lProdStdData = new List<ProdStdData>();
            ProdStdData model = new ProdStdData();
            //将XML文件加载进来
            XDocument document = XDocument.Load(Path.Combine(Application.StartupPath, @"StdData.xml"));
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            //获取根元素下的所有子元素
            IEnumerable<XElement> enumerable = root.Elements();
            foreach (XElement item in enumerable)
            {
                foreach (XElement item1 in item.Elements())
                {
                    if (item1.Name == "Code")
                    {
                        model.Code = item1.Value;

                    }
                    if (item1.Name == "Name")
                    {
                        model.Name = item1.Value;
                    }
                }
                lProdStdData.Add(model);
                model = new ProdStdData();
            }

            cboCurrProd.DataSource = lProdStdData;
            cboCurrProd.DisplayMember = "Name";
            cboCurrProd.ValueMember = "Code";
            var pCode = iniHelper.IniReadValue("SysSeting", "CurrentProductCode");
            CurrentPCode = pCode;
            if (!string.IsNullOrEmpty(pCode))
            {
                cboCurrProd.SelectedValue = pCode;
            }

            if (LanguageHelper.CurrenLan == Language.EN_US)
            {
                this.label8.Left = 8;
                this.btnSave.Width = 78 + 10;
                this.btnSave.Left = 144 - 10;
                this.btnClose.Width = 80 + 4;
            }
            else if (LanguageHelper.CurrenLan == Language.ZH_CN)
            {
                this.label8.Left = 28;
                this.btnSave.Width = 78;
                this.btnClose.Width = 80;
            }
            this.Text = LanguageHelper.GetString("fstb_Text");
            this.label8.Text = LanguageHelper.GetString("fstb_EP");
            this.btnSave.Text = LanguageHelper.GetString("btn_Use");
            this.btnClose.Text = LanguageHelper.GetString("btn_Close");

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CurrentPCode != cboCurrProd.SelectedValue.ToString())
            {
                
                if (MessageBox.Show(LanguageHelper.GetString("fstb_Msg1"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    iniHelper.IniWriteValue("SysSeting", "CurrentProductCode", cboCurrProd.SelectedValue.ToString().Trim());
                    reLoadTBInspection?.Invoke();
                    Close();
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSwitchTB_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
