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
    
    public partial class FORMATO_EVENTO
    {
        public FORMATO_EVENTO()
        {
            this.FORMATO_EVENTOXEVENTO = new HashSet<FORMATO_EVENTOXEVENTO>();
            this.FORMATOEVENTOXCONFIRMACION = new HashSet<FORMATOEVENTOXCONFIRMACION>();
        }
    
        public int COD_FORMATO_EVENTO { get; set; }
        public string NOMBRE_FORMATO_EVENTO { get; set; }
        public string URL_ARCHIVO { get; set; }
    
        public virtual ICollection<FORMATO_EVENTOXEVENTO> FORMATO_EVENTOXEVENTO { get; set; }
        public virtual ICollection<FORMATOEVENTOXCONFIRMACION> FORMATOEVENTOXCONFIRMACION { get; set; }
    }
}
