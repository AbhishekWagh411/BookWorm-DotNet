using BookWorm_DotNet.Models;

namespace BookWorm_DotNet.DAL
{
    public interface ICustomerRepository
    {
        Customer LoginUser(String email, String password);
        long AddCustomer(Customer customer);
        Customer GetCustomer(long customerId);
    }
}
