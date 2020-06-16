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
			this.Hide();

			Dashboard dashboard = new Dashboard();
			dashboard.Show();
		}
	}
}
