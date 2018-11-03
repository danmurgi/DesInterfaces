using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Videojuego
    {

        //private int cod { get; set; }
        public string nombre { get; set; }

        //Constructor
        public Videojuego(string nombre)
        {
            this.nombre = nombre;
        }
    }
}
