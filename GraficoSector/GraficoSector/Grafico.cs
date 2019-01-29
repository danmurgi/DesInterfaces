using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
                PintarGrafico();
            }
            
        }

        private void PintarGrafico()
        {
            Ellipse elipse = new Ellipse();

            elipse.Width = 300;
            elipse.Height = 300;

            SolidColorBrush color = new SolidColorBrush(Colors.Aqua);
            //color.Color = Color.FromArgb(0, 0, 0, 0);

            elipse.Fill = color;

            //Canvas.SetLeft(elipse, 200);
            //Canvas.SetTop(elipse, 200);

            paleta.Children.Add(elipse);

            Canvas.SetLeft(elipse, 50);
            Canvas.SetTop(elipse, 50);
        }
    }
}
