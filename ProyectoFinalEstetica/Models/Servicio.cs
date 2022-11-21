using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalEstetica.Models
{
	public class Servicio
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Tipo{ get; set; }

	}

	

}
