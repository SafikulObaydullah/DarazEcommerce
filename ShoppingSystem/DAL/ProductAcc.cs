using ShoppingSystem.Models;
using ShoppingSystem.ViewModel;
//using B1_C31_Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystem.DAL
{
    public class ProductAcc
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Product> GetAll()
        {
            return db.Products.OrderBy(c => c.Name).ToList();
        }
        public List<Product> GetAll(int catid)
        {
            return db.Products.OrderBy(c => c.Name).Where(c=>c.CatId==catid).ToList();
        }
        public Product GetById(int Id)
        {
            return db.Products.Find(Id);
        }
        public int Save(Product prd)
        {
            db.Products.Add(prd);
           int result=  db.SaveChanges();
            if (result > 0)
            {
               
                foreach (var img in prd.ImageList)
                {
                    PrdImage prdImage = new PrdImage();
                    prdImage.ImagePath = img;
                    prdImage.ProductId = prd.Id;
                    db.PrdImages.Add(prdImage);
                    result = db.SaveChanges();
                }
            }
            return result;
        }
        public int Update(Product prd)
        {
            db.Entry(prd).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int prdId)
        {
            Product prd= db.Products.Find(prdId);
            db.Products.Remove(prd);
            return db.SaveChanges();
        }
        
        public ProductVM GetAllInfo(int id)
        {
            var prd = db.Products.Include("Brand")
                                .Include("Model")
                                .Include("Category")
                                .Select(s => new ProductVM
                                {
                                    Name = s.Name,
                                    Description = s.Description,
                                    Feature = s.Feature,
                                    FeaturedPic = s.FeaturedPic,
                                    CategoryName = s.Category.Name,
                                    BrandName = s.Brand.Name,
                                    ModelName = s.Model.Name,
                                    OriginName = s.OriginCountry.OriginCountryName,
                                    Price=s.Price,
                                    Warranty=s.Warranty,
                                    VideoPath=s.VideoPath,
                                    Id=s.Id
                                }).Where(p=>p.Id==id).SingleOrDefault();

            return prd;

        }
        public List<PrdImage> GetImg(int id)
        {
            return db.PrdImages.Where(c=>c.ProductId==id).ToList();

        }
    }
}