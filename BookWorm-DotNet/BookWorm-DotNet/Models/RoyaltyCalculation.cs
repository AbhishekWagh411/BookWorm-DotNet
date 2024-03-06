using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class RoyaltyCalculation
{
    public long RoyaltyCalculationId { get; set; }

    public double? BasePrice { get; set; }

    public long? BeneficiaryId { get; set; }

    public long? InvoiceId { get; set; }

    public long? ProductId { get; set; }

    public DateTime? RoyaltyCalculationDate { get; set; }

    public double? RoyaltyOnBasePrice { get; set; }

    public double? SalePrice { get; set; }

    public string? TransactionType { get; set; }
}
