using CCD_Framework.Helper;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Threading;
using System.Windows.Forms;

namespace CCD_Framework
{
    public partial class frmQuickBuild : Form
    {
        public delegate void saveTBInspectionHandler(int index, CogToolBlock toolBlock);
        public event saveTBInspectionHandler saveTBInspection;
        private int toolIndex;
        string ToolBlockPath = string.Empty;
        CogImage8Grey inputImage = null;
        private CogToolBlockEditV2 CogToolBlockEditV21;
        public frmQuickBuild()
        {
            InitializeComponent();
        }
        public frmQuickBuild(string ToolBlockPath, int index, CogImage8Grey inputImage)
        {
            InitializeComponent();
            this.ToolBlockPath = ToolBlockPath;
            this.inputImage = inputImage;
            toolIndex = index;
        }
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
                   
                    CogToolBlockEditV21 = new CogToolBlockEditV2();
                    CogToolBlockEditV21.Dock = DockStyle.Fill;
                    this.Controls.Add(CogToolBlockEditV21);
                    this.CogToolBlockEditV21.Subject = (CogToolBlock)CogSerializer.LoadObjectFromFile(ToolBlockPath);
                    if (inputImage != null)
                    {
                        this.CogToolBlockEditV21.Subject.Inputs["InputImage"].Value = inputImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("算法文件加载失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveTBInspection?.Invoke(toolIndex, this.CogToolBlockEditV21.Subject);
            this.Close();
        }

        private void frmQuickBuild_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void frmQuickBuild_Load(object sender, EventArgs e)
        {
            Thread t1 = new Thread(new ThreadStart(OpenTB));
            t1.Start();
            this.Text = LanguageHelper.GetString("fqb_Text");
        }
    }
}
