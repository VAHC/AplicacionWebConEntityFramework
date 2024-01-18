using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWebConEntityFramework.Models
{
    public class BusCLS
    {
        [Display(Name = "Id Bus")]
        public int iidBus { get; set; }

        [Display(Name = "Id Sucursal")]
        [Required]
        public int iidSucursal { get; set; }

        [Display(Name = "Tipo de Bus")]
        [Required]
        public int iidTipoBus { get; set; }

        [Display(Name = "Placa")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud maxima de caracteres 100")]
        public string placa { get; set; }

        [Display(Name = "Fecha de Compra")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaCompra { get; set; }

        [Display(Name = "Nombre de Modelo")]
        [Required]
        public int iidModelo { get; set; }

        [Display(Name = "Numero de Columnas")]
        [Required]
        public int numeroFilas { get; set; }

        [Display(Name = "Numero de Filas ")]
        [Required]
        public int numeroColumnas { get; set; }
        public int bdhabilitado { get; set; }

        [Display(Name = "Descripcion")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        public string descripcion { get; set; }

        [Display(Name = "Tipo de Bus")]
        [StringLength(200, ErrorMessage ="Longitud maxima 200")]
        public string observacion { get; set; }

        [Display(Name = "Nombre de Marca")]
        [Required]  
        public int iidmarca { get; set; }

        // Propiedades adicionales

        [Display(Name = "Nombre de Sucursal")]
        public string nombreSucursal { get; set; }

        [Display(Name = "Nombre Tipo Bus")]
        public string nombreTipoBus { get; set; }

        [Display(Name = "Nombre Modelo")]
        public string nombreModelo { get; set; }
    }
}