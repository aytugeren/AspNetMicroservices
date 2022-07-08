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
        public static void SeedData(IMongoCollection<Product> productCollection, IMongoCollection<Catalog> catalogCollection, IMongoCollection<ContentCatalog> contentCatalogCollection, IMongoCollection<CatalogProductMapping> catalogProductMapping)
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

            bool existCatalogProductMapping = catalogProductMapping.Find(s => true).Any();
            if (!existCatalogProductMapping)
            {
                catalogProductMapping.InsertManyAsync(GetPreconfiguredCatalogProductMapping());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Kırmızı Taşlı 14 Ayar Altın Kolye",
                    Summary = "14 Ayar Altin Kolye ",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ProductSeoName = "kirmizi-tasli-altin-kolye",
                    ProductVariantIndex = 1,
                    Price = 1200.00M,
                    CampaignPrice = 100.00M,
                    DiscountedPrice = 1100.00M,
                    CampaignType = CampaignTypeEnum.Total.ToString(),
                    ProductImage = "v1656871077/Products/Neackle/Necklet-1_tsc07c.png"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Yıldız Motifli Doğal Taş Beyaz Altın Kolye",
                    Summary = "14 Ayar Altin Kolye ",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ProductSeoName = "yildiz-motifli-altin-kolye",
                    ProductVariantIndex = 2,
                    Price = 900.00M,
                    CampaignPrice = 50.00M,
                    DiscountedPrice = 850.00M,
                    CampaignType = CampaignTypeEnum.Total.ToString(),
                    ProductImage = "v1656871707/Products/Neackle/Necklet-2_r8al5n.png"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Altın Sarısı İsimli Kelepçe",
                    Summary = "14 Ayar Altin Bileklik ",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ProductSeoName = "altin-sarisi-isimli-bileklik",
                    ProductVariantIndex = 3,
                    Price = 450.00M,
                    CampaignPrice = null,
                    DiscountedPrice = null,
                    CampaignType = null,
                    ProductImage = "v1656871759/Products/Bracalet/Bracalet-6_ez39y6.png"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Sonsuzluk Motifli İsimli Altın Bileklik",
                    Summary = "14 Ayar Altin Bileklik ",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ProductSeoName = "sonsuzluk-motifli-isimli-altin-bileklik",
                    ProductVariantIndex = 4,
                    Price = 560.00M,
                    CampaignPrice = null,
                    DiscountedPrice = null,
                    CampaignType = null,
                    ProductImage = "v1656871761/Products/Bracalet/Bracalet-5_nuhjkb.png"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Sıralı Doğal Taşlı Altın Yüzük",
                    Summary = "14 Ayar Altin Yüzük ",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ProductSeoName = "sirali-dogal-tasli-altin-yuzuk",
                    ProductVariantIndex = 5,
                    Price = 670.00M,
                    CampaignPrice = 20.00M,
                    DiscountedPrice = 536.00M,
                    CampaignType = CampaignTypeEnum.Percentage.ToString(),
                    ProductImage = "v1656871740/Products/Ring/Ring-4_glnfc0.png"
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "Narin Tek ve Doğal Taşlı Altın Yüzük",
                    Summary = "14 Ayar Altin Yüzük ",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ProductSeoName = "narin-tek-ve-dogal-tasli-altin-yuzuk",
                    ProductVariantIndex = 6,
                    Price = 670.00M,
                    CampaignPrice = 20.00M,
                    DiscountedPrice = 536.00M,
                    CampaignType = CampaignTypeEnum.Percentage.ToString(),
                    ProductImage = "v1656871741/Products/Ring/Ring-3_vwtpne.png"                
                },
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
                    ContentImage = "v1656505745/GoldHomePageSliderDone_mloiyl.jpg",
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

        private static IEnumerable<CatalogProductMapping> GetPreconfiguredCatalogProductMapping()
        {
            return new List<CatalogProductMapping>() {
                new CatalogProductMapping()
                {
                    CatalogId = "602d2149e773f2a3990b47f5",
                    Products = new List<string>() { "602d2149e773f2a3990b47f5", "602d2149e773f2a3990b47f6", "602d2149e773f2a3990b47f7" },
                    IsActive = true,
                    IsDeleted = false
                },
                new CatalogProductMapping()
                {
                    CatalogId = "602d2149e773f2a3990b4345",
                    Products = new List<string> { "602d2149e773f2a3990b47f8", "602d2149e773f2a3990b47f9", "602d2149e773f2a3990b47fa" },
                    IsActive = true,
                    IsDeleted = false
                }
            };
        }
    }
}
