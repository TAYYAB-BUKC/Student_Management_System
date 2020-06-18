using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Desktop.Models
{
	public class Employee
	{
		public int EmployeeId { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirth	{ get; set; }
		public string CNIC { get; set; }
		public string Email { get; set; }
		public string Mobile { get; set; }
		public string Telephone { get; set; }
		public int GenderId { get; set; }
		public DateTime EmploymentDate { get; set; }
		public int BranchId { get; set; }
		public byte[] Picture { get; set; }
		public string AddressLine { get; set; }
		public int CityId { get; set; }
		public int DistrictId { get; set; }
		public string PostalCode { get; set; }
		public int JobTitleId { get; set; }
		public decimal CurrentSalary { get; set; }
		public decimal StartingSalary { get; set; }
		public bool HasLeft { get; set; }
		public DateTime DateLeft { get; set; }
		public int ReasonLeftId { get; set; }
		public string Comments { get; set; }
		public string CreatedBy { get; set; }

	}
}
