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
    
    public partial class USUARIO
    {
        public USUARIO()
        {
            this.CONFIGURACION_VALIDACION_PROCESO = new HashSet<CONFIGURACION_VALIDACION_PROCESO>();
            this.NOMINACION_PROCESO_UPC = new HashSet<NOMINACION_PROCESO_UPC>();
            this.REGISTRO = new HashSet<REGISTRO>();
            this.REGISTRO1 = new HashSet<REGISTRO>();
            this.VALIDACION_PROCESO_RUPS = new HashSet<VALIDACION_PROCESO_RUPS>();
            this.VALIDACION_PROCESO = new HashSet<VALIDACION_PROCESO>();
            this.NOMINACION_PROCESO = new HashSet<NOMINACION_PROCESO>();
        }
    
        public int CODIGO { get; set; }
        public string PASSWORD { get; set; }
        public byte[] ECRYPTEDPASS { get; set; }
        public string NOMBRE { get; set; }
        public bool ACTIVO { get; set; }
        public Nullable<int> CODIGO_PERFIL { get; set; }
        public string LOGIN { get; set; }
        public string EMAIL { get; set; }
    
        public virtual ICollection<CONFIGURACION_VALIDACION_PROCESO> CONFIGURACION_VALIDACION_PROCESO { get; set; }
        public virtual ICollection<NOMINACION_PROCESO_UPC> NOMINACION_PROCESO_UPC { get; set; }
        public virtual PERFIL PERFIL { get; set; }
        public virtual ICollection<REGISTRO> REGISTRO { get; set; }
        public virtual ICollection<REGISTRO> REGISTRO1 { get; set; }
        public virtual ICollection<VALIDACION_PROCESO_RUPS> VALIDACION_PROCESO_RUPS { get; set; }
        public virtual ICollection<VALIDACION_PROCESO> VALIDACION_PROCESO { get; set; }
        public virtual ICollection<NOMINACION_PROCESO> NOMINACION_PROCESO { get; set; }
    }
}
