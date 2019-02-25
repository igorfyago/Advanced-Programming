using System.Data;

namespace ExtractTransformLoad
{
    public interface IInvoiceRepository
    {
        DataTable ListInvoices();
    }
}