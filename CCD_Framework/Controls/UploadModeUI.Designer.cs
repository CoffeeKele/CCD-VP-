namespace CCD_Framework.Controls
{
    partial class UploadModeUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadModeUI));
            this.pbLoadingBar1 = new System.Windows.Forms.PictureBox();
            this.btnUpload1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRun1 = new System.Windows.Forms.Button();
            this.lblResult1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblResult2 = new System.Windows.Forms.Label();
            this.btnRun2 = new System.Windows.Forms.Button();
            this.btnUpload2 = new System.Windows.Forms.Button();
            this.pbLoadingBar2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLoadingBar1
            // 
            this.pbLoadingBar1.Image = ((System.Drawing.Image)(resources.GetObject("pbLoadingBar1.Image")));
            this.pbLoadingBar1.Location = new System.Drawing.Point(23, 18);
            this.pbLoadingBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbLoadingBar1.Name = "pbLoadingBar1";
            this.pbLoadingBar1.Size = new System.Drawing.Size(195, 30);
            this.pbLoadingBar1.TabIndex = 12;
            this.pbLoadingBar1.TabStop = false;
            // 
            // btnUpload1
            // 
            this.btnUpload1.BackColor = System.Drawing.Color.White;
            this.btnUpload1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpload1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnUpload1.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload1.Image")));
            this.btnUpload1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload1.Location = new System.Drawing.Point(23, 40);
            this.btnUpload1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpload1.Name = "btnUpload1";
            this.btnUpload1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnUpload1.Size = new System.Drawing.Size(90, 30);
            this.btnUpload1.TabIndex = 11;
            this.btnUpload1.Text = "上传图片";
            this.btnUpload1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpload1.UseVisualStyleBackColor = false;
            this.btnUpload1.Click += new System.EventHandler(this.btnUpload1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRun1);
            this.groupBox1.Controls.Add(this.lblResult1);
            this.groupBox1.Controls.Add(this.btnUpload1);
            this.groupBox1.Controls.Add(this.pbLoadingBar1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(322, 78);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机1";
            // 
            // btnRun1
            // 
            this.btnRun1.BackColor = System.Drawing.Color.White;
            this.btnRun1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRun1.Image = ((System.Drawing.Image)(resources.GetObject("btnRun1.Image")));
            this.btnRun1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun1.Location = new System.Drawing.Point(131, 40);
            this.btnRun1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRun1.Name = "btnRun1";
            this.btnRun1.Padding = new System.Windows.Forms.Padding(10, 0, 2, 0);
            this.btnRun1.Size = new System.Drawing.Size(90, 30);
            this.btnRun1.TabIndex = 13;
            this.btnRun1.Text = "运行(0)";
            this.btnRun1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun1.UseVisualStyleBackColor = false;
            this.btnRun1.Click += new System.EventHandler(this.btnRun1_Click);
            // 
            // lblResult1
            // 
            this.lblResult1.BackColor = System.Drawing.Color.GhostWhite;
            this.lblResult1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblResult1.Location = new System.Drawing.Point(242, 30);
            this.lblResult1.Name = "lblResult1";
            this.lblResult1.Size = new System.Drawing.Size(51, 44);
            this.lblResult1.TabIndex = 14;
            this.lblResult1.Text = "R";
            this.lblResult1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblResult2);
            this.groupBox2.Controls.Add(this.btnRun2);
            this.groupBox2.Controls.Add(this.btnUpload2);
            this.groupBox2.Controls.Add(this.pbLoadingBar2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 80);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "相机2";
            // 
            // lblResult2
            // 
            this.lblResult2.BackColor = System.Drawing.Color.GhostWhite;
            this.lblResult2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblResult2.Location = new System.Drawing.Point(243, 32);
            this.lblResult2.Name = "lblResult2";
            this.lblResult2.Size = new System.Drawing.Size(51, 44);
            this.lblResult2.TabIndex = 19;
            this.lblResult2.Text = "R";
            this.lblResult2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRun2
            // 
            this.btnRun2.BackColor = System.Drawing.Color.White;
            this.btnRun2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRun2.Image = ((System.Drawing.Image)(resources.GetObject("btnRun2.Image")));
            this.btnRun2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun2.Location = new System.Drawing.Point(132, 43);
            this.btnRun2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRun2.Name = "btnRun2";
            this.btnRun2.Padding = new System.Windows.Forms.Padding(10, 0, 2, 0);
            this.btnRun2.Size = new System.Drawing.Size(90, 30);
            this.btnRun2.TabIndex = 16;
            this.btnRun2.Text = "运行(0)";
            this.btnRun2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun2.UseVisualStyleBackColor = false;
            this.btnRun2.Click += new System.EventHandler(this.btnRun2_Click);
            // 
            // btnUpload2
            // 
            this.btnUpload2.BackColor = System.Drawing.Color.White;
            this.btnUpload2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpload2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnUpload2.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload2.Image")));
            this.btnUpload2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload2.Location = new System.Drawing.Point(24, 43);
            this.btnUpload2.Name = "btnUpload2";
            this.btnUpload2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnUpload2.Size = new System.Drawing.Size(90, 30);
            this.btnUpload2.TabIndex = 17;
            this.btnUpload2.Text = "上传图片";
            this.btnUpload2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpload2.UseVisualStyleBackColor = false;
            this.btnUpload2.Click += new System.EventHandler(this.btnUpload2_Click);
            // 
            // pbLoadingBar2
            // 
            this.pbLoadingBar2.Image = ((System.Drawing.Image)(resources.GetObject("pbLoadingBar2.Image")));
            this.pbLoadingBar2.Location = new System.Drawing.Point(24, 20);
            this.pbLoadingBar2.Name = "pbLoadingBar2";
            this.pbLoadingBar2.Size = new System.Drawing.Size(196, 30);
            this.pbLoadingBar2.TabIndex = 18;
            this.pbLoadingBar2.TabStop = false;
            // 
            // UploadModeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UploadModeUI";
            this.Size = new System.Drawing.Size(322, 163);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingBar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLoadingBar1;
        private System.Windows.Forms.Button btnUpload1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRun1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbLoadingBar2;
        private System.Windows.Forms.Button btnUpload2;
        private System.Windows.Forms.Button btnRun2;
        private System.Windows.Forms.Label lblResult1;
        private System.Windows.Forms.Label lblResult2;
    }
}
