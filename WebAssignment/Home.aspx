<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebAssignment.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <table style="width:1105px;border-spacing:0px;margin-top:-27px">
            
            <tr style="width:1100px; height:320px">
                    <td colspan="3">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">

                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick">

                                </asp:Timer>
                                <asp:Image ID="bannerImage" runat="server" BackColor="White" BorderColor="Gray" BorderStyle="Double" Height="260px" Width="1100px" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>

            <tr style="height:200px;text-align:center;background-color:#99CCFF">
                    <td colspan="3">
                        <h2>Hi Art Lover, Welcome to Mr.P Artwork Gallery</h2>
                        <h2>You can buy or sell artwork here with just a few steps!</h2>
                        
                        <h3>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/RegisterPage.aspx" style="color:brown;text-decoration: none;margin-right:80px" Font-Italic="True" Font-Strikeout="False">Sign Up Now to get Started</asp:HyperLink>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ProductMenu.aspx" style="color:brown;text-decoration: none" Font-Italic="True">Visit Artwork Gallery</asp:HyperLink>
                        </h3>

                    </td>
            </tr>
        </table>
    </div>
    
</asp:Content>
