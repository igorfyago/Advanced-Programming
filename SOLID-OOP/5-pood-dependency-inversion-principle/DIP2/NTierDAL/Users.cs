using System;
using System.Data;
using System.Data.SqlClient;
using NTier.Common;

namespace NTier.DAL
{
    public class Users : DAL
    {
        public static int AddUser(String firstName, String lastName, String email, String password)
        {
            string sql =
                @"INSERT Users (FirstName, LastName, Email, Password)
                            VALUES (@FirstName, @LastName, @Email, @Password)
                            SELECT @@IDENTITY";
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@FirstName", firstName));
                cmd.Parameters.Add(new SqlParameter("@LastName", lastName));
                cmd.Parameters.Add(new SqlParameter("@Email", email));
                cmd.Parameters.Add(new SqlParameter("@Password", password));
                conn.Open();
                return (int) cmd.ExecuteScalar();
            }
        }

        public static UserDetails GetUser(int userId)
        {
            string sql =
                @"SELECT FirstName, LastName, Email, Password FROM Users Where UserId = @UserId";
            using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add(new SqlParameter("@UserId", userId));
                conn.Open();
                using(var myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if(myReader.Read())
                    {
                        var userDetails = new UserDetails();
                        userDetails.UserId = userId;
                        userDetails.FirstName = myReader.GetString(0);
                        userDetails.LastName = myReader.GetString(1);
                        userDetails.Email = myReader.GetString(2);
                        userDetails.Password = myReader.GetString(3);
                        return userDetails;
                    }
                }
                return null;
            }
        }
    }
}