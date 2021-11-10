<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShoppingSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 style="text-align:center; font-size:60px; color:green">Welcome To Our Shopping System </h1>

    
    <img src="Images/homepic-Omega%20model.jpg" width="1000" height="200" style="margin-bottom:30px;" /><br />

    <h1 style="text-align:center; color:magenta">Please, Choose Your Product </h1>
    <div class="row">
        <div class="col-md-12">
            <asp:ObjectDataSource ID="PrdObjDataSource" runat="server" 
                SelectMethod="GetAll" TypeName="ShoppingSystem.DAL.ProductAcc"></asp:ObjectDataSource>
             <asp:ListView ID="productList" runat="server" 
                DataKeyNames="ID" GroupItemCount="6"
                 >
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    
                                     <a href='<%# Eval("Id", "ProductDetails.aspx?Id={0}") %>'>
                                        <img src='<%#Eval("FeaturedPic") %>'
                                            width="100" height="75" style="border: solid" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href='<%# Eval("Id", "ProductDetails.aspx?Id={0}") %>'>
                                       <asp:Label runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    </a>
                                    <br />
                                   <asp:Label runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                                    <br />    
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                     
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
            <br />
        </div>
    </div>

</asp:Content>
