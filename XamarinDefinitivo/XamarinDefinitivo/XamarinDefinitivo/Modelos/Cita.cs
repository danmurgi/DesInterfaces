using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;
namespace XamarinDefinitivo.Modelos
{
    public class Cita : INotifyPropertyChanged
    {
        //Evento propertychanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Atributos
        private string _nombre;
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                if (!value.Equals(_nombre))
                {
                    this._nombre = value;
                }
            }
        }
        private string _apellidos;
        public string Apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                if (!value.Equals(_apellidos))
                {
                    this._apellidos = value;
                }
            }
        }
        private string _fechaCita;

        [PrimaryKey]
        public string FechaCita
        {
            get
            {
                return _fechaCita;
            }
            set
            {
                if (!value.Equals(_fechaCita))
                {
                    this._fechaCita = value;
                }
            }
        }
        private string _horaCita;
        public string HoraCita
        {
            get
            {
                return _horaCita;
            }
            set
            {
                if (!value.Equals(_horaCita))
                {
                    this._horaCita = value;
                }
            }
        }
        private string _motivoCita;
        public string MotivoCita
        {
            get
            {
                return _motivoCita;
            }
            set
            {
                if (!value.Equals(_motivoCita))
                {
                    this._motivoCita = value;
                }
            }
        }

        public Cita() { }

        public Cita(string nombre, string apellidos, string fechaCita, string horaCita, string motivoCita)
        {
            this._nombre = nombre;
            this._apellidos = apellidos;
            this._fechaCita = fechaCita;
            this._horaCita = horaCita;
            this._motivoCita = motivoCita;
        }
    }
}
