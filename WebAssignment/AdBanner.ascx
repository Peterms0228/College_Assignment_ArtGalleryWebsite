<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdBanner.ascx.cs" Inherits="WebAssignment.AdBanner" %>
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
                                <asp:Image ID="BannerImage" runat="server" BackColor="White" BorderColor="Gray" BorderStyle="Double" Height="260px" Width="1100px" style="margin-left:10px" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
</table>
    </div>