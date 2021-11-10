namespace DarazEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thmdo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNo = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        OrderqTY = c.Int(nullable: false),
                        PrdID = c.Int(nullable: false),
                        DeliveryBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MOrders",
                c => new
                    {
                        MOrderId = c.Int(nullable: false, identity: true),
                        MOrderNo = c.Int(nullable: false),
                        MOrderDate = c.DateTime(nullable: false),
                        MOrderqty = c.Int(nullable: false),
                        MPrdId = c.Int(nullable: false),
                        MOamount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MOrderId)
                .ForeignKey("dbo.Products", t => t.MPrdId, cascadeDelete: true)
                .Index(t => t.MPrdId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MOrders", "MPrdId", "dbo.Products");
            DropIndex("dbo.MOrders", new[] { "MPrdId" });
            DropTable("dbo.MOrders");
            DropTable("dbo.Deliveries");
        }
    }
}
