using DatosInscripcionMinSalud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioInscripcionMinSalud
{
    public class TipoUsuario
    {

        public string Id { get; set; }
        public string Nombre { get; set; }

        public static TipoDocumento[] ObtenerTiposUsuario()
        {
            DatosParticipante listaBD = new DatosParticipante();
            DataTable listaDropDown = listaBD.CargarListaBD(TipoLista.TipoUsuario);

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

        public static TipoDocumento[] ObtenerTiposUsuarionUEVONatural()
        {
            DatosParticipante listaBD = new DatosParticipante();
            DataTable listaDropDown = listaBD.CargarListaBD(TipoLista.tipoUsuarioNuevoNatural);

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

        public static TipoDocumento[] ObtenerTiposUsuarionUEVOJuridico() { 
            DatosParticipante listaBD = new DatosParticipante();
            DataTable listaDropDown = listaBD.CargarListaBD(TipoLista.tipoUsuarioNuevoJuridico);

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

        public static TipoDocumento[] ObtenerTiposUsuarioviejo()
        {
            DatosParticipante listaBD = new DatosParticipante();
            DataTable listaDropDown = listaBD.CargarListaBD(TipoLista.tipoUsuarioViejo);

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


        public static TipoDocumento ObtenerTiposUsuarioCodigo(string codigo)
        {
            DatosParticipante listaBD = new DatosParticipante();
            DataRow datosUsuario = listaBD.BuscarTipoUsuarioCodigo(codigo);
            TipoDocumento nwTipo = new TipoDocumento();

            if (datosUsuario != null)
            {
                nwTipo.Id = datosUsuario["Id"].ToString();
                nwTipo.Nombre = datosUsuario["Nombre"].ToString();
            }
            else
            {
                nwTipo.Id = "-1";
                nwTipo.Nombre = "";
            }
            return nwTipo;
        }

    }
}
