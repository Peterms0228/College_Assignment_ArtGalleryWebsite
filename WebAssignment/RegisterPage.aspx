<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="WebAssignment.RegisterPage" %>

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
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" DefaultButton="btnRegister">
        <div>
            <div style="height:510px">
                <table align="center" style="width:700px; height:390px; background-color:#99CCFF;">
                    <tr>
                        <td align="center" colspan="2" width="50%">
                            <h1>Register</h1>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="50%">
                            <h3>User Name:</h3>
                        </td>
                        <td width="50%">
                            <br />
                            <asp:TextBox ID="txtUserName" runat="server" Width="310px"></asp:TextBox>
                            <br />
                            <asp:Label ID="msgExistedUser" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="requiredUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="*User Name is Required!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <br />
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

                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="50%">
                            <h3>Confirm Password:</h3>
                        </td>
                        <td width="50%">
                            <br />
                            <asp:TextBox ID="txtUserPasswConf" runat="server" Width="310px" TextMode="Password"></asp:TextBox>
                            <br />
                            <asp:Label ID="msgPasswUnmatch" runat="server"></asp:Label>
                            <asp:RequiredFieldValidator ID="requiredPassConf" runat="server" ControlToValidate="txtUserPasswConf" ErrorMessage="*Confirm Password is Required!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="50%">
                            <h3>
                                Profile Picture
                                </h3></td>
                        <td width="50%">
                            <br />
                        <asp:FileUpload ID="fuUserPic" runat="server" />
                            <br />
                            <asp:RegularExpressionValidator ID="validateImg" runat="server" ErrorMessage="*Please insert correct file format of image!" 
                                     ControlToValidate="fuUserPic" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="50%">
                           <h3>E-mail</h3>
                        </td>
                        <td width="50%">
                            <asp:TextBox ID="txtUserEmail" runat="server" Width="310px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="*Email is Requried!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="validateEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtUserEmail" ErrorMessage="*Invalid Email Format" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="50%">
                            <h3>
                            Phone Number (+60)
                                </h3></td>
                        <td width="50%">
                            <asp:TextBox ID="txtUserPhone" runat="server" Width="310px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredPhoneNo" runat="server" ControlToValidate="txtUserPhone" ErrorMessage="*Phone Number is Requried!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="validatePhoneNo" runat="server" ValidationExpression="^(\+?6?01)[02-46-9]-*[0-9]{7}$|^(\+?6?01)[1]-*[0-9]{8}$" ControlToValidate="txtUserPhone" ErrorMessage="*Invalid Phone Number Format" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" width="50%">
                            <h3>Address
                                </h3>
                        </td>
                        <td width="50%">
                            <asp:TextBox ID="txtUserAddr" runat="server" TextMode="MultiLine" Width="310px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredAddress" runat="server" ControlToValidate="txtUserAddr" ErrorMessage="*Address is Requried!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>                       
                        <td colspan="2" width="50%" class="auto-style2">
                            <br />
                            <asp:Button ID="btnCancelRegs" runat="server" Font-Bold="True" Height="33px" OnClick="btnCancelRegs_Click" Text="Cancel" Width="90px" BackColor="Red" ForeColor="White" ValidationGroup="cancel" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRegister" runat="server" Font-Bold="True" Height="33px" OnClick="btnUserRegs_Click" Text="Register" Width="120px" BackColor="Lime" ForeColor="Black" />
                        &nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="hlToLoginPage" runat="server" Font-Italic="False" Font-Underline="True" ForeColor="#000066" NavigateUrl="~/LoginPage.aspx" Visible="False">Go To Login Page</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" width="50%" class="auto-style2">
                            <asp:Label ID="msgRegisterFeedback" runat="server"></asp:Label>
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
