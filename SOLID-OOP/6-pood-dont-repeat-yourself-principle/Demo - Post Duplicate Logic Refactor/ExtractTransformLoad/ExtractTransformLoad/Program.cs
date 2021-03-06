﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Entities;

namespace ExtractTransformLoad
{
    internal class Program
    {
        private static DataTable _employeeTable;
        private static List<Employee> _employees;
        private static List<FreightByShipper> _freightByShipperList;
        private static DataTable _invoiceTable;

        private static void Main(string[] args)
        {
            Console.WriteLine("Beginning extract at " + DateTime.Now);
            Extract();
            Console.WriteLine("Finished extract at " + DateTime.Now);

            Console.WriteLine("Beginning transform at " + DateTime.Now);
            Transform();
            Console.WriteLine("Finished transform at " + DateTime.Now);

            Console.WriteLine("Beginning load at " + DateTime.Now);
            Load();
            Console.WriteLine("Finished load at " + DateTime.Now);

            Console.ReadLine();
        }

        private static void Extract()
        {
            using (var myConnection = new SqlConnection())
            {
                myConnection.ConnectionString =
                    "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";

                string myQuery =
                    "select * from invoices where orderdate > @LastRunDate order by salesperson, customerid, orderdate, productid";
                using (var myCommand = new SqlCommand(myQuery, myConnection))
                {
                    myCommand.Parameters.Add(new SqlParameter("LastRunDate", new DateTime(1996, 1, 1)));

                    var myAdapter = new SqlDataAdapter(myCommand);
                    _invoiceTable = new DataTable("Invoices");
                    myAdapter.Fill(_invoiceTable);

                    OutputTable(_invoiceTable, 3);
                }
            }
            using (var myConnection = new SqlConnection())
            {
                myConnection.ConnectionString =
                    "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";

                string myQuery =
                    "select FirstName + LastName, (select(count(*)) from Employees where ReportsTo = e.EmployeeId) from Employees e";
                using (var myCommand = new SqlCommand(myQuery, myConnection))
                {
                    var myAdapter = new SqlDataAdapter(myCommand);
                    _employeeTable = new DataTable("Employees");
                    myAdapter.Fill(_employeeTable);

                    OutputTable(_employeeTable);
                }
            }
        }

        public static void OutputTable(DataTable table, int columnsToDisplay = 0)
        {
            foreach (DataRow row in table.Rows)
            {
                int columnIndex = 0;
                int columnCount = table.Columns.Count;
                if (columnsToDisplay > 0 && columnsToDisplay < columnCount)
                {
                    columnCount = columnsToDisplay;
                }
                while (columnIndex < columnCount)
                {
                    Console.Write(row[columnIndex]);
                    columnIndex++;
                    if (columnIndex < columnCount)
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        private static void Transform()
        {
            DataTable shippers = _invoiceTable.DefaultView.ToTable(true, new[] {"ShipperName"});
            _freightByShipperList = new List<FreightByShipper>();
            foreach (DataRow row in shippers.Rows)
            {
                Console.WriteLine("{0}", row[0]);
                _freightByShipperList.Add(new FreightByShipper {ShipperName = row[0].ToString()});
            }
            if (_freightByShipperList.Count > 0)
            {
                _freightByShipperList[0].Freight =
                    (decimal)
                    _invoiceTable.Compute("sum(freight)", "shippername='" + _freightByShipperList[0].ShipperName + "'");
                Console.WriteLine("{0}:{1:#.##}", _freightByShipperList[0].ShipperName, _freightByShipperList[0].Freight);
            }

            if (_freightByShipperList.Count > 1)
            {
                _freightByShipperList[1].Freight =
                    (decimal)
                    _invoiceTable.Compute("sum(freight)", "shippername='" + _freightByShipperList[1].ShipperName + "'");
                Console.WriteLine("{0}:{1:#.##}", _freightByShipperList[1].ShipperName, _freightByShipperList[1].Freight);
            }

            if (_freightByShipperList.Count > 2)
            {
                _freightByShipperList[2].Freight =
                    (decimal)
                    _invoiceTable.Compute("sum(freight)", "shippername='" + _freightByShipperList[2].ShipperName + "'");
                Console.WriteLine("{0}:{1:#.##}", _freightByShipperList[2].ShipperName, _freightByShipperList[2].Freight);
            }

            var totalFreight = (decimal) _invoiceTable.Compute("sum(freight)", "");
            Console.WriteLine("Total Freight: " + totalFreight);

            _employees = new List<Employee>();
            foreach (DataRow row in _employeeTable.Rows)
            {
                var employee = new Employee {Name = row[0].ToString()};
                if ((int) row[1] > 0)
                {
                    employee.IsManager = true;
                }
                else
                {
                    employee.IsManager = false;
                }
                _employees.Add(employee);
            }
            foreach (Employee employee in _employees)
            {
                if (employee.IsManager)
                {
                    employee.Bonus = totalFreight/10m;
                }
                else
                {
                    employee.Bonus = totalFreight/1000m;
                }
            }
        }

        private static void Load()
        {
            foreach (FreightByShipper shipper in _freightByShipperList)
            {
                using (var db = new NorthwindDataContext("Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True"))
                {
                    var shipperToDelete = from shippers in db.FreightSummaries
                                          where
                                              shippers.ShipperName == shipper.ShipperName &&
                                              shippers.RunDate == DateTime.Today
                                          select shippers;
                    db.FreightSummaries.DeleteOnSubmit(shipperToDelete.First());
                    db.SubmitChanges();

                    var shipperToInsert = new FreightSummary()
                                              {
                                                  Freight = shipper.Freight,
                                                  ShipperName = shipper.ShipperName,
                                                  RunDate = DateTime.Today
                                              };
                    db.FreightSummaries.InsertOnSubmit(shipperToInsert);
                    db.SubmitChanges();

                }
            }
            foreach (Employee employee in _employees)
            {
                using (var myConnection = new SqlConnection())
                {
                    myConnection.ConnectionString =
                        "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";

                    string myQuery = "delete EmployeeBonus where Date = @RunDate and EmployeeName = @EmployeeName";
                    using (var myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.Add(new SqlParameter("RunDate", DateTime.Today));
                        myCommand.Parameters.Add(new SqlParameter("EmployeeName", employee.Name));
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                    }

                    myQuery =
                        "insert EmployeeBonus (Date,EmployeeName,Bonus) VALUES (@RunDate, @EmployeeName, @Bonus)";
                    using (var myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.Add(new SqlParameter("RunDate", DateTime.Today));
                        myCommand.Parameters.Add(new SqlParameter("EmployeeName", employee.Name));
                        myCommand.Parameters.Add(new SqlParameter("Bonus", employee.Bonus));
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();

                        string result = String.Format("{0}:{1}:{2:#.##}", employee.Name,
                                                      employee.IsManager ? "Manager" : "Employee",
                                                      employee.Bonus);
                        Console.WriteLine("Added Row to summary: " + result);
                    }
                }
            }
        }
    }
}