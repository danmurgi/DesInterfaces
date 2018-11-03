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
                new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();
                String tableCommand0 = "DROP TABLE IF EXISTS videojuegos";
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS videojuegos (nom_juego varchar(30) PRIMARY KEY NOT NULL)";

                SqliteCommand deleteTable = new SqliteCommand(tableCommand0, db);
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                deleteTable.ExecuteReader();
                createTable.ExecuteReader();
            }
        }

        public static void AddData(string inputText)
        {
            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO videojuegos VALUES (@Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", inputText);

                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        public static List<Videojuego> GetData()
        {
            List<Videojuego> listaVideojuegos = new List<Videojuego>();

            using (SqliteConnection db =
                new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from videojuegos", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    listaVideojuegos.Add(new Videojuego(query.GetString(0)));
                }

                db.Close();
            }

            return listaVideojuegos;
        }
    }
}
