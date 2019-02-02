using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace GraficoSector
{
    public class Videojuego
    {
        public string nombre { get; set; }
        public int ventas { get; set; }
        public Brush colorJuego { get; set; } //Se le asignara el color que le toque en el grafico

    }
}
