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
    
    public partial class TIPO_NOMINACION_MEDICAMENTO
    {
        public TIPO_NOMINACION_MEDICAMENTO()
        {
            this.UPC_FORMULARIO3 = new HashSet<UPC_FORMULARIO3>();
        }
    
        public int COD_TIPO_NOMINACION_MEDICAMENTO { get; set; }
        public string NOMBRE_TIPO_NOMINACION_MEDICAMENTO { get; set; }
    
        public virtual ICollection<UPC_FORMULARIO3> UPC_FORMULARIO3 { get; set; }
    }
}