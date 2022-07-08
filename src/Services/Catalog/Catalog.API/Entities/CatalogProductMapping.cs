using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class CatalogProductMapping
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? CatalogId { get; set; }

        public List<string>? Products { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
