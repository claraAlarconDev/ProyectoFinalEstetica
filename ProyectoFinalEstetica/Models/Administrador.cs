using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalEstetica.Models
{
	public class Administrador
	{
		[Key]
		public int Id { get; set; }

		public string Contraseña { get; set; }
	}
}
