using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gen06_23EjemploAPI.Models
{
    public class CAerolinea
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El ID es Requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El Nombre es Requerido")]
        public string Country { get; set; }
        public string IATA { get; set; }
        public Estatus Status { get; set; }

        public List<Avion> Aviones { get; set; }
    }
}
