<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="AssignRole.aspx.cs" Inherits="ShoppingSystem.Admin.AssignRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Assign User To Role</h2>
            <div class="form-group">
                <label class="control-label">User Name</label>
                <asp:DropDownList ID="drpUser" runat="server"  ></asp:DropDownList>
            </div>
             <div class="form-group">
                <label class="control-label">Role </label>
                <asp:CheckBoxList ID="chkrole"  runat="server"  ></asp:CheckBoxList>
            </div>
</asp:Content>
