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

namespace SMS.Desktop.Forms.Employees
{
	public partial class ManageEmployees : TemplateForm
	{
		public ManageEmployees()
		{
			InitializeComponent();
		}

		private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AddNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowAddEmployee(0, false);
		}

		private void ShowAddEmployee(int employeeId, bool isUpdate)
		{
			AddEmployee addEmployee = new AddEmployee();
			addEmployee.IsUpdate = isUpdate;
			addEmployee.EmployeeId = employeeId;
			addEmployee.ShowDialog();

			LoadData();
		}

		private void ManageEmployees_Load(object sender, EventArgs e)
		{
			LoadData();
		}
		private void LoadData()
		{
			ListData.LoadData(EmployeesDataGridView, "Employees_GetAllEmployees");
		}
	}
}
