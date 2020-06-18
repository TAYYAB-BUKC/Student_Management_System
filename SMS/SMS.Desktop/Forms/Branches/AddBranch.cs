using SMS.Database;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Desktop.Forms.Branches
{
	public partial class AddBranch : TemplateForm
	{
		public int BranchId { get; set; }
		Db db = new Db(AppSettings.ConnectionString());
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

		private void LogoPictureBox_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Title = "Select Logo file";
			fileDialog.Filter = "Logo file (*.png;*.jpg;*.bmp;*.gif;)|*.png;*.jpg;*.bmp;*.gif;";

			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				LogoPictureBox.Image = new Bitmap(fileDialog.FileName);
			}
		}

		private void AddBranch_Load(object sender, EventArgs e)
		{
			LoadData();
			if (this.IsUpdate)
			{
				AddBranchButton.Text = "Update Branch";
				this.Text = "Update Branch";
				LoadDataIfUpdate();
			}
			else
			{
				LogoPictureBox.Image = Resources.noimage;
			}
		}

		private void LoadData()
		{
			ListData.LoadData(CityComboBox, new DbParameter() { Name = "@ListTypeId", Value = ListTypes.City });
			ListData.LoadData(DistrictComboBox, new DbParameter() { Name = "@ListTypeId", Value = ListTypes.District });
		}

		private void LoadDataIfUpdate()
		{

			DataRow dataRow = db.GetList("Branches_GetBranchByID", new DbParameter() { Name = "@BranchId", Value = BranchId }).Rows[0];

			NameTextBox.Text = dataRow["BranchName"].ToString();
			EmailTextBox.Text = dataRow["Email"].ToString();
			TelephoneTextBox.Text = dataRow["Telephone"].ToString();
			WebsiteTextBox.Text = dataRow["Website"].ToString();
			AddressLineTextBox.Text = dataRow["AddressLine"].ToString();
			CityComboBox.SelectedValue = dataRow["CityId"];
			DistrictComboBox.SelectedValue = dataRow["DistrictId"];
			PostalCodeTextBox.Text = dataRow["PostalCode"].ToString();
			
			LogoPictureBox.Image = dataRow["BranchImage"] is DBNull ? Resources.noimage : ImageManipulation.ConvertBytesIntoImage((byte[])dataRow["BranchImage"]);
		}

		private void AddBranchButton_Click(object sender, EventArgs e)
		{
			if (IsFormValid())
			{
				if (this.IsUpdate)
				{
					AddOrUpdateBranch("Branches_UpdateBranch");
					MessageBox.Show("Branch is updated successfully", "Sucess Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					AddOrUpdateBranch("Branches_AddNewBranch");
					MessageBox.Show("Branch is added successfully", "Sucess Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				this.Close();
			}
		}

		private void AddOrUpdateBranch(string procedureName)
		{
			db.WriteValues(procedureName, GetObject());
		}

		private Branch GetObject()
		{
			Branch branch = new Branch();
			branch.BranchId = this.IsUpdate ? this.BranchId : 0;
			branch.BranchName = NameTextBox.Text;
			branch.Email = EmailTextBox.Text;
			branch.Telephone = TelephoneTextBox.Text;
			branch.Website = WebsiteTextBox.Text;
			branch.AddressLine = AddressLineTextBox.Text;
			branch.CityId = (int)CityComboBox.SelectedValue;
			branch.DistrictId = (int)DistrictComboBox.SelectedValue;
			branch.PostalCode = PostalCodeTextBox.Text;
			branch.CreatedBy = LoggedInUser.Username;
			branch.BranchImage = LogoPictureBox.Image == null ? null : ImageManipulation.ConvertImageIntoBytes(LogoPictureBox);
			return branch;
		}

		private bool IsFormValid()
		{
			if (NameTextBox.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Name is required", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
				NameTextBox.Clear();
				NameTextBox.Focus();
				return false;
			}
			if (EmailTextBox.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Email is required", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
				EmailTextBox.Clear();
				EmailTextBox.Focus();
				return false;
			}
			if (TelephoneTextBox.Text.Trim() == string.Empty)
			{
				MessageBox.Show("Name is required", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
				TelephoneTextBox.Clear();
				TelephoneTextBox.Focus();
				return false;
			}
			return true;
		}
	}
}
