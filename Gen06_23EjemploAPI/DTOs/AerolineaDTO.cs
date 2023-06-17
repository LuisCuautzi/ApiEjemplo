using Gen06_23EjemploAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gen06_23EjemploAPI.DTOs
{
    public class AerolineaDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String IATA { get; set; }
        public Estatus Status { get; set; }
        public String Country { get; set; }
    }
}
