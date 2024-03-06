using BookWorm_DotNet.DAL;
using BookWorm_DotNet.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookWorm_DotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyShelfController : Controller
    {
        private readonly IMyShelfRepository myShelfRepository;
        private readonly IRoyaltyCalculationRepository royaltyCalculationRepository;
        private readonly IProductBeneficiaryRepository productBeneficiaryRepository;
        private readonly IProductRepository productRepository;
        private readonly IBeneficiaryRepository beneficiaryRepository;
        public MyShelfController(IMyShelfRepository myShelfRepository, IRoyaltyCalculationRepository royaltyCalculationRepository, IProductBeneficiaryRepository productBeneficiaryRepository, IProductRepository productRepository, IBeneficiaryRepository beneficiaryRepository )
        {
            this.myShelfRepository = myShelfRepository;
            this.royaltyCalculationRepository = royaltyCalculationRepository;
            this.productBeneficiaryRepository = productBeneficiaryRepository;
            this.beneficiaryRepository = beneficiaryRepository;
            this.productRepository = productRepository;
        }


        [HttpGet("{customerId}")]
        public IActionResult GetMyShelfByCustomerId(long customerId)
        {
            var myShelves = myShelfRepository.GetMyShelvesByCustomerId(customerId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(myShelves);
        }


        [HttpPost]
        public IActionResult AddToShelf([FromBody] MyShelf myShelf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IEnumerable<ProductBeneficiary> productBeneficiaries = productBeneficiaryRepository.GetByProductId(myShelf.BuyId);
            Product product = productRepository.GetProductById(myShelf.BuyId);
            double amount = 0;
            double totalEaring = 0;
            foreach(ProductBeneficiary productBeneficiary in productBeneficiaries)
            {
                RoyaltyCalculation royaltyCalculation = new RoyaltyCalculation();
                royaltyCalculation.BeneficiaryId = productBeneficiary.BeneficiaryId.Value;
                royaltyCalculation.BasePrice = product.Baseprice;
                royaltyCalculation.TransactionType = myShelf.TransactionType;
                royaltyCalculation.ProductId = myShelf.BuyId;
                royaltyCalculation.RoyaltyCalculationDate = myShelf.ProductExpiryDate;
                royaltyCalculation.SalePrice = product.SalePrice;
                if (myShelf.PriceAmount != 0)
                {
                    amount = product.Baseprice * (productBeneficiary.BeneficiaryPercentage.Value / 100);
                }
                else
                {
                    amount = myShelf.TotalAmount * (productBeneficiary.BeneficiaryPercentage.Value / 100);
                }
                royaltyCalculation.RoyaltyOnBasePrice = amount;
                royaltyCalculationRepository.AddRoyaltyCalculation(royaltyCalculation);
                Beneficiary beneficiary = beneficiaryRepository.GetBeneficiaryById(productBeneficiary.BeneficiaryId.Value);
                totalEaring = beneficiary.TotalEarning.Value + amount;
                beneficiary.TotalEarning = totalEaring;
                beneficiaryRepository.UpdateBeneficiary(beneficiary);
            }

            var createdMyShelf = myShelfRepository.AddToShelf(myShelf);

            return CreatedAtAction(nameof(GetMyShelfByCustomerId), new { customerId = createdMyShelf.CustomerId }, createdMyShelf);
        }

        [HttpDelete("{shelfId}")]
        public IActionResult DeleteShelf(long shelfId)
        {
            var shelf = myShelfRepository.DeleteShelf(shelfId);
            if (shelf == null)
            {
                return NotFound();
            }
            return Ok(shelf);
        }

/*        [HttpGet()]
        public IActionResult GetMyShelf()
        {
            var myShelves = myShelfRepository.GetMyShelves();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(myShelves);
        }*/


    }
}
