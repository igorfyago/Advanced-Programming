using System.Collections.Generic;
using System.Linq;
using ExtractTransformLoad.Domain;

namespace ExtractTransformLoad
{
    public class ExtractionResult
    {
        public IEnumerable<Invoice> Invoices { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}