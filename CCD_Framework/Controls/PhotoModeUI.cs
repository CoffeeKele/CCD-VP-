using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using CCD_Framework.Models;
using System.Threading;
using Cognex.VisionPro.Exceptions;
using Microsoft.VisualBasic.CompilerServices;
using CCD_Framework.Helper;

namespace CCD_Framework.Controls
{
    public partial class PhotoModeUI : UserControl
    {
        private PhotoMode photoMode1;
        public PhotoMode PhotoMode1
        {
            get
            {
                return photoMode1;
            }
        }
        private PhotoMode photoMode2;
        public PhotoMode PhotoMode2
        {
            get
            {
                return photoMode2;
            }
        }
        private Queue<CogImage8Grey> Camera1ImageQueue;
        private Queue<CogImage8Grey> Camera2ImageQueue;

        private ICogAcqTrigger AcqTriggerMode1;
        private ICogAcqTrigger AcqTriggerMode2;

        private CogAcqFifoTool AcqFifoTool1;
        private CogAcqFifoTool AcqFifoTool2;

        private MyDisPlayUI MyDisPlayUI1;
        private MyDisPlayUI MyDisPlayUI2;

        private bool IsReal_timeDisplay1;
        private bool IsReal_timeDisplay2;
        public PhotoModeUI(CogAcqFifoTool acqFifoTool1, MyDisPlayUI myDisPlayUI1, CogAcqFifoTool acqFifoTool2, MyDisPlayUI myDisPlayUI2, string name1, string name2)
        {
            InitializeComponent();

            rdoAutoRun1.Checked = true;
            rdoAutoRun2.Checked = true;

            Camera1ImageQueue = new Queue<CogImage8Grey>();
            Camera2ImageQueue = new Queue<CogImage8Grey>();
            AcqFifoTool1 = acqFifoTool1;
            AcqFifoTool2 = acqFifoTool2;
            if (acqFifoTool1.Operator != null)
                AcqTriggerMode1 = acqFifoTool1.Operator.OwnedTriggerParams;
            if (acqFifoTool2.Operator != null)
                AcqTriggerMode2 = acqFifoTool2.Operator.OwnedTriggerParams;
            MyDisPlayUI1 = myDisPlayUI1;
            MyDisPlayUI2 = myDisPlayUI2;
            ReLoadLanguage(name1, name2);
        }

        public void ReLoadLanguage(string name1,string name2)
        {
            if (LanguageHelper.CurrenLan == Language.EN_US)
            {
                this.rdoManualRun1.Left = 90 + 20;
                this.rdoManualRun2.Left = 90 + 20;
                this.btnLiveVideo1.Width = 90 + 60;
                this.btnLiveVideo2.Width = 90 + 60;
                this.btnRun1.Left = 140 + 60;
                this.btnRun2.Left = 140 + 60;
                this.btnRun1.Width = 82 + 48;
                this.btnRun2.Width = 82 + 48;
            }
            else if (LanguageHelper.CurrenLan == Language.ZH_CN)
            {
                this.rdoManualRun1.Left = 90;
                this.rdoManualRun2.Left = 90;
                this.btnLiveVideo1.Width = 90;
                this.btnLiveVideo2.Width = 90;
                this.btnRun1.Left = 140;
                this.btnRun2.Left = 140;
                this.btnRun1.Width = 82;
                this.btnRun2.Width = 82;
            }
            this.groupBox1.Text= name1;
            this.groupBox2.Text = name2;
            this.rdoAutoRun1.Text = LanguageHelper.GetString("pm_Auto");
            this.rdoManualRun1.Text = LanguageHelper.GetString("pm_Manual");
            this.rdoAutoRun2.Text = LanguageHelper.GetString("pm_Auto");
            this.rdoManualRun2.Text = LanguageHelper.GetString("pm_Manual");
            this.btnLiveVideo1.Text = LanguageHelper.GetString("pm_RTD");
            this.btnLiveVideo2.Text = LanguageHelper.GetString("pm_RTD");
            this.btnRun1.Text = LanguageHelper.GetString("pm_Photograph");
            this.btnRun2.Text = LanguageHelper.GetString("pm_Photograph");
        }

