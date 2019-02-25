using System.Collections.Generic;
using ExtractTransformLoad.Domain;

namespace ExtractTransformLoad
{
    public class TransformResult
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<FreightByShipper> FreightByShippers { get; set; }
    }
}