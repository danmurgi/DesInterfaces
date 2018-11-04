using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Videojuego
    {
        //Atributos
        public string nombre { get; set; }
        public string compania { get; set; }
        public string genero { get; set; }
        public string plataforma { get; set; }
        public string fechaPubli { get; set; }


        //Constructor
        public Videojuego(string nombre, string compania, string genero, string plataforma, string fechaPubli) 
        {
            this.nombre = nombre;
            this.compania = compania;
            this.genero = genero;
            this.plataforma = plataforma;
            this.fechaPubli = fechaPubli;
        }
    }
}
