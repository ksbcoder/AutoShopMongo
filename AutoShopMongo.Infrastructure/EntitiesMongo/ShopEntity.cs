using MongoDB.Bson.Serialization.Attributes;

namespace AutoShopMongo.Infrastructure.EntitiesMongo
{
    public class ShopEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Shop_id { get; set; }

        public string Name_shop { get; set; }
        public string Address_shop { get; set; }
        public string Phone_shop { get; set; }
        public bool State_shop { get; set; }
    }
}
