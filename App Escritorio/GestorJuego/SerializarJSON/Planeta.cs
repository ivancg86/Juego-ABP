using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializarJSON
{
    public class Planeta
    {
        public byte id { get; set; }
        public String contenido { get; set; }
        public List<Pregunta> preguntas { get; set; }
        /// <summary>
        /// 0 == CAT / 1 == ESP / 2 == ENG
        /// </summary>
        //public byte idioma { get; set; }

        public Planeta()
        {

        }

        public Planeta(byte id)
        {
            this.id = id;

        }

        public Planeta(byte id, string contenido, List<Pregunta> preguntas)
        {
            this.id = id;
            this.contenido = contenido;
            this.preguntas = preguntas;
        }
    }
}
