using System;
using System.Collections.Generic;

namespace BookWorm_DotNet.Models;

public partial class Beneficiary
{
    public long BeneficiaryId { get; set; }

    public string? BeneficiaryAccNo { get; set; }

    public string? BeneficiaryAccType { get; set; }

    public string? BeneficiaryBankBranch { get; set; }

    public string? BeneficiaryBankName { get; set; }

    public string? BeneficiaryContactNo { get; set; }

    public string? BeneficiaryEmailId { get; set; }

    public string? BeneficiaryIFSC { get; set; }

    public string? BeneficiaryName { get; set; }

    public string? BeneficiaryPAN { get; set; }

    public double? TotalEarning { get; set; }

    public ICollection<ProductBeneficiary>? ProductBeneficiaries { get; set; }
}
