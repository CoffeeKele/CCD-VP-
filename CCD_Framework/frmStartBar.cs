using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCD_Framework
{
    public partial class frmStartBar : Form
    {
        frmMain fm = null;
        private delegate void _SetBarValue(int pValue, string text);
  
        public frmStartBar()
        {
            InitializeComponent();

        }
        public frmStartBar(frmMain fm)
        {
            InitializeComponent();
            this.fm = fm;
        }
        public void setBarValue(int pValue, string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new _SetBarValue(setBarValue), new object[] { pValue, text });
            }
            else
            {
                this.Text = text;
                if (pValue > 0 & pValue < 100)
                {
                    progressBar1.Value = pValue;
                }
                if (pValue == 100)
                {
                    progressBar1.Value = pValue;
                }
            }
        }
        private delegate void showMainHandler();
        public void showMain()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new showMainHandler(showMain), new object[] { });
            }
            else
            {
                if (fm != null)
                    this.fm.Show();
                this.Close();
                this.Dispose();
            }
        }
        private void frmStartBar_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (progressBar1.Value != 100)
                Environment.Exit(0);
        }

        private void frmStartBar_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
        }
    }
}
