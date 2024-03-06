using BookWorm_DotNet.Models;

namespace BookWorm_DotNet.DAL
{
    public interface IRoyaltyCalculationRepository
    {
        RoyaltyCalculation AddRoyaltyCalculation(RoyaltyCalculation royaltyCalculation);
    }
}