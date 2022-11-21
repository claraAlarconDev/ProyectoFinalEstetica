using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinalEstetica.Controllers
{
	public class HomeController1 : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
