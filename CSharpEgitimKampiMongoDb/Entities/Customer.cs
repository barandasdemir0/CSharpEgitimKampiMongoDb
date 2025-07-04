using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CSharpEgitimKampiMongoDb.Entities
{
    public class Customer
    {
        [BsonId] // Bu öznitelik, bu özelliğin MongoDB belgesi için birincil anahtar olduğunu belirtir
        [BsonRepresentation(BsonType.ObjectId)]// Bu öznitelik, özelliğin MongoDB'de ObjectId olarak saklanacağını belirtir
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerCity { get; set; }
        public decimal CustomerBalance { get; set; }
        public int CustomerShoppingCount { get; set; }
    }
}
