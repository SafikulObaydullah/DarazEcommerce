using ShoppingSystem.DAL;
using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSystem.AuthenticatedUser
{
    public partial class OrderInfo : System.Web.UI.Page
    {
        List<CartItem> cartItems = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                cartItems = Session["cart"] as List<CartItem>;
                this.productList.DataSource = cartItems;
                this.productList.DataBind();
            }
        }

        protected void btncheckout_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.ConactNo = txtcon.Text;
            customer.Email = txtEmail.Text;
            customer.ShippingAddress = txtAdd.Text;
            customer.Name = txtname.Text;
            int result = new OrderAcc().Save(cartItems, customer);
            if (result > 0)
            {
                Response.Redirect("/AuthenticatedUser/Thankyou.aspx");
            }
        }
    }
}