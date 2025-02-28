using Exam1.Model;
using Froantend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Froantend.Controllers
{
    public class UserController1 : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly UserService _userService;

        public UserController1(HttpClient httpClient, UserService userService)
        {
            _httpClient = httpClient;
              _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterM()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterM(Register register)
        {
            var response = await _userService.SingU(register);
            if (response.IsSuccess) 
            {
                TempData["Success"] = response.Success_Message;
            return RedirectToAction("SingIN", "UserController1");
            }
            TempData["Error"] = response.Error_Message;
            return View(register);
        }


        public IActionResult SingIN()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SingIN(Login login)
        {

            //if (login.email == "Admin@gmail.com" && login.password == "Admin@123")
            //{
            //    TempData["SuccessSign"] = "Login successful A"; // Admin login success
            //    return RedirectToAction("IndexAd", "AdminControllerM");
            //}
            var response = await _userService.SignIn(login);
            if (response.IsSuccess)
            {
                if (login.email == "Admin@gmail.com" && login.password == "Admin@123")
                {
                    TempData["Success"] = "response.Success_Message"; // Admin login success
                    return RedirectToAction("IndexAd", "AdminControllerM");
                }

                TempData["Success"] = response.Success_Message;
                return RedirectToAction("Index", "AdminCOntroller");
            }
            TempData["Error"] = response.Error_Message;
            return View(login);
        }

    }
}
