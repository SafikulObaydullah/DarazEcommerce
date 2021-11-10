using ShoppingSystem.Models;
using ShoppingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingSystem.DAL
{
    public class OrderAcc
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Order> GetAll()
        {
            return db.Orders.OrderBy(c => c.OrderDate).ToList();
        }
        public List<Order> GetAll(int catid)
        {
            return db.Orders.OrderBy(c => c.OrderDate).Where(c=>c.Product.CatId==catid).ToList();
        }
        public Order GetById(int Id)
        {
            return db.Orders.Find(Id);
        }
        public int Save(List<CartItem> cart,Customer customer)
        {
            int result = 0;
            using (DbContextTransaction tran = db.Database.BeginTransaction())
            {
                try
                {
               
                    db.Customers.Add(customer);
                    db.SaveChanges();
                    // db.Orders.Max(o => o.OrderNo);
                    int oNo = (db.Orders.Select(o => o.OrderNo)
                                        .DefaultIfEmpty(0)
                                        .Max()) + 1;

                    foreach (var item in cart)
                    {
                        Order order = new Order();

                        order.CusId = customer.Id;
                        //order.Customer = customer;
                        order.OrderDate = DateTime.Now;
                        order.OrderNo = oNo;
                        order.OrderqTY = item.Quantity;
                        order.Amount = item.Quantity * item.Product.Price;
                        order.PrdID = item.ProductId;
                       //order.Product = item.Product;

                        db.Orders.Add(order);

                    }
                    result = db.SaveChanges();
                    tran.Commit();
                
            }
            catch(Exception  ex)
            {
                    tran.Rollback();
            }
            }
            return result;
        }
        public int Save(Order prd)
        {
            db.Orders.Add(prd);
           int result=  db.SaveChanges();
            
            return result;
        }
        public int Update(Order prd)
        {
            db.Entry(prd).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int prdId)
        {
            Order prd= db.Orders.Find(prdId);
            db.Orders.Remove(prd);
            return db.SaveChanges();
        }
       
       
    }
}