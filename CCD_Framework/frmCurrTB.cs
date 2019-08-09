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
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CCD_Framework
{
    public partial class frmCurrTB : Form
    {
        public frmCurrTB()
        {
            InitializeComponent();
        }
        public delegate void reLoadTBInspectionHandler(bool hasChange);
        public event reLoadTBInspectionHandler reLoadTBInspection;
        bool hasChange = false;
        string vppPath1 = string.Empty;
        string vppPath2 = string.Empty;
        string vppPath3 = string.Empty;
        string vppPath4 = string.Empty;
        CogImage8Grey inputImage1 = null;
        CogImage8Grey inputImage2 = null;
        CogImage8Grey inputImage3 = null;
        CogImage8Grey inputImage4 = null;
        public frmCurrTB(string TB_Name, string vppPath1, string vppPath2, string vppPath3, string vppPath4, CogImage8Grey inputImage1, CogImage8Grey inputImage2, CogImage8Grey inputImage3, CogImage8Grey inputImage4)
        {
            InitializeComponent();
            this.Text = TB_Name;
            this.vppPath1 = vppPath1;
            this.vppPath2 = vppPath2;
            this.vppPath3 = vppPath3;
            this.vppPath4 = vppPath4;
            this.inputImage1 = inputImage1;
            this.inputImage2 = inputImage2;
            this.inputImage3 = inputImage3;
            this.inputImage4 = inputImage4;
        }

        private void frmCurrTB_Load(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(OpenTB));
            t1.Start();


            this.Text = LanguageHelper.GetString("fctb_Text");
            this.tsmtSave.Text = LanguageHelper.GetString("btn_Save");
            this.tsmtSaveAll.Text = LanguageHelper.GetString("btn_SaveAll");
            this.tabControl1.TabPages[0].Text = LanguageHelper.GetString("fctb_AF") + "1";
            this.tabControl1.TabPages[1].Text = LanguageHelper.GetString("fctb_AF") + "2";
            this.tabControl1.TabPages[2].Text = LanguageHelper.GetString("fctb_AF") + "3";
            this.tabControl1.TabPages[3].Text = LanguageHelper.GetString("fctb_AF") + "4";

        }
        private CogToolBlockEditV2 CogToolBlockEditV21;
        private CogToolBlockEditV2 CogToolBlockEditV22;
        private CogToolBlockEditV2 CogToolBlockEditV23;
        private CogToolBlockEditV2 CogToolBlockEditV24;
        private delegate void openTbHandler();
        private void OpenTB()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new openTbHandler(OpenTB));
            }
            else
            {
                try
                {
                    ToggleBar(true);
                    setBarValue(0);
                    this.menuStrip1.Enabled = false;
                    this.tabControl1.Enabled = false;
                    setBarValue(5);
                    CogToolBlockEditV21 = new CogToolBlockEditV2();
                    CogToolBlockEditV21.Dock = DockStyle.Fill;
                    tabPage1.Controls.Add(CogToolBlockEditV21);
                    setBarValue(10);
                    CogToolBlockEditV22 = new CogToolBlockEditV2();
                    CogToolBlockEditV22.Dock = DockStyle.Fill;
                    tabPage2.Controls.Add(CogToolBlockEditV22);
                    setBarValue(15);
                    CogToolBlockEditV23 = new CogToolBlockEditV2();
                    CogToolBlockEditV23.Dock = DockStyle.Fill;
                    tabPage3.Controls.Add(CogToolBlockEditV23);
                    setBarValue(20);
                    CogToolBlockEditV24 = new CogToolBlockEditV2();
                    CogToolBlockEditV24.Dock = DockStyle.Fill;
                    tabPage4.Controls.Add(CogToolBlockEditV24);
                    setBarValue(25);
                    this.CogToolBlockEditV21.Subject = (CogToolBlock)CogSerializer.LoadObjectFromFile(vppPath1);
                    setBarValue(40);
                    this.CogToolBlockEditV22.Subject = (CogToolBlock)CogSerializer.LoadObjectFromFile(vppPath2);
                    setBarValue(55);
                    this.CogToolBlockEditV23.Subject = (CogToolBlock)CogSerializer.LoadObjectFromFile(vppPath3);
                    setBarValue(70);
                    this.CogToolBlockEditV24.Subject = (CogToolBlock)CogSerializer.LoadObjectFromFile(vppPath4);
                    setBarValue(85);
                    if (inputImage1 != null)
                    {
                        this.CogToolBlockEditV21.Subject.Inputs["InputImage"].Value = inputImage1;
                        this.CogToolBlockEditV21.Subject.Run();
                        CogSerializer.SaveObjectToFile(CogToolBlockEditV21.Subject, vppPath1);
                    }
                    if (inputImage2 != null)
                    {
                        this.CogToolBlockEditV22.Subject.Inputs["InputImage"].Value = inputImage2;
                        this.CogToolBlockEditV22.Subject.Run();
                        CogSerializer.SaveObjectToFile(CogToolBlockEditV22.Subject, vppPath2);
                    }
                    if (inputImage3 != null)
                    {
                        this.CogToolBlockEditV23.Subject.Inputs["InputImage"].Value = inputImage3;
                        this.CogToolBlockEditV23.Subject.Run();
                        CogSerializer.SaveObjectToFile(CogToolBlockEditV23.Subject, vppPath3);
                    }
                    if (inputImage4 != null)
                    {
                        this.CogToolBlockEditV24.Subject.Inputs["InputImage"].Value = inputImage4;
                        this.CogToolBlockEditV24.Subject.Run();
                        CogSerializer.SaveObjectToFile(CogToolBlockEditV24.Subject, vppPath4);
                    }
                    this.menuStrip1.Enabled = true;
                    this.tabControl1.Enabled = true;
                    setBarValue(100);
                    Thread.Sleep(1000);
                    ToggleBar(false);
                }
                catch (Exception ex)
                {
                    this.menuStrip1.Enabled = true;
                    this.tabControl1.Enabled = true;
                    ToggleBar(false);
                    MessageBox.Show(LanguageHelper.GetString("fctb_Msg1"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tsmtSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab.Name == tabPage1.Name)
                {
                    //if (CogToolBlockEditV21.Subject.HasChanged)
                    //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV21.Subject, vppPath1);
                    hasChange = true;
                    //}

                }
                if (tabControl1.SelectedTab.Name == tabPage2.Name)
                {
                    //if (CogToolBlockEditV22.Subject.HasChanged)
                    //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV22.Subject, vppPath2);
                    hasChange = true;
                    //}

                }
                if (tabControl1.SelectedTab.Name == tabPage3.Name)
                {
                    //if (CogToolBlockEditV23.Subject.HasChanged)
                    //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV23.Subject, vppPath3);
                    hasChange = true;
                    //}

                }
                if (tabControl1.SelectedTab.Name == tabPage4.Name)
                {
                    //if (CogToolBlockEditV24.Subject.HasChanged)
                    //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV24.Subject, vppPath4);
                    hasChange = true;
                    //}

                }
                MessageBox.Show(LanguageHelper.GetString("fctb_AF") + LanguageHelper.GetString("common_SaveSuccess"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(LanguageHelper.GetString("fctb_AF") + LanguageHelper.GetString("common_SaveFailed"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsmtSaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CogToolBlockEditV21.Subject.HasChanged)
                //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV21.Subject, vppPath1);
                //    hasChange = true;
                //}

                //if (CogToolBlockEditV22.Subject.HasChanged)
                //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV22.Subject, vppPath2);
                //    hasChange = true;
                //}

                //if (CogToolBlockEditV23.Subject.HasChanged)
                //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV23.Subject, vppPath3);
                //    hasChange = true;
                //}

                //if (CogToolBlockEditV24.Subject.HasChanged)
                //{
                    CogSerializer.SaveObjectToFile(CogToolBlockEditV24.Subject, vppPath4);
                //    hasChange = true;
                //}
                hasChange = true;
                MessageBox.Show(LanguageHelper.GetString("fctb_AF") + LanguageHelper.GetString("common_SaveAllSuccess"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(LanguageHelper.GetString("fctb_AF") + " " + LanguageHelper.GetString("common_SaveFailed"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmCurrTB_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CogToolBlockEditV21.Subject.HasChanged || CogToolBlockEditV22.Subject.HasChanged || CogToolBlockEditV23.Subject.HasChanged || CogToolBlockEditV24.Subject.HasChanged)
            {
                if (
                MessageBox.Show(LanguageHelper.GetString("fctb_Msg2"), LanguageHelper.GetString("common_Info"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (CogToolBlockEditV21.Subject.HasChanged)
                    {
                        CogSerializer.SaveObjectToFile(CogToolBlockEditV21.Subject, vppPath1);
                        hasChange = true;
                    }

                    if (CogToolBlockEditV22.Subject.HasChanged)
                    {
                        CogSerializer.SaveObjectToFile(CogToolBlockEditV22.Subject, vppPath2);
                        hasChange = true;
                    }

                    if (CogToolBlockEditV23.Subject.HasChanged)
                    {
                        CogSerializer.SaveObjectToFile(CogToolBlockEditV23.Subject, vppPath3);
                        hasChange = true;
                    }

                    if (CogToolBlockEditV24.Subject.HasChanged)
                    {
                        CogSerializer.SaveObjectToFile(CogToolBlockEditV24.Subject, vppPath4);
                        hasChange = true;
                    }

                }
            }
            reLoadTBInspection?.Invoke(hasChange);
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private delegate void setBarValueHandler(int pValue);
        public void setBarValue(int pValue)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new setBarValueHandler(setBarValue), new object[] { pValue });
            }
            else
            {
                if (pValue >= 0 & pValue < 100)
                {
                    progressBar1.Value = pValue;
                }
                if (pValue == 100)
                {
                    progressBar1.Value = pValue;
                }
            }
        }
        private delegate void ToggleBarHandler(bool isShow);
        public void ToggleBar(bool isShow)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ToggleBarHandler(ToggleBar), new object[] { isShow });
            }
            else
            {
                if (isShow)
                {
                    progressBar1.Visible = true;
                }
                else
                {
                    progressBar1.Visible = false;
                }
            }
        }
    }
}
