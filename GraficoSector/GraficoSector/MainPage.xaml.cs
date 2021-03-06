﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace GraficoSector
{
    /// <summary>
    /// Pagina vacía que inicializa la lista de objetos y contiene el frame del menu
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            llenarLista();
            MenuFrame.Navigate(typeof(VerGrafico));
        }


        private void llenarLista()
        {
            GestorVideojuegos.listaJuegos.Add(new Videojuego { nombre = "Final Fantasy VIII", ventas = 705184 });
            GestorVideojuegos.listaJuegos.Add(new Videojuego { nombre = "Resident Evil 3", ventas = 205932 });
            GestorVideojuegos.listaJuegos.Add(new Videojuego { nombre = "Pokémon Rojo", ventas = 450000 });
            GestorVideojuegos.listaJuegos.Add(new Videojuego { nombre = "The Legend of Zelda: Ocarina of Time", ventas = 400000 });
            //GestorVideojuegos.listaJuegos.Add(new Videojuego { nombre = "Final Fantasy VIII", ventas = 1000 });
            //GestorVideojuegos.listaJuegos.Add(new Videojuego { nombre = "Resident Evil 3", ventas =2000 });
        }

        private void btnGrafico_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(typeof(VerGrafico));
        }

        private void btnFormulario_Click(object sender, RoutedEventArgs e)
        {
            MenuFrame.Navigate(typeof(Formulario));
        }

        private void Bt_Hamburguesa_Click(object sender, RoutedEventArgs e)
        {
            SplitMenu.IsPaneOpen = !SplitMenu.IsPaneOpen;
        }
    }
}
