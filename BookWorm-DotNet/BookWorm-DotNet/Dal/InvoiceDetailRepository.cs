using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;

namespace BookWorm_DotNet.DAL
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private readonly BookwormContext context;

        public InvoiceDetailRepository(BookwormContext context)
        {
            this.context = context;
        }
        public InvoiceDetail setInvoiceDetails(InvoiceDetail invdetails)
        {
            context.InvoiceDetails.Add(invdetails);
            context.SaveChanges();
            return invdetails;
        }
    }
}
