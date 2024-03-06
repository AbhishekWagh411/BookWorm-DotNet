using BookWorm_DotNet.DAL;
using BookWorm_DotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm_DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceDetailController
    {
        private readonly IInvoiceDetailRepository _repository;

        public InvoiceDetailController(IInvoiceDetailRepository repository)
        {
            _repository = repository;

        }
        [HttpPost("add")]
        public void SetInvoiceDetails([FromBody] InvoiceDetail invdtl)
        {
            _repository.setInvoiceDetails(invdtl);
          
        }

     
    }
}
