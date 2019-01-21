using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace SistemaSolar
{
    public sealed class SistemaSolar : Control 
    {
        //Atributos
        Canvas _canvas;
        private int radioSol = 80;

        //Constructor
        public SistemaSolar()
        {
            this.DefaultStyleKey = typeof(SistemaSolar);
        }

        //Metodo para pintar dentro del canvas
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _canvas = (Canvas)GetTemplateChild("canvasTemplate");

            if(_canvas != null)
            {
                crearPlanetas();
            }
        }

        private void crearPlanetas()
        {
            if(ItemsSource != null)
            {
                foreach (var item in ItemsSource)
                {
                    var element = new Ellipse();
                    //element.Fill = item.Color;
                    element.Fill = new ImageBrush() { ImageSource = new BitmapImage() { UriSource = new Uri("ms-appx:///" + item.Imagen) } };
                    element.Width = element.Height = item.Diametro;
                    _canvas.Children.Add(element);
                    Canvas.SetLeft(element, (radioSol * -1) + (item.DistanciaSol * -1));
                    Canvas.SetTop(element, (item.Diametro / 2) * -1);
                    var title = new TextBlock();
                    title.Text = item.Nombre;
                    title.HorizontalAlignment = HorizontalAlignment.Center;
                    _canvas.Children.Add(title);
                    Canvas.SetLeft(title, (radioSol * -1) + (item.DistanciaSol * -1));
                    Canvas.SetTop(title, ((item.Diametro / 2) + 20) * -1);

                }
            }
        }


        public List<Planeta> ItemsSource
        {
            get { return (List<Planeta>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(List<Planeta>), typeof(SistemaSolar), new PropertyMetadata(null));



        public double MaxItemSize
        {
            get { return (double)GetValue(MaxItemSizeProperty); }
            set { SetValue(MaxItemSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxItemSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxItemSizeProperty =
            DependencyProperty.Register("MaxItemSize", typeof(double), typeof(SistemaSolar), new PropertyMetadata(null));



        public double MinItemSize
        {
            get { return (double)GetValue(MinItemSizeProperty); }
            set { SetValue(MinItemSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinItemSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinItemSizeProperty =
            DependencyProperty.Register("MinItemSize", typeof(double), typeof(SistemaSolar), new PropertyMetadata(null));


    }
}
