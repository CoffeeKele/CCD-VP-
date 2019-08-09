using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using CCD_Framework.Helper;

namespace CCD_Framework
{
    public partial class frmAcqFifo : Form
    {
        public delegate void saveTBAcqHandler(int index, ICogAcqFifo toolBlock);
        public event saveTBAcqHandler saveAcqFifo;
        private int toolIndex;
        public frmAcqFifo()
        {
            InitializeComponent();
        }
        public frmAcqFifo(CogAcqFifoTool AcqFifoTool, int index)
        {
            InitializeComponent();
            this.CogAcqFifoEditV21.Subject = AcqFifoTool;
            toolIndex = index;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            saveAcqFifo?.Invoke(toolIndex, this.CogAcqFifoEditV21.Subject.Operator);
            this.Close();
        }

        private void frmAcqFifo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void frmAcqFifo_Load(object sender, EventArgs e)
        {
            this.Text = LanguageHelper.GetString("faq_Text");
        }
    }
}
