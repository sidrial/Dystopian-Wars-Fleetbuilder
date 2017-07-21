namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFactionsAndSuperblocks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Factions",
                c => new
                    {
                        FactionID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Acronym = c.String(),
                        SuperBlock_ID = c.Int(),
                    })
                .PrimaryKey(t => t.FactionID)
                .ForeignKey("dbo.SuperBlocks", t => t.SuperBlock_ID)
                .Index(t => t.SuperBlock_ID);
            
            CreateTable(
                "dbo.SuperBlocks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Squadrons", "FactionID_FactionID", c => c.Guid());
            CreateIndex("dbo.Squadrons", "FactionID_FactionID");
            AddForeignKey("dbo.Squadrons", "FactionID_FactionID", "dbo.Factions", "FactionID");
            DropColumn("dbo.Squadrons", "FactionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Squadrons", "FactionID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Squadrons", "FactionID_FactionID", "dbo.Factions");
            DropForeignKey("dbo.Factions", "SuperBlock_ID", "dbo.SuperBlocks");
            DropIndex("dbo.Squadrons", new[] { "FactionID_FactionID" });
            DropIndex("dbo.Factions", new[] { "SuperBlock_ID" });
            DropColumn("dbo.Squadrons", "FactionID_FactionID");
            DropTable("dbo.SuperBlocks");
            DropTable("dbo.Factions");
        }
    }
}
