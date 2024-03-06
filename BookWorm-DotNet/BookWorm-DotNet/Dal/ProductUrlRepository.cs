using BookWorm_DotNet.Data;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_DotNet.DAL
{
    public class ProductUrlRepository:IProductUrlRepository
    {
        private readonly BookwormContext context;

        public ProductUrlRepository(BookwormContext context)
        {
            this.context = context;
        }

        public string getUrlByProductId(int productId)
        {
            var url = context.ProductUrls
           .Where(p => p.ProductId == productId)
           .Select(p => p.Url)
           .FirstOrDefault();

            return url;
        }
    
    }
}
