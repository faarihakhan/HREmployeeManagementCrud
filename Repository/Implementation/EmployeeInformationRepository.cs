using Microsoft.EntityFrameworkCore;
using Model.Entity;
using Repository.Common.Implementation;
using Repository.Interface;

namespace Repository.Implementation
{
	public class EmployeeInformationRepository : GenericRepository<EmployeeDatum>, IEmployeeInformationRepository
	{
        public EmployeeInformationRepository(DbContext context)
        {
				Context = context;
        }
        public List<EmployeeDatum> GetEmployeeData()
		{
			return GetAll().Where(x => (bool)x.isActive).ToList();
		}

		public EmployeeDatum GetEmployeeDataById(int id)
		{
			return FindBy(x => x.ID == id).FirstOrDefault();
		}

		public List<EmployeeDatum> GetAllEmployees()
		{
			var abc = GetAll().Where(x => (bool)x.isActive).ToList();
			return GetAll().Where(x => (bool)x.isActive).ToList();
		}

	}
}
