using BookWorm_DotNet.DAL;
using BookWorm_DotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceController(IInvoiceRepository repository)
        {
            _repository = repository;
           
        }

        [HttpGet("getAllInvoice")]
        public ActionResult<List<Invoice>> GetAllInvoice()
        {
            var invoices = _repository.getAllInvoice();
            return Ok(invoices);
        }

        [HttpGet("getById/{id}")]
        public ActionResult<Invoice> GetById(long id)
        {
            var invoice = _repository.getById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        [HttpPost("addInvoice")]
        public  Task<IActionResult> AddInvoice([FromBody] Invoice invoice)
        {

            _repository.addToInvoice(invoice);
            return Task.FromResult<IActionResult>(Ok());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteByInvoiceId(long id)
        {
            _repository.deleteByInvoiceId(id);
            return NoContent();
        }

        [HttpGet("ByCustomerId/{id}")]
        public ActionResult<IEnumerable<Invoice>> GetByCustomerId(long id)
        {
            var invoices = _repository.getByCustomerId(id);
            return Ok(invoices);
        }
    }
}
