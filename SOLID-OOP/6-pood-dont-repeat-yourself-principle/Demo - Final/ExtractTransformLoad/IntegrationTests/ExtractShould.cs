using ExtractTransformLoad;
using ExtractTransformLoad.Services;
using NUnit.Framework;
using System.Linq;

namespace IntegrationTests
{
    [TestFixture]
    public class ExtractShould
    {
        [Test]
        public void LoadInvoices()
        {
            ExtractionResult result = new ExtractionService().Extract();

            Assert.AreEqual(2155, result.Invoices.Count());
            Assert.AreEqual(9, result.Employees.Count());
        }
    }
}