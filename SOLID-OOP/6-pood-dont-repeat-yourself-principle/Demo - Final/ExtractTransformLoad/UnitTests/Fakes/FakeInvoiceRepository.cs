using System;
using System.Collections.Generic;
using ExtractTransformLoad.Domain;
using ExtractTransformLoad.Interfaces;

namespace UnitTests.Fakes
{
    public class FakeInvoiceRepository : IInvoiceRepository
    {
        public bool WasCalled;

        public IEnumerable<Invoice> List(DateTime minimumOrderDate)
        {
            WasCalled = true;
            return new List<Invoice>();
        }
    }
}