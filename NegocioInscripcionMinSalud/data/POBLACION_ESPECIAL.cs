//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NegocioInscripcionMinSalud.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class POBLACION_ESPECIAL
    {
        public POBLACION_ESPECIAL()
        {
            this.REGISTRO = new HashSet<REGISTRO>();
        }
    
        public int COD_POBLACION_ESPECIAL { get; set; }
        public string NOMBRE_POBLACION_ESPECIAL { get; set; }
    
        public virtual ICollection<REGISTRO> REGISTRO { get; set; }
    }
}