using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;
namespace ClassLibrary
{
    public class DataAccess
    {
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=DataBase.db"))
            {
                //Abrimos la conexion
                db.Open();

                //Cadenas de texto con las ordenes
                string cadCompanias = "CREATE TABLE IF NOT EXISTS companias " +
                    "(" +
                    "nom_comp varchar(35) PRIMARY KEY NOT NULL," +
                    "fecha_ini TEXT," +
                    "num_trab TEXT)";

                string cadVideojuegos = "CREATE TABLE IF NOT EXISTS videojuegos " +
                    "(" +
                    "nom_juego varchar(30) PRIMARY KEY NOT NULL," +
                    "compania varchar(35)," +
                    "genero varchar(25)," +
                    "plataforma varchar(15)," +
                    "fecha_publi TEXT," +
                    "FOREIGN KEY(compania) REFERENCES compania(nom_comp)" +
                    ")";
            }
        }

        public static void EliminarBase() {
            using (SqliteConnection db = new SqliteConnection("Filename=DataBase.db")) {
                //Abrimos la conexion con la base de datos
                db.Open();

                //Cadenas de texto con las ordenes
                string cadCompanias = "DROP TABLE IF EXISTS companias";
                string cadVideojuegos = "DROP TABLE IF EXISTS videojuegos";

                //Instanciamos los comandos
                SqliteCommand deleteCompanias = new SqliteCommand(cadCompanias, db);
                SqliteCommand deleteVideojuegos = new SqliteCommand(cadVideojuegos, db);

                //Ejecutamos los comandos
                deleteCompanias.ExecuteReader();
                deleteVideojuegos.ExecuteReader();

                //Cerramos la conexion
                db.Close();
            }
        }
        public static void InsertCompanias(String nomComp, String fechaIni, String numTrab) {
            using (SqliteConnection db = new SqliteConnection("Filename=DataBase.db")) {
                //Abrimos la conexion
                db.Open();

                //Instanciamos el comando
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                
                //Parametrizamos el comando
                insertCommand.CommandText = "INSERT INTO companias VALUES(@EntryNom, @EntryFecha, @EntryTrab);";
                insertCommand.Parameters.AddWithValue("@EntryNom", nomComp);
                insertCommand.Parameters.AddWithValue("@EntryFecha", fechaIni);
                insertCommand.Parameters.AddWithValue("@EntryTrab", numTrab);

                insertCommand.ExecuteReader();

                //Cerramos la conexion
                db.Close();
            }
        }

        public static void InsertVideojuegos(String nomJuego, String compania, String genero, String plataforma, String fechaPubli)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=DataBase.db"))
            {
                //Abrimos la conexion
                db.Open();

                //Instanciamos el comando
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Parametrizamos el comando
                insertCommand.CommandText = "INSERT INTO videojuegos VALUES (@EntryNom, @EntryComp, @EntryGen, @EntryPlat, @EntryFecha);";
                insertCommand.Parameters.AddWithValue("@EntryNom", nomJuego);
                insertCommand.Parameters.AddWithValue("@EntryComp", compania);
                insertCommand.Parameters.AddWithValue("@EntryGen", genero);
                insertCommand.Parameters.AddWithValue("@EntryPlat", plataforma);
                insertCommand.Parameters.AddWithValue("@EntryFecha", fechaPubli);

                //Ejecutamos el comando
                insertCommand.ExecuteReader();

                //Cerramos la conexion
                db.Close();
            }

        }
        public static List<Compania> getCompanias()
        {
            //Creamos la lista
            List<Compania> listaCompanias = new List<Compania>();

            using (SqliteConnection db = new SqliteConnection("Filename=DataBase.db"))
            { 
                db.Open();
            
             //Realizamos las consultas
            SqliteCommand selectCommand = new SqliteCommand
                ("SELECT * from companias", db);

            SqliteDataReader query = selectCommand.ExecuteReader();

            //Añadimos cada consulta a la lista
            while (query.Read())
            {
                listaCompanias.Add(new Compania(query.GetString(0), query.GetString(1), query.GetString(2)));
            }

            db.Close();

        }
            return listaCompanias;
        }

        public static List<string> getNomCompanias()
        {
            //Creamos la lista
            List<string> listaCompanias = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=DataBase.db"))
            {
                db.Open();

                //Realizamos las consultas
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT nom_comp from companias", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                //Añadimos cada consulta a la lista
                while (query.Read())
                {
                    listaCompanias.Add(query.GetString(0));
                }

                db.Close();

            }
            return listaCompanias;
        }

        public static List<Videojuego> GetVideojuegos()
        {
            //Creamos la lista
            List<Videojuego> listaVideojuegos = new List<Videojuego>();

            using (SqliteConnection db =
                new SqliteConnection("Filename=DataBase.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from videojuegos", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                //Añadimos cada consulta a la lista
                while (query.Read())
                {
                    listaVideojuegos.Add(new Videojuego(query.GetString(0), query.GetString(1), query.GetString(2), query.GetString(3), query.GetString(4)));
                }

                db.Close();
            }

            return listaVideojuegos;
        }
    }
}
