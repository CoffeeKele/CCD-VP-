namespace CCD_Framework
{
    partial class frmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbZH = new System.Windows.Forms.RadioButton();
            this.rdbEN = new System.Windows.Forms.RadioButton();
            this.rdb2C = new System.Windows.Forms.RadioButton();
            this.rdb4C = new System.Windows.Forms.RadioButton();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdb4C);
            this.groupBox5.Controls.Add(this.rdb2C);
            this.groupBox5.Location = new System.Drawing.Point(16, 174);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(343, 58);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "相机运行模式设定";
            this.groupBox5.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(281, 242);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnClose.Size = new System.Drawing.Size(83, 33);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "关闭";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(183, 242);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.btnSave.Size = new System.Drawing.Size(83, 33);
            this.btnSave.TabIndex = 18;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "应用";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.groupBox2.Location = new System.Drawing.Point(675, 357);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Size = new System.Drawing.Size(12, 14);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tcp参数设定";
            this.groupBox2.Visible = false;
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.GhostWhite;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMsg.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.Location = new System.Drawing.Point(3, -16);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            this.lblMsg.Size = new System.Drawing.Size(6, 38);
            this.lblMsg.TabIndex = 11;
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.BackColor = System.Drawing.Color.White;
            this.btnTestConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestConnect.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTestConnect.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnTestConnect.Location = new System.Drawing.Point(610, 118);
            this.btnTestConnect.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(93, 40);
            this.btnTestConnect.TabIndex = 10;
            this.btnTestConnect.Text = "测试连接";
            this.btnTestConnect.UseVisualStyleBackColor = false;
            // 
            // txtBufferSize
            // 
            this.txtBufferSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBufferSize.Location = new System.Drawing.Point(127, 101);
            this.txtBufferSize.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtBufferSize.Name = "txtBufferSize";
            this.txtBufferSize.Size = new System.Drawing.Size(98, 23);
            this.txtBufferSize.TabIndex = 9;
            // 
            // txtPort
            // 
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPort.Location = new System.Drawing.Point(461, 42);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(98, 23);
            this.txtPort.TabIndex = 8;
            // 
            // txtIP
            // 
            this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIP.Location = new System.Drawing.Point(127, 42);
            this.txtIP.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(200, 23);
            this.txtIP.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "缓冲区大小：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "端口号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP地址：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbUpload);
            this.groupBox1.Controls.Add(this.rdbPhoto);
            this.groupBox1.Location = new System.Drawing.Point(16, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Size = new System.Drawing.Size(343, 67);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运行模式选择";
            // 
            // rdbUpload
            // 
            this.rdbUpload.AutoSize = true;
            this.rdbUpload.Location = new System.Drawing.Point(122, 28);
            this.rdbUpload.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
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
            this.rdbPhoto.Location = new System.Drawing.Point(24, 28);
            this.rdbPhoto.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.rdbPhoto.Name = "rdbPhoto";
            this.rdbPhoto.Size = new System.Drawing.Size(74, 21);
            this.rdbPhoto.TabIndex = 0;
            this.rdbPhoto.TabStop = true;
            this.rdbPhoto.Text = "相机拍照";
            this.rdbPhoto.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbZH);
            this.groupBox3.Controls.Add(this.rdbEN);
            this.groupBox3.Location = new System.Drawing.Point(16, 93);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(343, 61);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "语言选择";
            // 
            // rdbZH
            // 
            this.rdbZH.AutoSize = true;
            this.rdbZH.Location = new System.Drawing.Point(122, 23);
            this.rdbZH.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.rdbZH.Name = "rdbZH";
            this.rdbZH.Size = new System.Drawing.Size(74, 21);
            this.rdbZH.TabIndex = 3;
            this.rdbZH.TabStop = true;
            this.rdbZH.Text = "简体中文";
            this.rdbZH.UseVisualStyleBackColor = true;
            // 
            // rdbEN
            // 
            this.rdbEN.AutoSize = true;
            this.rdbEN.Location = new System.Drawing.Point(24, 23);
            this.rdbEN.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.rdbEN.Name = "rdbEN";
            this.rdbEN.Size = new System.Drawing.Size(50, 21);
            this.rdbEN.TabIndex = 2;
            this.rdbEN.TabStop = true;
            this.rdbEN.Text = "英语";
            this.rdbEN.UseVisualStyleBackColor = true;
            // 
            // rdb2C
            // 
            this.rdb2C.AutoSize = true;
            this.rdb2C.Location = new System.Drawing.Point(24, 23);
            this.rdb2C.Name = "rdb2C";
            this.rdb2C.Size = new System.Drawing.Size(82, 21);
            this.rdb2C.TabIndex = 0;
            this.rdb2C.Text = "2 Camera";
            this.rdb2C.UseVisualStyleBackColor = true;
            // 
            // rdb4C
            // 
            this.rdb4C.AutoSize = true;
            this.rdb4C.Checked = true;
            this.rdb4C.Location = new System.Drawing.Point(122, 23);
            this.rdb4C.Name = "rdb4C";
            this.rdb4C.Size = new System.Drawing.Size(82, 21);
            this.rdb4C.TabIndex = 1;
            this.rdb4C.TabStop = true;
            this.rdb4C.Text = "4 Camera";
            this.rdb4C.UseVisualStyleBackColor = true;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(376, 287);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "参数设定";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetting_FormClosed);
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMsg;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbZH;
        private System.Windows.Forms.RadioButton rdbEN;
        private System.Windows.Forms.RadioButton rdb4C;
        private System.Windows.Forms.RadioButton rdb2C;
    }
}