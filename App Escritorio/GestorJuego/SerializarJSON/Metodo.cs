using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *  Clase donde se guardarán todos los métodos de manera STATIC.
 *  Acceder desde cualquier Form de la siguiente manera: 
 *      Metodo.metodo()
 */
namespace SerializarJSON
{
    public class Metodo
    {
        /// <summary>
        /// Comprueba que ninguna cadena sea nulo o tenga solo espacios.
        /// Devuelve FALSE si alguna cadena es NULL o contiene espacios únicamente.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static bool revisarContenido(String cadena)
        {
            bool retorno = true;

            if (string.IsNullOrWhiteSpace(cadena))
            {
                retorno = false;
            }
            return retorno;
        }
        
        public static bool revisarContenido(List<String> respuestas)
        {
            bool retorno = true;
            int i = 0;

            while (i < respuestas.Count)
            {
                //Si el metodo devuelve false en algún momento
                if (! revisarContenido( respuestas[i] ) )
                {
                   retorno = false;
                   i = respuestas.Count;
                }
                i++;
            }

            return retorno;
        }

        public static bool preguntaRepetida(String pregunta, List<Pregunta> preguntas)
        {
            bool retorno = true;
            int i = 0;

            while (i < preguntas.Count)
            {
                if (pregunta == preguntas[i].pregunta)
                {
                    retorno = false;
                }
                i++;
            }
            return retorno;
        }


    }
}
