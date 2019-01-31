using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace GraficoSector
{
    public sealed class Grafico : Control
    {
        Canvas paleta;
        Ellipse circunf;
        public Grafico()
        {
            this.DefaultStyleKey = typeof(Grafico);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            paleta = (Canvas)GetTemplateChild("canvas");

            if(paleta != null)
            {
                trazar(4);
                //PintarGrafico();

            }
            
        }

        private void PintarGrafico()
        {
            //Creamos la ellipse
            circunf = new Ellipse();

            //Redimensionamos la ellipse
            circunf.Width = 300;
            circunf.Height = 300;

            //Obtenemos el color
            SolidColorBrush color = new SolidColorBrush(Colors.Aqua);

            //Pintamos la ellipse
            circunf.Fill = color;

            //Añadimos la ellipse al canvas
            paleta.Children.Add(circunf);
            
            //Posicionamos la ellipse
            Canvas.SetLeft(circunf, 50);
            Canvas.SetTop(circunf, 50);
        }
        
        //De momento se le pasa un numero de productos, mas tarde se le pasara una lista de objetos
        private void trazar(int numProductos)
        {
            int tamanoTotal = 300;
            int cantidadMax = 2000;
            int auxEje = 0;
            int yPunto2 = tamanoTotal/2;
            int yPunto3 = 100;

            for (int i = 0; i < numProductos; i++)
            {
                //Instanciamos el poligono
                Polygon poligono = new Polygon();

                //Creamos los colores
                SolidColorBrush rojo = new SolidColorBrush(Colors.Red);
                SolidColorBrush verde = new SolidColorBrush(Colors.Green);

                //Pintamos el borde y relleno del poligono
                poligono.Stroke = rojo;
                poligono.Fill = verde;

                //poligono.StrokeThickness = 2;

                //Creamos los puntos
                //if ()
                //{

                //}
                Point punto1 = new Point(0, 0);
                Point punto2 = new Point(0, yPunto2);
                Point punto3 = new Point(tamanoTotal/2, yPunto3);

                //Creamos una lista de puntos
                PointCollection listaPuntos = new PointCollection();

                //Añadimos los puntos
                listaPuntos.Add(punto1);
                listaPuntos.Add(punto2);
                listaPuntos.Add(punto3);

                //Le asignamos la lista de puntos al poligono
                poligono.Points = listaPuntos;

                //Añadimos el poligono al canvas
                paleta.Children.Add(poligono);

                yPunto2+=
                yPunto3 += 100;
            }
        }


        //Propiedad que define el alto y ancho del grafico
        public int tamano
        {
            get { return (int)GetValue(tamanoProperty); }
            set { SetValue(tamanoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for tamano.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty tamanoProperty =
            DependencyProperty.Register("tamano", typeof(int), typeof(Grafico), new PropertyMetadata(null));


    }
}
