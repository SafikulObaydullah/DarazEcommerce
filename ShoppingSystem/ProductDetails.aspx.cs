using ShoppingSystem.DAL;
using ShoppingSystem.Models;
using ShoppingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSystem
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        public static int PrdId { get; set; }
        List<CartItem> cartItems;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrdId = Int32.Parse(Request.QueryString["Id"].ToString());
                LoadProduct(PrdId);
                LoadProductImg(PrdId);

            }
            if (Session["cart"] != null)
            {
                cartItems = Session["cart"] as List<CartItem>;
            }
            else
            {
                cartItems = new List<CartItem>();
            }

        }
        private void LoadProductImg(int id)
        {
            List<PrdImage> p = new ProductAcc().GetImg(id);
            foreach (var item in p)
            {
                this.imgGallery.InnerHtml += $"<img src='{item.ImagePath}' class='imgStyle' id='mainimg'  runat='server' />";
            }
        }
        private void LoadProduct(int id)
        {
            ProductVM p = new ProductAcc().GetAllInfo(id);
            this.title.InnerText = p.Name;
            this.des.InnerText = p.Description;
            this.price.InnerText = p.Price.ToString();
            this.mainimg.Src = p.FeaturedPic;
            this.feature.Src = p.VideoPath;
        }

        protected void addToCart_Click(object sender, EventArgs e)
        {
            Session["cart"] = null;
            if (Session["cart"] != null)
            {
                cartItems = Session["cart"] as List<CartItem>;
            }
            if (cartItems.Count > 0)
            {
                var citem = cartItems.Where(p => p.ProductId == PrdId).SingleOrDefault();
                if (citem != null)
                {
                    citem.Quantity = citem.Quantity + 1;
                    //cartItems.Add(citem);
                    Session["cart"] = cartItems;
                }
                else
                {
                    CartItem cartItem = new CartItem();
                    cartItem.DateCreated = DateTime.Now;
                    cartItem.ProductId = PrdId;
                    cartItem.Quantity = 1;
                    cartItem.Product = new ProductAcc().GetById(PrdId); ;
                    cartItems.Add(cartItem);
                    Session["cart"] = cartItems;

                }
                //foreach (var item in cartItems)
                //{
                //    if (item.ProductId == PrdId)
                //    {
                //        item.Quantity = item.Quantity + 1;
                //        Session["cart"] = cartItems;
                //    }
                //    else
                //    {
                //        CartItem cartItem = new CartItem();
                //        cartItem.DateCreated = DateTime.Now;
                //        cartItem.ProductId = PrdId;
                //        cartItem.Quantity = 1;
                //        cartItem.Product = new ProductAcc().GetById(PrdId); ;
                //        cartItems.Add(cartItem);
                //        Session["cart"] = cartItems;
                //        break;
                //    }


                //}
            }
            else
            {
                CartItem cartItem = new CartItem();
                cartItem.DateCreated = DateTime.Now;
                cartItem.ProductId = PrdId;
                cartItem.Quantity = 1;
                cartItem.Product = new ProductAcc().GetById(PrdId); ;
                cartItems.Add(cartItem);
                Session["cart"] = cartItems;
            }
        }

        protected void btnbuy_Click(object sender, EventArgs e)
        {

        }
    }
}