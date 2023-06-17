using Gen06_23EjemploAPI.Models;
using System;
using System.Collections.Generic;

namespace Gen06_23EjemploAPI.DTOs
{
    public class AeroLineaDTOConAviones
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String IATA { get; set; }
        public  Estatus Status { get; set; }
        public String Country { get; set; }
        public int? Antiguedad { get; set; }
        public List<Avion> Aviones { get; set; }
    }
}
