using System;
using System.Data;
using System.Data.SqlClient;

namespace ExtractTransformLoad
{
    class SqlInvoiceRepository : IInvoiceRepository
    {
        public DataTable ListInvoices()
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
                    var table = new DataTable("Invoices");
                    myAdapter.Fill(table);
                    return table;
                }
            }
        }
    }
}