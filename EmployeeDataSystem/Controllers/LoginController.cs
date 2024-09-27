
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Model.Common;
using Model.ViewModel;
using Service.Implementation;
using Service.Interface;

namespace EmployeeDataSystem.Controllers
{
    public class LoginController : Controller
    {
        #region Private variables
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        private readonly ILogger<LoginController> _logger;
        private readonly IEmployeeInformationService _employeeInformationService;
        #endregion

        #region private contanst
        private const string SOMETHING_WENT_WRONG = "Something went wrong";
        #endregion
        public LoginController(ILogger<LoginController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _employeeInformationService = new EmployeeInformationService();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OnLogin(EmployeeViewModel model)
        {
            try
            {
                var allUsers = _employeeInformationService.GetEmployeeDataa();
                var userModel = allUsers.FirstOrDefault(x =>
                    x.Email != null &&
                    x.Email.ToLower() == model.Email.ToLower() &&
                    x.Password == model.Password);

                if (userModel != null)
                {
                    // Check if the user is in the HR role
                    if (userModel.Role.Equals("HR"))
                    {
                        // Set user data in session (optional, if you still want to use it)
                        HttpContext.Session.SetString("ID", userModel.ID.ToString());
                        HttpContext.Session.SetString("Email", model.Email.ToLower());
                        HttpContext.Session.SetString("Password", model.Password);

                        // Sign in the user using claims
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, userModel.ID.ToString()),
                            new Claim(ClaimTypes.Email, model.Email.ToLower()),
                            new Claim(ClaimTypes.Role, userModel.Role) // Add role claim
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = true, // True if you want to remember the user
                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) // Set expiration as needed
                        };

                        // Sign in the user
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), authProperties).Wait();

                        return RedirectToAction("employeeData", "Employee");
                    }
                    else
                    {
                        // Optionally, redirect to a different page or show an error for unauthorized access
                        ModelState.AddModelError(string.Empty, "You are not authorized to access this page.");
                        return RedirectToAction("Login", "Login");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return RedirectToAction("Login", "Login");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong. Please try again.");
                return RedirectToAction("Login", "Login");
            }

        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult onSignUp(EmployeeViewModel model)
        {
            var responseModel = new ResponseModel { IsSuccess = true, Action = Component.Action.Create };
            try
            {
                _employeeInformationService.InsertData(model);

                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while signing up.");
                responseModel.Message = SOMETHING_WENT_WRONG;
                return StatusCode((int)HttpStatusCode.BadRequest, new { Status = 400, Data = responseModel });
            }
        }
    }
}
