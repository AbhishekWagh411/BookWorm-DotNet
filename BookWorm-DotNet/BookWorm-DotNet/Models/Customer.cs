using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_DotNet.Models;

public partial class Customer
{
    public long CustomerId { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }

    public string? PhoneNo { get; set; }
}
