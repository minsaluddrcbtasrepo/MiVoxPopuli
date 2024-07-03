using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosInscripcionMinSalud;

namespace NegocioInscripcionMinSalud
{
    public class Administrador
    {
        public static int ObtenerMayorRango()
        {            
            DatosParticipante consulta = new DatosParticipante();
            return consulta.ObtenerMayorRango();            

        }
    }
}
