using BookWorm_DotNet.DAL;
using BookWorm_DotNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            await _repository.AddProduct(product);

            return CreatedAtAction("GetProductById", new { id = product.ProductId }, product);
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        [HttpGet("type/{typeId}")]
        public ActionResult<List<Product>> GetProductByType(long typeId)
        {
            return _repository.GetProductByType(typeId);
        }

        // GET: api/Products/type/{typeId}/language/{langId}
        [HttpGet("type/{typeId}/language/{langId}")]
        public ActionResult<List<Product>> GetProductsByTypeAndLang(long typeId, long langId)
        {
            return _repository.GetProductsByTypeAndLang(typeId, langId);
        }

        [HttpGet("id/{id}")]
        public ActionResult<Product> GetById(long id)
        {
            var product = _repository.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpGet("type/{typeId}/genre/{genreId}")]
        public ActionResult<List<Product>> GetProductsByTypeAndGenre(long typeId, long genreId)
        {
            return _repository.GetProductsByTypeAndGenre(typeId, genreId);
        }

    }

    
}
