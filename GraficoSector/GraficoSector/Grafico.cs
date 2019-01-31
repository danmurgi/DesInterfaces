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
                //trazar(4);
                //PintarGrafico();
                trazarGrafico();

            }
            
        }

        private void trazarGrafico()
        {
            
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
