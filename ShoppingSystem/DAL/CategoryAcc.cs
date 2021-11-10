using ShoppingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using static ShoppingSystem.Models.ApplicationDbContext;

namespace ShoppingSystem.DAL
{
    public class CategoryAcc
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Category> GetAll()
        {
            return db.Categories.OrderBy(c => c.Name).ToList();
        }
        public int Save(Category category)
        {
            db.Categories.Add(category);
            return db.SaveChanges();
        }
        public int Update(Category category)
        {
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int prdId)
        {
            var category = db.Categories.Find(prdId);
            db.Categories.Remove(category);
            return db.SaveChanges();
        }

        public Category GetById(int id)
        {
            return db.Categories.Find(id);
        }
    }
}