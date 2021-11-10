using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static  DarazEcommerce.Models.ApplicationDbContext;
using System.ComponentModel;
using DarazEcommerce.Models;

namespace DarazEcommerce
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        List<CartItem> cartItems = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
                if (Session["cart"] != null)
                {
                    cartItems = Session["cart"] as List<CartItem>;
                    this.productList.DataSource = cartItems;
                    this.productList.DataBind();
                }
            //}
           
        }

        protected void productList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            if(e.CommandName=="rem" && id>0)
            {
                CartItem cartItem = cartItems.Where(c => c.ProductId == id).FirstOrDefault();
                cartItems.Remove(cartItem);
                Session["cart"] = cartItems;
                this.productList.DataSource = cartItems;
                this.productList.DataBind();
            }
        }
    }
}