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
    
    public partial class ESTADO_NOMINACION_RUPS
    {
        public ESTADO_NOMINACION_RUPS()
        {
            this.NOMINACION_PROCESO_RUPS = new HashSet<NOMINACION_PROCESO_RUPS>();
        }
    
        public int COD_ESTADO_NOMINACION_RUPS { get; set; }
        public string NOMBRE_ESTADO_NOMINACION_RUPS { get; set; }
    
        public virtual ICollection<NOMINACION_PROCESO_RUPS> NOMINACION_PROCESO_RUPS { get; set; }
    }
}