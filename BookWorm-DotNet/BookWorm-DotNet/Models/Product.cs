using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class Product
{
    public long ProductId { get; set; }

    public bool IsRentable { get; set; }

    public int MinRentDays { get; set; }

    public string Author { get; set; }

    public double Baseprice { get; set; }

    public string DescriptionLong { get; set; }

    public string DescriptionShort { get; set; }

    public string EnglishName { get; set; }

    public string Isbn { get; set; }

    public string Name { get; set; }

    public DateTime OfferPriceExpirydate { get; set; }

    public double Offerprice { get; set; }

    public string Publisher { get; set; }

    public double SalePrice { get; set; }

    public double RentPerDay { get; set; }

    public long? GenreId { get; set; }

    public long? LanguageId { get; set; }

    public int? TypeId { get; set; }

    public Genre? Genre { get; set; }

    public Language? Language { get; set; }

    public ICollection<ProductAttribute>? ProductAttributes { get; set; }

    public ICollection<ProductBeneficiary>? ProductBeneficiaries { get; set; }

    public ProductUrl? ProductUrl { get; set; }

    public ProductType? Type { get; set; }
}
