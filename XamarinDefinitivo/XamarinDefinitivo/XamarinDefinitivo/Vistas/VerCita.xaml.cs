using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinDefinitivo.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerCita : ContentPage
	{
		public VerCita ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listaCitas.ItemsSource = await App.DataBase.GetCitas();
        }
    }
}