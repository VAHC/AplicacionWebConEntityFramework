using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWebConEntityFramework.Models
{
    public class ClienteCLS
    {
        [Display(Name = "Id Cliente")]
        public int iidcliente { get; set; }

        [Display(Name = "Nombre Cliente")]
        [StringLength(100, ErrorMessage ="Longitud maxima 100")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [StringLength(150, ErrorMessage = "Longitud maxima 150")]
        [Required]
        public string apPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [StringLength(150, ErrorMessage = "Longitud maxima 150")]
        [Required]
        public string apMaterno { get; set;}
        
        [Display(Name ="Email")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [EmailAddress(ErrorMessage ="Ingrese un email valido")]
        [Required]
        public string email { get; set; }
        
        [Display(Name ="Direccion")]
        [DataType(DataType.MultilineText)]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [Required]
        public string direccion { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        public int iidsexo { get; set; }

        [Display(Name = "Telefono Fijo")]
        [StringLength(10, ErrorMessage = "Longitud maxima 10")]
        [Required]
        public string telefonoFijo { get; set; }

        [Display(Name = "Telefono Celular")]
        [StringLength(10, ErrorMessage = "Longitud maxima 10")]
        [Required]
        public string telefonoCelular { get; set; }
        public int bhabilitado { get; set; }

        // Propiedad adicional

        public string mensajeError { get; set; }
    }
}