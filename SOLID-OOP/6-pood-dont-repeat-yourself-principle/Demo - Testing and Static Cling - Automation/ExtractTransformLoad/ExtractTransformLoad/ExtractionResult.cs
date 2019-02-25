using System.Data;

namespace ExtractTransformLoad
{
    public class ExtractionResult
    {
        public DataTable InvoiceTable { get; set; }
        public DataTable EmployeeTable { get; set; }
    }
}