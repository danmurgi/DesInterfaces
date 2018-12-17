using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XamarinDefinitivo.Modelos
{
    public class ItemMenu
    {
        //Atributos
        public string _titulo { get; set; }
        public string _icono { get; set; }
        public Type _pagina { get; set; }

        public ItemMenu(string titulo, string icono, Type pagina)
        {
            this._titulo = titulo;
            this._icono = icono;
            this._pagina = pagina;
        }


    }
}
