using ShoppingSystem.DAL;
using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSystem.Admin
{
    public partial class ProductInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCate();
                LoadBrand();

                LoadOrigin();
            }
        }

        private void LoadOrigin()
        {
            this.drpOrigin.DataSource = new OriginAcc().GetAll();
            this.drpOrigin.DataTextField = "OriginCountryName";
            this.drpOrigin.DataValueField = "Id";
            this.drpOrigin.DataBind();
        }

        private void LoadModel(int brandID)
        {
            this.drpModel.DataSource = new ModelAcc().GetAllByBrand(brandID);
            this.drpModel.DataTextField = "Name";
            this.drpModel.DataValueField = "Id";
            this.drpModel.DataBind();
        }

        private void LoadBrand()
        {
            this.drpBrand.DataSource = new BrandAcc().GetAll();
            this.drpBrand.DataTextField = "Name";
            this.drpBrand.DataValueField = "Id";
            this.drpBrand.DataBind();
        }

        private void LoadCate()
        {
            this.drpCat.DataSource = new CategoryAcc().GetAll();
            this.drpCat.DataTextField = "Name";
            this.drpCat.DataValueField = "Id";
            this.drpCat.DataBind();
        }

        protected void drpBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadModel(int.Parse(this.drpBrand.SelectedValue));

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Product product = new Product();


            if (fldVdo.HasFile)
            {
                string fileName = fldVdo.PostedFile.FileName;
                string ext = Path.GetExtension(fileName).ToLower();

                if (ext == ".mp3" || ext == ".mp4" || ext == ".flv")
                {
                    if (!Directory.Exists(Server.MapPath("~/Video")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Video"));
                    }
                    string fName = txtName.Text + ext;
                    fldVdo.PostedFile.SaveAs(Path.Combine(Server.MapPath("~/Video"), fName));
                    product.VideoPath = "/Video/" + fName;
                }
                //else
                //{
                //    this.lblmsg.Text = "Please provide product image jpg,jpeg or png format";
                //    this.lblmsg.ForeColor = System.Drawing.Color.Red;
                //    return;
                //}

            }
            product.ModelId = int.Parse(drpModel.SelectedValue);
            product.OriginId = int.Parse(drpOrigin.SelectedValue);
            product.Price = decimal.Parse(txtPrice.Text);
            //product.Warranty=tx
            product.Name = txtName.Text;
            product.Description = txtDes.Text;
            product.Feature = txtfeature.Text;
            product.BrandId = int.Parse(drpBrand.SelectedValue);

            product.CatId = int.Parse(drpCat.SelectedValue);
            List<string> Imaglist = new List<string>();
            if (fldImage.HasFile)
            {
                //PrdImage prdImage = new PrdImage();

                foreach (HttpPostedFile postedFile in fldImage.PostedFiles)
                {
                    string imagePath = "";
                    string fileName = postedFile.FileName;
                    string ext = Path.GetExtension(fileName).ToLower();

                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        if (!Directory.Exists(Server.MapPath("~/Images")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Images"));
                        }
                        string fName = Path.GetFileNameWithoutExtension(fileName) + "-" + txtName.Text + ext;
                        postedFile.SaveAs(Path.Combine(Server.MapPath("~/Images"), fName));
                        //prdImage.ImagePath = "/Images/" + fName;
                        //prdImage.ProductId = product.Id;
                        imagePath = "/Images/" + fName;
                        Imaglist.Add(imagePath);
                    }
                    else
                    {
                        this.lbl.Text = "Please provide product image jpg,jpeg or png format";
                        this.lbl.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }




            }
            else
            {
                this.lbl.Text = "Please provide product image jpg,jpeg or png format";
                this.lbl.ForeColor = System.Drawing.Color.Red;
                return;
            }
            product.ImageList = Imaglist;
            if (new ProductAcc().Save(product) > 0)
            {
                this.lbl.Text = "success";
            }
            else
            {
                this.lbl.Text = "fail";

            }
        }
    }
}