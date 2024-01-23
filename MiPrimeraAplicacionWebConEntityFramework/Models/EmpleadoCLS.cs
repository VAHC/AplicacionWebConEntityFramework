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
        public int iidEmpleado { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        public string nombre { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required]
        [StringLength(200, ErrorMessage = "Longitud maxima 200")]
        public string apPaterno { get; set; }

        [Display(Name = "Apellido Materno")]
        [Required]  
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        public string apMaterno { get; set; }

        [Display(Name = "Fecha de Contrato")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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

        [Display(Name ="Sueldo")]
        [Required]
        [Range(0,100000,ErrorMessage ="Fuera de rango")]
        public decimal sueldo { get; set; }

        // Propiedades adicionales

        [Display(Name ="Tipo Contrato")]
        public string nombreTipoContrato { get; set; }

        [Display(Name = "Tipo Usuario")]
        public string nombreTipoUsuario { get; set; }
    }
}