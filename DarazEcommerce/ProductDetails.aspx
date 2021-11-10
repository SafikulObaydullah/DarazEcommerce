<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="DarazEcommerce.ProductDetails" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .imgStyle{
            height:80px;
            width:50px;
            border: 1px solid grey ;
            margin: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <div id="maindiv">
                <img src="" id="mainimg" runat="server"  />
            </div>
            <div id="imgGallery" runat="server">
            </div>
            <div>
                <video id="feature" runat="server" height="200" width="250" controls loop="loop"></video>
            </div>
            <script>
                $(document).ready(function () {
                    $("#MainContent_imgGallery img").click(function () {
                        //alert("hi");
                    })
                    $("#MainContent_imgGallery img").mouseover(function () {
                        $(this).css({ 'cursor': 'hand', 'border-color': 'red' });
                    })
                    $("#MainContent_imgGallery img").mouseout(function () {
                        $(this).css({ 'cursor': 'default', 'border-color': 'gray' });
                    })
                    $("#MainContent_imgGallery img").click(function () {
                        var imgUrl = $(this).attr('src');
                        console.log(imgUrl)
                        $("#maindiv img").fadeOut(500, function () {
                            $(this).attr('src', imgUrl);
                        }).fadeIn(500);
                    })
                })
            </script>
        </div>
           <div class="col-md-8" style="padding-left:5px">
               <h2 id="title" runat="server"></h2>
               <div id="des" runat="server"></div>
               <p id="price" runat="server"></p>
               <div>
                   <asp:Button ID="addtoCart" runat="server" Text="Add To Cart" Onclick="addtoCart_Click" />
               </div>
           </div>
    </div>
</asp:Content>
