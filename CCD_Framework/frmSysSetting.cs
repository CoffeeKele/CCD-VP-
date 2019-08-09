using CCD_Framework.Controls;
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
    public partial class frmSysSetting : Form
    {
        public frmSysSetting()
        {
            InitializeComponent();
            SettingOneUI settingOneUI = new SettingOneUI();
            settingOneUI.Name = "settingOne";
            settingOneUI.Close += new SettingOneUI.CloseHandler(CloseForm);
            settingOneUI.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(settingOneUI);
        }

        public void CloseForm()
        {
            this.Close();
        }

        private void frmSysSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
