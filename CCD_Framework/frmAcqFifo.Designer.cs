namespace CCD_Framework
{
    partial class frmAcqFifo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcqFifo));
            this.CogAcqFifoEditV21 = new Cognex.VisionPro.CogAcqFifoEditV2();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CogAcqFifoEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // CogAcqFifoEditV21
            // 
            this.CogAcqFifoEditV21.BackColor = System.Drawing.Color.White;
            this.CogAcqFifoEditV21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CogAcqFifoEditV21.Location = new System.Drawing.Point(0, 0);
            this.CogAcqFifoEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.CogAcqFifoEditV21.Name = "CogAcqFifoEditV21";
            this.CogAcqFifoEditV21.Size = new System.Drawing.Size(814, 443);
            this.CogAcqFifoEditV21.SuspendElectricRuns = false;
            this.CogAcqFifoEditV21.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.Location = new System.Drawing.Point(724, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAcqFifo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 443);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.CogAcqFifoEditV21);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAcqFifo";
            this.Text = "相机设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAcqFifo_FormClosed);
            this.Load += new System.EventHandler(this.frmAcqFifo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CogAcqFifoEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CogAcqFifoEditV2 CogAcqFifoEditV21;
        private System.Windows.Forms.Button btnSave;
    }
}