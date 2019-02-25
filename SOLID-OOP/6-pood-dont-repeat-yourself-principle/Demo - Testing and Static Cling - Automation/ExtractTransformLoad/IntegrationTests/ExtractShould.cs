using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtractTransformLoad;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class ExtractShould
    {
        [Test]
        public void LoadInvoices()
        {
            var result = new ExtractionService().Extract();

            Assert.AreEqual(2155, result.InvoiceTable.Rows.Count);
            Assert.AreEqual(9, result.EmployeeTable.Rows.Count);

        }
    }
}
