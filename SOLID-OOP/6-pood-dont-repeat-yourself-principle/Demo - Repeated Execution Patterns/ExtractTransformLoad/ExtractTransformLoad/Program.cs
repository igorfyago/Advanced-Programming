using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ExtractTransformLoad.Data;

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
            foreach (var step in GetSteps())
            {
                ExecuteStep(step);
            }

            Console.ReadLine();
        }

        private static IEnumerable<Action> GetSteps()
        {
            yield return Extract;
            yield return Transform;
            yield return Load;
        }

        private static void ExecuteStep(Action action)
        {
            Console.WriteLine("Beginning {0} at " + DateTime.Now, action.Method.Name);
            action();
            Console.WriteLine("Finished {0} at " + DateTime.Now, action.Method.Name);
        }

        private static void Extract()
        {
            string myQuery =
                    "select * from invoices where orderdate > @LastRunDate order by salesperson, customerid, orderdate, productid";
            _invoiceTable = SqlHelper.ExecuteDataset(
                "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True",
                CommandType.Text,
                myQuery,
                new[]
                    {
                        new SqlParameter("LastRunDate", new DateTime(1996, 1, 1))
                    }
                ).Tables[0];

            foreach (DataRow row in _invoiceTable.Rows)
            {
                Console.WriteLine("{0}-{1}-{2}", row[0], row[1], row[2]);
            }

            myQuery =
                    "select FirstName + LastName, (select(count(*)) from Employees where ReportsTo = e.EmployeeId) from Employees e";
            _employeeTable = SqlHelper.ExecuteDataset(
                "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True",
                CommandType.Text,
                myQuery).Tables[0];

            foreach (DataRow row in _employeeTable.Rows)
            {
                Console.WriteLine("{0}-{1}", row[0], row[1]);
            }
        }

        private static void Transform()
        {
            DataTable shippers = _invoiceTable.DefaultView.ToTable(true, new[] { "ShipperName" });
            _freightByShipperList = new List<FreightByShipper>();
            foreach (DataRow row in shippers.Rows)
            {
                Console.WriteLine("{0}", row[0]);
                _freightByShipperList.Add(new FreightByShipper { ShipperName = row[0].ToString() });
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

            var totalFreight = (decimal)_invoiceTable.Compute("sum(freight)", "");
            Console.WriteLine("Total Freight: " + totalFreight);

            _employees = new List<Employee>();
            foreach (DataRow row in _employeeTable.Rows)
            {
                var employee = new Employee { Name = row[0].ToString() };
                if ((int)row[1] > 0)
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
                    employee.Bonus = totalFreight / 10m;
                }
                else
                {
                    employee.Bonus = totalFreight / 1000m;
                }
            }
        }

        private static void Load()
        {
            foreach (FreightByShipper shipper in _freightByShipperList)
            {
                using (var myConnection = new SqlConnection())
                {
                    myConnection.ConnectionString =
                        "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";

                    string myQuery = "delete FreightSummary where RunDate = @RunDate and ShipperName = @ShipperName";
                    using (var myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.Add(new SqlParameter("RunDate", DateTime.Today));
                        myCommand.Parameters.Add(new SqlParameter("ShipperName", shipper.ShipperName));
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                    }

                    myQuery =
                        "insert FreightSummary (RunDate,ShipperName,Freight) VALUES (@RunDate, @ShipperName, @Freight)";
                    using (var myCommand = new SqlCommand(myQuery, myConnection))
                    {
                        myCommand.Parameters.Add(new SqlParameter("RunDate", DateTime.Today));
                        myCommand.Parameters.Add(new SqlParameter("ShipperName", shipper.ShipperName));
                        myCommand.Parameters.Add(new SqlParameter("Freight", shipper.Freight));
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();

                        string result = String.Format("{0}:{1:#.##}", shipper.ShipperName,
                                                      shipper.Freight);
                        Console.WriteLine("Added Row to summary: " + result);
                    }
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