using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinDefinitivo.Vistas;
using XamarinDefinitivo.Modelos;

namespace XamarinDefinitivo
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(VerCita)));
        }

        private void ListView_ItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            ItemMenu im = (ItemMenu)e.SelectedItem;
            Type tipoPagina = im._pagina;
            Detail = new NavigationPage((Page)Activator.CreateInstance(tipoPagina));
        }
    }
}
