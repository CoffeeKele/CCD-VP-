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
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace CCD_Framework.Controls
{
    public partial class SettingOneUI : UserControl
    {
        public delegate void CloseHandler();
        public event CloseHandler Close;

        iniHelper iniHelper = new iniHelper(Application.StartupPath + @"\Config.ini");
        private string CurrentPCode = string.Empty;
        #region "TCP通讯变量"


        //主机IP地址
        private string IPAddress;
        //端口号
        private int Port;
        //缓冲区大小
        private int BufferSize;
        #endregion
        public SettingOneUI()
        {
            InitializeComponent();
            IPAddress = iniHelper.IniReadValue("TCPSeting", "IPAddress");
            Port = Convert.ToInt32(iniHelper.IniReadValue("TCPSeting", "Port"));
            BufferSize = Convert.ToInt32(iniHelper.IniReadValue("TCPSeting", "BufferSize"));
        }
        private void SettingOneUI_Load(object sender, EventArgs e)
        {
            var runningMode = (RunningMode)Convert.ToInt32(iniHelper.IniReadValue("SysSeting", "RunningMode"));
            if (runningMode == RunningMode.Photo) rdbPhoto.Checked = true;
            else if (runningMode == RunningMode.Upload) rdbUpload.Checked = true;

            var acqPathType = (PathType)Convert.ToInt32(iniHelper.IniReadValue("AcqSeting", "AcqPathType"));
            if (acqPathType == PathType.Absolute) rdbAbsolute1.Checked = true;
            else if (acqPathType == PathType.Relative) rdbRelative1.Checked = true;
            txtPathView1.Text = iniHelper.IniReadValue("AcqSeting", "AcqVppPath");

            var tBInspectionPathType = (PathType)Convert.ToInt32(iniHelper.IniReadValue("TBSeting", "TBInspectionPathType"));
            if (acqPathType == PathType.Absolute) rdbAbsolute2.Checked = true;
            else if (acqPathType == PathType.Relative) rdbRelative2.Checked = true;
            txtPathView2.Text = iniHelper.IniReadValue("TBSeting", "TBInspectionVppPath");

            //var recCellLength = Convert.ToInt32(iniHelper.IniReadValue("ProSeting", "RecCellLength"));
            //if (recCellLength == 0) chkRecCellL.Checked = false;
            //else if (recCellLength == 1) chkRecCellL.Checked = true;
            txtPathView2.Text = iniHelper.IniReadValue("TBSeting", "TBInspectionVppPath");


            txtIP.Text = IPAddress;
            txtPort.Text = Port.ToString();
            txtBufferSize.Text = BufferSize.ToString();

        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rdbPhoto.Checked) iniHelper.IniWriteValue("SysSeting", "RunningMode", ((int)RunningMode.Photo).ToString());
            else if (rdbUpload.Checked) iniHelper.IniWriteValue("SysSeting", "RunningMode", ((int)RunningMode.Upload).ToString());
            iniHelper.IniWriteValue("TCPSeting", "IPAddress", txtIP.Text.Trim());
            iniHelper.IniWriteValue("TCPSeting", "Port", txtPort.Text.Trim());
            iniHelper.IniWriteValue("TCPSeting", "BufferSize", txtBufferSize.Text.Trim());
            //if (chkRecCellL.Checked)
            //    iniHelper.IniWriteValue("ProSeting", "RecCellLength", "1");
            //else
            //    iniHelper.IniWriteValue("ProSeting", "RecCellLength", "0");
        }

        private void btnPathView1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPathView1.Text = dialog.SelectedPath;
            }
        }

        private void btnPathView2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPathView2.Text = dialog.SelectedPath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close?.Invoke();
        }

        private void chkRecCellL_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
