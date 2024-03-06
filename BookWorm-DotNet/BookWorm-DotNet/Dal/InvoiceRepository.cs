using BookWorm_DotNet.DAL;
using BookWorm_DotNet.Data;
using BookWorm_DotNet.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookWorm_DotNet.Services
{
    public class InvoiceRepository : IInvoiceRepository
    {

        private readonly BookwormContext context;

        public InvoiceRepository(BookwormContext context)
        {
            this.context = context;
        }
        public Invoice addToInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return invoice;
        }

        public Invoice deleteByInvoiceId(long id)
        {
            Invoice invoice = context.Invoices.Find(id);
            if (invoice != null)
            {
                context.Invoices.Remove(invoice);
                 context.SaveChanges();
            }
            return invoice;
        }

        public List<Invoice> getAllInvoice()
        {
            if (context.Invoices == null)
            {
                return null;
            }
            return  context.Invoices.ToList();
        }

       
        public IEnumerable<Invoice> getByCustomerId(long id)
        {
            return context.Invoices.Where(invoice => invoice.CustomerId == id).ToList();
        }
        public Invoice getById(long id)
        {
            if (context.Invoices == null)
            {
                return null;
            }
            var invoice =  context.Invoices.Find(id);

            if (invoice == null)
            {
                return null;
            }

            return invoice;
        }
    }
}
