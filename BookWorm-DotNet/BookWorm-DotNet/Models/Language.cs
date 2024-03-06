using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class Language
{
    public long LanguageId { get; set; }

    public string? LanguageDesc { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
