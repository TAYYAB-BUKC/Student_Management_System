using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Desktop.Utilities
{
	public class AppSettings
	{
		public static string ConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
		}
	}
}
