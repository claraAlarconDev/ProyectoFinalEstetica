using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinalEstetica.Models
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
