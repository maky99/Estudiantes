using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.Librery
{
    //genero la clase para poder abrir la busqueda
    public class Uploadimage
    {
        //creo un objeto y agrego la referencia, esto es la ventana que nos va a permitir cargar las imagenes
        private OpenFileDialog fd = new OpenFileDialog();
        //creo el metodo que recibe un objeto como parametro que es un picture box
        public void CargarImagen(PictureBox pictureBox) 
        {
            //establecer la propiedad de waitOnload a true significa que la imagen se carga de forma sincronica
            pictureBox.WaitOnLoad = true;
            fd.Filter = "Imagenes|*.jpg;*.gif;*.png;*,bmp";
            fd.ShowDialog();
            if (fd.FileName != string.Empty )
            {//le decimos a nuestro picturebox la loacliazcion de la imagen 
                pictureBox.ImageLocation = fd.FileName;
                
            }
        }
    }
}
