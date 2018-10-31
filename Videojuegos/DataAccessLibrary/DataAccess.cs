using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Cargamos el recurso de la base de datos
using Microsoft.Data.Sqlite;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        public static void InicializarBase()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=Base.bd"))
            {
                db.Open();
                String comandoTablas = "CREATE TABLE IF NOT EXISTS videojuegos(" +
                    "nombre text primary key)";
                // "cod integer primary key," +

                //Creamos un comando paracrear la tabla con la orden y la base de datos
                SqliteCommand crearTabla = new SqliteCommand(comandoTablas, db);

                //Ejecutamos el comando
                crearTabla.ExecuteReader();
            }
        }
        public static void insertarDatos(string cadena)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=Base.db"))
            {
                db.Open();
                SqliteCommand insertarComando = new SqliteCommand();
                insertarComando.Connection = db;

                //Creamos la orden de insertar datos en la tabla
                insertarComando.CommandText = "INSERT INTO videojuegos VALUES (NULL, @Entry)";
                insertarComando.Parameters.AddWithValue("@Entry", cadena);

                //Ejecutamos la orden dee insercion
                insertarComando.ExecuteReader();

                //Cerramos la base de datos
                db.Close();
            }
        }
        public static List<string> GetData()
        {
            List<string> entradas = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=Base.db"))
            {
                //Abrimos la conexion a la base de datos
                db.Open();

                //Declarando el comando de la consulta
                SqliteCommand selectCommand = new SqliteCommand("SELECT * from videojuegos", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                //Si se puede leer añadimos los datos especificados a la lista
                while (query.Read())
                {
                    //Videojuego juego = new Videojuego(/*query.GetInt32(0), */query.GetString(1));
                    entradas.Add(query.GetString(0));
                }

                //Cerramos la conexion
                db.Close();
            }
            return entradas;

        }
    }
}

