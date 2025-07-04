using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpEgitimKampiMongoDb.Entities;
using MongoDB.Bson;

namespace CSharpEgitimKampiMongoDb.Services
{
    public class CustomerOperations
    {
        public void AddCustomer(Customer customer)
        {
            var connection = new MongoDbConnection(); // MongoDB bağlantısını oluştur
            var customerCollection = connection.GetCustomersCollection(); // Müşteri koleksiyonunu al

            var document = new BsonDocument //ekleme işlemi parametrelerini gireceğiz
            {
                {"CustomerName",customer.CustomerName }, //buranın CustomerName özelliğini MongoDB'de CustomerName olarak saklayacağız
                {"CustomerSurname", customer.CustomerSurname }, // buranın CustomerSurname özelliğini MongoDB'de CustomerSurname olarak saklayacağız
                {"CustomerCity", customer.CustomerCity }, // bura CustomerCity özelliğini MongoDB'de CustomerCity olarak saklayacağız
                {"CustomerBalance", customer.CustomerBalance }, // bura CustomerBalance özelliğini MongoDB'de CustomerBalance olarak saklayacağız
                {"CustomerShoppingCount", customer.CustomerShoppingCount } // bura CustomerShoppingCount özelliğini MongoDB'de CustomerShoppingCount olarak saklayacağız
                
            };
            customerCollection.InsertOne(document); // dokümana eklediğimiz verileri ınsert one ile mongoDB'ye ekle
        }
    }
}
