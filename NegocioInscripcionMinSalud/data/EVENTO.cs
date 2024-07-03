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
    
    public partial class EVENTO
    {
        public EVENTO()
        {
            this.CONFIRMACION_EVENTO = new HashSet<CONFIRMACION_EVENTO>();
            this.FORMATO_EVENTOXEVENTO = new HashSet<FORMATO_EVENTOXEVENTO>();
            this.TECNOLOGIASXEVENTO = new HashSet<TECNOLOGIASXEVENTO>();
            this.TIPO_JURIDICOXEVENTO = new HashSet<TIPO_JURIDICOXEVENTO>();
        }
    
        public int COD_EVENTO { get; set; }
        public Nullable<int> COD_TEMATICA_EVENTO { get; set; }
        public string NOMBRE_EVENTO { get; set; }
        public string PROYECTO_ASOCIADO { get; set; }
        public string DESCRIPCION_EVENTO { get; set; }
        public string PUBLICO_OBJETIVO { get; set; }
        public string REQUISITOS { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string LUGAR { get; set; }
        public Nullable<int> CAPACIDAD_MAXIMA { get; set; }
        public Nullable<int> COD_PROCESO { get; set; }
        public Nullable<bool> PERMITE_REPETIR_ASISTENCIA { get; set; }
        public Nullable<int> DURACION_EVENTO { get; set; }
        public Nullable<bool> PERMITE_PERSONAS_NATURALES { get; set; }
        public Nullable<int> DELEGADOS { get; set; }
        public Nullable<System.DateTime> VISIBLE_DESDE { get; set; }
        public Nullable<System.DateTime> VISIBLE_HASTA { get; set; }
    
        public virtual ICollection<CONFIRMACION_EVENTO> CONFIRMACION_EVENTO { get; set; }
        public virtual TEMATICA_EVENTO TEMATICA_EVENTO { get; set; }
        public virtual ICollection<FORMATO_EVENTOXEVENTO> FORMATO_EVENTOXEVENTO { get; set; }
        public virtual ICollection<TECNOLOGIASXEVENTO> TECNOLOGIASXEVENTO { get; set; }
        public virtual ICollection<TIPO_JURIDICOXEVENTO> TIPO_JURIDICOXEVENTO { get; set; }
        public virtual PROCESO PROCESO { get; set; }
    }
}