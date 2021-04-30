namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "AddressId", "dbo.Address");
            DropIndex("dbo.Customer", new[] { "AddressId" });
            AddColumn("dbo.Address", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Address", "CustomerId");
            AddForeignKey("dbo.Address", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
            DropColumn("dbo.Customer", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "AddressId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Address", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Address", new[] { "CustomerId" });
            DropColumn("dbo.Address", "CustomerId");
            CreateIndex("dbo.Customer", "AddressId");
            AddForeignKey("dbo.Customer", "AddressId", "dbo.Address", "AddressId", cascadeDelete: true);
        }
    }
}
