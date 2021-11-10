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
    public partial class AssignRole : System.Web.UI.Page
    {
        UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

        RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        ApplicationDbContext db = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUser();
            LoadRole();
        }

        private void LoadRole()
        {
            this.chkrole.DataSource = db.Roles.ToList();
            this.chkrole.DataTextField = "Name";
            this.chkrole.DataValueField = "Id";
            this.chkrole.DataBind();
        }

        private void LoadUser()
        {
            this.drpUser.DataSource = db.Users.ToList();
            this.drpUser.DataTextField = "Email";
            this.drpUser.DataValueField = "Id";
            this.drpUser.DataBind();
        }
    }
}