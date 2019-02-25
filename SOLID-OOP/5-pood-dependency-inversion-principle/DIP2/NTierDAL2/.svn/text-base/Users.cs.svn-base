using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Xml;
using NTier.DAL2;
using NTier.Common;

namespace NTier.DAL2
{

	/// <summary>
	/// Manages security for NTier and affiliated websites.
	/// </summary>
	public class Users : DAL 
	{
		public static int AddUser(String firstName, String lastName, String email, String password)
		{
			int user_id = 0;
			DataSet ds = new DataSet();
			//Initialize a string named userFile with the path to the Users.xml file. 
			String userFile = UserFile;
			//Read in the XML file to the ds DataSet 
			FileStream fs = new FileStream(userFile, FileMode.Open,FileAccess.Read);
			StreamReader reader = new StreamReader(fs);
			ds.ReadXml(reader);
			fs.Close();

			//See if the user already exists for this email
			ds.Tables[0].PrimaryKey = new DataColumn[] {ds.Tables[0].Columns["email"]};
			DataRow dr = ds.Tables[0].Rows.Find(email);
			if(dr != null)
				throw new Exception("User already exists in database.");

			//Add the new name and password to the ds DataSet. 
			DataRow newUser = ds.Tables[0].NewRow();
			newUser["first_name"] = firstName;
			newUser["last_name"] = lastName;
			newUser["email"] = email;
			newUser["password"] = password;
			user_id = ds.Tables[0].Rows.Count + 1;
			newUser["user_id"] = user_id;
			ds.Tables[0].Rows.Add(newUser);
			ds.AcceptChanges();
			//Write the new DataSet with the new name and password to the XML file. 
			fs = new FileStream(userFile, FileMode.Create, 
				FileAccess.Write|FileAccess.Read);
			StreamWriter writer = new StreamWriter(fs);
			ds.WriteXml(writer);
			writer.Close();
			fs.Close();

			return user_id;
		}

		public static UserDetails GetUser(int userId)
		{
			DataSet ds = new DataSet();
			//Initialize a string named userFile with the path to the Users.xml file. 
			String userFile = UserFile;
			//Read in the XML file to the ds DataSet
			FileStream fs = new FileStream(userFile, FileMode.Open,FileAccess.Read);
			StreamReader reader = new StreamReader(fs);
			ds.ReadXml(reader);
			fs.Close();
			
			ds.Tables[0].PrimaryKey = new DataColumn[] {ds.Tables[0].Columns["user_id"]};
			DataRow dr = ds.Tables[0].Rows.Find(userId);

			// Populate UserDetails Struct
			UserDetails ud = new UserDetails();
			ud.UserId = userId;
			ud.FirstName = dr["first_name"].ToString();
			ud.LastName =  dr["last_name"].ToString();
			ud.Email =  dr["email"].ToString();
			ud.Password = dr["password"].ToString();

			return ud;
		}
	}	
}
