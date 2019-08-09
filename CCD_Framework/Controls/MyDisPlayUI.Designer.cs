namespace CCD_Framework.Controls
{
    partial class MyDisPlayUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyDisPlayUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CogDisplayToolbarV21 = new Cognex.VisionPro.CogDisplayToolbarV2();
            this.panel3 = new System.Windows.Forms.Panel();
            this.CogDisplayStatusBarV21 = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CogRecordDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 29);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.GhostWhite;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "相机";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.CogDisplayToolbarV21);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(469, 30);
            this.panel2.TabIndex = 1;
            // 
            // CogDisplayToolbarV21
            // 
            this.CogDisplayToolbarV21.BackColor = System.Drawing.SystemColors.Control;
            this.CogDisplayToolbarV21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CogDisplayToolbarV21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CogDisplayToolbarV21.Location = new System.Drawing.Point(0, 0);
            this.CogDisplayToolbarV21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CogDisplayToolbarV21.Name = "CogDisplayToolbarV21";
            this.CogDisplayToolbarV21.Size = new System.Drawing.Size(469, 30);
            this.CogDisplayToolbarV21.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.CogDisplayStatusBarV21);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 468);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(469, 28);
            this.panel3.TabIndex = 2;
            // 
            // CogDisplayStatusBarV21
            // 
            this.CogDisplayStatusBarV21.BackColor = System.Drawing.Color.White;
            this.CogDisplayStatusBarV21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CogDisplayStatusBarV21.CoordinateSpaceName = "*\\#";
            this.CogDisplayStatusBarV21.CoordinateSpaceName3D = "*\\#";
            this.CogDisplayStatusBarV21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CogDisplayStatusBarV21.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CogDisplayStatusBarV21.Location = new System.Drawing.Point(0, 0);
            this.CogDisplayStatusBarV21.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CogDisplayStatusBarV21.Name = "CogDisplayStatusBarV21";
            this.CogDisplayStatusBarV21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CogDisplayStatusBarV21.Size = new System.Drawing.Size(469, 28);
            this.CogDisplayStatusBarV21.TabIndex = 0;
            this.CogDisplayStatusBarV21.Use3DCoordinateSpaceTree = false;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.CogRecordDisplay1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 59);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(469, 409);
            this.panel4.TabIndex = 3;
            // 
            // CogRecordDisplay1
            // 
            this.CogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.CogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.CogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.CogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.CogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.CogRecordDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CogRecordDisplay1.DoubleTapZoomCycleLength = 2;
            this.CogRecordDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.CogRecordDisplay1.Location = new System.Drawing.Point(0, 0);
            this.CogRecordDisplay1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.CogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.CogRecordDisplay1.Name = "CogRecordDisplay1";
            this.CogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CogRecordDisplay1.OcxState")));
            this.CogRecordDisplay1.Size = new System.Drawing.Size(467, 407);
            this.CogRecordDisplay1.TabIndex = 0;
            // 
            // MyDisPlayUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MyDisPlayUI";
            this.Size = new System.Drawing.Size(469, 496);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CogRecordDisplay1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private Cognex.VisionPro.CogDisplayToolbarV2 CogDisplayToolbarV21;
        public Cognex.VisionPro.CogRecordDisplay CogRecordDisplay1;
        private Cognex.VisionPro.CogDisplayStatusBarV2 CogDisplayStatusBarV21;
    }
}
