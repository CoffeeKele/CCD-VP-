using CCD_Framework.Helper;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CCD_Framework
{
    public partial class frmBaseTB : Form
    {
        public frmBaseTB()
        {
            InitializeComponent();
            Thread t1 = new Thread(new ThreadStart(OpenTB));
            t1.Start();
        }
        bool IsOpen1 = false;
        bool IsOpen2 = false;
        bool IsOpen3 = false;
        bool IsOpen4 = false;

        string vppPath1 = Path.Combine(Application.StartupPath, @"BaseTBInspectionVpp\TB_Inspection0.vpp");
        string vppPath2 = Path.Combine(Application.StartupPath, @"BaseTBInspectionVpp\TB_Inspection1.vpp");
        string vppPath3 = Path.Combine(Application.StartupPath, @"BaseTBInspectionVpp\TB_Inspection2.vpp");
        string vppPath4 = Path.Combine(Application.StartupPath, @"BaseTBInspectionVpp\TB_Inspection3.vpp");

        private CogToolBlockEditV2 CogToolBlockEditV21;

        private delegate void openTbHandler();
        private void OpenTB()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new openTbHandler(OpenTB));
            }
            else
            {
                CogToolBlockEditV21 = new CogToolBlockEditV2();
                CogToolBlockEditV21.Dock = DockStyle.Fill;
                panel2.Controls.Add(CogToolBlockEditV21);
            }
        }

        private void tsmtOpen1_Click(object sender, EventArgs e)
        {
            if (IsCanOpen(1))
            {
                if (!File.Exists(vppPath1))
                {
                    MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + "TB_Inspection0.vpp " + LanguageHelper.GetString("fbtb_Msg2"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CogToolBlockEditV21.Subject = (CogToolBlock)CogSerializer.LoadObjectFromFile(vppPath1);
                lblMsg.Text = LanguageHelper.GetString("fbtb_AF") + "1";
                IsOpen1 = true;
                IsOpen2 = false;
                IsOpen3 = false;
                IsOpen4 = false;
            }

        }

        private void tsmtSave1_Click(object sender, EventArgs e)
        {
            if (IsOpen1)
            {
                //if (CogToolBlockEditV21.Subject.HasChanged)
                //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV21.Subject, vppPath1);
                    MessageBox.Show(LanguageHelper.GetString("common_SaveSuccess"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
            }
            else
            {
                MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + " 1 " + LanguageHelper.GetString("fbtb_Msg1"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void tsmtOpen2_Click(object sender, EventArgs e)
        {
            if (IsCanOpen(2))
            {
                if (!File.Exists(vppPath2))
                {
                    MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + "1 TB_Inspection0.vpp " + LanguageHelper.GetString("fbtb_Msg2"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CogToolBlockEditV21.Subject = (CogToolBlock)CogSerializer.LoadObjectFromFile(vppPath2);
                lblMsg.Text = LanguageHelper.GetString("fbtb_AF") + "2";
                IsOpen1 = false;
                IsOpen2 = true;
                IsOpen3 = false;
                IsOpen4 = false;
            }
        }

        private void tsmtSave2_Click(object sender, EventArgs e)
        {
            if (IsOpen2)
            {
                //if (CogToolBlockEditV21.Subject.HasChanged)
                //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV21.Subject, vppPath2);
                    MessageBox.Show(LanguageHelper.GetString("common_SaveSuccess"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
            }
            else
            {
                MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + " 2 " + LanguageHelper.GetString("fbtb_Msg1"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void tsmtOpen3_Click(object sender, EventArgs e)
        {
            if (IsCanOpen(3))
            {
                if (!File.Exists(vppPath3))
                {
                    MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + "3 TB_Inspection1.vpp " + LanguageHelper.GetString("fbtb_Msg2"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CogToolBlockEditV21.Subject = (CogToolBlock)CogSerializer.LoadObjectFromFile(vppPath3);
                lblMsg.Text = LanguageHelper.GetString("fbtb_AF") + "3";
                IsOpen1 = false;
                IsOpen2 = false;
                IsOpen3 = true;
                IsOpen4 = false;
            }
        }

        private void tsmtOpen4_Click(object sender, EventArgs e)
        {
            if (IsCanOpen(4))
            {
                if (!File.Exists(vppPath4))
                {
                    MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + " 4 TB_Inspection3.vpp " + LanguageHelper.GetString("fbtb_Msg2"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CogToolBlockEditV21.Subject = (CogToolBlock)CogSerializer.LoadObjectFromFile(vppPath4);
                lblMsg.Text = LanguageHelper.GetString("fbtb_AF") + "4";
                IsOpen1 = false;
                IsOpen2 = false;
                IsOpen3 = false;
                IsOpen4 = true;
            }
        }

        private bool IsCanOpen(int index)
        {
            bool result = true;
            if (index != 1)
            {
                if (IsOpen1 && CogToolBlockEditV21.Subject.HasChanged)
                {

                    if (MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + " 1 " + LanguageHelper.GetString("fbtb_Msg3") + index + "？", LanguageHelper.GetString("common_Info"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    {
                        result = false;

                    }
                }
            }
            if (index != 2)
            {
                if (IsOpen2 && CogToolBlockEditV21.Subject.HasChanged)
                {

                    if (MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + " 2 " + LanguageHelper.GetString("fbtb_Msg3") + index + "？", LanguageHelper.GetString("common_Info"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    {
                        result = false;
                    }
                }
            }
            if (index != 3)
            {
                if (IsOpen3 && CogToolBlockEditV21.Subject.HasChanged)
                {

                    if (MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + " 3 " + LanguageHelper.GetString("fbtb_Msg3") + index + "？", LanguageHelper.GetString("common_Info"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    {
                        result = false;
                    }
                }
            }
            if (index != 4)
            {
                if (IsOpen4 && CogToolBlockEditV21.Subject.HasChanged)
                {

                    if (MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + " 4 " + LanguageHelper.GetString("fbtb_Msg3") + index + "？", LanguageHelper.GetString("common_Info"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        private void tsmtSave3_Click(object sender, EventArgs e)
        {
            if (IsOpen3)
            {
                //if (CogToolBlockEditV21.Subject.HasChanged)
                //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV21.Subject, vppPath3);
                    MessageBox.Show(LanguageHelper.GetString("common_SaveSuccess"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
            }
            else
            {
                MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + " 3 " + LanguageHelper.GetString("fbtb_Msg1"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void tsmtSave4_Click(object sender, EventArgs e)
        {
            if (IsOpen4)
            {
                //if (CogToolBlockEditV21.Subject.HasChanged)
                //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV21.Subject, vppPath4);
                    MessageBox.Show(LanguageHelper.GetString("common_SaveSuccess"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
            }
            else
            {
                MessageBox.Show(LanguageHelper.GetString("fbtb_AF") + " 4 " + LanguageHelper.GetString("fbtb_Msg1"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void frmBaseTB_Load(object sender, EventArgs e)
        {
            tsmt1.Text = LanguageHelper.GetString("fbtb_AF") + "1";
            tsmtOpen1.Text = LanguageHelper.GetString("btn_Edit");
            tsmtSave1.Text = LanguageHelper.GetString("btn_Save");
            tsmt2.Text = LanguageHelper.GetString("fbtb_AF") + "2";
            tsmtOpen2.Text = LanguageHelper.GetString("btn_Edit");
            tsmtSave2.Text = LanguageHelper.GetString("btn_Save");
            tsmt3.Text = LanguageHelper.GetString("fbtb_AF") + "3";
            tsmtOpen3.Text = LanguageHelper.GetString("btn_Edit");
            tsmtSave3.Text = LanguageHelper.GetString("btn_Save");
            tsmt4.Text = LanguageHelper.GetString("fbtb_AF") + "4";
            tsmtOpen4.Text = LanguageHelper.GetString("btn_Edit");
            tsmtSave4.Text = LanguageHelper.GetString("btn_Save");
        }
    }
}
