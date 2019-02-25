using System;
using System.Collections.Generic;
using ExtractTransformLoad;
using ExtractTransformLoad.Domain;
using ExtractTransformLoad.Interfaces;
using ExtractTransformLoad.Services;
using Moq;
using NUnit.Framework;
using UnitTests.Fakes;

namespace UnitTests
{
    [TestFixture]
    public class ExtractShould
    {
        [Test]
        public void GetDataFromInvoicesAndEmployeesFakes()
        {
            // Arrange
            var invoiceRepository = new FakeInvoiceRepository();
            var employeeRepository = new FakeEmployeeRepository();

            var service = new ExtractionService(invoiceRepository,
                                                employeeRepository,
                                                Console.Out);

            // Act
            ExtractionResult result = service.Extract();

            // Assert
            Assert.That(invoiceRepository.WasCalled);
            Assert.That(employeeRepository.WasCalled == false);
        }

        [Test]
        public void GetDataFromInvoicesAndEmployeesMocks()
        {
            // Arrange
            var invoiceRepository = new Mock<IInvoiceRepository>();
            var employeeRepository = new Mock<IEmployeeRepository>();

            invoiceRepository.Setup(m => m.List(It.IsAny<DateTime>())).Returns(new List<Invoice>());

            var service = new ExtractionService(invoiceRepository.Object,
                                                employeeRepository.Object,
                                                Console.Out);

            // Act
            ExtractionResult result = service.Extract();

            // Assert
            invoiceRepository.VerifyAll();
            employeeRepository.Verify(e => e.List(), Times.Never());
        }
    }
}