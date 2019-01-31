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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace GraficoSector
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Videojuego> listaJuegos = new ObservableCollection<Videojuego>();

        public MainPage()
        {
            this.InitializeComponent();
            LlenarLista();
            //sb.Begin();
            //Le damos la fuente de objetos al componente
            graficoPizza.ItemSource = listaJuegos;

        }

        private void LlenarLista()
        {
            listaJuegos.Add(new Videojuego {nombre="Final Fantasy VIII", ventas=7000});
            listaJuegos.Add(new Videojuego {nombre = "Resident Evil 3", ventas = 3000});
            listaJuegos.Add(new Videojuego { nombre = "Final Fantasy VIII", ventas = 4000 });
            listaJuegos.Add(new Videojuego { nombre = "Resident Evil 3", ventas = 10000 });
            listaJuegos.Add(new Videojuego { nombre = "Final Fantasy VIII", ventas = 1000 });
            listaJuegos.Add(new Videojuego { nombre = "Resident Evil 3", ventas =2000 });
        }
    }
}
