using BookWorm_DotNet.Models;

namespace BookWorm_DotNet.DAL
{
    public interface IMyShelfRepository
    {
        ICollection<MyShelf> GetMyShelves();

        ICollection<MyShelf> GetMyShelvesByCustomerId(long customerId);

        MyShelf AddToShelf(MyShelf myShelf);

        MyShelf DeleteShelf(long shelfId);
    }
}