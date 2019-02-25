using System;
using System.Data.SqlClient;

namespace NTier.DAL
{
    public class Security : DAL
    {
        public static int Login(String email, String password)
        {
            string sql = "SELECT UserId from Users WHERE Email = @email and Password = @password";
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                conn.Open();
                return (int) cmd.ExecuteScalar();
            }
        }
    }
}