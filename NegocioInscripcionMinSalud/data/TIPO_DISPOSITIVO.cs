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
    
    public partial class TIPO_DISPOSITIVO
    {
        public TIPO_DISPOSITIVO()
        {
            this.NOMINACION_PROCESO_UPC = new HashSet<NOMINACION_PROCESO_UPC>();
        }
    
        public int COD_TIPO_DISPOSITIVO { get; set; }
        public string NOMBRE_TIPO_DISPOSITIVO { get; set; }
    
        public virtual ICollection<NOMINACION_PROCESO_UPC> NOMINACION_PROCESO_UPC { get; set; }
    }
}