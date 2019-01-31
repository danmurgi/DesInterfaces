﻿using System;
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

namespace GraficoSector
{
    public sealed class Grafico : Control
    {
        Canvas paleta;
        List<Color> listaColores = new List<Color>();
        public Grafico()
        {
            this.DefaultStyleKey = typeof(Grafico);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            paleta = (Canvas)GetTemplateChild("canvas");
            llenarListaColores();
            if (paleta != null)
            {
                TrazarGrafico();
            }

        }

        public void TrazarGrafico()
        {
            if(ItemSource != null)
            {
                //Establecemos el angulo de inicio y fin para posicionar mas tarde cada segmento del grafico
                int anguloInicio = 0;
                int anguloFin = 0;

                int totalVentas = contarVentas(); 

                int posiColor = 0; //Contador que indicara la posicion de la lista de colores

                //Objeto que almacena la animacion
                Storyboard storyboard = (Storyboard)GetTemplateChild("sb");

                //Recorremos la lista para dibujar cada segmento 
                foreach (Videojuego juego in ItemSource)
                {
                    //Creamos el segmento grafico del elemento
                    RingSegment segmento = new RingSegment();

                    //Obtenemos el angulo donde acaba
                    anguloFin = anguloInicio + ((juego.ventas * 360) / totalVentas);

                    //Definimos el inicio y fin del segmento
                    segmento.StartAngle = anguloInicio;
                    segmento.EndAngle = anguloFin;

                    //Radio
                    segmento.Radius = radio;

                    //Color
                    segmento.Fill = new SolidColorBrush(listaColores[posiColor]);


                    segmento.Tapped += segmento_Tapped; //Evento del segmento
                   
                    //Añadimos el segmento al canvas
                    paleta.Children.Add(segmento);

                    //El angulo de inicio comenzara por el que ha terminado
                    anguloInicio = anguloFin;

                    
                    Canvas.SetLeft(segmento, 0);
                    Canvas.SetTop(segmento, 0);
                    posiColor++;
                }

                //Comenzamos la animacion
                storyboard.Begin();
            }
           
        }

        //Evento Tapped
        private void segmento_Tapped(object sender, TappedRoutedEventArgs e)
        {
            RingSegment segmento = sender as RingSegment;
            segmento.Fill = new SolidColorBrush(Colors.Magenta);
        }

        public int contarVentas()
        {
            int total=0;

            foreach (Videojuego juego in ItemSource)
            {
                total += juego.ventas;
            }

            return total;
        }
        
        public void llenarListaColores()
        {
            listaColores.Add(Colors.Red);
            listaColores.Add(Colors.Blue);
            listaColores.Add(Colors.Black);
            listaColores.Add(Colors.Pink);
            listaColores.Add(Colors.Green);
            listaColores.Add(Colors.Khaki);

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


//Creamos la animacion
/*
DoubleAnimation animacion = new DoubleAnimation()
{
    From = anguloInicio,
    To = anguloFin,
    Duration = new Duration(TimeSpan.FromSeconds(2)),
    EnableDependentAnimation = false
};

//var prop = RingSegment.EndAngleProperty;

//RotateTransform rotar = new RotateTransform();
//segmento.RenderTransform = rotar;

Storyboard.SetTarget(animacion, segmento);
Storyboard.SetTargetProperty(animacion, "EndAngle");
storyboard.Children.Add(animacion);

*/
