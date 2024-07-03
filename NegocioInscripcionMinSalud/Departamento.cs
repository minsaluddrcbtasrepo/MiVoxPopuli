using DatosInscripcionMinSalud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioInscripcionMinSalud
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static Departamento[] ObtenerDepartamento()
        {
            DatosParticipante listaBD = new DatosParticipante();
            DataTable listaDropDown = listaBD.CargarListaBD(TipoLista.Departamento);

            List<Departamento> departamento = new List<Departamento>();
            foreach (DataRow rw in listaDropDown.Rows)
            {
                Departamento nwDepto = new Departamento();
                nwDepto.Id = int.Parse(rw["Id"].ToString());
                nwDepto.Nombre = rw["Nombre"].ToString();

                departamento.Add(nwDepto);
            }

            return departamento.ToArray();
        }
        
    }
}
