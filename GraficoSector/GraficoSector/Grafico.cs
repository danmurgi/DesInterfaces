using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Template10.Controls;
using Windows.UI.Xaml.Media.Animation;
using System.Diagnostics;
using System.Collections.Specialized;

namespace GraficoSector
{
    public sealed class Grafico : Control
    {
        //Atributos
        Canvas paleta;
        StackPanel stackLeyenda;
        StackPanel stackJuego;
        StackPanel stackInfo;
        TextBlock infoNombre;
        TextBlock infoVentas;
        List<Color> listaColores = new List<Color>();

        //Constructor
        public Grafico()
        {
            this.DefaultStyleKey = typeof(Grafico);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            paleta = (Canvas)GetTemplateChild("canvas");

            //StackPanel que muestra la informacion del juego seleccionado
            stackInfo = new StackPanel();
            infoNombre = new TextBlock();
            infoVentas = new TextBlock();

            //Definimos el panel de informacion
            stackInfo.Orientation = Orientation.Vertical;
            stackInfo.BorderThickness = new Thickness(5);
            stackInfo.BorderBrush = new SolidColorBrush(Colors.Black);

            stackInfo.Children.Add(infoNombre);
            stackInfo.Children.Add(infoVentas);
            paleta.Children.Add(stackInfo);

            //Posicionamos el panel de info
            Canvas.SetTop(stackInfo, 0);
            Canvas.SetLeft(stackInfo, 0);

            //Segundo anillo que hara la animacion
            RingSegment rs = (RingSegment)GetTemplateChild("graficoAnimacion");
            rs.Radius = this.radio;

            llenarListaColores(); //Cargamos la lista de colores

            //Objeto que almacena la animacion
            Storyboard storyboard = (Storyboard)GetTemplateChild("sb");

            if (paleta != null)
            {
                TrazarGrafico();
                storyboard.Begin(); //Comenzamos la animacion
            }

            //Si la lista cambia se vuelve a trazar el grafico
            ItemSource.CollectionChanged += itemSource_Changed;


        }

        public void TrazarGrafico()
        {

            if (ItemSource != null)
            {
                //Inicializamos el StackPanel de la leyenda
                stackLeyenda = new StackPanel();
                stackLeyenda.Orientation = Orientation.Vertical;
                paleta.Children.Add(stackLeyenda);

                Canvas.SetLeft(stackLeyenda, this.Width-50);

                

                //Establecemos el angulo de inicio y fin para posicionar mas tarde cada segmento del grafico
                int anguloInicio = 0;
                int anguloFin = 0;

                int totalVentas = contarVentas();

                //Recorremos la lista para dibujar cada segmento 
                for (int i = 0; i < ItemSource.Count && i < listaColores.Count; i++)
                {
                    //Obtenemos el juego actual
                    Videojuego juego = ItemSource[i];

                    //Creamos el segmento grafico del elemento
                    RingSegment segmento = new RingSegment();

                    //Obtenemos el angulo donde acaba
                    //Si se va a pintar el ultimo item el angulo de fin sera 360
                    if (i == ItemSource.Count - 1)
                    {
                        anguloFin = 360;
                    }
                    //Si no calculamos el angulo con la proporcion
                    else
                    {
                        anguloFin = anguloInicio + ((juego.ventas * 360) / totalVentas);
                    }

                    //Redefinimos el inicio y fin del segmento
                    segmento.StartAngle = anguloInicio;
                    segmento.EndAngle = anguloFin;

                    //Radio
                    segmento.Radius = radio;

                    //Asignamos el mismo color de la lista al segmento y al objeto
                    segmento.Fill = new SolidColorBrush(listaColores[i]);
                    juego.colorJuego = new SolidColorBrush(listaColores[i]);

                    //Etiqueta con el nombre del juego
                    TextBlock etiquetaJuego = new TextBlock();
                    etiquetaJuego.Text = juego.nombre;

                    //Rectangulo del mismo color que el segmento
                    Rectangle cuadroColor = new Rectangle();
                    cuadroColor.Width = 25;
                    cuadroColor.Height = 25;
                    cuadroColor.Margin = new Thickness(0, 0, 6, 0);
                    cuadroColor.Fill = juego.colorJuego;

                    //StackPanel horizontal que tendra el cuadro de color y el nombre del videojuego
                    stackJuego = new StackPanel();
                    stackJuego.Orientation = Orientation.Horizontal;
                    stackJuego.Margin = new Thickness(0, 0, 0, 6);

                    //Añadimos los componentes a los stackpanel
                    stackJuego.Children.Add(cuadroColor);
                    stackJuego.Children.Add(etiquetaJuego);
                    stackLeyenda.Children.Add(stackJuego);

                    //Evento del segmento
                    segmento.Tapped += segmento_Tapped; //Evento del segmento

                    //Añadimos el segmento al canvas
                    paleta.Children.Add(segmento);

                    //El angulo de inicio comenzara por el que ha terminado
                    anguloInicio = anguloFin;

                    Canvas.SetLeft(segmento, 0);
                    Canvas.SetTop(segmento, 0);

                }


            }

        }

        //Evento Tapped
        private void segmento_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Obtenemos el segmento recibido
            RingSegment segmento = sender as RingSegment;

            //Obtenemos el color solido del segmento
            SolidColorBrush colorSegmento = (SolidColorBrush)segmento.Fill;

            for (int i = 0; i < ItemSource.Count; i++)
            {
                Videojuego juego = ItemSource[i];

                //Obtenemos el color solido del del juego y 
                SolidColorBrush colorJuego = (SolidColorBrush)juego.colorJuego;

                //Comprobamos si el color del segmento es el mismo que el del objeto Videojuego
                if (colorSegmento.Color == colorJuego.Color)
                {
                    Debug.WriteLine("Juego pulsado: " + juego.nombre);
                    infoNombre.Text = "Videojuego: " + juego.nombre;
                    infoVentas.Text = "Ventas: " + juego.ventas;
                    

                }

            }
        }

        private void itemSource_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            TrazarGrafico();
        }
        public int contarVentas()
        {
            int total = 0;

            foreach (Videojuego juego in ItemSource)
            {
                total += juego.ventas;
            }

            return total;
        }

        public void llenarListaColores()
        {
            listaColores.Add(Colors.LightCoral);
            listaColores.Add(Colors.SteelBlue);
            listaColores.Add(Colors.Red);
            listaColores.Add(Colors.Aqua);
            listaColores.Add(Colors.Blue);
            listaColores.Add(Colors.SeaGreen);
            listaColores.Add(Colors.Green);

        }
        //Propiedad que define el radio
        public int radio
        {
            get { return (int)GetValue(radioProperty); }
            set { SetValue(radioProperty, value); }
        }

        // Using a DependencyProperty as the backing store for radio.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty radioProperty =
            DependencyProperty.Register("radio", typeof(int), typeof(Grafico), new PropertyMetadata(null));


        //Fuente de datos
        public ObservableCollection<Videojuego> ItemSource
        {
            get { return (ObservableCollection<Videojuego>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(ObservableCollection<Videojuego>), typeof(Grafico), new PropertyMetadata(null));



    }
}

