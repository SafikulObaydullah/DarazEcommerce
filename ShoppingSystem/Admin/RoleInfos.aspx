<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="RoleInfos.aspx.cs" Inherits="ShoppingSystem.Admin.RoleInfos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12">
          <label class="control-label" id="msg" runat="server"></label>
        <div class="form-group">

                <label class="control-label">Name</label>
                <asp:TextBox ID="txtname" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
         <div class="form-group">
                  <asp:Button runat="server" ID="btncreate"  Text="Create"  CssClass="btn btn-success"
        
        Onclick="btncreate_Click" />
            </div>
    </div>
</asp:Content>
