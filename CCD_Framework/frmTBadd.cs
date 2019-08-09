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
    public partial class frmTBadd : Form
    {
        public frmTBadd()
        {
            InitializeComponent();
        }
        public delegate void reLoadTBInspectionHandler();
        public event reLoadTBInspectionHandler reLoadTBInspection;
        iniHelper iniHelper = new iniHelper(Application.StartupPath + @"\Config.ini");
        private void frmTBadd_Load(object sender, EventArgs e)
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
                        lProdStdData.Add(model);
                        model = new ProdStdData();
                    }
                }
            }
            txtCode.Text = (Convert.ToInt32(lProdStdData.Max(m => m.Code)) + 1).ToString("000");
            txtName.Focus();
            if (LanguageHelper.CurrenLan == Language.EN_US)
            {
                this.lblCode.Left = 40;
                this.lblName.Left = 40;
                this.btnSave.Width = 78 + 4;
                this.btnClose.Width = 80 + 4;
            }
            else if (LanguageHelper.CurrenLan == Language.ZH_CN)
            {
                this.lblCode.Left = 52;
                this.lblName.Left = 31;
                this.btnSave.Width = 78;
                this.btnClose.Width = 80;
            }
            this.Text = LanguageHelper.GetString("ftba_Text");
            this.lblName.Text= LanguageHelper.GetString("ftba_PN");
            this.btnSave.Text= LanguageHelper.GetString("btn_Save");
            this.btnClose.Text = LanguageHelper.GetString("btn_Close");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Equals(""))
            {
                MessageBox.Show(LanguageHelper.GetString("ftba_Msg1"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }

            var path = Path.Combine(Application.StartupPath, @"TBInspectionVpp\", txtCode.Text.Trim());
            Directory.CreateDirectory(path);

            var baseVppPath1 = Path.Combine(Application.StartupPath, @"BaseTBInspectionVpp\TB_Inspection0.vpp");
            if (!File.Exists(baseVppPath1))
            {
                MessageBox.Show(LanguageHelper.GetString("ftba_Msg2_h") +"TB_Inspection0.vpp "+ LanguageHelper.GetString("ftba_Msg2_f"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var vppPath1 = Path.Combine(path, "TB_Inspection0.vpp");
            if (!File.Exists(vppPath1))
                File.Copy(baseVppPath1, vppPath1);

            var baseVppPath2 = Path.Combine(Application.StartupPath, @"BaseTBInspectionVpp\TB_Inspection1.vpp");
            if (!File.Exists(baseVppPath2))
            {
                MessageBox.Show(LanguageHelper.GetString("ftba_Msg2_h") + "TB_Inspection1.vpp " + LanguageHelper.GetString("ftba_Msg2_f"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var vppPath2 = Path.Combine(path, "TB_Inspection1.vpp");
            if (!File.Exists(vppPath2))
                File.Copy(baseVppPath2, vppPath2);

            var baseVppPath3 = Path.Combine(Application.StartupPath, @"BaseTBInspectionVpp\TB_Inspection2.vpp");
            if (!File.Exists(baseVppPath3))
            {
                MessageBox.Show(LanguageHelper.GetString("ftba_Msg2_h") + "TB_Inspection2.vpp " + LanguageHelper.GetString("ftba_Msg2_f"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var vppPath3 = Path.Combine(path, "TB_Inspection2.vpp");
            if (!File.Exists(vppPath3))
                File.Copy(baseVppPath3, vppPath3);


            var baseVppPath4 = Path.Combine(Application.StartupPath, @"BaseTBInspectionVpp\TB_Inspection1.vpp");
            if (!File.Exists(baseVppPath4))
            {
                MessageBox.Show(LanguageHelper.GetString("ftba_Msg2_h") + "TB_Inspection3.vpp " + LanguageHelper.GetString("ftba_Msg2_f"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var vppPath4 = Path.Combine(path, "TB_Inspection3.vpp");
            if (!File.Exists(vppPath4))
                File.Copy(baseVppPath4, vppPath4);


            xmlAdd(new ProdStdData { Code = txtCode.Text.Trim(), Name = txtName.Text.Trim() });

            if (MessageBox.Show(LanguageHelper.GetString("common_SaveSuccess") +" "+ LanguageHelper.GetString("ftba_Msg3"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                iniHelper.IniWriteValue("SysSeting", "CurrentProductCode", txtCode.Text.Trim());
                reLoadTBInspection?.Invoke();
                Close();
            }
        }

        private void xmlAdd(ProdStdData item)
        {
            var xmlPath = Path.Combine(Application.StartupPath, @"StdData.xml");
            XElement xe = XElement.Load(xmlPath);
            XElement record = new XElement(
                new XElement("ProdStdData", new XAttribute("Guid", Guid.NewGuid()), new XAttribute("Date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new XElement("Code", item.Code),
                new XElement("Name", item.Name),
                new XElement("sMidPoint", item.sMidPoint),
                new XElement("Angle", item.Angle),
                new XElement("sMidPoint2", item.sMidPoint2),
                new XElement("Angle2", item.Angle2),
                new XElement("XOffsetAllowed", item.XOffsetAllowed),
                new XElement("YOffsetAllowed", item.YOffsetAllowed),
                new XElement("Note", item.Note),
                new XElement("AngleOffsetAllowed", item.AngleOffsetAllowed)
                                ));
            xe.Add(record);
            xe.Save(xmlPath);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTBadd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
