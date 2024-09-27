using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
	public class UserViewModel
	{
		public int ID { get; set; }

		public int? EmpId { get; set; }

		public bool? IsAdmin { get; set; }

		public DateTime? CreateDate { get; set; }

		public DateTime? CreatedBy { get; set; }

		public DateTime? UpdateDate { get; set; }

		public DateTime? UpdatedBy { get; set; }

		//public virtual EmployeeViewModel? Emp { get; set; }
	}
}
