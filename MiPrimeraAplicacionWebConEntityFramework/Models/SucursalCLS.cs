using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWebConEntityFramework.Models
{
    public class SucursalCLS
    {
        [Display(Name = "Id Sucursal")]
        public int iidsucursal { get; set; }
        
        [Display(Name = "Nombre de Sucursal")]
        [StringLength(100,ErrorMessage ="Longitud maxima 100")]
        [Required]
        public string nombre { get; set; }
        
        [Display(Name = "Direccion de Sucursal")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [Required]
        public string direccion { get; set; }
        
        [Display(Name = "Telefono de Sucursal")]
        [StringLength(10, ErrorMessage = "Longitud maxima 10")]
        [Required]
        public string telefono { get; set; }
        
        [Display(Name = "Email de Sucursal")]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        [EmailAddress(ErrorMessage ="Ingrese un emal valido")]
        [Required]
        public string email { get; set; }

        //private const bool V = true;
        [Display(Name ="Fecha de Apertura")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime fechaApertura { get; set; }
        public int bhabilitado { get; set; }

        // AÑADO UNA PROPIEDAD (ERRORES DE VALIDADCIÓN)

        public string mensajeError { get; set; }
    }
}