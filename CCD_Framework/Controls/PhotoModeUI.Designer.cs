namespace CCD_Framework.Controls
{
    partial class PhotoModeUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoModeUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLiveVideo1 = new System.Windows.Forms.Button();
            this.btnRun1 = new System.Windows.Forms.Button();
            this.rdoAutoRun1 = new System.Windows.Forms.RadioButton();
            this.rdoManualRun1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLiveVideo2 = new System.Windows.Forms.Button();
            this.rdoAutoRun2 = new System.Windows.Forms.RadioButton();
            this.btnRun2 = new System.Windows.Forms.Button();
            this.rdoManualRun2 = new System.Windows.Forms.RadioButton();
            this.lblMsg1 = new System.Windows.Forms.Label();
            this.lblMsg2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMsg1);
            this.groupBox1.Controls.Add(this.btnLiveVideo1);
            this.groupBox1.Controls.Add(this.btnRun1);
            this.groupBox1.Controls.Add(this.rdoAutoRun1);
            this.groupBox1.Controls.Add(this.rdoManualRun1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(307, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机1";
            // 
            // btnLiveVideo1
            // 
            this.btnLiveVideo1.BackColor = System.Drawing.Color.White;
            this.btnLiveVideo1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLiveVideo1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLiveVideo1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLiveVideo1.Image = ((System.Drawing.Image)(resources.GetObject("btnLiveVideo1.Image")));
            this.btnLiveVideo1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLiveVideo1.Location = new System.Drawing.Point(28, 44);
            this.btnLiveVideo1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnLiveVideo1.Name = "btnLiveVideo1";
            this.btnLiveVideo1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnLiveVideo1.Size = new System.Drawing.Size(90, 30);
            this.btnLiveVideo1.TabIndex = 10;
            this.btnLiveVideo1.Text = "实时显示";
            this.btnLiveVideo1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLiveVideo1.UseVisualStyleBackColor = false;
            this.btnLiveVideo1.Click += new System.EventHandler(this.btnLiveVideo1_Click);
            // 
            // btnRun1
            // 
            this.btnRun1.BackColor = System.Drawing.Color.White;
            this.btnRun1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRun1.Image = ((System.Drawing.Image)(resources.GetObject("btnRun1.Image")));
            this.btnRun1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun1.Location = new System.Drawing.Point(140, 44);
            this.btnRun1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnRun1.Name = "btnRun1";
            this.btnRun1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnRun1.Size = new System.Drawing.Size(82, 30);
            this.btnRun1.TabIndex = 9;
            this.btnRun1.Text = "拍照";
            this.btnRun1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun1.UseVisualStyleBackColor = false;
            this.btnRun1.Click += new System.EventHandler(this.btnRun1_Click);
            // 
            // rdoAutoRun1
            // 
            this.rdoAutoRun1.AutoSize = true;
            this.rdoAutoRun1.Location = new System.Drawing.Point(18, 20);
            this.rdoAutoRun1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.rdoAutoRun1.Name = "rdoAutoRun1";
            this.rdoAutoRun1.Size = new System.Drawing.Size(50, 21);
            this.rdoAutoRun1.TabIndex = 6;
            this.rdoAutoRun1.TabStop = true;
            this.rdoAutoRun1.Text = "自动";
            this.rdoAutoRun1.UseVisualStyleBackColor = true;
            // 
            // rdoManualRun1
            // 
            this.rdoManualRun1.AutoSize = true;
            this.rdoManualRun1.Location = new System.Drawing.Point(90, 20);
            this.rdoManualRun1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.rdoManualRun1.Name = "rdoManualRun1";
            this.rdoManualRun1.Size = new System.Drawing.Size(50, 21);
            this.rdoManualRun1.TabIndex = 7;
            this.rdoManualRun1.TabStop = true;
            this.rdoManualRun1.Text = "手动";
            this.rdoManualRun1.UseVisualStyleBackColor = true;
            this.rdoManualRun1.CheckedChanged += new System.EventHandler(this.rdoManualRun1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMsg2);
            this.groupBox2.Controls.Add(this.btnLiveVideo2);
            this.groupBox2.Controls.Add(this.rdoAutoRun2);
            this.groupBox2.Controls.Add(this.btnRun2);
            this.groupBox2.Controls.Add(this.rdoManualRun2);
            this.groupBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 80);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(307, 84);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "相机2";
            // 
            // btnLiveVideo2
            // 
            this.btnLiveVideo2.BackColor = System.Drawing.Color.White;
            this.btnLiveVideo2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLiveVideo2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLiveVideo2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLiveVideo2.Image = ((System.Drawing.Image)(resources.GetObject("btnLiveVideo2.Image")));
            this.btnLiveVideo2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLiveVideo2.Location = new System.Drawing.Point(29, 45);
            this.btnLiveVideo2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLiveVideo2.Name = "btnLiveVideo2";
            this.btnLiveVideo2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnLiveVideo2.Size = new System.Drawing.Size(90, 30);
            this.btnLiveVideo2.TabIndex = 17;
            this.btnLiveVideo2.Text = "实时显示";
            this.btnLiveVideo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLiveVideo2.UseVisualStyleBackColor = false;
            this.btnLiveVideo2.Click += new System.EventHandler(this.btnLiveVideo2_Click);
            // 
            // rdoAutoRun2
            // 
            this.rdoAutoRun2.AutoSize = true;
            this.rdoAutoRun2.Location = new System.Drawing.Point(19, 20);
            this.rdoAutoRun2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoAutoRun2.Name = "rdoAutoRun2";
            this.rdoAutoRun2.Size = new System.Drawing.Size(50, 21);
            this.rdoAutoRun2.TabIndex = 14;
            this.rdoAutoRun2.TabStop = true;
            this.rdoAutoRun2.Text = "自动";
            this.rdoAutoRun2.UseVisualStyleBackColor = true;
            // 
            // btnRun2
            // 
            this.btnRun2.BackColor = System.Drawing.Color.White;
            this.btnRun2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRun2.Image = ((System.Drawing.Image)(resources.GetObject("btnRun2.Image")));
            this.btnRun2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun2.Location = new System.Drawing.Point(141, 45);
            this.btnRun2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRun2.Name = "btnRun2";
            this.btnRun2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnRun2.Size = new System.Drawing.Size(82, 30);
            this.btnRun2.TabIndex = 16;
            this.btnRun2.Text = "拍照";
            this.btnRun2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun2.UseVisualStyleBackColor = false;
            this.btnRun2.Click += new System.EventHandler(this.btnRun2_Click);
            // 
            // rdoManualRun2
            // 
            this.rdoManualRun2.AutoSize = true;
            this.rdoManualRun2.Location = new System.Drawing.Point(91, 20);
            this.rdoManualRun2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoManualRun2.Name = "rdoManualRun2";
            this.rdoManualRun2.Size = new System.Drawing.Size(50, 21);
            this.rdoManualRun2.TabIndex = 15;
            this.rdoManualRun2.TabStop = true;
            this.rdoManualRun2.Text = "手动";
            this.rdoManualRun2.UseVisualStyleBackColor = true;
            this.rdoManualRun2.CheckedChanged += new System.EventHandler(this.rdoManualRun2_CheckedChanged);
            // 
            // lblMsg1
            // 
            this.lblMsg1.AutoSize = true;
            this.lblMsg1.Location = new System.Drawing.Point(163, 22);
            this.lblMsg1.Name = "lblMsg1";
            this.lblMsg1.Size = new System.Drawing.Size(0, 17);
            this.lblMsg1.TabIndex = 11;
            // 
            // lblMsg2
            // 
            this.lblMsg2.AutoSize = true;
            this.lblMsg2.Location = new System.Drawing.Point(163, 22);
            this.lblMsg2.Name = "lblMsg2";
            this.lblMsg2.Size = new System.Drawing.Size(0, 17);
            this.lblMsg2.TabIndex = 18;
            // 
            // PhotoModeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PhotoModeUI";
            this.Size = new System.Drawing.Size(307, 176);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoAutoRun1;
        private System.Windows.Forms.RadioButton rdoManualRun1;
        private System.Windows.Forms.Button btnLiveVideo1;
        private System.Windows.Forms.Button btnRun1;
        private System.Windows.Forms.Button btnLiveVideo2;
        private System.Windows.Forms.RadioButton rdoAutoRun2;
        private System.Windows.Forms.Button btnRun2;
        private System.Windows.Forms.RadioButton rdoManualRun2;
        private System.Windows.Forms.Label lblMsg1;
        private System.Windows.Forms.Label lblMsg2;
    }
}
