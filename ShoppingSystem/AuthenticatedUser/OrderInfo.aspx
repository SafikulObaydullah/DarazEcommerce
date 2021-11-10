<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderInfo.aspx.cs" Inherits="ShoppingSystem.AuthenticatedUser.OrderInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
                <h2>Shipping Information</h2>
            <div class="form-group">
                <label class="control-label">Name</label>
                <asp:TextBox ID="txtname" runat="server" Cssclass="form-control" ></asp:TextBox>
            </div>
             <div class="form-group">
                <label class="control-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
              <div class="form-group">
                <label class="control-label">Contact Number</label>
                <asp:TextBox ID="txtcon" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
              <div class="form-group">
                <label class="control-label">Shipping Address</label>
                <asp:TextBox ID="txtAdd" runat="server"  CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-12">
            <h2>Shopping cart</h2>
                         <asp:ListView ID="productList" runat="server"          
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
                 <LayoutTemplate>
                     <table class="table table-bordered">
                            <tr>
                                <td>Image</td>
                                <td>Name</td>
                                <td>Price</td>
                                <td>Qty</td>
                                <td>total</td>
                               
                            </tr>
                         <tbody>
                             <asp:PlaceHolder id="itemPlaceholder" runat="server"></asp:PlaceHolder>
                         </tbody>
                         </table>

                 </LayoutTemplate>
              
                <ItemTemplate>
                  
                            <tr>
                                <td>
                                    
                                   
                                        <img src='<%#Eval("Product.FeaturedPic") %>'
                                            width="100" height="75" style="border: solid" />
                                </td>
                                 <td>
                                    
                                       <asp:Label runat="server" Text='<%#Eval("Product.Name") %>'></asp:Label>
                                    
                                   
                                </td>
                                 <td>
                                  
                                   <asp:Label runat="server" Text='<%#Eval("Product.Price") %>'></asp:Label>
                                  
                                </td>
                                 
                                 <td>
                                  
                                   <asp:Label runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                  
                                </td>
                                <td>
                                     <asp:Label runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                                </td>
                               
                            </tr>
                         
                </ItemTemplate>
             
            </asp:ListView>
        </div> 
        <div class="col-md-12">
            <asp:Button ID="btncheckout" CssClass="btn btn-success" runat="server" Text="Chek Out" OnClick="btncheckout_Click" />
        </div>
    </div>
</asp:Content>
