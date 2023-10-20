<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PaymentPage.aspx.cs" Inherits="WebAssignment.PaymentPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: left;
        }
        .auto-style3 {
            width: 446px;
        }
        .auto-style4 {
            width: 257px;
        }
        .auto-style5 {
            width: 167px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
            <div style="padding-top: 50px; padding-bottom: 80px;">
                <table align="center" style="width:500px; height:0px; background-color:#C0C0C0;">
                    <tr>
                        <td width="50%" class="auto-style1" style="width: 600px">
                            <h1 style="width: 600px">Payment</h1>
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" class="auto-style2" style="padding-top: 20px;">
                            &nbsp;&nbsp;&nbsp; Total Cost : <asp:Label ID="lblTotalCost" runat="server" Font-Bold="True"></asp:Label>
                            <br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" class="auto-style2" style="padding-top: 20px; padding-bottom: 20px; line-height: 25px;">
                            &nbsp;&nbsp;&nbsp;Cardholder Name
                            <asp:TextBox id="txtCardholderName" placeholder="Chua Meng Sin" runat="server" class="auto-style3" type="text" style="margin-right: 10px; margin-left: 10px; width: 90%" /></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldCardholderName" runat="server" ControlToValidate="txtCardholderName" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            &nbsp;
                            
                            <br />
&nbsp;&nbsp; Card number
                            <asp:TextBox id="txtCardNumber" placeholder="1234 5678 9015 3456" runat="server" type="text" class="auto-style3" style="margin-right: 10px; margin-left: 10px; width: 90%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldCardNumber" runat="server" ControlToValidate="txtCardNumber" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
&nbsp;
                            <asp:RegularExpressionValidator ID="RegularExpressionCardNumber" runat="server" ControlToValidate="txtCardNumber" ErrorMessage="*Correct Format Card Number is Required!" ForeColor="Red" ValidationExpression="(\d{4}\s{1}\d{4}\s{1}\d{4}\s{1}\d{4})|(\d{16})"></asp:RegularExpressionValidator>
                            
                            <br />
&nbsp;&nbsp;&nbsp; Expiry date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CVV&nbsp;&nbsp;&nbsp;
                            <br />
                            <asp:TextBox id="txtExpiryDate" placeholder="MM/YY" runat="server" class="auto-style4" type="text" style="margin-right: 10px; margin-left: 10px; width: 45%" /></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldExpiryDate" runat="server" ControlToValidate="txtExpiryDate" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:TextBox id="txtCVV" placeholder="3 digits" class="auto-style5" type="text" runat="server" style="margin-right: 10px; margin-left: 10px; width: 38%" /></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldCCV" runat="server" ControlToValidate="txtCVV" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            
                            &nbsp;
                            <br />
&nbsp;
                            
                            <asp:RegularExpressionValidator ID="RegularExpressionExpiryDate" runat="server" ControlToValidate="txtExpiryDate" ErrorMessage="*Correct Format Expiry Date is Required!" ForeColor="Red" ValidationExpression="^((0[1-9])|(1[0-2]))/([2][2-9]|[3][0-9])$"></asp:RegularExpressionValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RegularExpressionValidator ID="RegularExpressionCCV" runat="server" ControlToValidate="txtCVV" ErrorMessage="*Correct Format CCV is Required!" ForeColor="Red" ValidationExpression="\d{3}"></asp:RegularExpressionValidator>
                            
                            <br />
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" class="auto-style1" style="padding-top: 10px; padding-bottom: 10px;">
                            <asp:Button ID="btnCancelPay" runat="server" Font-Bold="True" Height="33px" Text="Cancel" Width="90px" BackColor="Red" ForeColor="White" OnClick="btnCancelPay_Click" CausesValidation="False" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnProceed" runat="server" Font-Bold="True" Height="33px" Text="Procced to Payment" Width="214px" BackColor="Lime" ForeColor="Black" OnClick="btnProceed_Click" />
                        &nbsp;&nbsp;&nbsp;
                            </td>
                    </tr>
                    </table>
            </div>
        </div>
</asp:Content>
