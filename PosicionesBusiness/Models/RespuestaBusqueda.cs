using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosicionesNegocio.Models
{
    public class RespuestaBusqueda
    {
        public List<int[]> Resultados { get; set; }
        public string Errores { get; set; }

        public RespuestaBusqueda() {
            this.Resultados = new List<int[]>();
            this.Errores = string.Empty;
        }

    }
}
