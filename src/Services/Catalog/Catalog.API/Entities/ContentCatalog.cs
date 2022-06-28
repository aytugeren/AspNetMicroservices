using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class ContentCatalog
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonElement("Place")]
        public string? Place { get; set; }

        public string? BackgroundColor { get; set; }

        public string? BackgroundImage { get; set; }

        public string? ContentTitle { get; set; }

        public string? ContentImage { get; set; }

        public string? ContentBody { get; set; }

        public string? ButtonLink { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public string? ButtonText { get; set; }

        public string? ButtonHtml { get; set; }

        public string? ContentTitleStyleHtml { get; set; }

        public string? ContentHtml { get; set; }

        public string? ContentHtml2 { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
