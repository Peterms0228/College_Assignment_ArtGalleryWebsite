<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ProductMenu.aspx.cs" Inherits="WebAssignment.ProductMenu" %>
<%@ Register TagPrefix="tag" TagName="adBanner" Src="~/AdBanner.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style2">
            <div class="auto-style1">
                <tag:adBanner ID="KLBannerControl" runat="server" />
            </div>
            <asp:DataList ID="DataList_Product" runat="server" DataKeyField="ProdId" RepeatColumns="4" RepeatDirection="Horizontal" OnItemCommand="DataList_Product_ItemCommand" OnItemDataBound="DataList_Product_ItemDataBound">
                <ItemTemplate>
                    <table border="1" class="auto-style1">
                        <tr>
                            <td class="auto-style1">
                                Product Id : 
                                <asp:Label ID="dlProdId" runat="server" Text='<%# Eval("ProdId") %>' BorderColor="Black"></asp:Label>
                             </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                Name :
                                <asp:Label ID="dlProdName" runat="server" Text='<%# Eval("ProdName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Image ID="dlProdImg" runat="server" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ProdImg"))%>' Height ="270px" Width ="270px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                Description:<br />
                                <asp:Label ID="dlProdDesc" runat="server" Text='<%# Eval("ProdDesc") %>'></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td class="auto-style1">Artist :
                                <asp:Label ID="dlArtistName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                Price : RM
                                <asp:Label ID="dlProdPrice" runat="server" Text='<%# Eval("ProdPrice") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Label ID="dlProdQuant" runat="server" Text='<%# Eval("ProdQuant") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">To buy
                                <asp:DropDownList ID="ddlToBuy" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                &nbsp;<asp:ImageButton ID="btnAddToWishlist" runat="server" Height="33px" ImageAlign="Middle" Width="36px" OnClick="btnAddToWishlist_Click" CommandName="addToWishlist" CommandArgument='<%# Eval("ProdId") %>'/>
                                &nbsp;
                                <asp:ImageButton ID="btnAddToCart" runat="server" Height="49px" ImageAlign="Middle" ImageUrl="~/Images/add-to-cart.png" Width="171px" CommandName="addToCart" OnClick="btnAddToCart_Click" CommandArgument='<%# Eval("ProdId") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Products.ProdId, Products.ProdName, Products.ProdDesc, Products.ProdImg, Products.ProdPrice, Products.ProdQuant, Products.ArtistId, Users.UserName FROM Products INNER JOIN Users ON Products.ArtistId = Users.UserId"></asp:SqlDataSource>--%>
        </div>
        </asp:Content>
