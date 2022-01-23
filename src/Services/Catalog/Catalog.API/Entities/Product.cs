namespace Catalog.API.Entities
{
    #region
    using MongoDB.Bson.Serialization.Attributes;
    #endregion

    public class Product
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [BsonElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets Summary
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets ImageFile
        /// </summary>
        public string ImageFile { get; set; }

        /// <summary>
        /// Gets or sets Price
        /// </summary>
        public decimal Price { get; set; }

        #endregion
    }
}
