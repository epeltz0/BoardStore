namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction", "BoardId", "dbo.Board");
            DropForeignKey("dbo.Transaction", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Transaction", new[] { "CustomerId" });
            DropIndex("dbo.Transaction", new[] { "BoardId" });
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        BoardId = c.Int(nullable: false),
                        DateOfTransaction = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Board", t => t.BoardId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.BoardId);
            
            DropTable("dbo.Roles");
           
        }
        
        public override void Down()
        {
           
            
            DropForeignKey("dbo.Order", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Order", "BoardId", "dbo.Board");
            DropIndex("dbo.Order", new[] { "BoardId" });
            DropIndex("dbo.Order", new[] { "CustomerId" });
            DropTable("dbo.Order");
          
        }
    }
}
