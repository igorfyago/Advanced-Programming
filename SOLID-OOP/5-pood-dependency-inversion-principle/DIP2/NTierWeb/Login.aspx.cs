using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using NTier.Data.Sql;

namespace NTier.Web
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Message;
		protected System.Web.UI.WebControls.TextBox email;
		protected System.Web.UI.WebControls.RequiredFieldValidator emailRequired;
		protected System.Web.UI.WebControls.RegularExpressionValidator emailValid;
		protected System.Web.UI.WebControls.TextBox password;
		protected System.Web.UI.WebControls.RequiredFieldValidator passwordRequired;
		protected System.Web.UI.WebControls.CheckBox RememberLogin;
		protected System.Web.UI.WebControls.LinkButton LoginBtn;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
	
		public Login()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		private void LoginBtn_Click(object sender, System.EventArgs e)
		{

			// Only attempt a login if all form fields on the page are valid
			if (Page.IsValid == true) 
			{
			
				// Attempt to Validate User Credentials using Security class
                int user_id = new BLL.Security(new SqlUserRepository()).Login(email.Text, password.Text);

				if (user_id > 0) 
				{
/*
					// Store the user's fullname in a cookie for personalization purposes
					Response.Cookies["IBuySpy_FullName"].Value = customerDetails.FullName;

					// Make the cookie persistent only if the user selects "persistent" login checkbox
					if (RememberLogin.Checked == true) 
					{
						Response.Cookies["IBuySpy_FullName"].Expires = DateTime.Now.AddMonths(1);
					}
*/
					// Redirect browser back to originating page
					FormsAuthentication.RedirectFromLoginPage(user_id.ToString(), false);
				}
				else 
				{
					Message.Text = "Login Failed!";
				}
			}
		}
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	}
}
