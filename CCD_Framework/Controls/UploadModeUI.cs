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
using Cognex.VisionPro.ImageFile;
using CCD_Framework.Models;
using Cognex.VisionPro.ImageProcessing;
using System.Threading;
using CCD_Framework.Helper;

namespace CCD_Framework.Controls
{
    public partial class UploadModeUI : UserControl
    {

        public delegate void uploadRun1Handler(CogImage8Grey camera1Image);
        public event uploadRun1Handler uploadRun1;

        public delegate void uploadRun2Handler(CogImage8Grey camera2Image);
        public event uploadRun2Handler uploadRun2;

        private Queue<CogImage8Grey> Camera1ImageQueue;
        private Queue<CogImage8Grey> Camera2ImageQueue;

        public UploadModeUI()
        {
            InitializeComponent();
            btnRun1.Enabled = false;
            btnRun2.Enabled = false;
            pbLoadingBar1.Visible = false;
            pbLoadingBar2.Visible = false;
        }
        public UploadModeUI(string name1,string name2)
        {
            InitializeComponent();
            btnRun1.Enabled = false;
            btnRun2.Enabled = false;
            pbLoadingBar1.Visible = false;
            pbLoadingBar2.Visible = false;

            ReLoadLanguage(name1, name2);
        }

        public void ReLoadLanguage(string name1, string name2)
        {
            this.groupBox1.Text = name1;
            this.groupBox2.Text = name2;
            this.btnUpload1.Text = LanguageHelper.GetString("um_UP");
            this.btnRun1.Text = LanguageHelper.GetString("um_Run")+"(0)";
            this.btnUpload2.Text = LanguageHelper.GetString("um_UP");
            this.btnRun2.Text = LanguageHelper.GetString("um_Run") + "(0)";
        }

