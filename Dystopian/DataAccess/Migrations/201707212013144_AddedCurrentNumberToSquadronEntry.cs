namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCurrentNumberToSquadronEntry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SquadronEntries", "CurrentNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SquadronEntries", "CurrentNumber");
        }
    }
}
