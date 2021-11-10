using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using ShoppingSystem.DAL;
using ShoppingSystem.Models;

namespace ShoppingSystem
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCate();
        }
        private void LoadCate()
        {
            this.drpCat.DataSource = new CategoryAcc().GetAll();
            this.drpCat.DataTextField = "Name";
            this.drpCat.DataValueField = "Id";
            this.drpCat.DataBind();
        }
        protected override void OnPreRender(EventArgs e)
        {
            if (Session["cart"] != null)
            {
                List<CartItem> cartItems = Session["cart"] as List<CartItem>;
                int c = cartItems.Count;
                this.count.InnerHtml = $"<span class='glyphicon glyphicon-shopping-cart' ></span>({c})";
            }
            else
            {
                this.count.InnerHtml = $"<span class='glyphicon glyphicon-shopping-cart' ></span>({0})";
            }
            List<Category> catList = new List<Category>();
            string menu = "";
            catList = new CategoryAcc().GetAll();
            foreach (var item in catList)
            {
                menu += "<li class='nav - item'> "
                               + "<a href = '/Default?cid=" + item.Id + "' class='nav-link text-dark font-italic bg-light'>"
                                  + " <i class='fa fa-th-large mr-3 text-primary fa-fw'></i> "
                               + item.Name
                              + " </a></li>";
                this.leftMenu.InnerHtml = menu;
            }

            base.OnPreRender(e);
        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

}