namespace ClothesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        NewsTitle = c.String(nullable: false, maxLength: 500),
                        Image = c.Binary(),
                        Content = c.String(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NewsID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatID = c.Int(nullable: false, identity: true),
                        CatName = c.String(nullable: false, maxLength: 100),
                        ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.CatID)
                .ForeignKey("dbo.Categories", t => t.ParentID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(nullable: false, maxLength: 10),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 500),
                        CatID = c.Int(nullable: false),
                        ProID = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CatID, cascadeDelete: true)
                .ForeignKey("dbo.Promotions", t => t.ProID)
                .Index(t => t.CatID)
                .Index(t => t.ProID);
            
            CreateTable(
                "dbo.Promotions",
                c => new
                    {
                        ProID = c.Int(nullable: false, identity: true),
                        DisCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProID);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        LoginName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProductImages", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "ProID" });
            DropIndex("dbo.Products", new[] { "CatID" });
            DropIndex("dbo.Categories", new[] { "ParentID" });
            DropForeignKey("dbo.ProductImages", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "ProID", "dbo.Promotions");
            DropForeignKey("dbo.Products", "CatID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentID", "dbo.Categories");
            DropTable("dbo.Users");
            DropTable("dbo.ProductImages");
            DropTable("dbo.Promotions");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.News");
        }
    }
}
