﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ParticipacionCiudadanaEntities : DbContext
    {
        public ParticipacionCiudadanaEntities()
            : base("name=ParticipacionCiudadanaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ACTIVIDAD_APLICACION> ACTIVIDAD_APLICACION { get; set; }
        public DbSet<AMBITO_PROCEDIMIENTO> AMBITO_PROCEDIMIENTO { get; set; }
        public DbSet<AMBITO_UPC> AMBITO_UPC { get; set; }
        public DbSet<ARCHIVOXNOMINACION> ARCHIVOXNOMINACION { get; set; }
        public DbSet<ARCHIVOXOBJECION> ARCHIVOXOBJECION { get; set; }
        public DbSet<ARCHIVOXPROCESO> ARCHIVOXPROCESO { get; set; }
        public DbSet<CIE10> CIE10 { get; set; }
        public DbSet<CLASIFICACION_RIESGO> CLASIFICACION_RIESGO { get; set; }
        public DbSet<CONFIGURACION_VALIDACION_PROCESO> CONFIGURACION_VALIDACION_PROCESO { get; set; }
        public DbSet<CONFIRMACION_EVENTO> CONFIRMACION_EVENTO { get; set; }
        public DbSet<CUPS> CUPS { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<DETALLE_OBJECION> DETALLE_OBJECION { get; set; }
        public DbSet<DETALLE_VALIDACION_PROCESO> DETALLE_VALIDACION_PROCESO { get; set; }
        public DbSet<ESTADO_NOMINACION> ESTADO_NOMINACION { get; set; }
        public DbSet<ESTADO_NOMINACION_RUPS> ESTADO_NOMINACION_RUPS { get; set; }
        public DbSet<ESTADO_NOMINACION_UPC> ESTADO_NOMINACION_UPC { get; set; }
        public DbSet<ESTADO_REGISTRO> ESTADO_REGISTRO { get; set; }
        public DbSet<EstadoUsuario> EstadoUsuario { get; set; }
        public DbSet<EVENTO> EVENTO { get; set; }
        public DbSet<FORMATO_EVENTO> FORMATO_EVENTO { get; set; }
        public DbSet<FORMATO_EVENTOXEVENTO> FORMATO_EVENTOXEVENTO { get; set; }
        public DbSet<FORMATOEVENTOXCONFIRMACION> FORMATOEVENTOXCONFIRMACION { get; set; }
        public DbSet<GLOSARIO> GLOSARIO { get; set; }
        public DbSet<GRUPO_PARAMETRO_VALIDACION> GRUPO_PARAMETRO_VALIDACION { get; set; }
        public DbSet<HistoricoEliminacion> HistoricoEliminacion { get; set; }
        public DbSet<MEDICAMENTOS> MEDICAMENTOS { get; set; }
        public DbSet<MODULO_APLICACION> MODULO_APLICACION { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<NIVEL_FORMACION> NIVEL_FORMACION { get; set; }
        public DbSet<NOMINACION_PROCESO_UPC> NOMINACION_PROCESO_UPC { get; set; }
        public DbSet<OBJECION_PROCESO> OBJECION_PROCESO { get; set; }
        public DbSet<PAIS> PAIS { get; set; }
        public DbSet<PARAMETRO_VALIDACION> PARAMETRO_VALIDACION { get; set; }
        public DbSet<Participante> Participante { get; set; }
        public DbSet<PERFIL> PERFIL { get; set; }
        public DbSet<POBLACION_ESPECIAL> POBLACION_ESPECIAL { get; set; }
        public DbSet<PreguntaSecreta> PreguntaSecreta { get; set; }
        public DbSet<PROCEDIMIENTO> PROCEDIMIENTO { get; set; }
        public DbSet<REGISTRO> REGISTRO { get; set; }
        public DbSet<SEXO> SEXO { get; set; }
        public DbSet<tblMigracionPrimeraVigencia> tblMigracionPrimeraVigencia { get; set; }
        public DbSet<TECNOLOGIA> TECNOLOGIA { get; set; }
        public DbSet<TECNOLOGIASXEVENTO> TECNOLOGIASXEVENTO { get; set; }
        public DbSet<TECNOLOGIAXCONFIRMACION_EVENTO> TECNOLOGIAXCONFIRMACION_EVENTO { get; set; }
        public DbSet<TEMATICA_EVENTO> TEMATICA_EVENTO { get; set; }
        public DbSet<TIPO_DISPOSITIVO> TIPO_DISPOSITIVO { get; set; }
        public DbSet<TIPO_IPS> TIPO_IPS { get; set; }
        public DbSet<TIPO_JURIDICO> TIPO_JURIDICO { get; set; }
        public DbSet<TIPO_JURIDICOXEVENTO> TIPO_JURIDICOXEVENTO { get; set; }
        public DbSet<TIPO_NOMINACION_MEDICAMENTO> TIPO_NOMINACION_MEDICAMENTO { get; set; }
        public DbSet<TIPO_PROCEDIMIENTO> TIPO_PROCEDIMIENTO { get; set; }
        public DbSet<TIPO_REPRESENTADO> TIPO_REPRESENTADO { get; set; }
        public DbSet<TIPO_ZONA> TIPO_ZONA { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<UPC_FORMULARIO3> UPC_FORMULARIO3 { get; set; }
        public DbSet<USUARIO> USUARIO { get; set; }
        public DbSet<VALIDACION_PROCESO> VALIDACION_PROCESO { get; set; }
        public DbSet<VALIDACION_PROCESO_RUPS> VALIDACION_PROCESO_RUPS { get; set; }
        public DbSet<VIGENCIA> VIGENCIA { get; set; }
        public DbSet<OBJECION_HUERFANA> OBJECION_HUERFANA { get; set; }
        public DbSet<ARCHIVOXNOMINACION_HUERFANA> ARCHIVOXNOMINACION_HUERFANA { get; set; }
        public DbSet<ARCHIVOXOBJECION_HUERFANA> ARCHIVOXOBJECION_HUERFANA { get; set; }
        public DbSet<REPOSITORIO_HUEFANAS> REPOSITORIO_HUEFANAS { get; set; }
        public DbSet<DCI> DCI { get; set; }
        public DbSet<PRUEBA> PRUEBA { get; set; }
        public DbSet<PROCESO> PROCESO { get; set; }
        public DbSet<ESPECIALIDAD> ESPECIALIDAD { get; set; }
        public DbSet<LISTADO_HEF> LISTADO_HEF { get; set; }
        public DbSet<NOMINACION_HUERFANA> NOMINACION_HUERFANA { get; set; }
        public DbSet<NOMINACION_PROCESO_RUPS> NOMINACION_PROCESO_RUPS { get; set; }
        public DbSet<NOMINACION_PROCESO> NOMINACION_PROCESO { get; set; }
        public DbSet<ANALISIS_TECNICO_CIENTIFICO_EHR> ANALISIS_TECNICO_CIENTIFICO_EHR { get; set; }
        public DbSet<NOMINACION_CRITERIO_EXCLUYENTE> NOMINACION_CRITERIO_EXCLUYENTE { get; set; }
        public DbSet<ARCHIVOXNOMINACIONXCRITERIO> ARCHIVOXNOMINACIONXCRITERIO { get; set; }
    }
}