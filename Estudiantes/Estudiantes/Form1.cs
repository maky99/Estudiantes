using Logica;
using Logica.Librery;
using Microsoft.Win32;
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
        //private Libreria libreria;

        public Form1()
        {
            InitializeComponent();
            //libreria = new Libreria();

            var listTexBox = new List<TextBox>();
            listTexBox.Add(textBoxDni);
            listTexBox.Add(textBoxApellido);
            listTexBox.Add(textBoxNombre);
            listTexBox.Add(textBoxEmail);
            var listlabel = new List<Label>();
            listlabel.Add(labelDni);
            listlabel.Add(labelApellido);
            listlabel.Add(labelNombre);
            listlabel.Add(labelEmail);
            listlabel.Add(labelPaginas);
            Object[] objectos = { pictureBoxImagen, Properties.Resources.estudiantes, dataGridView1, numericUpDown1 };
            estudiante = new LEstudiantes(listTexBox,listlabel, objectos);



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


        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            estudiante.Registrar();
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

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            estudiante.searchEstudiante(textBoxBuscar.Text);
        }

        private void buttonInicio_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Primero");
        }

        private void buttonAnt_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Anterior");
        }

        private void buttonSig_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Siguiente");
        }

        private void buttonFin_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Ultimo");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            estudiante.Registro_paginas();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count!=0)
                estudiante.GetEstudiante();
            
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
                estudiante.GetEstudiante();

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            estudiante.Restablecer();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            estudiante.Eliminar();
        }
    }
}
