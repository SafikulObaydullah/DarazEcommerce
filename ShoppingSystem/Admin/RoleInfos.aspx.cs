using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSystem.Admin
{
    public partial class RoleInfos : System.Web.UI.Page
    {
        RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            IdentityResult result = roleManager.Create(new IdentityRole { Name = this.txtname.Text });
            if(result.Succeeded)
            {
                this.msg.InnerText = "Role Created Successfully";
            }
            else if(result.Errors.Count()>0)
            {
                foreach(var eroor in result.Errors)
                {
                    this.msg.InnerText += eroor;
                }
            }
        }
    }
}