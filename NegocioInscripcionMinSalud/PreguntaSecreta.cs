using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DatosInscripcionMinSalud;

namespace NegocioInscripcionMinSalud
{
    public class PreguntaSecreta
    {
        public int Id { get; set; }
        public string TextoPregunta { get; set; }

        public static PreguntaSecreta[] ObtenerPregunta()
        {
            DatosParticipante listaBD = new DatosParticipante();
            DataTable listaDropDown = listaBD.CargarListaBD(TipoLista.Pregunta);           

            List<PreguntaSecreta> preguntaSecreta = new List<PreguntaSecreta>();
            foreach (DataRow rw in listaDropDown.Rows)
            {
                PreguntaSecreta nwPregunta = new PreguntaSecreta();
                nwPregunta.Id = int.Parse(rw["Id"].ToString());
                nwPregunta.TextoPregunta = rw["TextoPregunta"].ToString();

                preguntaSecreta.Add(nwPregunta);
            }

            return preguntaSecreta.ToArray();
        }
    }
}
