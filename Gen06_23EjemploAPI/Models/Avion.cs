using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace Gen06_23EjemploAPI.Models
{
    public class Avion
    {
        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "El ID es Requerido")]
        [Required(ErrorMessage = "El Numero de Registro es Requerido")]
        [StringLength(maximumLength:10, ErrorMessage = "El N° de Registro debe tener maximo 10")]
        public string NumRegistro { get; set; }
        [Required(ErrorMessage = "El Tipo es Requerido")]
        public string Tipo { set; get; }
        [Required(ErrorMessage = "El Modelo es Requerido")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "El Codigo del Modelo es Requerido")]
        public string CodigoModelo { get; set; }
        [Required(ErrorMessage = "La Capacidad es Requerido")]
        public int Capacidad { set; get; }
        [Required(ErrorMessage = "La Fecha es Requerido")]
        public DateTime FechaPrimerVuelo { set; get;}
        [Required(ErrorMessage = "La Motores son Requerido")]
        public int NumMotores { get; set; }
        [Required(ErrorMessage = "La Antiguedad es Requerido")]
        public int Antiguedad { set; get; }
        [Required(ErrorMessage = "La Estatus es Requerido")]
        public Estatus Estatus { set; get; }


        //Aca hacemos la relacion
        //AerolineaID
        public int AerolineaID { set; get; }
        [ForeignKey("AerolineaID")]
        public CAerolinea Aerolinea { set; get; }
    }
}
