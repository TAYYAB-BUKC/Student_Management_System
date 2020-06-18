using SMS.Desktop.Forms.Branches;
using SMS.Desktop.Forms.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Desktop.Forms
{
	public partial class Dashboard : TemplateForm
	{
		public Dashboard()
		{
			InitializeComponent();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void ManageBranchesToolStripButton_Click(object sender, EventArgs e)
		{
			ManageBranches manageBranches = new ManageBranches();
			manageBranches.Show();
		}

		private void ManageEmployeesToolStripButton_Click(object sender, EventArgs e)
		{
			ManageEmployees manageEmployees = new ManageEmployees();
			manageEmployees.Show();
		}
	}
}
