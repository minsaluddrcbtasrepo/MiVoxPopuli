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
    
    public partial class TIPO_PROCEDIMIENTO
    {
        public TIPO_PROCEDIMIENTO()
        {
            this.NOMINACION_PROCESO_UPC = new HashSet<NOMINACION_PROCESO_UPC>();
            this.NOMINACION_PROCESO_RUPS = new HashSet<NOMINACION_PROCESO_RUPS>();
        }
    
        public int COD_TIPO_PROCEDIMIENTO { get; set; }
        public string NOMBRE_TIPO_PROCEDIMIENTO { get; set; }
    
        public virtual ICollection<NOMINACION_PROCESO_UPC> NOMINACION_PROCESO_UPC { get; set; }
        public virtual ICollection<NOMINACION_PROCESO_RUPS> NOMINACION_PROCESO_RUPS { get; set; }
    }
}
