

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Common;
using Model.ViewModel;
using Service.Implementation;
using Service.Interface;
using System.Net;


namespace EmployeeDataSystem.Controllers
{
    [Authorize(Roles = "HR")]
    public class EmployeeController : Controller
    {
		#region private variable
        public IWebHostEnvironment webHostEnvironment { get; set; }
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeInformationService _employeeInformationService;
        private const string SOMETHING_WENT_WRONG = "Something went wrong";
        #endregion
        public EmployeeController(ILogger<EmployeeController> logger, IWebHostEnvironment webHostEnvironment )
        {
             _logger = logger;
            _employeeInformationService = new EmployeeInformationService();
        }
        [HttpGet]
       
        public IActionResult employeeData()
        {
            var empList = _employeeInformationService.GetEmployeeDataa();
            //model.empDataList = empList;
            return View(empList);
        }
        [HttpPost]
        public IActionResult createEmployee(EmployeeViewModel model)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };
            try
            {
                if (model.ID > 0)
                {
                    var responseModell = new ResponseModel { IsSuccess = true, Action = Component.Action.Update };
                    _employeeInformationService.UpdateEmployee(model);
                }
                else
                {
                    _employeeInformationService.InsertData(model);
                }
                return RedirectToAction("employeeData");
            }
            catch (Exception)
            {
                responseModel.Message = SOMETHING_WENT_WRONG;
                return StatusCode((int)HttpStatusCode.BadRequest, new { Status = 400, Data = responseModel });
            }
        }
        public IActionResult DeleteEmployee(int ID)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Delete };
            try
            {
                _employeeInformationService.DeleteEmployee(ID);
                return RedirectToAction("employeeData");
            }
            catch (Exception)
            {
                responseModel.Message = SOMETHING_WENT_WRONG;
                return StatusCode((int)HttpStatusCode.BadRequest, new { Status = 400, Data = responseModel });
            }
        }

        public IActionResult GetUpdateEmployeePopup(int employeeId)
        {
            var employee = _employeeInformationService.GetEmployeeDetails(employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            var viewModel = new EmployeeViewModel
            {
                ID = employee.ID,
                First_Name = employee.First_Name,
                Last_Name = employee.Last_Name,
                Gender = employee.Gender,
                Salary = employee.Salary,
                DOB = employee.DOB
            };
            // Pass the employee data to the partial view
            return PartialView("updateEmployee", employee);
        }
        public IActionResult GetEmployeeDetails(int employeeId)
        {
            var employee = _employeeInformationService.GetEmployeeDetails(employeeId); // Assuming you have this method
            if (employee == null)
            {
                return NotFound();
            }

            var viewModel = new EmployeeViewModel
            {
                ID = employee.ID,
                First_Name = employee.First_Name,
                Last_Name = employee.Last_Name,
                Gender = employee.Gender,
                Salary = employee.Salary,
                DOB = employee.DOB
            };

            return PartialView("UpdateEmployee", viewModel);

        }
    }
}
