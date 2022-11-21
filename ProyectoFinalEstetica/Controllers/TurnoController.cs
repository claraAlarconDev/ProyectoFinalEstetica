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
			_ = agendaContext.Servicios.ToList();
			List<Turno> turnos = agendaContext.Turnos.ToList();
			return View(turnos);
        }
        [HttpGet]
        public IActionResult AgendarManicuria()
       
        {
            return View();
        }
        [HttpPost]
        public IActionResult AgendarManicuria(Turno turno)
        {
            Servicio? s = agendaContext.Servicios.Where(serve => serve.Tipo == "Manicuria").FirstOrDefault();
            if (s != null)
            {
                //Servicio servicio = new Servicio();
                //servicio.tipo = "Manicuria";
                turno.Servicio = s;
                
            }
            agendaContext.Turnos.Add(turno);
            agendaContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult AgendarPedicuria()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AgendarPedicuria(Turno turno)
        {
            Servicio? s = agendaContext.Servicios.Where(serve => serve.Tipo == "Pedicuria").FirstOrDefault();
            if (s != null)
            {
                turno.Servicio = s;

            }
            agendaContext.Turnos.Add(turno);
            agendaContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
