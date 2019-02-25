using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ExtractTransformLoad;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ExtractShould
    {
        [Test]
        public void GetDataFromInvoicesAndEmployees()
        {
            // Arrange
            var invoiceRepository = new Mock<IInvoiceRepository>();
            var employeeRepository = new Mock<IEmployeeRepository>();

            invoiceRepository.Setup(m => m.ListInvoices()).Returns(new DataTable());

            var service = new ExtractionService(invoiceRepository.Object, 
                employeeRepository.Object);

            // Act
            var result = service.Extract();

            // Assert
            invoiceRepository.Verify(i => i.ListInvoices(), Times.Exactly(1));
            employeeRepository.Verify(e => e.ListEmployees(), Times.Never());
        }
    }

    public class FakeInvoiceRepository : IInvoiceRepository
    {
        public bool WasCalled = false;
        public DataTable ListInvoices()
        {
            WasCalled = true;
            return new DataTable();
        }
    }
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        public bool WasCalled = false;

        public DataTable ListEmployees()
        {
            WasCalled = true;
            return new DataTable();
        }
    }
}
