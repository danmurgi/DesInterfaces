using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinDefinitivo.Vistas;
namespace XamarinDefinitivo.Modelos
{
    public class MenuPrincipal
    {
        //Lista que contendra los item de menu
        private static ObservableCollection<ItemMenu> _items = new ObservableCollection<ItemMenu>();
        public ObservableCollection<ItemMenu> Items
        {
            get
            {
                return _items;
            }
        }


        public MenuPrincipal()
        {
            _items.Add(new ItemMenu("Ver Citas", "Assets/orange.png", typeof(VerCita)));
            _items.Add(new ItemMenu("Nueva Citas", "Assets/orange.png", typeof(NuevaCita)));
        }
    }
}
