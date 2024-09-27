using Model.Entity;
using Model.ViewModel;
using Repository.Common.Implementation;
using Repository.Interface;
using Service.Common.Helper;
using Service.Interface;

namespace Service.Implementation
{
    public class EmployeeInformationService : GenericServices<EmployeeViewModel, EmployeeDatum>, IEmployeeInformationService
	{
		#region private variables
		private readonly IEmployeeInformationRepository _employeeInformationRepository;
		#endregion

		public EmployeeInformationService()
		{
			UnitOfWork = new UnitOfWork();
			GenericRepository = _employeeInformationRepository = UnitOfWork.EmployeeInformationRepository;

		}
		public void DeleteEmployee(int ID)
		{
			if (ID > 0)
			{
				var employeeModel = _employeeInformationRepository.GetEmployeeDataById(ID);
				employeeModel.isActive = false;
				_employeeInformationRepository.Update(employeeModel);
				UnitOfWork.Commit();
			}
		}

		public List<EmployeeViewModel> GetEmployeeDataa()
		{
			return MapperHelper.MapList<EmployeeViewModel, EmployeeDatum>(_employeeInformationRepository.GetEmployeeData());
		}

		public EmployeeViewModel GetEmployeeDetails(int employeeId)
		{
			try
			{
				var model = MapperHelper.Map<EmployeeViewModel, EmployeeDatum>(_employeeInformationRepository.FindById(employeeId));
				if (model == null)
				{
					return null;
				}
				return model;
			}
			catch (Exception)
			{

				throw;
			}
			
			
		}

		public void InsertData(EmployeeViewModel employee)
		{
			employee.isActive = true;
			var employeeData = MapperHelper.Map<EmployeeDatum, EmployeeViewModel>(employee);
			_employeeInformationRepository.Save(employeeData);
			UnitOfWork.Commit();
		}

		public void UpdateEmployee(EmployeeViewModel employee)
		{
			if (employee.ID > 0)
			{
				var employeeModel = _employeeInformationRepository.GetEmployeeDataById(employee.ID);
				employeeModel.First_Name = employee.First_Name;
				employeeModel.Last_Name = employee.Last_Name;
				employeeModel.Salary = employee.Salary;
				employeeModel.Gender = employee.Gender;
				employeeModel.DOB = employeeModel.DOB;
				employeeModel.isActive = true;
				_employeeInformationRepository.Update(employeeModel);
				UnitOfWork.Commit();
			}
		}
	}
}
