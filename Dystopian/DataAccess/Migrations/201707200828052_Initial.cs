namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        Points = c.Int(nullable: false),
                        OptionGroup = c.Int(),
                        Active = c.Boolean(nullable: false),
                        Ship_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ships", t => t.Ship_Id)
                .Index(t => t.Ship_Id);
            
            CreateTable(
                "dbo.Ships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Size = c.String(),
                        BasePoints = c.Int(nullable: false),
                        CurrentPoints = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        SquadronEntry_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SquadronEntries", t => t.SquadronEntry_ID)
                .Index(t => t.SquadronEntry_ID);
            
            CreateTable(
                "dbo.SquadronEntries",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Minimum = c.Int(nullable: false),
                        Maximum = c.Int(nullable: false),
                        Squadron_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Squadrons", t => t.Squadron_ID)
                .Index(t => t.Squadron_ID);
            
            CreateTable(
                "dbo.Squadrons",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SquadronEntries", "Squadron_ID", "dbo.Squadrons");
            DropForeignKey("dbo.Ships", "SquadronEntry_ID", "dbo.SquadronEntries");
            DropForeignKey("dbo.Options", "Ship_Id", "dbo.Ships");
            DropIndex("dbo.SquadronEntries", new[] { "Squadron_ID" });
            DropIndex("dbo.Ships", new[] { "SquadronEntry_ID" });
            DropIndex("dbo.Options", new[] { "Ship_Id" });
            DropTable("dbo.Squadrons");
            DropTable("dbo.SquadronEntries");
            DropTable("dbo.Ships");
            DropTable("dbo.Options");
        }
    }
}
