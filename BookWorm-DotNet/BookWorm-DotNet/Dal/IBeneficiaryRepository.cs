using System;
using System.Collections.Generic;
using System.Linq;
using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_DotNet.DAL
{
    public interface IBeneficiaryRepository
    {
        IEnumerable<Beneficiary> GetAllBeneficiaries();
        Beneficiary GetBeneficiaryById(long id);
        void AddBeneficiary(Beneficiary beneficiary);
        void UpdateBeneficiary(Beneficiary beneficiary);
        void DeleteBeneficiary(long id);
    }

    
}
