using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class ProductAttribute
{
    public long ProductAttributeId { get; set; }

    public long AttributeId { get; set; }

    public long ProductId { get; set; }

    public string AttributeValue { get; set; }

    public Attribute Attribute { get; set; }

    public Product Product { get; set; }
}
