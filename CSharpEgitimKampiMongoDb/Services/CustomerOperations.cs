using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpEgitimKampiMongoDb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

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

        public List<Customer> GetAllCustomer()
        {
            var connection = new MongoDbConnection(); // MongoDB bağlantısını metoduna erişim sağlar
            var customerCollection = connection.GetCustomersCollection(); // Müşteri tablosune erişim sağlar
            var customers = customerCollection.Find(new BsonDocument()).ToList(); // Müşteri koleksiyonundaki tüm belgeleri hafızaya alır
            List<Customer> customersList = new List<Customer>(); // boş bir Müşteri listesini oluşturur
            foreach (var c in customers) // Her bir müşteri belgesi için döngü başlatır bunun verilerini çekeceği yer ise  customers koleksiyonudur
            {
                customersList.Add(new Customer // oluşturduğumuz boş customerlist nesnesine customers verilerini ekle
                {
                    CustomerId = c["_id"].ToString(), // MongoDB'deki _id alanını CustomerId olarak alır neden _id çünkü MongoDB'de her belge için benzersiz bir kimlik alanı vardır
                    CustomerName = c["CustomerName"].ToString(), // MongoDB'deki CustomerName alanını CustomerName olarak alır 
                    CustomerSurname = c["CustomerSurname"].ToString(), // MongoDB'deki CustomerSurname alanını CustomerSurname olarak alır
                    CustomerCity = c["CustomerCity"].ToString(), // MongoDB'deki CustomerCity alanını CustomerCity olarak alır
                    CustomerBalance = decimal.Parse( c["CustomerBalance"].ToString()), // MongoDB'deki CustomerBalance alanını decimal olarak alır
                    CustomerShoppingCount = int.Parse( c["CustomerShoppingCount"].ToString()) // MongoDB'deki CustomerShoppingCount alanını int olarak alır

                });
            }
            return customersList; // Müşteri listesini döndürür


        }

        public void DeleteCustomer(string id)
        {
            var connection = new MongoDbConnection();
            // MongoDB bağlantısını oluştur
            var customerCollection = connection.GetCustomersCollection(); // Müşteri koleksiyonunu al
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id)); // Silinecek müşteri belgesini bulmak için filtre oluşturur
            customerCollection.DeleteOne(filter); // Belirtilen filtreye uyan ilk belgeyi siler

        }

        public void UpdateCustomer(Customer customer)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(customer.CustomerId)); // Güncellenecek müşteri belgesini bulmak için filtre oluşturur
            var updateValue = Builders<BsonDocument>.Update. // Güncelleme işlemi için değerleri ayarlar
                Set("CustomerName", customer.CustomerName) // CustomerName özelliğini günceller
                .Set("CustomerSurname", customer.CustomerSurname) // CustomerSurname özelliğini günceller
                .Set("CustomerCity", customer.CustomerCity) // CustomerCity özelliğini günceller
                .Set("CustomerBalance", customer.CustomerBalance) // CustomerBalance özelliğini günceller
                .Set("CustomerShoppingCount", customer.CustomerShoppingCount); // CustomerShoppingCount özelliğini günceller

            customerCollection.UpdateOne(filter, updateValue); // Belirtilen filtreye uyan ilk belgeyi günceller
        }

        public Customer GetById(string id)
        {
            var connection = new MongoDbConnection();
            var connectionCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id",ObjectId.Parse(id)); // Belirtilen id'ye göre filtre oluşturur
            var result = connectionCollection.Find(filter).FirstOrDefault(); // Filtreye uyan ilk belgeyi bulur
            return new Customer
            {
                CustomerBalance = decimal.Parse(result["CustomerBalance"].ToString()), // CustomerBalance özelliğini alır
                CustomerCity = result["CustomerCity"].ToString(), // CustomerCity özelliğini alır
                CustomerId = id, // CustomerId özelliğini alır
                CustomerName = result["CustomerName"].ToString(), // CustomerName özelliğini alır
                CustomerSurname = result["CustomerSurname"].ToString(), // CustomerSurname özelliğini alır
                CustomerShoppingCount = int.Parse(result["CustomerShoppingCount"].ToString()) // CustomerShoppingCount özelliğini alır

            };
        }
    }
}