        private void btnUpload1_Click(object sender, EventArgs e)
        {

            try
            {
                var cogImageFileTool = new CogImageFileTool();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff|"+LanguageHelper.GetString("um_AF") + "(*.*)|*.*||";
                openFileDialog.AutoUpgradeEnabled = true;
                openFileDialog.Title = LanguageHelper.GetString("um_SP");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    pbLoadingBar1.Visible = true;
                    Camera1ImageQueue = new Queue<CogImage8Grey>();
                    new Thread(new ThreadStart(delegate ()
                    {
                        for (var index = 0; index < openFileDialog.FileNames.Count(); index++)
                        {
                            cogImageFileTool.Operator.Open(openFileDialog.FileNames[index], CogImageFileModeConstants.Read);
                            cogImageFileTool.Run();
                            if (cogImageFileTool.OutputImage.GetType().Equals(typeof(CogImage24PlanarColor)))
                            {
                                CogImageConvertTool cogImageConvertTool = new CogImageConvertTool();
                                cogImageConvertTool.InputImage = cogImageFileTool.OutputImage;
                                cogImageConvertTool.Run();
                                Camera1ImageQueue.Enqueue((CogImage8Grey)cogImageConvertTool.OutputImage);

                            }
                            else
                            {
                                Camera1ImageQueue.Enqueue((CogImage8Grey)cogImageFileTool.OutputImage);
                            }

                        }
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                pbLoadingBar1.Visible = false;
                                if (Camera1ImageQueue.Count > 0)
                                {
                                    btnRun1.Enabled = true;
                                    btnRun1.Text = LanguageHelper.GetString("um_Run") +"(" + Camera1ImageQueue.Count.ToString() + ")";
                                }
                            }));
                        }
                        else
                        {
                            pbLoadingBar1.Visible = false;
                            if (Camera1ImageQueue.Count > 0)
                            {
                                btnRun1.Enabled = true;
                                btnRun1.Text = LanguageHelper.GetString("um_Run") + "(" + Camera1ImageQueue.Count.ToString() + ")";
                            }
                        }
                        
                    })).Start();
                }
            }
            catch (Exception ex)
            {
                pbLoadingBar1.Visible = false;
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpload2_Click(object sender, EventArgs e)
        {
            try
            {

                var cogImageFileTool = new CogImageFileTool();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff|"+LanguageHelper.GetString("um_AF") +"(*.*)|*.*||";
                openFileDialog.AutoUpgradeEnabled = true;
                openFileDialog.Title = LanguageHelper.GetString("um_SP");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbLoadingBar2.Visible = true;
                    Camera2ImageQueue = new Queue<CogImage8Grey>();
                    new Thread(new ThreadStart(delegate ()
                    {
                        for (var index = 0; index < openFileDialog.FileNames.Count(); index++)
                        {


                            cogImageFileTool.Operator.Open(openFileDialog.FileNames[index], CogImageFileModeConstants.Read);
                            cogImageFileTool.Run();
                            if (cogImageFileTool.OutputImage.GetType().Equals(typeof(CogImage24PlanarColor)))
                            {
                                CogImageConvertTool cogImageConvertTool = new CogImageConvertTool();
                                cogImageConvertTool.InputImage = cogImageFileTool.OutputImage;
                                cogImageConvertTool.Run();
                                Camera2ImageQueue.Enqueue((CogImage8Grey)cogImageConvertTool.OutputImage);
                            }
                            else
                            {
                                Camera2ImageQueue.Enqueue((CogImage8Grey)cogImageFileTool.OutputImage);
                            }
                        }
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                pbLoadingBar2.Visible = false;
                                if (Camera2ImageQueue.Count > 0)
                                {
                                    btnRun2.Enabled = true;
                                    btnRun2.Text = LanguageHelper.GetString("um_Run") + "(" + Camera2ImageQueue.Count.ToString() + ")";
                                }
                            }));
                        }
                        else
                        {
                            pbLoadingBar2.Visible = false;
                            if (Camera2ImageQueue.Count > 0)
                            {
                                btnRun2.Enabled = true;
                                btnRun2.Text = LanguageHelper.GetString("um_Run") + "(" + Camera2ImageQueue.Count.ToString() + ")";
                            }
                        }
                    })).Start();
                }
            }
            catch (Exception ex)
            {
                pbLoadingBar2.Visible = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRun1_Click(object sender, EventArgs e)
        {
            if (Camera1ImageQueue.Count > 0)
            {

                uploadRun1?.Invoke(Camera1ImageQueue.Dequeue());
                if (Camera1ImageQueue.Count > 0)
                    btnRun1.Text = LanguageHelper.GetString("um_Run") + "(" + Camera1ImageQueue.Count.ToString() + ")";
                else
                {
                    btnRun1.Enabled = false;
                    btnRun1.Text = LanguageHelper.GetString("um_Run") + "(0)";
                }

            }
            else
            {
                btnRun1.Enabled = false;
                btnRun1.Text = LanguageHelper.GetString("um_Run") + "(0)";
            }
        }

        private void btnRun2_Click(object sender, EventArgs e)
        {
            if (Camera2ImageQueue.Count > 0)
            {
                uploadRun2?.Invoke(Camera2ImageQueue.Dequeue());
                if (Camera2ImageQueue.Count > 0)
                    btnRun2.Text = LanguageHelper.GetString("um_Run") + "(" + Camera2ImageQueue.Count.ToString() + ")";
                else
                {
                    btnRun2.Enabled = false;
                    btnRun2.Text = LanguageHelper.GetString("um_Run") + "(0)";

                }
            }
            else
            {
                btnRun2.Enabled = false;
                btnRun2.Text = LanguageHelper.GetString("um_Run") + "(0)";
            }
        }

        public delegate void setResult1Handler(RunResult relult);
        public void SetResult1(RunResult relult)
        {
            if (lblResult1.InvokeRequired)
            {
                lblResult1.Invoke(new setResult1Handler(SetResult1), new object[] { relult });
            }
            else
            {
                if (relult == RunResult.OK)
                {
                    lblResult1.ForeColor = Color.Green;
                }
                else
                {
                    lblResult1.ForeColor = Color.Red;
                }
                lblResult1.Text = relult.ToString();
            }
        }

        public delegate void setResult2Handler(RunResult relult);
        public void SetResult2(RunResult relult)
        {
            if (lblResult2.InvokeRequired)
            {
                lblResult2.Invoke(new setResult1Handler(SetResult2), new object[] { relult });
            }
            else
            {
                if (relult == RunResult.OK)
                {
                    lblResult2.ForeColor = Color.Green;
                }
                else
                {
                    lblResult2.ForeColor = Color.Red;
                }
                lblResult2.Text = relult.ToString();
            }
        }
    }
}
