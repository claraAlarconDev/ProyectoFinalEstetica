using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalEstetica.Models;

namespace ProyectoFinalEstetica.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        
    }
}