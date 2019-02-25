using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using NTier.BLL;
using NTier.Common;

namespace NTierWeb
{
    public class WebForm1 : Page
    {
        protected Label lblAppName;
        protected Label lblUser;

        public WebForm1()
        {
            Page.Init += Page_Init;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblUser.Text = "(" + Page.User.Identity.Name + ") ";
                UserDetails ud = Users.GetUser(Int32.Parse(Page.User.Identity.Name));
                lblUser.Text += ud.FirstName + " " + ud.LastName + " (" + ud.Email + ")";
                lblAppName.Text = BLL.ApplicationName;
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
            this.Load += new System.EventHandler(this.Page_Load);
        }

        #endregion
    }
}