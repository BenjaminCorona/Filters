using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Imaging.Filters;
using AForge.Math.Random;

namespace EditorImg
{
    public partial class Form1 : Form
    {
        //Variable global de la dirección de imagen
        public string direc;

        //Variable global del Bitmap de la imagen
        public System.Drawing.Bitmap res;

        public Form1()
        {
            InitializeComponent();

            //Inicializamos los componentes en null
            pictureB1.Image = null;
            pictureB2.Image = null;
            direc = null;
            res = null;
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            //Se crea un objeto de la clase filtros
            Filtros Fil = new Filtros();
            res = Fil.SaturationCorrection(direc);

            /*Aquí se carga la imagen con filtro al pictureBox*/
            pictureB2.Image = res;
            pictureB2.SizeMode = PictureBoxSizeMode.StretchImage;


            //Se guarda la imagen en el bin del proyecto
            //res.Save("prueba2.jpg");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void acercadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecciona un filtro en el menú y edita la fotografía que quieras", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //La URL del pictures box los iniciamos en null
            pictureB1.Image = null;
            pictureB2.Image = null;

            OpenFileDialog cargar = new OpenFileDialog();

            cargar.InitialDirectory = "c:\\";
            cargar.Title = "Abrir imagen";
            cargar.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|Todos los archivos (*.*)|*.*";
            cargar.FilterIndex = 4;
            cargar.RestoreDirectory = true;
            cargar.ShowDialog();

            try
            {
                pictureB1.Load(cargar.FileName);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //throw ex;
            }

            pictureB1.SizeMode = PictureBoxSizeMode.StretchImage;

            direc = cargar.FileName;
            //Bitmap image = Bitmap(Pb1.Image);

            /*
            pictureB1.Width = 20;
            pictureB1.Height = 100;
            */
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureB1.Image = null;
            pictureB2.Image = null;
            direc = null;
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.DefaultExt = "jpg";
            guardar.Filter = "JPG (*.jpg)|*.jpg|PNG (*.png)|*.png|Todos los archivos (*.*)|*.*";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (pictureB2.Image == null)
                    {
                        MessageBox.Show("No se generó ninguna imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        pictureB2.Image.Save(guardar.FileName);
                        MessageBox.Show("Se guardó correctamente", "AForge", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    //throw ex;
                }
            }
        }


    }
}
