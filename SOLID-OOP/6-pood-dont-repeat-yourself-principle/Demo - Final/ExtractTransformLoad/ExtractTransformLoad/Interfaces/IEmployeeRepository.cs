using System.Collections.Generic;
using ExtractTransformLoad.Domain;

namespace ExtractTransformLoad.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> List();
    }
}