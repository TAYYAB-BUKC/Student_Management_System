using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Database.DesktopMessage
{
	public class Messages
	{
		public static void ShowErrorMessage(string message)
		{
			MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void ShowErrorMessage(string message,string title)
		{
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void ShowErrorMessage(string message, string title,MessageBoxButtons buttons)
		{
			MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
		}

		public static void ShowErrorMessage(string message, string title, MessageBoxButtons buttons,MessageBoxIcon icon)
		{
			MessageBox.Show(message, title, buttons, icon);
		}

		public static void ShowSuccessMessage(string message)
		{
			MessageBox.Show(message, "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static void ShowSuccessMessage(string message, string title)
		{
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static void ShowSuccessMessage(string message, string title, MessageBoxButtons buttons)
		{
			MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
		}

		public static void ShowSuccessMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			MessageBox.Show(message, title, buttons, icon);
		}
	}
}
