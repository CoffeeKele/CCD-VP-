using CCD_Framework.Controls;
using CCD_Framework.Helper;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace CCD_Framework
{
    public partial class frmImageSave : Form
    {
        public frmImageSave()
        {
            InitializeComponent();
            ImageSave imageSave = new ImageSave();
            imageSave.Name = "imageSave";
            imageSave.save += new ImageSave.SaveHandler(CloseForm);
            imageSave.cancel += new ImageSave.CancelHandler(CloseForm);
            imageSave.Dock = DockStyle.Fill;
            this.Controls.Add(imageSave);
            this.Text = LanguageHelper.GetString("is_Text");
        }

        public void CloseForm() {
            this.Close();
        }

        private void frmImageSave_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}



