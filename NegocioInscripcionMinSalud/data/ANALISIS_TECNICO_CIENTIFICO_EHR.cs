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
    
    public partial class ANALISIS_TECNICO_CIENTIFICO_EHR
    {
        public int ID { get; set; }
        public Nullable<int> ID_NOMINACION_HER { get; set; }
        public string NOMBRE_NOMINACION { get; set; }
        public string TIPO_CLASIFICACION { get; set; }
        public string SINONIMO { get; set; }
        public Nullable<int> NOMINADOR { get; set; }
        public string SOLICITUD { get; set; }
        public Nullable<int> RESOLUCION { get; set; }
        public string CODIGO_OMIN { get; set; }
        public string CODIGO_ORPHANET { get; set; }
        public string CODIGO_CIE { get; set; }
        public string CARACTERIZACION { get; set; }
        public string PREVALENCIA { get; set; }
        public string ETIOLOGIA { get; set; }
        public string CONFIRMACION_DIAGNOSTICA { get; set; }
        public string PRUEBA_ORO { get; set; }
        public string CUPS_PRUEBA_ORO { get; set; }
        public string ESPECIALIDAD_PRIMARIA { get; set; }
        public string OTRAS_ESPECIALIDADES { get; set; }
        public string OBSERVACIONES { get; set; }
        public string REFERENCIAS { get; set; }
        public string EXPERTOS_CONVOCADOS { get; set; }
        public Nullable<System.DateTime> FECHA_PANEL { get; set; }
        public string DECISION_PANEL { get; set; }
        public string ACTA { get; set; }
        public Nullable<bool> AFECTA_LISTADO { get; set; }
        public string CONSECUTIVO_QUE_MODIFICA { get; set; }
        public Nullable<bool> ANALISIS_FINALIZADO { get; set; }
    }
}