<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="WebAssignment.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
        .auto-style3 {
            height: 31px;
        }
        .auto-style6 {
            width: 75%;
        }
        .auto-style7 {
            width: 34%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
            <table align="center" style="width:700px; height:390px; background-color:#99CCFF;">
                    <tr>
                        <td align="center" class="auto-style6">
                            <h2>User Profile</h2>
                            &nbsp;<asp:DataList ID="DataList1" runat="server" BackColor="#99CCFF" CellPadding="30">
                                <ItemTemplate>
                                    <asp:Image ID="imgUserImg" runat="server" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("UserImg"))%>' Height ="200px" Width ="200px" />
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                        <td align="center" width="50%">
                <table align="center" style="width:700px; height:390px; background-color:#99CCFF;" border="1">
                    <tr>
                        <td align="center" class="auto-style7">
                            <h3>User Name:</h3>
                        </td>
                        <td width="50%">
                            <asp:Label ID="lblUserName" runat="server" Font-Bold="True" Width="98%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style7">
                            <h3>
                                Old Password
                            </h3></td>
                        <td width="50%">
                            <asp:TextBox ID="txtUserPasswOld" placeholder="Leave it blank if you don't want to change password" runat="server" Width="98%" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style7">
                            <h3>New Password:</h3>
                        </td>
                        <td width="50%" class="auto-style1">
                            <asp:TextBox ID="txtUserPasswNew" placeholder="Leave it blank if you don't want to change password" runat="server" Width="98%" TextMode="Password"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style7">
                            <h3>Confirm Password:</h3>
                        </td>
                        <td width="50%">
                            <asp:TextBox ID="txtUserPasswConf" placeholder="Leave it blank if you don't want to change password" runat="server" Width="98%" TextMode="Password"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style7">
                            <h3>
                                Profile Picture
                                </h3></td>
                        <td width="50%">
                        <asp:FileUpload ID="fuUserPic" placeholder="Leave it blank if you don't want to change password" runat="server" Width="400px" />
                            <asp:RegularExpressionValidator ID="validateImg" runat="server" ErrorMessage="*Please insert correct file format of image!" 
                                     ControlToValidate="fuUserPic" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" Display="Static" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style7">
                            <h3>E-mail</h3>
                        </td>
                        <td width="50%">
                            <asp:TextBox ID="txtUserEmail" runat="server" Width="98%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="*Email is Requried!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="validateEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtUserEmail" ErrorMessage="*Invalid Email Format" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style7">
                            <h3>
                            Phone Number
                                </h3></td>
                        <td width="50%">
                            <asp:TextBox ID="txtUserPhone" runat="server" Width="98%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredPhoneNo" runat="server" ControlToValidate="txtUserPhone" ErrorMessage="*Phone Number is Requried!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="validatePhoneNo" runat="server" ValidationExpression="^(\+?6?01)[02-46-9]-*[0-9]{7}$|^(\+?6?01)[1]-*[0-9]{8}$" ControlToValidate="txtUserPhone" ErrorMessage="*Invalid Phone Number Format" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style7">
                            <h3>Address
                                </h3></td>
                        <td width="50%">
                            <asp:TextBox ID="txtUserAddr" runat="server" TextMode="MultiLine" Width="98%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredAddress" runat="server" ControlToValidate="txtUserAddr" ErrorMessage="*Address is Requried!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" width="50%">
                            <asp:Button ID="btnCancelRegs" runat="server" Font-Bold="True" Height="33px" Text="Cancel" Width="90px" BackColor="Red" ForeColor="White" OnClick="btnCancelRegs_Click" ValidationGroup="cancel" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRegister" runat="server" Font-Bold="True" Height="33px" Text="Update" Width="150px" BackColor="Lime" OnClick="btnRegister_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" width="50%" class="auto-style3">
                            <asp:Label ID="msgUpdateFeedback" runat="server" Width="98%"></asp:Label>
                        </td>
                    </tr>
                </table>
                        </td>
                    </tr>
                    </table>
        </div>
</asp:Content>
