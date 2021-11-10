namespace DarazEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "FeaturedPic", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "FeaturedPic");
        }
    }
}
