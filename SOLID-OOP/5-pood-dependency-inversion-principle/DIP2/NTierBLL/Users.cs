using System;
using NTier.Common;

namespace NTier.BLL
{
    public class Users : BLL
    {
        public static int AddUser(String firstName, String lastName, 
            String email, String password)
        {
            return DAL.Users.AddUser(firstName, lastName, email, password);
        }

        public static UserDetails GetUser(int userId)
        {
            return DAL.Users.GetUser(userId);
        }
    }
}