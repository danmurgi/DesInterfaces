using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using GraficoSector;
// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace GraficoSector
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class VerGrafico : Page
    {

        public VerGrafico()
        {
            this.InitializeComponent();

            //Le damos la fuente de objetos al componente
            graficoPizza.ItemSource = GestorVideojuegos.listaJuegos;
        }        

       /* private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            GestorVideojuegos.listaJuegos.Add(new Videojuego {nombre = "prueba", ventas = 250000});
        }
        */
    }
}
