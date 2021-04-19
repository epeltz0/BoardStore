namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Catagory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        YearsSkating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            AddColumn("dbo.Board", "BoardCategory", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "DateOfTransaction", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Transaction", "CustomerId");
            CreateIndex("dbo.Transaction", "BoardId");
            AddForeignKey("dbo.Transaction", "BoardId", "dbo.Board", "BoardId", cascadeDelete: true);
            AddForeignKey("dbo.Transaction", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
            DropTable("dbo.Ratings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        BoardId = c.Int(nullable: false),
                        OverallRating = c.Int(nullable: false),
                        AffordabilityRating = c.Int(nullable: false),
                        DurabilityRating = c.Int(nullable: false),
                        SpeedRating = c.Int(nullable: false),
                        StyleRating = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.RatingId);
            
            DropForeignKey("dbo.Transaction", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Transaction", "BoardId", "dbo.Board");
            DropIndex("dbo.Transaction", new[] { "BoardId" });
            DropIndex("dbo.Transaction", new[] { "CustomerId" });
            DropColumn("dbo.Transaction", "DateOfTransaction");
            DropColumn("dbo.Transaction", "CustomerId");
            DropColumn("dbo.Board", "BoardCategory");
            DropTable("dbo.Customer");
        }
    }
}
