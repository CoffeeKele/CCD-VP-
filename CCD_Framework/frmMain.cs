//#define RecordBeat 
#define FangDai 
using CCD_Framework.Controls;
using CCD_Framework.Helper;
using CCD_Framework.Models;
using CCD_Framework.Properties;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace CCD_Framework
{
    public partial class frmMain : Form
    {

        frmStartBar fSB;
        iniHelper iniHelper = new iniHelper(Application.StartupPath + @"\Config.ini");
        private int RunNum = 0;
        private int RunNum2 = 0;
        private RunningMode runningMode;
        private UploadModeUI uploadMode;
        private UploadModeUI uploadMode2;
        private PhotoModeUI photoMode;
        private PhotoModeUI photoMode2;
        private int AcqNum;
        private PathType AcqPathType;
        private string AcqVppPath;
        private string[] AcqFifoFilePath;
        private string DropDownItemAFName = "编辑相机";
        private CogToolBlock[] TB_Acq;
        private CogAcqFifoTool[] AcqFifoTool;
        private ICogAcqFifo[] AcqFifo;
        private bool[] CameraIsLink;
        private bool[] IsCameraRuning;
        private bool[] IsAcqRuning;

        private int TBInspectionNum;
        private PathType TBInspectionPathType;
        private string TBInspectionVppPath;
        private string[] ToolBlockPath;
        private string DropDownItemQBName = "编辑算法文件";
        private CogToolBlock[] TB_Inspection;

        private int TNum;
        private MyDisPlayUI[] Mydispaly;

        private string guid1 = string.Empty;
        private string guid2 = string.Empty;
        private string curGuid1 = string.Empty;
        private string curGuid2 = string.Empty;
        //相机1拍照存放
        private Queue<CogImage8Grey> Camera1ImageQueue = new Queue<CogImage8Grey>();

        //相机2拍照存放
        private Queue<CogImage8Grey> Camera2ImageQueue = new Queue<CogImage8Grey>();

        //相机3拍照存放
        private Queue<CogImage8Grey> Camera3ImageQueue = new Queue<CogImage8Grey>();

        //相机4拍照存放
        private Queue<CogImage8Grey> Camera4ImageQueue = new Queue<CogImage8Grey>();

        #region 坐标信息
        private Models.Point pointA = new Models.Point();
        private Models.Point pointB = new Models.Point();
        private Line lineAB = new Line();
        //private double pinWidth;
        //private double AreaA;
        //private double AreaB;
        private double PinWidthA;
        private double PinWidthB;
        private double WidthA1;
        private double WidthB1;
        private double WidthA2;
        private double WidthB2;
        private string ImageA1Name;
        private string ImageB1Name;
        private string ImageA2Name;
        private string ImageB2Name;
        private ProdStdData CurrProStdData = new ProdStdData();
        private string CurrProCode;

        #region Add By Duke on 20190608 长度和宽度转换
        private double aL1;
        private double aL2;
        private double aWA1;
        private double aWB1;
        private double aWA2;
        private double aWB2;
        #endregion
        #endregion

#if (RecordBeat)
        private DateTime StartTime;

        private DateTime EndTime1;

        private DateTime EndTime2;
#endif
        LogHelper logHelper = new LogHelper();
        public frmMain()
        {
            InitializeComponent();
            try
            {
                runningMode = (RunningMode)Convert.ToInt32(iniHelper.IniReadValue("SysSeting", "RunningMode"));
                CurrProCode = iniHelper.IniReadValue("SysSeting", "CurrentProductCode");
                AcqNum = Convert.ToInt32(iniHelper.IniReadValue("AcqSeting", "AcqNum"));
                TNum = Convert.ToInt32(iniHelper.IniReadValue("AcqSeting", "TNum"));
                TBInspectionNum = Convert.ToInt32(iniHelper.IniReadValue("TBSeting", "TBInspectionNum"));
                aL1 = Convert.ToDouble(iniHelper.IniReadValue("ProSeting", "aL1"));
                aL2 = Convert.ToDouble(iniHelper.IniReadValue("ProSeting", "aL2"));
                aWA1 = Convert.ToDouble(iniHelper.IniReadValue("ProSeting", "aWA1"));
                aWB1 = Convert.ToDouble(iniHelper.IniReadValue("ProSeting", "aWB1")); ;
                aWA2 = Convert.ToDouble(iniHelper.IniReadValue("ProSeting", "aWA2")); ;
                aWB2 = Convert.ToDouble(iniHelper.IniReadValue("ProSeting", "aWB2")); ;
                //AWidth = Convert.ToDouble(iniHelper.IniReadValue("ProSeting", "AWidth"));
                //BWidth = Convert.ToDouble(iniHelper.IniReadValue("ProSeting", "BWidth"));
                tsmtSetting.Enabled = false;
                tsmtStandardData.Enabled = false;
                tsmtFile.Enabled = false;
            }
            catch
            {
                MessageBox.Show(LanguageHelper.GetString("fm_Msg1"));
                Environment.Exit(0);
            }
            if (TNum <= 0 || TNum > 9)
            {
                MessageBox.Show(LanguageHelper.GetString("fm_Msg2"));
                Environment.Exit(0);
            }
            if (AcqNum > 0 && TBInspectionNum > 0)
            {
                DropDownItemAFName = iniHelper.IniReadValue("AcqSeting", "DropDownItemAFName");
                AcqPathType = (PathType)Convert.ToInt32(iniHelper.IniReadValue("AcqSeting", "AcqPathType"));
                if (AcqPathType == PathType.Relative)
                    AcqVppPath = Application.StartupPath + iniHelper.IniReadValue("AcqSeting", "AcqVppPath");
                else if (AcqPathType == PathType.Absolute)
                    AcqVppPath = iniHelper.IniReadValue("AcqSeting", "AcqVppPath");
                AcqFifoFilePath = new string[AcqNum];
                TB_Acq = new CogToolBlock[AcqNum];
                AcqFifoTool = new CogAcqFifoTool[AcqNum];
                AcqFifo = new ICogAcqFifo[AcqNum];
                CameraIsLink = new bool[AcqNum];
                IsCameraRuning = new bool[AcqNum];
                IsAcqRuning = new bool[AcqNum];

                DropDownItemQBName = iniHelper.IniReadValue("TBSeting", "DropDownItemQBName");
                TBInspectionPathType = (PathType)Convert.ToInt32(iniHelper.IniReadValue("TBSeting", "TBInspectionPathType"));
                if (TBInspectionPathType == PathType.Relative)
                    TBInspectionVppPath = Application.StartupPath + iniHelper.IniReadValue("TBSeting", "TBInspectionVppPath");
                else if (TBInspectionPathType == PathType.Absolute)
                    TBInspectionVppPath = iniHelper.IniReadValue("TBSeting", "TBInspectionVppPath");
                TB_Inspection = new CogToolBlock[TBInspectionNum];
                ToolBlockPath = new string[TBInspectionNum];


                Mydispaly = new MyDisPlayUI[TNum];
            }
            else
            {
                MessageBox.Show(LanguageHelper.GetString("fm_Msg3"));
                Environment.Exit(0);
            }

            InitDisplay();
        }

        public delegate void LoadBarHandler();
        private void frmMain_Load(object sender, EventArgs e)
        {
            var CurrentProcess = Process.GetCurrentProcess();
            CurrentProcess.PriorityClass = ProcessPriorityClass.High;
            this.Hide();
            fSB = new frmStartBar(this);
            fSB.Show();
            LoadBarHandler handler = new LoadBarHandler(LoadBarData);
            handler.BeginInvoke(null, null);
            //Thread ts = new Thread(new ThreadStart(LoadBarData));
            //ts.Start();
            try
            {
                var language = (Language)Convert.ToInt32(iniHelper.IniReadValue("SysSeting", "Language"));
                ReLoadLanguage(language);
            }
            catch
            {
                iniHelper.IniWriteValue("SysSeting", "Language", ((int)Language.EN_US).ToString());
                ReLoadLanguage(0);
            }
        }

        private void ReLoadLanguage(Language language)
        {
            if (language == Language.EN_US)
            {
                LanguageHelper.CurrenLan = Language.EN_US;
                rdoMd.Left = 110 + 80;
                lblResultPoint.Left = 96 + 90;
                lblResultAngle.Left = 96 + 90;
                lblRunNum.Left = 96 + 90;
                lblResult.Left = 263 + 90;
                rdoMd2.Left = 110 + 80;
                lblResultPoint2.Left = 96 + 90;
                lblResultAngle2.Left = 96 + 90;
                lblRunNum2.Left = 96 + 90;
                lblResult2.Left = 263 + 90;
                lblProdName.Left = 78 + 90;
                lblStdMidPoint.Left = 78 + 90;
                lblStdMidPoint2.Left = 78 + 90;
                lblStdXOffset.Left = 78 + 90;
                lblStdYOffset.Left = 78 + 90;
                label13.Left = 214 + 90;
                label11.Left = 214 + 90;
                label20.Left = 214 + 90;
                lblStdAngle.Left = 303 + 90;
                lblStdAngle2.Left = 303 + 90;
                lblStdAngleOffset.Left = 303 + 90;
                lblPointA.Left = 78 + 60;
                lblMidPoint.Left = 78 + 60;
                lblWidthA.Left = 78 + 60;
                label6.Left = 214 + 60;
                label9.Left = 214 + 60;
                label18.Left = 214 + 60;
                lblPointB.Left = 280 + 110;
                lblAngle.Left = 280 + 110;
                lblWidthB.Left = 280 + 110;
                _lblResultPoint.Left = 113 + 90;
                _lblResultAngle.Left = 113 + 90;
                _lblRunNum.Left = 113 + 90;
                _lblResult.Left = 276 + 90;
                lblPointA2.Left = 78 + 60;
                lblMidPoint2.Left = 78 + 60;
                lblWidthA2.Left = 78 + 60;
                label39.Left = 214 + 60;
                label35.Left = 214 + 60;
                label31.Left = 214 + 60;
                lblPointB2.Left = 280 + 110;
                lblAngle2.Left = 280 + 110;
                lblWidthB2.Left = 280 + 110;
                _lblResultPoint2.Left = 113 + 90;
                _lblResultAngle2.Left = 113 + 90;
                _lblRunNum2.Left = 113 + 90;
                _lblResult2.Left = 276 + 90;
            }
            else if (language == Language.ZH_CN)
            {
                LanguageHelper.CurrenLan = Language.ZH_CN;
                rdoMd.Left = 110;
                lblResultPoint.Left = 96;
                lblResultAngle.Left = 96;
                lblRunNum.Left = 96;
                lblResult.Left = 263;
                rdoMd2.Left = 110;
                lblResultPoint2.Left = 96;
                lblResultAngle2.Left = 96;
                lblRunNum2.Left = 96;
                lblResult2.Left = 263;
                lblProdName.Left = 78;
                lblStdMidPoint.Left = 78;
                lblStdMidPoint2.Left = 78;
                lblStdXOffset.Left = 78;
                lblStdYOffset.Left = 78;
                label13.Left = 214;
                label11.Left = 214;
                label20.Left = 214;
                lblStdAngle.Left = 303;
                lblStdAngle2.Left = 303;
                lblStdAngleOffset.Left = 303;
                lblPointA.Left = 78;
                lblMidPoint.Left = 78;
                lblWidthA.Left = 78;
                label6.Left = 214;
                label9.Left = 214;
                label18.Left = 214;
                lblPointB.Left = 280;
                lblAngle.Left = 280;
                lblWidthB.Left = 280;
                _lblResultPoint.Left = 113;
                _lblResultAngle.Left = 113;
                _lblRunNum.Left = 113;
                _lblResult.Left = 276;
                lblPointA2.Left = 78;
                lblMidPoint2.Left = 78;
                lblWidthA2.Left = 78;
                label39.Left = 214;
                label35.Left = 214;
                label31.Left = 214;
                lblPointB2.Left = 280;
                lblAngle2.Left = 280;
                lblWidthB2.Left = 280;
                _lblResultPoint2.Left = 113;
                _lblResultAngle2.Left = 113;
                _lblRunNum2.Left = 113;
                _lblResult2.Left = 276;
            }
            Text = LanguageHelper.GetString("frmMain_Text");
            tsmtLogin.Text = LanguageHelper.GetString("fm_menu_PL");
            tsmtFile.Text = LanguageHelper.GetString("fm_menu_Files");
            tsmtAddTB.Text = LanguageHelper.GetString("fm_menu_File1");
            tsmtSwitchTB.Text = LanguageHelper.GetString("fm_menu_File2");
            tsmtCurrTB.Text = LanguageHelper.GetString("fm_menu_File3");
            tsmtEditTB.Text = LanguageHelper.GetString("fm_menu_File4");
            tsmtImageSave.Text = LanguageHelper.GetString("fm_ImageSave");
            tsmtSetting2.Text = LanguageHelper.GetString("fm_Algorithm");
            tsmtSetting.Text = LanguageHelper.GetString("fm_CPS");
            tsmtStandardData.Text = LanguageHelper.GetString("fm_SDC");
            tsmtSysSetting.Text = LanguageHelper.GetString("fm_SS");
            关于ToolStripMenuItem1.Text = LanguageHelper.GetString("fm_About");
            tsmtHelp.Text = LanguageHelper.GetString("fm_Help");

            tabControl1.TabPages[0].Text = LanguageHelper.GetString("fm_OR");
            groupBox7.Text = LanguageHelper.GetString("fm_OR1");
            groupBox8.Text = LanguageHelper.GetString("fm_OR2");
            rdoCd.Text = LanguageHelper.GetString("fm_RC");
            rdoCd2.Text = LanguageHelper.GetString("fm_RC");
            rdoMd.Text = LanguageHelper.GetString("fm_PC");
            rdoMd2.Text = LanguageHelper.GetString("fm_PC");
            label7.Text = LanguageHelper.GetString("fm_XYC");
            label26.Text = LanguageHelper.GetString("fm_XYC");
            label17.Text = LanguageHelper.GetString("fm_AC");
            label24.Text = LanguageHelper.GetString("fm_AC");
            label15.Text = LanguageHelper.GetString("fm_OT");
            label28.Text = LanguageHelper.GetString("fm_OT");
            cbSendWLdata1.Text = LanguageHelper.GetString("fm_SWL");
            cbSendWLdata2.Text = LanguageHelper.GetString("fm_SWL");

            tabControl1.TabPages[1].Text = LanguageHelper.GetString("fm_RS");
            groupBox1.Text = LanguageHelper.GetString("fm_CPSI");
            label16.Text = LanguageHelper.GetString("fm_PN");
            lable11.Text = LanguageHelper.GetString("fm_Mid1");
            label19.Text = LanguageHelper.GetString("fm_Mid2");
            label12.Text = LanguageHelper.GetString("fm_XDL");
            label22.Text = LanguageHelper.GetString("fm_YDL");
            label20.Text = LanguageHelper.GetString("fm_AL");

            tabControl2.TabPages[0].Text = LanguageHelper.GetString("fm_LRS");
            groupBox6.Text = LanguageHelper.GetString("fm_ACI");
            label4.Text = LanguageHelper.GetString("fm_PA");
            label6.Text = LanguageHelper.GetString("fm_PB");
            label8.Text = LanguageHelper.GetString("fm_PM");

            groupBox10.Text = LanguageHelper.GetString("fm_OR");
            label46.Text = LanguageHelper.GetString("fm_XYC");
            label44.Text = LanguageHelper.GetString("fm_AC");
            label48.Text = LanguageHelper.GetString("fm_OT");


            tabControl2.TabPages[1].Text = LanguageHelper.GetString("fm_RRS");
            groupBox9.Text = LanguageHelper.GetString("fm_ACI");
            label41.Text = LanguageHelper.GetString("fm_PA");
            label39.Text = LanguageHelper.GetString("fm_PB");
            label37.Text = LanguageHelper.GetString("fm_PM");

            groupBox11.Text = LanguageHelper.GetString("fm_OR");
            label54.Text = LanguageHelper.GetString("fm_XYC");
            label52.Text = LanguageHelper.GetString("fm_AC");
            label56.Text = LanguageHelper.GetString("fm_OT");


            tabControl1.TabPages[2].Text = LanguageHelper.GetString("fm_TCP_Comm");
            groupBox3.Text = LanguageHelper.GetString("fm_CD");
            groupBox4.Text = LanguageHelper.GetString("fm_Rec");
            groupBox5.Text = LanguageHelper.GetString("fm_Send");

            tabControl1.TabPages[3].Text = LanguageHelper.GetString("fm_TCP_Conn");
            groupBox2.Text = LanguageHelper.GetString("fm_ConnDetails");

            ToolStripStatusLabel2.Text = LanguageHelper.GetString("fm_OAS");
        }

        public void LoadBarData()
        {
            fSB.setBarValue(2, LanguageHelper.GetString("fm_Msg4"));
            CheckAcqVppPath();
            for (var index = 0; index < AcqNum; index++)
            {
                fSB.setBarValue((2 + 30 / AcqNum) * index, LanguageHelper.GetString("fm_Msg5") + (index + 1).ToString());
                LoadTB_Acq(index);
            }
            fSB.setBarValue(2, LanguageHelper.GetString("fm_Msg6"));
            CheckInspectionVppPath();
            for (var index = 0; index < TBInspectionNum; index++)
            {
                fSB.setBarValue(34 + (30 / TBInspectionNum) * index, LanguageHelper.GetString("fm_Msg7") + (index + 1).ToString());
                LoadTB_Inspection(index);
            }
            fSB.setBarValue(70, LanguageHelper.GetString("fm_Msg8"));
            JudgementCameraLinked();
            fSB.setBarValue(72, LanguageHelper.GetString("fm_Msg9"));
            LoadSettingList();
            fSB.setBarValue(74, LanguageHelper.GetString("fm_Msg10"));
            InitRunMode();
            fSB.setBarValue(76, LanguageHelper.GetString("fm_Msg11"));
            InitTCP();
            fSB.setBarValue(84, LanguageHelper.GetString("fm_Msg12"));
            LoadXMLData();
            fSB.setBarValue(100, LanguageHelper.GetString("fm_Msg13"));
            Thread.Sleep(800);
            fSB.showMain();
            //TClient.Send("OK");
            SendInfo("OK");

        }

        /// <summary>
        /// 加载拍照界面
        /// </summary>
        public delegate void InitDisplayHandler();
        public void InitDisplay()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new InitDisplayHandler(InitDisplay));
            }
            else
            {
                var col = (int)Math.Sqrt(TNum);
                var row = col;
                if (col < Math.Sqrt(TNum))
                {
                    col++;
                    row = (int)TNum / col;
                    if (row < Math.Round(TNum / (decimal)col, 2))
                    {
                        row++;
                    }
                }


                tableLayoutPanel1.RowCount = row;
                for (int i = 0; i < row; i++)
                {
                    tableLayoutPanel1.RowStyles[i].SizeType = SizeType.Percent;
                    tableLayoutPanel1.RowStyles[i].Height = tableLayoutPanel1.Height / row;
                }
                tableLayoutPanel1.ColumnCount = col;
                for (int i = 0; i < col; i++)
                {
                    tableLayoutPanel1.ColumnStyles[i].SizeType = SizeType.Percent;
                    tableLayoutPanel1.ColumnStyles[i].Width = tableLayoutPanel1.Width / col;
                }
                var index = 0;
                var cameraNum = 0;
                for (var i = 0; i < row; i++)
                {
                    for (var j = 0; j < col; j++)
                    {
                        if (index < TNum)
                        {
                            if (index == 0) cameraNum = 2;
                            else if (index == 1) cameraNum = 4;
                            else if (index == 2) cameraNum = 1;
                            else if (index == 3) cameraNum = 3;

                            Mydispaly[index] = new MyDisPlayUI(cameraNum);
                            Mydispaly[index].Dock = DockStyle.Fill;
                            tableLayoutPanel1.Controls.Add(Mydispaly[index], j, i);
                        }
                        index++;
                    }
                }
            }
        }

        public delegate void InitRunModeHandler();
        public void InitRunMode()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new InitRunModeHandler(InitRunMode));
            }
            else
            {
                panel5.Controls.Clear();
                panel5.Visible = true;
                panel7.Controls.Clear();
                panel7.Visible = true;
                if (runningMode == RunningMode.Upload)
                {
                    uploadMode = new UploadModeUI(LanguageHelper.GetString("fm_Camera") + "1", LanguageHelper.GetString("fm_Camera") + "2");
                    uploadMode.uploadRun1 += new UploadModeUI.uploadRun1Handler(UpLoadRun1);
                    uploadMode.uploadRun2 += new UploadModeUI.uploadRun2Handler(UpLoadRun2);
                    uploadMode.Dock = DockStyle.Fill;
                    panel5.Text = LanguageHelper.GetString("fm_UPM");
                    panel5.Controls.Add(uploadMode);

                    uploadMode2 = new UploadModeUI(LanguageHelper.GetString("fm_Camera") + "3", LanguageHelper.GetString("fm_Camera") + "4");
                    uploadMode2.uploadRun1 += new UploadModeUI.uploadRun1Handler(UpLoadRun3);
                    uploadMode2.uploadRun2 += new UploadModeUI.uploadRun2Handler(UpLoadRun4);
                    uploadMode2.Dock = DockStyle.Fill;
                    panel7.Text = LanguageHelper.GetString("fm_UPM");
                    panel7.Controls.Add(uploadMode2);
                }
                else if (runningMode == RunningMode.Photo)
                {
                    photoMode = new PhotoModeUI(AcqFifoTool[0], Mydispaly[2], AcqFifoTool[1], Mydispaly[0], LanguageHelper.GetString("fm_Camera") + "1", LanguageHelper.GetString("fm_Camera") + "2");
                    photoMode.Dock = DockStyle.Fill;
                    panel5.Text = LanguageHelper.GetString("fm_CPM");
                    panel5.Controls.Add(photoMode);

                    photoMode2 = new PhotoModeUI(AcqFifoTool[2], Mydispaly[3], AcqFifoTool[3], Mydispaly[1], LanguageHelper.GetString("fm_Camera") + "3", LanguageHelper.GetString("fm_Camera") + "4");
                    photoMode2.Dock = DockStyle.Fill;
                    panel7.Text = LanguageHelper.GetString("fm_CPM");
                    panel7.Controls.Add(photoMode2);
                }
                else
                {
                    panel5.Visible = false;
                    panel7.Visible = false;
                }


            }
        }
        private delegate void loadSettingHandler();
        /// <summary>
        /// 加载设置的下拉选项
        /// </summary>
        public void LoadSettingList()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new loadSettingHandler(LoadSettingList));
            }
            else
            {
                for (var index = 0; index < AcqNum; index++)
                {
                    tsmtSetting.DropDownItems.Add(DropDownItemAFName + (index + 1).ToString());
                    tsmtSetting.DropDownItems[index].Click += new EventHandler(AcqFifoSetting);
                }
                for (var index = 0; index < TBInspectionNum; index++)
                {
                    tsmtSetting2.DropDownItems.Add(DropDownItemQBName + (index + 1).ToString());
                    tsmtSetting2.DropDownItems[index].Click += new EventHandler(QuickBuildSetting);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CheckAcqVppPath()
        {

            if (!Directory.Exists(AcqVppPath))
            {
                Directory.CreateDirectory(AcqVppPath);
            }
        }

        /// <summary>
        /// 加载相机设置所在的CogToolBlock VPP文件
        /// </summary>
        /// <param name="index"></param>
        public void LoadTB_Acq(int index)
        {


            AcqFifoFilePath[index] = AcqVppPath + @"\Acq" + index.ToString() + ".vpp";
            if (!File.Exists(AcqFifoFilePath[index]))
            {
                MessageBox.Show("Acq" + index.ToString() + ".vpp" + LanguageHelper.GetString("fm_Msg14"));
                Environment.Exit(0);
            }
            TB_Acq[index] = (CogToolBlock)Cognex.VisionPro.CogSerializer.LoadObjectFromFile(AcqFifoFilePath[index]);
        }

        public void CheckInspectionVppPath()
        {
            var vppPath = Path.Combine(TBInspectionVppPath, CurrProCode);
            if (!Directory.Exists(vppPath))
            {
                Directory.CreateDirectory(vppPath);
            }
        }
        /// <summary>
        /// 加载算法所在的CogToolBlock VPP文件
        /// </summary>
        /// <param name="index"></param>
        public void LoadTB_Inspection(int index)
        {
            var vppPath = Path.Combine(TBInspectionVppPath, CurrProCode);
            ToolBlockPath[index] = vppPath + @"\TB_Inspection" + index.ToString() + ".vpp";
            if (!File.Exists(ToolBlockPath[index]))
            {
                MessageBox.Show(CurrProCode.ToString() + "TB_Inspection" + index.ToString() + ".vpp " + LanguageHelper.GetString("fm_Msg15"));
                Environment.Exit(0);
            }
            TB_Inspection[index] = (CogToolBlock)Cognex.VisionPro.CogSerializer.LoadObjectFromFile(ToolBlockPath[index]);
        }
        /// <summary>
        /// 显示可以编辑相机设置所在的CogToolBlock的界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcqFifoSetting(object sender, object e)
        {
            var dropDownItem = (ToolStripDropDownItem)sender;

            for (var index = 0; index < AcqNum; index++)
            {
                if (dropDownItem.Text.Equals(DropDownItemAFName + (index + 1).ToString()))
                {
                    frmAcqFifo frmAF = new frmAcqFifo(AcqFifoTool[index], index);
                    frmAF.saveAcqFifo += new frmAcqFifo.saveTBAcqHandler(SaveAcqFifoTool);
                    frmAF.ShowDialog();
                }
            }
        }
        private void SaveAcqFifoTool(int index, ICogAcqFifo ICogAcqFifo)
        {
            AcqFifo[index] = ICogAcqFifo;
            CogSerializer.SaveObjectToFile(TB_Acq[index], AcqFifoFilePath[index]);

        }
        /// <summary>
        /// 显示可以编辑算法所在的CogToolBlock的界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickBuildSetting(object sender, object e)
        {
            try
            {
                var dropDownItem = (ToolStripDropDownItem)sender;

                for (var index = 0; index < TBInspectionNum; index++)
                {
                    if (dropDownItem.Text.Equals(DropDownItemQBName + (index + 1).ToString()))
                    {
                        var inputImage = TB_Inspection[index].Inputs["InputImage"].Value;
                        frmQuickBuild frmQB = new frmQuickBuild(ToolBlockPath[index], index, (CogImage8Grey)inputImage);
                        //frmQuickBuild frmQB = new frmQuickBuild(TB_Inspection[index], index);
                        frmQB.saveTBInspection += new frmQuickBuild.saveTBInspectionHandler(SaveTBInspection);
                        frmQB.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void SaveTBInspection(int index, CogToolBlock cogToolBlock)
        {
            TB_Inspection[index] = cogToolBlock;
            CogSerializer.SaveObjectToFile(TB_Inspection[index], ToolBlockPath[index]);

        }
        /// <summary>
        /// 界面大小调整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_SizeChanged(object sender, EventArgs e)
        {

        }

        private int LockID = 502143588;
        private void CheckLock()
        {
            var myLock = new AppLock();
            var lockResult = myLock.CheckAppLock(LockID);
            if (lockResult == 0)
            {
                MessageBox.Show("请确认软件许可证是否授权");
            }
        }

        #region 判断相机是否连接
        public delegate void JudgementCameraLinkedHandler();
        private void JudgementCameraLinked()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new JudgementCameraLinkedHandler(JudgementCameraLinked));
            }
            else
            {
                var cameraLinkNum = 0;
                var cameraName = string.Empty;
                for (var index = 0; index < AcqNum; index++)
                {
                    AcqFifoTool[index] = (CogAcqFifoTool)TB_Acq[index].Tools["CogAcqFifoTool1"];
                    AcqFifo[index] = AcqFifoTool[index].Operator;
                    try
                    {
                        if (!string.IsNullOrEmpty(AcqFifo[index].FrameGrabber.Name))
                        {
                            cameraLinkNum++;
                            CameraIsLink[index] = true;
                        }
                        else CameraIsLink[index] = false;
                    }
                    catch
                    {
                        CameraIsLink[index] = false;
                    }


                }
                if (cameraLinkNum == AcqNum)
                {
                    ToolStripStatusLabel1.Text = LanguageHelper.GetString("fm_Msg16");
                    ToolStripStatusLabel1.BackColor = Color.GhostWhite;
                    ToolStripStatusLabel1.LinkColor = Color.Green;
                    ToolStripStatusLabel1.ActiveLinkColor = Color.Green;
                }
                else
                {
                    for (var index = 0; index < AcqNum; index++)
                    {

                        if (CameraIsLink[index] == false)
                        {
                            cameraName += (index + 1).ToString() + ",";
                        }

                    }
                    cameraName = cameraName.Remove(cameraName.Length - 1, 1);
                    ToolStripStatusLabel1.Text = LanguageHelper.GetString("fm_Camera") + cameraName + LanguageHelper.GetString("fm_Msg17");
                    ToolStripStatusLabel1.BackColor = Color.Yellow;
                    ToolStripStatusLabel1.LinkColor = Color.Red;
                    ToolStripStatusLabel1.ActiveLinkColor = Color.Red;
                }
                #region Required Coding Adding eventHandler about camera completed shooting 
                if (AcqFifoTool[0].Operator != null)
                    AcqFifoTool[0].Operator.Complete += new CogCompleteEventHandler(Camera1Acq_compeletevent);
                if (AcqFifoTool[1].Operator != null)
                    AcqFifoTool[1].Operator.Complete += new CogCompleteEventHandler(Camera2Acq_compeletevent);
                if (AcqFifoTool[2].Operator != null)
                    AcqFifoTool[2].Operator.Complete += new CogCompleteEventHandler(Camera3Acq_compeletevent);
                if (AcqFifoTool[3].Operator != null)
                    AcqFifoTool[3].Operator.Complete += new CogCompleteEventHandler(Camera4Acq_compeletevent);
                #endregion

            }

        }
        #endregion

        #region 触发相机拍照
        public void AcqRun(int index)
        {
            if (!IsAcqRuning[index])
            {
                IsAcqRuning[index] = true;
                try
                {
                    AcqFifoTool[index].Run();
                }
                catch
                {
                    //相机触发失效
                    IsAcqRuning[index] = false;
                }
            }
            else
            {
                //相机触发太快
                IsAcqRuning[index] = false;
            }
        }
        #endregion

        #region 相机拍完照后执行下面方法

        private bool TBOneIsRunOK = false;
        private bool TBTwoIsRunOK = false;
        private bool TBOneIsRun = false;
        private bool TBTwoIsRun = false;
        private bool TBThreeIsRunOK = false;
        private bool TBFourIsRunOK = false;
        private bool TBThreeIsRun = false;
        private bool TBFourIsRun = false;
        private int camAcqNum = 0;
        private void Camera1Acq_compeletevent(object sender, CogCompleteEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CogCompleteEventHandler(Camera1Acq_compeletevent), new object[] { sender, e });
            }
            else
            {
#if (RecordBeat)
                EndTime1 = DateTime.Now;
#endif
                //logHelper.WriteLog("相机拍照结束触发事件记录", "相机1拍照触发事件");
                var numPending = 0;
                var numReady = 0;
                var busy = false;
                AcqFifoTool[0].Operator.GetFifoState(out numPending, out numReady, out busy);
                if (numReady > 0)
                {
                    var info = new CogAcqInfo();
                    var _Image = (CogImage8Grey)AcqFifo[0].CompleteAcquireEx(info);
                    Camera1ImageQueue.Enqueue(_Image);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ToolBlock1Run));

                }
                IsAcqRuning[0] = false;
                camAcqNum += 1;
                if (camAcqNum > 4)
                {
                    GC.Collect();
                    camAcqNum = 0;
                }
            }

        }
        private void Cam1_DisplayImage(object sender)
        {
            //var CogImage = (CogImage8Grey)sender;
            Mydispaly[2].CogRecordDisplay1.InteractiveGraphics.Clear();
            Mydispaly[2].CogRecordDisplay1.Record = (ICogRecord)sender;
            //Mydispaly[0].CogRecordDisplay1.Record
            //Mydispaly[0].Image = CogImage;
            Mydispaly[2].Fit();

        }
        private void ToolBlock1Run(object sender)
        {
            var inputImage = Camera1ImageQueue.Dequeue();
            toolBlock1Run(inputImage, false);
        }

        private void toolBlock1Run(CogImage8Grey inputImage, bool isLocalRun)
        {
            curGuid1 = guid1;
            bool wNG = false;
            TBOneIsRun = false;
            TBOneIsRunOK = false;
            //算法文件输入项
            TB_Inspection[0].Inputs["InputImage"].Value = inputImage;
            TB_Inspection[0].Run();
            var record = TB_Inspection[0].CreateLastRunRecord().SubRecords[1];
            ImageA1Name = "A" + DateTime.Now.ToString("yyyyMMddHHmmss");
            var runStatus = TB_Inspection[0].RunStatus;
            if (runStatus.Result == CogToolResultConstants.Accept)
            {
                pointA.PointX = (float)Convert.ToDouble(TB_Inspection[0].Outputs["X"].Value);
                pointA.PointY = (float)Convert.ToDouble(TB_Inspection[0].Outputs["Y"].Value);
                SetLabelOK(lblPointA);
                SetLabelText(lblPointA, pointA.PointX.ToString() + "," + pointA.PointY.ToString());
                PinWidthA = Math.Round(Convert.ToDouble(TB_Inspection[0].Outputs["PinWidth"].Value), 3);
                //AreaA = Math.Round(Convert.ToDouble(TB_Inspection[0].Outputs["Area"].Value), 3);
                //SetLabelText(lblAreaA, AreaA.ToString());
                WidthA1 = Math.Round(CurrProStdData.GetWidthA1(aWA1, Math.Round(Convert.ToDouble(TB_Inspection[0].Outputs["Distance"].Value), 3)), 3);

                SetLabelText(lblWidthA, WidthA1.ToString());
                if (CurrProStdData.WidthA1 != 0 && CurrProStdData.WidthA1Limits != 0)
                {
                    if (Math.Abs(WidthA1 - CurrProStdData.WidthA1) > CurrProStdData.WidthA1Limits)
                    {
                        imageSaveHerper.SaveImage(inputImage, ImageA1Name + "_W_NG");
                        wNG = true;
                        LogHelper.Instance.WriteLog("NG记录(NG Record)", "NG(Width) " + LanguageHelper.GetString("fm_Camera") + "1 " + LanguageHelper.GetString("fm_WNG") + " Image:" + ImageA1Name + "_W_NG");

#if (FangDai)
                        ShowNG(LanguageHelper.GetString("fm_Camera") + "1 " + LanguageHelper.GetString("fm_WNG"));

                        //                       var msg = string.Format("Image" + "\r\n" +
                        //"[X:{0}; Y:{1}; A:{2}; ATTR:{3}; ID:{4}]" + "\r\n" +
                        //"Done", 0, 0, 0, 0, 2);
                        //if (cbSendWLdata1.Checked)
                        //    sendData(msg);
#endif
                    }
                    else
                    {
                        TBOneIsRunOK = true;
                    }
                }
                else
                {
                    TBOneIsRunOK = true;
                }

                if (isLocalRun) uploadMode.SetResult1(RunResult.OK);
                if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveCorrectImage)
                    imageSaveHerper.SaveImage(inputImage, ImageA1Name + "OK");

            }
            else if (runStatus.Result == CogToolResultConstants.Error)
            {
                if (runStatus.Message.Contains("FindPointA"))
                {
                    SetLabelNG(lblPointA);
                    SetLabelNG(lblMidPoint);
                    SetLabelNG(lblAngle);
                    ShowNG(LanguageHelper.GetString("fm_Camera") + "1 " + LanguageHelper.GetString("fm_Msg18"));
                }
                else if (runStatus.Message.Contains("FindLead"))
                {
                    pointA.PointX = (float)Convert.ToDouble(TB_Inspection[0].Outputs["X"].Value);
                    pointA.PointY = (float)Convert.ToDouble(TB_Inspection[0].Outputs["Y"].Value);
                    SetLabelText(lblPointA, pointA.PointX.ToString() + "," + pointA.PointY.ToString());
                    PinWidthA = 0;
                    ShowNG(LanguageHelper.GetString("fm_Camera") + "1 " + LanguageHelper.GetString("fm_Msg19"));
                    TBOneIsRunOK = true;
                }
                if (isLocalRun) uploadMode.SetResult1(RunResult.NG);
                //sendNG();
                if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveErrorImage)
                    imageSaveHerper.SaveImage(inputImage, ImageA1Name + "NG");
            }
            if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveAllImage)
            {

                if (runStatus.Result == CogToolResultConstants.Accept && !wNG)
                    imageSaveHerper.SaveImage(inputImage, ImageA1Name + "OK");
                else
                    imageSaveHerper.SaveImage(inputImage, ImageA1Name + "NG");
            }

            TBOneIsRun = true;
            GetMidPoint("pos1");
            ThreadPool.QueueUserWorkItem(new WaitCallback(Cam1_DisplayImage), record);
        }

        private void Camera2Acq_compeletevent(object sender, CogCompleteEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CogCompleteEventHandler(Camera2Acq_compeletevent), new object[] { sender, e });
            }
            else
            {
#if (RecordBeat)
                EndTime2 = DateTime.Now;
#endif
                //logHelper.WriteLog("相机拍照结束触发事件记录", "相机2拍照触发事件");
                var numPending = 0;
                var numReady = 0;
                var busy = false;
                AcqFifoTool[1].Operator.GetFifoState(out numPending, out numReady, out busy);
                if (numReady > 0)
                {
                    var info = new CogAcqInfo();
                    var _Image = (CogImage8Grey)AcqFifo[1].CompleteAcquireEx(info);
                    Camera2ImageQueue.Enqueue(_Image);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ToolBlock2Run));
                }
                IsAcqRuning[1] = false;
                camAcqNum += 1;
                if (camAcqNum > 4)
                {
                    GC.Collect();
                    camAcqNum = 0;
                }
            }
        }
        private void Cam2_DisplayImage(object sender)
        {
            //var CogImage = (CogImage8Grey)sender;
            Mydispaly[0].CogRecordDisplay1.InteractiveGraphics.Clear();
            Mydispaly[0].CogRecordDisplay1.Record = (ICogRecord)sender;
            //Mydispaly[1].Image = CogImage;
            Mydispaly[0].Fit();
        }
        private void ToolBlock2Run(object sender)
        {
            var inputImage = Camera2ImageQueue.Dequeue();
            toolBlock2Run(inputImage, false);
        }

        private void toolBlock2Run(CogImage8Grey inputImage, bool isLocalRun)
        {
            bool wNG = false;
            TBTwoIsRun = false;
            TBTwoIsRunOK = false;
            //算法文件输入项
            TB_Inspection[1].Inputs["InputImage"].Value = inputImage;
            TB_Inspection[1].Run();
            var record = TB_Inspection[1].CreateLastRunRecord().SubRecords[1];
            ImageB1Name = "B" + DateTime.Now.ToString("yyyyMMddHHmmss");
            var runStatus = TB_Inspection[1].RunStatus;
            if (runStatus.Result == CogToolResultConstants.Accept)
            {
                pointB.PointX = (float)Convert.ToDouble(TB_Inspection[1].Outputs["X"].Value);
                pointB.PointY = (float)Convert.ToDouble(TB_Inspection[1].Outputs["Y"].Value);
                SetLabelOK(lblPointB);
                SetLabelText(lblPointB, pointB.PointX.ToString() + "," + pointB.PointY.ToString());
                PinWidthB = Math.Round((double)TB_Inspection[1].Outputs["PinWidth"].Value, 3);
                WidthB1 = Math.Round(CurrProStdData.GetWidthB1(aWB1, Math.Round(Convert.ToDouble(TB_Inspection[1].Outputs["Distance"].Value), 3)), 3);

                SetLabelText(lblWidthB, WidthB1.ToString());
                if (CurrProStdData.WidthB1 != 0 && CurrProStdData.WidthB1Limits != 0)
                {
                    if (Math.Abs(WidthB1 - CurrProStdData.WidthB1) > CurrProStdData.WidthB1Limits)
                    {
                        imageSaveHerper.SaveImage(inputImage, ImageB1Name + "_W_NG");
                        wNG = true;
                        LogHelper.Instance.WriteLog("NG记录(NG Record)", "NG(Width) " + LanguageHelper.GetString("fm_Camera") + "2 " + LanguageHelper.GetString("fm_WNG") + " Image:" + ImageB1Name + "_W_NG");

#if (FangDai)
                        ShowNG(LanguageHelper.GetString("fm_Camera") + "2 " + LanguageHelper.GetString("fm_WNG"));
                        //                        var msg = string.Format("Image" + "\r\n" +
                        //"[X:{0}; Y:{1}; A:{2}; ATTR:{3}; ID:{4}]" + "\r\n" +
                        //"Done", 0, 0, 0, 0, 2);
                        //if (cbSendWLdata1.Checked)
                        //    sendData(msg);
#endif
                    }
                    else
                    {
                        TBTwoIsRunOK = true;
                    }
                }
                else
                {
                    TBTwoIsRunOK = true;
                }
                if (isLocalRun) uploadMode.SetResult2(RunResult.OK);
                if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveCorrectImage)
                    imageSaveHerper.SaveImage(inputImage, ImageB1Name + "OK");
            }
            else if (runStatus.Result == CogToolResultConstants.Error)
            {
                if (runStatus.Message.Contains("FindPointB"))
                {
                    SetLabelNG(lblPointB);
                    SetLabelNG(lblMidPoint);
                    SetLabelNG(lblAngle);
                    ShowNG(LanguageHelper.GetString("fm_Camera") + "2 " + LanguageHelper.GetString("fm_Msg18"));
                }
                else if (runStatus.Message.Contains("FindLead"))
                {
                    pointB.PointX = (float)Convert.ToDouble(TB_Inspection[1].Outputs["X"].Value);
                    pointB.PointY = (float)Convert.ToDouble(TB_Inspection[1].Outputs["Y"].Value);
                    SetLabelText(lblPointB, pointB.PointX.ToString() + "," + pointB.PointY.ToString());
                    PinWidthB = 0;
                    ShowNG(LanguageHelper.GetString("fm_Camera") + "2 " + LanguageHelper.GetString("fm_Msg19"));
                    TBTwoIsRunOK = true;
                }
                if (isLocalRun) uploadMode.SetResult2(RunResult.NG);
                //sendNG();
                if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveErrorImage)
                    imageSaveHerper.SaveImage(inputImage, ImageB1Name + "NG");
            }
            if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveAllImage)
            {

                if (runStatus.Result == CogToolResultConstants.Accept && !wNG)
                    imageSaveHerper.SaveImage(inputImage, ImageB1Name + "OK");
                else
                    imageSaveHerper.SaveImage(inputImage, ImageB1Name + "NG");
            }
            TBTwoIsRun = true;
            GetMidPoint("pos1");

            ThreadPool.QueueUserWorkItem(new WaitCallback(Cam2_DisplayImage), record);
        }

        private void Camera3Acq_compeletevent(object sender, CogCompleteEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CogCompleteEventHandler(Camera3Acq_compeletevent), new object[] { sender, e });
            }
            else
            {
                //logHelper.WriteLog("相机拍照结束触发事件记录", "相机3拍照触发事件");
                var numPending = 0;
                var numReady = 0;
                var busy = false;
                AcqFifoTool[2].Operator.GetFifoState(out numPending, out numReady, out busy);
                if (numReady > 0)
                {
                    var info = new CogAcqInfo();
                    var _Image = (CogImage8Grey)AcqFifo[2].CompleteAcquireEx(info);
                    Camera3ImageQueue.Enqueue(_Image);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ToolBlock3Run));

                }
                IsAcqRuning[2] = false;
                camAcqNum += 1;
                if (camAcqNum > 4)
                {
                    GC.Collect();
                    camAcqNum = 0;
                }
            }

        }
        private void Cam3_DisplayImage(object sender)
        {
            //var CogImage = (CogImage8Grey)sender;
            Mydispaly[3].CogRecordDisplay1.InteractiveGraphics.Clear();
            Mydispaly[3].CogRecordDisplay1.Record = (ICogRecord)sender;
            //Mydispaly[2].Image = CogImage;
            Mydispaly[3].Fit();
        }
        private void ToolBlock3Run(object sender)
        {
            var inputImage = Camera3ImageQueue.Dequeue();
            toolBlock3Run(inputImage, false);
        }

        private void toolBlock3Run(CogImage8Grey inputImage, bool isLocalRun)
        {
            curGuid2 = guid2;
            bool wNG = false;
            TBThreeIsRun = false;
            TBThreeIsRunOK = false;
            var index = 2;
            //算法文件输入项
            TB_Inspection[index].Inputs["InputImage"].Value = inputImage;
            TB_Inspection[index].Run();
            var record = TB_Inspection[2].CreateLastRunRecord().SubRecords[1];
            ImageA2Name = "C" + DateTime.Now.ToString("yyyyMMddHHmmss");
            var runStatus = TB_Inspection[index].RunStatus;
            if (runStatus.Result == CogToolResultConstants.Accept)
            {
                pointA.PointX = (float)Convert.ToDouble(TB_Inspection[index].Outputs["X"].Value);
                pointA.PointY = (float)Convert.ToDouble(TB_Inspection[index].Outputs["Y"].Value);
                SetLabelOK(lblPointA2);
                SetLabelText(lblPointA2, pointA.PointX.ToString() + "," + pointA.PointY.ToString());
                PinWidthA = Math.Round(Convert.ToDouble(TB_Inspection[index].Outputs["PinWidth"].Value), 3);
                WidthA2 = Math.Round(CurrProStdData.GetWidthA2(aWA2, Math.Round(Convert.ToDouble(TB_Inspection[index].Outputs["Distance"].Value), 3)), 3);
                SetLabelText(lblWidthA2, WidthA2.ToString());
                if (CurrProStdData.WidthA2 != 0 && CurrProStdData.WidthA2Limits != 0)
                {
                    if (Math.Abs(WidthA2 - CurrProStdData.WidthA2) > CurrProStdData.WidthA2Limits)
                    {
                        imageSaveHerper.SaveImage(inputImage, ImageA2Name + "_W_NG");
                        wNG = true;
                        LogHelper.Instance.WriteLog("NG记录(NG Record)", "NG(Width) " + LanguageHelper.GetString("fm_Camera") + "3 " + LanguageHelper.GetString("fm_WNG") + " Image:" + ImageA2Name + "_W_NG");
#if (FangDai)
                        ShowNG2(LanguageHelper.GetString("fm_Camera") + "3 " + LanguageHelper.GetString("fm_WNG"));
                        //                        var msg = string.Format("Image" + "\r\n" +
                        //"[X:{0}; Y:{1}; A:{2}; ATTR:{3}; ID:{4}]" + "\r\n" +
                        //"Done", 0, 0, 0, 0, 3);
                        //if (cbSendWLdata2.Checked)
                        //    sendData(msg);

#endif
                    }
                    else
                    {
                        TBThreeIsRunOK = true;
                    }
                }
                else
                {
                    TBThreeIsRunOK = true;
                }
                if (isLocalRun) uploadMode2.SetResult1(RunResult.OK);
                if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveCorrectImage)
                    imageSaveHerper.SaveImage(inputImage, ImageA2Name + "OK");
            }
            else if (runStatus.Result == CogToolResultConstants.Error)
            {
                if (runStatus.Message.Contains("FindPointA"))
                {
                    SetLabelNG(lblPointA2);
                    SetLabelNG(lblMidPoint2);
                    SetLabelNG(lblAngle2);
                    ShowNG2(LanguageHelper.GetString("fm_Camera") + "3 " + LanguageHelper.GetString("fm_Msg18"));
                }
                else if (runStatus.Message.Contains("FindLead"))
                {
                    pointA.PointX = (float)Convert.ToDouble(TB_Inspection[index].Outputs["X"].Value);
                    pointA.PointY = (float)Convert.ToDouble(TB_Inspection[index].Outputs["Y"].Value);
                    SetLabelText(lblPointA2, pointA.PointX.ToString() + "," + pointA.PointY.ToString());
                    PinWidthA = 0;
                    ShowNG2(LanguageHelper.GetString("fm_Camera") + "3 " + LanguageHelper.GetString("fm_Msg19"));
                    TBThreeIsRunOK = true;
                }
                if (isLocalRun) uploadMode2.SetResult1(RunResult.NG);
                //sendNG();
                if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveErrorImage)
                    imageSaveHerper.SaveImage(inputImage, ImageA2Name + "NG");
            }
            if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveAllImage)
            {

                if (runStatus.Result == CogToolResultConstants.Accept && !wNG)
                    imageSaveHerper.SaveImage(inputImage, ImageA2Name + "OK");
                else
                    imageSaveHerper.SaveImage(inputImage, ImageA2Name + "NG");
            }

            TBThreeIsRun = true;
            GetMidPoint("pos2");

            ThreadPool.QueueUserWorkItem(new WaitCallback(Cam3_DisplayImage), record);
        }

        private void Camera4Acq_compeletevent(object sender, CogCompleteEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new CogCompleteEventHandler(Camera4Acq_compeletevent), new object[] { sender, e });
            }
            else
            {
                //logHelper.WriteLog("相机拍照结束触发事件记录", "相机4拍照触发事件");
                var numPending = 0;
                var numReady = 0;
                var busy = false;
                AcqFifoTool[3].Operator.GetFifoState(out numPending, out numReady, out busy);
                if (numReady > 0)
                {
                    var info = new CogAcqInfo();
                    var _Image = (CogImage8Grey)AcqFifo[3].CompleteAcquireEx(info);
                    Camera4ImageQueue.Enqueue(_Image);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ToolBlock4Run));

                }
                IsAcqRuning[3] = false;
                camAcqNum += 1;
                if (camAcqNum > 4)
                {
                    GC.Collect();
                    camAcqNum = 0;
                }
            }

        }
        private void Cam4_DisplayImage(object sender)
        {
            //var CogImage = (CogImage8Grey)sender;
            Mydispaly[1].CogRecordDisplay1.InteractiveGraphics.Clear();
            Mydispaly[1].CogRecordDisplay1.Record = (ICogRecord)sender;
            //Mydispaly[3].Image = CogImage;
            Mydispaly[1].Fit();
        }
        private void ToolBlock4Run(object sender)
        {
            var inputImage = Camera4ImageQueue.Dequeue();
            toolBlock4Run(inputImage, false);
        }

        private void toolBlock4Run(CogImage8Grey inputImage, bool isLocalRun)
        {
            bool wNG = false;
            TBFourIsRun = false;
            TBFourIsRunOK = false;
            var index = 3;
            //算法文件输入项
            TB_Inspection[index].Inputs["InputImage"].Value = inputImage;
            TB_Inspection[index].Run();
            var record = TB_Inspection[3].CreateLastRunRecord().SubRecords[1];
            ImageB2Name = "D" + DateTime.Now.ToString("yyyyMMddHHmmss");
            var runStatus = TB_Inspection[index].RunStatus;
            if (runStatus.Result == CogToolResultConstants.Accept)
            {
                pointB.PointX = (float)Convert.ToDouble(TB_Inspection[index].Outputs["X"].Value);
                pointB.PointY = (float)Convert.ToDouble(TB_Inspection[index].Outputs["Y"].Value);
                SetLabelOK(lblPointB2);
                SetLabelText(lblPointB2, pointB.PointX.ToString() + "," + pointB.PointY.ToString());
                PinWidthB = Math.Round(Convert.ToDouble(TB_Inspection[index].Outputs["PinWidth"].Value), 3);
                WidthB2 = Math.Round(CurrProStdData.GetWidthB2(aWB2, Math.Round(Convert.ToDouble(TB_Inspection[index].Outputs["Distance"].Value), 3)), 3);
                SetLabelText(lblWidthB2, WidthB2.ToString());
                if (CurrProStdData.WidthB2 != 0 && CurrProStdData.WidthB2Limits != 0)
                {
                    if (Math.Abs(WidthB2 - CurrProStdData.WidthB2) > CurrProStdData.WidthB2Limits)
                    {
                        imageSaveHerper.SaveImage(inputImage, ImageB2Name + "_W_NG");
                        wNG = true;
                        LogHelper.Instance.WriteLog("NG记录(NG Record)", "NG(Width) " + LanguageHelper.GetString("fm_Camera") + "4 " + LanguageHelper.GetString("fm_WNG") + " Image:" + ImageB2Name + "_W_NG");
#if (FangDai)
                        ShowNG2(LanguageHelper.GetString("fm_Camera") + "4 " + LanguageHelper.GetString("fm_WNG"));
                        //                        var msg = string.Format("Image" + "\r\n" +
                        //"[X:{0}; Y:{1}; A:{2}; ATTR:{3}; ID:{4}]" + "\r\n" +
                        //"Done", 0, 0, 0, 0, 3);
                        //if (cbSendWLdata2.Checked)
                        //    sendData(msg);

#endif
                    }
                    else
                    {
                        TBFourIsRunOK = true;
                    }
                }
                else
                {
                    TBFourIsRunOK = true;
                }

                if (isLocalRun) uploadMode2.SetResult2(RunResult.OK);
                if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveCorrectImage)
                    imageSaveHerper.SaveImage(inputImage, ImageB2Name + "OK");
            }
            else if (runStatus.Result == CogToolResultConstants.Error)
            {
                if (runStatus.Message.Contains("FindPointB"))
                {
                    SetLabelNG(lblPointB2);
                    SetLabelNG(lblMidPoint2);
                    SetLabelNG(lblAngle2);
                    ShowNG2(LanguageHelper.GetString("fm_Camera") + "4 " + LanguageHelper.GetString("fm_Msg18"));
                }
                else if (runStatus.Message.Contains("FindLead"))
                {
                    pointB.PointX = (float)Convert.ToDouble(TB_Inspection[index].Outputs["X"].Value);
                    pointB.PointY = (float)Convert.ToDouble(TB_Inspection[index].Outputs["Y"].Value);
                    SetLabelText(lblPointB, pointB.PointX.ToString() + "," + pointB.PointY.ToString());
                    PinWidthB = 0;
                    ShowNG2(LanguageHelper.GetString("fm_Camera") + "4 " + LanguageHelper.GetString("fm_Msg19"));
                    TBFourIsRunOK = true;
                }
                if (isLocalRun) uploadMode2.SetResult2(RunResult.NG);
                //sendNG();
                if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveErrorImage)
                    imageSaveHerper.SaveImage(inputImage, ImageB2Name + "NG");
            }
            if (imageSaveHerper.SaveImageUI.IsSaveToLocal && imageSaveHerper.SaveImageUI.WhichImageNeedSave == (int)ImageNeedSave.SaveAllImage)
            {

                if (runStatus.Result == CogToolResultConstants.Accept && !wNG)
                    imageSaveHerper.SaveImage(inputImage, ImageB2Name + "OK");
                else
                    imageSaveHerper.SaveImage(inputImage, ImageB2Name + "NG");
            }

            TBFourIsRun = true;
            GetMidPoint("pos2");

            ThreadPool.QueueUserWorkItem(new WaitCallback(Cam4_DisplayImage), record);
        }

        private void GetMidPoint(string type)
        {
            object o = new object();
            lock (o)
            {
                if (type == "pos1")
                {
                    if (TBOneIsRun && TBTwoIsRun)
                    {
                        RunNum++;
                        if (TBOneIsRunOK && TBTwoIsRunOK)
                        {
                            lineAB.A = pointA;
                            lineAB.B = pointB;
                            lineAB.MidPoint = lineAB.GetMidPoint(pointA, pointB);
                            SetLabelOK(lblMidPoint);
                            SetLabelText(lblMidPoint, Math.Round(lineAB.MidPoint.PointX, 3).ToString() + "," + Math.Round(lineAB.MidPoint.PointY, 3).ToString());
                            SetLabelOK(lblAngle);
                            SetLabelText(lblAngle, Math.Round((Math.Atan(lineAB.GetK(pointA, pointB)) * 180 / Math.PI), 3).ToString());
                            ThreadPool.QueueUserWorkItem(new WaitCallback(GetResultPointAndAngle1));
                        }
                        else
                        {
                            ShowNG(LanguageHelper.GetString("fm_Camera") + "One or Two " + LanguageHelper.GetString("fm_Msg18"));
                            LogHelper.Instance.WriteLog("NG记录(NG Record)", "NG：" + " ImageA:" + ImageA1Name + " ImageB:" + ImageB1Name + " TBOneIsRun：" + TBOneIsRun.ToString() + " TBTwoIsRun：" + TBTwoIsRun.ToString() + " TBOneIsRunOK：" + TBOneIsRunOK.ToString() + " TBTwoIsRunOK：" + TBTwoIsRunOK.ToString());
                            LogHelper.Instance.WriteLog("电池串计算数据记录(Cell Length Record)", "NG：" + " ImageA:" + ImageA1Name + " ImageB:" + ImageB1Name + " TBOneIsRun：" + TBOneIsRun.ToString() + " TBTwoIsRun：" + TBTwoIsRun.ToString() + " TBOneIsRunOK：" + TBOneIsRunOK.ToString() + " TBTwoIsRunOK：" + TBTwoIsRunOK.ToString() + " " + guid1 + " " + curGuid1);
                        }
                        SetLabelText(lblRunNum, RunNum.ToString());
                        SetLabelText(_lblRunNum, RunNum.ToString());
                        TBOneIsRun = false;
                        TBTwoIsRun = false;
                    }
                }
                else if (type == "pos2")
                {
                    if (TBThreeIsRun && TBFourIsRun)
                    {
                        RunNum2++;
                        if (TBThreeIsRunOK && TBFourIsRunOK)
                        {
                            lineAB.A = pointA;
                            lineAB.B = pointB;
                            lineAB.MidPoint = lineAB.GetMidPoint(pointA, pointB);
                            SetLabelOK(lblMidPoint2);
                            SetLabelText(lblMidPoint2, Math.Round(lineAB.MidPoint.PointX, 3).ToString() + "," + Math.Round(lineAB.MidPoint.PointY, 3).ToString());
                            SetLabelOK(lblAngle2);
                            SetLabelText(lblAngle2, Math.Round((Math.Atan(lineAB.GetK(pointA, pointB)) * 180 / Math.PI), 3).ToString());
                            ThreadPool.QueueUserWorkItem(new WaitCallback(GetResultPointAndAngle2));
                        }
                        else
                        {

                            ShowNG2(LanguageHelper.GetString("fm_Camera") + LanguageHelper.GetString("fm_Msg18"));
                            LogHelper.Instance.WriteLog("NG记录(NG Record)", "NG：" + " ImageC:" + ImageA2Name + " ImageD:" + ImageB2Name + " TBThreeIsRun：" + TBThreeIsRun.ToString() + " TBFourIsRun：" + TBFourIsRun.ToString() + " TBThreeIsRunOK：" + TBThreeIsRunOK.ToString() + " TBFourIsRunOK：" + TBFourIsRunOK.ToString());
                            LogHelper.Instance.WriteLog("电池串计算数据记录(Cell Length Record)", "NG：" + " ImageC:" + ImageA2Name + " ImageD:" + ImageB2Name + " TBThreeIsRun：" + TBThreeIsRun.ToString() + " TBFourIsRun：" + TBFourIsRun.ToString() + " TBThreeIsRunOK：" + TBThreeIsRunOK.ToString() + " TBFourIsRunOK：" + TBFourIsRunOK.ToString() + " " + guid2 + " " + curGuid2);
                        }
                        SetLabelText(lblRunNum2, RunNum2.ToString());
                        SetLabelText(_lblRunNum2, RunNum2.ToString());
                        TBThreeIsRun = false;
                        TBFourIsRun = false;
                    }
                }
            }
        }
        private void GetResultPointAndAngle1(object send)
        {
            var dX = 0.000;
            var dY = 0.000;
            var dAngle = 0.000;
            var MDx = lineAB.MidPoint.PointX - CurrProStdData.MidPoint.PointX;
            var MDy = lineAB.MidPoint.PointY - CurrProStdData.MidPoint.PointY;
            var a = (Math.PI * ((Math.Atan(lineAB.GetK(pointA, pointB)) * 180 / Math.PI) - CurrProStdData.Angle)) / 180;

            //计算串长
            var l1 = Math.Round(CurrProStdData.GetCellLength1(aL1, Math.Round(Math.Sqrt((pointA.PointY - pointB.PointY) * (pointA.PointY - pointB.PointY) + (pointA.PointX - pointB.PointX) * (pointA.PointX - pointB.PointX)), 3)), 3);
            LogHelper.Instance.WriteLog("电池串计算数据记录(Cell Length Record)", "Length1：" + l1.ToString("0000.000") + " Width(A1)：" + WidthA1.ToString("000.000") + " Width(B1)：" + WidthB1.ToString("000.000") + " ImageA:" + ImageA1Name + " ImageB:" + ImageB1Name);

#if (FangDai)
            if (CurrProStdData.CellLength1 != 0 && CurrProStdData.CellLength1Limits != 0)
            {
                if (Math.Abs(CurrProStdData.CellLength1 - l1) > CurrProStdData.CellLength1Limits)
                {
                    LogHelper.Instance.WriteLog("NG记录(NG Record)", "NG(Length) " + LanguageHelper.GetString("fm_Camera") + "1,2" + LanguageHelper.GetString("fm_LNG") + " ImageA:" + ImageA1Name + " ImageB:" + ImageB1Name);

                    ShowNG(LanguageHelper.GetString("fm_Camera") + "1,2 " + LanguageHelper.GetString("fm_LNG"));
                    //                    var msg = string.Format("Image" + "\r\n" +
                    //"[X:{0}; Y:{1}; A:{2}; ATTR:{3}; ID:{4}]" + "\r\n" +
                    //"Done", 0, 0, 0, 0, 2);
                    //if (cbSendWLdata1.Checked)
                    //    sendData(msg);

                    return;
                }
            }
#endif

            if (rdoMd.Checked)
            {
                dX = Math.Round(MDx, 3);
                dY = Math.Round(MDy, 3);
                dAngle = Math.Round(a * 180 / Math.PI, 3);
            }
            else if (rdoCd.Checked)
            {
                //CDx= (cos (a) -1) * StDx- sin (a) * StDy+ MDx
                dX = Math.Round((Math.Cos(a) - 1) * CurrProStdData.StDx - Math.Sin(a) * CurrProStdData.StDy + MDx, 3);
                //CDy= (cos (a) -1) * StDy + sin (a) * StDx + Mdy
                dY = Math.Round((Math.Cos(a) - 1) * CurrProStdData.StDy + Math.Sin(a) * CurrProStdData.StDx + MDy, 3);
                dAngle = Math.Round(a * 180 / Math.PI, 3);
            }
            if (Math.Abs(dX) > CurrProStdData.XOffsetAllowed)
            {
                ShowNG(LanguageHelper.GetString("fm_Msg20"));
                LogHelper.Instance.WriteLog("NG记录(NG Record)", LanguageHelper.GetString("fm_Msg20") + " ImageA:" + ImageA1Name + " ImageB:" + ImageB1Name);
                //sendNG();
                return;
            }
            if (Math.Abs(dY) > CurrProStdData.YOffsetAllowed)
            {
                ShowNG(LanguageHelper.GetString("fm_Msg21"));
                LogHelper.Instance.WriteLog("NG记录(NG Record)", LanguageHelper.GetString("fm_Msg21") + " ImageA:" + ImageA1Name + " ImageB:" + ImageB1Name);
                //sendNG();
                return;
            }
            if (Math.Abs(dAngle) > CurrProStdData.AngleOffsetAllowed)
            {
                ShowNG(LanguageHelper.GetString("fm_Msg22"));
                LogHelper.Instance.WriteLog("NG记录(NG Record)", LanguageHelper.GetString("fm_Msg22") + " ImageA:" + ImageA1Name + " ImageB:" + ImageB1Name);
                //sendNG();
                return;
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    lblResultPoint.Text = dX.ToString() + "," + dY.ToString();
                    lblResultAngle.Text = dAngle.ToString();

                    _lblResultPoint.Text = dX.ToString() + "," + dY.ToString();
                    _lblResultAngle.Text = dAngle.ToString();
                    var attr = 0;
                    //if (ckbAB.Checked)
                    //{
                    //    if (PinWidthA == 0 || PinWidthB == 0) attr = 0;
                    //    else
                    //        attr = Convert.ToInt32(PinWidthA > PinWidthB) + 1;
                    //}
                    var msg = String.Format("Image" + "\r\n" +
                  "[X:{0}; Y:{1}; A:{2}; ATTR:{3}; ID:{4}]" + "\r\n" +
                  "Done", dX.ToString(), dY.ToString(), dAngle.ToString(), attr, 10);
                    //TClient.Send(msg);
                    sendData(msg);
                    SendInfo(msg);
                    ShowOK("OK");
                    LogHelper.Instance.WriteLog("补偿值记录", "相机1 2: " + msg);
                }));
            }
            else
            {
                lblResultPoint.Text = dX.ToString() + "," + dY.ToString();
                lblResultAngle.Text = dAngle.ToString();

                _lblResultPoint.Text = dX.ToString() + "," + dY.ToString();
                _lblResultAngle.Text = dAngle.ToString();
                var attr = 0;
                //if (ckbAB.Checked)
                //{
                //    if (PinWidthA == 0 || PinWidthB == 0) attr = 0;
                //    else
                //        attr = Convert.ToInt32(PinWidthA > PinWidthB) + 1;
                //}
                var msg = String.Format("Image" + "\r\n" +
                           "[X:{0}; Y:{1}; A:{2}; ATTR:{3}; ID:{4}]" + "\r\n" +
                           "Done", dX.ToString(), dY.ToString(), dAngle.ToString(), attr, 10);
                //TClient.Send(msg);
                sendData(msg);
                SendInfo(msg);
                ShowOK("OK");
                LogHelper.Instance.WriteLog("补偿值记录", "相机1 2: " + msg);
            }


        }
        private void GetResultPointAndAngle2(object send)
        {
            var dX = 0.000;
            var dY = 0.000;
            var dAngle = 0.000;
            var MDx = lineAB.MidPoint.PointX - CurrProStdData.MidPoint2.PointX;
            var MDy = lineAB.MidPoint.PointY - CurrProStdData.MidPoint2.PointY;
            var a = (Math.PI * ((Math.Atan(lineAB.GetK(pointA, pointB)) * 180 / Math.PI) - CurrProStdData.Angle2)) / 180;


            //计算串长
            var l2 = Math.Round(CurrProStdData.GetCellLength2(aL2, Math.Round(Math.Sqrt((pointA.PointY - pointB.PointY) * (pointA.PointY - pointB.PointY) + (pointA.PointX - pointB.PointX) * (pointA.PointX - pointB.PointX)), 3)), 3);
            LogHelper.Instance.WriteLog("电池串计算数据记录(Cell Length Record)", "Length2：" + l2.ToString("0000.000") + " Width(A2)：" + WidthA2.ToString("000.000") + " Width(B2)：" + WidthB2.ToString("000.000") + " ImageC:" + ImageA2Name + " ImageD:" + ImageB2Name);

#if (FangDai)
            if (CurrProStdData.CellLength2 != 0 && CurrProStdData.CellLength2Limits != 0)
            {
                if (Math.Abs(CurrProStdData.CellLength2 - l2) > CurrProStdData.CellLength2Limits)
                {
                    LogHelper.Instance.WriteLog("NG记录(NG Record)", "NG(Length) " + LanguageHelper.GetString("fm_Camera") + "3,4" + LanguageHelper.GetString("fm_LNG"));
                    ShowNG2(LanguageHelper.GetString("fm_Camera") + "3,4 " + LanguageHelper.GetString("fm_LNG") + " ImageC:" + ImageA2Name + " ImageD:" + ImageB2Name);
                    //                    var msg = string.Format("Image" + "\r\n" +
                    //"[X:{0}; Y:{1}; A:{2}; ATTR:{3}; ID:{4}]" + "\r\n" +
                    //"Done", 0, 0, 0, 0, 3);
                    //if (cbSendWLdata2.Checked)
                    //    sendData(msg);
                    return;
                }
            }
#endif
            if (rdoMd2.Checked)
            {
                dX = Math.Round(MDx, 3);
                dY = Math.Round(MDy, 3);
                dAngle = Math.Round(a * 180 / Math.PI, 3);
            }
            else if (rdoCd2.Checked)
            {
                //CDx= (cos (a) -1) * StDx- sin (a) * StDy+ MDx
                dX = Math.Round((Math.Cos(a) - 1) * CurrProStdData.StDx2 - Math.Sin(a) * CurrProStdData.StDy2 + MDx, 3);
                //CDx= (cos (a) -1) * StDy + sin (a) * StDx + Mdy
                dY = Math.Round((Math.Cos(a) - 1) * CurrProStdData.StDy2 + Math.Sin(a) * CurrProStdData.StDx2 + MDy, 3);
                dAngle = Math.Round(a * 180 / Math.PI, 3);
            }
            if (Math.Abs(dX) > CurrProStdData.XOffsetAllowed)
            {
                ShowNG2(LanguageHelper.GetString("fm_Msg20"));
                LogHelper.Instance.WriteLog("NG记录(NG Record)", LanguageHelper.GetString("fm_Msg20") + " ImageC:" + ImageA2Name + " ImageD:" + ImageB2Name);
                //sendNG();
                return;
            }
            if (Math.Abs(dY) > CurrProStdData.YOffsetAllowed)
            {
                ShowNG2(LanguageHelper.GetString("fm_Msg21"));
                LogHelper.Instance.WriteLog("NG记录(NG Record)", LanguageHelper.GetString("fm_Msg21") + " ImageC:" + ImageA2Name + " ImageD:" + ImageB2Name);
                //sendNG();
                return;
            }
            if (Math.Abs(dAngle) > CurrProStdData.AngleOffsetAllowed)
            {
                ShowNG2(LanguageHelper.GetString("fm_Msg22"));
                LogHelper.Instance.WriteLog("NG记录(NG Record)", LanguageHelper.GetString("fm_Msg22") + " ImageC:" + ImageA2Name + " ImageD:" + ImageB2Name);
                //sendNG();
                return;
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    lblResultPoint2.Text = dX.ToString() + "," + dY.ToString();
                    lblResultAngle2.Text = dAngle.ToString();

                    _lblResultPoint2.Text = dX.ToString() + "," + dY.ToString();
                    _lblResultAngle2.Text = dAngle.ToString();
                    var attr = 0;
                    //if (ckbAB.Checked)
                    //{
                    //    if (PinWidthA == 0 || PinWidthB == 0) attr = 0;
                    //    else
                    //        attr = Convert.ToInt32(PinWidthA > PinWidthB) + 1;
                    //}
                    var msg = String.Format("Image" + "\r\n" +
                  "[X:{0}; Y:{1}; A:{2}; ATTR:{3}; ID:{4}]" + "\r\n" +
                  "Done", dX.ToString(), dY.ToString(), dAngle.ToString(), attr, 20);
                    //TClient.Send(msg);
                    sendData(msg);
                    SendInfo(msg);
                    ShowOK2("OK");
                    LogHelper.Instance.WriteLog("补偿值记录", "相机3 4: " + msg);
                }));
            }
            else
            {
                lblResultPoint.Text = dX.ToString() + "," + dY.ToString();
                lblResultAngle.Text = dAngle.ToString();

                _lblResultPoint2.Text = dX.ToString() + "," + dY.ToString();
                _lblResultAngle2.Text = dAngle.ToString();
                var attr = 0;
                //if (ckbAB.Checked)
                //{
                //    if (PinWidthA == 0 || PinWidthB == 0) attr = 0;
                //    else
                //        attr = Convert.ToInt32(PinWidthA > PinWidthB) + 1;
                //}
                var msg = String.Format("Image" + "\r\n" +
                           "[X:{0}; Y:{1}; A:{2}; ATTR:{3}; ID:{4}]" + "\r\n" +
                           "Done", dX.ToString(), dY.ToString(), dAngle.ToString(), attr, 20);
                //TClient.Send(msg);
                sendData(msg);
                SendInfo(msg);
                ShowOK2("OK");
                LogHelper.Instance.WriteLog("补偿值记录", "相机3 4: " + msg);
            }


        }
        private delegate void showNGHandler(string msg);
        private void ShowNG(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new showNGHandler(ShowNG), new object[] { msg });
            }
            else
            {
                lblResult.Text = RunResult.NG.ToString();
                lblResult.ForeColor = Color.Red;
                lblResultPoint.Text = "dX,dY";
                lblResultAngle.Text = string.Empty;
                lblResultInfo.Text = msg;

                _lblResult.Text = RunResult.NG.ToString();
                _lblResult.ForeColor = Color.Red;
                _lblResultPoint.Text = "dX,dY";
                _lblResultAngle.Text = string.Empty;
                //_lblResultInfo.Text = msg;
            }
        }
        private delegate void showNG2Handler(string msg);
        private void ShowNG2(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new showNG2Handler(ShowNG2), new object[] { msg });
            }
            else
            {
                lblResult2.Text = RunResult.NG.ToString();
                lblResult2.ForeColor = Color.Red;
                lblResultPoint2.Text = "dX,dY";
                lblResultAngle2.Text = string.Empty;
                lblResultInfo2.Text = msg;

                _lblResult2.Text = RunResult.NG.ToString();
                _lblResult2.ForeColor = Color.Red;
                _lblResultPoint2.Text = "dX,dY";
                _lblResultAngle2.Text = string.Empty;
                //lblResultInfo2.Text = msg;
            }
        }
        private delegate void showOKHandler(string msg);
        private void ShowOK(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new showNGHandler(ShowOK), new object[] { msg });
            }
            else
            {
                lblResult.Text = RunResult.OK.ToString();
                lblResult.ForeColor = Color.Green;
                lblResultInfo.Text = msg;

                _lblResult.Text = RunResult.OK.ToString();
                _lblResult.ForeColor = Color.Green;
            }
        }

        private delegate void showOK2Handler(string msg);
        private void ShowOK2(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new showNGHandler(ShowOK2), new object[] { msg });
            }
            else
            {
                lblResult2.Text = RunResult.OK.ToString();
                lblResult2.ForeColor = Color.Green;
                lblResultInfo2.Text = msg;

                _lblResult2.Text = RunResult.OK.ToString();
                _lblResult2.ForeColor = Color.Green;
            }
        }

        private delegate void showRHandler(string msg);
        private void ShowR(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new showRHandler(ShowR), new object[] { msg });
            }
            else
            {
                lblResult.Text = "R";
                lblResult.ForeColor = Color.White;
                lblResultInfo.Text = msg;

                _lblResult.Text = "R";
                _lblResult.ForeColor = Color.White;
            }
        }

        private delegate void showR2Handler(string msg);
        private void ShowR2(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new showR2Handler(ShowR2), new object[] { msg });
            }
            else
            {
                lblResult2.Text = "R";
                lblResult2.ForeColor = Color.White;
                lblResultInfo2.Text = msg;

                _lblResult2.Text = "R";
                _lblResult2.ForeColor = Color.White;
            }
        }
        private void SetLabelOK(Label label)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    label.BackColor = Color.GhostWhite;
                }));
            }
            else
            {
                label.BackColor = Color.GhostWhite;
            }

        }
        private void SetLabelNG(Label label)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    label.Text = string.Empty;
                    label.BackColor = Color.Red;
                }));
            }
            else
            {
                label.Text = string.Empty;
                label.BackColor = Color.Red;
            }
        }


        #region 本地图片运行


        ImageSaveHerper imageSaveHerper = new ImageSaveHerper();
        public void UpLoadRun1(CogImage8Grey camera1Image)
        {
            toolBlock1Run(camera1Image, true);
        }

        public void UpLoadRun2(CogImage8Grey camera2Image)
        {
            toolBlock2Run(camera2Image, true);
        }

        public void UpLoadRun3(CogImage8Grey camera3Image)
        {
            toolBlock3Run(camera3Image, true);
        }

        public void UpLoadRun4(CogImage8Grey camera4Image)
        {
            toolBlock4Run(camera4Image, true);
        }
        private void LocalGetMidPoint()
        {
            if (TBOneIsRun && TBTwoIsRun)
            {
                RunNum++;
                if (TBOneIsRunOK && TBTwoIsRunOK)
                {
                    lineAB.A = pointA;
                    lineAB.B = pointB;
                    lineAB.MidPoint = lineAB.GetMidPoint(pointA, pointB);
                    SetLabelOK(lblMidPoint);
                    SetLabelText(lblMidPoint, Math.Round(lineAB.MidPoint.PointX, 3).ToString() + "," + Math.Round(lineAB.MidPoint.PointY, 3).ToString());
                    SetLabelOK(lblAngle);
                    SetLabelText(lblAngle, Math.Round((Math.Atan(lineAB.GetK(pointA, pointB)) * 180 / Math.PI), 3).ToString());
                    ThreadPool.QueueUserWorkItem(new WaitCallback(GetResultPointAndAngle1));
                }
                else
                {
                    ShowNG("相机拍摄未找到电池片\r\n请确认电池片在视野范围内并且未变形或损坏或被其它障碍物遮挡");
                    LogHelper.Instance.WriteLog("工具运行日志(Tool Running Log)", "相机拍摄未找到电池片\r\n请确认电池片在视野范围内并且未变形或损坏或被其它障碍物遮挡");
                }
                SetLabelText(lblRunNum, RunNum.ToString());
                SetLabelText(_lblRunNum, RunNum.ToString());
                TBOneIsRun = false;
                TBTwoIsRun = false;
            }

            if (TBThreeIsRun && TBFourIsRun)
            {
                RunNum2++;
                if (TBThreeIsRunOK && TBFourIsRunOK)
                {
                    lineAB.A = pointA;
                    lineAB.B = pointB;
                    lineAB.MidPoint = lineAB.GetMidPoint(pointA, pointB);
                    SetLabelOK(lblMidPoint2);
                    SetLabelText(lblMidPoint2, Math.Round(lineAB.MidPoint.PointX, 3).ToString() + "," + Math.Round(lineAB.MidPoint.PointY, 3).ToString());
                    SetLabelOK(lblAngle2);
                    SetLabelText(lblAngle2, Math.Round((Math.Atan(lineAB.GetK(pointA, pointB)) * 180 / Math.PI), 3).ToString());
                    ThreadPool.QueueUserWorkItem(new WaitCallback(GetResultPointAndAngle2));
                }
                else
                {
                    ShowNG("相机拍摄未找到电池片\r\n请确认电池片在视野范围内并且未变形或损坏或被其它障碍物遮挡");
                    LogHelper.Instance.WriteLog("工具运行日志(Tool Running Log)", "相机拍摄未找到电池片\r\n请确认电池片在视野范围内并且未变形或损坏或被其它障碍物遮挡");
                }
                SetLabelText(lblRunNum2, RunNum2.ToString());
                SetLabelText(_lblRunNum2, RunNum2.ToString());
                TBThreeIsRun = false;
                TBFourIsRun = false;
            }
        }
        #endregion

        #endregion

        #region 与机器人对接部分
        #region "TCP通讯变量"
        private static byte[] result = new byte[1024];
        private static int myProt = 3000;   //端口  
        private static Socket serverSocket;
        private static Socket socketSend;
        //Queue<Socket> myClientSocket = new Queue<Socket>();
        //创建监听连接的线程
        Thread AcceptSocketThread;
        Thread threadReceive;
        private delegate void initTCPHandler();
        #endregion
        private void InitTCP()
        {

            if (this.InvokeRequired)
            {
                this.Invoke(new initTCPHandler(InitTCP));
            }
            else
            {
                IPAddress ip = IPAddress.Parse(GetIpAddress());
                // IPAddress ip =IPAddress.Parse(IPAddress);
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ip, myProt));  //绑定IP地址：端口  
                serverSocket.Listen(10);    //设定最多10个排队连接请求  
                Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());
                //通过Clientsoket发送数据  
                //Thread myThread = new Thread(ListenClientConnect);
                //myThread.Start();
                AcceptSocketThread = new Thread(new ParameterizedThreadStart(ListenClientConnect));
                AcceptSocketThread.IsBackground = true;
                AcceptSocketThread.Start(serverSocket);
            }

        }

        private string GetIpAddress()
        {
            string hostName = Dns.GetHostName();   //获取本机名
            IPHostEntry localhost = Dns.GetHostByName(hostName);    //方法已过期，可以获取IPv4的地址
            //IPHostEntry localhost = Dns.GetHostEntry(hostName);   //获取IPv6地址
            IPAddress localaddr = localhost.AddressList[0];

            return localaddr.ToString();
        }

        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private void ListenClientConnect(object obj)
        {
            while (true)
            {
                try
                {

                    Socket clientSocket = serverSocket.Accept();
                    SetTCPConnecInfo(clientSocket.RemoteEndPoint + LanguageHelper.GetString("fm_Msg23"));
                    socketSend = clientSocket;
                    clientSocket.Send(Encoding.ASCII.GetBytes("OK"));
                    //Thread receiveThread = new Thread(ReceiveMessage);
                    //receiveThread.Start(clientSocket);
                    threadReceive = new Thread(new ParameterizedThreadStart(ReceiveMessage));
                    threadReceive.IsBackground = true;
                    threadReceive.Start(clientSocket);
                }
                catch (Exception ex)
                {
                    LogHelper.Instance.WriteLog("TCP异常", "代码：1000 描述：" + ex.Message);
                }
            }

        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private void ReceiveMessage(object obj)
        {
            var exceptionStep = string.Empty;
            Socket socketSend = obj as Socket;
            while (true)
            {
                try
                {
                    exceptionStep = "1001";
                    //通过clientSocket接收数据  
                    int receiveNumber = socketSend.Receive(result);
                    if (receiveNumber == 0)//count 表示客户端关闭，要退出循环
                    {
                        exceptionStep = "1002";
                        SetTCPConnecInfo(socketSend.RemoteEndPoint + LanguageHelper.GetString("fm_Msg24"));
                        break;
                    }
                    else
                    {
                        exceptionStep = "1003";
                        var receiveMsg = Encoding.ASCII.GetString(result, 0, receiveNumber);
                        if (receiveMsg.Trim() == "Ready")
                        {

                            //ShowR("R");
                            //ShowR2("R");
                            var msg = string.Format("Image" + "\r\n" +
                             "[X:{0}; Y:{1}; A:{2}; ATTR:{3}; ID:{4}]" + "\r\n" +
                             "Done", 0, 0, 0, 0, 0);
                            socketSend.Send(Encoding.ASCII.GetBytes(msg)); ;
                        }
                        else if (receiveMsg.Trim() == "pos1")
                        {
#if (RecordBeat)
                        StartTime = DateTime.Now;
#endif
                            ShowR("");

                            TBOneIsRun = false;
                            TBTwoIsRun = false;
                            TBOneIsRunOK = false;
                            TBTwoIsRunOK = false;
                            guid1 = Guid.NewGuid().ToString();

                            exceptionStep = "1004";
                            LogHelper.Instance.WriteLog("补偿值记录", "相机1 2拍照");
                            //myClientSocket.Enqueue((Socket)clientSocket);
                            exceptionStep = "1005";
                            AcqRun(0);
                            exceptionStep = "1006";
                            Thread.Sleep(100);
                            exceptionStep = "1007";
                            AcqRun(1);

                        }
                        else if (receiveMsg.Trim() == "pos2")
                        {
                            ShowR2("");

                            TBThreeIsRun = false;
                            TBFourIsRun = false;
                            TBThreeIsRunOK = false;
                            TBFourIsRunOK = false;
                            guid2 = Guid.NewGuid().ToString();

                            exceptionStep = "1008";
                            LogHelper.Instance.WriteLog("补偿值记录", "相机3 4拍照");
                            //myClientSocket.Enqueue((Socket)clientSocket);
                            exceptionStep = "1009";
                            AcqRun(2);
                            exceptionStep = "1010";
                            Thread.Sleep(100);
                            exceptionStep = "1011";
                            AcqRun(3);

                        }
                        GetInfo(receiveMsg.Trim());
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Instance.WriteLog("TCP异常", "代码：" + exceptionStep + "描述：" + ex.Message);
                    Console.WriteLine(ex.Message);
                    try
                    {
                        exceptionStep = "1012";
                        socketSend.Shutdown(SocketShutdown.Both);
                        exceptionStep = "1013";
                        socketSend.Close();
                    }
                    catch (Exception ex2)
                    {
                        LogHelper.Instance.WriteLog("TCP异常", "代码：" + exceptionStep + "描述：" + ex2.Message);
                    }
                    break;
                }
            }

        }

        private delegate void sendInfoHandler(string msg);
        private void SendInfo(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new sendInfoHandler(SendInfo), new object[] { msg });
            }
            else
            {
                lstSendInfo.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + msg);
            }
        }
        //private void sendNG()
        //{
        //    if (myClientSocket != null && myClientSocket.Count > 0)
        //    {
        //        var clientSocket = myClientSocket.Dequeue();
        //    }

        //}
        private void sendData(string msg)
        {
            //if (myClientSocket != null && myClientSocket.Count > 0)
            //{
            //    var clientSocket = myClientSocket.Dequeue();
            //    if (clientSocket != null)
            //    {
            if (socketSend != null)
                socketSend.Send(Encoding.ASCII.GetBytes(msg));
#if (RecordBeat)
                    logHelper.WriteLog("时间节拍记录", StartTime.ToString("HH:mm:ss.fff") + " " + EndTime1.ToString("HH:mm:ss.fff") + " " + EndTime2.ToString("HH:mm:ss.fff") + " " + DateTime.Now.ToString("HH:mm:ss.fff"));
#endif
            //    }
            //}


        }

        private delegate void getInfoHandler(string msg);
        private void GetInfo(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new getInfoHandler(GetInfo), new object[] { msg });
            }
            else
            {
                lstGetInfo.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + msg);
            }
