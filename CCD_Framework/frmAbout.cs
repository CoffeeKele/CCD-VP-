using CCD_Framework.Helper;
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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Point mouseOff;//鼠标移动位置变量  
        //bool leftFlag;//标签是否为左键  
        private void frmAbout_MouseMove(object sender, MouseEventArgs e)
        {
            //if (leftFlag)
            //{
            //    Point mouseSet = Control.MousePosition;
            //    mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置  
            //    this.Location = mouseSet;
            //}
        }

        private void frmAbout_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    mouseOff = new Point(-e.X, -e.Y); //得到变量的值  
            //    leftFlag = true;
            //}
        }

        private void frmAbout_MouseUp(object sender, MouseEventArgs e)
        {
            //if (leftFlag)
            //{
            //    leftFlag = false;//释放鼠标后标注为false;  
            //}
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            if(LanguageHelper.CurrenLan==Models.Language.EN_US)
            {
                this.Text = "About";
                this.label1.Text = "Company Address：No.188 .Tongdun Street ,Suzhou,China.";
                this.label3.Text = "Phone:15995415885";
                this.label4.Text = "Website: http://www.sc-solar.com.cn/";
                this.label2.Text = "Version: 19.06.17.01";
                this.btnOK.Text = "OK ";
            }
        }
    }
}
