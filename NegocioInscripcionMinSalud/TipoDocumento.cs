using DatosInscripcionMinSalud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioInscripcionMinSalud
{
    public class TipoDocumento
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
      
        public static TipoDocumento[] ObtenerTiposDocumentos()
        {
            DatosParticipante listaBD = new DatosParticipante();
            DataTable listaDropDown = listaBD.CargarListaBD(TipoLista.TipoDocumento);            

            List<TipoDocumento> tipoDocumento = new List<TipoDocumento>();
            foreach (DataRow rw in listaDropDown.Rows)
            {
                TipoDocumento nwTipo = new TipoDocumento();
                nwTipo.Id = rw["Id"].ToString();
                nwTipo.Nombre = rw["Nombre"].ToString();

                tipoDocumento.Add(nwTipo);
            }

            return tipoDocumento.ToArray();
        }

        public static TipoDocumento[] ObtenerTiposDocumentosNatural()
        {
            DatosParticipante listaBD = new DatosParticipante();
            DataTable listaDropDown = listaBD.CargarListaBD(TipoLista.TipoDocumentoNatural);

            List<TipoDocumento> tipoDocumento = new List<TipoDocumento>();
            foreach (DataRow rw in listaDropDown.Rows)
            {
                TipoDocumento nwTipo = new TipoDocumento();
                nwTipo.Id = rw["Id"].ToString();
                nwTipo.Nombre = rw["Nombre"].ToString();

                tipoDocumento.Add(nwTipo);
            }

            return tipoDocumento.ToArray();
        }

        public static TipoDocumento[] ObtenerTiposDocumentosJuridico()
        {
            DatosParticipante listaBD = new DatosParticipante();
            DataTable listaDropDown = listaBD.CargarListaBD(TipoLista.TipoDocumentoJuridico);

            List<TipoDocumento> tipoDocumento = new List<TipoDocumento>();
            foreach (DataRow rw in listaDropDown.Rows)
            {
                TipoDocumento nwTipo = new TipoDocumento();
                nwTipo.Id = rw["Id"].ToString();
                nwTipo.Nombre = rw["Nombre"].ToString();

                tipoDocumento.Add(nwTipo);
            }

            return tipoDocumento.ToArray();
        }
    }
}
