

using Model.ViewModel;

namespace Service.Interface
{
	public interface IEmployeeInformationService
	{
		//EmployeeDataModel GetEmployeeDataById(int employeeId);
		List<EmployeeViewModel> GetEmployeeDataa();
		void InsertData(EmployeeViewModel employee);
		void UpdateEmployee(EmployeeViewModel employee);
		void DeleteEmployee(int ID);
		EmployeeViewModel GetEmployeeDetails(int employeeId);
	}
}
