namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsAttachment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SquadronEntries", "IsAttachment", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SquadronEntries", "IsAttachment");
        }
    }
}
