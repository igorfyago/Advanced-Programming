<%@ Page language="c#" Codebehind="Register.aspx.cs" AutoEventWireup="false" Inherits="NTier.Web.Register" %>

<HTML>
  <HEAD>
<title>Register</title>
</HEAD>
    <body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0" marginheight="0" marginwidth="0">


                                <form runat="server" ID="Form1">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="ContentHead">Create a New Account
                                                <br>
                                            </td>
                                        </tr>
                                    </table>
                                    <img align="left" height="1" width="92" src="images/1x1.gif">
                                    <table height="100%" cellspacing="0" cellpadding="0" width="500" border="0">
                                        <tr valign="top">
                                            <td width="550">
                                                <br>
                                                <br>
                                                <span class="NormalBold">First Name</span>
                                                <br>
                                                <asp:TextBox size="25" id="FirstName" runat="server" />
                                                 
                                                <asp:RequiredFieldValidator ControlToValidate="FirstName" Display="dynamic" Font-Name="verdana" Font-Size="9pt" ErrorMessage="'First Name' must not be left blank." runat="server" ID="Requiredfieldvalidator1"></asp:RequiredFieldValidator>
                                                <br>
                                                <br>
                                                <span class="NormalBold">Last Name</span>
                                                <br>
                                                <asp:TextBox size="25" id="LastName" runat="server" />
                                                 
                                                <asp:RequiredFieldValidator ControlToValidate="LastName" Display="dynamic" Font-Name="verdana" Font-Size="9pt" ErrorMessage="'Last Name' must not be left blank." runat="server" ID="Requiredfieldvalidator5"></asp:RequiredFieldValidator>
                                                <br>
                                                <br>
                                                <span class="NormalBold">Email</span>
                                                <br>
                                                <asp:TextBox size="25" id="Email" runat="server" />
                                                 
                                                <asp:RegularExpressionValidator ControlToValidate="Email" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" Display="Dynamic" Font-Name="verdana" Font-Size="9pt" ErrorMessage="Must use a valid email address." runat="server" ID="Regularexpressionvalidator1"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ControlToValidate="Email" Display="dynamic" Font-Name="verdana" Font-Size="9pt" ErrorMessage="'Email' must not be left blank." runat="server" ID="Requiredfieldvalidator2"></asp:RequiredFieldValidator>
                                                <br>
                                                <br>
                                                <span class="NormalBold">Password</span>
                                                <br>
                                                <asp:TextBox size="25" id="Password" TextMode="Password" runat="server" />
                                                 
                                                <asp:RequiredFieldValidator ControlToValidate="Password" Display="dynamic" Font-Name="verdana" Font-Size="9pt" ErrorMessage="'Password' must not be left blank." runat="server" ID="Requiredfieldvalidator3"></asp:RequiredFieldValidator>
                                                <br>
                                                <br>
                                                <span class="NormalBold">Confirm Password</span>
                                                <br>
                                                <asp:TextBox size="25" id="ConfirmPassword" TextMode="Password" runat="server" />
                                                 
                                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" Display="dynamic" Font-Name="verdana" Font-Size="9pt" ErrorMessage="'Confirm' must not be left blank." runat="server" ID="Requiredfieldvalidator4"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ControlToValidate="ConfirmPassword" ControlToCompare="Password" Display="Dynamic" Font-Name="verdana" Font-Size="9pt" ErrorMessage="Password fields do not match." runat="server" id=CompareValidator1></asp:CompareValidator>
                                                <br>
                                                <br>
                                                <asp:LinkButton id=RegisterBtn runat="server" Text="Register"/>
                                                <br>
                                            </td>
                                        </tr>
                                    </table>
                                </form>
    </body>
</HTML>
