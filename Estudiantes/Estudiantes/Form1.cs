using Logica;
using Logica.Librery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudiantes
{
    public partial class Form1 : Form
    {
        private LEstudiantes estudiante;
        public Form1()
        {
            InitializeComponent();
            var listTexBox = new List<TextBox>();
            listTexBox.Add(textBoxDni);
            listTexBox.Add(textBoxNombre);
            listTexBox.Add(textBoxApellido);
            listTexBox.Add(textBoxEmail);
            estudiante = new LEstudiantes(listTexBox);



        }
        //para cargar la imagen desde
            private void pictureBox_Click(object sender, EventArgs e)
        {
            estudiante.uploadimage.CargarImagen(pictureBoxImagen);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDni_TextChanged(object sender, EventArgs e)
        {
            //valido si en el campo de tex hay algo de texto lo pone enotro color 
            if (textBoxDni.Text.Equals(""))
            {
                labelDni.ForeColor = Color.LightSlateGray;

            }
            else
            {
                labelDni.ForeColor = Color.Green;
                labelDni.Text = "Dni";
            }
        }

        private void textBoxDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.numerKeyPress(e);
        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {
            if (textBoxApellido.Text.Equals(""))
            {
                labelApellido.ForeColor = Color.LightSlateGray;

            }
            else
            {
                labelApellido.ForeColor = Color.Green;
                labelApellido.Text = "Apellido";
            }
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.textKeyPress(e);
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNombre.Text.Equals(""))
            {
                labelNombre.ForeColor = Color.LightSlateGray;

            }
            else
            {
                labelNombre.ForeColor = Color.Green;
                labelNombre.Text = "Nombre";
            }

        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.textBoxEvent.textKeyPress(e);
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEmail.Text.Equals(""))
            {
                labelEmail.ForeColor = Color.LightSlateGray;

            }
            else
            {
                labelEmail.ForeColor = Color.Green;
                labelEmail.Text = "Email";
            }
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
