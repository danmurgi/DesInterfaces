using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes

namespace GraficoPizza
{
    /// <summary>
    ///  Realice los pasos 1a o 1b y luego 2 para usar este control personalizado en un archivo XAML.
    ///
    /// Paso 1a) Usar este control personalizado en un archivo XAML existente en el proyecto actual.
    /// Agregue este atributo XmlNamespace al elemento raíz del archivo de marcado en el que 
    /// se va a utilizar:
    ///
    ///     xmlns:MyNamespace="clr-namespace:GraficoPizza"
    ///
    ///
    /// Paso 1b) Usar este control personalizado en un archivo XAML existente en otro proyecto.
    /// Agregue este atributo XmlNamespace al elemento raíz del archivo de marcado en el que 
    /// se va a utilizar:
    ///
    ///     xmlns:MyNamespace="clr-namespace:GraficoPizza;assembly=GraficoPizza"
    ///
    /// Tendrá también que agregar una referencia de proyecto desde el proyecto en el que reside el archivo XAML
    /// hasta este proyecto y recompilar para evitar errores de compilación:
    ///
    ///     Haga clic con el botón secundario del mouse en el proyecto de destino en el Explorador de soluciones y seleccione
    ///     "Agregar referencia"->"Proyectos"->[Busque y seleccione este proyecto]
    ///
    ///
    /// Paso 2)
    /// Prosiga y utilice el control en el archivo XAML.
    ///
    ///     <MyNamespace:Grafico/>
    ///
    /// </summary>
    public class Grafico : Control
    {
        static Grafico()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Grafico), new FrameworkPropertyMetadata(typeof(Grafico)));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            const int margin = 10;
            const int width = 100;
            Graphics gr = e.Graphics;
            Pen outline_pen = Pens.Red;
            Brush fill_brush = Brushes.LightGreen;

            using (Pen ellipse_pen = new Pen(Color.Blue))
            {
                ellipse_pen.DashPattern = new float[] { 5, 5 };

                // Northeast wedge.
                Rectangle rect =
                    new Rectangle(margin + 30, 10, width, width);
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 300, 30);
                gr.DrawPie(outline_pen, rect, 300, 30);

                // Everything else.
                rect.X += width + margin;
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 300, -330);
                gr.DrawPie(outline_pen, rect, 300, -330);

                // East wedge.
                rect.Y += width + margin;
                rect.X = margin + 30;
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 315, 90);
                gr.DrawPie(outline_pen, rect, 315, 90);

                // Everything else.
                rect.X += width + margin;
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 315, -270);
                gr.DrawPie(outline_pen, rect, 315, -270);

                // Northwest quadrant.
                rect.Y += width + margin;
                rect.X = margin + 30;
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 180, 90);
                gr.DrawPie(outline_pen, rect, 180, 90);

                // Everything else.
                rect.X += width + margin;
                gr.DrawEllipse(ellipse_pen, rect);
                gr.FillPie(fill_brush, rect, 180, -270);
                gr.DrawPie(outline_pen, rect, 180, -270);
            }
        }
    }
}
