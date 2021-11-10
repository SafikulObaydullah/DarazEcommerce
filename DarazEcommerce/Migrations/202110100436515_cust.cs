namespace DarazEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cust : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ConactNo = c.String(maxLength: 15),
                        ShippingAddress = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
