<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="ShoppingSystem.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
           <h2>Shopping Cart Items</h2>
             <asp:ListView ID="productList" runat="server" OnItemCommand="productList_ItemCommand"          
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
                                <td>
                                   ..........

                                </td>
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
                                <td>
                                     <asp:LinkButton ID="btnremove" runat="server" Text="remove"  CommandArgument='<%#Eval("Product.Id") %>' CommandName="rem"></asp:LinkButton>
                                </td>
                            </tr>
                         
                </ItemTemplate>
             
            </asp:ListView>
        </div>
          <div class="col-md-12">

              <a href="Default.aspx" class="btn btn-primary"> Continue Shopping</a>
              &nbsp;&nbsp;&nbsp;
              <a href="AuthenticatedUser/OrderInfo.aspx" class="btn btn-primary">Confirm Order</a>
          </div>
    </div>
</asp:Content>
