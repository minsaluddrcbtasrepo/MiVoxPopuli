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
    
    public partial class PERFIL
    {
        public PERFIL()
        {
            this.USUARIO = new HashSet<USUARIO>();
            this.ACTIVIDAD_APLICACION = new HashSet<ACTIVIDAD_APLICACION>();
            this.MODULO_APLICACION = new HashSet<MODULO_APLICACION>();
        }
    
        public int CODIGO_PERFIL { get; set; }
        public string NOMBRE { get; set; }
    
        public virtual ICollection<USUARIO> USUARIO { get; set; }
        public virtual ICollection<ACTIVIDAD_APLICACION> ACTIVIDAD_APLICACION { get; set; }
        public virtual ICollection<MODULO_APLICACION> MODULO_APLICACION { get; set; }
    }
}