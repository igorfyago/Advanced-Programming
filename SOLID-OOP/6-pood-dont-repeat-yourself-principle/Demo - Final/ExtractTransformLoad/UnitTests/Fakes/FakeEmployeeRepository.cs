using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ExtractTransformLoad.Domain;
using ExtractTransformLoad.Interfaces;

namespace UnitTests.Fakes
{
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        public bool WasCalled = false;
        public IEnumerable<Employee> List()
        {
            WasCalled = true;
            return new List<Employee>().AsQueryable();
        }
    }
}