using System;
using System.Data;
using System.IO;

namespace NTier.DAL2
{
    public class Security : DAL
    {
        public static int Login(String email, String password)
        {
            var ds = new DataSet();
            //Initialize a string named userFile with the path to the Users.xml file. 
            String userFile = UserFile;
            //Read in the XML file to the ds DataSet 
            var fs = new FileStream(userFile, FileMode.Open, FileAccess.Read);
            var reader = new StreamReader(fs);
            ds.ReadXml(reader);
            fs.Close();

            ds.Tables[0].PrimaryKey = new[] {ds.Tables[0].Columns["email"]};
            DataRow dr = ds.Tables[0].Rows.Find(email);

            if (dr == null) return 0;

            if (dr["password"].ToString() == password)
            {
                return Int32.Parse(dr["user_id"].ToString());
            }
            else
            {
                return 0;
            }
        }
    }
}