using System.Collections.Generic;
using System.Threading.Tasks;
using CrudAPI.Domain;
using CrudAPI.Settings;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CrudAPI.Services
{
    public class TodoListService
    {
        private readonly IMongoCollection<Promocion> _collection;

        public TodoListService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);
            _collection = database.GetCollection<Promocion>("Promocion");
        }


        public async Task<Promocion> Insert(Promocion promocion) //Create
        {
            await _collection.InsertOneAsync(promocion);
            return promocion;
        }

        public async Task<Promocion> Update(Promocion promocion) //Update
        {
            await _collection.ReplaceOneAsync(t => t.Id
                                                   == promocion.Id, promocion);
            return promocion;
        }

        public async Task<IList<Promocion>> GetAll() //Read
        {
            return await _collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }


        public async Task<Promocion> GetById(string promocionId) //Read
        {
            return await _collection.FindAsync(t => t.Id == promocionId).Result.FirstOrDefaultAsync();
        }

        public async Task Remove(string promocionId) //Delete
        {
            await _collection.DeleteOneAsync(t => t.Id
                                                  == promocionId);
        }
    }
}