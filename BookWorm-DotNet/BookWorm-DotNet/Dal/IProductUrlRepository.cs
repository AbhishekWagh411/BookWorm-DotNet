namespace BookWorm_DotNet.DAL
{
    public interface IProductUrlRepository
    {
        public String getUrlByProductId(int productId);
    }
}
