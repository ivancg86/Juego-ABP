using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SerializarJSON
{
    public partial class FormGestorPreguntes : Form
    {
        /***
        *     ██████╗ ██████╗ ███╗   ██╗███████╗████████╗ █████╗ ███╗   ██╗████████╗███████╗███████╗
        *    ██╔════╝██╔═══██╗████╗  ██║██╔════╝╚══██╔══╝██╔══██╗████╗  ██║╚══██╔══╝██╔════╝██╔════╝
        *    ██║     ██║   ██║██╔██╗ ██║███████╗   ██║   ███████║██╔██╗ ██║   ██║   █████╗  ███████╗
        *    ██║     ██║   ██║██║╚██╗██║╚════██║   ██║   ██╔══██║██║╚██╗██║   ██║   ██╔══╝  ╚════██║
        *    ╚██████╗╚██████╔╝██║ ╚████║███████║   ██║   ██║  ██║██║ ╚████║   ██║   ███████╗███████║
        *     ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝
        *                                                                                           
        */

        // Máximo de respuestas por pregunta
        private const byte MAX_RESPUESTAS = 4;

        // Constantes necesarias para mover form
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;


        /***
        *     █████╗ ████████╗██████╗ ██╗██████╗ ██╗   ██╗████████╗ ██████╗ ███████╗
        *    ██╔══██╗╚══██╔══╝██╔══██╗██║██╔══██╗██║   ██║╚══██╔══╝██╔═══██╗██╔════╝
        *    ███████║   ██║   ██████╔╝██║██████╔╝██║   ██║   ██║   ██║   ██║███████╗
        *    ██╔══██║   ██║   ██╔══██╗██║██╔══██╗██║   ██║   ██║   ██║   ██║╚════██║
        *    ██║  ██║   ██║   ██║  ██║██║██████╔╝╚██████╔╝   ██║   ╚██████╔╝███████║
        *    ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═╝╚═════╝  ╚═════╝    ╚═╝    ╚═════╝ ╚══════╝
        *                                                                           
        */

        // Guarda información de un planeta recibido del gestor de contenido
        Planeta planeta = new Planeta();

        // Lista de preguntas
        List<Pregunta> listaPreguntas = new List<Pregunta>();        

        // Guarda el número de respuestas posibles (Incrementa al darle a "Afegir" y decrementa con "Eliminar")
        public byte nRespostes = 2;


        /***
        *     ██████╗ ██████╗ ███╗   ██╗███████╗████████╗██████╗ ██╗   ██╗ ██████╗████████╗ ██████╗ ██████╗ ███████╗███████╗
        *    ██╔════╝██╔═══██╗████╗  ██║██╔════╝╚══██╔══╝██╔══██╗██║   ██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝██╔════╝
        *    ██║     ██║   ██║██╔██╗ ██║███████╗   ██║   ██████╔╝██║   ██║██║        ██║   ██║   ██║██████╔╝█████╗  ███████╗
        *    ██║     ██║   ██║██║╚██╗██║╚════██║   ██║   ██╔══██╗██║   ██║██║        ██║   ██║   ██║██╔══██╗██╔══╝  ╚════██║
        *    ╚██████╗╚██████╔╝██║ ╚████║███████║   ██║   ██║  ██║╚██████╔╝╚██████╗   ██║   ╚██████╔╝██║  ██║███████╗███████║
        *     ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝  ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝
        *                                                                                                                   
        */

        // Constructor del formulario
        public FormGestorPreguntes(Planeta planeta)
        {
            InitializeComponent();
                        
            this.planeta = planeta;

            // Si el planeta recibido ya contiene preguntas, se agregan a la lista
            try
            {
                for (int i = 0; i < planeta.preguntas.Count; i++)
                {
                    // Añade las preguntas a la lista
                    listaPreguntas.Add( planeta.preguntas[i]);

                    // Borra la primera pregunta si viene vacía
                    if ( ! Metodo.revisarContenido( listaPreguntas[0].pregunta ) )
                    {
                        listaPreguntas.RemoveAt(0);
                    }
                    
                }
                
                refrescarListBox();

            }catch (Exception) {} 
            
        }




        /*    EVENTOS
         *    ███████╗██╗   ██╗ ███████╗ ███╗   ██╗████████╗ ██████╗  ███████╗
         *    ██╔════╝██║   ██║ ██╔════╝ ████╗  ██║╚══██╔══╝██╔═══██╗ ██╔════╝
         *    █████╗  ██║   ██║ █████╗   ██╔██╗ ██║   ██║   ██║   ██║ ███████╗
         *    ██╔══╝  ╚██╗ ██╔╝ ██╔══╝   ██║╚██╗██║   ██║   ██║   ██║ ╚════██║
         *    ███████╗ ╚████╔╝  ███████╗ ██║ ╚████║   ██║   ╚██████╔╝ ███████║
         *    ╚══════╝  ╚═══╝   ╚══════╝ ╚═╝  ╚═══╝   ╚═╝    ╚═════╝  ╚══════╝                                                                 
         */

        // Guardar y añadir a la listbox
        private void pictureBoxGuardar_Click(object sender, EventArgs e)
        {
            // Guarda las respuestas de los textbox en una lista para ser verificadas
            List<String> respuestasTextBoxs = new List<string>();
            respuestasTextBoxs.Add(textBoxResposta1.Text);
            respuestasTextBoxs.Add(textBoxResposta2.Text);
            if (nRespostes == 3)
            {
                respuestasTextBoxs.Add(textBoxResposta3.Text);
            }
            else if (nRespostes == 4)
            {
                respuestasTextBoxs.Add(textBoxResposta3.Text);
                respuestasTextBoxs.Add(textBoxResposta4.Text);
            }


            bool formularioCorrecto = false;

            // Comprueba que se haya introducido una pregunta
            if ( Metodo.revisarContenido(textBoxPregunta.Text) )
            {
                // Comprueba que no haya ninguna pregunta repetida
                if ( Metodo.preguntaRepetida(textBoxPregunta.Text, listaPreguntas) )
                {
                    // Comprueba que no falte por marcar algun radioButton
                    if ( radioCheck() )
                    {
                        // Comprueba que se hayan introducido las respuestas
                        if ( Metodo.revisarContenido( respuestasTextBoxs) )
                        {
                            formularioCorrecto = true;
                        }
                        else
                        {
                            //Error
                            MessageBox.Show("Introdueix la resposta que falta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }                    
                }
                else
                {
                    //Error
                    MessageBox.Show("Aquesta pregunta ja existeix", "Pregunta duplicada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPregunta.Focus();
                }
            }
            else
            {
                //Error
                MessageBox.Show("Escriu una pregunta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPregunta.Focus();
            }

            // Si se han pasado todas las comprobaciones
            if ( formularioCorrecto )
            {
                // Lista para guardar 4 respuestas
                List<Respuesta> listaRespuestas = new List<Respuesta>();

                // Vacia la lista de respuestas
                listaRespuestas.Clear();

                // Instancia tantas respuestas como textBoxs haya activado el usuario
                // Después las añade a la lista
                Respuesta a = new Respuesta(textBoxResposta1.Text, radioButtonA.Checked);
                Respuesta b = new Respuesta(textBoxResposta2.Text, radioButtonB.Checked);
                listaRespuestas.Add(a);
                listaRespuestas.Add(b);
                if (nRespostes == 3)
                {
                    Respuesta c = new Respuesta(textBoxResposta3.Text, radioButtonC.Checked);
                    listaRespuestas.Add(c);
                    
                }
                else if (nRespostes == 4)
                {
                    Respuesta c = new Respuesta(textBoxResposta3.Text, radioButtonC.Checked);
                    Respuesta d = new Respuesta(textBoxResposta4.Text, radioButtonD.Checked);
                    listaRespuestas.Add(c);
                    listaRespuestas.Add(d);
                }
                
                // Instancia pregunta y la añade a la lista de preguntas
                Pregunta pregunta = new Pregunta(textBoxPregunta.Text, listaRespuestas, !radioButtonFacil.Checked);
                listaPreguntas.Add(pregunta);

                //Añade al listBox el nuevo contenido
                refrescarListBox();

                //Limpia todos los campos para rellenar de nuevo el formulario
                limpiarCampos();
            }
        }

        // Permite mover la ventana
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }        
        
        // Botón para salir
        private void pictureBoxSortir_Click(object sender, EventArgs e)
        {
            // Pregunta si esta seguro que desea cerrar
            var respuesta = MessageBox.Show("Els canvis no es desaran\nSegur que vols sortir?", 
                "Confirmar sortida", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Si es así, se cierra el form
            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }        

        // Selección de un elemento de la listbox de contenidos
        private void listBoxContenidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Asigna a ContenidoMostrado el contenido seleccionado en la listbox
            // (Contenido): Cast para convertir de object a Pelicula
            Pregunta preguntaSeleccionada = (Pregunta)listBoxPreguntas.SelectedItem;

            // Si el contenido no es nulo
            if (preguntaSeleccionada != null)
            {
                // Limpia el formulario antes
                limpiarCampos();

                // Muestra la pregunta del elemento seleccionado
                textBoxPregunta.Text = preguntaSeleccionada.pregunta;

                // Muestra en los dos primeros textboxs las dos primeras respuestas del elemento seleccionado             
                textBoxResposta1.Text = preguntaSeleccionada.respuestas[0].respuesta;
                textBoxResposta2.Text = preguntaSeleccionada.respuestas[1].respuesta;

                // Si el elemento seleccionado tiene más de dos respuestas
                if ( preguntaSeleccionada.respuestas.Count > 2 )
                {
                    // hay 3 respuestas
                    nRespostes = 3;

                    // metodo: hace visible la respuesta 3
                    respuestaVisible(3, true);

                    // Muestra la tercera respuesta en el textbox del elemento seleccionado
                    textBoxResposta3.Text = preguntaSeleccionada.respuestas[2].respuesta;

                    // Si el elemento seleccionado tiene 4 respuestas
                    if ( preguntaSeleccionada.respuestas.Count == 4 )
                    {
                        // hay 4 respuestas
                        nRespostes = 4;

                        // metodo: hace visible la respuesta 4
                        respuestaVisible(4, true);

                        // Muestra la cuarta respuesta en el textbox del elemento seleccionado
                        textBoxResposta4.Text = preguntaSeleccionada.respuestas[3].respuesta;
                    }
                    // Si el elemento seleccionado no tiene 4 respuestas
                    else
                    {
                        // metodo: hace invisible la respuesta 4
                        respuestaVisible(4, false);
                    }
                }
                // Si el elemento seleccionado no tiene > 2 respuestas
                else
                {
                    // metodo: hace invisibles las respuestas 3 y 4
                    respuestaVisible(3, false);
                    respuestaVisible(4, false);
                }
                


                // Selecciona el radioButton de la respuesta correcta
                if (preguntaSeleccionada.respuestas[0].esCorrecta)
                {
                    radioButtonA.Checked = true;
                }
                else if (preguntaSeleccionada.respuestas[1].esCorrecta)
                {
                    radioButtonB.Checked = true;
                }
                else if (preguntaSeleccionada.respuestas[1].esCorrecta)
                {
                    radioButtonC.Checked = true;
                }
                else 
                {
                    radioButtonD.Checked = true;
                }

                // Selecciona el radioButton con la dificultad de la pregunta
                if ( preguntaSeleccionada.dificultad )
                {
                    radioButtonDificil.Checked = true;
                }
                else
                {
                    radioButtonFacil.Checked = true;
                }
            }

        }

        //Limpia todos los campos para poder añadir una nueva pregunta FALTA PROGRAMAR
        private void pictureBoxNetejar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            //listBoxContenidos.ClearSelected();
            //textBoxPregunta.Focus();
        }

        // Elimina elemento del listbox y de la lista de contenidos FALTA PROGRAMAR
        private void pictureBoxEliminarSel_Click(object sender, EventArgs e)
        {
            // Si hay por lo menos un elemento en la lista
            if (listBoxPreguntas.SelectedItems.Count > 0)
            {
                // Quita de la lista de preguntas la pregunta seleccionada en la listbox
                listaPreguntas.RemoveAt(listBoxPreguntas.SelectedIndex);

                // Vuelve a cargar la listbox
                refrescarListBox();
            }
        }

        // Minimizar formulario
        private void pictureBoxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Afegir textbox resposta
        private void pictureBoxAfegir_Click(object sender, EventArgs e)
        {
            // Si la respuesta 3 NO es visible
            if (!textBoxResposta3.Visible)
            {
                // metodo: hace visible la respuesta tres
                respuestaVisible(3, true);

                // incrementa el numero de respuestas
                nRespostes++;
            }
            // Si la respuesta 4 no es visible y la 3 sí
            else if (!textBoxResposta4.Visible && textBoxResposta3.Visible)
            {
                // metodo: hace visible la respuesta 4
                respuestaVisible(4, true);
                // incrementa el numero de respuestas
                nRespostes++;
            }
        }

        // Eliminar textbox reposta
        private void pictureBoxEliminar_Click(object sender, EventArgs e)
        {
            // Si la respuesta 4 es visible
            if (textBoxResposta4.Visible)
            {
                // metodo: Hace invisible la respuesta 4
                respuestaVisible(4, false);

                // Limpia el campo
                textBoxResposta4.Clear();

                // Deselecciona el radio button D
                radioButtonD.Checked = false;

                // Decrementa el numero de respuestas
                nRespostes--;
            }
            // Si la respuesta 3 es visible 
            else if (textBoxResposta3.Visible)
            {
                // metodo: Hace invisible la respuesta 3
                respuestaVisible(3, false);

                // Limpia la respuesta 3
                textBoxResposta3.Clear();
                
                // Desmarca el radio button C
                radioButtonC.Checked = false;

                //Decrementa el numero de respuestas
                nRespostes--;
            }
        }

        // Abre ventana de ayuda
        private void pictureBoxAjuda_Click(object sender, EventArgs e)
        {
            FormAjuda ajuda = new FormAjuda(0);
            ajuda.Show();
        }

        // Botón Continuar
        private void pictureBoxContinuar_Click(object sender, EventArgs e)
        {
            // Si hay alguna pregunta
            if (listaPreguntas.Count > 0)
            {
                // Instancia un planeta nuevo                
                Planeta planetaNuevo = new Planeta(this.planeta.id, this.planeta.contenido, listaPreguntas);

                FormMenuPrincipal.planetas[this.planeta.id] = planetaNuevo;

                this.Close();
            }
            else
            {
                //Error
                MessageBox.Show("No hi han dades per guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        


        /*    METODOS
         *    ███╗   ███╗ ███████╗████████╗ ██████╗  ██████╗    ██████╗  ███████╗
         *    ████╗ ████║ ██╔════╝╚══██╔══╝██╔═══██╗ ██╔══██╗  ██╔═══██╗ ██╔════╝
         *    ██╔████╔██║ █████╗     ██║   ██║   ██║ ██║   ██║ ██║   ██║ ███████╗
         *    ██║╚██╔╝██║ ██╔══╝     ██║   ██║   ██║ ██║  ██║  ██║   ██║ ╚════██║
         *    ██║ ╚═╝ ██║ ███████╗   ██║   ╚██████╔╝ ██████╔╝  ╚██████╔╝ ███████║
         *    ╚═╝     ╚═╝ ╚══════╝   ╚═╝    ╚═════╝  ╚═════╝    ╚═════╝  ╚══════╝                                                                
         */

        /// <summary>
        /// Limpia textbox pregunta/respuestas y desmarca todos los radioButtons.
        /// </summary>
        private void limpiarCampos()
        {
            textBoxPregunta.Clear();
            textBoxResposta1.Clear();
            textBoxResposta2.Clear();
            textBoxResposta3.Clear();
            textBoxResposta4.Clear();

            radioButtonA.Checked = false;
            radioButtonB.Checked = false;
            radioButtonC.Checked = false;
            radioButtonD.Checked = false;

            radioButtonDificil.Checked = false;
            radioButtonFacil.Checked = false;

            // Vuelve a 2 respuestas
            nRespostes = 2;

            // Oculta los dos ultimos campos
            respuestaVisible(3, false);
            respuestaVisible(4, false);
        }

        /// <summary>
        /// Retorna FALSE si falta por marcar un radioButton
        /// </summary>
        /// <returns></returns>
        private bool radioCheck()
        {            
            bool retorno = false;

            //Resposta correcte seleccionada? 
            if ( radioButtonA.Checked || radioButtonB.Checked || radioButtonC.Checked || radioButtonD.Checked )
            {
                //Dificultat seleccionada?
                if ( radioButtonFacil.Checked || radioButtonDificil.Checked )
                {
                    retorno = true;
                }
                else
                {
                    //Error
                    MessageBox.Show("Indica la dificultat de la pregunta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    panelRespostaCorrecte.Focus();
                }
            }
            else
            {
                //Error
                MessageBox.Show("Indica una resposta correcte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                panelRespostaCorrecte.Focus();
            }   

            return retorno;
        }

        //Refrescar la listboxPreguntas
        private void refrescarListBox()
        {
            listBoxPreguntas.DataSource = null;
            listBoxPreguntas.DataSource = listaPreguntas;
            listBoxPreguntas.DisplayMember = "pregunta";
        }

        // Vuelve atrás al gestor de contenido                                                 
        private void pictureBoxGestContingut_Click(object sender, EventArgs e)
        {
            // Pregunta si esta seguro que desea cerrar
            var respuesta = MessageBox.Show("Els canvis no es desaran\nSegur que vols sortir?",
                "Confirmar sortida", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Si es así, se cierra el form
            if (respuesta == DialogResult.Yes)
            {
                FormGestorContingut gestorContingut = new FormGestorContingut(planeta);
                gestorContingut.ShowDialog();
                this.Close();
            }
            
        }

        /// <summary>
        /// Indica el número de la respuesta en el primer parámetro.
        /// Indica TRUE/FALSE en el segundo parametro para hacer visible u ocultar
        /// </summary>
        /// <param name="numRespuesta"></param>
        /// <param name="visible"></param>
        private void respuestaVisible (byte numRespuesta, bool visible)
        {
            if (numRespuesta == 3 && visible)
            {
                // Hace visible la respuesta 3
                textBoxResposta3.Visible = true;
                radioButtonC.Visible = true;
                labelC.Visible = true;
            }
            else if (numRespuesta == 3 && !visible)
            {
                // Oculta la respuesta 3
                textBoxResposta3.Visible = false;
                radioButtonC.Visible = false;
                labelC.Visible = false;
            }

            if (numRespuesta == 4 && visible)
            {
                // Hace visible la respuesta 4
                textBoxResposta4.Visible = true;
                radioButtonD.Visible = true;
                labelD.Visible = true;
            }
            else if (numRespuesta == 4 && !visible)
            {
                // Oculta la respuesta 4
                textBoxResposta4.Visible = false;
                radioButtonD.Visible = false;
                labelD.Visible = false;
            }

        }
    }
}
