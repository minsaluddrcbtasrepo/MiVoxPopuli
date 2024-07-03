using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DatosInscripcionMinSalud;

namespace NegocioInscripcionMinSalud
{
    public class Municipio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static Municipio[] ObtenerMunicipio(Int16 idDepartamento)
        {
            DatosParticipante listaBD = new DatosParticipante();
            DataTable listaDropDown = listaBD.CargarListaBD(TipoLista.Municipio, idDepartamento.ToString());
            DataSet ds = new DataSet();
            ds.Tables.Add(listaDropDown);

            List<Municipio> municipio = new List<Municipio>();
            foreach (DataRow rw in listaDropDown.Rows)
            {
                Municipio nwMunicipio = new Municipio();
                nwMunicipio.Id = int.Parse(rw["id"].ToString());
                nwMunicipio.Nombre = rw["nombre"].ToString();

                municipio.Add(nwMunicipio);
            }

            return municipio.ToArray();

        }

    }
}
