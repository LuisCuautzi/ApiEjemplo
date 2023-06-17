using Gen06_23EjemploAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gen06_23EjemploAPI.DTOs
{
    public class AerolineaCreateDTO
    {
        [Required(ErrorMessage = "Nombre de aerolinea es requerida")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Codigo IATA de aerilinea es requerido")]
        public String IATA { get; set; }
        [Required(ErrorMessage = "El estatus de aerolinea es requerido")]
        public Estatus Status { get; set; }
        [Required(ErrorMessage = "Pais de aerolinea es requerido")]
        public  String Country { get; set; }
    }
}
