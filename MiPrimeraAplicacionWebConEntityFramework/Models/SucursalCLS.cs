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
        [Display(Name = "Nombre Sucursal")]
        public string nombre { get; set; }
        public string direccion { get; set; }
        [Display(Name = "Telefono Sucursal")]
        public string telefono { get; set; }
        [Display(Name = "Email Sucursal")]
        public string email { get; set; }
        public DateTime fechaApertura { get; set; }
        public int bhabilitado { get; set; }
    }
}