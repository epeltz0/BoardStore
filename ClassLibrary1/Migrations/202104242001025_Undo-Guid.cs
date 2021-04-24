namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UndoGuid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "UserId");
            DropColumn("dbo.Order", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Customer", "UserId", c => c.Guid(nullable: false));
        }
    }
}
