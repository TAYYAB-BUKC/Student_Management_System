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
	public partial class AddBranch : TemplateForm
	{
		public int BranchId { get; set; }
		public AddBranch()
		{
			InitializeComponent();
		}

		private void NameTextBox_TextChanged(object sender, EventArgs e)
		{
			if (NameTextBox.Text.Trim() == String.Empty)
			{
				CollegeLabel.Text = "PAF Fazaia College";
			}
			else
			{
				CollegeLabel.Text = NameTextBox.Text;
			}
		}
	}
}
