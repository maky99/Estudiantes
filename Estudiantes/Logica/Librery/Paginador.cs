using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace Logica.Librery
{
    public class Paginador<T>
    {
        private List<T> dataList;
        private Label _label;
        //para hacer el paginador se hacen estas variables estaticas asi no se pueden modificar 
        //maxReg (maximos de registros), reg_por_pagina (regisro por pagina), pageCount(cantidad de paginas), numpagi(numero de pagina)
        private static int maxReg, _reg_por_pagina, pageCount, numpagi ;

        //creamos el constructor 
        public Paginador(List<T> data, Label label, int reg_por_pagina) { 
            //inicializamos los objetos
            dataList= data;
            _label = label;
            _reg_por_pagina = reg_por_pagina;
            cargarDatos();
        }
        private void cargarDatos()
        {
            numpagi = 1;
            maxReg = dataList.Count;
            pageCount=(maxReg/_reg_por_pagina);
            //ajusta el numero de la pagina si la ultima pagina contiene una parte de la pagina 
            if ((maxReg % _reg_por_pagina)>0)
            {
                pageCount += 1;
            }
            _label.Text = $"Paginas 1/{pageCount}";
        }
        public int primero()
        {
            numpagi = 1;
            _label.Text = $"Paginas{numpagi}/{pageCount}";

            return numpagi;
        }
        public int anterior()
        {
            if (numpagi>1)
            {
                numpagi -= 1;
                _label.Text = $"paginas{numpagi}/{pageCount}";
            }
            return numpagi;
            
        }
        public int siguiente()
        {
            if (numpagi == pageCount)
            {
                numpagi -= 1;
            }
            if (numpagi<pageCount)
            {
                numpagi += 1;
                _label.Text = $"paginas{numpagi}/{pageCount}";
            }
            return numpagi;
        }
        public int ultimo()
        {
            numpagi = pageCount;
            _label.Text=$"paginas{numpagi}/{pageCount}";
            return numpagi;

        }
    }
}
