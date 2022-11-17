using Microsoft.AspNetCore.Mvc;
using ProyectoFinalEstetica.Models;

namespace ProyectoFinalEstetica.Controllers
{
    public class TurnoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Agendar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agendar(Turno turno)
        {
            return RedirectToAction(nameof(View));
        }
    }
}
