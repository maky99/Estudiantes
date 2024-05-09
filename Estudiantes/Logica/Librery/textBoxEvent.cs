using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Librery
{
    public class TextBoxEvent
    {
        public void  textKeyPress(KeyPressEventArgs e) 
        {
            //condicion que solo nos permite ingresar datos de tipo texto 
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            //condicion que permite no dar salto de linea ciando se oprime enter
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
            }
            //condicion que nos deja unsar la trcla de borrar (backspace)
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //condicion que nos permite usar la barra espaciadora
            else if (char.IsSeparator(e.KeyChar)) 
            {
                e.Handled = false;
            }
            else { e.Handled = true; }
        }
        public void numerKeyPress(KeyPressEventArgs e)
        {
            //condicion que solo nos permite ingresar datos de tipo numero
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //condicion que permite no dar salto de linea ciando se oprime enter
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;
            }
            //condicion que nos deja unsar la trcla de borrar (backspace)
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //condicion que nos permite usar la barra espaciadora
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else { e.Handled = true; }
        }
        public bool comprobarFormatoEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

    }
}
