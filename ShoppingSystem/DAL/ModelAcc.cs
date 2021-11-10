using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystem.DAL
{
    public class ModelAcc
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Model> GetAll()
        {
            return db.Models.OrderBy(c => c.Name).ToList();
        }
        public List<Model> GetAllByBrand(int brandId)
        {
            return db.Models.Where(m=>m.BrandId==brandId).OrderBy(c => c.Name).ToList();
        }
        public Model GetById(int Id)
        {
            return db.Models.Find(Id);
        }
        public int Save(Model prd)
        {
            db.Models.Add(prd);
            return db.SaveChanges();
        }
        public int Update(Model prd)
        {
            db.Entry(prd).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int prdId)
        {
            Model prd= db.Models.Find(prdId);
            db.Models.Remove(prd);
            return db.SaveChanges();
        }
    }
}