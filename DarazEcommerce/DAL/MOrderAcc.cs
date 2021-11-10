using DarazEcommerce.Models;
using DarazEcommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static DarazEcommerce.Models.ApplicationDbContext;

namespace DarazEcommerce.DAL
{
    public class MOrderAcc 
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<MOrder> GetAll()
        {
            return db.MOrders.OrderBy(c => c.MOrderDate).ToList();
        }
        public List<MOrder> GetAll(int catid)
        {
            return db.MOrders.OrderBy(c => c.MOrderDate).Where(c => c.Product.CatId == catid).ToList();
        }
        public MOrder GetById(int Id)
        {
            return db.MOrders.Find(Id);
        }
        public int Save(List<CartItem> cart, Customer customer)
        {
            int result = 0;
            using (DbContextTransaction tran = db.Database.BeginTransaction())
            {
                try
                {

                    db.Customers.Add(customer);
                    db.SaveChanges();
                    // db.Orders.Max(o => o.OrderNo);
                    int oNo = (db.MOrders.Select(o => o.MOrderNo)
                                        .DefaultIfEmpty(0)
                                        .Max()) + 1;

                    foreach (var item in cart)
                    {
                        MOrder order = new MOrder();

                        order.CusId = customer.Id;
                        //order.Customer = customer;
                        order.MOrderDate = DateTime.Now;
                        order.MOrderNo = oNo;
                        order.MOrderqty = item.Quantity;
                        order.MOamount = item.Quantity * item.Product.Price;
                        order.MPrdId = item.ProductId;
                        //order.Product = item.Product;

                        db.MOrders.Add(order);

                    }
                    result = db.SaveChanges();
                    tran.Commit();

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
            }
            return result;
        }
        public int Save(MOrder prd)
        {
            db.MOrders.Add(prd);
            int result = db.SaveChanges();

            return result;
        }
        public int Update(MOrder prd)
        {
            db.Entry(prd).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public int Delete(int prdId)
        {
            MOrder prd = db.MOrders.Find(prdId);
            db.MOrders.Remove(prd);
            return db.SaveChanges();
        }

        

    }
}