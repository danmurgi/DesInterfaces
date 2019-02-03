using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace GraficoSector
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Formulario : Page
    {
        public Formulario()
        {
            this.InitializeComponent();
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numVentas = int.Parse(campoVentas.Text);
                if(!String.IsNullOrEmpty(campoNombre.Text) && !String.IsNullOrEmpty(campoVentas.Text))
                {
                    GestorVideojuegos.listaJuegos.Add(new Videojuego {nombre=campoNombre.Text, ventas=numVentas});
                    campoNombre.Text = "";
                    campoVentas.Text = "";
                }

            }catch(Exception)
            {

            }
        }
    }
}
