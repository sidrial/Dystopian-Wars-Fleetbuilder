namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMajorFactionBoolToFaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Factions", "MajorFaction", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Factions", "MajorFaction");
        }
    }
}