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

namespace NTier.Web
{
	/// <summary>
	/// Summary description for Register.
	/// </summary>
	public class Register : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.TextBox Email;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.TextBox Password;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.TextBox ConfirmPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.TextBox FirstName;
		protected System.Web.UI.WebControls.TextBox LastName;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
		protected System.Web.UI.WebControls.LinkButton RegisterBtn;
	
		public Register()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.RegisterBtn.Click += new System.EventHandler(this.RegisterBtn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void RegisterBtn_Click(object sender, System.EventArgs e)
		{
			// Only attempt a login if all form fields on the page are valid
			if (Page.IsValid == true) 
			{

				int user_id = BLL.Users.AddUser(FirstName.Text, LastName.Text, Email.Text, Password.Text);

				if (user_id > 0) 
				{

					// Set the user's authentication name to the user_id
					FormsAuthentication.SetAuthCookie(user_id.ToString(), false);

					// Store the user's fullname in a cookie for personalization purposes
					//Response.Cookies["IBuySpy_FullName"].Value = Name.Text;

					// Redirect browser back to secure page
					Response.Redirect("Secure.aspx");
				}
			}

		}
	}
}
