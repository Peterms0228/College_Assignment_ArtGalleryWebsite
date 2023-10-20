<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="WebAssignment.AddToCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
        .auto-style4 {
            text-align: left;
        }
        .auto-style5 {
            text-align: right;
        }
        .auto-style6 {
            width: 100%;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style4">
        <div class="auto-style2">
                    <h2>Your have
        <asp:Label ID="lblAddToCartNo" runat="server">0</asp:Label>
                        products inside your cart.</h2>
        
        </div>
        <div class="auto-style2">
        
        <asp:DataList ID="DataList_AddToCart" runat="server" DataSourceID="" Width ="100%" class="text-center" OnItemCommand="DataList_AddToCart_ItemCommand" OnItemDataBound="DataList_AddToCart_ItemDataBound">

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>
        <FooterStyle BackColor="#AAAADD" />
            <FooterTemplate>
                <table aria-multiline="False" border="1">
                    <tr>
                        <td style="width:1060px" class="auto-style5">Total Price: 
                            <asp:Label ID="lblTotalPrice" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width:105px">
                            <asp:Button ID="btnCheckOut" runat="server" BackColor="Lime" Text="Check Out" Width="100px" OnClick="btnCheckOut_Click"/>
                        </td>
                    </tr>
                </table>
            </FooterTemplate>
            
        <HeaderStyle BackColor="#AAAADD" />
         <HeaderTemplate>
             <table aria-multiline="False" border="1" >
            <tr>
                        <td style="width:100px">Product Id</td>
                        <td style="width:110px">Product Name</td>
                        <td style="width:235px">Product Image</td>
                        <td style="width:185px">Product Description</td>
                        <td style="width:105px">Product Price</td>
                        <td style="width:115px">Artist Name</td>
                        <td style="width:90px">Cart Quantity</td>
                        <td style="width:110px">Total Price</td>
                        <td style="width:105px">
                            <asp:Button ID="btnRemoveAll" runat="server" BackColor="#990000" ForeColor="White" Width="100px" OnClick="btnRemoveAll_Click" Text="Remove All" />
                        </td>
                    </tr>
             </table>
         </HeaderTemplate>
            <ItemTemplate>

                <table aria-multiline="False" border="1">
                    <tr>
                        <td style="width:110px" class="auto-style2">
                            <asp:Label ID="ProdIdLabel" runat="server" Text='<%# Eval("ProdId") %>' />
                        </td>
                        <td style="width:120px" class="auto-style2">
                            <asp:Label ID="ProdNameLabel" runat="server" Text='<%# Eval("ProdName") %>' />
                        </td>
                        <td style="width:200px">
                            <asp:Image ID="ProdImgLabel" runat="server" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ProdImg"))%>' Height ="200px" Width ="200px" />
                        </td>
                        <td style="width:195px" class="auto-style2">
                            <asp:Label ID="ProdDescLabel" runat="server" Text='<%# Eval("ProdDesc") %>' />
                        </td>
                        <td style="width:120px" class="auto-style2">
                            RM
                            <asp:Label ID="ProdPriceLabel" runat="server" Text='<%# Eval("ProdPrice") %>' />
                        </td>
                        <td style="width:120px" class="auto-style2">
                            <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                        </td>
                        <td style="width:105px" class="auto-style2">
                            <asp:Label ID="CartQuantLabel" runat="server" Text='<%# Eval("CartQuant") %>' />
                        </td>
                        <td style="width:120px" class="auto-style2">
                            RM
                            <asp:Label ID="CartPriceLabel" runat="server" Text='<%# Eval("CartPrice") %>' />
                        </td>
                        <td style="width:105px">
                            <asp:Button ID="btnRemoveCart" runat="server" BackColor="#CC0000" ForeColor="White" Text="Remove" Width="100px" OnClick="btnRemoveCart_Click" CommandName="removeCart" CommandArgument='<%# Eval("CartId") %>'/>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT AddToCart.*, Products.*, Users.* FROM AddToCart INNER JOIN Users ON AddToCart.SellerId = Users.UserId INNER JOIN Products ON AddToCart.ProdId = Products.ProdId AND Users.UserId = Products.ArtistId"></asp:SqlDataSource>--%>
            <br />
        </div>
       </asp:Content>
