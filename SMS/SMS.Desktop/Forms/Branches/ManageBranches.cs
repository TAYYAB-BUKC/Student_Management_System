using SMS.Desktop.Utilities.Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Desktop.Forms.Branches
{
	public partial class ManageBranches : TemplateForm
	{
		public ManageBranches()
		{
			InitializeComponent();
		}

		private void AddNewBranchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowAddBranch(0,false);
		}

		private void ShowAddBranch(int branchId,bool isUpdate)
		{
			AddBranch addBranch = new AddBranch();
			addBranch.IsUpdate = isUpdate;
			addBranch.BranchId = branchId;
			addBranch.ShowDialog();

			LoadData();
		}

		private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ManageBranches_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			ListData.LoadData(BranchesDataGridView, "Branches_GetAllBranches");
		}

		private void BranchesDataGridView_DoubleClick(object sender, EventArgs e)
		{
			int rowIndex = BranchesDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Selected);
			int branchId = Convert.ToInt32(BranchesDataGridView.Rows[rowIndex].Cells["BranchId"].Value);
			ShowAddBranch(branchId, true);
		}
	}
}
