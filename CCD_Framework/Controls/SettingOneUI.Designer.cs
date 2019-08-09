namespace CCD_Framework.Controls
{
    partial class SettingOneUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingOneUI));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.txtBufferSize = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbUpload = new System.Windows.Forms.RadioButton();
            this.rdbPhoto = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPathView2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPathView2 = new System.Windows.Forms.TextBox();
            this.rdbRelative2 = new System.Windows.Forms.RadioButton();
            this.rdbAbsolute2 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnPathView1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPathView1 = new System.Windows.Forms.TextBox();
            this.rdbRelative1 = new System.Windows.Forms.RadioButton();
            this.rdbAbsolute1 = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMsg);
            this.groupBox2.Controls.Add(this.btnTestConnect);
            this.groupBox2.Controls.Add(this.txtBufferSize);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.txtIP);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(622, 438);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(10, 10);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tcp参数设定";
            this.groupBox2.Visible = false;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.GhostWhite;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMsg.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.Location = new System.Drawing.Point(3, -7);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblMsg.Size = new System.Drawing.Size(4, 27);
            this.lblMsg.TabIndex = 11;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.BackColor = System.Drawing.Color.White;
            this.btnTestConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestConnect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestConnect.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnTestConnect.Location = new System.Drawing.Point(523, 83);
            this.btnTestConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(80, 28);
            this.btnTestConnect.TabIndex = 10;
            this.btnTestConnect.Text = "测试连接";
            this.btnTestConnect.UseVisualStyleBackColor = false;
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // txtBufferSize
            // 
            this.txtBufferSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBufferSize.Location = new System.Drawing.Point(109, 71);
            this.txtBufferSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBufferSize.Name = "txtBufferSize";
            this.txtBufferSize.Size = new System.Drawing.Size(84, 23);
            this.txtBufferSize.TabIndex = 9;
            // 
            // txtPort
            // 
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPort.Location = new System.Drawing.Point(395, 30);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(84, 23);
            this.txtPort.TabIndex = 8;
            // 
            // txtIP
            // 
            this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIP.Location = new System.Drawing.Point(109, 30);
            this.txtIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(172, 23);
            this.txtIP.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "缓冲区大小：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "端口号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP地址：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbUpload);
            this.groupBox1.Controls.Add(this.rdbPhoto);
            this.groupBox1.Location = new System.Drawing.Point(16, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(616, 65);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运行模式选择";
            // 
            // rdbUpload
            // 
            this.rdbUpload.AutoSize = true;
            this.rdbUpload.Location = new System.Drawing.Point(164, 28);
            this.rdbUpload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbUpload.Name = "rdbUpload";
            this.rdbUpload.Size = new System.Drawing.Size(74, 21);
            this.rdbUpload.TabIndex = 1;
            this.rdbUpload.TabStop = true;
            this.rdbUpload.Text = "照片上传";
            this.rdbUpload.UseVisualStyleBackColor = true;
            // 
            // rdbPhoto
            // 
            this.rdbPhoto.AutoSize = true;
            this.rdbPhoto.Location = new System.Drawing.Point(46, 28);
            this.rdbPhoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbPhoto.Name = "rdbPhoto";
            this.rdbPhoto.Size = new System.Drawing.Size(74, 21);
            this.rdbPhoto.TabIndex = 0;
            this.rdbPhoto.TabStop = true;
            this.rdbPhoto.Text = "相机拍照";
            this.rdbPhoto.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(456, 237);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSave.Size = new System.Drawing.Size(80, 32);
            this.btnSave.TabIndex = 11;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "应用";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPathView2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtPathView2);
            this.groupBox3.Controls.Add(this.rdbRelative2);
            this.groupBox3.Controls.Add(this.rdbAbsolute2);
            this.groupBox3.Location = new System.Drawing.Point(23, 92);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(615, 10);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "算法文件路径";
            this.groupBox3.Visible = false;
            // 
            // btnPathView2
            // 
            this.btnPathView2.BackColor = System.Drawing.Color.White;
            this.btnPathView2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPathView2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPathView2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnPathView2.Location = new System.Drawing.Point(538, 54);
            this.btnPathView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPathView2.Name = "btnPathView2";
            this.btnPathView2.Size = new System.Drawing.Size(68, 28);
            this.btnPathView2.TabIndex = 11;
            this.btnPathView2.Text = "浏览...";
            this.btnPathView2.UseVisualStyleBackColor = false;
            this.btnPathView2.Click += new System.EventHandler(this.btnPathView2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "类别：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "路径：";
            // 
            // txtPathView2
            // 
            this.txtPathView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPathView2.Location = new System.Drawing.Point(110, 57);
            this.txtPathView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPathView2.Name = "txtPathView2";
            this.txtPathView2.Size = new System.Drawing.Size(420, 23);
            this.txtPathView2.TabIndex = 7;
            // 
            // rdbRelative2
            // 
            this.rdbRelative2.AutoSize = true;
            this.rdbRelative2.Location = new System.Drawing.Point(197, 25);
            this.rdbRelative2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbRelative2.Name = "rdbRelative2";
            this.rdbRelative2.Size = new System.Drawing.Size(74, 21);
            this.rdbRelative2.TabIndex = 6;
            this.rdbRelative2.TabStop = true;
            this.rdbRelative2.Text = "相对路径";
            this.rdbRelative2.UseVisualStyleBackColor = true;
            // 
            // rdbAbsolute2
            // 
            this.rdbAbsolute2.AutoSize = true;
            this.rdbAbsolute2.Location = new System.Drawing.Point(110, 25);
            this.rdbAbsolute2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbAbsolute2.Name = "rdbAbsolute2";
            this.rdbAbsolute2.Size = new System.Drawing.Size(74, 21);
            this.rdbAbsolute2.TabIndex = 5;
            this.rdbAbsolute2.TabStop = true;
            this.rdbAbsolute2.Text = "绝对路径";
            this.rdbAbsolute2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPathView1);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtPathView1);
            this.groupBox4.Controls.Add(this.rdbRelative1);
            this.groupBox4.Controls.Add(this.rdbAbsolute1);
            this.groupBox4.Location = new System.Drawing.Point(17, 83);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(615, 10);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "相机配置文件路径";
            this.groupBox4.Visible = false;
            // 
            // btnPathView1
            // 
            this.btnPathView1.BackColor = System.Drawing.Color.White;
            this.btnPathView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPathView1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPathView1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnPathView1.Location = new System.Drawing.Point(538, 55);
            this.btnPathView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPathView1.Name = "btnPathView1";
            this.btnPathView1.Size = new System.Drawing.Size(68, 28);
            this.btnPathView1.TabIndex = 11;
            this.btnPathView1.Text = "浏览...";
            this.btnPathView1.UseVisualStyleBackColor = false;
            this.btnPathView1.Click += new System.EventHandler(this.btnPathView1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "类别：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "路径：";
            // 
            // txtPathView1
            // 
            this.txtPathView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPathView1.Location = new System.Drawing.Point(110, 58);
            this.txtPathView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPathView1.Name = "txtPathView1";
            this.txtPathView1.Size = new System.Drawing.Size(420, 23);
            this.txtPathView1.TabIndex = 2;
            // 
            // rdbRelative1
            // 
            this.rdbRelative1.AutoSize = true;
            this.rdbRelative1.Location = new System.Drawing.Point(197, 27);
            this.rdbRelative1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbRelative1.Name = "rdbRelative1";
            this.rdbRelative1.Size = new System.Drawing.Size(74, 21);
            this.rdbRelative1.TabIndex = 1;
            this.rdbRelative1.TabStop = true;
            this.rdbRelative1.Text = "相对路径";
            this.rdbRelative1.UseVisualStyleBackColor = true;
            // 
            // rdbAbsolute1
            // 
            this.rdbAbsolute1.AutoSize = true;
            this.rdbAbsolute1.Location = new System.Drawing.Point(110, 27);
            this.rdbAbsolute1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbAbsolute1.Name = "rdbAbsolute1";
            this.rdbAbsolute1.Size = new System.Drawing.Size(74, 21);
            this.rdbAbsolute1.TabIndex = 0;
            this.rdbAbsolute1.TabStop = true;
            this.rdbAbsolute1.Text = "绝对路径";
            this.rdbAbsolute1.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(561, 237);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnClose.Size = new System.Drawing.Size(80, 32);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "关闭";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(16, 83);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(612, 132);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "组件参数设定";
            // 
            // SettingOneUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SettingOneUI";
            this.Size = new System.Drawing.Size(653, 291);
            this.Load += new System.EventHandler(this.SettingOneUI_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTestConnect;
        private System.Windows.Forms.TextBox txtBufferSize;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbUpload;
        private System.Windows.Forms.RadioButton rdbPhoto;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPathView1;
        private System.Windows.Forms.RadioButton rdbRelative1;
        private System.Windows.Forms.RadioButton rdbAbsolute1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPathView2;
        private System.Windows.Forms.RadioButton rdbRelative2;
        private System.Windows.Forms.RadioButton rdbAbsolute2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPathView2;
        private System.Windows.Forms.Button btnPathView1;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}
