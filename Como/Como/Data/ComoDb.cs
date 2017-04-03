using Como.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Como.Data
{
    public class ComoDb
    {
        readonly SQLiteAsyncConnection database;

        public ComoDb(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Fruta>().Wait();
        }

        public Task<List<Fruta>> GetUsuarioAsync()
        {
            return database.Table<Fruta>().ToListAsync();
        }

        public Task<List<Fruta>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Fruta>("SELECT * FROM [UsuarioModel] WHERE [Done] = 0");
        }

        public Task<Fruta> GetItemAsync(int id)
        {
            var usuario = database.Table<Fruta>().Where(i => i.ID == id).FirstOrDefaultAsync();

            return usuario;
        }

        public Task<int> SaveItemAsync(Fruta item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Fruta item)
        {
            return database.DeleteAsync(item);
        }
    }
}
