using System;
using System.Data.SqlClient;
using System.IO;
using ExtractTransformLoad.Domain;
using ExtractTransformLoad.Impl;
using ExtractTransformLoad.Interfaces;

namespace ExtractTransformLoad.Services
{
    public class LoadService
    {
        private readonly IFreightByShipperRepository _freightByShipperRepository;
        private readonly IEmployeeBonusRepository _employeeBonusRepository;
        private readonly TextWriter _outputStream;

        public LoadService(IFreightByShipperRepository freightByShipperRepository,
            IEmployeeBonusRepository employeeBonusRepository,
            TextWriter outputStream)
        {
            _freightByShipperRepository = freightByShipperRepository;
            _employeeBonusRepository = employeeBonusRepository;
            _outputStream = outputStream;
        }

        public LoadService()
            : this(new SqlFreightByShipperRepository(),
                new SqlEmployeeBonusRepository(),
                Console.Out)
        {

        }

        public void Load(TransformResult transformResult)
        {
            foreach (FreightByShipper shipper in transformResult.FreightByShippers)
            {
                _freightByShipperRepository.DeleteAndInsert(DateTime.Today, shipper);

                string result = String.Format(Format.FreightFormatString, shipper.ShipperName,
                                              shipper.Freight);
                _outputStream.WriteLine("Added Row to summary: " + result);
            }
            foreach (Employee employee in transformResult.Employees)
            {
                _employeeBonusRepository.DeleteAndInsert(DateTime.Today, employee);

                string result = String.Format("{0}:{1}:{2:#.##}", employee.Name,
                                              employee.GetType().Name,
                                              employee.Bonus);
                _outputStream.WriteLine("Added Row to summary: " + result);
            }
        }

    }
}