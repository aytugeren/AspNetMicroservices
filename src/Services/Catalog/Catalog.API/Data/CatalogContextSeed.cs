namespace Catalog.API.Data
{
    #region
    using Catalog.API.Entities;
    using Catalog.API.Entities.Enums;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// The static CatalogContextSeed
    /// </summary>
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection, IMongoCollection<Catalog> catalogCollection, IMongoCollection<ContentCatalog> contentCatalogCollection)
        {
            bool existProduct = productCollection.Find(s => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }

            bool existCatalog = catalogCollection.Find(s => true).Any();
            if (!existCatalog)
            {
                catalogCollection.InsertManyAsync(GetPreconfiguredCatalogs());
            }

            bool existContentCatalog = contentCatalogCollection.Find(s => true).Any();
            if (!existContentCatalog)
            {
                contentCatalogCollection.InsertManyAsync(GetPreconfiguredContentCatalog());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "IPhone X",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Samsung 10",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Huawei Plus",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Xiaomi Mi 9",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = "White Appliances"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "HTC U11+ Plus",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "LG G7 ThinQ",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = "Home Kitchen"
                }
            };
        }

        private static IEnumerable<Catalog> GetPreconfiguredCatalogs()
        {
            return new List<Catalog>()
            {
                new Catalog()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    CatalogName = "Kadın",
                    CatalogIndex = "1",
                    CatalogSeoName = "/kadin",
                    CatalogParentIndex = string.Empty,
                    CatalogPlace = CatalogPlaceEnum.Header.ToString()
                },
                new Catalog()
                {
                    Id = "602d2149e773f2a3990b4345",
                    CatalogName = "Erkek",
                    CatalogIndex = "2",
                    CatalogSeoName = "/erkek",
                    CatalogParentIndex = string.Empty,
                    CatalogPlace = CatalogPlaceEnum.Header.ToString()
                },
                new Catalog()
                {
                    Id = "602d2149e773f2a3990b4348",
                    CatalogName = "Tişört",
                    CatalogIndex = "5",
                    CatalogSeoName = "/erkek-tisort",
                    CatalogParentIndex = "2",
                    CatalogPlace = CatalogPlaceEnum.HeaderSub.ToString()
                },
                new Catalog()
                {
                    Id = "602d2149e773f2a3990b4346",
                    CatalogName = "Çocuk",
                    CatalogIndex = "3",
                    CatalogSeoName = "/cocuk",
                    CatalogParentIndex = string.Empty,
                    CatalogPlace = CatalogPlaceEnum.Header.ToString()
                },
                new Catalog()
                {
                    Id = "602d2149e773f2a3990b4347",
                    CatalogName = "Diğer",
                    CatalogIndex = "4",
                    CatalogSeoName = "/diger-urunler",
                    CatalogParentIndex = string.Empty,
                    CatalogPlace = CatalogPlaceEnum.Header.ToString()
                }
            };
        }

        private static IEnumerable<ContentCatalog> GetPreconfiguredContentCatalog()
        {
            var a = new List<ContentCatalog>()
            {
                new ContentCatalog
                {
                    Id = "602d2149e773f2a3990b38f5",
                    ContentImage = "v1656078532/bannerTaki_rqbrhz.jpg",
                    BackgroundColor = "#F6F6F6",
                    BackgroundImage = string.Empty,
                    ContentTitleStyleHtml = "color: #333; max-width: 430px; line-height: 1.15;",
                    ContentBody = string.Empty,
                    ContentHtml = "Yaz Ayına Özel<br>Koleksiyonlar",
                    ContentHtml2 = "Bu yazın en popüler takılarını sizler için derledik.",
                    IsActive = true,
                    IsDeleted = false,
                    ContentTitle = string.Empty,
                    ButtonLink = "localhost:28520/#",
                    ButtonHtml = "<span>İncele</span> <i class=\"icon-angle-right\"></i>",
                    ButtonText = "İncele",
                    Place = CatalogContentEnum.Header.ToString(),
                    DisplayOrder = 1
                },
                new ContentCatalog
                {
                    Id = "602d2149e773f2a3990b39f5",
                    ContentImage ="v1656447711/GoldRingHomePage_kahqnf.jpg",
                    ButtonHtml = "col-md-3 min-vh-25 min-vh-md-0",
                    Place = CatalogContentEnum.HeaderSub.ToString(),
                    ButtonLink = "localhost:28520/deneme",
                    IsActive = true,
                    IsDeleted = false,
                    DisplayOrder = 1
                },
                new ContentCatalog
                {
                    Id = "602d2149e773f2a3990b40f5",
                    ContentImage = "v1656447645/GoldNecklaceHomePage_nvjjyd.jpg",
                    ButtonHtml = "col-md-3 min-vh-25 min-vh-md-0",
                    Place = CatalogContentEnum.HeaderSub.ToString(),
                    ButtonLink = "localhost:28520/deneme",
                    IsActive = true,
                    IsDeleted = false,
                    DisplayOrder = 2
                },
                new ContentCatalog
                {
                    Id = "602d2149e773f2a3990b41f5",
                    ContentImage ="v1656447642/GoldBraceletHomePage_esy5id.jpg",
                    ButtonHtml = "col-md-3 min-vh-25 min-vh-md-0",
                    Place = CatalogContentEnum.HeaderSub.ToString(),
                    ButtonLink = "localhost:28520/deneme",
                    IsActive = true,
                    IsDeleted = false,
                    DisplayOrder = 3
                },
                new ContentCatalog
                {
                    Id = "602d2149e773f2a3990b42f5",
                    ContentImage = "v1656439830/GoldSetHomePage_h8jub9.jpg",
                    ButtonHtml = "col-md-3 min-vh-25 min-vh-md-0",
                    Place = CatalogContentEnum.HeaderSub.ToString(),
                    ButtonLink = "localhost:28520/deneme",
                    IsActive = true,
                    IsDeleted = false,
                    DisplayOrder = 4
                }
            };

            return a;
        }
    }
}
