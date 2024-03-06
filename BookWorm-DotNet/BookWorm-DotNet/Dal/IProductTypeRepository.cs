using BookWorm_DotNet.Models;

namespace BookWorm_DotNet.DAL
{
    public interface IProductTypeRepository
    {

        List<ProductType> getAllProducts();

        ProductType addProductType(ProductType pro);

        ProductType delete(int id);

        void update(ProductType p, int id);
    }
}
