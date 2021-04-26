namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Address : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(nullable: false),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
            AddColumn("dbo.Board", "BoardQuality", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customer", "AddressId");
            AddForeignKey("dbo.Customer", "AddressId", "dbo.Address", "AddressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "AddressId", "dbo.Address");
            DropIndex("dbo.Customer", new[] { "AddressId" });
            DropColumn("dbo.Customer", "AddressId");
            DropColumn("dbo.Board", "BoardQuality");
            DropTable("dbo.Address");
        }
    }
}
