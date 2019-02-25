<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="NTier.Web.Login" %>

<HTML>
  <HEAD>
        <title>Login</title>

<script runat="server">

    //*******************************************************
    //
    // The LoginBtn_Click event is used on this page to
    // authenticate a customer's supplied username/password
    // credentials against a database.
    //
    // If the supplied username/password are valid, then
    // the event handler adds a cookie to the client
    // (so that we can personalize the home page's welcome
    // message), migrates any items stored in the user's
    // temporary (non-persistent) shopping cart to their
    // permanent customer account, and then redirects the browser
    // back to the originating page.
    //
    //*******************************************************



</script>
</HEAD>
    <body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0" marginheight="0" marginwidth="0">
                    <table height="100%" align="left" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr valign="top">
                            <td nowrap>
                                <br>
                                <form runat="server" ID="Form1">
                                    <img align="left" width="24" height="1" src="images/1x1.gif">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="ContentHead">Sign Into Your Account
                                                <br>
                                            </td>
                                        </tr>
                                    </table>
                                    <img align="left" height="1" width="92" src="images/1x1.gif">
                                    <table height="100%" cellspacing="0" cellpadding="0" border="0">
                                        <tr valign="top">
                                            <td width="550">
                                                <asp:Label id="Message" class="ErrorText" runat="server" />
                                                <br>
                                                <br>
                                                 <span class="NormalBold">Email</span>
                                                <br>
                                                 <asp:TextBox size="25" id="email" runat="server" /> 
                                                <asp:RequiredFieldValidator id="emailRequired" ControlToValidate="email" Display="dynamic" Font-Name="verdana" Font-Size="9pt" ErrorMessage="'Name' must not be left blank." runat="server" />
                                                <asp:RegularExpressionValidator id="emailValid" ControlToValidate="email" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" Display="Dynamic" ErrorMessage="Must use a valid email address." runat="server" />
                                                <br>
                                                <br>
                                                 <span class="NormalBold">Password</span>
                                                <br>
                                                 <asp:TextBox id="password" textmode="password" size="25" runat="server" /> 
                                                <asp:RequiredFieldValidator id="passwordRequired" ControlToValidate="password" Display="Static" Font-Name="verdana" Font-Size="9pt" ErrorMessage="'Password' must not be left blank." runat="server" />
                                                <br>
                                                <br>
                                                <br>
                                                <asp:LinkButton id="LoginBtn" runat="server" Text="Sign In"/>
                                                <br>
                                                <br>
                                                <span class="Normal"> If you are a new user and you don't have an account with IBuySpy, then register for one now.</span>
                                                <br>
                                                <br>
                                                <a href="register.aspx">Register</a>
                                            </td>
                                        </tr>
                                    </table>
                                </form>
                            </td>
                        </tr>
                    </table>

    </body>
</HTML>
