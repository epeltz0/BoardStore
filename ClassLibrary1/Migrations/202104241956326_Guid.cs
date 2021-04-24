namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Order", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "UserId");
            DropColumn("dbo.Customer", "UserId");
        }
    }
}
