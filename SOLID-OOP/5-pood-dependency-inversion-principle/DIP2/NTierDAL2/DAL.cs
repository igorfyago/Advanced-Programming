using System;

namespace NTier.DAL2
{
    public abstract class DAL
    {
        private static String _userFile = @"C:\Dev\SteveSmith\N-Tier Development In .NET\trunk\src\NTierWeb\App_Data\users.xml";

        protected static String UserFile
        {
            get { return _userFile; }
        }
    }
}