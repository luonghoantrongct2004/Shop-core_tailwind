using Microsoft.AspNetCore.Mvc;
using Shop.DTO.DTOs;
using ShopBussinessLogic.Service.IServices;
using ShopPresentation.Models;
using System.Diagnostics;

namespace ShopPresentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<ProductDTO> _service;

        public HomeController(ILogger<HomeController> logger, IEntityService<ProductDTO> service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            var products = await _service.GetAsync(id);
            if(products == null)
            {
                return NotFound();
            }
            return View(products);
        }
        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
