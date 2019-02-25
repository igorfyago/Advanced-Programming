using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using NTier.BLL;
using NTier.Common;
using NTier.Data.Sql;

namespace NTier.WebService
{
	/// <summary>
	/// Summary description for NTier.
	/// </summary>
	[WebService(Namespace="http://aspalliances.com/webservices/")]
	public class NTier : System.Web.Services.WebService
	{
		public NTier()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
		}

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

		[WebMethod (Description="A login method that returns a user_id.  User ID must be greater than zero to be valid.")]
		public int Login(string Email, string Password)
		{
            return new Security(new SqlUserRepository()).Login(Email, Password);
		}

		[WebMethod (Description="Adds a user to the database.")]
		public int Register(string FirstName, string LastName, string Email, string Password)
		{
			return BLL.Users.AddUser(FirstName, LastName, Email, Password);
		}

		[WebMethod (Description="Retrieves a user record from the database.")]
		public UserDetails GetUser(string userID)
		{
			if(userID == "") userID = "0";
			return BLL.Users.GetUser(Int32.Parse(userID));
		}
	}
}
