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

		public static void LoadData(ComboBox comboBox, DbParameter parameter)
		{
			
			comboBox.DataSource = db.GetList("ListTypes_GetListTypesByID", parameter);

			comboBox.DisplayMember = "Description";
			comboBox.ValueMember = "Id";
			comboBox.SelectedIndex = -1;
			comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		public static void LoadData(ComboBox comboBox, string storedProcedure)
		{

			comboBox.DataSource = db.GetList(storedProcedure);

			comboBox.DisplayMember = "Description";
			comboBox.ValueMember = "Id";
			comboBox.SelectedIndex = -1;
			comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		public static void LoadData(ComboBox comboBox, string storedProcedure, DbParameter parameter)
		{

			comboBox.DataSource = db.GetList(storedProcedure, parameter);

			comboBox.DisplayMember = "Description";
			comboBox.ValueMember = "Id";
			comboBox.SelectedIndex = -1;
			comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		}

		public static void LoadData(ComboBox comboBox, string storedProcedure, List<DbParameter> parameters)
		{

			comboBox.DataSource = db.GetList(storedProcedure, parameters);

			comboBox.DisplayMember = "Description";
			comboBox.ValueMember = "Id";
			comboBox.SelectedIndex = -1;
			comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
		}
	}
}
