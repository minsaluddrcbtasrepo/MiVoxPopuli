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
    
    public partial class PARAMETRO_VALIDACION
    {
        public PARAMETRO_VALIDACION()
        {
            this.DETALLE_OBJECION = new HashSet<DETALLE_OBJECION>();
            this.DETALLE_VALIDACION_PROCESO = new HashSet<DETALLE_VALIDACION_PROCESO>();
        }
    
        public int COD_PARAMETRO_VALIDACION { get; set; }
        public bool ES_OK { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<int> COD_GRUPO_PARAMETRO_VALIDACION { get; set; }
    
        public virtual ICollection<DETALLE_OBJECION> DETALLE_OBJECION { get; set; }
        public virtual ICollection<DETALLE_VALIDACION_PROCESO> DETALLE_VALIDACION_PROCESO { get; set; }
        public virtual GRUPO_PARAMETRO_VALIDACION GRUPO_PARAMETRO_VALIDACION { get; set; }
    }
}
