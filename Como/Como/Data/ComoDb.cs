using Como.Model;
using SQLite;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Como.Data
{
    public class ComoDb
    {
        readonly SQLiteAsyncConnection database;

        public ComoDb(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Dica>().Wait();
        }

        public Task<List<Dica>> GetUsuarioAsync()
        {
            return database.Table<Dica>().ToListAsync();
        }

        public Task<List<Dica>> GetItemsActiveAsync()
        {
            return database.QueryAsync<Dica>("SELECT * FROM [Dica] WHERE [Ativo] = 1");
        }

        public int UpsertItemSync(Dica item)
        {
            return database.InsertOrReplaceAsync(item).Result;
        }

        public List<Dica> GetItemsSync()
        {
            var dicas = database.Table<Dica>().ToListAsync().Result;

            return dicas;
        }

        public Task<Dica> GetItemAsync(int id)
        {
            var usuario = database.Table<Dica>().Where(i => i.ID == id).FirstOrDefaultAsync();

            return usuario;
        }

        public Task<int> DeleteItemAsync(Dica item)
        {
            return database.DeleteAsync(item);
        }
    }
}
