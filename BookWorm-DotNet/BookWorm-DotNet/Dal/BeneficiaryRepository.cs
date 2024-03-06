
using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_DotNet.DAL
{
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly BookwormContext _context;

        public BeneficiaryRepository(BookwormContext context)
        {
            _context = context;
        }

        public IEnumerable<Beneficiary> GetAllBeneficiaries()
        {
            return _context.BeneficiaryMasters.ToList();
        }

        public Beneficiary GetBeneficiaryById(long id)
        {
            return _context.BeneficiaryMasters.Find(id);
        }

        public void AddBeneficiary(Beneficiary beneficiary)
        {
            _context.BeneficiaryMasters.Add(beneficiary);
            _context.SaveChanges();
        }

        public void UpdateBeneficiary(Beneficiary beneficiary)
        {
            _context.Entry(beneficiary).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteBeneficiary(long id)
        {
            var beneficiary = _context.BeneficiaryMasters.Find(id);
            if (beneficiary != null)
            {
                _context.BeneficiaryMasters.Remove(beneficiary);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Beneficiary not found");
            }
        }
    }
}