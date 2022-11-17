using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalEstetica.Models;

namespace ProyectoFinalEstetica.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<string> participantes = new List<string>();
            participantes.Add("Jake");
            participantes.Add("Mlepnos");
            participantes.Add("Terry");
            participantes.Add("Holt");
            participantes.Add("Boyle");
            participantes.Add("Santiago");
            participantes.Add("Cheddar");
            string nombre = "Cheddar";
            int numero = 5;
            ViewBag.numero = numero;
            ViewBag.nombre = nombre;
            return View(participantes);
        }

        
    }
}