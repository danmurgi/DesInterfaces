using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace GraficoSector
{
    /// <summary>
    /// Tipo de objeto con el que trabajara el grafico
    /// </summary>
    public class Videojuego
    {
        public string nombre { get; set; }
        public int ventas { get; set; }
        public Brush colorJuego { get; set; } //Se le asignara el color que le toque en el grafico
    }

    /// <summary>
    /// Clase estatica que contiene la lista de objetos
    /// </summary>
    public static class GestorVideojuegos
    {
        public static ObservableCollection<Videojuego> listaJuegos = new ObservableCollection<Videojuego>();
    }
}
