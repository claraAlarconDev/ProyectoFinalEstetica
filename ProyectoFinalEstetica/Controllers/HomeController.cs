using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalEstetica.Models;

namespace ProyectoFinalEstetica.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}