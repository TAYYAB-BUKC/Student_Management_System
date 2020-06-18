namespace SMS.Desktop.Forms.Employees
{
	partial class ManageEmployees
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
			this.EmployeesDataGridView = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.AddNewEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.EmployeesDataGridView)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// EmployeesDataGridView
			// 
			this.EmployeesDataGridView.AllowUserToAddRows = false;
			this.EmployeesDataGridView.AllowUserToDeleteRows = false;
			this.EmployeesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EmployeesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.EmployeesDataGridView.Location = new System.Drawing.Point(11, 38);
			this.EmployeesDataGridView.Name = "EmployeesDataGridView";
			this.EmployeesDataGridView.ReadOnly = true;
			this.EmployeesDataGridView.Size = new System.Drawing.Size(633, 515);
			this.EmployeesDataGridView.TabIndex = 3;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseToolStripMenuItem,
            this.toolStripMenuItem1,
            this.AddNewEmployeeToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(655, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// CloseToolStripMenuItem
			// 
			this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
			this.CloseToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.CloseToolStripMenuItem.Text = "Close";
			this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 20);
			this.toolStripMenuItem1.Text = "|";
			// 
			// AddNewEmployeeToolStripMenuItem
			// 
			this.AddNewEmployeeToolStripMenuItem.Name = "AddNewEmployeeToolStripMenuItem";
			this.AddNewEmployeeToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
			this.AddNewEmployeeToolStripMenuItem.Text = "Add New Employee";
			this.AddNewEmployeeToolStripMenuItem.Click += new System.EventHandler(this.AddNewEmployeeToolStripMenuItem_Click);
			// 
			// ManageEmployees
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(655, 563);
			this.Controls.Add(this.EmployeesDataGridView);
			this.Controls.Add(this.menuStrip1);
			this.Name = "ManageEmployees";
			this.ShowInTaskbar = true;
			this.Text = "Manage Employees";
			this.Load += new System.EventHandler(this.ManageEmployees_Load);
			((System.ComponentModel.ISupportInitialize)(this.EmployeesDataGridView)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView EmployeesDataGridView;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem AddNewEmployeeToolStripMenuItem;
	}
}