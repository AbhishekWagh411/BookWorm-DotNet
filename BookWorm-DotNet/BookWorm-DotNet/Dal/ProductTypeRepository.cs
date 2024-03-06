using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;

namespace BookWorm_DotNet.DAL
{
    public class ProductTypeRepository:IProductTypeRepository
    {
        private readonly BookwormContext context;

        public ProductTypeRepository(BookwormContext context)
        {
            this.context = context;
        }

        public ProductType addProductType(ProductType pro)
        {
            context.ProductTypeMasters.Add(pro);
            context.SaveChanges();
            return pro;
        }

        public ProductType delete(int id)
        {
            ProductType pro = context.ProductTypeMasters.Find(id);
            if (pro != null)
            {
                context.ProductTypeMasters.Remove(pro);
                context.SaveChanges();
            }
            return pro;
        }

        public List<ProductType> getAllProducts()
        {
            if (context.ProductTypeMasters == null)
            {
                return null;
            }
            return context.ProductTypeMasters.ToList();
        }

        public void update(ProductType p, int id)
        {
            var entity = context.ProductTypeMasters.FirstOrDefault(p => p.TypeId == id);
            if (entity != null)
            {
                entity.TypeDesc = p.TypeDesc;
                context.SaveChanges();
            }
        }

        
    }
}
