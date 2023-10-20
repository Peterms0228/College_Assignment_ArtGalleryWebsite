<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ReceiptPage.aspx.cs" Inherits="WebAssignment.ReceiptPage" %>
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
            <h2>
                Receipt id:
                <asp:Label ID="lblReceiptId" runat="server"></asp:Label>
            </h2>
            <p>
                <table class="auto-style6">
                    <tr>
                        <td class="auto-style4">Purchased By:
                            <asp:Label ID="lblPurchasedBy" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style5">Date:
                            <asp:Label ID="lblReceiptDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Delivery To:
                            <asp:Label ID="lblDeliveryTo" runat="server"></asp:Label>
                        </td>
                        <td class="auto-style5">Time:
                            <asp:Label ID="lblReceiptTime" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </p>
        </div>
        <div class="auto-style2">
        
        <asp:DataList ID="DataList_Receipt" runat="server" DataSourceID="" Width ="100%" class="text-center" OnItemDataBound="DataList_Receipt_ItemDataBound">

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>
        <FooterStyle BackColor="#AAAADD" />
            <FooterTemplate>
                <div class="auto-style5">
                    Total Payment:
                    <asp:Label ID="lblTotalPrice" runat="server" Font-Bold="True"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                </div>
            </FooterTemplate>
            
        <HeaderStyle BackColor="#AAAADD" />
         <HeaderTemplate>
             <table aria-multiline="False" border="1" >
            <tr>
                        <td style="width:100px">Product Id</td>
                        <td style="width:120px">Product Name</td>
                        <td style="width:205px">Product Image</td>
                        <td style="width:185px">Product Description</td>
                        <td style="width:110px">Product Price</td>
                        <td style="width:110px">Artist Name</td>
                        <td style="width:100px">Cart Quantity</td>
                        <td style="width:110px">Total Price</td>
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
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT AddToCart.*, Products.*, Users.* FROM AddToCart INNER JOIN Users ON AddToCart.SellerId = Users.UserId INNER JOIN Products ON AddToCart.ProdId = Products.ProdId AND Users.UserId = Products.ArtistId"></asp:SqlDataSource>--%>
            <br />
        </div>
       </asp:Content>
