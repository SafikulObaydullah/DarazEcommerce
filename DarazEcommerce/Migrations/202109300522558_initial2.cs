namespace DarazEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.OriginCountries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OriginCountryName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrdImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Products", "VideoPath", c => c.String());
            CreateIndex("dbo.Products", "BrandId");
            CreateIndex("dbo.Products", "ModelId");
            CreateIndex("dbo.Products", "OriginId");
            AddForeignKey("dbo.Products", "BrandId", "dbo.Brands", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Products", "ModelId", "dbo.Models", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "OriginId", "dbo.OriginCountries", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "ColorID");
            DropColumn("dbo.Products", "Video");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Video", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ColorID", c => c.Int(nullable: false));
            DropForeignKey("dbo.PrdImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "OriginId", "dbo.OriginCountries");
            DropForeignKey("dbo.Products", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Models", "BrandId", "dbo.Brands");
            DropIndex("dbo.PrdImages", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "OriginId" });
            DropIndex("dbo.Products", new[] { "ModelId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Models", new[] { "BrandId" });
            DropColumn("dbo.Products", "VideoPath");
            DropTable("dbo.PrdImages");
            DropTable("dbo.OriginCountries");
            DropTable("dbo.Models");
            DropTable("dbo.Brands");
        }
    }
}
