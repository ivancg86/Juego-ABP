using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializarJSON
{
    public class Respuesta
    {
        public String respuesta { get; set; }
        public bool esCorrecta { get; set; }

        public Respuesta()
        {

        }

        public Respuesta(string respuesta, bool esCorrecta)
        {
            this.respuesta = respuesta;
            this.esCorrecta = esCorrecta;
        }
    }
}
