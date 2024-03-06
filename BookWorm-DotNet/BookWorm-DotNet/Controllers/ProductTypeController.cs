    using BookWorm_DotNet.DAL;
    using BookWorm_DotNet.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    namespace Bookworm.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductTypeController : ControllerBase
        {
            private readonly IProductTypeRepository _productTypeService;

            public ProductTypeController(IProductTypeRepository productTypeService)
            {
                _productTypeService = productTypeService;
            }

            [HttpGet("getAll")]
            public ActionResult<IEnumerable<ProductType>> GetAllProducts()
            {
                var products = _productTypeService.getAllProducts();
                return Ok(products);
            }

            [HttpDelete("delete/{pid}")]
            public IActionResult DeleteProduct(int pid)
            {
                _productTypeService.delete(pid);
                return NoContent();
            }

            [HttpPut("update/{pid}")]
            public IActionResult UpdateProduct(int pid, [FromBody] ProductType product)
            {
                _productTypeService.update(product, pid);
                return NoContent();
            }

            [HttpPost("add")]
            public IActionResult AddProduct([FromBody] ProductType product)
            {
                _productTypeService.addProductType(product);
                return CreatedAtAction(nameof(GetAllProducts), product);
            }

            // Implement other endpoints as needed
        }
    }

