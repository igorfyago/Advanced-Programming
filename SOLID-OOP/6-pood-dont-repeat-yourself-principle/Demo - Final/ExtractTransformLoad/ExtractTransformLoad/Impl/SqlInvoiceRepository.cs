using System;
using System.Collections.Generic;
using System.Linq;
using ExtractTransformLoad.Interfaces;
using Northwind.Entities;
using Invoice = ExtractTransformLoad.Domain.Invoice;

namespace ExtractTransformLoad.Impl
{
    public class SqlInvoiceRepository : IInvoiceRepository
    {
        public IEnumerable<Invoice> List(DateTime minimumOrderDate)
        {
            using (var context = new NorthwindEntities())
            {
                return (from invoice in context.Invoices
                        where invoice.OrderDate > minimumOrderDate
                        select new Invoice
                                   {
                                       Freight = invoice.Freight.HasValue ? invoice.Freight.Value : 0,
                                       OrderDate = invoice.OrderDate,
                                       ShipperName = invoice.ShipperName,
                                       ShipAddress = invoice.ShipAddress,
                                       ShipCity = invoice.ShipCity
                                   }).ToList();
                
            }
        }
    }
}