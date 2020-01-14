using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

/*
 * Este es el primer formulario en abrirse, se instancia por primera vez desde la clase Program.cs por defecto
 * 
 * FUNCIONAMIENTO:
 *          1. Al abrirse el formulario por primera vez, se instancian 9 planetas con su id correspondiente y 9 personajes
 *          2. Segun el idioma seleccionado y el planeta pulsado, se pasa al constructor del gestor de contenido un planeta u otro
 *             Al hacer click en personajes se pasa por constructor 1, 2 o 3 para saber de qué idioma son esos personajes
 * 
 * El código está ordenado respectivamente por Constantes, Atributos, Constructores, Eventos y Métodos.
 *      Nota: Existen más métodos en la clase Metodo (Archivo Metodo.cs) que se usan desde varios formularios (Reciclaje de código)
 */
namespace SerializarJSON
{    
    public partial class FormMenuPrincipal : Form
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

        //Constantes necesarias para mover form
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        // Constante max planetas totales
        private const byte MAX_PLANETAS = 9;

        // Constante maximo de personajes
        private const byte MAX_PERSONAJES = 9;

        // Constantes que hacen referencia al planeta pulsado
        private const byte PLANETA1 = 0;
        private const byte PLANETA2 = 1;
        private const byte PLANETA3 = 2;


        /***
        *     █████╗ ████████╗██████╗ ██╗██████╗ ██╗   ██╗████████╗ ██████╗ ███████╗
        *    ██╔══██╗╚══██╔══╝██╔══██╗██║██╔══██╗██║   ██║╚══██╔══╝██╔═══██╗██╔════╝
        *    ███████║   ██║   ██████╔╝██║██████╔╝██║   ██║   ██║   ██║   ██║███████╗
        *    ██╔══██║   ██║   ██╔══██╗██║██╔══██╗██║   ██║   ██║   ██║   ██║╚════██║
        *    ██║  ██║   ██║   ██║  ██║██║██████╔╝╚██████╔╝   ██║   ╚██████╔╝███████║
        *    ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═╝╚═════╝  ╚═════╝    ╚═╝    ╚═════╝ ╚══════╝
        *                                                                           
        */

        // Lista estatica de planetas
        public static List<Planeta> planetas = new List<Planeta>();

        // Lista estatic de personajes
        public static List<Personaje> listaPersonajes = new List<Personaje>();

        

        /***
        *     ██████╗ ██████╗ ███╗   ██╗███████╗████████╗██████╗ ██╗   ██╗ ██████╗████████╗ ██████╗ ██████╗ ███████╗███████╗
        *    ██╔════╝██╔═══██╗████╗  ██║██╔════╝╚══██╔══╝██╔══██╗██║   ██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝██╔════╝
        *    ██║     ██║   ██║██╔██╗ ██║███████╗   ██║   ██████╔╝██║   ██║██║        ██║   ██║   ██║██████╔╝█████╗  ███████╗
        *    ██║     ██║   ██║██║╚██╗██║╚════██║   ██║   ██╔══██╗██║   ██║██║        ██║   ██║   ██║██╔══██╗██╔══╝  ╚════██║
        *    ╚██████╗╚██████╔╝██║ ╚████║███████║   ██║   ██║  ██║╚██████╔╝╚██████╗   ██║   ╚██████╔╝██║  ██║███████╗███████║
        *     ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝  ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝
        *                                                                                                                   
        */

        // Constructor
        public FormMenuPrincipal()
        {
            InitializeComponent();                                 

            // Crea 9 planetas con su id correspondiente [0-8]
            crearPlanetas();
            // Crea 9 personajes vacíos
            crearPersonajes();
        }



