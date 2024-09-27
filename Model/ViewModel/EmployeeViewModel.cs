
using Model.Entity;

namespace Model.ViewModel
{
	public class EmployeeViewModel
	{
		public int ID { get; set; }

		public string? First_Name { get; set; }

		public string? Last_Name { get; set; }

		public string? Gender { get; set; }

		public float? Salary { get; set; }

		public DateTime? DOB { get; set; }

		public bool? isActive { get; set; }

		public string? Email { get; set; }

		public string? Password { get; set; }

		public string? User_Name { get; set; }
		public string? Role { get; set; }

		//public string? InvalidFileBytes { get; set; }
		//public byte[] OriginalInvalidFileBytes { get; set; }
		//public virtual ICollection<UserViewModel> Users { get; } = new List<UserViewModel>();
	}
}
