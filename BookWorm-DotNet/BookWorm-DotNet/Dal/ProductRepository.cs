using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_DotNet.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly BookwormContext _bookwormContext;

        public ProductRepository(BookwormContext bookwormContext)
        {
            _bookwormContext = bookwormContext;
        }

        public async Task AddProduct(Product product)
        {
            _bookwormContext.Products.Add(product);
            await _bookwormContext.SaveChangesAsync();
        }

        public ActionResult<List<Product>> GetAllProducts()
        {
            var products = _bookwormContext.Products.ToList();

            if (products == null || products.Count == 0)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(products);
        }

        public ActionResult<Product> GetById(long id)
        {
            var product = _bookwormContext.Products.Find(id);

            if (product == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(product);
        }

        public Product GetProductById(long id)
        {
            Product product = _bookwormContext.Products.Find(id);
            return product;
        }

        public ActionResult<List<Product>> GetProductByType(long typeId)
        {
            var products = _bookwormContext.Products.Where(p => p.TypeId == typeId).ToList();

            if (products == null || products.Count == 0)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(products);
        }

        public ActionResult<List<Product>> GetProductsByTypeAndLang(long typeId, long langId)
        {
            var products = _bookwormContext.Products.Where(p => p.TypeId == typeId && p.LanguageId == langId).ToList();

            if (products == null || products.Count == 0)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(products);
        }

        public ActionResult<List<Product>> GetProductsByTypeAndGenre(long typeId, long genreId)
        {
            var products = _bookwormContext.Products.Where(p => p.TypeId == typeId && p.GenreId == genreId).ToList();

            if (products == null || products.Count == 0)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(products);
        }
    }
}
