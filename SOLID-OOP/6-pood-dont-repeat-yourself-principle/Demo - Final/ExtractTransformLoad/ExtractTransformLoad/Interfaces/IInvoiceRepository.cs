using System;
using System.Collections.Generic;
using ExtractTransformLoad.Domain;

namespace ExtractTransformLoad.Interfaces
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> List(DateTime minimumOrderDate);
    }
}