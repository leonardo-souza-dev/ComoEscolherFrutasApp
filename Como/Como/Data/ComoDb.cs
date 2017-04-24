using Como.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Como.Data
{
    public class ComoDb
    {
        readonly SQLiteAsyncConnection database;
        readonly SQLiteConnection database2;

        public ComoDb(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Dica>().Wait();

            database2 = new SQLiteConnection(dbPath);
            database2.CreateTable<Dica>();
        }

        #region Síncronos

        public List<Dica> ObterDicasSync()
        {
            //var dicas = database.Table<Dica>().ToListAsync().Result; //ASYNC

            var dicas2a = database2.Table<Dica>();
            var dicas2b = new List<Dica>();
            foreach (var item in dicas2a) dicas2b.Add(item);

            return dicas2b;
        }

        public int UpsertDicaSync(Dica item)
        {
            //return database.InsertOrReplaceAsync(item).Result; //ASYNC

            var resultado = database2.InsertOrReplace(item);
            return resultado;
        }

        public Dica GetItemSync(int pk)
        {
            var dica = database2.Find<Dica>(pk);

            return dica;
        }

        #endregion

        #region Assíncronos

        public Task<List<Dica>> GetDicaAsync()
        {
            return database.Table<Dica>().ToListAsync();
        }

        public Task<List<Dica>> GetItemsActiveAsync()
        {
            return database.QueryAsync<Dica>("SELECT * FROM [Dica] WHERE [Ativo] = 1");
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

        #endregion
    }
}
