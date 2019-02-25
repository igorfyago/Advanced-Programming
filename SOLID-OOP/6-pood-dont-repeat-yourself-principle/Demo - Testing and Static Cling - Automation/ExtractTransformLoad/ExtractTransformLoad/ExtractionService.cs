using System;
using System.Data;

namespace ExtractTransformLoad
{
    public class ExtractionService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ExtractionService(IInvoiceRepository invoiceRepository,
            IEmployeeRepository employeeRepository)
        {
            _invoiceRepository = invoiceRepository;
            _employeeRepository = employeeRepository;
        }

        public ExtractionService()
            : this(new SqlInvoiceRepository(),
            new SqlEmployeeRepository())
        { }

        public ExtractionResult Extract()
        {
            var result = new ExtractionResult();

            result.InvoiceTable = _invoiceRepository.ListInvoices();
            foreach (DataRow row in result.InvoiceTable.Rows)
            {
                Console.WriteLine("{0}-{1}-{2}", row[0], row[1], row[2]);
            }

            if (result.InvoiceTable.Rows.Count > 0)
            {
                result.EmployeeTable = _employeeRepository.ListEmployees();
                foreach (DataRow row in result.EmployeeTable.Rows)
                {
                    Console.WriteLine("{0}-{1}", row[0], row[1]);
                }
            }
            return result;
        }
    }
}