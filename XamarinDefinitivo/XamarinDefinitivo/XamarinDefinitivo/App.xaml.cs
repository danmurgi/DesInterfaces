using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDefinitivo.Modelos;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinDefinitivo
{ 
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            //Añadimos una cita de prueba
            DataBase.SaveCita(new Cita("Kevin", "Martínez", "fecha", "hora", "urgencia"));
        }

        static BaseDatos database;
        

        public static BaseDatos DataBase
        {
            get
            {
                if (database == null)
                {
                    database = new BaseDatos(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bbdd.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
