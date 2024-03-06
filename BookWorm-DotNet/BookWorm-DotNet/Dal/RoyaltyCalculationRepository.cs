using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;

namespace BookWorm_DotNet.DAL
{
    public class RoyaltyCalculationRepository : IRoyaltyCalculationRepository
    {
        private readonly BookwormContext context;

        public RoyaltyCalculationRepository(BookwormContext context)
        {
            this.context = context;

        }
        public RoyaltyCalculation AddRoyaltyCalculation(RoyaltyCalculation royaltyCalculation)
        {
            if (royaltyCalculation != null)
            {
                context.RoyaltyCalculations.Add(royaltyCalculation);
                context.SaveChanges();
            }
            return royaltyCalculation;
        }
    }
}