using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Librery
{
    public class Libreria : Conexion
    {
        //al no poder usar herencia multiple se crea esta clase
        public Uploadimage uploadimage = new Uploadimage();
        public TextBoxEvent textBoxEvent = new TextBoxEvent();

    }
}
