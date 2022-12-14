using Microsoft.AspNetCore.Mvc;
using ProyectoFinalEstetica.Models;

namespace ProyectoFinalEstetica.Controllers
{
    public class HomeController : Controller
    {
		AgendaContext agendaContext = new AgendaContext();
		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Contacto(Contacto contacto)
        {
            agendaContext.Contactos.Add(contacto);
            agendaContext.SaveChanges();
            return View(contacto);
        }

    }
}