using DarazEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static DarazEcommerce.Models.ApplicationDbContext;

namespace DarazEcommerce.DAL
{
    public class BrandAcc
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Brand> GetAll()
        {
            return db.Brands.OrderBy(c => c.Name).ToList();
        }
        public Brand GetById(int Id)
        {
            return db.Brands.Find(Id);
        }
        public int Save(Brand brd)
        {
            db.Brands.Add(brd);
            return db.SaveChanges();
        }
        public int Update(Brand brd)
        {
            db.Entry(brd).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int prdId)
        {
            Brand prd = db.Brands.Find(prdId);
            db.Brands.Remove(prd);
            return db.SaveChanges();
        }
    }
}