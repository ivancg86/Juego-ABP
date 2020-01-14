using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * Este es el segundo formulario en abrirse, 
 * se instancia por primera vez desde el formulario Menu Principal al pulsar sobre un planeta
 * 
 * FUNCIONAMIENTO:
 *      1. Esta clase (form) recibe por el constructor un planeta [0-8] a través del constructor.
 *      2. Si el planeta recibido por constructor tiene un contenido, es mostrado en el textbox.
 *      3. El planeta recibido contiene un atributo id para distinguirlo a lo largo del programa.
 *      4. Una vez completado el contenido, se añade a este planeta y se pasa por constructor al siguiente formulario.
 *       
 * 
 * El código está ordenado respectivamente por Constantes, Variables, Constructores, Eventos y Métodos
 * 
 * Nota: Existen más métodos en la clase Metodo (Archivo Metodo.cs) que se usan desde varios formularios (Reciclaje de código)
 */
namespace SerializarJSON
{
    public partial class FormGestorContingut : Form
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

        /***
        *     █████╗ ████████╗██████╗ ██╗██████╗ ██╗   ██╗████████╗ ██████╗ ███████╗
        *    ██╔══██╗╚══██╔══╝██╔══██╗██║██╔══██╗██║   ██║╚══██╔══╝██╔═══██╗██╔════╝
        *    ███████║   ██║   ██████╔╝██║██████╔╝██║   ██║   ██║   ██║   ██║███████╗
        *    ██╔══██║   ██║   ██╔══██╗██║██╔══██╗██║   ██║   ██║   ██║   ██║╚════██║
        *    ██║  ██║   ██║   ██║  ██║██║██████╔╝╚██████╔╝   ██║   ╚██████╔╝███████║
        *    ╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚═╝╚═════╝  ╚═════╝    ╚═╝    ╚═════╝ ╚══════╝
        *                                                                           
        */

        // Guarda información de un planeta recibido del menu principal
        Planeta planeta = new Planeta();


        /***
        *     ██████╗ ██████╗ ███╗   ██╗███████╗████████╗██████╗ ██╗   ██╗ ██████╗████████╗ ██████╗ ██████╗ ███████╗███████╗
        *    ██╔════╝██╔═══██╗████╗  ██║██╔════╝╚══██╔══╝██╔══██╗██║   ██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝██╔════╝
        *    ██║     ██║   ██║██╔██╗ ██║███████╗   ██║   ██████╔╝██║   ██║██║        ██║   ██║   ██║██████╔╝█████╗  ███████╗
        *    ██║     ██║   ██║██║╚██╗██║╚════██║   ██║   ██╔══██╗██║   ██║██║        ██║   ██║   ██║██╔══██╗██╔══╝  ╚════██║
        *    ╚██████╗╚██████╔╝██║ ╚████║███████║   ██║   ██║  ██║╚██████╔╝╚██████╗   ██║   ╚██████╔╝██║  ██║███████╗███████║
        *     ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝  ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝
        *                                                                                                                   
        */

        //Recibe un planeta desde menu principal
        public FormGestorContingut(Planeta planeta)
        {            
            InitializeComponent();
            
            // Asigna el planeta recibido por parámetro al planeta de este form
            this.planeta = planeta;

            // Si el planeta recibido tiene un contenido
            if ( Metodo.revisarContenido( planeta.contenido ) )
            {
                // lo muestra en el textbox
                textBoxContenido.Text = planeta.contenido;
            }
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

        // Cierra el formulario y abre FormGestorPreguntes
        private void pictureBoxSiguiente_Click(object sender, EventArgs e)
        {
            // Si el contenido es correcto
            if (Metodo.revisarContenido(textBoxContenido.Text) )
            {
                // Guarda el contenido en este planeta
                this.planeta.contenido = textBoxContenido.Text;

                // Instancia un formulario con el planeta editado
                FormGestorPreguntes gestorPreguntes = new FormGestorPreguntes( this.planeta );

                // Esconde este formulario
                this.Hide();

                // Muestra el formulario
                gestorPreguntes.ShowDialog();

                // Cierra este formulario
                this.Close();
            }
            else
            {
                MessageBox.Show("Introdueix un contingut per continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxContenido.Focus();
            }
            
        }

        // Abre el formulario de ayuda sobre este formulario
        private void pictureBoxAyuda_Click(object sender, EventArgs e)
        {
            FormAjuda formAjuda = new FormAjuda(2);
            formAjuda.Show();
        }

        // Cierra el formulario
        private void pictureBoxCerrar_Click(object sender, EventArgs e)
        {
            // Pregunta si esta seguro que desea cerrar
            var respuesta = MessageBox.Show("Els canvis no es desaran\nSegur que vols sortir?", "Confirmar sortida", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            // Si es así, se cierra el form
            if (respuesta == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormGestorContingut_Load(object sender, EventArgs e)
        {

        }
    }
}
