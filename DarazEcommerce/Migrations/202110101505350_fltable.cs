namespace DarazEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fltable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MOrders", "CusId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Customer_Id", c => c.Int());
            CreateIndex("dbo.MOrders", "CusId");
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.MOrders", "CusId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MOrders", "CusId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.MOrders", new[] { "CusId" });
            DropColumn("dbo.Orders", "Customer_Id");
            DropColumn("dbo.MOrders", "CusId");
        }
    }
}
