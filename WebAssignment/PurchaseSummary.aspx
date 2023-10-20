 <%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="PurchaseSummary.aspx.cs" Inherits="WebAssignment.PurchaseSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style2">
        <h2 class="auto-style1">
            Purchased Summary
        </h2>
    </div>
    <div class="auto-style2">
        
        <asp:DataList ID="DataList_PurcSummary" runat="server" DataSourceID="" Width ="100%" class="text-center" OnItemCommand="DataList_PurcSummary_ItemCommand">

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
                        <td style="width:100px" class="auto-style1">Product Id</td>
                        <td style="width:110px" class="auto-style1">Product Name</td>
                        <td style="width:235px" class="auto-style1">Product Image</td>
                        <td style="width:105px" class="auto-style1">Product Price</td>
                        <td style="width:105px" class="auto-style1">Artist Name</td>
                        <td style="width:80px" class="auto-style1">Cart Quantity</td>
                        <td style="width:110px" class="auto-style1">Total Price</td>
                        <td style="width:110px" class="auto-style1">Purchase Date</td>
                        <td style="width:110px" class="auto-style1">Purchase Time</td>
                        <td style="width:105px" class="auto-style1">
                            <asp:Button ID="btnRemoveAll" runat="server" BackColor="#990000" ForeColor="White" Width="100px" OnClick="btnRemoveAll_Click" Text="Remove All" />
                        </td>
                    </tr>
             </table>
         </HeaderTemplate>
            <ItemTemplate>

                <table aria-multiline="False" border="1">
                    <tr>
                        <td style="width:110px" class="auto-style1">
                            <asp:Label ID="ProdIdLabel" runat="server" Text='<%# Eval("ProdId") %>' />
                        </td>
                        <td style="width:120px" class="auto-style1">
                            <asp:Label ID="ProdNameLabel" runat="server" Text='<%# Eval("ProdName") %>' />
                        </td>
                        <td style="width:200px" class="auto-style1">
                            <asp:Image ID="ProdImgLabel" runat="server" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ProdImg"))%>' Height ="200px" Width ="200px" />
                        </td>
                        <td style="width:120px" class="auto-style1">
                            RM
                            <asp:Label ID="ProdPriceLabel" runat="server" Text='<%# Eval("ProdPrice") %>' />
                        </td>
                        <td style="width:110px" class="auto-style1">
                            <asp:Label ID="ArtistName" runat="server" Text='<%# Eval("UserName") %>' />
                        </td>
                        <td class="auto-style1" style="width:105px">
                            <asp:Label ID="CartQuantLabel" runat="server" Text='<%# Eval("CartQuant") %>' />
                        </td>
                        <td style="width:120px" class="auto-style1">
                            RM
                            <asp:Label ID="CartPriceLabel" runat="server" Text='<%# Eval("CartPrice") %>' />
                        </td>
                        <td style="width:115px" class="auto-style1">
                            <asp:Label ID="PurcDate" runat="server" Text='<%# Eval("BuyDate") %>' />
                        </td>
                        <td class="auto-style1" style="width:120px">
                            <asp:Label ID="PurcTime" runat="server" Text='<%# Eval("BuyTime") %>' />
                        </td>
                        <td style="width:105px" class="auto-style1">
                            <asp:Button ID="btnRemoveHistory" runat="server" BackColor="#CC0000" ForeColor="White" Text="Remove" Width="100px" OnClick="btnRemoveHistory_Click" CommandName="removeHistory" CommandArgument='<%# Eval("HistoryId") %>' />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT AddToCart.*, Products.*, Users.* FROM AddToCart INNER JOIN Users ON AddToCart.SellerId = Users.UserId INNER JOIN Products ON AddToCart.ProdId = Products.ProdId AND Users.UserId = Products.ArtistId"></asp:SqlDataSource>--%>
            <br />
        </div>
</asp:Content>
