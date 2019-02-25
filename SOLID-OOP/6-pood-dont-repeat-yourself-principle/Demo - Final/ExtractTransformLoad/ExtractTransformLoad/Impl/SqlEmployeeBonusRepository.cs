using System;
using System.Data.Objects;
using System.Linq;
using System.Transactions;
using ExtractTransformLoad.Interfaces;
using Northwind.Entities;
using Employee = ExtractTransformLoad.Domain.Employee;

namespace ExtractTransformLoad.Impl
{
    public class SqlEmployeeBonusRepository : IEmployeeBonusRepository
    {
        public void DeleteAndInsert(DateTime runDate, Employee employee)
        {
            using (var context = new NorthwindEntities())
            using (var scope = new TransactionScope())
            {
                EmployeeBonus bonusToDelete = (from bonus in context.EmployeeBonus
                                               where
                                                   bonus.Date == runDate &&
                                                   bonus.EmployeeName == employee.Name
                                               select bonus).FirstOrDefault();
                if (bonusToDelete != null)
                {
                    context.DeleteObject(bonusToDelete);
                }

                var newBonus = new EmployeeBonus
                                   {
                                       EmployeeName = employee.Name,
                                       Date = runDate,
                                       Bonus = employee.Bonus
                                   };
                context.EmployeeBonus.AddObject(newBonus);
                context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                scope.Complete();
            }
        }
    }
}