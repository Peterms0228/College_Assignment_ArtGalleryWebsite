<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ViewArtwork.aspx.cs" Inherits="WebAssignment.ViewArtwork" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div align ="center" style="height:auto">

    <table>
        <tr>
            <td>
                <h2><u>Your Posted Artwork</u></h2>
            </td>
        </tr>
    </table>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="You haven't posted any Artwork!" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="Artwork ID">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("ProdId") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <EditItemTemplate>
                        <br />
                        <asp:TextBox ID="txtboxName" runat="server" Text='<%# Eval("ProdName") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredProdName" runat="server" ControlToValidate="txtboxName" ErrorMessage="*Artwork Name is Required!" ForeColor="Red" Display="Static" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("ProdName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <EditItemTemplate>
                        <br />
                        <asp:TextBox ID="txtboxDesc" runat="server" Text='<%# Eval("ProdDesc") %>' TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredProdDesc" runat="server" ControlToValidate="txtboxDesc" ErrorMessage="*Artwork Description is Required!" ForeColor="Red" Display="Static" SetFocusOnError="True"></asp:RequiredFieldValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("ProdDesc") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image">
                    <EditItemTemplate>
                        <asp:Image ID="Image3" runat="server" Height="101px" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ProdImg"))  %>' Width="100px" />
                        <asp:FileUpload ID="FileUpload1" runat="server"/>
                        <asp:RegularExpressionValidator ID="validateImg" runat="server" ErrorMessage="*Please insert correct file format of image!" 
                                     ControlToValidate="FileUpload1" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>

                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image3" runat="server" Height="101px" ImageUrl='<%# "data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ProdImg"))  %>' Width="100px" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price(RM)">
                    <EditItemTemplate>
                        
                        <asp:TextBox ID="txtboxPrice" runat="server" Text='<%# Eval("ProdPrice") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredProdPrice" runat="server" ControlToValidate="txtboxPrice" ErrorMessage="*Artwork Price is Required!" ForeColor="Red" Display="Dynamic" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="validatePriceFormat" ValidationExpression="^[1-9][0-9]*$" runat="server" ErrorMessage="*Please Enter Correct Artwork Price!" ControlToValidate="txtboxPrice" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("ProdPrice") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <EditItemTemplate>
                        
                        <asp:TextBox ID="txtboxQuant" runat="server" Text='<%# Eval("ProdQuant") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredProdQuant" runat="server" ControlToValidate="txtboxQuant" ErrorMessage="*Artwork Quantity is Required!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>                        
                        <asp:RegularExpressionValidator ID="RegularExpressionValidateQuant" ValidationExpression="^[1-9][0-9]*$" runat="server" ErrorMessage="*Please Enter Correct Artwork Quantity!" ControlToValidate="txtboxQuant" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("ProdQuant") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ButtonType="Button">
                <ControlStyle BackColor="Lime" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button OnClientClick="return confirm('Are you sure to delete the selected Artwork?');" ID="Button1" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                    </ItemTemplate>
                    <ControlStyle BackColor="Red" ForeColor="White" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />
        </asp:GridView>
    </div>
</asp:Content>