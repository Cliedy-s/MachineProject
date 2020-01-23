namespace MachineProject
{
    partial class EmployeeToManagerForm
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
            this.dgvETM = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvETM)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvETM
            // 
            this.dgvETM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvETM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvETM.Location = new System.Drawing.Point(0, 0);
            this.dgvETM.Name = "dgvETM";
            this.dgvETM.Size = new System.Drawing.Size(800, 450);
            this.dgvETM.TabIndex = 0;
            this.dgvETM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvETM_CellClick);
            // 
            // EmployeeToManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvETM);
            this.Name = "EmployeeToManagerForm";
            this.Text = "EmployeeToManager";
            this.Load += new System.EventHandler(this.EmployeeToManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvETM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvETM;
    }
}