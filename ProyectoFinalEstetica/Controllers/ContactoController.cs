using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalEstetica.Models;

namespace ProyectoFinalEstetica.Controllers
{
	public class ContactoController : Controller
	{
        AgendaContext agendaContext = new AgendaContext();

        [HttpGet]
		public IActionResult Index(String password)
		{
            Administrador? admin = agendaContext.Administradores.Where(admi => admi.Contraseña == password).FirstOrDefault();
            if (admin != null)
			{
                return RedirectToAction(nameof(Consultas));
            }
			return View();
		}
        
        [HttpGet]
		public IActionResult Consultas()
		{
            List<Contacto> contactoList = new List<Contacto>();
            contactoList = agendaContext.Contactos.ToList();
            return View(contactoList);
		}
		[HttpGet]
		public IActionResult Delete(int Id)
		{
			
			Contacto? contactoBuscado = agendaContext.Contactos.Find(Id);
			if (contactoBuscado != null)
			{
				agendaContext.Remove(contactoBuscado);
				agendaContext.SaveChanges();
			} 


				return RedirectToAction(nameof(Consultas));
			
			
        }
    }
}
