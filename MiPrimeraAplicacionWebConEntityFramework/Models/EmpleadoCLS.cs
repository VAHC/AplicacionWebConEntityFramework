using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiPrimeraAplicacionWebConEntityFramework.Models
{
    public class EmpleadoCLS
    {
        [Display(Name ="Id Empleado")]
        [Required]
        public int iidEmpleado { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(100,ErrorMessage ="Longitud maxima 100")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [Required]
        public string apPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        [Required]
        public string apMaterno { get; set; }

        [Display(Name = "Fecha de Contrato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime fechaContrato { get; set; }

        [Display(Name = "Tipo de Usuario")]
        [Required]
        public int iidTipoUsuario { get; set; }

        [Display(Name = "Tipo de Contrato")]
        [Required]
        public int iidTipoContrato { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        public int iidSexo { get; set; }
        public int bhabilitado { get; set; }

        // Propiedad adicionales

        public string nombreTipoContrato { get; set; }
        public string nombreTipoUsuario { get; set; }
    }
}