using System.Data;
using System.Data.SqlClient;

namespace ExtractTransformLoad
{
    class SqlEmployeeRepository : IEmployeeRepository
    {
        public DataTable ListEmployees()
        {
            using (var myConnection = new SqlConnection())
            {
                myConnection.ConnectionString =
                    "Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";

                string myQuery =
                    "select FirstName + LastName, (select(count(*)) from Employees where ReportsTo = e.EmployeeId) from Employees e";
                using (var myCommand = new SqlCommand(myQuery, myConnection))
                {
                    var myAdapter = new SqlDataAdapter(myCommand);
                    var table = new DataTable("Employees");
                    myAdapter.Fill(table);
                    return table;
                }
            }
        }
    }
}