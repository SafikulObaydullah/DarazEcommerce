<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="CategoryInfo.aspx.cs" Inherits="ShoppingSystem.Admin.CategoryInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <div class="col-md-6">
            <div class="form-group">
                <label>Name</label>
                <asp:HiddenField ID="hdn" runat="server" />
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="form-group">
                <label>Description</label>
                <asp:TextBox ID="txtDsc" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="form-group" id="chkdiv" runat="server" >
                <label>IsSub</label>
                  <asp:CheckBox ID="chkparent" runat="server" 
                       AutoPostBack="True" OnCheckedChanged="chkparent_CheckedChanged"   />
                 <%-- <asp:DropDownList ID="drpCategory" runat="server" Visible="False" CssClass="form-control" 
                      DataSourceID="CategoryDataSource" DataTextField="Name" DataValueField="Id"></asp:DropDownList>--%>
            </div>
              <div class="form-group" id="prntDiv"  visible="false" runat="server">
                <label>Parent Id</label>
                 
                  <asp:DropDownList ID="drpCategory" runat="server"  CssClass="form-control" 
                      DataSourceID="CategoryDataSource" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
            </div>
               <div class="form-group">
            <asp:Button ID="btnSave" runat="server" Text="Save"  Onclick="btnSave_Click" CssClass="btn btn-secondary" />
                   <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" Onclick="btnUpdate_Click" CssClass="btn btn-primary" />
        </div>
        </div>
            <div class="col-md-6">

                <asp:GridView ID="GridView1" runat="server"  DataKeyNames="Id"
                    DataSourceID="CategoryDataSource" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="....">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CommandArgument='<%#Eval("Id") %>'  CommandName="edt" Text="Edit" />
                                <asp:Button ID="btnDelete" runat="server" CommandName="del" Text="Delete"  CommandArgument='<%#Eval("Id") %>'  />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="CategoryDataSource" runat="server" 
                    SelectMethod="GetAll" TypeName="ShoppingSystem.DAL.CategoryAcc">
                </asp:ObjectDataSource>
            </div>
     
    </div>
    <script>
        $(document).ready(function () {
           
            //$("#chkparent").change(function () {
            //    if ($(this).is(':checked')) {
            //        // Do something...
            //        alert('You can rock now...');
            //    };
            //})
        })
           
       
    </script>
</asp:Content>
