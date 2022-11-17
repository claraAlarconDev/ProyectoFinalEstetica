using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ProyectoFinalEstetica.Models
{
	public class Turno
	{
        public string Horario { get; set; }
        public string Fecha { get; set; }
        public int Telefono { get; set; }
        public string Nombre { get; set; }

        public string Email { get; set; }
        
    }
}
