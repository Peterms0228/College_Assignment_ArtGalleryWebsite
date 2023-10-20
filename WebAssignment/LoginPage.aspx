<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebAssignment.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link runat="server" rel="shortcut icon" href="~/Images/test.ico" type="image/x-icon"/>
    <link runat="server" rel="icon" href="~/Images/test.ico" type="image/ico"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            height: 37px;
        }
        .auto-style2 {
            height: 62px;
        }
        .auto-style3 {
            height: 45px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" DefaultButton="btnLogin">
        <div>
                <table align="center" style="width:700px; height:390px; background-color:#99CCFF;">
                    <tr>
                        <td align="center" colspan="2" width="50%" class="auto-style2">
                            <h3>&nbsp;</h3>
                            <h1>Login</h1>
                            <p>&nbsp;</p>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="50%" class="auto-style3">
                            <h3>User Name:</h3>
                        </td>
                        <td width="50%" class="auto-style3">
                            <br />
                            <asp:TextBox ID="txtUserName" runat="server" Width="310px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="*User Name is Required!" ForeColor="Red"  SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="50%" class="auto-style1">
                            <h3>Password:</h3>
                        </td>
                        <td width="50%" class="auto-style1">
                            <br />
                            <asp:TextBox ID="txtUserPassw" runat="server" Width="310px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredUserPassw" runat="server" ControlToValidate="txtUserPassw" ErrorMessage="*Password is Required!" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" width="50%">
                            <asp:Button ID="btnCancelLogin" runat="server" Font-Bold="True" Height="33px" OnClick="btnCancelLogin_Click" Text="Cancel" Width="90px" BackColor="Red" ForeColor="White" ValidationGroup="cancel" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnLogin" runat="server" Font-Bold="True" Height="33px" OnClick="btnLogin_Click" Text="Login" Width="120px" BackColor="Lime" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" width="50%">
                            <asp:HyperLink ID="HyperLink1" runat="server" BorderStyle="None" ForeColor="#000066" NavigateUrl="~/RegisterPage.aspx">Not a member? Register one!</asp:HyperLink>
                        </td>
                    </tr>
                </table>
        </div>
    </form>
</body>
</html>
