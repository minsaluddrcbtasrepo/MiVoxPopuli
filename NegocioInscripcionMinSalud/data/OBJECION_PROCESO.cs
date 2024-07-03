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
    
    public partial class OBJECION_PROCESO
    {
        public OBJECION_PROCESO()
        {
            this.ARCHIVOXOBJECION = new HashSet<ARCHIVOXOBJECION>();
            this.DETALLE_OBJECION = new HashSet<DETALLE_OBJECION>();
        }
    
        public int COD_OBJECION_PROCESO { get; set; }
        public Nullable<System.DateTime> FECHA_OBJECION { get; set; }
        public string OBSERVACIONES_GENERALES { get; set; }
        public Nullable<int> OBJETADO_POR { get; set; }
        public Nullable<int> COD_NOMINACION_PROCESO { get; set; }
        public string OBS_NOMBRE_TECNOLOGIA { get; set; }
        public string OBS_CIE10 { get; set; }
        public string OBS_CIE10_2 { get; set; }
        public string OBS_INDICACION_CIE10 { get; set; }
        public string OBS_MEDICAMENTO { get; set; }
        public string OBS_PROCEDIMIENTO { get; set; }
        public string OBS_DISPOSITIVO_MEDICO { get; set; }
        public string OBS_OTRO { get; set; }
        public string OBS_CREITERIO_A { get; set; }
        public string OBS_CREITERIO_B { get; set; }
        public string OBS_CREITERIO_C { get; set; }
        public string OBS_CREITERIO_D { get; set; }
        public string OBS_CREITERIO_E { get; set; }
        public string OBS_CREITERIO_F { get; set; }
        public string OBS_EVIDENCIA { get; set; }
        public string OBS_CONFLICTO_INTERES { get; set; }
        public string OBS_CONCEPTO { get; set; }
        public Nullable<bool> VISIBLE { get; set; }
    
        public virtual ICollection<ARCHIVOXOBJECION> ARCHIVOXOBJECION { get; set; }
        public virtual ICollection<DETALLE_OBJECION> DETALLE_OBJECION { get; set; }
        public virtual REGISTRO REGISTRO { get; set; }
        public virtual NOMINACION_PROCESO NOMINACION_PROCESO { get; set; }
    }
}