using SMS.Database;
using SMS.Database.DesktopMessage;
using SMS.Desktop.Models.Users;
using SMS.Desktop.Utilities;
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
	public partial class LoginForm : TemplateForm
	{
		Db db = new Db(AppSettings.ConnectionString());
		public LoginForm()
		{
			InitializeComponent();
		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void LoginButton_Click(object sender, EventArgs e)
		{
			if (IsFormValid())
			{
				List<DbParameter> dbParameters = new List<DbParameter>();
				GetParameters(dbParameters);

				bool IsCredentialsCorrect = (bool)db.GetValue("Users_CheckUsersCredentials", dbParameters);
				if (IsCredentialsCorrect)
				{
					LoggedInUser.Username = UsernameTextBox.Text;
					this.Hide();

					Dashboard dashboard = new Dashboard();
					dashboard.Show();
				}
				else
				{
					Messages.ShowErrorMessage("Incorrect Credentials");
				}
			}
		}

		private void GetParameters(List<DbParameter> dbParameters)
		{
			dbParameters.Add(new DbParameter() { Name = "@Username", Value = UsernameTextBox.Text });
			dbParameters.Add(new DbParameter() { Name = "@Password", Value = PasswordTextBox.Text });
		}

		private bool IsFormValid()
		{
			if (UsernameTextBox.Text.Trim() == String.Empty)
			{
				Messages.ShowErrorMessage("Username is required");
				UsernameTextBox.Clear();
				UsernameTextBox.Focus(); 
				return false;
			}
			if (PasswordTextBox.Text.Trim() == String.Empty)
			{
				Messages.ShowErrorMessage("Password is required");
				PasswordTextBox.Clear();
				PasswordTextBox.Focus();
				return false;
			}
			return true;
		}
	}
}
