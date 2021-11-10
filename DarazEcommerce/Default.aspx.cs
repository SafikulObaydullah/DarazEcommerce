using DarazEcommerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DarazEcommerce
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int cid = 0;

                if (Request.QueryString["cid"] != null)
                {
                    cid = int.Parse(Request.QueryString["cid"]);

                }

                LoadProduct(cid);
            }

        }

        private void LoadProduct(int cid)
        {
            if (cid > 0)
            {
                this.productList.DataSource = new ProductAcc().GetAll(cid);
                this.productList.DataBind();
            }
            else
            {
                this.productList.DataSource = new ProductAcc().GetAll();
                this.productList.DataBind();

            };
        }
    }
}