using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CSharpEgitimKampiMongoDb.Services
{
    public class MongoDbConnection
    {
        private IMongoDatabase _database; // MongoDB veritabanı bağlantısını tutar
        public MongoDbConnection() // Yapıcı metot, MongoDB sunucusuna bağlanır ve veritabanını seçer
        {
            var client = new MongoClient("mongodb://localhost:27017"); // MongoDB sunucusuna bağlan
            _database = client.GetDatabase("CSharpEgitimKampiMongoDb"); // Veritabanını seç
        }
        public IMongoCollection<BsonDocument> GetCustomersCollection() // Müşteri koleksiyonunu döndür
        {
            return _database.GetCollection<BsonDocument>("Customers"); // "Customers" koleksiyonunu alır
        }
    }
}
