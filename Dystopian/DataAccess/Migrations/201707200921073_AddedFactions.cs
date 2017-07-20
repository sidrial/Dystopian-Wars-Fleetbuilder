namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFactions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Squadrons", "FactionID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Squadrons", "FactionID");
        }
    }
}
