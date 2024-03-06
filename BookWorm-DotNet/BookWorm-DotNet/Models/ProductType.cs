using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class ProductType
{
    public int TypeId { get; set; }

    public string TypeDesc { get; set; }

    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
}
