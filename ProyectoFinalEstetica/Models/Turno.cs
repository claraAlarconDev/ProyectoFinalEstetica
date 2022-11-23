using System.ComponentModel.DataAnnotations;


namespace ProyectoFinalEstetica.Models
{
	public class Turno
	{
        [Key]
        public int Id { get; set; }
        public string Horario { get; set; }
        public DateTime Fecha { get; set; }
        public Int32 Telefono { get; set; }
        public string Nombre { get; set; }
        public Servicio servicio { get; set; }
		public string Email { get; set; }
        public string Especialidad { get; set; }

    }
}
