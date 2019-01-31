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
using System.Text.RegularExpressions;
using ClassLibrary;
using Windows.UI.Popups;
// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppVideojuegos
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AltaCompanias : Page
    {
        public AltaCompanias()
        {
            this.InitializeComponent();
        }

            private void AddComp(object sender, RoutedEventArgs e)
            {
            String dateString = Input_FechaIni.Date.ToString("dd/MM/yyyy");
            if (string.IsNullOrEmpty(Input_NomComp.Text) || string.IsNullOrEmpty(Input_NumTrab.ToString()))
            {
                MessageDialog mensaje = new MessageDialog("No pueden haber campos vacíos");
                mensaje.ShowAsync();
            }
            else {
                //Comprobamos si es numerico el campo numero de trabajadores
                /*NO FUNCIONA BIEN**********
                var regex = new Regex("[^0-9.-]+");
                var numerico = !regex.IsMatch(Input_NumTrab.ToString());
                if (numerico)
                {
                    MessageDialog mensaje = new MessageDialog("El campo Numero de trabajadores de ser numerico");
                    mensaje.ShowAsync();
                }
                */
                    DataAccess.InsertCompanias(Input_NomComp.Text, dateString, Input_NumTrab.Text);
                    VaciarCampos();
                

                

            }
            
            
            }
        private void VaciarCampos()
        {
            Input_NomComp.Text = "";
            Input_NumTrab.Text = "";
        }

    }
    }
