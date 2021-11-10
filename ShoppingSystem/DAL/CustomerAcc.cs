using ShoppingSystem.Models;
using ShoppingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSystem.DAL
{
    public class CustomerAcc
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Customer> GetAll()
        {
            return db.Customers.OrderBy(c => c.Name).ToList();
        }
       
        public Customer GetById(int Id)
        {
            return db.Customers.Find(Id);
        }
        public int Save(Customer prd)
        {
            db.Customers.Add(prd);
            int result=  db.SaveChanges();
            if (result > 0)
            {
               
                
            }
            return result;
        }
        public int Update(Customer cust)
        {
            db.Entry(cust).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int cid)
        {
            Customer customer= db.Customers.Find(cid);
            db.Customers.Remove(customer);
            return db.SaveChanges();
        }
       
       
    }
}