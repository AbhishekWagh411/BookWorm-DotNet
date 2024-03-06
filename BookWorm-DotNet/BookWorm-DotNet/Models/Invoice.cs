using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class Invoice
{
    public long InvoiceId { get; set; }

    public double InvoiceAmount { get; set; }

    public DateTime InvoiceDate { get; set; }

    public long? CustomerId { get; set; }

    public double BuyAmount { get; set; }

    public long ProductId { get; set; }

    public string ProductName { get; set; }

    public double RentAmount { get; set; }

    public string TransactionType { get; set; }
}
