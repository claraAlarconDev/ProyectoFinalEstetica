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
            List<Turno> turnos = agendaContext.Turnos.ToList();
            //List<Servicio> servicios = agendaContext.Servicios.ToList();
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
            
            Servicio? s = agendaContext.Servicios.Where(serve => serve.tipo == "Manicuria").FirstOrDefault();
            if (s != null)
            {
                //Servicio servicio = new Servicio();
                //servicio.tipo = "Manicuria";
                turno.servicio = s;
                
            }
            //agendaContext.Turnos.Add(turno);
            //agendaContext.SaveChanges();
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
            Servicio? s = agendaContext.Servicios.Where(serve => serve.tipo == "Pedicuria").FirstOrDefault();
            if (s != null)
            {
                turno.servicio = s;

            }
            agendaContext.Turnos.Add(turno);
            agendaContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult AgendarPeluqueria()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AgendarPeluqueria(Turno turno)
        {
            Servicio? s = agendaContext.Servicios.Where(serve => serve.tipo == "Peluqueria").FirstOrDefault();
            if (s != null)
            {
                turno.servicio = s;

            }
            agendaContext.Turnos.Add(turno);
            agendaContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
