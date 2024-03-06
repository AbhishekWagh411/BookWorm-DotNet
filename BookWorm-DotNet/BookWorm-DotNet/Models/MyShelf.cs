using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class MyShelf
{
    public long ShelfId { get; set; }

    public long CustomerId { get; set; }

    public DateTime? ProductExpiryDate { get; set; }

    public string TransactionType { get; set; }

     public long BuyId { get; set; }

    public double PriceAmount { get; set; }

    public string ProductName { get; set; }

    public long RentId { get; set; }

    public double TotalAmount { get; set; }
}
