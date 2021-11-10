<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ShoppingSystem.ProductDetails" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .imgStyle{
            height:80px;
            width:50px;
            border:1px solid grey;
            margin:2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-5">
            <div id="maindiv">
                <img src="" id="mainimg"  runat="server" height="300" width="400"/>
            </div>
            <div id="imgGallery" runat="server">

            </div>
             <div>
                   <video id="feature" runat="server" height="200" width="250" controls   loop="loop"></video>
               </div>
            <script>
                $(document).ready(function () {
                    $("#MainContent_imgGallery img").click(function () {
                       // alert("hi")
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
                        }).fadeIn(500)
                    })
                })
              
            </script>
        </div>
           <div class="col-md-7 " style=" padding-left: 35px;">
               <h2 id="title" runat="server"></h2>
               <div id="des" runat="server"></div>
               <p id="price" runat="server"></p>
              <div>
                
                  <asp:Button ID="addToCart" runat="server" Text="Add To Cart"  OnClick="addToCart_Click"/>
              </div>
               <hr />
               <div class="container">
                     <input type="button" onclick="decrementValue()" value="-" />
                      <input type="text" name="quantity" value="1" maxlength="2" max="10" size="1" id="number" />
                       <input type="button" onclick="incrementValue()" value="+" />
                        <asp:Button ID="btnbuy" runat="server" Text="Buy Now" class="btn btn-success" OnClick="btnbuy_Click" />
               </div>
               <script type="text/javascript">
                   function incrementValue() {
                       var value = parseInt(document.getElementById('number').value, 10);
                       value = isNaN(value) ? 0 : value;
                       if (value < 10) {
                           value++;
                           document.getElementById('number').value = value;
                       }
                   }
                   function decrementValue() {
                       var value = parseInt(document.getElementById('number').value, 10);
                       value = isNaN(value) ? 0 : value;
                       if (value > 1) {
                           value--;
                           document.getElementById('number').value = value;
                       }

                   }
               </script>
               <hr />
               <div class="col-md-10">
                   
            <table class="table table-success table-striped">
                <tr>
                    <th><a href="#">TECHNICAL SPACES</a></th>
                    <th><a href="#">MORE INFO</a></th>
                </tr>
                <tr>
                    <td><b>Brand</b></td>
                    <td>CITIZEN</td>
                </tr>
                <tr>
                    <td><b>Model</b></td>
                    <td>AN3560-51E ST BK MT</td>
                </tr>
                <tr>
                    <td><b>Family</b></td>
                    <td>CITIZEN</td>
                </tr>
                <tr>
                    <td><b>Movement</b></td>
                    <td>QUARTZ</td>
                </tr>
                <tr>
                    <td><b>Case Color</b></td>
                    <td>SILVER</td>
                </tr>
                <tr>
                    <td><b>Water Resistance</b></td>
                    <td>50M</td>
                </tr>

            </table>
        </div>
           </div>
        
    </div>
</asp:Content>
