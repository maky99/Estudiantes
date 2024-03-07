using Logica.Librery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class LEstudiantes : Libreria
    {
        private List<TextBox> listTexBox;

        public LEstudiantes(List<TextBox> listTexBox)
        {
            this.listTexBox = listTexBox;
        }
    }
}
