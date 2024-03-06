using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class Attribute
{
    public long AttributeId { get; set; }

    public string? AttributeDesc { get; set; }

    public ICollection<ProductAttribute> ProductAttributes { get; set; }
}
