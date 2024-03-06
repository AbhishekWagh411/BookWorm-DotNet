using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;

namespace BookWorm_DotNet.DAL
{
    public class MyShelfRepository : IMyShelfRepository
    {
        private readonly BookwormContext context;

        public MyShelfRepository(BookwormContext context)
        {
            this.context = context;
        }
        public MyShelf AddToShelf(MyShelf myShelf)
        {
            if (myShelf != null)
            {
                context.MyShelves.Add(myShelf);
                context.SaveChanges();
            }
            return myShelf;
        }

        public MyShelf DeleteShelf(long shelfId)
        {
            var shelf = context.MyShelves.FirstOrDefault(s => s.ShelfId == shelfId);
            if (shelf != null)
            {
                context.MyShelves.Remove(shelf);
                context.SaveChanges();
            }
            return shelf;
        }

        public ICollection<MyShelf> GetMyShelves()
        {
            return context.MyShelves.OrderBy(s => s.ShelfId).ToList();
        }

        public ICollection<MyShelf> GetMyShelvesByCustomerId(long customerId)
        {
            return context.MyShelves.Where(s => s.CustomerId == customerId).ToList();
        }
    }
}