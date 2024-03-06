using System;
using System.Collections.Generic;
using System.Linq;
using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_DotNet.DAL
{
    public interface IProductBeneficiaryRepository
    {
        IEnumerable<ProductBeneficiary> GetAllProductBeneficiaries();
        ProductBeneficiary GetProductBeneficiaryById(long id);
        void AddProductBeneficiary(ProductBeneficiary productBeneficiary);
        void UpdateProductBeneficiary(ProductBeneficiary productBeneficiary);
        void DeleteProductBeneficiary(long id);
        IEnumerable<ProductBeneficiary> GetByProductId(long id);
    }

    
}
