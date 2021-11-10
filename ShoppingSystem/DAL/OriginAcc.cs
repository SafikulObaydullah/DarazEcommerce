using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystem.DAL
{
    public class OriginAcc
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<OriginCountry> GetAll()
        {
            return db.OriginCountries.OrderBy(c => c.OriginCountryName).ToList();
        }
        public OriginCountry GetById(int Id)
        {
            return db.OriginCountries.Find(Id);
        }
        public int Save(OriginCountry prd)
        {
            db.OriginCountries.Add(prd);
            return db.SaveChanges();
        }
        public int Update(OriginCountry prd)
        {
            db.Entry(prd).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int prdId)
        {
            OriginCountry prd= db.OriginCountries.Find(prdId);
            db.OriginCountries.Remove(prd);
            return db.SaveChanges();
        }
    }
}