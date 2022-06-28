using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class Catalog
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [BsonElement("CatalogName")]
        public string? CatalogName { get; set; }

        /// <summary>
        /// Gets or sets CatalogIndex
        /// </summary>
        public string? CatalogIndex { get; set; }

        /// <summary>
        /// Gets or sets CatalogSeoName
        /// </summary>
        public string? CatalogSeoName { get; set; }

        /// <summary>
        /// Gets or sets CatalogPlace
        /// </summary>
        public string? CatalogPlace { get; set; }

        public string? CatalogParentIndex { get; set; }

        public byte[] CatalogImage { get; set; }

        public string CatalogImageUrl { get; set; }


    }
}
