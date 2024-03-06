using BookWorm_DotNet.Models;

namespace BookWorm_DotNet.DAL
{
    public interface IInvoiceRepository
    {

        List<Invoice> getAllInvoice();

        Invoice addToInvoice(Invoice invoice);

        Invoice deleteByInvoiceId(long id);


        Invoice getById(long id);
        public IEnumerable<Invoice> getByCustomerId(long id);
    }
}
