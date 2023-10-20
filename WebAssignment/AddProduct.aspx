<%@ Page Language="C#" MasterPageFile ="~/Default.Master" AutoEventWireup ="true" CodeBehind="AddProduct.aspx.cs" Inherits="WebAssignment.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div style="height:630px">
            <table style="width:700px; height:590px; background-color:#99CCFF;" align="center">
                <tr>
                    <td align="center" width="50%" colspan="2">
                        <h1>Post your Artwork</h1><hr />
                    </td>
                    
                </tr>

                <tr>
                    <td align="center" width="50%">
                        <h3>Artwork Name:</h3>
                    </td>

                    <td width="50%">
                        <br />
                        <asp:TextBox ID="txtProdName" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="requiredProdName" runat="server" ControlToValidate="txtProdName" ErrorMessage="*Artwork Name is Required!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" width="50%">
                        <h3>Artwork Description:</h3>
                    </td>

                    <td width="50%">
                        <br />
                        <asp:TextBox ID="txtProdDesc" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <%--<textarea name="txtProdDesc" id="txtProdDesc" cols="20" rows="2"></textarea>--%>
                        <br />
                        <asp:RequiredFieldValidator ID="requiredProdDesc" runat="server" ControlToValidate="txtProdDesc" ErrorMessage="*Artwork Description is Required!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" width="50%">
                        <h3>Image:</h3>
                    </td>

                    <td width="50%">
                        <br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <br />
                        <asp:RequiredFieldValidator ID="requiredProdImg" runat="server" ControlToValidate="FileUpload1" ErrorMessage="*Artwork Image is Requried!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="validateImg" runat="server" ErrorMessage="*Please insert correct file format of image!" 
                                     ControlToValidate="FileUpload1" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>

                        <br />

                    </td>
                </tr>
                <tr>
                    <td align="center" width="50%">
                        <h3>Artwork Price (RM):</h3>
                    </td>

                    <td width="50%">
                        <br />
                        <asp:TextBox ID="txtProdPrice" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="requiredProdPrice" runat="server" ControlToValidate="txtProdPrice" ErrorMessage="*Artwork Price is Required!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="validatePriceFormat" ValidationExpression="^[1-9][0-9]*$" runat="server" ErrorMessage="*Please Enter Correct Artwork Price!" ControlToValidate="txtProdPrice" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" width="50%">
                        <h3>Artwork Quantity:</h3>
                    </td>

                    <td width="50%">
                        <br />
                        <asp:TextBox ID="txtProdQuant" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="requiredProdQuant" runat="server" ControlToValidate="txtProdQuant" ErrorMessage="*Artwork Quantity is Required!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <%--<asp:CompareValidator ID="validateQuantInt" runat="server" ControlToValidate="txtProdQuant" ErrorMessage="*Quantity must be an integer!" ForeColor="Red" Operator="DataTypeCheck" Type="Integer" Display="Dynamic" SetFocusOnError="True"></asp:CompareValidator>
                        <asp:CompareValidator ID="validateQuant" runat="server" ControlToValidate="txtProdQuant" ErrorMessage="*Quantity must be greater than zero!" ForeColor="Red" Operator="GreaterThan" Type="Integer" ValueToCompare="0" Display="Dynamic" SetFocusOnError="True"></asp:CompareValidator>--%>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidateQuant" ValidationExpression="^[1-9][0-9]*$" runat="server" ErrorMessage="*Please Enter Correct Artwork Quantity!" ControlToValidate="txtProdQuant" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="center" width="50%" colspan="2">
                        <asp:Button ID="btnPost" runat="server" Text="Post" Font-Bold="True" Height="33px" OnClick="btnPost_Click" Width="90px" />
                    </td>                    
                </tr>

                <tr>
                    <td align="center" width="50%" colspan="2">
                        <%--<asp:Label ID="postSuccessMsg" runat="server"></asp:Label>--%>
                       <asp:HyperLink ID="postSuccessLink" runat="server" NavigateUrl="~/ViewArtwork.aspx" style="color:purple; font-size:x-large; margin-left:430px; text-decoration: none" Font-Italic="True"></asp:HyperLink>
                    </td>                  
                </tr>
            </table>
        </div>
</asp:Content>

