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
    
    public partial class VIGENCIA
    {
        public VIGENCIA()
        {
            this.NOMINACION_PROCESO_RUPS = new HashSet<NOMINACION_PROCESO_RUPS>();
            this.NOMINACION_PROCESO = new HashSet<NOMINACION_PROCESO>();
        }
    
        public int COD_VIGENCIA { get; set; }
        public int COD_PROCESO { get; set; }
        public string DESCRIPCION { get; set; }
        public System.DateTime FECHA_INICIO { get; set; }
        public System.DateTime FECHA_FIN { get; set; }
        public bool ABIERTO { get; set; }
    
        public virtual PROCESO PROCESO { get; set; }
        public virtual ICollection<NOMINACION_PROCESO_RUPS> NOMINACION_PROCESO_RUPS { get; set; }
        public virtual ICollection<NOMINACION_PROCESO> NOMINACION_PROCESO { get; set; }
    }
}
