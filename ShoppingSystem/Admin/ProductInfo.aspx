<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminSite.Master" AutoEventWireup="true" CodeBehind="ProductInfo.aspx.cs" Inherits="ShoppingSystem.Admin.ProductInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <label class="control-label">Category</label>
                <asp:DropDownList ID="drpCat" runat="server" CssClass="form-control" 
                    AppendDataBoundItems="True" AutoPostBack="True">
                    <asp:ListItem Value="0">Select Category</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Origin</label>
                <asp:DropDownList ID="drpOrigin" runat="server" CssClass="form-control" 
                    AutoPostBack="True"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Brand</label>
                <asp:DropDownList ID="drpBrand" runat="server" CssClass="form-control" 
                    AutoPostBack="True" OnSelectedIndexChanged="drpBrand_SelectedIndexChanged" ></asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Model</label>
                <asp:DropDownList ID="drpModel" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label class="control-label">Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Description</label>
                <asp:TextBox ID="txtDes" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
             <div class="form-group">
                <label class="control-label">Price</label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label">Feature</label>
                <asp:TextBox  ID="txtfeature" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="control-label">Video</label>
                <asp:FileUpload ID="fldVdo" runat="server" />
            </div>
            
            <div class="form-group">
                <label class="control-label">Picture</label>
                <asp:FileUpload ID="fldImage" runat="server" AllowMultiple="true" />
            </div>
             <div class="form-group">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            &nbsp;<asp:Label ID="lbl" runat="server"></asp:Label>
            </div>
        </div>
        <div class="col-md-6">

        </div>
    </div>
</asp:Content>
