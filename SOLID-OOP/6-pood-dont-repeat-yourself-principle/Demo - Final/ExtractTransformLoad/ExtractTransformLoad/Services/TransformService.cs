using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExtractTransformLoad.Domain;

namespace ExtractTransformLoad.Services
{
    public class TransformService
    {
        private readonly TextWriter _outputStream;

        public TransformService(TextWriter outputStream)
        {
            _outputStream = outputStream;
        }

        public TransformService()
            : this(Console.Out)
        {
        }

        public TransformResult Transform(ExtractionResult extractionResult)
        {
            List<FreightByShipper> _freightByShipperList = (from invoice in extractionResult.Invoices
                                                            group invoice by invoice.ShipperName
                                                            into shippers
                                                            select new FreightByShipper
                                                                       {
                                                                           ShipperName = shippers.Key,
                                                                           Freight =
                                                                               shippers.Sum(invoice => invoice.Freight)
                                                                       }).ToList();

            foreach (FreightByShipper freightByShipper in _freightByShipperList)
            {
                _outputStream.WriteLine("Shipper: {0}; Freight: {1}", freightByShipper.ShipperName,
                                        freightByShipper.Freight);
            }

            decimal totalFreight = _freightByShipperList.Sum(f => f.Freight);
            _outputStream.WriteLine("Total Freight: " + totalFreight);

            var employeesWithBonus = extractionResult.Employees.ToList();
            foreach (Employee employee in employeesWithBonus)
            {
                employee.CalculateAndSetBonus(totalFreight);
            }
            return new TransformResult() { Employees = employeesWithBonus, FreightByShippers = _freightByShipperList};
        }
    }
}