using SMS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Desktop.Utilities.Lists
{
	public class ListData
	{
		public static Db db = new Db(AppSettings.ConnectionString());
		public static void LoadData(DataGridView dataGridView, string procedureName)
		{
			dataGridView.DataSource = db.GetList(procedureName);
			dataGridView.MultiSelect = false;
			dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

		}
	}
}
