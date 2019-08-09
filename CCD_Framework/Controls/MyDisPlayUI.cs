using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro.ToolBlock;
using CCD_Framework.Helper;

namespace CCD_Framework.Controls
{
    public partial class MyDisPlayUI : UserControl
    {
        public MyDisPlayUI()
        {
            InitializeComponent();
            CogDisplayToolbarV21.Display = CogRecordDisplay1;
            CogDisplayStatusBarV21.Display = CogRecordDisplay1;
        }
        public MyDisPlayUI(int index)
        {
            InitializeComponent();
            CogDisplayToolbarV21.Display = CogRecordDisplay1;
            CogDisplayStatusBarV21.Display = CogRecordDisplay1;
    
            label1.Text = LanguageHelper.GetString("common_Camera") + index.ToString();
        }
        public void reLoadLanguage(int index)
        {
            label1.Text = LanguageHelper.GetString("common_Camera") + index.ToString();
        }
        public Cognex.VisionPro.ICogImage Image
        {
            get
            {
                return CogRecordDisplay1.Image;
            }
            set
            {
                CogRecordDisplay1.Image = value;
            }
        }

        public void Fit()
        {
            CogRecordDisplay1.Fit();
        }
        public void StopLiveDisplay()
        {
            CogRecordDisplay1.StopLiveDisplay();
        }

        public void StartLiveDisplay(ref object AcqFifo, bool IsTrue)
        {
            CogRecordDisplay1.StartLiveDisplay(AcqFifo, IsTrue);
        }
    }
}
