using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;
using Microsoft.EntityFrameworkCore;


namespace BookWorm_DotNet.DAL
{

    public class ProductBeneficiaryRepository : IProductBeneficiaryRepository
    {
        private readonly BookwormContext _context;

        public ProductBeneficiaryRepository(BookwormContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductBeneficiary> GetAllProductBeneficiaries()
        {
            return _context.ProductBeneficiaries.ToList();
        }

        public ProductBeneficiary GetProductBeneficiaryById(long id)
        {
            return _context.ProductBeneficiaries.Find(id);
        }

        public void AddProductBeneficiary(ProductBeneficiary productBeneficiary)
        {
            _context.ProductBeneficiaries.Add(productBeneficiary);
            _context.SaveChanges();
        }

        public void UpdateProductBeneficiary(ProductBeneficiary productBeneficiary)
        {
            _context.Entry(productBeneficiary).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProductBeneficiary(long id)
        {
            var productBeneficiary = _context.ProductBeneficiaries.Find(id);
            if (productBeneficiary != null)
            {
                _context.ProductBeneficiaries.Remove(productBeneficiary);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Product Beneficiary not found");
            }
        }

        public IEnumerable<ProductBeneficiary> GetByProductId(long id)
        {
            return _context.ProductBeneficiaries.Where(pb => pb.ProductId == id).ToList();
        }
    }
}