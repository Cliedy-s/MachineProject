namespace MachineProject
{
    partial class MachineStateForm
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
            this.components = new System.ComponentModel.Container();
            this.flpBase = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.전체가동ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.전체중지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpBase
            // 
            this.flpBase.ContextMenuStrip = this.contextMenuStrip1;
            this.flpBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBase.Location = new System.Drawing.Point(0, 0);
            this.flpBase.Name = "flpBase";
            this.flpBase.Size = new System.Drawing.Size(564, 412);
            this.flpBase.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.전체가동ToolStripMenuItem,
            this.전체중지ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // 전체가동ToolStripMenuItem
            // 
            this.전체가동ToolStripMenuItem.Name = "전체가동ToolStripMenuItem";
            this.전체가동ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.전체가동ToolStripMenuItem.Text = "전체 가동";
            this.전체가동ToolStripMenuItem.Click += new System.EventHandler(this.전체가동ToolStripMenuItem_Click);
            // 
            // 전체중지ToolStripMenuItem
            // 
            this.전체중지ToolStripMenuItem.Name = "전체중지ToolStripMenuItem";
            this.전체중지ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.전체중지ToolStripMenuItem.Text = "전체 중지";
            this.전체중지ToolStripMenuItem.Click += new System.EventHandler(this.전체중지ToolStripMenuItem_Click);
            // 
            // MachineStateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 412);
            this.Controls.Add(this.flpBase);
            this.Name = "MachineStateForm";
            this.Text = "MachineForm";
            this.Load += new System.EventHandler(this.MachineForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBase;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 전체가동ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 전체중지ToolStripMenuItem;
    }
}