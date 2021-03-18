using SMS.Database;
using SMS.Database.DesktopMessage;
using SMS.Desktop.Models;
using SMS.Desktop.Models.Branches;
using SMS.Desktop.Models.Users;
using SMS.Desktop.Properties;
using SMS.Desktop.Utilities;
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
	public partial class AddEmployee : TemplateForm
	{
		public int EmployeeId { get; set; }
		Db db = new Db(AppSettings.ConnectionString());

		public AddEmployee()
		{
			InitializeComponent();
			DateLeftDateTimePicker.Text = null;
		}

		private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AddEmployee_Load(object sender, EventArgs e)
		{
			LoadData();
			if (this.IsUpdate)
			{
				//update procedure
				AddEmployeeToolStripMenuItem.Text = "Update Employee";
				this.Text = "Update Employee";
				EnableButtons();
				LoadDataIfUpdate();
			}
			else
			{
				//insert procedure
				GenerateEmployeeID();
			}
		}

		private void LoadDataIfUpdate()
		{
			DataRow dataRow = db.GetList("Employees_GetEmployeeByEmployeeId", new DbParameter() { Name = "@EmployeeId", Value = EmployeeId }).Rows[0];
			EmployeeIDTextBox.Text = EmployeeId.ToString();
			EmployeeNameTextBox.Text = dataRow["Name"].ToString();
			DateOfBirthDateTimePicker.Value = Convert.ToDateTime(dataRow["DateOfBirth"]);
			CNICTextBox.Text = dataRow["CNIC"].ToString();
			EmailTextBox.Text = dataRow["Email"].ToString();              
			MobileTextBox.Text = dataRow["Mobile"].ToString();
			TelephoneTextBox.Text = dataRow["Telephone"].ToString();
			GenderComboBox.SelectedValue = dataRow["GenderId"];
			EmploymentDateDateTimePicker.Value = Convert.ToDateTime(dataRow["EmploymentDate"]);
			//if (Convert.ToInt32(dataRow["BranchId"]) != 0)
			//{
				BranchComboBox.SelectedValue = dataRow["BranchId"];
			//}
			AddressLineTextBox.Text = dataRow["AddressLine"].ToString();
			CityComboBox.SelectedValue = dataRow["CityId"];
			DistrictComboBox.SelectedValue = dataRow["DistrictId"];
			PostalCodeTextBox.Text = dataRow["PostalCode"].ToString();
			JobTitleComboBox.SelectedValue = dataRow["JobTitleId"];
			StartingSalaryTextBox.Text = dataRow["StartingSalary"].ToString();
			CurrentSalaryTextBox.Text = dataRow["CurrentSalary"].ToString();
			PicturePictureBox.Image = dataRow["Picture"] is DBNull ? Resources.noimage : ImageManipulation.ConvertBytesIntoImage((byte[])dataRow["Picture"]);
			HasLeftComboBox.Text = ((bool)dataRow["HasLeft"]) ? "Yes" : "No";
			DateLeftDateTimePicker.Value = Convert.ToDateTime(dataRow["DateLeft"]);
			LeftReasonComboBox.SelectedValue = dataRow["ReasonLeftId"];
			LeavingCommentsTextBox.Text = dataRow["Comments"].ToString();
		}


		private void LoadData()
		{
			FillData(CityComboBox, ListTypes.City);
			FillData(DistrictComboBox, ListTypes.District);
			FillData(GenderComboBox, ListTypes.Gender);
			FillData(JobTitleComboBox, ListTypes.JobTitle);
			FillData(HasLeftComboBox, ListTypes.HasLeft);
			FillData(LeftReasonComboBox, ListTypes.LeftReason);
			ListData.LoadData(BranchComboBox, "Branches_GetAllBranchesName");
		}

		private void FillData(ComboBox comboBox,object value)
		{
			ListData.LoadData(comboBox, new DbParameter() { Name = "@ListTypeId", Value = value });
		}

		private void GenerateEmployeeID()
		{
			EmployeeIDTextBox.Text = db.GetValue("Employees_GenerateEmployeesId").ToString();
		}

		private void PicturePictureBox_Click(object sender, EventArgs e)
		{
			SelectPicture();
		}

		private void SelectPicture()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Title = "Select Picture";
			fileDialog.Filter = "Picture File (*.png;*.jpg;*.bmp;*.gif;)|*.png;*.jpg;*.bmp;*.gif;";

			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				PicturePictureBox.Image = new Bitmap(fileDialog.FileName);
			}
		}

		private void SelectPictureBox_Click(object sender, EventArgs e)
		{
			SelectPicture();
		}

		private void UnSelectPictureBox_Click(object sender, EventArgs e)
		{
			PicturePictureBox.Image = null;
		}

		private void AddEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (IsFormValid())
			{
				if (this.IsUpdate)
				{
					AddOrUpdateEmployee("Employees_UpdateEmployee");
					Messages.ShowSuccessMessage("Employee updated successfully");
				}
				else
				{
					AddOrUpdateEmployee("Employees_AddNewEmployee");
					Messages.ShowSuccessMessage("Employee added successfully");

					this.IsUpdate = true;
					EnableButtons();
				}
			}
		}

		private void EnableButtons()
		{
			AddEmployeeToolStripMenuItem.Enabled = true;
			SendToolStripMenuItem.Enabled = true;
			PrintToolStripMenuItem.Enabled = true;
		}

		private void AddOrUpdateEmployee(string procedureName)
		{
			db.WriteValues(procedureName, GetObject());
		}

		private Employee GetObject()
		{
			Employee employee = new Employee();
			employee.EmployeeId = this.IsUpdate ? this.EmployeeId : Convert.ToInt32(EmployeeIDTextBox.Text);
			employee.Name = EmployeeNameTextBox.Text;
			employee.DateOfBirth = DateOfBirthDateTimePicker.Value.Date;
			employee.CNIC = CNICTextBox.Text;
			employee.Email = EmailTextBox.Text;
			employee.Mobile = MobileTextBox.Text;
			employee.Telephone = TelephoneTextBox.Text;
			employee.GenderId = (int)GenderComboBox.SelectedValue;
			employee.EmploymentDate = EmploymentDateDateTimePicker.Value.Date;
			employee.BranchId = (BranchComboBox.SelectedIndex == -1) ? 0 : (int)BranchComboBox.SelectedValue;
			employee.AddressLine = AddressLineTextBox.Text;
			employee.CityId = (int)CityComboBox.SelectedValue;
			employee.DistrictId = (int)DistrictComboBox.SelectedValue;
			employee.PostalCode = PostalCodeTextBox.Text;
			employee.JobTitleId = (int)JobTitleComboBox.SelectedValue;
			employee.StartingSalary = Convert.ToDecimal(StartingSalaryTextBox.Text);
			employee.CurrentSalary = Convert.ToDecimal(CurrentSalaryTextBox.Text);
			employee.HasLeft = HasLeftComboBox.Text == "Yes" ? true : false;
			if (DateLeftDateTimePicker.Text == null)
			{

			}
			else
			{
				employee.DateLeft = DateLeftDateTimePicker.Value.Date;
			}
			employee.ReasonLeftId = (LeftReasonComboBox.SelectedIndex == -1) ? 0 : (int)LeftReasonComboBox.SelectedValue;
			employee.Comments = LeavingCommentsTextBox.Text;

			employee.CreatedBy = LoggedInUser.Username;
			employee.Picture = PicturePictureBox.Image == null ? null : ImageManipulation.ConvertImageIntoBytes(PicturePictureBox);
			return employee;
		}

		private bool IsFormValid()
		{
			if (EmployeeNameTextBox.Text.Trim() == string.Empty)
			{
				Messages.ShowErrorMessage("Name is required");
				EmployeeNameTextBox.Focus();
				return false;
			}
			if (CNICTextBox.Text.Trim() == string.Empty)
			{
				Messages.ShowErrorMessage("CNIC is required");
				CNICTextBox.Focus();
				return false;
			}
			if ((TelephoneTextBox.Text.Trim() == string.Empty) && (MobileTextBox.Text.Trim() == string.Empty))
			{
				Messages.ShowErrorMessage("Mobile number or Telephone number is required");
				MobileTextBox.Focus();
				return false;
			}
			if (GenderComboBox.SelectedIndex == -1)
			{
				Messages.ShowErrorMessage("Gender is required");
				GenderComboBox.Focus();
				return false;
			}
			//if (BranchComboBox.SelectedIndex == -1)
			//{
			//	Messages.ShowErrorMessage("Branch is required");
			//	BranchComboBox.Focus();
			//	return false;
			//}
			if (AddressLineTextBox.Text.Trim() == string.Empty)
			{
				Messages.ShowErrorMessage("Address Line is required");
				AddressLineTextBox.Focus();
				return false;
			}
			if (CityComboBox.SelectedIndex == -1)
			{
				Messages.ShowErrorMessage("City is required");
				CityComboBox.Focus();
				return false;
			}
			if (DistrictComboBox.SelectedIndex == -1)
			{
				Messages.ShowErrorMessage("District is required");
				DistrictComboBox.Focus();
				return false;
			}
			if (PostalCodeTextBox.Text.Trim() == string.Empty)
			{
				Messages.ShowErrorMessage("Postal Code is required");
				PostalCodeTextBox.Focus();
				return false;
			}
			if (JobTitleComboBox.SelectedIndex == -1)
			{
				Messages.ShowErrorMessage("Job Title is required");
				JobTitleComboBox.Focus();
				return false;
			}
			if (StartingSalaryTextBox.Text.Trim() == string.Empty)
			{
				Messages.ShowErrorMessage("Starting Salary is required");
				StartingSalaryTextBox.Focus();
				return false;
			}
			else
			{
				if (Convert.ToDecimal(StartingSalaryTextBox.Text) <= 0)
				{
					Messages.ShowErrorMessage("Starting Salary cannot be zero or less than zero");
					StartingSalaryTextBox.Focus();
					return false;
				}
			}
			if (CurrentSalaryTextBox.Text.Trim() == string.Empty)
			{
				Messages.ShowErrorMessage("Current Salary is required");
				CurrentSalaryTextBox.Focus();
				return false;
			}
			else
			{
				if (Convert.ToDecimal(CurrentSalaryTextBox.Text) <= 0)
				{
					Messages.ShowErrorMessage("Current Salary cannot be zero or less than zero");
					CurrentSalaryTextBox.Focus();
					return false;
				}
			}
			return true;
		}
	}
}
