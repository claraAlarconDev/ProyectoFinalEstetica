using Microsoft.AspNetCore.Mvc;
using ProyectoFinalEstetica.Models;

namespace ProyectoFinalEstetica.Controllers
{
    public class TurnoController : Controller
    {
        AgendaContext agendaContext = new AgendaContext(); 
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Agendar1()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Agendar(Turno turno)
        {
            
            return RedirectToAction(nameof(View));
        }
        [HttpGet]
        public IActionResult AgendarManicuria()
       
        {
            return View();
        }
        [HttpPost]
        public IActionResult AgendarManicuria(Turno turno)
        {
            Servicio? s = agendaContext.Servicios.Where(serve => serve.tipo == "Manicuria").FirstOrDefault();
            if (s != null)
            {
                //Servicio servicio = new Servicio();
                //servicio.tipo = "Manicuria";
                turno.servicio = s;
                
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
