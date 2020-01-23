namespace MachineProject
{
    partial class WorkForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvTodo = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProductionPlans = new System.Windows.Forms.DataGridView();
            this.dgvTodoListPerEmployee = new System.Windows.Forms.DataGridView();
            this.dgvProductionable = new System.Windows.Forms.DataGridView();
            this.btnRemoveTodo = new System.Windows.Forms.Button();
            this.cmbEmployees = new System.Windows.Forms.ComboBox();
            this.btnAddTodo = new System.Windows.Forms.Button();
            this.cmbMachines = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductionPlans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodoListPerEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductionable)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.dgvTodo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txtAmount);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.dgvProductionPlans);
            this.splitContainer1.Panel2.Controls.Add(this.dgvTodoListPerEmployee);
            this.splitContainer1.Panel2.Controls.Add(this.dgvProductionable);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemoveTodo);
            this.splitContainer1.Panel2.Controls.Add(this.cmbEmployees);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddTodo);
            this.splitContainer1.Panel2.Controls.Add(this.cmbMachines);
            this.splitContainer1.Size = new System.Drawing.Size(1047, 490);
            this.splitContainer1.SplitterDistance = 268;
            this.splitContainer1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(108, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 19);
            this.label4.TabIndex = 76;
            this.label4.Text = "TODO";
            // 
            // dgvTodo
            // 
            this.dgvTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodo.Location = new System.Drawing.Point(12, 43);
            this.dgvTodo.Name = "dgvTodo";
            this.dgvTodo.RowHeadersWidth = 51;
            this.dgvTodo.RowTemplate.Height = 23;
            this.dgvTodo.Size = new System.Drawing.Size(253, 435);
            this.dgvTodo.TabIndex = 75;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 461);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 12);
            this.label5.TabIndex = 76;
            this.label5.Text = "개 할당";
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAmount.Location = new System.Drawing.Point(101, 457);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(152, 21);
            this.txtAmount.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(172, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 73;
            this.label3.Text = "생산 계획";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(619, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 72;
            this.label2.Text = "담당 작업";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(377, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 71;
            this.label1.Text = "생산 가능 제품";
            // 
            // dgvProductionPlans
            // 
            this.dgvProductionPlans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvProductionPlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductionPlans.Location = new System.Drawing.Point(101, 43);
            this.dgvProductionPlans.Name = "dgvProductionPlans";
            this.dgvProductionPlans.RowHeadersWidth = 51;
            this.dgvProductionPlans.RowTemplate.Height = 23;
            this.dgvProductionPlans.Size = new System.Drawing.Size(215, 406);
            this.dgvProductionPlans.TabIndex = 69;
            // 
            // dgvTodoListPerEmployee
            // 
            this.dgvTodoListPerEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTodoListPerEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodoListPerEmployee.Location = new System.Drawing.Point(547, 76);
            this.dgvTodoListPerEmployee.Name = "dgvTodoListPerEmployee";
            this.dgvTodoListPerEmployee.RowHeadersWidth = 51;
            this.dgvTodoListPerEmployee.RowTemplate.Height = 23;
            this.dgvTodoListPerEmployee.Size = new System.Drawing.Size(216, 402);
            this.dgvTodoListPerEmployee.TabIndex = 68;
            // 
            // dgvProductionable
            // 
            this.dgvProductionable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvProductionable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductionable.Location = new System.Drawing.Point(322, 76);
            this.dgvProductionable.Name = "dgvProductionable";
            this.dgvProductionable.RowHeadersWidth = 51;
            this.dgvProductionable.RowTemplate.Height = 23;
            this.dgvProductionable.Size = new System.Drawing.Size(216, 402);
            this.dgvProductionable.TabIndex = 67;
            // 
            // btnRemoveTodo
            // 
            this.btnRemoveTodo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRemoveTodo.Location = new System.Drawing.Point(3, 248);
            this.btnRemoveTodo.Name = "btnRemoveTodo";
            this.btnRemoveTodo.Size = new System.Drawing.Size(92, 23);
            this.btnRemoveTodo.TabIndex = 66;
            this.btnRemoveTodo.Text = "▷ 작업취소";
            this.btnRemoveTodo.UseVisualStyleBackColor = true;
            this.btnRemoveTodo.Click += new System.EventHandler(this.BtnRemoveTodo_Click);
            // 
            // cmbEmployees
            // 
            this.cmbEmployees.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbEmployees.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbEmployees.FormattingEnabled = true;
            this.cmbEmployees.Location = new System.Drawing.Point(547, 12);
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.Size = new System.Drawing.Size(216, 25);
            this.cmbEmployees.TabIndex = 65;
            this.cmbEmployees.SelectedIndexChanged += new System.EventHandler(this.CmbEmployees_SelectedIndexChanged);
            // 
            // btnAddTodo
            // 
            this.btnAddTodo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddTodo.Location = new System.Drawing.Point(3, 219);
            this.btnAddTodo.Name = "btnAddTodo";
            this.btnAddTodo.Size = new System.Drawing.Size(92, 23);
            this.btnAddTodo.TabIndex = 64;
            this.btnAddTodo.Text = "◁ 작업할당";
            this.btnAddTodo.UseVisualStyleBackColor = true;
            this.btnAddTodo.Click += new System.EventHandler(this.BtnAddTodo_Click);
            // 
            // cmbMachines
            // 
            this.cmbMachines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbMachines.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbMachines.FormattingEnabled = true;
            this.cmbMachines.Location = new System.Drawing.Point(322, 12);
            this.cmbMachines.Name = "cmbMachines";
            this.cmbMachines.Size = new System.Drawing.Size(216, 25);
            this.cmbMachines.TabIndex = 63;
            this.cmbMachines.SelectedIndexChanged += new System.EventHandler(this.CmbMachines_SelectedIndexChanged);
            // 
            // WorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 490);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WorkForm";
            this.Text = " WorkForm";
            this.Load += new System.EventHandler(this.WorkForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductionPlans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodoListPerEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductionable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvTodo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProductionPlans;
        private System.Windows.Forms.DataGridView dgvTodoListPerEmployee;
        private System.Windows.Forms.DataGridView dgvProductionable;
        private System.Windows.Forms.Button btnRemoveTodo;
        private System.Windows.Forms.ComboBox cmbEmployees;
        private System.Windows.Forms.Button btnAddTodo;
        private System.Windows.Forms.ComboBox cmbMachines;
    }
}