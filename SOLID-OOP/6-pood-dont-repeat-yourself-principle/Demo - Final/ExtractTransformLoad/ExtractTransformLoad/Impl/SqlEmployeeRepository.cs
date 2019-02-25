using System.Collections.Generic;
using System.Linq;
using ExtractTransformLoad.Domain;
using ExtractTransformLoad.Interfaces;
using Northwind.Entities;
using Employee = ExtractTransformLoad.Domain.Employee;

namespace ExtractTransformLoad.Impl
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> List()
        {
            using (var context = new NorthwindEntities())
            {
                var result = (from e in context.Employees
                              select new
                                         {
                                             Employee = e,
                                             DirectReports = (from e2 in context.Employees
                                                              where e2.ReportsTo == e.EmployeeID
                                                              select e2).Count()
                                         }).ToList();
                return (from r in result
                        select
                            new EmployeeFactory().Create(r.DirectReports,
                                                         r.Employee.FirstName + " " + r.Employee.LastName));
            }
        }
    }
}