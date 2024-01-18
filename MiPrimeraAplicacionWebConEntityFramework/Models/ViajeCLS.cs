using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWebConEntityFramework.Models
{
    public class ViajeCLS
    {
        [Display(Name ="Id Viaje")]
        public int iidViaje { get; set; }

        [Display(Name = "Lugar de Origen")]
        [Required]
        public int iidLugarOrigen { get; set; }

        [Display(Name = "Lugar de Destino")]
        [Required]
        public int iidLugarDestino { get; set; }

        [Display(Name = "Precio")]
        [Required]
        public double precio  { get; set; }

        [Display(Name = "Fecha de Viaje")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime fechaViaje { get; set; }

        [Display(Name = "Bus")]
        [Required]
        public DateTime iidBus { get; set; }

        [Display(Name = "Numeros de Asientos")]
        [Required]
        public int numeroAsientosDisponibles { get; set; }


        // Propiedades Adicionales

        [Display(Name = "Lugar de Origen")]
        public string nombreLugarOrigen { get; set; }

        [Display(Name = "Lugar de Destino")]
        public string nombreLugarDestino { get; set; }

        [Display(Name = "Nombre de Bus")]
        public string nombreBus { get; set; }
    }
}