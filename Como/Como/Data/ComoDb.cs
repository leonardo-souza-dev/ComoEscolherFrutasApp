﻿using Como.Model;
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
            database.CreateTableAsync<Dica>().Wait();
        }

        public Task<List<Dica>> GetUsuarioAsync()
        {
            return database.Table<Dica>().ToListAsync();
        }

        public Task<List<Dica>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Dica>("SELECT * FROM [UsuarioModel] WHERE [Done] = 0");
        }

        public Task<Dica> GetItemAsync(int id)
        {
            var usuario = database.Table<Dica>().Where(i => i.ID == id).FirstOrDefaultAsync();

            return usuario;
        }

        public Task<int> SaveItemAsync(Dica item)
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

        public Task<int> DeleteItemAsync(Dica item)
        {
            return database.DeleteAsync(item);
        }
    }
}
