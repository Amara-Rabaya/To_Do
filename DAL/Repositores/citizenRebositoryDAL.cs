using DAL.DataBase;
using DAL.Interface;
using DAL.ModelsNew;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositores
{
    public class citizenRebositoryDAL : IcitizenRebositoryDAL
    {
        private readonly IMongoCollection<Citizen> _collection;

        public citizenRebositoryDAL(IOptions<MongoDbSettings> settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Citizen>("Citizen"); // Collection name
        }

        public async Task<List<Citizen>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Citizen> GetByIdAsync(int id)
        {
            return await _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Citizen citizen)
        {
            await _collection.InsertOneAsync(citizen);
        }

        public async Task UpdateAsync(int id, Citizen citizen)
        {
            await _collection.ReplaceOneAsync(c => c.Id == id, citizen);
        }

        public async Task DeleteAsync(int id)
        {
            await _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
