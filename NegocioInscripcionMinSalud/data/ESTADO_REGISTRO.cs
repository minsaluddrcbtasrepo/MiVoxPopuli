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
    
    public partial class ESTADO_REGISTRO
    {
        public ESTADO_REGISTRO()
        {
            this.REGISTRO = new HashSet<REGISTRO>();
        }
    
        public int COD_ESTADO_REGISTRO { get; set; }
        public string NOMBRE_ESTADO_REGISTRO { get; set; }
    
        public virtual ICollection<REGISTRO> REGISTRO { get; set; }
    }
}
