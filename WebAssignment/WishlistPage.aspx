<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="WishlistPage.aspx.cs" Inherits="WebAssignment.WishlistPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style2 {
            text-align: center;
        }
        .auto-style5 {
            text-align: right;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="auto-style2">
        <h2 class="auto-style1">
            Wishlist
        </h2>
    </div>
        <div class="auto-style2">
        
        <asp:DataList ID="DataList_Wishlist" runat="server" DataSourceID="" Width ="100%" class="text-center" OnItemCommand="DataList_Wishlist_ItemCommand">

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>
          <FooterStyle BackColor="#AAAADD" />
            <FooterTemplate>
                <table aria-multiline="False" border="1">
                    <tr>
                        <td style="width:1160px" class="auto-style5">&nbsp;</td>
                    </tr>
                </table>
            </FooterTemplate>  
        <HeaderStyle BackColor="#AAAADD" />
         <HeaderTemplate>
             <table aria-multiline="False" border="1" >
            <tr>
                        <td style="width:110px">Product Id</td>
                        <td style="width:120px">Product Name</td>
                        <td style="width:260px">Product Image</td>
                        <td style="width:240px">Product Description</td>
                        <td style="width:120px">Product Price</td>
                        <td style="width:120px">Artist</td>
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
                        <td style="width:250px">
                            <asp:Image ID="ProdImgLabel" runat="server" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ProdImg"))%>' Height ="250px" Width ="250px" />
                        </td>
                        <td style="width:240px" class="auto-style2">
                            <asp:Label ID="ProdDescLabel" runat="server" Text='<%# Eval("ProdDesc") %>' />
                        </td>
                        <td style="width:120px" class="auto-style2">
                            RM
                            <asp:Label ID="ProdPriceLabel" runat="server" Text='<%# Eval("ProdPrice") %>' />
                        </td>
                        <td style="width:120px" class="auto-style2">
                            <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                        </td>
                        <td style="width:100px">
                            <asp:Button ID="btnRemoveWishlist" runat="server" BackColor="#CC0000" ForeColor="White" Text="Remove" Width="100px" OnClick="btnRemoveWishlist_Click" CommandName="removeWishlist" CommandArgument='<%# Eval("WishlistId") %>'/>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        &nbsp;<br />
        </div>
        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Wishlist.WishlistId, Wishlist.UserId, Wishlist.ProdId, Products.ProdName, Products.ProdDesc, Products.ProdImg, Products.ProdPrice, Products.ProdQuant, Products.ArtistId, Users.UserName FROM Wishlist INNER JOIN Products ON Wishlist.ProdId = Products.ProdId INNER JOIN Users ON Products.ArtistId = Users.UserId"></asp:SqlDataSource>--%>
</asp:Content>
