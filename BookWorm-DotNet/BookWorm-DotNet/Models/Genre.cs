using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class Genre
{
    public long GenreId { get; set; }

    public string GenreDesc { get; set; }

    public ICollection<Product> Products { get; set; }
}
