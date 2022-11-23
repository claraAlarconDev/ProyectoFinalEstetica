using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult MisTurnos(String phone = "")
        {
            Int32 phoneNumber;
            bool validNumber = Int32.TryParse(phone, out phoneNumber);
            List<Turno> turnos = new List<Turno>();
            
            if (validNumber)
                turnos = agendaContext.Turnos.Include(t => t.servicio).Where(x => x.Telefono.Equals(phoneNumber)).ToList();
            return View(turnos);
        }

        [HttpGet]
        public IActionResult AgendarManicuria()
        {
            List<string> horarios = new List<string>{ "9:00","10:00","11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
            Dictionary<string, List<string>> mapaHorariosDisponiblesPorDia = new Dictionary<string, List<string>>();
            List<Turno> turnos = agendaContext.Turnos.Where(x => x.Fecha >= DateTime.Today && x.Especialidad.Equals("Manicuria")).ToList();
            for (int i = 0; i < 7; i++)
            {
                string dia = DateTime.Today.AddDays(i).ToString("yyyy-MM-dd");
                List<string> turnosDelDiaOcupados = turnos.Where(x => x.Fecha.Equals(DateTime.Today.AddDays(i))).Select(x => x.Horario).ToList();
                List<string> horariosDisponiblesDelDia = horarios.ToList();
                horariosDisponiblesDelDia.RemoveAll(x => turnosDelDiaOcupados.Contains(x));
                mapaHorariosDisponiblesPorDia.Add(dia, horariosDisponiblesDelDia);
            }

            this.ViewData.Add("horariosDisponibles", mapaHorariosDisponiblesPorDia);

            return View();
        }
        [HttpPost]
        public IActionResult AgendarManicuria(Turno turno)
        {
            
            Servicio? s = agendaContext.Servicios.Where(serve => serve.tipo == "Manicuria").FirstOrDefault();
            if (s != null)
            {
                turno.servicio = s;
                agendaContext.Turnos.Add(turno);
                agendaContext.SaveChanges();
                return RedirectToAction("Index", "");
            }
            return View(turno);
        }

        [HttpGet]
        public IActionResult AgendarPedicuria()
        {
            List<string> horarios = new List<string> { "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
            Dictionary<string, List<string>> mapaHorariosDisponiblesPorDia = new Dictionary<string, List<string>>();
            List<Turno> turnos = agendaContext.Turnos.Where(x => x.Fecha >= DateTime.Today && x.Especialidad.Equals("Pedicuria")).ToList();
            for (int i = 0; i < 7; i++)
            {
                string dia = DateTime.Today.AddDays(i).ToString("yyyy-MM-dd");
                List<string> turnosDelDiaOcupados = turnos.Where(x => x.Fecha.Equals(DateTime.Today.AddDays(i))).Select(x => x.Horario).ToList();
                List<string> horariosDisponiblesDelDia = horarios.ToList();
                horariosDisponiblesDelDia.RemoveAll(x => turnosDelDiaOcupados.Contains(x));
                mapaHorariosDisponiblesPorDia.Add(dia, horariosDisponiblesDelDia);
            }

            this.ViewData.Add("horariosDisponibles", mapaHorariosDisponiblesPorDia);

            return View();
        }

        [HttpPost]
        public IActionResult AgendarPedicuria(Turno turno)
        {
            Servicio? s = agendaContext.Servicios.Where(serve => serve.tipo == "Pedicuria").FirstOrDefault();
                if (s != null)
                {
                    turno.servicio = s;
                    agendaContext.Turnos.Add(turno);
                    agendaContext.SaveChanges();
                    return RedirectToAction("Index", "");
                }
            return View(turno);
        }

        [HttpGet]
        public IActionResult AgendarPeluqueria()
        {
            List<string> horarios = new List<string> { "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
            Dictionary<string, List<string>> mapaHorariosDisponiblesPorDia = new Dictionary<string, List<string>>();
            List<Turno> turnos = agendaContext.Turnos.Where(x => x.Fecha >= DateTime.Today && x.Especialidad.Equals("Peluqueria")).ToList();
            for (int i = 0; i < 7; i++)
            {
                string dia = DateTime.Today.AddDays(i).ToString("yyyy-MM-dd");
                List<string> turnosDelDiaOcupados = turnos.Where(x => x.Fecha.Equals(DateTime.Today.AddDays(i))).Select(x => x.Horario).ToList();
                List<string> horariosDisponiblesDelDia = horarios.ToList();
                horariosDisponiblesDelDia.RemoveAll(x => turnosDelDiaOcupados.Contains(x));
                mapaHorariosDisponiblesPorDia.Add(dia, horariosDisponiblesDelDia);
            }

            this.ViewData.Add("horariosDisponibles", mapaHorariosDisponiblesPorDia);

            return View();
        }

        [HttpPost]
        public IActionResult AgendarPeluqueria(Turno turno)
        {
            Servicio? s = agendaContext.Servicios.Where(serve => serve.tipo == "Peluqueria").FirstOrDefault();
            if (s != null)
            {
                turno.servicio = s;
                agendaContext.Turnos.Add(turno);
                agendaContext.SaveChanges();
                return RedirectToAction("Index", "");
            }
            return View(turno);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Turno? turnoBuscado = agendaContext.Turnos.Find(Id);
            if (turnoBuscado != null)
            {
                agendaContext.Turnos.Remove(turnoBuscado);
                agendaContext.SaveChanges();
            }
            return RedirectToAction("MisTurnos", new { phone = turnoBuscado?.Telefono });
        }
        [HttpGet]
        public IActionResult EditManicuria(int Id)
        {
            Turno? turnoBuscado = agendaContext.Turnos.Find(Id);

            List<string> horarios = new List<string> { "9:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
            Dictionary<string, List<string>> mapaHorariosDisponiblesPorDia = new Dictionary<string, List<string>>();
            List<Turno> turnos = agendaContext.Turnos.Where(x => x.Fecha >= DateTime.Today).ToList();
            for (int i = 0; i < 7; i++)
            {
                string dia = DateTime.Today.AddDays(i).ToString("yyyy-MM-dd");
                List<string> turnosDelDiaOcupados = turnos.Where(x => x.Fecha.Equals(DateTime.Today.AddDays(i))).Select(x => x.Horario).ToList();
                List<string> horariosDisponiblesDelDia = horarios.ToList();
                horariosDisponiblesDelDia.RemoveAll(x => turnosDelDiaOcupados.Contains(x));
                mapaHorariosDisponiblesPorDia.Add(dia, horariosDisponiblesDelDia);
            }

            this.ViewData.Add("horariosDisponibles", mapaHorariosDisponiblesPorDia);

            if (turnoBuscado != null)
            {
                return View(turnoBuscado);
            } else
            {
                return RedirectToAction(nameof(Index));
            }
        }
        [HttpPost]
        public IActionResult UpdateManicuria(int Id,Turno turno)
        {
            
            
                if (Id != turno.Id)
                {
                    return NotFound();
                }
                Servicio? s = agendaContext.Servicios.Where(serve => serve.tipo == "Manicuria").FirstOrDefault();
                if (s != null)
                {
                    turno.servicio = s;

                }
               
                    agendaContext.Turnos.Update(turno);
                    agendaContext.SaveChanges();
          
                return RedirectToAction(nameof(Index));
            
        }
        [HttpPost]
        public IActionResult UpdatePedicuria(int Id, Turno turno)
        {

            if (Id != turno.Id)
            {
                return NotFound();
            }
            
            Servicio? s = agendaContext.Servicios.Where(serve => serve.tipo == "Pedicuria").FirstOrDefault();
            if (s != null)
            {
                turno.servicio = s;

            }
           
                agendaContext.Turnos.Update(turno);
                agendaContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult UpdatePeluqueria(int Id, Turno turno)
        {

            if (Id != turno.Id)
            {
                return NotFound();
            }
            Servicio? s = agendaContext.Servicios.Where(serve => serve.tipo == "Peluqueria").FirstOrDefault();
            if (s != null)
            {
                turno.servicio = s;

            }
            
                agendaContext.Turnos.Update(turno);
                agendaContext.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }
    }
}
