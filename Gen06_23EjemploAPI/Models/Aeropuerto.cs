using System;
using System.ComponentModel.DataAnnotations;

namespace Gen06_23EjemploAPI.Models
{
    public class Aeropuerto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre del aeropuerto es requerido")]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "El IATA del aeropuerto es requerido")]
        public String IATA { get; set; }
        [Required(ErrorMessage = "El ICAO del aeropuerto es requerido")]
        public String ICAO { get; set; }
        [Required(ErrorMessage = "Latitud del aeropuerto es requerido")]
        public String Latitud { get; set; }
        [Required(ErrorMessage = "Longuitud del aeropuerto es requerido")]
        public String Longuitud { get; set; }
        [Required(ErrorMessage = "Debe especificarse la zona horaria del aeropuerto")]
        public String ZonaHoraria { get; set; }
        [Required(ErrorMessage = "Debe especificarse la terminal del aeropuerto")]
        public String Terminal { get; set; }
        [Required(ErrorMessage = "Debe especificarse el pais al que pertenece el aeropuerto")]
        public String Pais { get; set; }

    }
}
