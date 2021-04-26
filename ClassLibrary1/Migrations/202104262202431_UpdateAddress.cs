namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Address", "AddressLine2", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Address", "AddressLine2", c => c.String(nullable: false));
        }
    }
}