        /*    EVENTOS
         *    ███████╗██╗   ██╗ ███████╗ ███╗   ██╗████████╗ ██████╗  ███████╗
         *    ██╔════╝██║   ██║ ██╔════╝ ████╗  ██║╚══██╔══╝██╔═══██╗ ██╔════╝
         *    █████╗  ██║   ██║ █████╗   ██╔██╗ ██║   ██║   ██║   ██║ ███████╗
         *    ██╔══╝  ╚██╗ ██╔╝ ██╔══╝   ██║╚██╗██║   ██║   ██║   ██║ ╚════██║
         *    ███████╗ ╚████╔╝  ███████╗ ██║ ╚████║   ██║   ╚██████╔╝ ███████║
         *    ╚══════╝  ╚═══╝   ╚══════╝ ╚═╝  ╚═══╝   ╚═╝    ╚═════╝  ╚══════╝                                                                 
         */

        
        // Permite mover la ventana
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        // Cerrar formulario
        private void pictureBoxSortir_Click(object sender, EventArgs e)
        {
            // Pregunta si esta seguro que desea cerrar
            var respuesta = MessageBox.Show("Els canvis no es desaran\nSegur que vols sortir?", "Confirmar sortida", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Si es así, se cierra el form
            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Minimizar formulario
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Abre ventana de ayuda
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormAjuda ajuda = new FormAjuda(3);
            ajuda.Show();
        }

        // Botón exportar
        private void pictureBoxExportar_Click(object sender, EventArgs e)
        {
            try
            {
                //Metodo: Commprueba personajes y planetas
                if (ContenidoExistente())
                {
                //Metodo: Guarda ficheros
                    GuardarTodo();
        }
                else //Error
                {
                    MessageBox.Show(
                    "Falten personatges o planetes per omplir",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
}
            catch (Exception)
            {
                MessageBox.Show(
                    "No s'han pogut generar els fitxers",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cuando un idioma es seleccionado
        private void comboBoxIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Colorea los planetas si tienen alguna pregunta dentro, sino los descolorea
            // Hace aparecer la bandera correspondiente al idioma seleccionado            
            colorPlanetas(comboBoxIdioma.SelectedIndex);
        }

        // Click Planeta 1
        private void pictureBoxPlaneta1_Click(object sender, EventArgs e)
        {
            abrirGestorContenido(PLANETA1);            
        }

        // Click Planeta 2
        private void pictureBoxPlaneta2_Click(object sender, EventArgs e)
        {
            abrirGestorContenido(PLANETA2);            
        }

        // Click Planeta 3
        private void pictureBoxPlaneta3_Click(object sender, EventArgs e)
        {
            abrirGestorContenido(PLANETA3);            
        }

        //Obrir gestor de personatges
        private void pictureBoxGestorPersonatges_Click(object sender, EventArgs e)
        {
            switch (comboBoxIdioma.SelectedIndex)
            {
                //idioma català
                case 0:

                    FormGestorPersonatges formGestorPersonatges0 = new FormGestorPersonatges(listaPersonajes, 0);
                    this.Hide();
                    formGestorPersonatges0.ShowDialog();
                    this.Show();
                    break;

                //idioma castellà
                case 1:
                    FormGestorPersonatges formGestorPersonatges1 = new FormGestorPersonatges(listaPersonajes, 1);
                    this.Hide();
                    formGestorPersonatges1.ShowDialog();
                    this.Show();
                    break;

                //idioma anglès
                case 2:

                    FormGestorPersonatges formGestorPersonatges2 = new FormGestorPersonatges(listaPersonajes, 2);
                    this.Hide();
                    formGestorPersonatges2.ShowDialog();
                    this.Show();
                    break;

                default:
                    MessageBox.Show("Selecciona un idioma primer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            
        }
        
        // Botón importar
        private void pictureBoxImportar_Click(object sender, EventArgs e)
        {
            try
            {
                importar();
                colorPlanetas(0);
                colorPlanetas(1);
                colorPlanetas(2);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "No s'han pogut importar els fitxers",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void crearPersonajes()
        {
            
            for (int i = 0; i < MAX_PERSONAJES; i++)
            {
                Personaje personaje = new Personaje();
                listaPersonajes.Add(personaje);
            }
            
        }

        /// <summary>        
        /// Pasa el planeta correspondiente al formulario gestor de contenido por su constructor.
        /// Finalmente reemplaza la imagen del planeta.
        /// </summary>
        /// <param name="numPlaneta"></param>
        private void abrirGestorContenido(byte numPlaneta)
        {
            // Si el idioma es Catalan
            if (comboBoxIdioma.SelectedIndex == 0)
            {
                this.Hide();
                switch (numPlaneta)
                {
                    case 0:
                        FormGestorContingut gestorContingut1 = new FormGestorContingut(planetas[0]);
                        gestorContingut1.ShowDialog();
                        break;

                    case 1:
                        FormGestorContingut gestorContingut2 = new FormGestorContingut(planetas[1]);
                        gestorContingut2.ShowDialog();
                        break;

                    case 2:
                        FormGestorContingut gestorContingut3 = new FormGestorContingut(planetas[2]);
                        gestorContingut3.ShowDialog();
                        break;
                }
                this.Show();
            }
            // Si el idioma es Español
            else if (comboBoxIdioma.SelectedIndex == 1)
            {
                this.Hide();
                switch (numPlaneta)
                {
                    case 0:
                        FormGestorContingut gestorContingut1 = new FormGestorContingut(planetas[3]);
                        gestorContingut1.ShowDialog();
                        break;

                    case 1:
                        FormGestorContingut gestorContingut2 = new FormGestorContingut(planetas[4]);
                        gestorContingut2.ShowDialog();
                        break;

                    case 2:
                        FormGestorContingut gestorContingut3 = new FormGestorContingut(planetas[5]);
                        gestorContingut3.ShowDialog();
                        break;
                }
                this.Show();
            }
            // Si el idioma es Ingles
            else if (comboBoxIdioma.SelectedIndex == 2)
            {
                this.Hide();
                switch (numPlaneta)
                {
                    case 0:
                        FormGestorContingut gestorContingut1 = new FormGestorContingut(planetas[6]);
                        gestorContingut1.ShowDialog();
                        break;

                    case 1:
                        FormGestorContingut gestorContingut2 = new FormGestorContingut(planetas[7]);
                        gestorContingut2.ShowDialog();
                        break;

                    case 2:
                        FormGestorContingut gestorContingut3 = new FormGestorContingut(planetas[8]);
                        gestorContingut3.ShowDialog();
                        break;
                }
                this.Show();
            }
            // Si ningún idioma es selccionado y se pulsa sobre un planeta
            else
            {
                MessageBox.Show("Selecciona un idioma primer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Cambia el color de los planetas si tienen > 0 preguntas
            colorPlanetas(comboBoxIdioma.SelectedIndex);
        }        

        /// <summary>
        /// Instancia 9 planetas con su atributo id y una lista de 1 pregunta vacia en la priemera posicion
        /// Los añade en la lista estatica "planetas"
        /// 
        /// Los 3 primeros planetas son idioma Catalan [0 - 1 - 2]
        /// Los 3 siguientes son Español [3 - 4 - 5]
        /// Los 3 últimos English [6 - 7 - 8]
        /// </summary>
        private void crearPlanetas()
        {
            for (byte i = 0; i < MAX_PLANETAS; i++)
            {
                // Instancia una pregunta con id 0 y string vacío
                Pregunta preguntaVacia = new Pregunta("");
                
                // Instancia una lista de preguntas vacias 
                List<Pregunta> preguntasVacias = new List<Pregunta>();

                // Añade la pregunta vacía a la lista
                preguntasVacias.Add(preguntaVacia);

                // Crea un planeta con el id = i
                Planeta planetaVacio = new Planeta( i );

                // La lista de preguntas del planeta será la lista de preguntas vacías
                planetaVacio.preguntas = preguntasVacias;

                // Añade el planeta con su id y una pregunta vacía la lista estatica de planetas
                planetas.Add(planetaVacio);
            }
        }

        /// <summary>
        /// Hace dos cosas:
        ///     Da color a aquellos planetas que contengan almenos 1 pregunta
        ///     Al cambiar de idioma cambia la imagen de la bandera correspondiente
        /// </summary>
        /// <param name="idioma"></param> 
        private void colorPlanetas(int idioma)
        {
            switch (idioma)
            {
                case 0:
                    // Cambia la imagen y hace el control visible
                    pictureBoxBandera.Image = SerializarJSON.Properties.Resources.cat;
                    pictureBoxBandera.Visible = true;

                    if (planetas[0].preguntas.Count > 0 && Metodo.revisarContenido(planetas[0].preguntas[0].pregunta) )
                    {
                        // Cambia el planeta a color
                        pictureBoxPlaneta1.Image = SerializarJSON.Properties.Resources.Planeta1true;
                    }
                    else
                    {
                        // Quita el color del planeta
                        pictureBoxPlaneta1.Image = SerializarJSON.Properties.Resources.Planeta1false;
                    }
                    if (planetas[1].preguntas.Count > 0 && Metodo.revisarContenido(planetas[1].preguntas[0].pregunta))
                    {
                        // Cambia el planeta a color
                        pictureBoxPlaneta2.Image = SerializarJSON.Properties.Resources.planeta2true;
                    }
                    else
                    {
                        // Quita el color del planeta
                        pictureBoxPlaneta2.Image = SerializarJSON.Properties.Resources.planeta2false;
                    }
                    if (planetas[2].preguntas.Count > 0 && Metodo.revisarContenido(planetas[2].preguntas[0].pregunta))
                    {
                        // Cambia el planeta a color
                        pictureBoxPlaneta3.Image = SerializarJSON.Properties.Resources.planeta3true;
                    }
                    else
                    {
                        // Quita el color del planeta
                        pictureBoxPlaneta3.Image = SerializarJSON.Properties.Resources.planeta3false;
                    }

                    break;

                case 1:
                    // Cambia la imagen y hace el control visible
                    pictureBoxBandera.Image = SerializarJSON.Properties.Resources.esp;
                    pictureBoxBandera.Visible = true;
                    if (planetas[3].preguntas.Count > 0 && Metodo.revisarContenido(planetas[3].preguntas[0].pregunta))
                    {
                        // Cambia el planeta a color
                        pictureBoxPlaneta1.Image = SerializarJSON.Properties.Resources.Planeta1true;
                    }
                    else
                    {
                        // Quita el color del planeta
                        pictureBoxPlaneta1.Image = SerializarJSON.Properties.Resources.Planeta1false;
                    }
                    if (planetas[4].preguntas.Count > 0 && Metodo.revisarContenido(planetas[4].preguntas[0].pregunta))
                    {
                        // Cambia el planeta a color
                        pictureBoxPlaneta2.Image = SerializarJSON.Properties.Resources.planeta2true;
                    }
                    else
                    {
                        // Quita el color del planeta
                        pictureBoxPlaneta2.Image = SerializarJSON.Properties.Resources.planeta2false;
                    }
                    if (planetas[5].preguntas.Count > 0 && Metodo.revisarContenido(planetas[5].preguntas[0].pregunta))
                    {
                        // Cambia el planeta a color
                        pictureBoxPlaneta3.Image = SerializarJSON.Properties.Resources.planeta3true;
                    }
                    else
                    {
                        // Quita el color del planeta
                        pictureBoxPlaneta3.Image = SerializarJSON.Properties.Resources.planeta3false;
                    }
                    break;

                case 2:
                    // Cambia la imagen y hace el control visible
                    pictureBoxBandera.Image = SerializarJSON.Properties.Resources.eng;
                    pictureBoxBandera.Visible = true;

                    if (planetas[6].preguntas.Count > 0 && Metodo.revisarContenido(planetas[6].preguntas[0].pregunta))
                    {
                        // Cambia el planeta a color
                        pictureBoxPlaneta1.Image = SerializarJSON.Properties.Resources.Planeta1true;
                    }
                    else
                    {
                        // Quita el color del planeta
                        pictureBoxPlaneta1.Image = SerializarJSON.Properties.Resources.Planeta1false;
                    }
                    if (planetas[7].preguntas.Count > 0 && Metodo.revisarContenido(planetas[7].preguntas[0].pregunta))
                    {
                        // Cambia el planeta a color
                        pictureBoxPlaneta2.Image = SerializarJSON.Properties.Resources.planeta2true;
                    }
                    else
                    {
                        // Quita el color del planeta
                        pictureBoxPlaneta2.Image = SerializarJSON.Properties.Resources.planeta2false;
                    }
                    if (planetas[8].preguntas.Count > 0 && Metodo.revisarContenido(planetas[8].preguntas[0].pregunta))
                    {
                        // Cambia el planeta a color
                        pictureBoxPlaneta3.Image = SerializarJSON.Properties.Resources.planeta3true;
                    }
                    else
                    {
                        // Quita el color del planeta
                        pictureBoxPlaneta3.Image = SerializarJSON.Properties.Resources.planeta3false;
                    }
                    break;
            }
        }

        /// <summary>
        /// Guarda todo ordenado por directorios y pregunta al usuario si desea abrirlo
        /// en caso de error muestra un mensaje
        /// </summary>
        private void GuardarTodo()
        {
            // Instancia objeto de la clase FolderBroseDialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            // Descripción del cuadro de dialogo
            fbd.Description = "Selecciona un directori on guardar els fitxers";
            
            // Guarda la ruta seleccionada por el usuario
            String ruta = "";

            // Cuando el usuario pulse ok
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                // Ruta sera la ruta seleccionada
                ruta = fbd.SelectedPath;
            

                // Crea los directorios y subdirectorios
                Directory.CreateDirectory(ruta + @"\contingut del joc\planetas");
                Directory.CreateDirectory(ruta + @"\Contingut del Joc\personatges\imatges");

                // Serializa a JSON la lista de planetas 
                // guarda en el directorio "contingut del joc\planetas\planetas"
                File.WriteAllText(ruta + @"\contingut del joc\planetas\planetas.JSON",
                    Newtonsoft.Json.JsonConvert.SerializeObject(planetas));

                // Serializa a JSON la lista de personajes
                // guarda en el directorio "contingut del joc\personajes"
                File.WriteAllText(ruta + @"\contingut del joc\personatges\personatges.JSON",
                    Newtonsoft.Json.JsonConvert.SerializeObject(listaPersonajes));


                // Copia las imagenes a la carpeta de imagenes y las renombra
                System.IO.File.Copy(Personaje.rutaImagen1,
                        ruta + @"\Contingut del Joc\personatges\imatges\imagen1.png", true);
                System.IO.File.Copy(Personaje.rutaImagen2,
                        ruta + @"\Contingut del Joc\personatges\imatges\imagen2.png", true);
                System.IO.File.Copy(Personaje.rutaImagen3,
                        ruta + @"\Contingut del Joc\personatges\imatges\imagen3.png", true);


                // Pregunta si esta seguro que desea cerrar
                var respuesta = MessageBox.Show(
                    "Arxius generats correctament\nVols anar al directori? ",
                    "Fet",
                    MessageBoxButtons.YesNo, MessageBoxIcon.None);

                // Si es así, abre la carpeta que contiene los archivos
                if (respuesta == DialogResult.Yes)
                {
                    // Objtiene el directorio actual
                    String directorio = Directory.GetCurrentDirectory();

                    Process.Start(fbd.SelectedPath);
                }

            }
        }

        /// <summary>
        /// Devuelve true si todos los planetas y personajes tienen un contenido valido
        /// </summary>
        /// <returns></returns>
        private bool ContenidoExistente()
        {
            // Guarda el resultado de la revision
            bool planetasOk = false, personajesOK = false, retorno = false;
            // recorren bucles
            byte i = 0, j = 0;


            // Recorre planetas
            while (i < MAX_PLANETAS)
            {

                // Si algun planeta no tiene un contenido valido
                if ( !Metodo.revisarContenido(planetas[i].contenido) )
                {
                    // La variable se niega y sale del bucle
                    planetasOk = false;
                    i = MAX_PLANETAS;
                }
                else
                {
                    planetasOk = true;
                }                
                
                i++;
            }

            // Recorre personajes
            while (j < MAX_PERSONAJES)
            {
                if (! ( Metodo.revisarContenido(listaPersonajes[j].nom) 
                     && Metodo.revisarContenido(listaPersonajes[j].frase) 
                     && Metodo.revisarContenido(Personaje.rutaImagen1)
                     && Metodo.revisarContenido(Personaje.rutaImagen2)
                     && Metodo.revisarContenido(Personaje.rutaImagen3) ) )
                {
                    // La variable se niega y sale del bucle
                    personajesOK = false;
                    i = MAX_PLANETAS;
                }
                else
                {
                    personajesOK = true;
                }
                
                j++;
            }

            // si las dos comprobaciones anteriores han ido bien
            if (planetasOk && personajesOK)
            {
                // El retorno sera true
                retorno = true;
            }

            // Retorna el retorno
            return retorno;
        }

        /// <summary>
        /// Método para importar todo
        /// </summary>
        private void importar()
        {
            // Instancia un objeto de la clase FolderBrowserDialog
            FolderBrowserDialog abrirCarpetaExp = new FolderBrowserDialog();

            /*
             * Opciones del dialogo:
             *      Descripción, Ruta inicial mostrada y botón nueva carpeta deshabilitado.
             */
            abrirCarpetaExp.Description = "Selecciona la carpeta \"contingut del joc\" i fes click en \"Acceptar\"";
            abrirCarpetaExp.RootFolder = System.Environment.SpecialFolder.MyComputer;
            abrirCarpetaExp.ShowNewFolderButton = false;

            // Da instrucciones previas al usuario
            MessageBox.Show(
                    "Selecciona la carpeta \"contingut del joc\" i fes click en \"Acceptar\"",
                    "Instruccions",
                    MessageBoxButtons.OK);

            // Cuando el usuario pulse ok
            if (abrirCarpetaExp.ShowDialog() == DialogResult.OK)
            {
                // Deserializa e importa los personajes
                JArray jArrayPersonajes = JArray.Parse(File.ReadAllText(abrirCarpetaExp.SelectedPath + @"\personatges\personatges.JSON"));                
                listaPersonajes = jArrayPersonajes.ToObject<List<Personaje>>();

                // Deserializa e importa planetas
                JArray jArrayPlanetas = JArray.Parse(File.ReadAllText(abrirCarpetaExp.SelectedPath + @"\planetas\planetas.JSON"));
                planetas = jArrayPlanetas.ToObject<List<Planeta>>();

                //Importar imagenees
                Personaje.rutaImagen1 = (abrirCarpetaExp.SelectedPath + @"\personatges\imatges\imagen1.png");
                Personaje.rutaImagen2 = (abrirCarpetaExp.SelectedPath + @"\personatges\imatges\imagen2.png");
                Personaje.rutaImagen3 = (abrirCarpetaExp.SelectedPath + @"\personatges\imatges\imagen3.png");

                // Mensaje importacion correcta
                MessageBox.Show(
                        "Importació correcta",
                        "Fet",
                        MessageBoxButtons.OK);

            }
        }
    }
}
