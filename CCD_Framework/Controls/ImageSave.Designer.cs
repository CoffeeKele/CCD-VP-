namespace CCD_Framework.Controls
{
    partial class ImageSave
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageSave));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbUseCognex = new System.Windows.Forms.CheckBox();
            this.ckbUseTimeForFileName = new System.Windows.Forms.CheckBox();
            this.ckbCreatDateFolder = new System.Windows.Forms.CheckBox();
            this.btnPathView = new System.Windows.Forms.Button();
            this.txtImageSavePath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbBMP = new System.Windows.Forms.CheckBox();
            this.ckbJPG = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbSaveCorrectImage = new System.Windows.Forms.RadioButton();
            this.rdbSaveErrorImage = new System.Windows.Forms.RadioButton();
            this.rdbSaveAllImage = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbSaveToLocal = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbUseCognex);
            this.groupBox1.Controls.Add(this.ckbUseTimeForFileName);
            this.groupBox1.Controls.Add(this.ckbCreatDateFolder);
            this.groupBox1.Controls.Add(this.btnPathView);
            this.groupBox1.Controls.Add(this.txtImageSavePath);
            this.groupBox1.Location = new System.Drawing.Point(14, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(644, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像保存路径";
            // 
            // ckbUseCognex
            // 
            this.ckbUseCognex.AutoSize = true;
            this.ckbUseCognex.Location = new System.Drawing.Point(370, 56);
            this.ckbUseCognex.Margin = new System.Windows.Forms.Padding(4);
            this.ckbUseCognex.Name = "ckbUseCognex";
            this.ckbUseCognex.Size = new System.Drawing.Size(167, 21);
            this.ckbUseCognex.TabIndex = 4;
            this.ckbUseCognex.Text = "使用Cognex工具保存图片";
            this.ckbUseCognex.UseVisualStyleBackColor = true;
            // 
            // ckbUseTimeForFileName
            // 
            this.ckbUseTimeForFileName.AutoSize = true;
            this.ckbUseTimeForFileName.Location = new System.Drawing.Point(177, 56);
            this.ckbUseTimeForFileName.Margin = new System.Windows.Forms.Padding(4);
            this.ckbUseTimeForFileName.Name = "ckbUseTimeForFileName";
            this.ckbUseTimeForFileName.Size = new System.Drawing.Size(159, 21);
            this.ckbUseTimeForFileName.TabIndex = 3;
            this.ckbUseTimeForFileName.Text = "图片名称以日期时间命名";
            this.ckbUseTimeForFileName.UseVisualStyleBackColor = true;
            // 
            // ckbCreatDateFolder
            // 
            this.ckbCreatDateFolder.AutoSize = true;
            this.ckbCreatDateFolder.Location = new System.Drawing.Point(8, 56);
            this.ckbCreatDateFolder.Margin = new System.Windows.Forms.Padding(4);
            this.ckbCreatDateFolder.Name = "ckbCreatDateFolder";
            this.ckbCreatDateFolder.Size = new System.Drawing.Size(135, 21);
            this.ckbCreatDateFolder.TabIndex = 2;
            this.ckbCreatDateFolder.Text = "自动生成日期文件夹";
            this.ckbCreatDateFolder.UseVisualStyleBackColor = true;
            // 
            // btnPathView
            // 
            this.btnPathView.BackColor = System.Drawing.Color.White;
            this.btnPathView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPathView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPathView.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnPathView.Location = new System.Drawing.Point(545, 21);
            this.btnPathView.Margin = new System.Windows.Forms.Padding(4);
            this.btnPathView.Name = "btnPathView";
            this.btnPathView.Size = new System.Drawing.Size(76, 30);
            this.btnPathView.TabIndex = 1;
            this.btnPathView.Text = "浏览...";
            this.btnPathView.UseVisualStyleBackColor = false;
            this.btnPathView.Click += new System.EventHandler(this.btnPathView_Click);
            // 
            // txtImageSavePath
            // 
            this.txtImageSavePath.Location = new System.Drawing.Point(8, 25);
            this.txtImageSavePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtImageSavePath.Name = "txtImageSavePath";
            this.txtImageSavePath.Size = new System.Drawing.Size(529, 23);
            this.txtImageSavePath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckbBMP);
            this.groupBox2.Controls.Add(this.ckbJPG);
            this.groupBox2.Location = new System.Drawing.Point(18, 102);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(143, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图像保存格式";
            // 
            // ckbBMP
            // 
            this.ckbBMP.AutoSize = true;
            this.ckbBMP.Location = new System.Drawing.Point(71, 30);
            this.ckbBMP.Margin = new System.Windows.Forms.Padding(4);
            this.ckbBMP.Name = "ckbBMP";
            this.ckbBMP.Size = new System.Drawing.Size(54, 21);
            this.ckbBMP.TabIndex = 1;
            this.ckbBMP.Text = "BPM";
            this.ckbBMP.UseVisualStyleBackColor = true;
            // 
            // ckbJPG
            // 
            this.ckbJPG.AutoSize = true;
            this.ckbJPG.Location = new System.Drawing.Point(18, 30);
            this.ckbJPG.Margin = new System.Windows.Forms.Padding(4);
            this.ckbJPG.Name = "ckbJPG";
            this.ckbJPG.Size = new System.Drawing.Size(48, 21);
            this.ckbJPG.TabIndex = 0;
            this.ckbJPG.Text = "JPG";
            this.ckbJPG.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbSaveCorrectImage);
            this.groupBox3.Controls.Add(this.rdbSaveErrorImage);
            this.groupBox3.Controls.Add(this.rdbSaveAllImage);
            this.groupBox3.Location = new System.Drawing.Point(202, 102);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(287, 64);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "需要保存的图片";
            // 
            // rdbSaveCorrectImage
            // 
            this.rdbSaveCorrectImage.AutoSize = true;
            this.rdbSaveCorrectImage.Location = new System.Drawing.Point(186, 30);
            this.rdbSaveCorrectImage.Margin = new System.Windows.Forms.Padding(4);
            this.rdbSaveCorrectImage.Name = "rdbSaveCorrectImage";
            this.rdbSaveCorrectImage.Size = new System.Drawing.Size(74, 21);
            this.rdbSaveCorrectImage.TabIndex = 2;
            this.rdbSaveCorrectImage.TabStop = true;
            this.rdbSaveCorrectImage.Text = "正确图片";
            this.rdbSaveCorrectImage.UseVisualStyleBackColor = true;
            // 
            // rdbSaveErrorImage
            // 
            this.rdbSaveErrorImage.AutoSize = true;
            this.rdbSaveErrorImage.Location = new System.Drawing.Point(98, 30);
            this.rdbSaveErrorImage.Margin = new System.Windows.Forms.Padding(4);
            this.rdbSaveErrorImage.Name = "rdbSaveErrorImage";
            this.rdbSaveErrorImage.Size = new System.Drawing.Size(74, 21);
            this.rdbSaveErrorImage.TabIndex = 1;
            this.rdbSaveErrorImage.TabStop = true;
            this.rdbSaveErrorImage.Text = "错误图片";
            this.rdbSaveErrorImage.UseVisualStyleBackColor = true;
            // 
            // rdbSaveAllImage
            // 
            this.rdbSaveAllImage.AutoSize = true;
            this.rdbSaveAllImage.Location = new System.Drawing.Point(8, 30);
            this.rdbSaveAllImage.Margin = new System.Windows.Forms.Padding(4);
            this.rdbSaveAllImage.Name = "rdbSaveAllImage";
            this.rdbSaveAllImage.Size = new System.Drawing.Size(74, 21);
            this.rdbSaveAllImage.TabIndex = 0;
            this.rdbSaveAllImage.TabStop = true;
            this.rdbSaveAllImage.Text = "所有图片";
            this.rdbSaveAllImage.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.White;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(484, 238);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnOK.Size = new System.Drawing.Size(76, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(583, 238);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnCancel.Size = new System.Drawing.Size(76, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckbSaveToLocal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 38);
            this.panel1.TabIndex = 6;
            // 
            // ckbSaveToLocal
            // 
            this.ckbSaveToLocal.AutoSize = true;
            this.ckbSaveToLocal.Location = new System.Drawing.Point(25, 10);
            this.ckbSaveToLocal.Name = "ckbSaveToLocal";
            this.ckbSaveToLocal.Size = new System.Drawing.Size(135, 21);
            this.ckbSaveToLocal.TabIndex = 0;
            this.ckbSaveToLocal.Text = "是否保存图片到本地";
            this.ckbSaveToLocal.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 188);
            this.panel2.TabIndex = 7;
            // 
            // ImageSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImageSave";
            this.Size = new System.Drawing.Size(675, 281);
            this.Load += new System.EventHandler(this.ImageSave_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPathView;
        private System.Windows.Forms.TextBox txtImageSavePath;
        private System.Windows.Forms.CheckBox ckbBMP;
        private System.Windows.Forms.CheckBox ckbJPG;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rdbSaveCorrectImage;
        private System.Windows.Forms.RadioButton rdbSaveErrorImage;
        private System.Windows.Forms.RadioButton rdbSaveAllImage;
        private System.Windows.Forms.CheckBox ckbUseCognex;
        private System.Windows.Forms.CheckBox ckbUseTimeForFileName;
        private System.Windows.Forms.CheckBox ckbCreatDateFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckbSaveToLocal;
        private System.Windows.Forms.Panel panel2;
    }
}
