//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiPrimeraAplicacionWebConEntityFramework.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETALLEVENTA
    {
        public int IIDETALLEVENTA { get; set; }
        public Nullable<int> IIDVENTA { get; set; }
        public Nullable<int> IIDVIAJE { get; set; }
        public Nullable<int> IIDBUS { get; set; }
        public Nullable<decimal> PRECIO { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
    
        public virtual Bus Bus { get; set; }
        public virtual VENTA VENTA { get; set; }
        public virtual Viaje Viaje { get; set; }
    }
}
