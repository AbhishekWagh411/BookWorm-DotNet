using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BookWorm_DotNet.Models;
using BookWorm_DotNet.DAL;

namespace BookWorm_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBeneficiaryController : ControllerBase
    {
        private readonly IProductBeneficiaryRepository _repository;

        public ProductBeneficiaryController(IProductBeneficiaryRepository repository)
        {
            _repository = repository;
        }

        // GET: api/ProductBeneficiary
        [HttpGet]
        public ActionResult<IEnumerable<ProductBeneficiary>> GetProductBeneficiaries()
        {
            return _repository.GetAllProductBeneficiaries().ToList();
        }

        // GET: api/ProductBeneficiary/5
        [HttpGet("{id}")]
        public ActionResult<ProductBeneficiary> GetProductBeneficiary(long id)
        {
            var productBeneficiary = _repository.GetProductBeneficiaryById(id);

            if (productBeneficiary == null)
            {
                return NotFound();
            }

            return productBeneficiary;
        }

        // POST: api/ProductBeneficiary
        [HttpPost]
        public ActionResult<ProductBeneficiary> PostProductBeneficiary(ProductBeneficiary productBeneficiary)
        {
            _repository.AddProductBeneficiary(productBeneficiary);

            return CreatedAtAction(nameof(GetProductBeneficiary), new { id = productBeneficiary.ProductBeneficiaryId }, productBeneficiary);
        }

        // PUT: api/ProductBeneficiary/5
        [HttpPut("{id}")]
        public IActionResult PutProductBeneficiary(long id, ProductBeneficiary productBeneficiary)
        {
            if (id != productBeneficiary.ProductBeneficiaryId)
            {
                return BadRequest();
            }

            _repository.UpdateProductBeneficiary(productBeneficiary);

            return NoContent();
        }

        // DELETE: api/ProductBeneficiary/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProductBeneficiary(long id)
        {
            var productBeneficiary = _repository.GetProductBeneficiaryById(id);
            if (productBeneficiary == null)
            {
                return NotFound();
            }

            _repository.DeleteProductBeneficiary(id);

            return NoContent();
        }
    }
}
