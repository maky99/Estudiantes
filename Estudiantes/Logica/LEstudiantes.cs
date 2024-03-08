using Logica.Librery;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class LEstudiantes : Libreria
    {
        private List<TextBox> listTexBox;
        private List<Label> listlabel;

        public LEstudiantes(List<TextBox> listTexBox, List<Label> listlabel)
        {
            this.listTexBox = listTexBox;
            this.listlabel= listlabel;
        }
        public void Registrar()
        {
            if (listTexBox[0].Text.Equals(""))
            {
                listlabel[0].Text = "Dni *Requerido";
                listlabel[0].ForeColor = Color.Red;
                listTexBox[0].Focus();
            }
            else {
                if (listTexBox[1].Text.Equals(""))
                {
                    listlabel[1].Text = "Apellido *Requerido ";
                    listlabel[1].ForeColor = Color.Red;
                    listTexBox[1].Focus();
                }
                else {
                    if (listTexBox[2].Text.Equals(""))
                    {
                        listlabel[2].Text = "Nombre *Requerido";
                        listlabel[2].ForeColor = Color.Red;
                        listTexBox[2].Focus();
                    }
                    else {
                        if (listTexBox[3].Text.Equals(""))
                        {
                            listlabel[3].Text = "Email *Requerido";
                            listlabel[3].ForeColor = Color.Red;
                            listTexBox[3].Focus();
                        }
                    }
                }
            }            
        }
    }
}