        private void rdoManualRun1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoManualRun1.Checked == true)
            {
                try
                {
                    Camera1ImageQueue.Clear();
                    AcqTriggerMode1.TriggerEnabled = false;
                    Thread.Sleep(2);
                    AcqFifoTool1.Operator.Flush();
                    Thread.Sleep(2);
                    AcqTriggerMode1.TriggerEnabled = true;
                    AcqTriggerMode1.TriggerModel = CogAcqTriggerModelConstants.Manual;
                    this.photoMode1 = PhotoMode.Manual;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rdoManualRun2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoManualRun1.Checked == true)
            {
                try
                {
                    Camera2ImageQueue.Clear();
                    AcqTriggerMode2.TriggerEnabled = false;
                    Thread.Sleep(2);
                    AcqFifoTool2.Operator.Flush();
                    Thread.Sleep(2);
                    AcqTriggerMode2.TriggerEnabled = true;
                    AcqTriggerMode2.TriggerModel = CogAcqTriggerModelConstants.Manual;
                    this.photoMode2 = PhotoMode.Manual;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRun1_Click(object sender, EventArgs e)
        {
            if (rdoManualRun1.Checked == true)
            {
                try
                {
                    AcqFifoTool1.Operator.StartAcquire();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRun2_Click(object sender, EventArgs e)
        {
            if (rdoManualRun2.Checked == true)
            {
                try
                {
                    AcqFifoTool2.Operator.StartAcquire();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLiveVideo1_Click(object sender, EventArgs e)
        {
            if (rdoManualRun1.Checked == true)
            {
                if (!this.IsReal_timeDisplay1)
                {
                    try
                    {
                        this.AcqTriggerMode1.TriggerEnabled = false;
                        this.rdoAutoRun1.Checked = false;
                        this.AcqFifoTool1.Operator.Flush();
                        this.AcqTriggerMode1.TriggerModel = CogAcqTriggerModelConstants.Manual;
                        this.AcqTriggerMode1.TriggerEnabled = true;
                        Thread.Sleep(20);
                        MyDisPlayUI mydisplaypenal = this.MyDisPlayUI1;
                        CogAcqFifoTool cogAcqFifoTool = this.AcqFifoTool1;
                        CogAcqFifoTool cogAcqFifoTool1 = cogAcqFifoTool;
                        object @operator = cogAcqFifoTool.Operator;
                        mydisplaypenal.StartLiveDisplay(ref @operator, false);
                        cogAcqFifoTool1.Operator = (ICogAcqFifo)@operator;
                        Application.DoEvents();
                        this.rdoAutoRun1.Enabled = false;
                        this.rdoManualRun1.Enabled = false;
                        this.lblMsg1.Text = LanguageHelper.GetString("pm_Msg1");
                        this.btnLiveVideo1.Text = LanguageHelper.GetString("pm_SR");
                        this.IsReal_timeDisplay1 = true;
                    }
                    catch (CogException cogException)
                    {
                        ProjectData.SetProjectError(cogException);
                        CogException cogex = cogException;
                        MessageBox.Show(cogException.Message, LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ProjectData.ClearProjectError();
                    }
                }
                else if (this.IsReal_timeDisplay1)
                {
                    try
                    {
                        this.rdoAutoRun1.Enabled = true;
                        this.rdoManualRun1.Enabled = true;
                        this.AcqTriggerMode1.TriggerEnabled = false;
                        //DateTime now = DateTime.Now;
                        //this.Str = string.Concat(now.ToString("HH:mm:ss.fff"), "1  ");
                        this.AcqFifoTool1.Operator.Flush();
                        this.AcqTriggerMode1.TriggerEnabled = true;
                        Thread.Sleep(20);
                        this.MyDisPlayUI1.StopLiveDisplay();
                        //now = DateTime.Now;
                        //this.str1 = string.Concat(now.ToString("HH:mm:ss.fff"), "2  ");
                        Thread.Sleep(20);
                        Application.DoEvents();
                        this.lblMsg1.Text = "";
                        this.btnLiveVideo1.Text = LanguageHelper.GetString("pm_SR");
                        this.IsReal_timeDisplay1 = false;
                    }
                    catch (CogException cogException1)
                    {
                        ProjectData.SetProjectError(cogException1);
                        CogException cogex = cogException1;
                        this.lblMsg1.Text = "";
                        this.btnLiveVideo1.Text = LanguageHelper.GetString("pm_RTD");
                        MessageBox.Show(cogException1.Message, LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ProjectData.ClearProjectError();
                    }
                }
            }
        }

        private void btnLiveVideo2_Click(object sender, EventArgs e)
        {
            if (rdoManualRun2.Checked == true)
            {
                if (!this.IsReal_timeDisplay2)
                {
                    try
                    {
                        this.AcqTriggerMode2.TriggerEnabled = false;
                        this.rdoAutoRun2.Checked = false;
                        this.AcqFifoTool2.Operator.Flush();
                        this.AcqTriggerMode2.TriggerModel = CogAcqTriggerModelConstants.Manual;
                        this.AcqTriggerMode2.TriggerEnabled = true;
                        Thread.Sleep(20);
                        MyDisPlayUI mydisplaypenal = this.MyDisPlayUI2;
                        CogAcqFifoTool cogAcqFifoTool = this.AcqFifoTool2;
                        CogAcqFifoTool cogAcqFifoTool2 = cogAcqFifoTool;
                        object @operator = cogAcqFifoTool.Operator;
                        mydisplaypenal.StartLiveDisplay(ref @operator, false);
                        cogAcqFifoTool2.Operator = (ICogAcqFifo)@operator;
                        Application.DoEvents();
                        this.rdoAutoRun2.Enabled = false;
                        this.rdoManualRun2.Enabled = false;
                        this.lblMsg2.Text = LanguageHelper.GetString("pm_Msg1");
                        this.btnLiveVideo2.Text = LanguageHelper.GetString("pm_SR");
                        this.IsReal_timeDisplay2 = true;
                    }
                    catch (CogException cogException)
                    {
                        ProjectData.SetProjectError(cogException);
                        CogException cogex = cogException;
                        MessageBox.Show(cogException.Message, LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ProjectData.ClearProjectError();
                    }
                }
                else if (this.IsReal_timeDisplay2)
                {
                    try
                    {
                        this.rdoAutoRun2.Enabled = true;
                        this.rdoManualRun2.Enabled = true;
                        this.AcqTriggerMode2.TriggerEnabled = false;
                        //DateTime now = DateTime.Now;
                        //this.Str = string.Concat(now.ToString("HH:mm:ss.fff"), "1  ");
                        this.AcqFifoTool2.Operator.Flush();
                        this.AcqTriggerMode2.TriggerEnabled = true;
                        Thread.Sleep(20);
                        this.MyDisPlayUI2.StopLiveDisplay();
                        //now = DateTime.Now;
                        //this.str1 = string.Concat(now.ToString("HH:mm:ss.fff"), "2  ");
                        Thread.Sleep(20);
                        Application.DoEvents();
                        this.lblMsg2.Text = "";
                        this.btnLiveVideo2.Text = LanguageHelper.GetString("pm_RTD");
                        this.IsReal_timeDisplay2 = false;
                    }
                    catch (CogException cogException2)
                    {
                        ProjectData.SetProjectError(cogException2);
                        CogException cogex = cogException2;
                        this.lblMsg2.Text = "";
                        this.btnLiveVideo2.Text = LanguageHelper.GetString("pm_RTD");
                        MessageBox.Show(cogException2.Message, LanguageHelper.GetString("common_Info"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ProjectData.ClearProjectError();
                    }
                }
            }
        }
    }
}