;
        }

        private void SetTCPConnecInfo(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new sendInfoHandler(SetTCPConnecInfo), new object[] { msg });
            }
            else
            {
                rtbTCPContent.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + msg + "\r\n";
            }
        }
        #endregion

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmAbout fa = new frmAbout();
            fa.ShowDialog();
        }

        private void tsmtImageSave_Click(object sender, EventArgs e)
        {
            frmImageSave fIS = new frmImageSave();
            fIS.ShowDialog();
            imageSaveHerper = new ImageSaveHerper();


        }

        private void tsmtLogin_Click(object sender, EventArgs e)
        {
            if (tsmtSetting.Enabled)
            {
                MessageBox.Show(LanguageHelper.GetString("fm_Msg25"));
            }
            else
            {
                frmLogin fL = new frmLogin();
                fL.userLogin += new frmLogin.userLoginHandler(UserLogin);
                fL.ShowDialog();
            }

        }
        private bool UserLogin(string userName, string pwd)
        {
            var result = false;
            if (userName == "Admin" && pwd == "123456")
            {
                tsmtSetting.Enabled = true;
                tsmtStandardData.Enabled = true;
                tsmtFile.Enabled = true;
                panel5.Enabled = true;
                panel7.Enabled = true;
                result = true;
            }

            return result;
        }

        private void tsmtStandardData_Click(object sender, EventArgs e)
        {
            frmStdData fsd = new frmStdData();
            var result = fsd.ShowDialog();
            LoadXMLData();
        }

        private void tsmtSysSetting_Click(object sender, EventArgs e)
        {
            frmSetting fss = new frmSetting();
            fss.reLoadRunMode += new frmSetting.reLoadRunModeHandler(delegate ()
            {
                Thread t1 = new Thread(new ThreadStart(ReLoadRunMode));
                t1.Start();
            });
            fss.reLoadLanguage += new frmSetting.reLoadLanguageHandler(delegate ()
            {
                var language = (Language)Convert.ToInt32(iniHelper.IniReadValue("SysSeting", "Language"));
                ReLoadLanguage(language);
                JudgementCameraLinked();
                Mydispaly[0].reLoadLanguage(0);
                var cameraNum = 0;
                for (var index = 0; index < TNum; index++)
                {
                    if (index == 0) cameraNum = 2;
                    else if (index == 1) cameraNum = 4;
                    else if (index == 2) cameraNum = 1;
                    else if (index == 3) cameraNum = 3;
                    Mydispaly[index].reLoadLanguage(cameraNum);
                }
                if (uploadMode != null)
                {
                    uploadMode.ReLoadLanguage(LanguageHelper.GetString("fm_Camera") + "1", LanguageHelper.GetString("fm_Camera") + "2");
                }
                if (uploadMode2 != null)
                {
                    uploadMode2.ReLoadLanguage(LanguageHelper.GetString("fm_Camera") + "3", LanguageHelper.GetString("fm_Camera") + "4");
                }
                if (photoMode != null)
                {
                    photoMode.ReLoadLanguage(LanguageHelper.GetString("fm_Camera") + "1", LanguageHelper.GetString("fm_Camera") + "2");
                }
                if (photoMode2 != null)
                {
                    photoMode2.ReLoadLanguage(LanguageHelper.GetString("fm_Camera") + "3", LanguageHelper.GetString("fm_Camera") + "4");
                }
            });
            fss.ShowDialog();
        }

        List<ProdStdData> lProdStdData;
        private void LoadXMLData()
        {

            lProdStdData = new List<ProdStdData>();
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
                    if (item1.Name == "sMidPoint")
                    {
                        model.sMidPoint = item1.Value;
                    }
                    if (item1.Name == "Angle")
                    {
                        model.Angle = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "StDx")
                    {
                        model.StDx = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "StDy")
                    {
                        model.StDy = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "sMidPoint2")
                    {
                        model.sMidPoint2 = item1.Value;
                    }
                    if (item1.Name == "Angle2")
                    {
                        model.Angle2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "StDx2")
                    {
                        model.StDx2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "StDy2")
                    {
                        model.StDy2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "XOffsetAllowed")
                    {
                        model.XOffsetAllowed = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "YOffsetAllowed")
                    {
                        model.YOffsetAllowed = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "AngleOffsetAllowed")
                    {
                        model.AngleOffsetAllowed = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "YOffsetAllowed")
                    {
                        model.YOffsetAllowed = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "AngleOffsetAllowed")
                    {
                        model.AngleOffsetAllowed = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "CellLength1")
                    {
                        model.CellLength1 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "CellLength1Limits")
                    {
                        model.CellLength1Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "CellLength2")
                    {
                        model.CellLength2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "CellLength2Limits")
                    {
                        model.CellLength2Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthA1")
                    {
                        model.WidthA1 = (float)Convert.ToDecimal(item1.Value);
                    }

                    if (item1.Name == "WidthA1Limits")
                    {
                        model.WidthA1Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthB1")
                    {
                        model.WidthB1 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthB1Limits")
                    {
                        model.WidthB1Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthA2")
                    {
                        model.WidthA2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthA2Limits")
                    {
                        model.WidthA2Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthB2")
                    {
                        model.WidthB2 = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (item1.Name == "WidthB2Limits")
                    {
                        model.WidthB2Limits = (float)Convert.ToDecimal(item1.Value);
                    }
                    if (model.sMidPoint != null)
                    {
                        model.MidPoint = new Models.Point();
                        if (model.sMidPoint.Split(',').Length > 1)
                        {
                            model.MidPoint.PointX = (float)Convert.ToDecimal(model.sMidPoint.Split(',')[0]);
                            model.MidPoint.PointY = (float)Convert.ToDecimal(model.sMidPoint.Split(',')[1]);
                        }
                    }
                    if (model.sMidPoint2 != null)
                    {
                        model.MidPoint2 = new Models.Point();
                        if (model.sMidPoint2.Split(',').Length > 1)
                        {
                            model.MidPoint2.PointX = (float)Convert.ToDecimal(model.sMidPoint2.Split(',')[0]);
                            model.MidPoint2.PointY = (float)Convert.ToDecimal(model.sMidPoint2.Split(',')[1]);
                        }
                    }

                }
                lProdStdData.Add(model);
                model = new ProdStdData();
            }

            if (lProdStdData.Count > 0)
            {
                if (!string.IsNullOrEmpty(CurrProCode))
                {
                    SetProdStdData(lProdStdData.FirstOrDefault(m => m.Code == CurrProCode));
                }
                else
                {
                    SetProdStdData(lProdStdData[0]);
                }
            }
        }

        private void SetProdStdData(ProdStdData prodStdData)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    SetProdStdDataToUI(prodStdData);
                }));
            }
            else
            {
                SetProdStdDataToUI(prodStdData);
            }
        }

        private void SetProdStdDataToUI(ProdStdData prodStdData)
        {
            lblProdName.Text = prodStdData.Name;
            lblProdNameShow.Text = prodStdData.Name;
            lblStdMidPoint.Text = prodStdData.sMidPoint;
            lblStdAngle.Text = prodStdData.Angle.ToString();
            lblStdMidPoint2.Text = prodStdData.sMidPoint2;
            lblStdAngle2.Text = prodStdData.Angle2.ToString();
            lblStdXOffset.Text = prodStdData.XOffsetAllowed.ToString();
            lblStdYOffset.Text = prodStdData.YOffsetAllowed.ToString();
            lblStdAngleOffset.Text = prodStdData.AngleOffsetAllowed.ToString();
            CurrProStdData = prodStdData;
        }

        private void SetLabelText(Label lable, string msg)
        {
            if (lable.InvokeRequired)
            {
                lable.Invoke(new MethodInvoker(delegate ()
                {
                    lable.Text = msg;
                }));
            }
            else
            {
                lable.Text = msg;
            }

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            serverSocket.Close();
            if (socketSend != null)
                socketSend.Close();
            //终止线程
            AcceptSocketThread.Abort();
            if (threadReceive != null)
                threadReceive.Abort();

            CogFrameGrabbers frame = new CogFrameGrabbers();
            foreach (Cognex.VisionPro.ICogFrameGrabber fg in frame)
                fg.Disconnect(true);

            GC.Collect();

            Application.Exit();
            Environment.Exit(0);
        }

        private void btnCameraIsLink_Click(object sender, EventArgs e)
        {
            var sCamera = LanguageHelper.GetString("fm_Camera");
            JudgementCameraLinked();
            if (!CameraIsLink[0] && !CameraIsLink[1])
            {

                MessageBox.Show(sCamera + "1 " + sCamera + "2" + LanguageHelper.GetString("fm_Msg24"), LanguageHelper.GetString("fm_Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!CameraIsLink[0])
            {
                MessageBox.Show(sCamera + "1" + LanguageHelper.GetString("fm_Msg24"), LanguageHelper.GetString("fm_Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!CameraIsLink[1])
            {
                MessageBox.Show(sCamera + "2" + LanguageHelper.GetString("fm_Msg24"), LanguageHelper.GetString("fm_Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (CameraIsLink[0] && CameraIsLink[1])
            {
                MessageBox.Show(sCamera + "1" + sCamera + "2" + LanguageHelper.GetString("fm_Msg23"), LanguageHelper.GetString("fm_Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void tsmtAddTB_Click(object sender, EventArgs e)
        {
            frmTBadd frmTBadd = new frmTBadd();
            frmTBadd.reLoadTBInspection += new frmTBadd.reLoadTBInspectionHandler(delegate ()
            {
                CurrProCode = iniHelper.IniReadValue("SysSeting", "CurrentProductCode");
                LoadXMLData();
                Thread t1 = new Thread(new ThreadStart(ReLoadTB));
                t1.Start();
            });
            frmTBadd.ShowDialog();
        }

        private void tsmtEditTB_Click(object sender, EventArgs e)
        {
            frmBaseTB frmBaseTB = new frmBaseTB();
            frmBaseTB.ShowDialog();
        }

        private void tsmtSwitchTB_Click(object sender, EventArgs e)
        {
            frmSwitchTB frmSwitchTB = new frmSwitchTB();
            frmSwitchTB.reLoadTBInspection += new frmSwitchTB.reLoadTBInspectionHandler(delegate ()
            {
                CurrProCode = iniHelper.IniReadValue("SysSeting", "CurrentProductCode");
                LoadXMLData();
                Thread t1 = new Thread(new ThreadStart(ReLoadTB));
                t1.Start();
            });
            frmSwitchTB.ShowDialog();
        }

        private void tsmtCurrTB_Click(object sender, EventArgs e)
        {
            frmCurrTB frmCurrTB = new frmCurrTB(this.CurrProStdData.Name, ToolBlockPath[0], ToolBlockPath[1], ToolBlockPath[2], ToolBlockPath[3], (CogImage8Grey)TB_Inspection[0].Inputs["InputImage"].Value, (CogImage8Grey)TB_Inspection[1].Inputs["InputImage"].Value, (CogImage8Grey)TB_Inspection[2].Inputs["InputImage"].Value, (CogImage8Grey)TB_Inspection[3].Inputs["InputImage"].Value);
            frmCurrTB.reLoadTBInspection += new frmCurrTB.reLoadTBInspectionHandler(delegate (bool hasChange)
            {
                //if (hasChange)
                //{
                Thread t1 = new Thread(new ThreadStart(ReLoadTB));
                t1.Start();
                //}
            });
            frmCurrTB.ShowDialog();
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            JudgementCameraLinked();
        }

        private void ReLoadRunMode()
        {
            runningMode = (RunningMode)Convert.ToInt32(iniHelper.IniReadValue("SysSeting", "RunningMode"));
            InitRunMode();
        }
        private void ReLoadTB()
        {
            ToggleBar(true);
            setBarValue(10);
            LoadTB_Inspection(0);
            setBarValue(30);
            LoadTB_Inspection(1);
            setBarValue(60);
            LoadTB_Inspection(2);
            setBarValue(80);
            LoadTB_Inspection(3);
            setBarValue(100);
            Thread.Sleep(1000);
            ToggleBar(false);
            setBarValue(0);
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
                    toolStripProgressBar1.Value = pValue;
                }
                if (pValue == 100)
                {
                    toolStripProgressBar1.Value = pValue;
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
                    ToolStripStatusLabel2.Visible = true;
                    toolStripProgressBar1.Visible = true;
                }
                else
                {
                    ToolStripStatusLabel2.Visible = false;
                    toolStripProgressBar1.Visible = false;
                }
            }
        }



    }
}
