using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_DotNet.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookwormContext _context;
        public CustomerRepository(BookwormContext dbContext)
        {
            _context = dbContext;
        }
        public long AddCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return customer.CustomerId;
        }

        public Customer LoginUser(String email, String password)
        {
            return _context.Customers.FirstOrDefault((c) => c.Email == email && c.Password == password);
        }

        public Customer GetCustomer(long customerId)
        {
            return _context.Customers.Find(customerId);
        }
    }
}
