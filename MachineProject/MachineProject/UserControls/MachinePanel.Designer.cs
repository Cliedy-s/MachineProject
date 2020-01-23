namespace MachineProject
{
    partial class MachinePanel
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachinePanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.중지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.재시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picRedLight = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNomalAmount_V = new System.Windows.Forms.Label();
            this.lblDefectAmount_V = new System.Windows.Forms.Label();
            this.lblMahineName = new System.Windows.Forms.Label();
            this.lblTotalAmount_V = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRunningDTO = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDefectRateAlarm_V = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDefectRate_V = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.picGreenLight = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.runTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRedLight)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGreenLight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Controls.Add(this.picRedLight);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.picGreenLight);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 364);
            this.panel1.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.중지ToolStripMenuItem,
            this.재시작ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 48);
            // 
            // 중지ToolStripMenuItem
            // 
            this.중지ToolStripMenuItem.Name = "중지ToolStripMenuItem";
            this.중지ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.중지ToolStripMenuItem.Text = "일시중지";
            this.중지ToolStripMenuItem.Click += new System.EventHandler(this.일시중지ToolStripMenuItem_Click);
            // 
            // 재시작ToolStripMenuItem
            // 
            this.재시작ToolStripMenuItem.Name = "재시작ToolStripMenuItem";
            this.재시작ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.재시작ToolStripMenuItem.Text = "재시작";
            this.재시작ToolStripMenuItem.Click += new System.EventHandler(this.재시작ToolStripMenuItem_Click);
            // 
            // picRedLight
            // 
            this.picRedLight.Location = new System.Drawing.Point(115, 6);
            this.picRedLight.Name = "picRedLight";
            this.picRedLight.Size = new System.Drawing.Size(66, 66);
            this.picRedLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRedLight.TabIndex = 20;
            this.picRedLight.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblNomalAmount_V);
            this.panel2.Controls.Add(this.lblDefectAmount_V);
            this.panel2.Controls.Add(this.lblMahineName);
            this.panel2.Controls.Add(this.lblTotalAmount_V);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lblRunningDTO);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblDefectRateAlarm_V);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblDefectRate_V);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(6, 248);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 106);
            this.panel2.TabIndex = 24;
            // 
            // lblNomalAmount_V
            // 
            this.lblNomalAmount_V.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNomalAmount_V.Location = new System.Drawing.Point(128, 34);
            this.lblNomalAmount_V.Name = "lblNomalAmount_V";
            this.lblNomalAmount_V.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNomalAmount_V.Size = new System.Drawing.Size(62, 19);
            this.lblNomalAmount_V.TabIndex = 4;
            this.lblNomalAmount_V.Text = "0";
            this.lblNomalAmount_V.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDefectAmount_V
            // 
            this.lblDefectAmount_V.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDefectAmount_V.Location = new System.Drawing.Point(128, 49);
            this.lblDefectAmount_V.Name = "lblDefectAmount_V";
            this.lblDefectAmount_V.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDefectAmount_V.Size = new System.Drawing.Size(62, 19);
            this.lblDefectAmount_V.TabIndex = 13;
            this.lblDefectAmount_V.Text = "0";
            this.lblDefectAmount_V.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMahineName
            // 
            this.lblMahineName.AutoSize = true;
            this.lblMahineName.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMahineName.Location = new System.Drawing.Point(-3, 0);
            this.lblMahineName.Name = "lblMahineName";
            this.lblMahineName.Size = new System.Drawing.Size(120, 19);
            this.lblMahineName.TabIndex = 9;
            this.lblMahineName.Text = "MachineName";
            // 
            // lblTotalAmount_V
            // 
            this.lblTotalAmount_V.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalAmount_V.Location = new System.Drawing.Point(128, 19);
            this.lblTotalAmount_V.Name = "lblTotalAmount_V";
            this.lblTotalAmount_V.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotalAmount_V.Size = new System.Drawing.Size(62, 19);
            this.lblTotalAmount_V.TabIndex = 22;
            this.lblTotalAmount_V.Text = "0";
            this.lblTotalAmount_V.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(-2, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "정상 상품 수";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(176, 19);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(33, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "개";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(-2, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "불량 상품 수";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(-2, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "전체 상품 수";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(-2, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "불량률";
            // 
            // lblRunningDTO
            // 
            this.lblRunningDTO.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRunningDTO.Location = new System.Drawing.Point(179, -2);
            this.lblRunningDTO.Name = "lblRunningDTO";
            this.lblRunningDTO.Size = new System.Drawing.Size(30, 23);
            this.lblRunningDTO.TabIndex = 10;
            this.lblRunningDTO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(-2, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "불량률 마지노선";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(176, 34);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(33, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "개";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDefectRateAlarm_V
            // 
            this.lblDefectRateAlarm_V.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDefectRateAlarm_V.Location = new System.Drawing.Point(128, 87);
            this.lblDefectRateAlarm_V.Name = "lblDefectRateAlarm_V";
            this.lblDefectRateAlarm_V.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDefectRateAlarm_V.Size = new System.Drawing.Size(62, 19);
            this.lblDefectRateAlarm_V.TabIndex = 17;
            this.lblDefectRateAlarm_V.Text = "100";
            this.lblDefectRateAlarm_V.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(176, 49);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(33, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "개";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDefectRate_V
            // 
            this.lblDefectRate_V.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDefectRate_V.Location = new System.Drawing.Point(128, 71);
            this.lblDefectRate_V.Name = "lblDefectRate_V";
            this.lblDefectRate_V.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDefectRate_V.Size = new System.Drawing.Size(62, 19);
            this.lblDefectRate_V.TabIndex = 15;
            this.lblDefectRate_V.Text = "0";
            this.lblDefectRate_V.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(176, 71);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(33, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(176, 86);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(33, 19);
            this.label5.TabIndex = 25;
            this.label5.Text = "%";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picGreenLight
            // 
            this.picGreenLight.Location = new System.Drawing.Point(43, 6);
            this.picGreenLight.Name = "picGreenLight";
            this.picGreenLight.Size = new System.Drawing.Size(66, 66);
            this.picGreenLight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGreenLight.TabIndex = 19;
            this.picGreenLight.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("돋움체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 78);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(213, 160);
            this.listBox1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MachineProject.Properties.Resources.Led_Yellow_Light;
            this.pictureBox1.Location = new System.Drawing.Point(115, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Led_Green_Dark.png");
            this.imageList1.Images.SetKeyName(1, "Led_Green_Light.png");
            this.imageList1.Images.SetKeyName(2, "Led_Red_Dark.png");
            this.imageList1.Images.SetKeyName(3, "Led_Red_Light.png");
            this.imageList1.Images.SetKeyName(4, "Led_Yellow_Light.png");
            // 
            // runTimer
            // 
            this.runTimer.Interval = 1000;
            this.runTimer.Tick += new System.EventHandler(this.RunTimer_Tick);
            // 
            // MachinePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "MachinePanel";
            this.Size = new System.Drawing.Size(225, 364);
            this.Load += new System.EventHandler(this.MachinePanel_Load);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRedLight)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGreenLight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDefectRateAlarm_V;
        private System.Windows.Forms.Label lblDefectRate_V;
        private System.Windows.Forms.Label lblDefectAmount_V;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNomalAmount_V;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMahineName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.PictureBox picGreenLight;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox picRedLight;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 중지ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 재시작ToolStripMenuItem;
        private System.Windows.Forms.Timer runTimer;
        private System.Windows.Forms.Label lblRunningDTO;
        private System.Windows.Forms.Label lblTotalAmount_V;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}
