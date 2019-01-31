using System;
using System.Collections.Generic;
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
using Windows.UI.Popups;

using ClassLibrary;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppVideojuegos
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AltaVideojuegos : Page
    {
        private List<string> listaCompanias;
        public AltaVideojuegos()
        {
            this.InitializeComponent();

            //Obtenemos el listado de nombres de compañias
            listaCompanias = DataAccess.getNomCompanias();
        }

        private void AddData(object sender, RoutedEventArgs e)
        {
            var dateString = Input_FechaPubli.Date.ToString("dd/MM/yyyy");
            if (string.IsNullOrEmpty(Input_NomJuego.Text) || string.IsNullOrEmpty(Input_Compania.ToString())|| string.IsNullOrEmpty(Input_Genero.ToString())) {
                MessageDialog mensaje = new MessageDialog("No pueden haber campos vacíos");
                mensaje.ShowAsync();
            }
            else {
                String sPlat = "";
                CheckBox[] plataformas = new CheckBox[]
                    {
                        Input_PC, Input_PSX, Input_PS2, Input_PS4, Input_XBox, Input_Switch
                    };

                foreach (var opcion in plataformas)
                {
                    if (opcion.IsChecked == true)
                    {
                        sPlat += opcion.Content + " ";
                    }
                }

                DataAccess.InsertVideojuegos(Input_NomJuego.Text, Input_Compania.SelectedValue.ToString(), Input_Genero.Text, sPlat, dateString);
                VaciarCampos();
            }
            
        }
        private void VaciarCampos() {
            Input_NomJuego.Text = "";
            Input_Compania.SelectedIndex = -1;
            
            Input_Genero.Text = "";
        }
    }
}
