using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class InvoiceDetail
{
    public long InvoiceDetailId { get; set; }

    public double BuyAmount { get; set; }

    public int RentDays { get; set; }

    public double RentAmount { get; set; }

    public string TransactionType { get; set; }

    public long InvoiceId { get; set; }

    public long? ProductId { get; set; }

    public int Quantity { get; set; }
}
