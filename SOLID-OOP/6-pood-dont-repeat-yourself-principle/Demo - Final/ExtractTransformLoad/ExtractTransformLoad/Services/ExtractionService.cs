using System;
using System.IO;
using System.Linq;
using ExtractTransformLoad.Domain;
using ExtractTransformLoad.Impl;
using ExtractTransformLoad.Interfaces;

namespace ExtractTransformLoad.Services
{
    public class ExtractionService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly TextWriter _outputStream;
        private readonly IInvoiceRepository _invoiceRepository;

        public ExtractionService(IInvoiceRepository invoiceRepository,
                                 IEmployeeRepository employeeRepository,
            TextWriter outputStream)
        {
            _invoiceRepository = invoiceRepository;
            _employeeRepository = employeeRepository;
            _outputStream = outputStream;
        }

        public ExtractionService()
            : this(new SqlInvoiceRepository(),
                   new SqlEmployeeRepository(),
            Console.Out)
        {
        }

        public ExtractionResult Extract()
        {
            var result = new ExtractionResult();

            result.Invoices = _invoiceRepository.List(new DateTime(1996, 1, 1));
            foreach (Invoice invoice in result.Invoices)
            {
                _outputStream.WriteLine("{0}-{1}-{2}", invoice.ShipperName, invoice.ShipAddress, invoice.ShipCity);
            }

            if (result.Invoices.Count() > 0)
            {
                result.Employees = _employeeRepository.List();
                foreach (Employee employee in result.Employees)
                {
                    _outputStream.WriteLine(employee);
                }
            }
            return result;
        }
    }
}