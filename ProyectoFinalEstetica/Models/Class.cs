using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalEstetica.Models
{
	public class Contacto
	{
		public string Nombre { get; set; }
		public string Email { get; set; }
		public string Asunto { get; set; }
		public string Mensaje { get; set; }

	}
}
