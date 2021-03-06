﻿using System;
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

using ClassLibrary;
// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace AppVideojuegos
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //Inicializamos el frame del menu
            MenuFrame.Navigate(typeof(VerCompanias));
           
        }

        private void Atras_Click(object sender, RoutedEventArgs e) {
            try
            {
                this.MenuFrame.GoBack();
            }
            catch (Exception) { }
        }
        private void Adelante_Click(object sender, RoutedEventArgs e) {
            try
            {
                this.MenuFrame.GoForward();
            }
            catch (Exception) { }
        }
        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(typeof(VerCompanias));
        }
        //Eventos del menu
        private void Bt_Hamburguesa_Click(object sender, RoutedEventArgs e) {
            SplitMenu.IsPaneOpen = !SplitMenu.IsPaneOpen;
        }
        private void AltaComp_Click(object sender, RoutedEventArgs e) {
            MenuFrame.Navigate(typeof(AltaCompanias));
        }

        private void AltaVideojuegos_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(typeof(AltaVideojuegos));
        }

        private void VerComp_Click(object sender, RoutedEventArgs e) {
            MenuFrame.Navigate(typeof(VerCompanias));
        }
        private void VerVideojuegos_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(typeof(VerVideojuegos));
        }

        
    }
}
