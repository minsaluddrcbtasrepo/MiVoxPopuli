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
    
    public partial class TIPO_IPS
    {
        public TIPO_IPS()
        {
            this.REGISTRO = new HashSet<REGISTRO>();
        }
    
        public int COD_TIPO_IPS { get; set; }
        public string TIPO_IPS1 { get; set; }
        public Nullable<bool> ES_PUBLICA { get; set; }
        public Nullable<bool> ES_PRIVADA { get; set; }
    
        public virtual ICollection<REGISTRO> REGISTRO { get; set; }
    }
}
