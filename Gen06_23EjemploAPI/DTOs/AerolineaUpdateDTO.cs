using Gen06_23EjemploAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gen06_23EjemploAPI.DTOs
{
    //Data Transfer Object
    public class AerolineaUpdateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre de aerolinea es requerida")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Codigo IATA de aerolinea es requerido")]
        public String IATA { get; set; }
        [Required(ErrorMessage = "Estatus de aerolinea es requerido")]
        public Estatus Status { get; set; }
        [Required(ErrorMessage = "Pais de aerolinea es requerido")]
        public String Country { get; set; }
    } 
}
