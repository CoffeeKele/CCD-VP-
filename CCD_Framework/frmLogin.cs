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
    public partial class frmLogin : Form
    {
        public delegate bool userLoginHandler(string userName, string pwd);
        public event userLoginHandler userLogin;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin();
        }

        private void UserLogin()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                lblMsg.Text = LanguageHelper.GetString("fl_Msg1");
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassWard.Text))
            {
                lblMsg.Text = LanguageHelper.GetString("fl_Msg2");
                txtPassWard.Focus();
                return;
            }
            var result = userLogin?.Invoke(txtUserName.Text, txtPassWard.Text);
            if (result != null && result == true)
            {
                this.Close();
            }
            else
            {
                lblMsg.Text = LanguageHelper.GetString("fl_Msg3");
                return;
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtUserName.Text))
                {
                    lblMsg.Text = LanguageHelper.GetString("fl_Msg1");
                    txtUserName.Focus();
                    return;
                }
                txtPassWard.Focus();
            }
        }
        private void txtPassWard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserLogin();

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (LanguageHelper.CurrenLan == Language.EN_US)
            {
                this.lblUserName.Left = 27 - 8;
                this.lblPassWard.Left = 27 - 8;
                this.btnLogin.Left = 206 - 18;
                this.btnLogin.Width = 78 + 26;
            }
            else if (LanguageHelper.CurrenLan == Language.ZH_CN)
            {
                this.lblUserName.Left = 27;
                this.lblPassWard.Left = 27;
                this.btnLogin.Left = 206;
                this.btnLogin.Width = 78;
            }
            this.Text = LanguageHelper.GetString("fm_menu_PL");
            this.lblUserName.Text = LanguageHelper.GetString("fl_UserName");
            this.lblPassWard.Text = LanguageHelper.GetString("fl_PassWard");
            this.btnLogin.Text = LanguageHelper.GetString("btn_Login");

        }
    }
}
