using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializarJSON
{
    public class Pregunta
    {
        public String pregunta { get; set; }
        public List<Respuesta> respuestas{ get; set; }
        public bool dificultad { get; set; }

        public Pregunta ()
        {

        }

        public Pregunta(string pregunta, List<Respuesta> respuestas, bool dificultad)
        {
            this.pregunta = pregunta;
            this.respuestas = respuestas;
            this.dificultad = dificultad;
        }

        public Pregunta(string pregunta)
        {
            this.pregunta = pregunta;
        }
    }
}
