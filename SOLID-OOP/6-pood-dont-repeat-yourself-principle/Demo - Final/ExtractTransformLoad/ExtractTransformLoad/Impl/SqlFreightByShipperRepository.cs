using System;
using System.Data.Objects;
using System.Transactions;
using ExtractTransformLoad.Domain;
using ExtractTransformLoad.Interfaces;
using ExtractTransformLoad.Services;
using Northwind.Entities;
using System.Linq;

namespace ExtractTransformLoad.Impl
{
    public class SqlFreightByShipperRepository : IFreightByShipperRepository
    {
        public void DeleteAndInsert(DateTime runDate, FreightByShipper freightByShipper)
        {
            using (var context = new NorthwindEntities())
            using (var scope = new TransactionScope())
            {
                var summaryToDelete = (from freightSummary in context.FreightSummaries
                                       where
                                           freightSummary.RunDate == runDate &&
                                           freightSummary.ShipperName == freightByShipper.ShipperName

                                       select freightSummary).FirstOrDefault();
                if (summaryToDelete != null)
                {
                    context.DeleteObject(summaryToDelete);
                }

                var newFreightSummary = new FreightSummary()
                                         {
                                             Freight = freightByShipper.Freight,
                                             RunDate = runDate,
                                             ShipperName = freightByShipper.ShipperName
                                         };
                context.FreightSummaries.AddObject(newFreightSummary);
                context.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                scope.Complete();
            }
        }
    }
}