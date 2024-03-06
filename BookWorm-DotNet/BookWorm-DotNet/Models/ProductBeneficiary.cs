using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class ProductBeneficiary
{
    public long ProductBeneficiaryId { get; set; }

    public long? BeneficiaryId { get; set; }

    public double? BeneficiaryPercentage { get; set; }

    public long? ProductId { get; set; }

    public virtual Beneficiary? Beneficiary { get; set; }

    public virtual Product? Product { get; set; }
}
