using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinDefinitivo.Modelos
{
    public class BaseDatos
    {
        readonly SQLiteAsyncConnection database;

        public BaseDatos(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Cita>().Wait();
        }

        public Task<List<Cita>> GetCitas()
        {
            return database.Table<Cita>().ToListAsync();
        }

        public Task<List<Cita>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Cita>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }



        public Task<int> SaveCita(Cita item)
        {
            return database.InsertAsync(item);
        }
        public Task<int> DeleteCita(Cita item)
        {
            return database.DeleteAsync(item);
        }
    }
}
