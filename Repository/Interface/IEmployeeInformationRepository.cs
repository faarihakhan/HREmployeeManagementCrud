using Model.Entity;

namespace Repository.Interface
{
	public interface IEmployeeInformationRepository: IGenericRepository<EmployeeDatum>
	{
		EmployeeDatum GetEmployeeDataById(int id);
		List<EmployeeDatum> GetEmployeeData();
	}
}
