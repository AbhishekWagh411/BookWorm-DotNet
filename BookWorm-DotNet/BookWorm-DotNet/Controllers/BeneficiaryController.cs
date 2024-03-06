using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookWorm_DotNet.Models;
using BookWorm_DotNet.DAL;

namespace BookWorm_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IBeneficiaryRepository _repository;

        public BeneficiaryController(IBeneficiaryRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Beneficiary
        [HttpGet]
        public ActionResult<IEnumerable<Beneficiary>> GetAllBeneficiaries()
        {
            var beneficiaries = _repository.GetAllBeneficiaries();
            return Ok(beneficiaries);
        }

        // GET: api/Beneficiary/5
        [HttpGet("{id}")]
        public ActionResult<Beneficiary> GetBeneficiaryById(long id)
        {
            var beneficiary = _repository.GetBeneficiaryById(id);
            if (beneficiary == null)
            {
                return NotFound();
            }
            return Ok(beneficiary);
        }

        // POST: api/Beneficiary
        [HttpPost]
        public IActionResult AddBeneficiary(Beneficiary beneficiary)
        {
            _repository.AddBeneficiary(beneficiary);
            return CreatedAtAction(nameof(GetBeneficiaryById), new { id = beneficiary.BeneficiaryId }, beneficiary);
        }

        // PUT: api/Beneficiary/5
        [HttpPut("{id}")]
        public IActionResult UpdateBeneficiary(long id, Beneficiary beneficiary)
        {
            if (id != beneficiary.BeneficiaryId)
            {
                return BadRequest();
            }

            _repository.UpdateBeneficiary(beneficiary);
            return NoContent();
        }

        // DELETE: api/Beneficiary/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBeneficiary(long id)
        {
            _repository.DeleteBeneficiary(id);
            return NoContent();
        }
    }
}
