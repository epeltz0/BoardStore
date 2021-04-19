namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class role : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IdentityRole", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IdentityRole", "Discriminator");
        }
    }
}
