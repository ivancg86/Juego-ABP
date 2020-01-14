using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerializarJSON
{
    public partial class FormGestorPersonatges : Form
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

        // Lista para los 9 personajes
        List<Personaje> listaPersonajes = new List<Personaje>();
        int idIdioma;


        /***
        *     ██████╗ ██████╗ ███╗   ██╗███████╗████████╗██████╗ ██╗   ██╗ ██████╗████████╗ ██████╗ ██████╗ ███████╗███████╗
        *    ██╔════╝██╔═══██╗████╗  ██║██╔════╝╚══██╔══╝██╔══██╗██║   ██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗██╔════╝██╔════╝
        *    ██║     ██║   ██║██╔██╗ ██║███████╗   ██║   ██████╔╝██║   ██║██║        ██║   ██║   ██║██████╔╝█████╗  ███████╗
        *    ██║     ██║   ██║██║╚██╗██║╚════██║   ██║   ██╔══██╗██║   ██║██║        ██║   ██║   ██║██╔══██╗██╔══╝  ╚════██║
        *    ╚██████╗╚██████╔╝██║ ╚████║███████║   ██║   ██║  ██║╚██████╔╝╚██████╗   ██║   ╚██████╔╝██║  ██║███████╗███████║
        *     ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝  ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚══════╝╚══════╝
        *                                                                                                                   
        */

        //inicializar componentes
        public FormGestorPersonatges(List<Personaje> listaPersonajes, int idIdioma)
        {
            InitializeComponent();
            inicializarPersonajes();
            this.listaPersonajes = listaPersonajes;
            this.idIdioma = idIdioma;

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

        private void FormGestorPersonatges_Load(object sender, EventArgs e)
        {
            switch (idIdioma)
            {
                case 0:
                    //cargamos datos del 1º personaje en català
                    textBoxNomP1.Text = listaPersonajes[0].nom;
                    textBoxDesc1.Text = listaPersonajes[0].frase;

                    //cargamos datos del 2º personaje en català
                    textBoxNomP2.Text = listaPersonajes[1].nom;
                    textBoxDesc2.Text = listaPersonajes[1].frase;

                    //cargamos datos del 3º personaje en català
                    textBoxNomP3.Text = listaPersonajes[2].nom;
                    textBoxDesc3.Text = listaPersonajes[2].frase;
                    break;


                case 1:
                    //cargamos datos del 1º personaje en castellà
                    textBoxNomP1.Text = listaPersonajes[3].nom;
                    textBoxDesc1.Text = listaPersonajes[3].frase;

                    //cargamos datos del 2º personaje en castellà
                    textBoxNomP2.Text = listaPersonajes[4].nom;
                    textBoxDesc2.Text = listaPersonajes[4].frase;

                    //cargamos datos del 3º personaje en castellà
                    textBoxNomP3.Text = listaPersonajes[5].nom;
                    textBoxDesc3.Text = listaPersonajes[5].frase;
                    break;


                case 2:
                    //cargamos datos del 1º personaje en angles
                    textBoxNomP1.Text = listaPersonajes[6].nom;
                    textBoxDesc1.Text = listaPersonajes[6].frase;

                    //cargamos datos del 2º personaje en angles
                    textBoxNomP2.Text = listaPersonajes[7].nom;
                    textBoxDesc2.Text = listaPersonajes[7].frase;

                    //cargamos datos del 3º personaje en angles
                    textBoxNomP3.Text = listaPersonajes[8].nom;
                    textBoxDesc3.Text = listaPersonajes[8].frase;
                    break;
            }
                        
            //Cargamos la 1 imagen
            if (Personaje.rutaImagen1 != null)
            {
                pictureBoxPersonatge1.Image = Image.FromFile(Personaje.rutaImagen1);
                pictureBoxPersonatge1.BackColor = Color.DarkGray;

            }

            //Cargamos la 2 imagen
            if (Personaje.rutaImagen2 != null)
            {
                pictureBoxPersonatge2.Image = Image.FromFile(Personaje.rutaImagen2);
                pictureBoxPersonatge2.BackColor = Color.DarkGray;

            }

            //Cargamos la 3 imagen
            if (Personaje.rutaImagen3 != null)
            {
                pictureBoxPersonatge3.Image = Image.FromFile(Personaje.rutaImagen3);
                pictureBoxPersonatge3.BackColor = Color.DarkGray;

            }

        }

        // Cerrar formulario
        private void pictureBoxSortir_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("Segur que vols sortir?", "Confirmar sortida", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                Close();
            }
        }

        // click volver al menu principal
        private void pictureBoxMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

        // click minimizar
        private void pictureBoxMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // click ajuda
        private void pictureBoxAjuda_Click(object sender, EventArgs e)
        {
            //el id 1 del FormAjuda corresponde con la ayuda para el gestor de personajes
            FormAjuda ajuda = new FormAjuda(1);
            ajuda.Show();
        }        

        //guardar personajes
        private void pictureBoxExportar_Click(object sender, EventArgs e)
        {

            //si hay campos vacios avisamos al usuario con el metodo campBuit();
            if (textBoxNomP1.Text == "")
            {
                campBuit();
                textBoxNomP1.Focus();
            }
            else if (textBoxDesc1.Text == "")
            {
                campBuit();
                textBoxDesc1.Focus();
            }
            else if (textBoxNomP2.Text == "")
            {
                campBuit();
                textBoxNomP2.Focus();
            }
            else if (textBoxDesc2.Text == "")
            {
                campBuit();
                textBoxDesc2.Focus();
            }
            else if (textBoxNomP3.Text == "")
            {
                campBuit();
                textBoxNomP3.Focus();
            }
            else if (textBoxDesc3.Text == "")
            {
                campBuit();
                textBoxDesc3.Focus();
            }
            //si hay imagenes sin cargar avisamos al usuario con el metodo campBuitImatge();
            else if (Personaje.rutaImagen1 == null)
            {
                campBuitImatge();
            }
            else if (Personaje.rutaImagen2 == null)
            {
                campBuitImatge();
            }
            else if (Personaje.rutaImagen3 == null)
            {
                campBuitImatge();
            }
            else
            {
                switch (idIdioma)
                {
                    case 0:
                        //guardamos datos del 1º personaje en català
                        listaPersonajes[0].nom = textBoxNomP1.Text;
                        listaPersonajes[0].frase = textBoxDesc1.Text;

                        //guardamos datos del 2º personaje en català
                        listaPersonajes[1].nom = textBoxNomP2.Text;
                        listaPersonajes[1].frase = textBoxDesc2.Text;

                        //guardamos datos del 3º personaje en català
                        listaPersonajes[2].nom = textBoxNomP3.Text;
                        listaPersonajes[2].frase = textBoxDesc3.Text;
                        break;

                    case 1:
                        //guardamos datos del 1º personaje en castellà
                        listaPersonajes[3].nom = textBoxNomP1.Text;
                        listaPersonajes[3].frase = textBoxDesc1.Text;

                        //guardamos datos del 2º personaje en castellà
                        listaPersonajes[4].nom = textBoxNomP2.Text;
                        listaPersonajes[4].frase = textBoxDesc2.Text;

                        //guardamos datos del 3º personaje en castellà
                        listaPersonajes[5].nom = textBoxNomP3.Text;
                        listaPersonajes[5].frase = textBoxDesc3.Text;
                        break;

                    case 2:
                        //guardamos datos del 1º personaje en angles
                        listaPersonajes[6].nom = textBoxNomP1.Text;
                        listaPersonajes[6].frase = textBoxDesc1.Text;

                        //guardamos datos del 2º personaje en angles
                        listaPersonajes[7].nom = textBoxNomP2.Text;
                        listaPersonajes[7].frase = textBoxDesc2.Text;

                        //guardamos datos del 3º personaje en angles
                        listaPersonajes[8].nom = textBoxNomP3.Text;
                        listaPersonajes[8].frase = textBoxDesc3.Text;
                        break;

                }

                Close();
            }
            
        }


        //Introducció de les imatges dels personatges i errors 
        private void pictureBoxPersonatge1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    pictureBoxPersonatge1.Image = Image.FromFile(imagen);
                    pictureBoxPersonatge1.BackColor = Color.DarkGray;

                    Personaje.rutaImagen1 = imagen;


                }
            }
            catch (Exception)
            {
                errorImatge();
            }
        }

        private void pictureBoxPersonatge2_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    pictureBoxPersonatge2.Image = Image.FromFile(imagen);
                    pictureBoxPersonatge2.BackColor = Color.DarkGray;

                    Personaje.rutaImagen2 = imagen;
                }
            }
            catch (Exception)
            {
                errorImatge();
            }
        }

        private void pictureBoxPersonatge3_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    pictureBoxPersonatge3.Image = Image.FromFile(imagen);
                    pictureBoxPersonatge3.BackColor = Color.DarkGray;

                    Personaje.rutaImagen3 = imagen;
                }
            }
            catch (Exception)
            {
                errorImatge();
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

        //metodo para inicializar los personajes
        private void inicializarPersonajes()
        {
            foreach (var personaje in listaPersonajes)
            {
                personaje.nom = "";
                personaje.frase = "";
            }
        }

        // Muestra error en caso de que haya un campo vacio
        private void campBuit()
        {
            MessageBox.Show("Completa el camp buit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Muestra error en caso de imagen sin cargar
        private void campBuitImatge()
        {
            MessageBox.Show("Introdueixi una imatge", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Muestra error en caso de que el archivo no sea una imagen
        private void errorImatge()
        {
            MessageBox.Show("El arxiu seleccionat no es una imatge");
        }


    }
}
