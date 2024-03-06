using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class ProductUrl
{
    public int UrlId { get; set; }

    public string Url { get; set; }

    public long ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
