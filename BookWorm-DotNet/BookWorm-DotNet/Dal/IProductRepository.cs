using BookWorm_DotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_DotNet.DAL
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        ActionResult<List<Product>> GetAllProducts();
        ActionResult<Product> GetById(long id);
        Product GetProductById(long id);
        ActionResult<List<Product>> GetProductByType(long typeId);
        ActionResult<List<Product>> GetProductsByTypeAndLang(long typeId, long langId);
        ActionResult<List<Product>> GetProductsByTypeAndGenre(long typeId, long genreId);
    }
}
