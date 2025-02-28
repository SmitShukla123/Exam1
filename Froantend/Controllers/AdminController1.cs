using Exam1.Model;
using Froantend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Froantend.Controllers
{
    public class AdminController1 : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly AdminService _AdminService;

        public AdminController1(HttpClient httpClient, AdminService AdminService)
        {
            _httpClient = httpClient;
            _AdminService = AdminService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            Response<List<Produ>> response = await _AdminService.GetALLP(pageNumber, pageSize);

            // Ensure response.Data is not null
            var products = response.Data ?? new List<Produ>();

            return View(products);
        }

    }
}
