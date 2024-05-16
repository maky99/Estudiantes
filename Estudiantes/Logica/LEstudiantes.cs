using Data;
using LinqToDB;
using Logica.Librery;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class LEstudiantes : Libreria
    {
        private List<TextBox> listTexBox;
        private List<Label> listlabel;
        private PictureBox image;
        private Bitmap imagBitmap;
        private DataGridView dataGridView;
        private NumericUpDown numericUpDown;
        private Paginador<Estudiante> paginador;
        private string accion = "insertar";
        //private Libreria libreria;

        public LEstudiantes(List<TextBox> listTexBox, List<Label> listlabel, object[] objectos)
        {
            this.listTexBox = listTexBox;
            this.listlabel = listlabel;
            //libreria = new Libreria();
            image = (PictureBox)objectos[0];
            imagBitmap = (Bitmap)objectos[1];
            dataGridView = (DataGridView)objectos[2];
            numericUpDown= (NumericUpDown)objectos[3];
            Restablecer();
        }
        public void Registrar()
        {
            if (listTexBox[0].Text.Equals(""))
            {
                listlabel[0].Text = "Dni *Requerido";
                listlabel[0].ForeColor = Color.Red;
                listTexBox[0].Focus();
            }
            else
            {
                if (listTexBox[1].Text.Equals(""))
                {
                    listlabel[1].Text = "Apellido *Requerido ";
                    listlabel[1].ForeColor = Color.Red;
                    listTexBox[1].Focus();
                }
                else
                {
                    if (listTexBox[2].Text.Equals(""))
                    {
                        listlabel[2].Text = "Nombre *Requerido";
                        listlabel[2].ForeColor = Color.Red;
                        listTexBox[2].Focus();
                    }
                    else
                    {
                        if (listTexBox[3].Text.Equals(""))
                        {
                            listlabel[3].Text = "Email *Requerido";
                            listlabel[3].ForeColor = Color.Red;
                            listTexBox[3].Focus();
                        }
                        else
                        //no puede validar el mail
                        {
                            if (textBoxEvent.comprobarFormatoEmail(listTexBox[3].Text))
                            {
                                using (var db = new Conexion())
                                {
                                    var estudiantes = db.GetTable<Estudiante>();//acedo a la tabla estudiante 
                                    var user = estudiantes.Where(u => u.email.Equals(listTexBox[3].Text) ).ToList();
                                    if (user.Count.Equals(0))
                                    {
                                        Save();
                                    }
                                    else {
                                        if (user[0].id.Equals(idEstudiante))
                                        {
                                            Save();
                                        }
                                        else
                                        {
                                            listlabel[3].Text = "Email *Ya registrado";
                                            listlabel[3].ForeColor = Color.Red;
                                            listTexBox[3].Focus();
                                        }
                                    }                                    
                                }
                            }
                            else
                            {
                                listlabel[3].Text = "Formato erroneo";
                                listlabel[3].ForeColor = Color.Red;
                                listTexBox[3].Focus();
                            }
                        }
                    }
                }
            }
            
        }
        private void Save() {
            BeginTransactionAsync();
            try
            {
                var imageArray = uploadimage.ImageToByte(image.Image);
                using (var db = new Conexion())
                {
                    switch (accion)
                {
                    case "insertar":
                            db.Insert(new Estudiante()
                            {
                                dni = listTexBox[0].Text,
                                apellido = listTexBox[1].Text,
                                nombre = listTexBox[2].Text,
                                email = listTexBox[3].Text,
                                image = imageArray
                            });

                            break;
                        case "actualizar":
                            var estudiante = db.FirstOrDefault(e => e.id == idEstudiante);
                            if (estudiante != null)
                            {
                                estudiante.dni = listTexBox[0].Text;
                                estudiante.apellido = listTexBox[1].Text;
                                estudiante.nombre = listTexBox[2].Text;
                                estudiante.email = listTexBox[3].Text;
                                estudiante.image = imageArray;

                                db.Update(estudiante);
                            }
                            break;

                            //case "actualizar":

                            //    db.Update(new Estudiante()
                            //    {
                            //        dni = listTexBox[0].Text,
                            //        apellido = listTexBox[1].Text,
                            //        nombre = listTexBox[2].Text,
                            //        email = listTexBox[3].Text,
                            //        image = imageArray
                            //    });

                            //    break;

                    }
                    CommitTransaction();
                    Restablecer();
                }
            }
            catch (Exception)
            {
                RollbackTransaction();
                throw;
            }   
        }
        private int num_pagina = 1, reg_por_pagina = 3;//creo las variables para usarlas para paginar (reg_por_pagina muestra la cantidad de rgistos por pagina)
        public void searchEstudiante(string campo)//con este metodo obtengo los metodos de la tabla 
        {
            List<Estudiante> query = new List<Estudiante>();
            int inicio = (num_pagina - 1) * reg_por_pagina;
            using (var db = new Conexion())
            {
                if (campo.Equals(""))
            {
                
                    query = db.GetTable<Estudiante>().ToList();
                
            }
            else
            {
                    query = db.GetTable<Estudiante>()
                          .Where(c => c.dni.StartsWith(campo) ||
                                      c.nombre.StartsWith(campo) ||
                                      c.apellido.StartsWith(campo))
                          .ToList();
                }
                if (0<query.Count)
                {
                    dataGridView.DataSource = query.Select(c => new
                    {
                        c.id,
                        c.dni,
                        c.apellido,
                        c.nombre,
                        c.email,
                        c.image
                    }).Skip(inicio).Take(reg_por_pagina).ToList();
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;//le doy el color que quiero a la columa
                    dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    dataGridView.DataSource = query.Select(c => new
                    {
                        c.id,
                        c.dni,
                        c.apellido,
                        c.nombre,
                        c.email,
                    }).ToList();

                }
            }
        }
        private int idEstudiante = 0;
        public void GetEstudiante()
        {
            accion = "actualizar";
            idEstudiante = Convert.ToInt16(dataGridView.CurrentRow.Cells[0].Value);
            listTexBox[0].Text = Convert.ToString(dataGridView.CurrentRow.Cells[1].Value);
            listTexBox[1].Text = Convert.ToString(dataGridView.CurrentRow.Cells[2].Value);
            listTexBox[3].Text = Convert.ToString(dataGridView.CurrentRow.Cells[4].Value);
            listTexBox[2].Text = Convert.ToString(dataGridView.CurrentRow.Cells[3].Value);
            try
            {
                byte[] arrayImage = (byte[])dataGridView.CurrentRow.Cells[5].Value;
                image.Image = uploadimage.byteArrayToImage(arrayImage);
            }
            catch (Exception)
            {

                image.Image=imagBitmap;
            }
        }


        private List<Estudiante> listEstudiante;

        public void Paginador(string metodo) 
        {
            switch (metodo)
            {
                case "Primero": num_pagina = paginador.primero();
                    break;
                case "Anterior":
                    num_pagina = paginador.anterior();
                    break;
                case "Siguiente":
                    num_pagina = paginador.siguiente();
                    break;
                case "Ultimo":
                    num_pagina = paginador.ultimo();
                    break;
            }
            searchEstudiante("");
        }
        public void Registro_paginas()
        {
            using (var db = new Conexion())
            {
                num_pagina = 1;
                reg_por_pagina = (int)numericUpDown.Value;
                var list = db.GetTable<Estudiante>().ToList();
                if (0<list.Count)
                {
                    paginador = new Paginador<Estudiante>(listEstudiante, listlabel[4], reg_por_pagina);
                    searchEstudiante("");
                }
            }
        }
        private void Restablecer() {
            using (var db = new Conexion())
            {
                accion = "insertar";
                num_pagina = 1;
                idEstudiante = 0;
                image.Image = imagBitmap;
                listlabel[0].Text = "Dni";
                listlabel[1].Text = "Apellido";
                listlabel[2].Text = "Nombre";
                listlabel[3].Text = "Email";
                listlabel[0].ForeColor = Color.LightGray;
                listlabel[1].ForeColor = Color.LightGray;
                listlabel[2].ForeColor = Color.LightGray;
                listlabel[3].ForeColor = Color.LightGray;
                listTexBox[0].Text = "";
                listTexBox[1].Text = "";
                listTexBox[2].Text = "";
                listTexBox[3].Text = "";

                listEstudiante = db.GetTable<Estudiante>().ToList();
                if (0 < listEstudiante.Count)
                {
                    paginador = new Paginador<Estudiante>(listEstudiante, listlabel[4], reg_por_pagina);
                }
                searchEstudiante("");
            }
        }
    }
}

