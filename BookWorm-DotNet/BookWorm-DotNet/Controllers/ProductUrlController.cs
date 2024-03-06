using BookWorm_DotNet.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductUrlController : ControllerBase
    {

      private readonly IProductUrlRepository _repository;

        public ProductUrlController(IProductUrlRepository repository)
        {
            _repository = repository;

        }

        [HttpGet("{productId}")]
        public IActionResult GetProductUrl(int productId)
        {
            var url = _repository.getUrlByProductId(productId);
            if (url == null)
            {
                return NotFound();
            }

            return Ok(url);
        }
    }

}
