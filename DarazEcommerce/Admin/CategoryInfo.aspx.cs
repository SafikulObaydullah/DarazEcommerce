using DarazEcommerce.DAL;
using DarazEcommerce.Models;
using System;
using System.Web.UI.WebControls;
using static DarazEcommerce.Models.ApplicationDbContext;

namespace DarazEcommerce.Admin
{
    public partial class CategoryInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name = txtName.Text;
            category.Description = txtDsc.Text;
            if (drpCategory.Visible)
            {
                category.ParentId = Int32.Parse(drpCategory.SelectedValue);
            }
            if (new CategoryAcc().Save(category) > 0)
            {
                lblmsg.Text = "Successfully Saved";
                AllClear();
                GridView1.DataSourceID = CategoryDataSource.ID;
                GridView1.DataBind();
            }
        }

        protected void chkparent_CheckedChanged(object sender, EventArgs e)
        {
            this.prntDiv.Visible = true;
            this.chkdiv.Visible = false;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "edt")
            {
                Category category = new CategoryAcc().GetById(id);
                if (category != null)
                {
                    txtName.Text = category.Name;
                    txtDsc.Text = category.Description;
                    if (category.ParentId != 0)
                    {
                        this.prntDiv.Visible = true;
                        this.chkdiv.Visible = false;
                        this.drpCategory.SelectedValue = category.ParentId.ToString();
                    }
                    hdn.Value = category.Id.ToString();
                    this.btnUpdate.Visible = true;
                    this.btnSave.Visible = false;
                }

            }
            if (e.CommandName == "del")
            {
                if (new CategoryAcc().Delete(id) > 0)
                {
                    lblmsg.Text = "Successfully Deleted ";
                    GridView1.DataSourceID = CategoryDataSource.ID;
                    GridView1.DataBind();
                }

            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name = txtName.Text;
            category.Description = txtDsc.Text;
            category.Id = int.Parse(hdn.Value);
            if (drpCategory.Visible)
            {
                category.ParentId = Int32.Parse(drpCategory.SelectedValue);
            }
            if (new CategoryAcc().Update(category) > 0)
            {
                lblmsg.Text = "Successfully Update";
                AllClear();
                GridView1.DataSourceID = CategoryDataSource.ID;
                GridView1.DataBind();
            }
        }

        private void AllClear()
        {
            txtName.Text = "";
            txtDsc.Text = "";

            this.prntDiv.Visible = false;
            this.chkdiv.Visible = true;
            this.drpCategory.SelectedValue = null;

            hdn.Value = "";
            this.btnUpdate.Visible = false;
            this.btnSave.Visible = true;
        }
    }
}